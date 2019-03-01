namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Base : DbMigration
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
                        Distance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Inscription = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Ville_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Villes", t => t.Ville_Id)
                .Index(t => t.Ville_Id);
            
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
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identifiant = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.PointOfInterests", "Epreuve_Id", "dbo.Epreuves");
            DropForeignKey("dbo.Epreuves", "Ville_Id", "dbo.Villes");
            DropForeignKey("dbo.PointOfInterests", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.PointOfInterests", new[] { "Epreuve_Id" });
            DropIndex("dbo.PointOfInterests", new[] { "Categorie_Id" });
            DropIndex("dbo.Epreuves", new[] { "Ville_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.PointOfInterests");
            DropTable("dbo.Villes");
            DropTable("dbo.Epreuves");
            DropTable("dbo.Categories");
        }
    }
}
