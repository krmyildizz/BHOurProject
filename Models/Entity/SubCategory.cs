using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
        public string Image { get; set; }
    }
}