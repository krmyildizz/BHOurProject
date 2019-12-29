using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class CarrierForm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool MilitaryStatus { get; set; }
        public string Note { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}