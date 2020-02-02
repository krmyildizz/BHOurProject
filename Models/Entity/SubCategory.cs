using BHOurProject.Models.Context;
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
        public bool IsActive { get; set; }
        public string Image { get; set; }

        public bool AddSubCategory(SubCategory sub)
        {
            var result = false;
            DataContext db = new DataContext();
            if (sub != null)
            {
                db.SubCategory.Add(sub);
                db.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}