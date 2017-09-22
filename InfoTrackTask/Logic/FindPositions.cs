using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace InfoTrackTask.Logic
{
    public class FindPositions
    {
        string _url;

        public FindPositions(string url)
        {
            _url = url;
        } 

        public List<int> GetPostions(string result)
        {
            var list = new List<int>();
            string[] searchRecords = result.Split(new[] { "<div class=\"g\"" }, StringSplitOptions.None);

            for (int i = 1; i < searchRecords.Length; i++)
            {
                if (Regex.Matches(searchRecords[i], _url).Count > 0)
                {
                    list.Add(i);
                }
            }
            if (list.Count == 0)
                list.Add(0);

            return list;
        }
    }
}