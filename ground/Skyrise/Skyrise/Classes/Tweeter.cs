using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TweetSharp;

namespace Skyrise
{
    class Tweeter
    {
        // ---------- Instance variables ---------- \\
        TwitterService _app;

        // ---------- Statics and events ---------- \\


        // ---------- Constructors       ---------- \\
        public Tweeter(string apiKey, string apiSecret, string accessToken, string accessTokenSecret)
        {
            _app = new TwitterService(apiKey, apiSecret);
            _app.AuthenticateWith(accessToken, accessTokenSecret);
        }

        // ---------- Public methods     ---------- \\
        public void Tweet(string message)
        {
            var tweetOption = new SendTweetOptions();
            tweetOption.Status = message;
        }

        public void Tweet(string message, double lat, double lon)
        {
            var tweetOption = new SendTweetOptions();
            tweetOption.Status = message;
            tweetOption.Lat = lat;
            tweetOption.Long = lon;
            tweetOption.DisplayCoordinates = true;
            var status = _app.SendTweet(tweetOption);
            string response = _app.Response.Response;
            if (response != "OK")
            {
                TwitterError error = _app.Deserialize<TwitterError>(response);
                throw new TwitterException(error);
            }
        }

        // ---------- Properties         ---------- \\


        // ---------- Private methods    ---------- \\
    }
}
