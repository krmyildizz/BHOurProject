using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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

        public static List<Product> GetProductList()
        {
            DataContext db = new DataContext();
            return db.Product.ToList();
        }
        public bool AddProduct(Product product)
        {
            var result = false;
            DataContext db = new DataContext();
            if (product != null)
            {
                db.Product.Add(product);
                db.SaveChanges();
                result = true;
            }

            return result;

        }
        public bool UpdateProduct(Product product)
        {
            var result = false;
            DataContext db = new DataContext();
            var deneme = db.Entry(product).State = EntityState.Modified;
        
            db.SaveChanges();
            return result;
        }
        public bool DeleteProduct(int id)
        {
            bool result;
            DataContext db = new DataContext();
            Product product = db.Product.Find(id);
            if (product != null)
            {
                db.Product.Remove(product);
                db.SaveChanges();
                result = true;
            }
            else
                result = false;
            return result;
        }
    }
}