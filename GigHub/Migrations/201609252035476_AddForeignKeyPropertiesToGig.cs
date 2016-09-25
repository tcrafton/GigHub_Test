namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToGig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            RenameColumn(table: "dbo.Gigs", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Genre_Id", newName: "IX_GenreId");
            AddColumn("dbo.Gigs", "AristId", c => c.String(nullable: false));
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Gigs", "AristId");
            RenameIndex(table: "dbo.Gigs", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Gigs", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
