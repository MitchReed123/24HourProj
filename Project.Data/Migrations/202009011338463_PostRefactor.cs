namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostRefactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "UserID", "dbo.User");
            DropForeignKey("dbo.Post", "UserID", "dbo.User");
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropForeignKey("dbo.Comment", "CommentID", "dbo.Comment");
            DropForeignKey("dbo.Like", "PostID", "dbo.Post");
            DropForeignKey("dbo.Like", "UserID", "dbo.User");
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropIndex("dbo.Comment", new[] { "CommentID" });
            DropIndex("dbo.Post", new[] { "UserID" });
            DropIndex("dbo.Like", new[] { "PostID" });
            DropIndex("dbo.Like", new[] { "UserID" });
            AddColumn("dbo.Post", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Post", "UserID");
            DropTable("dbo.Comment");
            DropTable("dbo.User");
            DropTable("dbo.Like");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        PostID = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        CommentID = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Post", "UserID", c => c.Guid(nullable: false));
            DropColumn("dbo.Post", "OwnerId");
            CreateIndex("dbo.Like", "UserID");
            CreateIndex("dbo.Like", "PostID");
            CreateIndex("dbo.Post", "UserID");
            CreateIndex("dbo.Comment", "CommentID");
            CreateIndex("dbo.Comment", "PostID");
            CreateIndex("dbo.Comment", "UserID");
            AddForeignKey("dbo.Like", "UserID", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Like", "PostID", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "CommentID", "dbo.Comment", "Id");
            AddForeignKey("dbo.Comment", "PostID", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Post", "UserID", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "UserID", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
