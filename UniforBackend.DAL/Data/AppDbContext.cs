using Microsoft.EntityFrameworkCore;
using System;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //-----Setando Ids strings auto-generadas--------//
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Item>()
                .Property(i => i.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Carrinho>()
                .Property(i => i.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Compra>()
                .Property(c => c.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            //------Setando relacoes de entidades-------//

            // 1 pra 1 
            modelBuilder.Entity<User>()
                .HasOne(u => u.Carrinho)
                .WithOne(c => c.User)
                .HasForeignKey<Carrinho>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // 1 pra n 
            modelBuilder.Entity<User>()
                .HasMany(u => u.Itens)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1 pra n
            modelBuilder.Entity<User>()
                .HasMany(u => u.Compras)
                .WithOne(c => c.Comprador)
                .HasForeignKey(c => c.CompradorId);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Compras)
                .WithOne(c => c.Vendedor)
                .HasForeignKey(c => c.VendedorId);

            // n pra n
            modelBuilder.Entity<Compra>()
                .HasMany(c => c.Itens)
                .WithMany()
                .UsingEntity<CompraItem>(
                    j => j.HasOne(e => e.Item).WithMany().HasForeignKey(e => e.ItemId),
                    j => j.HasOne(e => e.Compra).WithMany().HasForeignKey(e => e.CompraId)
                );

            // n pra n
            modelBuilder.Entity<Carrinho>()
                .HasMany(c => c.Itens)
                .WithMany()
                .UsingEntity<CarrinhoItem>(
                    j => j.HasOne(e => e.Item).WithMany().HasForeignKey(e => e.ItemId),
                    j => j.HasOne(e => e.Carrinho).WithMany().HasForeignKey(e => e.CarrinhoId)
                );
        }
    }
}
