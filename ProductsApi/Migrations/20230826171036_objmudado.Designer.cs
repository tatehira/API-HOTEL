﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi.Data;

#nullable disable

namespace ProductsApi.Migrations
{
    [DbContext(typeof(HotelsContext))]
    [Migration("20230826171036_objmudado")]
    partial class objmudado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeHotel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Regiao")
                        .HasColumnType("int");

                    b.Property<double>("ValorDiaria")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Quarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroQuarto")
                        .HasColumnType("int");

                    b.Property<int>("StatusQuarto")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Quarto");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<int?>("QuartoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Saida")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusReserva")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuartoId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Quarto", b =>
                {
                    b.HasOne("ProductsApi.Models.HotelModels.Hotel", null)
                        .WithMany("Quarto")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Reserva", b =>
                {
                    b.HasOne("ProductsApi.Models.HotelModels.Quarto", null)
                        .WithMany("Reserva")
                        .HasForeignKey("QuartoId");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Hotel", b =>
                {
                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Quarto", b =>
                {
                    b.Navigation("Reserva");
                });
#pragma warning restore 612, 618
        }
    }
}
