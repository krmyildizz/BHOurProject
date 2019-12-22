using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class RequestForm
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRepresentative { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxNumber { get; set; }
        public string MailAddress { get; set; }
        public string ProductOfInterest { get; set; }
        public double Quantity { get; set; }
        public string City { get; set; }
        public string Explanation { get; set; }
        [DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}