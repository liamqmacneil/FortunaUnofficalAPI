using FortunaUnofficialAPI.Models.SAF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficialAPI.Models.Containers
{
    public class AiContainer : Container
    {
        [Column(name:"ai")]
        public AttributesAi AiAttributes { get; set; }
    }
}