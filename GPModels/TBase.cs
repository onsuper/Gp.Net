using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels
{
    public class TBase
    {
        public int status { get; set; }
        public string info { get; set; }
        public string error_count { get; set; }
        public string server_time { get; set; }
        public string server_name { get; set; }
        public string msid { get; set; }
    }
}
