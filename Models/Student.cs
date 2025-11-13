using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class Student
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string CampusID { get; set; }

        [ForeignKey("CampusID")]
        public virtual UniversityCampus Campus { get; set; }
    }
}