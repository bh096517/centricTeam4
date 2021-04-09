using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace centricTeam4.Models

{

    public class Profile
    {
        public Guid ProfileID { get; set; }
       
        //public int profileID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage ="Digits or special characters are not allowed to be used in a name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Digits or special characters are not allowed to be used in a name")]
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
        //[RegularExpression(^\(? ([0 - 9]{3})\)?[-.●]? ([0 - 9]{3})[-.●]? ([0 - 9]{ 4})$)]
        [Display(Name = "Primary Phone")]
        [Phone]
        public string phoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        //public string photo { get; set; }
        [ForeignKey("recognizor")]
        public ICollection<employeeRecognition> personGivingRecognition { get; set; }
        
        [ForeignKey("recognized")]
        public ICollection<employeeRecognition> personGettingRecognition { get; set; }
        //public ICollection<employeeRecognition> award { get; set; }
        public ICollection<employeeRecognition> recognitionDate { get; set; }

    }
}