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

            int count = 0;
            var list = new List<int>() { count };
            
            using (var webClient = new WebClient())
            {
                var result = webClient.DownloadString("http://www.google.com.au/search?q="+key+ "&num=100");
                
                string[] split = result.Split(new[] { url }, StringSplitOptions.None);

                for (int i = 0; i<split.Length-1; i++)
                {
                    count = Regex.Matches(split[i], "<div class=\"g\">").Count;
                    if (count != 0)
                        list.Add(list.Last()+count);
                }
                list.Remove(0);
            }
            return String.Join(", ", list.ToArray());
        }
    }
}