using FortunaUnofficalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace FortunaUnofficalAPI.Controllers
{
    public class UpdateController : ApiController
    {
        public Base Test()
        {
            Base baseObject = new Base();
            WebClient client = new WebClient();
            var testList = new List<string>();
            string test = "<a href=\"drakon\">";
            string pattern = "(\\<a href=\"([a-zA-Z0-9\\-]*)\"\\>)";
            string downloadedString = client.DownloadString("https://cosmosdex.com/cosmosdex/species/");
            foreach (Match m in Regex.Matches(downloadedString,pattern))
            {
                testList.Add(Regex.Match(m.Value,"(\"[a-zA-Z0-9\\-]*\")").Value);
            }
            baseObject.alias = testList.ToArray();
            return baseObject;
        }
    }
}
