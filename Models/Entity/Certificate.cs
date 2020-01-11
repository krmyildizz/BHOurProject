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
            data = new DataContext();
            data.Entry(certificate).State = EntityState.Modified;
            data.SaveChanges();
            return result;
        }
        public bool DeleteCertificate(int id)
        {
            bool result;
            DataContext db = new DataContext();
            Certificate certificate = db.Certificate.Find(id);
            if (certificate != null)
            {
                db.Certificate.Remove(certificate);
                db.SaveChanges();
                result = true;
            }
            else
                result = false;
            return result;
        }

        public bool AddCertificate(Certificate certificate)
        {
            var result = false;
            DataContext db = new DataContext();
            if (certificate != null)
            {
                db.Certificate.Add(certificate);
                db.SaveChanges();
                result = true;
            }

            return result;

        }
    }
}