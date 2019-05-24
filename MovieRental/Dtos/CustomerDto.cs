using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        [Display(Name = "Is subscribed to news letter")]
        public bool IsSubscribedToNewsletter { get; set; }

         public byte MembershipTypeId { get; set; }
    }
}