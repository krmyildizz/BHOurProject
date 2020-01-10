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
    public class Company
    {
        DataContext data;
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Fax { get; set; }
        public string MapPath { get; set; }
        public string DetailInformation { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ICollection<Machine> MachineList { get; set; }

        public static List<Company> GetCompanyList()
        {  
             DataContext db = new DataContext();
            return db.Company.Where(x=>x.IsActive).ToList();
        }
        public bool UpdateCompany(Company company)
        {

            var result = false;
            data = new DataContext();
            data.Entry(company).State = EntityState.Modified;
            data.SaveChanges();
            return result;
        }
        public bool DeleteCompany(int id)
        {
            bool result;
            DataContext db = new DataContext();
            Company company = db.Company.Find(id);
            if (company != null)
            {
                db.Company.Remove(company);
                db.SaveChanges();
                result = true;
            }
            else
                result = false;
            return result;
        }

        public bool AddCompany(Company company)
        {
            var result = false;
            DataContext db = new DataContext();
            if (company != null)
            {
                db.Company.Add(company);
                db.SaveChanges();
                result = true;
            }

            return result;

        }
    }
}