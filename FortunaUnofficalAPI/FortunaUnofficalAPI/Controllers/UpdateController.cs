using FortunaUnofficalAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace FortunaUnofficalAPI.Controllers
{
    public class UpdateController : ApiController
    {
        public FortunaBase Test()
        {
            FortunaBase baseObject = new FortunaBase();
            WebClient client = new WebClient();
            var testList = new List<string>();
            string pattern = "(\\<a href=\"([a-zA-Z0-9\\-]*)\"\\>)";
            string downloadedString = client.DownloadString("https://cosmosdex.com/cosmosdex/fauna/");
            foreach (Match m in Regex.Matches(downloadedString,pattern))
            {
                string speciesLink = "https://cosmosdex.com/cosmosdex/species/" + Regex.Match(m.Value, "(\"([a-zA-Z0-9-]*))").Value.Remove(0, 1);
                
            }
            baseObject.alias = testList.ToArray();
            return baseObject;
        }
    }
}
