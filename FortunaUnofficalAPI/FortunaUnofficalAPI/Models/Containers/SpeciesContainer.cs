using FortunaUnofficalAPI.Models.SpeciesAiFauna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FortunaUnofficalAPI.Models
{
    public class SpeciesContainer
    {
        public int UrlId { get; set; }
        public string Url { get; set; }
        public AttributesGeneric BaseInfo { get; set; }
        public AttributesSpecies AttributeSpecies { get; set; }
    }
}