﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem.Models
{
    public class SubCategories
    {
        [Key]
        public int IdSubCat { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int IdCat { get; set; }
        public Categories Category { get; set; }
    }
}
