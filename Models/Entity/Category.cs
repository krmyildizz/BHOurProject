using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Models.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }


        //public virtual ICollection<Product> ProductList { get; set; }
        public static List<Category> GetCategoryList()
        {
            DataContext db = new DataContext();
            return db.Category.Where(x => x.IsActive).ToList();
        }
        public bool UpdateCategory(Category category)
        {

            var result = false;
            DataContext db = new DataContext();
            var deneme = db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return result;
        }
        public bool DeleteCategory(int id)
        {
            bool result;
            DataContext db = new DataContext();
            Category category = db.Category.Find(id);
            if (category != null)
            {
                db.Category.Remove(category);
                db.SaveChanges();
                result = true;
            }
            else
                result = false;
            return result;
        }

        public bool AddCategory(Category category)
        {
            var result = false;
            DataContext db = new DataContext();
            if (category != null)
            {
                db.Category.Add(category);
                db.SaveChanges();
                result = true;
            }
           
            return result;

        }
    }
}