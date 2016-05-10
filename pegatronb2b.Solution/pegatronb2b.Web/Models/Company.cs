using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pegatronb2b.Web.Models
{
    public partial class Company : Entity
    {
        public Company()
        {
            
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address {get;set;}
        public string City { get; set; }
        public string Province { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Logo { get; set; }
        

         
    }
}