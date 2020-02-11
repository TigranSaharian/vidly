using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        [Adult]
        public DateTime? Birthday { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}