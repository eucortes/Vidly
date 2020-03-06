using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "por favor, ingresa el nombre del cliente")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //[Min18YearsIfMember]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}