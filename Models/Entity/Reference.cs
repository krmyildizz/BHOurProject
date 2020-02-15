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
          
            try
            {
                if (refs!=null)
                {
                    DataContext db = new DataContext();
                    db.Reference.Add(refs);
                    var referanceResult=   db.SaveChanges();
                    result = Convert.ToBoolean(referanceResult);
                }
                else
                {
                    return result;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
                
           

            return result;

        }
        public bool UpdateReferance(Reference refs)
        {
            var result = false;
            try
            {
                if (refs != null)
                {
                    DataContext db = new DataContext();
                    db.Entry(refs).State = EntityState.Modified;
                    var referanceResult = db.SaveChanges();
                    result = Convert.ToBoolean(referanceResult);
                }
                else { return result; }
                }
            catch (Exception)
            {

                return result;
            }
            
            return result;

        }
        public bool DeleteReference(int id)
        {
            bool result=false;
           
            try
            {
                DataContext db = new DataContext();
                Reference reference = db.Reference.Find(id);
                if (reference != null)
                {
                    db.Reference.Remove(reference);
                    var referanceResult = db.SaveChanges();
                    result = Convert.ToBoolean(referanceResult);
                }
                else
                    return result;
            }
            catch (Exception)
            {

                return result;
            }
            
            return result;
        }
    }
}