﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem1.Models
{
    public class Categories
    {
        [Key]
        public int IdCat { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubCategories> SubCategories { get; set; }
        public List<Incidents> Incident { get; set; }
    }
}