using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScentApp.Model
{
    public class Template
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public List<Category> Categories { get; set; }
    }
}
