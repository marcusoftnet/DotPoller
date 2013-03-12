using System;
using System.Collections.Generic;

namespace DotPoller.Web.Models
{
    public abstract class AThingWithTags
    {
        public static readonly char[] SPLIT_CHARS = new[] { ' ', ',', ';' };

        public string TagString { get; set; }
        private IEnumerable<string> _tags;
        public IEnumerable<string> Tags
        {
            get
            {
                if (_tags == null)
                {
                    _tags = TagString.Split(SPLIT_CHARS, StringSplitOptions.RemoveEmptyEntries);
                }
                return _tags;
            }
            set { _tags = value; }
        }
    }
}