using FortunaUnofficialAPI.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FortunaUnofficalAPI.Models.General;
using SQLite;

namespace FortunaUnofficialAPI.Models.General
{
    public class AttributesGeneric
    {
        public AttributesGeneric()
        {
            Id = Guid.NewGuid();
            ArticleCreator = new AttributeCreator();
            MainArtCreator = new AttributeCreator();
            ArticleRewriter = new AttributeRewriter();
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string MainArt { get; set; }
        public string Quote { get; set; }
        public string Blurb { get; set; }
        public string Alias { get; set; }

        [Ignore]
        public ICollection<AttributeAltArt> AltArt { get; set; }

        public AttributeCreator ArticleCreator { get; set; }
        public AttributeCreator MainArtCreator { get; set; }
        public AttributeRewriter ArticleRewriter { get; set; }
        public Stat Stats { get; set; }
    }
}