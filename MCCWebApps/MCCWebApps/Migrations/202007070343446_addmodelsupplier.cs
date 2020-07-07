namespace MCCWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelsupplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        JoinDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Supplier");
        }
    }
}
