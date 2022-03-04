﻿using Lab1.Entities;
using Lab1.Models;
using Microsoft.EntityFrameworkCore;
using Lab1.Models;

namespace Lab1.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Bank> Banks { get; set; }
    // public DbSet<Topic> Topics { get; set; }
    //
    // public DbSet<TopicItem> TopicItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Role adminRole = new Role {Id = 1, Name = "admin"};
        Role userRole = new Role {Id = 2, Name = "user"};
        Role client = new Role {Id = 3, Name = "client"};
        Role specialist = new Role {Id = 4, Name = "specialist"};
        Role manager = new Role {Id = 5, Name = "manager"};
        Role oper = new Role {Id = 6, Name = "operator"};

        modelBuilder.Entity<Role>().HasData(new Role[] {adminRole, userRole, client, specialist, manager, oper});
        modelBuilder.Entity<User>().HasData(new User[] {new User() {Id = 123, RoleId = 1}});
        base.OnModelCreating(modelBuilder);
    }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     string adminRoleName = "admin";
    //     string userRoleName = "user";
    //
    //     string adminEmail = "admin@mail.ru";
    //     string adminPassword = "123456";
    //
    //     Role adminRole = new Role { Id = 1, Name = adminRoleName };
    //     Role userRole = new Role { Id = 2, Name = userRoleName };
    //     User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id , FirstName = "qwe",LastName = "qwe", Topics = new List<Topic>()};
    //     
    //     
    //     modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
    //     modelBuilder.Entity<User>().HasData( new User[] { adminUser });
    //     modelBuilder.Entity<Topic>().HasData( new Topic[] { new Topic(){TopicId = 1, Name = "Default topic", Info = "None", UserId = 1} });
    //     modelBuilder.Entity<TopicItem>().HasData(new TopicItem(){ItemId = 1, Name = "Default", ProfilePicture = "null",TopicId = 1});
    //     base.OnModelCreating(modelBuilder);
    // }
}