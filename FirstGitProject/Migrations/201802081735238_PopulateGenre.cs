namespace FirstGitProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Single Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Multi Unit')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Building')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Business')");
            

           
        }
        
        public override void Down()
        {
        }
    }
}
