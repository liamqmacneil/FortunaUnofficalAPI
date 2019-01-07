using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortunaUnofficialAPI.Models.General
{
    public class AttributeTrait
    {
        public AttributeTrait()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string TraitName { get; set; }
        public string TraitDesc { get; set; }
    }
}
