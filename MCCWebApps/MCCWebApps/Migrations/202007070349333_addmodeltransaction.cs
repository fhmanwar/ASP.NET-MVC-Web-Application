namespace MCCWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodeltransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Transaction",
                c => new
                    {
                        Nota = c.Int(nullable: false, identity: true),
                        qty = c.Int(nullable: false),
                        total = c.Int(nullable: false),
                        created_at = c.DateTimeOffset(nullable: false, precision: 7),
                        id_product = c.Int(nullable: false),
                        id_supplier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nota)
                .ForeignKey("dbo.Tbl_Product", t => t.id_product, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Supplier", t => t.id_supplier, cascadeDelete: true)
                .Index(t => t.id_product)
                .Index(t => t.id_supplier);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Transaction", "id_supplier", "dbo.Tbl_Supplier");
            DropForeignKey("dbo.Tbl_Transaction", "id_product", "dbo.Tbl_Product");
            DropIndex("dbo.Tbl_Transaction", new[] { "id_supplier" });
            DropIndex("dbo.Tbl_Transaction", new[] { "id_product" });
            DropTable("dbo.Tbl_Transaction");
        }
    }
}
