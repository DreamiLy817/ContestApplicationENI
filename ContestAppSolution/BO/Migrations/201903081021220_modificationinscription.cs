namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationinscription : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Epreuves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        VilleId = c.Int(),
                        Distance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Inscription = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Villes", t => t.VilleId)
                .Index(t => t.VilleId);
            
            CreateTable(
                "dbo.Villes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        CodePostal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        UtilisateurName = c.String(nullable: false, maxLength: 128),
                        dateInscription = c.DateTime(nullable: false),
                        Epreuve_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UtilisateurName)
                .ForeignKey("dbo.Epreuves", t => t.Epreuve_Id)
                .Index(t => t.Epreuve_Id);
            
            CreateTable(
                "dbo.PointOfInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Distance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Categorie_Id = c.Int(),
                        Epreuve_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id)
                .ForeignKey("dbo.Epreuves", t => t.Epreuve_Id)
                .Index(t => t.Categorie_Id)
                .Index(t => t.Epreuve_Id);
            
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resultats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfilId = c.Int(nullable: false),
                        EpreuveId = c.Int(nullable: false),
                        Temps = c.DateTime(nullable: false),
                        Positionfinale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Epreuves", t => t.EpreuveId, cascadeDelete: true)
                .ForeignKey("dbo.Profils", t => t.ProfilId, cascadeDelete: true)
                .Index(t => t.ProfilId)
                .Index(t => t.EpreuveId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resultats", "ProfilId", "dbo.Profils");
            DropForeignKey("dbo.Resultats", "EpreuveId", "dbo.Epreuves");
            DropForeignKey("dbo.PointOfInterests", "Epreuve_Id", "dbo.Epreuves");
            DropForeignKey("dbo.PointOfInterests", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Inscriptions", "Epreuve_Id", "dbo.Epreuves");
            DropForeignKey("dbo.Epreuves", "VilleId", "dbo.Villes");
            DropIndex("dbo.Resultats", new[] { "EpreuveId" });
            DropIndex("dbo.Resultats", new[] { "ProfilId" });
            DropIndex("dbo.PointOfInterests", new[] { "Epreuve_Id" });
            DropIndex("dbo.PointOfInterests", new[] { "Categorie_Id" });
            DropIndex("dbo.Inscriptions", new[] { "Epreuve_Id" });
            DropIndex("dbo.Epreuves", new[] { "VilleId" });
            DropTable("dbo.Resultats");
            DropTable("dbo.Profils");
            DropTable("dbo.PointOfInterests");
            DropTable("dbo.Inscriptions");
            DropTable("dbo.Villes");
            DropTable("dbo.Epreuves");
            DropTable("dbo.Categories");
        }
    }
}
