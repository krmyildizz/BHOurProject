using BHOurProject.Models.Context;
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
        [DefaultValue(true)]
        public bool IsBanner { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public static List<Reference> GetReference()
        {
            DataContext db = new DataContext();
            var list = db.Reference.ToList();
            return list;
        }
        public bool AddReferance(Reference refs)
        {
            var result = false;
            DataContext db = new DataContext();
           
                db.Reference.Add(refs);
                db.SaveChanges();
                result = true;
           

            return result;

        }
    }
}