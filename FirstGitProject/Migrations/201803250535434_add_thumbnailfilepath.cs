namespace FirstGitProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_thumbnailfilepath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homes", "ThumbnailFilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Homes", "ThumbnailFilePath");
        }
    }
}
