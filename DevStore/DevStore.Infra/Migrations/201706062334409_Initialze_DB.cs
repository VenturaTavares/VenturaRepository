namespace DevStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialze_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrinho",
                c => new
                    {
                        IDCarrinho = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(nullable: false, maxLength: 80),
                        DataCompra = c.DateTime(nullable: false),
                        ValorCompra = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IDCarrinho);
            
            CreateTable(
                "dbo.ItemPedido",
                c => new
                    {
                        IDItemPedido = c.Int(nullable: false, identity: true),
                        IDCarrinho = c.Int(nullable: false),
                        IDProduto = c.Int(nullable: false),
                        ValorUnitario = c.Double(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        Quantidade = c.Double(nullable: false),
                        Carrinho_IDCarrinho = c.Int(),
                    })
                .PrimaryKey(t => t.IDItemPedido)
                .ForeignKey("dbo.Carrinho", t => t.IDCarrinho, cascadeDelete: false)
                .ForeignKey("dbo.Produto", t => t.IDProduto, cascadeDelete: false)
                .Index(t => t.IDCarrinho)
                .Index(t => t.IDProduto)
                .Index(t => t.Carrinho_IDCarrinho);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        IDProduto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 160),
                        Valor = c.Double(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDProduto)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: false)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
      
            DropForeignKey("dbo.ItemPedido", "IDProduto", "dbo.Produto");
            DropForeignKey("dbo.Produto", "CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.ItemPedido", "IDCarrinho", "dbo.Carrinho");
            DropIndex("dbo.Produto", new[] { "CategoriaID" });
            DropIndex("dbo.ItemPedido", new[] { "Carrinho_IDCarrinho" });
            DropIndex("dbo.ItemPedido", new[] { "IDProduto" });
            DropIndex("dbo.ItemPedido", new[] { "IDCarrinho" });
            DropTable("dbo.Categoria");
            DropTable("dbo.Produto");
            DropTable("dbo.ItemPedido");
            DropTable("dbo.Carrinho");
        }
    }
}
