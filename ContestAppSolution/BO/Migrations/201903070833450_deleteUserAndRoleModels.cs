namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUserAndRoleModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "DisplayConfiguration_Id", "dbo.DisplayConfigurations");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "DisplayConfiguration_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropTable("dbo.DisplayConfigurations");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identifiant = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                        DisplayConfiguration_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DisplayConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniteTemps = c.Int(nullable: false),
                        UniteMesure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Users", "Role_Id");
            CreateIndex("dbo.Users", "DisplayConfiguration_Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
            AddForeignKey("dbo.Users", "DisplayConfiguration_Id", "dbo.DisplayConfigurations", "Id");
        }
    }
}
