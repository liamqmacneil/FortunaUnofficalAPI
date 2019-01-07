using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficalAPI.Models.General
{
    public class AttributeRewriter
    {
        public AttributeRewriter()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Rewriter { get; set; }
        public string RewriterUrl { get; set; }
    }
}