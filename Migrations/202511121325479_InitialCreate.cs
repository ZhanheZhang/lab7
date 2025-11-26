namespace lab7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        CampusID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UniversityCampus", t => t.CampusID)
                .Index(t => t.CampusID);
            
            CreateTable(
                "dbo.UniversityCampus",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CampusID", "dbo.UniversityCampus");
            DropIndex("dbo.Students", new[] { "CampusID" });
            DropTable("dbo.UniversityCampus");
            DropTable("dbo.Students");
        }
    }
}
