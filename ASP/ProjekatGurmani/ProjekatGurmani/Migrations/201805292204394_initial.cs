namespace ProjekatGurmani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jelo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazivJela = c.String(),
                        vrsta = c.String(),
                        cijena = c.Int(nullable: false),
                        idObjekta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Kupac",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ime = c.String(),
                        prezime = c.String(),
                        adresa = c.String(),
                        telefon = c.String(),
                        username = c.String(),
                        password = c.String(),
                        email = c.String(),
                        grad = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Narudzba",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idKupca = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Objekat",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ime = c.String(),
                        prezime = c.String(),
                        adresa = c.String(),
                        telefon = c.String(),
                        username = c.String(),
                        password = c.String(),
                        email = c.String(),
                        grad = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StavkeNarudzbe",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idNarudzbe = c.Int(nullable: false),
                        idJela = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StavkeNarudzbe");
            DropTable("dbo.Objekat");
            DropTable("dbo.Narudzba");
            DropTable("dbo.Kupac");
            DropTable("dbo.Jelo");
            DropTable("dbo.Administrator");
        }
    }
}
