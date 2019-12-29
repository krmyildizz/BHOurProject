using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class Company
    {
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

    }
}