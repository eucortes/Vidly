using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "por favor, ingresa el nombre del cliente")]
        [StringLength(255)]   
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        [Min18YearsIfMember]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
       
        [Display(Name="Date of birth")]
        public DateTime? BirthDate { get; set; }
    }
}