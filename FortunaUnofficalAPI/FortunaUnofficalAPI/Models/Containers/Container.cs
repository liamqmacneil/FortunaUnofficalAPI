using FortunaUnofficialAPI.Models.General;
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
        [Key]
        [Column(name:"id")]
        public int Id { get; set; }
        [Column(name:"url")]
        public string Url { get; set; }
        [Column(name:"baseInfo")]
        public AttributesGeneric BaseInfo { get; set; }
    }
}