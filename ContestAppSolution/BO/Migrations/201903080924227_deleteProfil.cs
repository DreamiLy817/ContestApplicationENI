namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteProfil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resultats", "ProfilId", "dbo.Profils");
            DropIndex("dbo.Resultats", new[] { "ProfilId" });
            DropColumn("dbo.Resultats", "ProfilId");
            DropTable("dbo.Profils");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Resultats", "ProfilId", c => c.Int(nullable: false));
            CreateIndex("dbo.Resultats", "ProfilId");
            AddForeignKey("dbo.Resultats", "ProfilId", "dbo.Profils", "Id", cascadeDelete: true);
        }
    }
}
