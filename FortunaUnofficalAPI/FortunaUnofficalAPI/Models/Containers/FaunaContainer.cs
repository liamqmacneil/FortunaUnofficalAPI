using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FortunaUnofficialAPI.Models.Containers
{
    public class FaunaContainer : Container
    {
        public AttributesFauna FaunaAttributes { get; set; }
    }
}