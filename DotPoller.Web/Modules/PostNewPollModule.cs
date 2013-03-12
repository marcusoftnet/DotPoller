using System;
using DotPoller.Web.Infrastructure;
using DotPoller.Web.Models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace DotPoller.Web.Modules
{
    public class PostNewPollModule : NancyModule
    {
        private readonly PollRepository _pollRepository;

        public PostNewPollModule(PollRepository pollRepository)
        {
            _pollRepository = pollRepository;

            Post["/poll"] = p =>
                                {
                                    var poll = SavePoll();
                                    return new RedirectResponse(poll.GetUrl());
                                };
        }

        private Poll SavePoll()
        {
            var poll = this.Bind<Poll>();
            return _pollRepository.Add(poll);
        }
    }
}