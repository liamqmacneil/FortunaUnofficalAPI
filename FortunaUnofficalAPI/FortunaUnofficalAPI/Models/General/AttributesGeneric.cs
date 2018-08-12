using FortunaUnofficialAPI.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FortunaUnofficalAPI.Models.General;

namespace FortunaUnofficialAPI.Models.General
{
    public class AttributesGeneric
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string MainArt { get; set; }
        public string Quote { get; set; }
        public string Blurb { get; set; }

        public string Alias { get; set; }

        [NotMapped]
        public List<AttributeAltArt> AltArt { get; set; }

        [JsonIgnore]
        public string SearlizedAltArt {
            get
            {
                return AltArt == null || !AltArt.Any()
                    ? null
                    : JsonConvert.SerializeObject(AltArt);
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    AltArt.Clear();
                else
                    AltArt = JsonConvert.DeserializeObject<List<AttributeAltArt>>(value);
            }
        }

        public AttributeCreator ArticleCreator { get; set; }
        public AttributeRewriter ArticleRewriter { get; set; }
    }
}