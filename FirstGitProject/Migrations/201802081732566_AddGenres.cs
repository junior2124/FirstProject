namespace FirstGitProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Homes", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Homes", "GenreId");
            AddForeignKey("dbo.Homes", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homes", "GenreId", "dbo.Genres");
            DropIndex("dbo.Homes", new[] { "GenreId" });
            DropColumn("dbo.Homes", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
