using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels.Base
{
    public class Menus
    {
        public Type[] dish { get; set; }
    }

    public class Type
    {
        public string cateid { get; set; }
        public string catename { get; set; }
        public int catestate { get; set; }
        public Dish[] dishes { get; set; }
    }

    public class Dish
    {
        public string gdsid { get; set; }
        public int gdsstate { get; set; }
        public string gdsname { get; set; }
        public string gdsprice { get; set; }
        public string gdsunit { get; set; }
        public string gdsqcode { get; set; }
        public string gdsaddon { get; set; }
        public string gdsinfo { get; set; }
        public string gdstype { get; set; }
        public string gdsaddon2 { get; set; }
        public int packfee { get; set; }
        public string mbprice1 { get; set; }
        public Gdsaddonset2 gdsaddonset2 { get; set; }
        public string gdsunits { get; set; }
    }

    public class Gdsaddonset2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

}
