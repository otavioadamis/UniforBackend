using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .HasKey(c => c.UserId);

            modelBuilder.Entity<Compra>()
                .Property(c => c.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            //------Setando relacoes de entidades-------//

            modelBuilder.Entity<User>()
                .HasOne(u => u.Carrinho)
                .WithOne(c => c.User)
                .HasForeignKey<Carrinho>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
