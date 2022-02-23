using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem1.Models
{
    public class SupportAgents
    {
        [Key]
        public int IdAgent { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Incidents> Incident { get; set; }
    }
}
