using InfoTrackTask.Logic;
using System;
using System.Web.Mvc;

namespace InfoTrackTask.Controllers
{
    public class HomeController : Controller
    {
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
            var customWebClient = new CustomWebClient(keywords);
            var positions = new FindPositions(url);

            return String.Join(", ", positions.GetPostions(customWebClient.QueryGoogle()));
        }
    }
}