using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
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

        public static List<Customer> GetCustomerList()
        {
            DataContext data = new DataContext();
            return data.Customer.ToList();

        }
    }
}