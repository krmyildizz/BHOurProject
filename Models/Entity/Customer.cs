using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        DataContext data;
        public static List<Customer> GetCustomerList()
        {
        DataContext db = new DataContext();
            return db.Customer.ToList();

        }
        public bool UpdateCustomer(Customer customer)
        {
            var result = false;
            try
            {
                if (customer!=null) {
                    data = new DataContext();
                    data.Entry(customer).State = EntityState.Modified;
                    var customerResult = data.SaveChanges();
                    result = Convert.ToBoolean(customerResult);
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
        public bool DeleteCustomer(int id)
        {
            bool result = false;
            try
            {
                DataContext db = new DataContext();
                Customer customer = db.Customer.Find(id);
                if (customer != null)
                {
                    db.Customer.Remove(customer);
                    var customerResult = data.SaveChanges();
                    result = Convert.ToBoolean(customerResult);
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

        public bool AddCustomer(Customer customer)
        {
            var result = false;
            try
            {
                if (customer != null)
                {
                    DataContext db = new DataContext();
                    if (customer != null)
                    {
                        db.Customer.Add(customer);
                        var customerResult = data.SaveChanges();
                        result = Convert.ToBoolean(customerResult);
                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }
           

            return result;

        }
    }
}