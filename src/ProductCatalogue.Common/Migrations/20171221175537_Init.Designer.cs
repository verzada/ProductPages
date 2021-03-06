﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProductPages.Common.Data;
using System;

namespace ProductPages.Common.Migrations
{
    [DbContext(typeof(ProductPageContext))]
    [Migration("20171221175537_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductPages.Common.Models.ImageUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("ProductPageId");

                    b.Property<string>("ToolTip");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProductPageId");

                    b.ToTable("ImageUrl");
                });

            modelBuilder.Entity("ProductPages.Common.Models.ProductPage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<string>("MaintainerOfProduct");

                    b.Property<string>("NameOfProduct");

                    b.Property<string>("OctopusDeployProjectUrl");

                    b.Property<string>("SystemDocumentationUrl");

                    b.Property<string>("TeamCityProjectUrl");

                    b.Property<int?>("TypeOfProductId");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfProductId");

                    b.ToTable("ProductPages");
                });

            modelBuilder.Entity("ProductPages.Common.Models.ProductPageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeOfProduct");

                    b.HasKey("Id");

                    b.ToTable("ProductPageTypes");
                });

            modelBuilder.Entity("ProductPages.Common.Models.ImageUrl", b =>
                {
                    b.HasOne("ProductPages.Common.Models.ProductPage")
                        .WithMany("ImageUrls")
                        .HasForeignKey("ProductPageId");
                });

            modelBuilder.Entity("ProductPages.Common.Models.ProductPage", b =>
                {
                    b.HasOne("ProductPages.Common.Models.ProductPageType", "TypeOfProduct")
                        .WithMany()
                        .HasForeignKey("TypeOfProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
