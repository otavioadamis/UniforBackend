﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UniforBackend.DAL.Data;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240430230348_imagens-varias")]
    partial class imagensvarias
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Categoria", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Imagem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Extensao")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Item", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("AceitaTroca")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsVendido")
                        .HasColumnType("boolean");

                    b.Property<bool>("MostrarContato")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<DateOnly>("PostadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<string>("SubCategoriaId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<bool>("isAprovado")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoriaId");

                    b.HasIndex("UserId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.SubCategoria", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CategoriaId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("SubCategorias");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("bytea");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Venda", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("DataVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("VendedorId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("VendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Imagem", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Item", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.SubCategoria", "SubCategoria")
                        .WithMany("Items")
                        .HasForeignKey("SubCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniforBackend.Domain.Models.Entities.User", "User")
                        .WithMany("Itens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategoria");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.SubCategoria", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.Categoria", "Categoria")
                        .WithMany("SubCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Venda", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.Item", "Item")
                        .WithOne()
                        .HasForeignKey("UniforBackend.Domain.Models.Entities.Venda", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniforBackend.Domain.Models.Entities.User", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Categoria", b =>
                {
                    b.Navigation("SubCategorias");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.SubCategoria", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.User", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
