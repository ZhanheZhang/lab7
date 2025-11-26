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

        [Required(ErrorMessage = "学生姓名是必填项。")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "姓名长度必须在3到50个字符之间。")]
        public string Name { get; set; }

        [Required(ErrorMessage = "地址是必填项。")]
        [StringLength(100, ErrorMessage = "地址不能超过100个字符。")]
        public string Address { get; set; }

        public string CampusID { get; set; }

        [ForeignKey("CampusID")]
        public virtual UniversityCampus Campus { get; set; }
    }
}