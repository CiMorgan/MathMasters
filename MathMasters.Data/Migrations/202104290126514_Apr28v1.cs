namespace MathMasters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Apr28v1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tutor", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutor", "Time", c => c.Int(nullable: false));
        }
    }
}
