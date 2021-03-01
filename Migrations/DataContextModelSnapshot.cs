﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerceAssessment.Data;

namespace ecommerceassessment.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eCommerceAssessment.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPrimary")
                        .HasColumnType("bit");

                    b.Property<int>("postalCode")
                        .HasColumnType("int");

                    b.Property<int>("postalCodeExt")
                        .HasColumnType("int");

                    b.Property<string>("street1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("productid")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int?>("transactionid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productid");

                    b.HasIndex("transactionid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.ShippingProvider", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameShort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("rateFlat")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("ShippingProviders");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Transaction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("shippingAddressid")
                        .HasColumnType("int");

                    b.Property<int?>("shippingProviderid")
                        .HasColumnType("int");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("shippingAddressid");

                    b.HasIndex("shippingProviderid");

                    b.HasIndex("userid");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("typeid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.UserType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accessLevel")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Address", b =>
                {
                    b.HasOne("eCommerceAssessment.Models.User", "user")
                        .WithMany("addresses")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Order", b =>
                {
                    b.HasOne("eCommerceAssessment.Models.Product", "product")
                        .WithMany("orders")
                        .HasForeignKey("productid");

                    b.HasOne("eCommerceAssessment.Models.Transaction", "transaction")
                        .WithMany("orders")
                        .HasForeignKey("transactionid");

                    b.Navigation("product");

                    b.Navigation("transaction");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Transaction", b =>
                {
                    b.HasOne("eCommerceAssessment.Models.Address", "shippingAddress")
                        .WithMany("transactions")
                        .HasForeignKey("shippingAddressid");

                    b.HasOne("eCommerceAssessment.Models.ShippingProvider", "shippingProvider")
                        .WithMany("transactions")
                        .HasForeignKey("shippingProviderid");

                    b.HasOne("eCommerceAssessment.Models.User", "user")
                        .WithMany("transactions")
                        .HasForeignKey("userid");

                    b.Navigation("shippingAddress");

                    b.Navigation("shippingProvider");

                    b.Navigation("user");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.User", b =>
                {
                    b.HasOne("eCommerceAssessment.Models.UserType", "type")
                        .WithMany("users")
                        .HasForeignKey("typeid");

                    b.Navigation("type");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Address", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Product", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.ShippingProvider", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Transaction", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.User", b =>
                {
                    b.Navigation("addresses");

                    b.Navigation("transactions");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.UserType", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}