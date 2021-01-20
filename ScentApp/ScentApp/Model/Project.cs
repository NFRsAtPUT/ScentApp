using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScentApp.Model
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Factor> Context { get; set; }

        public List<Requirement> Requirements { get; set; }
    }
}
