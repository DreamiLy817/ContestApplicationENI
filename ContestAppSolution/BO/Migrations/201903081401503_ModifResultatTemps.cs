namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifResultatTemps : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resultats", "Temps", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resultats", "Temps", c => c.DateTime(nullable: false));
        }
    }
}
