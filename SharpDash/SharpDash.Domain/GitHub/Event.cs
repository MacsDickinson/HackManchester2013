﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDash.Domain.GitHub
{
    public class Event
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public User Actor { get; set; }
        public Repository Repo { get; set; }
    }
}
