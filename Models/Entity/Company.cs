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

        //public virtual ICollection<Machine> MachineList { get; set; }

        public static List<Company> GetCompanyList()
        {  
             DataContext db = new DataContext();
            return db.Company.ToList();
        }
        public bool UpdateCompany(Company company)
        {
            var result = false;
            try
            {
                if (company != null) {
                    data = new DataContext();
                    data.Entry(company).State = EntityState.Modified;
                    var companyResult = data.SaveChanges();
                    result = Convert.ToBoolean(companyResult);
                }
                else
                {
                    return result;
                }
               
                
            }
            catch (Exception ex)
            {

                result = false;
            }
  
            return result;
        }
        public bool DeleteCompany(int id)
        {
            bool result;
            try
            {
                DataContext db = new DataContext();
                Company company = db.Company.Find(id);
                if (company != null)
                {
                    db.Company.Remove(company);
                    var companyResult = db.SaveChanges();
                    result = Convert.ToBoolean(companyResult);
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

        public bool AddCompany(Company company)
        {
            var result = false;
            try
            {
                DataContext db = new DataContext();
                if (company != null)
                {
                    db.Company.Add(company);
                    var companyResult = db.SaveChanges();
                    result = Convert.ToBoolean(companyResult);
                }

            }
            catch (Exception)
            {

                result = false;
            }
           

            return result;

        }
    }
}