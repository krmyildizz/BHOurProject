using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }


        public virtual ICollection<Product> ProductList { get; set; }
    }
}