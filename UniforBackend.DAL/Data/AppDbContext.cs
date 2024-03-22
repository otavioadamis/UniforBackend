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

            modelBuilder.Entity<Compra>()
                .Property(c => c.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            //------Setando relacoes de entidades-------//


            // 1 pra n 
            modelBuilder.Entity<User>()
                .HasMany(u => u.Itens)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1 pra n
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Comprador)
                .WithMany()
                .HasForeignKey(c => c.CompradorId);

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Vendedor)
                .WithMany()
                .HasForeignKey(c => c.VendedorId);

            // n pra n
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Item)
                .WithOne()
                .HasForeignKey<Compra>(c => c.ItemId);
        }
    }
}
