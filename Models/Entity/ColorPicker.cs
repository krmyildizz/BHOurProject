using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Entity
{
    public class ColorPicker
    {   [Key]
        public int Is { get; set; }
        public string Value { get; set; }
        public string Rgb { get; set; }

    }
}