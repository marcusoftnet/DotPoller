using Nancy;

namespace DotPoller.Web.Modules
{
    public class GetAddPollModule : NancyModule
    {
        public GetAddPollModule()
        {
            Get["/poll"] = p => { return View["AddPoll"]; };
        }
    }
}