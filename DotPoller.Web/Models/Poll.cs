using System;
using System.Collections.Generic;

namespace DotPoller.Web.Models
{
    public class Poll : AThingWithTags
    {
        public Poll()
        {
            Id = Guid.NewGuid().ToString();
            Answers = new List<PollAnswer>();
        }

        public string Id { get; set; }
        public string Question { get; set; }
        public IList<PollAnswer> Answers { get; set; }

        public string GetUrl()
        {
            return string.Format("/poll/{0}", Id);
        }
    }
}