namespace lab7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentValidationUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
        }
    }
}
