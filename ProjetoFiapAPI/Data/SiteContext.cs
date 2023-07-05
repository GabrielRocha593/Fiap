using ProjetoFiapAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFiapAPI.Data;

public class SiteContext : DbContext
{
    public SiteContext(DbContextOptions<SiteContext> opts) : base(opts)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ItemPedido>()
           .HasOne(itemPedido => itemPedido.Produto)
           .WithMany(produto => produto.ItemPedido)
           .HasForeignKey(itemPedido => itemPedido.ProdutoID);

        builder.Entity<ItemPedido>()
           .HasOne(itemPedido => itemPedido.Pedido)
           .WithMany(pedido => pedido.ItemPedido)
           .HasForeignKey(itemPedido => itemPedido.PedidoID);

        builder.Entity<Pedido>()
           .HasOne(pedido => pedido.Cadastro)
           .WithMany(cadastro => cadastro.Pedido)
           .HasForeignKey(pedido => pedido.CadastroId);
    }

    public DbSet<Produto> Produto { get; set; }
    public DbSet<Cadastro> Cadastro { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<ItemPedido> ItemPedido { get; set; }
}
