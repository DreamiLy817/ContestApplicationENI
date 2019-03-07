namespace ContestApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBD : DbMigration
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
            
            AddColumn("dbo.AspNetUsers", "displayConfiguration_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "displayConfiguration_Id");
            AddForeignKey("dbo.AspNetUsers", "displayConfiguration_Id", "dbo.DisplayConfigurations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "displayConfiguration_Id", "dbo.DisplayConfigurations");
            DropIndex("dbo.AspNetUsers", new[] { "displayConfiguration_Id" });
            DropColumn("dbo.AspNetUsers", "displayConfiguration_Id");
            DropTable("dbo.DisplayConfigurations");
        }
    }
}
