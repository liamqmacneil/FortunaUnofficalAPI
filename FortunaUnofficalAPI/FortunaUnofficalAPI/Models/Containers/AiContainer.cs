using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficialAPI.Models.Containers
{
    public class AiContainer : Container
    {
        public AttributesAi AiAttributes { get; set; }
    }
}