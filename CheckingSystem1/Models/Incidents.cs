using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem1.Models
{
    public class Incidents
    {
        [Key]
        public int IdInc { get; set; }
        
        public string Number { get; set; }
       
        public string Subcategory { get; set; }
     [Required]
        public string BusinessService { get; set; }
     [Required]
        public string Description { get; set; }
     [Required]
        public string ContactType { get; set; }
        
        public string state { get; set; }
    [Required]
        public string priority { get; set; }
   [Required]
        public string AssignementGroup { get; set; }
      
        public DateTime Updatedate { get; set; }
       [Required]
        public string UbdatedBy { get; set; }
        [ForeignKey("Category")]
        public int IdCat { get; set; }
      
        public Categories Category { get; set; }
        [ForeignKey("Caller")]
        public int IdUser { get; set; }
      
        public Users Caller { get; set; }
        [ForeignKey("admin")]
        public int Idadmin { get; set; }
       
        public admin admin { get; set; }
        [ForeignKey("AssignementTo")]
        public int IdAgent { get; set; }
       
        public SupportAgents AssignementTo { get; set; }

        [ForeignKey("Address")]
        public int IdMap { get; set; }
       public GoogleMap Address { get; set; }

    }
}
