using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortunaUnofficialAPI.Models.General
{
    public class AttributeAltArt
    {
        public AttributeAltArt()
        {
            Id = Guid.NewGuid();
            AltArtCreator = new AttributeCreator();
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid HostAttribute { get; set; }

        public string Url { get; set; }
        public string Description { get; set; }
        public AttributeCreator AltArtCreator { get; set; }
    }
}
