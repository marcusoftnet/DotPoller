using System;

namespace DotPoller.Web.Models
{
    public class PollAnswer : AThingWithTags
    {
        public PollAnswer()
        {
            RegistredAt = DateTime.Now;
        }

        public string Mood { get; set; }
        public DateTime RegistredAt { get; set; }
        public string ClientId { get; set; }
    }
}