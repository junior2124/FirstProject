using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FirstGitProject.Models;

namespace FirstGitProject.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}