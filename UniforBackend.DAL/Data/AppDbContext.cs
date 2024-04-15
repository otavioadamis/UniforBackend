using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            InitializeDatabase();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }

        private void InitializeDatabase()
        {
            // Check if the Categories table exists
            if (!Categorias.Any())
            {
                // Read SQL script file
                string script = File.ReadAllText("DatabaseInit.sql");

                // Execute SQL commands
                Database.ExecuteSqlRaw(script);
            }
        }

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

            modelBuilder.Entity<Venda>()
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

            modelBuilder.Entity<Venda>()
                .HasOne(c => c.Vendedor)
                .WithMany()
                .HasForeignKey(c => c.VendedorId);

            // n pra n
            modelBuilder.Entity<Venda>()
                .HasOne(c => c.Item)
                .WithOne()
                .HasForeignKey<Venda>(c => c.ItemId);

            // 1 pra n
            modelBuilder.Entity<SubCategoria>()
                .HasOne(s => s.Categoria)
                .WithMany(c => c.SubCategorias)
                .HasForeignKey(s => s.CategoriaId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.SubCategoria)
                .WithMany(s => s.Items)
                .HasForeignKey(i => i.SubCategoriaId);

            //------Propriedades auto-generadas-------//

            modelBuilder.Entity<Item>()
                .Property(b => b.PostadoEm)
                .HasDefaultValueSql("CURRENT_DATE");

            modelBuilder.Entity<Venda>()
                 .Property(b => b.DataVenda)
                 .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .Property(c => c.CriadoEm)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
