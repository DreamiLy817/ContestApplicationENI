namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBD : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Epreuves", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Epreuves", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
