﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem.Models
{
    public class admin
    {
        [Key]
        public int IdAdmin { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public List<Incidents> Incident { get; set; }
    }
}
