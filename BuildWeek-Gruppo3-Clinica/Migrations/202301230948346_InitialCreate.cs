namespace BuildWeek_Gruppo3_Clinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anagr_Animale",
                c => new
                    {
                        IdAnimale = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        IdTipo = c.Int(nullable: false),
                        Colore = c.String(nullable: false, maxLength: 20),
                        DataNascita = c.DateTime(nullable: false, storeType: "date"),
                        NrMicrochip = c.String(maxLength: 6),
                        Proprietario = c.Boolean(nullable: false),
                        NomeProprietario = c.String(maxLength: 20),
                        Indirizzo = c.String(maxLength: 50),
                        Contatto = c.String(maxLength: 20),
                        Foto = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdAnimale)
                .ForeignKey("dbo.Tipologia", t => t.IdTipo)
                .Index(t => t.IdTipo);
            
            CreateTable(
                "dbo.Tipologia",
                c => new
                    {
                        idTipo = c.Int(nullable: false, identity: true),
                        Animale = c.String(nullable: false, maxLength: 20),
                        Razza = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idTipo);
            
            CreateTable(
                "dbo.Visite",
                c => new
                    {
                        IdVisita = c.Int(nullable: false, identity: true),
                        IdAnimale = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Referto = c.String(nullable: false),
                        Diagnosi = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdVisita)
                .ForeignKey("dbo.Anagr_Animale", t => t.IdAnimale)
                .Index(t => t.IdAnimale);
            
            CreateTable(
                "dbo.Utente",
                c => new
                    {
                        IdUtente = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUtente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visite", "IdAnimale", "dbo.Anagr_Animale");
            DropForeignKey("dbo.Anagr_Animale", "IdTipo", "dbo.Tipologia");
            DropIndex("dbo.Visite", new[] { "IdAnimale" });
            DropIndex("dbo.Anagr_Animale", new[] { "IdTipo" });
            DropTable("dbo.Utente");
            DropTable("dbo.Visite");
            DropTable("dbo.Tipologia");
            DropTable("dbo.Anagr_Animale");
        }
    }
}
