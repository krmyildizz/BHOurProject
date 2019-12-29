using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string AplicationAreas { get; set; }
        public string Pdf { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string ManufacturingPlace { get; set; }
        public virtual Category Category { get; set; }
    }
}