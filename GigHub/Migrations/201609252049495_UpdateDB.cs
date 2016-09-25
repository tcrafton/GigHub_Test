namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "ArtistId");
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "ArtistId");
            AddForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Gigs", "AristId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "AristId", c => c.String(nullable: false));
            DropForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Gigs", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
