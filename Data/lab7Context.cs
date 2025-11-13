using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab7.Data
{
    public class lab7Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public lab7Context() : base("name=lab7Context")
        {
        }

        public System.Data.Entity.DbSet<lab7.Models.UniversityCampus> UniversityCampus { get; set; }

        public System.Data.Entity.DbSet<lab7.Models.Student> Students { get; set; }
    }
}
