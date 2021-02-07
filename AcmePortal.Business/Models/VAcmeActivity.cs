using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcmePortal.Business.Models
{
    public class VAcmeActivity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "First name can't be more than 256 characters")]
        [Display(Name = "first name")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "Last name can't be more than 256 characters")]
        [Display(Name = "last name")]
        public string Lastname { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "Activity can't be more than 256 characters")]
        [Display(Name = "activity")]
        public string Activity { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "Email can't be more than 256 characters")]
        [Display(Name = "email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string Comments { get; set; }
    }
}
