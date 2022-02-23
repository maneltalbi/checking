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
      
        public string BusinessService { get; set; }
     
        public string Description { get; set; }
      
        public string ContactType { get; set; }
       
        public string state { get; set; }
  
        public string priority { get; set; }
      
        public string AssignementGroup { get; set; }
      
        public DateTime Updatedate { get; set; }
        
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

    }
}
