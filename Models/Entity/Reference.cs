using System;
using System.Collections.Generic;
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
        public bool IsActive { get; set; }
    }
}