namespace DataBaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Table_update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 450));
            CreateIndex("dbo.Users", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Name" });
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
