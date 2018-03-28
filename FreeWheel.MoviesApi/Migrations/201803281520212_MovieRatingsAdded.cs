namespace FreeWheel.MoviesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieRatingsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        Surname = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.MovieRating");
        }
    }
}
