using FortunaUnofficialAPI;
using FortunaUnofficialAPI.Models.Containers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FortunaUnofficalAPI.Controllers
{
    public class SpeciesController : ApiController
    {
        /*
        select by creator/rewriter name, select by social class, and select by rarity would be neat i think
        */
        internal static FortunaDbContext _db = new FortunaDbContext();

        public IHttpActionResult GetSpecies()
        {
            return Ok("AAAAAAAAAA");
        }

        [Route("api/species/test")]
        public IHttpActionResult test()
        {
            return Ok("AAAAAAAAAA");
        }

        [HttpGet]
        public IHttpActionResult GetSpecies(string speciesName)
        {
            SpeciesContainer returnSpecies = _db.SpeciesContainers.Where(x => x.DatabaseName == speciesName).FirstOrDefault();
            return Ok(returnSpecies);
        }

        [HttpPost]
        [Route("api/species/testpost")]
        public IHttpActionResult PostSpeciesTest()
        {
            SpeciesContainer returnSpecies = _db.SpeciesContainers.Where(x => x.DatabaseName == "aftik")
                .Include(x => x.AttributesGeneric)
                .Include(x => x.AttributesSpecies)
                .Include(x => x.AttributesGeneric.ArticleCreator)
                .Include(x => x.AttributesGeneric.MainArtCreator)
                .FirstOrDefault();

            returnSpecies.AttributesGeneric.AltArt = _db.AttributeAltArts.Where(x => x.HostAttribute == returnSpecies.AttributesGeneric.Id).Include(x => x.AltArtCreator).ToArray();

            return Ok(returnSpecies);
        }
    }
}
