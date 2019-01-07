using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortunaUnofficialAPI.Models.Containers
{
    public class SpeciesContainer : Container
    {
        public AttributesSpecies AttributesSpecies { get; set; }
    }
}