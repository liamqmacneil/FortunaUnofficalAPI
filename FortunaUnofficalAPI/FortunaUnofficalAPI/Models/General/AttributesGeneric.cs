﻿using FortunaUnofficalAPI.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FortunaUnofficalAPI.Models.General
{
    public class AttributesGeneric
    {
        public string name;
        public string[] alias;
        public string mainart;
        public AttributeAltArt[] subart;
        public string pageurl;
        public string quote;
        public string blurb;
        public AttributeCreator creator;
    }
}