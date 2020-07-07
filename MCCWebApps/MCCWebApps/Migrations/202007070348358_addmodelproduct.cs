namespace MCCWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nm_product = c.String(),
                        price = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Product");
        }
    }
}
