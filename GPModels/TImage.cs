using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels
{
    public class TImage : TBase
    {
        public string fullurl { get; set; }
        public string url { get; set; }
        public float size { get; set; }
        public string file { get; set; }
    }
}
