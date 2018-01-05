using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewslettar { get; set; }

        
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

    }
}