﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyKeeda.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default Country";
        //Navigation Property
        public ICollection<State> States { get; set; } = new HashSet<State>();
    }
}
