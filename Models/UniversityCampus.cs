using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class UniversityCampus
    {
        [Key] 
        public string ID { get; set; }

        public string Name { get; set; }


        public virtual ICollection<Student> Students { get; set; }
    }
}