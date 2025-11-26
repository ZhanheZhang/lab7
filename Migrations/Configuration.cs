namespace lab7.Migrations
{
    using lab7.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lab7.Data.lab7Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "lab7.Data.lab7Context";
        }

        protected override void Seed(lab7.Data.lab7Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            var campuses = new List<UniversityCampus>
        {
            new UniversityCampus { ID = "UC01", Name = "Main Campus" }, 
            new UniversityCampus { ID = "UC02", Name = "City Campus" },
            new UniversityCampus { ID = "UC03", Name = "Online Campus" }
        };

            campuses.ForEach(c => context.UniversityCampus.AddOrUpdate(p => p.ID, c));
            

            context.SaveChanges(); 

           
            var students = new List<Student>
        {
            new Student {
                ID = "S001", 
                Name = "Alice",
                Address = "123 Main St",
                CampusID = campuses.Single(c => c.Name == "Main Campus").ID
            },
            new Student {
                ID = "S002", 
                Name = "Bob",
                Address = "456 City Ave",
                CampusID = campuses.Single(c => c.Name == "City Campus").ID
            },
            new Student {
                ID = "S003",
                Name = "Charlie",
                Address = "789 Remote Ln",
                CampusID = campuses.Single(c => c.Name == "Online Campus").ID
            },
            
        };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.ID, s));
            

            context.SaveChanges();
        }
    }
}
