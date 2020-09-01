namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentTests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        CommentPost_Id = c.Int(),
                        ReplyComment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.CommentPost_Id)
                .ForeignKey("dbo.Comment", t => t.ReplyComment_Id)
                .Index(t => t.CommentPost_Id)
                .Index(t => t.ReplyComment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "ReplyComment_Id", "dbo.Comment");
            DropForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "ReplyComment_Id" });
            DropIndex("dbo.Comment", new[] { "CommentPost_Id" });
            DropTable("dbo.Comment");
        }
    }
}
