using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExamenAPI.Models
{
    internal class Post
    {
        public int userId { get; set; }

        public string id { get; set; }

        public string title { get; set; }

        public string body { get; set; }


    }
}
