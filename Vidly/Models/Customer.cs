using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage="Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewslettar { get; set; }

        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        [Display(Name= "Day of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }


    }
}