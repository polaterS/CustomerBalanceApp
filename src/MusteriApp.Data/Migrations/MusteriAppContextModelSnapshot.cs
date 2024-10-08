﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusteriApp.Data;

#nullable disable

namespace MusteriApp.Data.Migrations
{
    [DbContext(typeof(MusteriAppContext))]
    partial class MusteriAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusteriApp.Data.Entities.Fatura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("FATURA_TARIHI")
                        .HasColumnType("date");

                    b.Property<decimal>("FATURA_TUTARI")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MUSTERI_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ODEME_TARIHI")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.HasIndex("MUSTERI_ID");

                    b.ToTable("musteri_fatura_table", (string)null);
                });

            modelBuilder.Entity("MusteriApp.Data.Entities.Musteri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("UNVAN")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("musteri_tanim_table", (string)null);
                });

            modelBuilder.Entity("MusteriApp.Data.Entities.Fatura", b =>
                {
                    b.HasOne("MusteriApp.Data.Entities.Musteri", "Musteri")
                        .WithMany()
                        .HasForeignKey("MUSTERI_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musteri");
                });
#pragma warning restore 612, 618
        }
    }
}
