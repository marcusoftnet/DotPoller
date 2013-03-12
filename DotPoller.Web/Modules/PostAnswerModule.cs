using System;
using System.Linq;
using DotPoller.Web.Infrastructure;
using DotPoller.Web.Models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace DotPoller.Web.Modules
{
    public class PostAnswerModule : NancyModule
    {
        public string CurrentUserIdentifier
        {
            get { return this.Request.Cookies.FirstOrDefault(k => k.Key == "NCSRF").Value; }
        }

        private readonly PollRepository _pollRepository;

        public PostAnswerModule(PollRepository pollRepository)
        {
            _pollRepository = pollRepository;

            Post["/poll/{id}/answer"] = p =>
                                            {
                                                var poll = AddAnswerToPoll(p.Id);
                                                return new RedirectResponse(poll.GetUrl());
                                            };
        }

        private Poll AddAnswerToPoll(string id)
        {
            var answer = this.Bind<PollAnswer>();
            answer.ClientId = CurrentUserIdentifier;

            var poll = _pollRepository.GetById(id);
            poll.Answers.Add(answer);
            _pollRepository.Update(poll);

            return poll;

        }
    }
}