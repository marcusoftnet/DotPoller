using System;

namespace DotPoller.Web.Models
{
    public class ReportParameters : AThingWithTags
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}