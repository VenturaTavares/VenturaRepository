namespace DevStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _incluir_novos_campos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carrinho", "CompraEfetuada", c => c.Boolean(nullable: false));
            AddColumn("dbo.Carrinho", "TipoCompra", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carrinho", "TipoCompra");
            DropColumn("dbo.Carrinho", "CompraEfetuada");
        }
    }
}
