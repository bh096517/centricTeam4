using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace centricTeam4.Models

{

    public class Profile
    {
        public Guid ProfileID { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Full Name")]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        [Required]
        [Display(Name = "Office")]
        public string office { get; set; }
        [Required]
        [Display(Name = "Current Position")]
        public string position { get; set; }

        [Display(Name = "Hire Date")]
        //[DisplayFormat(DataFormatString = DateTime, ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }
        [Display(Name = "Primary Phone")]
        [Phone]
        public string phoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        public string photo { get; set; }

    }
}