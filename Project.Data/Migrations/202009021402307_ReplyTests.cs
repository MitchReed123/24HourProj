namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplyTests : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comment", name: "ReplyComment_Id", newName: "CommentId");
            RenameIndex(table: "dbo.Comment", name: "IX_ReplyComment_Id", newName: "IX_CommentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comment", name: "IX_CommentId", newName: "IX_ReplyComment_Id");
            RenameColumn(table: "dbo.Comment", name: "CommentId", newName: "ReplyComment_Id");
        }
    }
}
