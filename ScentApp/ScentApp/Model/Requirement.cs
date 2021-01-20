using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScentApp.Model
{
    public class Requirement
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public Template Template { get; set; }

        public Category Category { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string Author { get; set; }

        public string Modifier { get; set; }

    }
}
