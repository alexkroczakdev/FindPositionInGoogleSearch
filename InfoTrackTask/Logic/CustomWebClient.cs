using System.Net;

namespace InfoTrackTask.Logic
{
    public class CustomWebClient
    {
        private string _keyWords;
        private int _number = 100;

        public CustomWebClient(string keywords)
        {
            _keyWords = keywords.Replace(' ', '+');
        }

        public string QueryGoogle()
        {
            string result = "";
            using (var webClient = new WebClient())
            {
                result = webClient.DownloadString("http://www.google.com.au/search?&num="+_number+"&q=" + _keyWords);
            }
            return result;
        }
    }
}