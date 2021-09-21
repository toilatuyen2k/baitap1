using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace baitap1.Models
{
    
    public class Student
    {
        [Key]
        public string StudentID { get; set; }
        public string Studentname { get; set; }
        public string Address { get; set; }
    }
}