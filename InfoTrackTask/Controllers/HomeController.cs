using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace InfoTrackTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Position(string keyword, string url)
        {
            ViewBag.Positions = FindPostionInSearch(keyword, url);
            return View();
        }

        public string FindPostionInSearch(string keywords, string url)
        {
            var key = keywords.Replace(' ', '+');
            var list = new List<int>();
            int num = 100;

            using (var webClient = new WebClient())
            {
                var result = webClient.DownloadString("http://www.google.com.au/search?q="+key+"&num="+num+"");

                string[] searchRecords = result.Split(new[] { "<div class=\"g\"" }, StringSplitOptions.None);

                for (int i = 1 ; i<=num; i++ )
                {
                    if(Regex.Matches(searchRecords[i], url).Count > 0)
                    {
                        list.Add(i);
                    }
                }
                if (list.Count == 0)
                    list.Remove(0);                
            }
            return String.Join(", ", list.ToArray());
        }
    }
}