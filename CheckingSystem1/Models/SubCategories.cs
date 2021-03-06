using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem1.Models
{
    public class SubCategories
    {
        [Key]
        public int IdSubCat { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int IdCat { get; set; }
        [Required]
        public Categories Category { get; set; }
    }
}
