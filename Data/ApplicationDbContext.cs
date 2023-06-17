using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_side_Model.Models;

namespace back_side_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
             
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post()
                {
                    PostID = 1,
                    Title = "ExampleTitle",
                    Description = "ExampleDescription",
                    AdvertisementID = 1,
                    UserID = 1,
                    Quota = 1,
                    PricePerPerson = 1
                });

            modelBuilder.Entity<User>().HasData(
                new User() 
                { 
                    UserID = 1, UserTypeID = 1, Name = "metinabadan", Password = "metinabadan06",
                    e_mail = "metinabadan@gmail.com", NameSurname = "Metin Abadan"}
                );

            modelBuilder.Entity<UserType>().HasData(
                new UserType()
                {
                    UserTypeID = 1,
                    UserTypeName = "Influencer"
                });
            modelBuilder.Entity<Advertisement>().HasData(
                new Advertisement()
                {
                    AdvertisementID = 1,
                });
            modelBuilder.Entity<Application>().HasData(
                new Application()
                {
                    ApplicationID = 1,
                    UserID = 1,
                    PostID = 1,
                    ShareURL = "URL"
                });
            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    CommentID = 1,
                    UserID = 1,
                    PostID = 1,
                    Description = "ExampleDescription123"

                });

        }

    }
}