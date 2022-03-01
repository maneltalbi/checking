using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem1.Models
{
    public class GoogleMap
    {
        [Key]
        public int IdMap { get; set; }
        public Nullable<int> Rating { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
