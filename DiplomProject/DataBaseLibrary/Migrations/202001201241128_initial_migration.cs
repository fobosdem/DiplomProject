namespace DataBaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NickName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserChats",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Chat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Chat_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chats", t => t.Chat_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Chat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserChats", "Chat_Id", "dbo.Chats");
            DropForeignKey("dbo.UserChats", "User_Id", "dbo.Users");
            DropIndex("dbo.UserChats", new[] { "Chat_Id" });
            DropIndex("dbo.UserChats", new[] { "User_Id" });
            DropTable("dbo.UserChats");
            DropTable("dbo.Users");
            DropTable("dbo.Chats");
        }
    }
}
