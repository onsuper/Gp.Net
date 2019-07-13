using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels
{

    public class R<T>
    {
        public Action action { get; set; }
        public Dictionary<string, string> get { get; set; }
        public T post { get; set; }
    }

    public class Post
    {
        public string file { get; set; }
    }
    public class Action
    {
        public string action { get; set; }
    }

    public class Get
    {
        public string getpay { get; set; }
        public string log { get; set; }
        public string id { get; set; }
        public string msid { get; set; }
        public string op { get; set; }
    }

}
