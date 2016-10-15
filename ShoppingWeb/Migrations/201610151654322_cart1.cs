namespace ShoppingWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Carts", "ShoppingCartViewModel_Id", c => c.Int());
            CreateIndex("dbo.Carts", "ShoppingCartViewModel_Id");
            AddForeignKey("dbo.Carts", "ShoppingCartViewModel_Id", "dbo.ShoppingCartViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ShoppingCartViewModel_Id", "dbo.ShoppingCartViewModels");
            DropIndex("dbo.Carts", new[] { "ShoppingCartViewModel_Id" });
            DropColumn("dbo.Carts", "ShoppingCartViewModel_Id");
            DropTable("dbo.ShoppingCartViewModels");
        }
    }
}
