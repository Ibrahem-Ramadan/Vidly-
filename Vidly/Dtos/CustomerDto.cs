using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedtoNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        [_18YearsValidationIfAMember]
        public System.Nullable<DateTime> BirthDate { get; set; }
    }
}