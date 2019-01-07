using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficialAPI.Models.SAF
{
    public class AttributesFauna
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string dangerLevel;
        public string environment;
        public string diet;
        public string rarity;
    }
}