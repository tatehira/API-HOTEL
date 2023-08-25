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
    [Migration("20230824220916_pr")]
    partial class pr
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

                    b.Property<int?>("QuartoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuartoId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Quarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumeroQuarto")
                        .HasColumnType("int");

                    b.Property<int>("StatusQuarto")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Hotel", b =>
                {
                    b.HasOne("ProductsApi.Models.HotelModels.Quarto", "Quarto")
                        .WithMany()
                        .HasForeignKey("QuartoId");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Reserva", b =>
                {
                    b.HasOne("ProductsApi.Models.HotelModels.Quarto", null)
                        .WithMany("Reserva")
                        .HasForeignKey("QuartoId");
                });

            modelBuilder.Entity("ProductsApi.Models.HotelModels.Quarto", b =>
                {
                    b.Navigation("Reserva");
                });
#pragma warning restore 612, 618
        }
    }
}
