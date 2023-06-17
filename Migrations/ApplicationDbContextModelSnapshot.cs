﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back_side_DataAccess.Data;

#nullable disable

namespace _423_proj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("back_side_Model.Models.Advertisement", b =>
                {
                    b.Property<int>("AdvertisementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdvertisementID"));

                    b.Property<int>("FollowerBottomLimit")
                        .HasColumnType("int");

                    b.Property<int>("FollowerUpperLimit")
                        .HasColumnType("int");

                    b.Property<int>("ViewsBottomLimit")
                        .HasColumnType("int");

                    b.HasKey("AdvertisementID");

                    b.ToTable("Advertisements");

                    b.HasData(
                        new
                        {
                            AdvertisementID = 1,
                            FollowerBottomLimit = 0,
                            FollowerUpperLimit = 0,
                            ViewsBottomLimit = 0
                        });
                });

            modelBuilder.Entity("back_side_Model.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"));

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("ShareURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            CommentID = 1,
                            PostID = 1,
                            ShareURL = "ExampleDescription123",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("back_side_Model.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostID"));

                    b.Property<int>("AdvertisementID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerPerson")
                        .HasColumnType("float");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PostID");

                    b.HasIndex("AdvertisementID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostID = 1,
                            AdvertisementID = 1,
                            Description = "ExampleDescription",
                            PricePerPerson = 1.0,
                            Quota = 1,
                            Title = "ExampleTitle",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("back_side_Model.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("InstagramAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstagramFollowerCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TiktokAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TiktokFollowerCount")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            InstagramFollowerCount = 0,
                            Name = "metinabadan",
                            NameSurname = "Metin Abadan",
                            Password = "metinabadan06",
                            TiktokFollowerCount = 0,
                            UserTypeID = 1,
                            e_mail = "metinabadan@gmail.com"
                        });
                });

            modelBuilder.Entity("back_side_Model.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeID"));

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            UserTypeID = 1,
                            UserTypeName = "Influencer"
                        });
                });

            modelBuilder.Entity("back_side_Model.Models.Comment", b =>
                {
                    b.HasOne("back_side_Model.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_side_Model.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("back_side_Model.Models.Post", b =>
                {
                    b.HasOne("back_side_Model.Models.Advertisement", "Advertisement")
                        .WithMany()
                        .HasForeignKey("AdvertisementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_side_Model.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("back_side_Model.Models.User", b =>
                {
                    b.HasOne("back_side_Model.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });
#pragma warning restore 612, 618
        }
    }
}
