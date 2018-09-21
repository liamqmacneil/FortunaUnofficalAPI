using FortunaUnofficialAPI.Models.Containers;
using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace FortunaUnofficialAPI.Controllers
{
    public class UpdateController : ApiController
    {
         /*public SpeciesContainer Test()
         {
             AttributesGeneric baseObject = new AttributesGeneric();
             WebClient client = new WebClient();
             var testList = new List<string>();
             string pattern = "(\\<a href=\"([a-zA-Z0-9\\-]*)\"\\>)";
             string downloadedString = client.DownloadString("https://cosmosdex.com/cosmosdex/fauna/");
             foreach (Match m in Regex.Matches(downloadedString,pattern))
             {
                 string speciesLink = "https://cosmosdex.com/cosmosdex/fauna/" + Regex.Match(m.Value, "(\"([a-zA-Z0-9-]*))").Value.Remove(0, 1);
             }
             using (var _db = new FortunaDbContext())
             {
                 var ResponseSpeciesContainer = _db.SpeciesContainers.Where(a => a.Url == "MainUrl").Include(b => b.SpeciesAttributes).Include(c => c.GenericAttributes).Include(d => d.GenericAttributes.ArticleCreator).Include(e => e.GenericAttributes.ArticleRewriter).FirstOrDefault();
                 return ResponseSpeciesContainer;
             }
         }*/
        
        
        /*public async Task<IHttpActionResult> UpdateSpecies()
        {
            WebClient client = new WebClient();
            var SpeciesUrls = new List<string>();
            string pattern = "(\\<a href=\"([a-zA-Z0-9\\-]*)\"\\>)";
            string downloadedString = client.DownloadString("https://cosmosdex.com/cosmosdex/fauna/");
            foreach (Match m in Regex.Matches(downloadedString, pattern))
            {
                string ToProcess = await client.DownloadStringTaskAsync("https://cosmosdex.com/cosmosdex/fauna/" + Regex.Match(m.Value, "(\"([a-zA-Z0-9-]*))").Value.Remove(0, 1));
            }
            return Ok();
        }*/
    }
}
