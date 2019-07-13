using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels
{

    public class Tx<T1>
    {
        public string key { get; set; }
        public string msgid { get; set; }
        public string timeout { get; set; }
        public string type { get; set; }
        public T1  data { get; set; }
    }

}
