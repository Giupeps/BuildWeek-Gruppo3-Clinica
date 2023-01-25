namespace BuildWeek_Gruppo3_Clinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        IdEmail = c.Int(nullable: false, identity: true),
                        EmailMittente = c.String(nullable: false, maxLength: 50),
                        Messaggio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emails");
        }
    }
}
