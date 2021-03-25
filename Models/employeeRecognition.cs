using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace centricTeam4.Models
{
    public class employeeRecognition
    {
        public int ID { get; set; }
        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        [Display(Name = "Person giving the recognition")]
        public Guid recognizor { get; set; }
        [ForeignKey("recognizor")]
        public virtual Profile personGivingRecognition{ get; set; }
        [Display(Name = "Person receiving the recognition")]
        public Guid recognized { get; set; }
        [ForeignKey("recognized")]
        public virtual Profile personGettingRecognition { get; set; }
        [Display(Name = "Date recognition given")]
        public DateTime recognizationDate { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }

    }
    }