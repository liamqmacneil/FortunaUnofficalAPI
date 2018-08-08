using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortunaUnofficialAPI.Models.Containers
{
    public class SpeciesContainer : Container
    {
        [Column(name:"species")]
        public AttributesSpecies SpeciesAttributes { get; set; }
    }
}