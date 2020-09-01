namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentImplement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "CommentPost_Id" });
            RenameColumn(table: "dbo.Comment", name: "CommentPost_Id", newName: "PostId");
            AlterColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostId" });
            AlterColumn("dbo.Comment", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "CommentPost_Id");
            CreateIndex("dbo.Comment", "CommentPost_Id");
            AddForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post", "Id");
        }
    }
}
