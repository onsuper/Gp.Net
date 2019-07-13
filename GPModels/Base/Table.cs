using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels.Base
{

    public class Tables
    {
        public Tab[] tables { get; set; }
    }

    public class Tab
    {
        public string code { get; set; }
        public string uid { get; set; }
    }
}
