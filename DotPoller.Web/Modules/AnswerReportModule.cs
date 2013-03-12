using System;
using System.Collections.Generic;
using System.Linq;
using DotPoller.Web.Infrastructure;
using DotPoller.Web.Models;
using Nancy;
using Nancy.ModelBinding;

namespace DotPoller.Web.Modules
{
    public class AnswerReportModule : NancyModule
    {
        private readonly PollRepository _pollRepository;

        public AnswerReportModule(PollRepository pollRepository)
        {
            _pollRepository = pollRepository;

            Post["/poll/{id}/report"] = p =>
                                           {
                                               return View["Report", GetReportData()];
                                           };
        }

        private IEnumerable<PollAnswer> GetReportData()
        {
            var reportParameters = this.Bind<ReportParameters>();

            var answers = from p in _pollRepository.All()
                   from a in p.Answers
                   select a;

            return answers.ToList();
        }
    }
}