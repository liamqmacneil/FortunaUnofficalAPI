using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortunaUnofficialAPI.Models.General
{
    public class Stat
    {
        public Stat()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public int S { get; set; }
        public int I { get; set; }
        public int C { get; set; }
        public int E { get; set; }
        public int A { get; set; }
        public int L { get; set; }
    }
}
