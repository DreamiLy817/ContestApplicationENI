namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProfilAndResultat : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Resultats", new[] { "EpreuveId" });
            DropIndex("dbo.Resultats", new[] { "ProfilId" });
            DropTable("dbo.Resultats");
            DropTable("dbo.Profils");
        }
    }
}
