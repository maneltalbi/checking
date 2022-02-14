using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem.Models
{
    public class Incidents
    {
        [Key]
        public int IdInc { get; set; }
        public string Number { get; set; }
        public string Caller { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string BusinessService { get; set; }
        public string Description { get; set; }
        public string ContactType { get; set; }
        public string state { get; set; }
        public string priority { get; set; }
        public string AssignementGroup { get; set; }
        public string AssignementTo { get; set; }
        public DateTime Updatedate { get; set; }
        public string UbdatedBy { get; set; }
        [ForeignKey("Categories")]
        public int IdCat { get; set; }
        public Categories Categories { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public Users User { get; set; }
        [ForeignKey("admin")]
        public int Idadmin { get; set; }
        public admin admin { get; set; }
        [ForeignKey("SupportAgent")]
        public int IdAgent { get; set; }
        public SupportAgents agent { get; set; }


    }
}
