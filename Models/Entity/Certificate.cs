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
    public class Certificate
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        DataContext data;
        public static List<Certificate> GetCertificateList()
        {
            DataContext db = new DataContext();
            return db.Certificate.ToList();
        }
        public bool UpdateCertificate(Certificate certificate)
        {

            var result = false;
            try
            {
                if (certificate != null)
                {
                    data = new DataContext();
                    data.Entry(certificate).State = EntityState.Modified;
                    var SertificateResult = data.SaveChanges();
                    result = Convert.ToBoolean(SertificateResult);
                }
                else return result;
            }
            catch (Exception ex)
            {
                return result;
            }
         
            return result;
        }
        public bool DeleteCertificate(int id)
        {
            bool result=false;
            try
            {
                DataContext db = new DataContext();
                Certificate certificate = db.Certificate.Find(id);
                if (certificate != null)
                {
                    db.Certificate.Remove(certificate);
                    var SertificateResult = data.SaveChanges();
                    result = Convert.ToBoolean(SertificateResult);
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

        public bool AddCertificate(Certificate certificate)
        {
            var result = false;
            try
            {
                DataContext db = new DataContext();
                if (certificate != null)
                {
                    db.Certificate.Add(certificate);
                    var SertificateResult = data.SaveChanges();
                    result = Convert.ToBoolean(SertificateResult);
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