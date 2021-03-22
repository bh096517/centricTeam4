using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace centricTeam4.Models
{
    public class recognition
    {
        
        public int recognitionID { get; set; }
        public string description { get; set; }
        public DateTime orderDate { get; set; }
        public int profileID { get; set; }
        public virtual Profile profile { get; set; }
    }
}