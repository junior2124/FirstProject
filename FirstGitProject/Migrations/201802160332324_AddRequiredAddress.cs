namespace FirstGitProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Homes", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Homes", "Address", c => c.String());
        }
    }
}
