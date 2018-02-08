namespace FirstGitProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }
    }
}
