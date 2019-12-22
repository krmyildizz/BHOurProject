using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class Reference
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}