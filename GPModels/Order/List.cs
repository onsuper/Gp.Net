using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels.Order
{

    public class List
    {
        public int qty { get; set; }
        public float amt { get; set; }
        public string rebate { get; set; }
        public string id { get; set; }
        public string unit { get; set; }
        public string name { get; set; }
        public string memo { get; set; }
        public string dgid { get; set; }
        public string refid { get; set; }
        public string parentid { get; set; }
        public float price { get; set; }
    }
}
