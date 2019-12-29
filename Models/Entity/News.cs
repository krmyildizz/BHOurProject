using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}