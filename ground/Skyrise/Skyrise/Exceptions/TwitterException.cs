using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetSharp;

namespace Skyrise
{
    class TwitterException : Exception
    {
        public TwitterError Error { get; private set; }

        public TwitterException() : base() { }

        public TwitterException(TwitterError error)
            : base(error.Message)
        {
            Error = error;
        }
    }
}
