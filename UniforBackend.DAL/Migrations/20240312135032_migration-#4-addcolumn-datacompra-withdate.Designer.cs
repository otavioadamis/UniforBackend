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
    [Migration("20240312135032_migration-#4-addcolumn-datacompra-withdate")]
    partial class migration4addcolumndatacomprawithdate
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

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Carrinho", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carrinhos");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.CarrinhoItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CarrinhoId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ItemId");

                    b.ToTable("CarrinhoItem");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Compra", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CompradorId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MetodoPagamento")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompradorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.CompraItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CompraId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ItemId");

                    b.ToTable("CompraItem");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Item", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsVendido")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasDefaultValueSql("uuid_generate_v4()");

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

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Carrinho", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.User", "User")
                        .WithOne("Carrinho")
                        .HasForeignKey("UniforBackend.Domain.Models.Entities.Carrinho", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.CarrinhoItem", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.Carrinho", "Carrinho")
                        .WithMany()
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniforBackend.Domain.Models.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Compra", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.User", "Comprador")
                        .WithMany("Compras")
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comprador");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.CompraItem", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.Compra", "Compra")
                        .WithMany()
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniforBackend.Domain.Models.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.Item", b =>
                {
                    b.HasOne("UniforBackend.Domain.Models.Entities.User", "User")
                        .WithMany("Itens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniforBackend.Domain.Models.Entities.User", b =>
                {
                    b.Navigation("Carrinho")
                        .IsRequired();

                    b.Navigation("Compras");

                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
