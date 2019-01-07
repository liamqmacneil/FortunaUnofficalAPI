using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficialAPI.Models.SAF
{
    public class AttributesAi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string type;
        public string jobs;
        public ShipInfo shipinfo;
        public Consorts consorts;
    }
}