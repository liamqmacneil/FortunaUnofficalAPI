using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace FortunaUnofficalAPI.Data
{
    public class DatabaseBuilder
    {
        public static bool BuildSpeciesDatabase()
        {
            WebClient client = new WebClient();
            var SpeciesUrls = new List<string>();
            string pattern = "(\\<a href=\"([a-zA-Z0-9\\-]*)\"\\>)";
            string downloadedString = client.DownloadString("https://cosmosdex.com/cosmosdex/species/");
            foreach (Match m in Regex.Matches(downloadedString, pattern))
            {
                //string ToProcess = client.DownloadString("https://cosmosdex.com/cosmosdex/fauna/" + Regex.Match(m.Value, "(\"([a-zA-Z0-9-]*))").Value.Remove(0, 1));
                System.Diagnostics.Debug.WriteLine(Regex.Match(m.Value, "(\"([a-zA-Z0-9-]*))").Value.Remove(0, 1));
            }
            return true;
        }
    }
}