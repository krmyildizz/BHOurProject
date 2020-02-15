using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{   public class ProductDTO
    {
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
        public string SubCategoryName { get; set; }
    }
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
        public  SubCategory Category { get; set; }

        public static List<ProductDTO> GetProductList()
        {
            DataContext db = new DataContext();
            var pro = (from ep in db.Product
                               join e in db.SubCategory on ep.CategoryId equals e.Id
                               select new ProductDTO
                               {   Id=ep.Id,
                                   CategoryId = e.Id,
                                   SubName = ep.SubName,
                                   Name = e.Name,
                                   Image=e.Image,
                                   Description=ep.Description,
                                   Description2=ep.Description2,
                                   AplicationAreas=ep.AplicationAreas,
                                   Pdf=ep.Pdf,
                                   IsActive=ep.IsActive,
                                   ManufacturingPlace=ep.ManufacturingPlace,
                                   SubCategoryName = e.Name,

                                  
                               }).ToList();
            return pro.ToList();
        }
        public bool AddProduct(Product product)
        {
            var result = false;
            try
            {
                
                DataContext db = new DataContext();
                if (product != null)
                {
                    db.Product.Add(product);
                   var add= db.SaveChanges();
                    result = Convert.ToBoolean(add);
                }

            }
            catch (Exception)
            {

                throw;
            }
          
            return result;

        }
        public bool UpdateProduct(Product product)
        { var result = false;
            try
            {
                DataContext db = new DataContext();
                db.Entry(product).State = EntityState.Modified;
                var deneme = db.SaveChanges();
                result = Convert.ToBoolean(deneme);
            }
            catch (Exception)
            {

                result = false;
            }
           
        
           
            return result;
        }
        public bool DeleteProduct(int id)
        {
            bool result=false;
            try
            {
                DataContext db = new DataContext();
                Product product = db.Product.Find(id);
                if (product != null)
                {
                    db.Product.Remove(product);
                    var delete= db.SaveChanges();
                    result= Convert.ToBoolean(delete);
                }
                else
                    result = false;
            }
            catch (Exception ex)
            {

                result = false;
            }
           
            return result;
        }
    }
}