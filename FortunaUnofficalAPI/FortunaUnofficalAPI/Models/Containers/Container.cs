using FortunaUnofficialAPI.Models.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficialAPI.Models.Containers
{
    public class Container
    {
        public Container()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Url { get; set; }
        public string DatabaseName { get; set; }
        public AttributesGeneric AttributesGeneric { get; set; }
    }
}