using Nancy;
using Nancy.Responses;

namespace DotPoller.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => { return new RedirectResponse("/poll"); };
        }
    }
}