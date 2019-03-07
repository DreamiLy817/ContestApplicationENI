namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayConfigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DisplayConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniteTemps = c.Int(nullable: false),
                        UniteMesure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DisplayConfigurations");
        }
    }
}
