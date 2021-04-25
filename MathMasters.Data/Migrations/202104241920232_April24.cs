namespace MathMasters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class April24 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedule", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Schedule", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Schedule", "TutorId", "dbo.Tutor");
            DropIndex("dbo.Schedule", new[] { "StudentId" });
            DropIndex("dbo.Schedule", new[] { "TutorId" });
            DropIndex("dbo.Schedule", new[] { "CourseId" });
            AlterColumn("dbo.Schedule", "StudentId", c => c.Int());
            AlterColumn("dbo.Schedule", "TutorId", c => c.Int());
            AlterColumn("dbo.Schedule", "CourseId", c => c.Int());
            CreateIndex("dbo.Schedule", "StudentId");
            CreateIndex("dbo.Schedule", "TutorId");
            CreateIndex("dbo.Schedule", "CourseId");
            AddForeignKey("dbo.Schedule", "CourseId", "dbo.Course", "Id");
            AddForeignKey("dbo.Schedule", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Schedule", "TutorId", "dbo.Tutor", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "TutorId", "dbo.Tutor");
            DropForeignKey("dbo.Schedule", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Schedule", "CourseId", "dbo.Course");
            DropIndex("dbo.Schedule", new[] { "CourseId" });
            DropIndex("dbo.Schedule", new[] { "TutorId" });
            DropIndex("dbo.Schedule", new[] { "StudentId" });
            AlterColumn("dbo.Schedule", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedule", "TutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedule", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedule", "CourseId");
            CreateIndex("dbo.Schedule", "TutorId");
            CreateIndex("dbo.Schedule", "StudentId");
            AddForeignKey("dbo.Schedule", "TutorId", "dbo.Tutor", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schedule", "StudentId", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schedule", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
        }
    }
}
