namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inscriptionid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inscriptions", "Epreuve_Id", "dbo.Epreuves");
            DropIndex("dbo.Inscriptions", new[] { "Epreuve_Id" });
            RenameColumn(table: "dbo.Inscriptions", name: "Epreuve_Id", newName: "Id");
            AlterColumn("dbo.Inscriptions", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Inscriptions", "Id");
            AddForeignKey("dbo.Inscriptions", "Id", "dbo.Epreuves", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscriptions", "Id", "dbo.Epreuves");
            DropIndex("dbo.Inscriptions", new[] { "Id" });
            AlterColumn("dbo.Inscriptions", "Id", c => c.Int());
            RenameColumn(table: "dbo.Inscriptions", name: "Id", newName: "Epreuve_Id");
            CreateIndex("dbo.Inscriptions", "Epreuve_Id");
            AddForeignKey("dbo.Inscriptions", "Epreuve_Id", "dbo.Epreuves", "Id");
        }
    }
}
