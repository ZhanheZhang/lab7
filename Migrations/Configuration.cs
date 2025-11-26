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
            // 1. 创建并添加 University Campuses (校区)，必须手动设置唯一的ID
            var campuses = new List<UniversityCampus>
        {
            new UniversityCampus { ID = "UC01", Name = "Main Campus" }, // <-- 明确设置 ID
            new UniversityCampus { ID = "UC02", Name = "City Campus" }, // <-- 明确设置 ID
            new UniversityCampus { ID = "UC03", Name = "Online Campus" } // <-- 明确设置 ID
        };

            campuses.ForEach(c => context.UniversityCampus.AddOrUpdate(p => p.ID, c));
            // 注意：这里使用 p => p.ID 来判断是否需要更新，而不是 Name

            context.SaveChanges(); // 必须先保存校区，以便获取它们的 ID

            // 2. 创建并添加 Students (学生)，必须手动设置唯一的ID
            var students = new List<Student>
        {
            new Student {
                ID = "S001", // <-- 明确设置 ID
                Name = "Alice",
                Address = "123 Main St",
                CampusID = campuses.Single(c => c.Name == "Main Campus").ID
            },
            new Student {
                ID = "S002", // <-- 明确设置 ID
                Name = "Bob",
                Address = "456 City Ave",
                CampusID = campuses.Single(c => c.Name == "City Campus").ID
            },
            new Student {
                ID = "S003", // <-- 明确设置 ID
                Name = "Charlie",
                Address = "789 Remote Ln",
                CampusID = campuses.Single(c => c.Name == "Online Campus").ID
            },
            // 添加更多学生数据...
        };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.ID, s));
            // 注意：这里使用 p => p.ID 来判断是否需要更新

            context.SaveChanges();
        }
    }
}
