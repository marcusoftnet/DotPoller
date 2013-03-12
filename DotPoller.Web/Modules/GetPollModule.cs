using DotPoller.Web.Infrastructure;
using DotPoller.Web.Models;
using Nancy;
using System.Linq;
namespace DotPoller.Web.Modules
{
    public class GetPollModule : NancyModule
    {
        private readonly PollRepository _pollRepository;

        public GetPollModule(PollRepository pollRepository)
        {
            _pollRepository = pollRepository;

            Get["/poll/{id}"] = p => { return View["Poll", GetPoll(p.Id)]; };
        }

        private Poll GetPoll(string id)
        {
            return _pollRepository.GetById(id);
        }
    }
}