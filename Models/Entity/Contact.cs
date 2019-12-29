using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public Company Company { get; set; }
        public string IFrameText { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}