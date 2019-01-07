using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortunaUnofficialAPI.Models.General
{
    public class AttributeCreator
    {
        public AttributeCreator()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string CreatorName { get; set; }
        public string CreatorUrl { get; set; }
    }
}
