using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficialAPI.Models.SAF
{
    public class AttributesSpecies
    {
        public AttributesSpecies()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string LifeSpan { get; set; }
        public string Diet { get; set; }
        public string SocialClass { get; set; }
        public string Rarity { get; set; }
        public string Jobs { get; set; }
    }
}