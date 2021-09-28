namespace baitap1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Cololumn_Student_Adress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        Studentname = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
