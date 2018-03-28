namespace FreeWheel.MoviesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        YearOfRelease = c.Int(nullable: false),
                        RunningTime = c.Int(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movie");
        }
    }
}
