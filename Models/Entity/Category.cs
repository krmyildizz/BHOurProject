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
    public class CategoryDTO
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string Image { get; set; }
    }
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
            return db.Category.ToList();
        }
        public static List<CategoryDTO> GetSubCategory()
        {
            DataContext db = new DataContext();
            var subCategory = (from ep in db.SubCategory
                               join e in db.Category on ep.CategoryId equals e.Id
                               select new CategoryDTO
                               {
                                   CategoryId = ep.CategoryId,
                                   SubName = ep.Name,
                                   Name = e.Name,
                                   SubCategoryId = ep.Id
                               }).ToList(); 
            return subCategory;
        }
        public bool UpdateCategory(Category category)
        {

            var result = false;
            try
            {
                if (category != null)
                {
                    DataContext db = new DataContext();
                    db.Entry(category).State = EntityState.Modified;
                    var categoryResult = db.SaveChanges();
                    result = Convert.ToBoolean(categoryResult);
                }
                else return result;

            }
            catch (Exception)
            {

                return result;
            }
          
            return result;
        }
        public bool DeleteCategory(int id)
        {
            bool result=false;
            try
            {
                DataContext db = new DataContext();
                Category category = db.Category.Find(id);
                if (category != null)
                {
                    db.Category.Remove(category);
                    var categoryResult = db.SaveChanges();
                    result = Convert.ToBoolean(categoryResult);
                }
                else
                    return result;
            }
            catch (Exception ex)
            {

                return result;
            }
           
            return result;
        }

        public bool AddCategory(Category category)
        {
            var result = false;
            try
            {
                DataContext db = new DataContext();
                if (category != null)
                {
                    db.Category.Add(category);
                    var categoryResult = db.SaveChanges();
                    result = Convert.ToBoolean(categoryResult);
                }
                else
                    return result;
            }
            catch (Exception ex)
            {

                return result;
            }
           
           
            return result;

        }
    }
}