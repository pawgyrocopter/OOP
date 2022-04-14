using Lab1.Entities;
using Lab1.Entities.Other;
using Lab1.Entities.Undo;
using Lab1.Entities.UserCategories;
using Lab1.Models;
using Microsoft.EntityFrameworkCore;
using Lab1.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab1.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Bank> Banks { get; set; }
    public DbSet<Factory> Factories { get; set; }
    public DbSet<Credit> Credits { get; set; }

    public DbSet<Plan> Plans { get; set; }

    public DbSet<Bill> Bills { get; set; }
    
    public DbSet<CreditInfo> CreditInfos { get; set; }
    public DbSet<PlanInfo> PlanInfos { get; set; }
    public DbSet<RequestMoney> RequestMonies { get; set; }
    
    public DbSet<BillCreation> BillCreations { get; set; }
    
    public DbSet<Transfer> Transfers { get; set; }
    
    public DbSet<Operator> Operators { get; set; }
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

        modelBuilder.Entity<Client>().HasMany(x => x.Bills).WithOne(c => c.Client);
        modelBuilder.Entity<Role>().HasData(new Role[]
        {
            adminRole, userRole, client, specialist, manager, oper
        });
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User() {Id = 123, RoleId = 1}
        });
        modelBuilder.Entity<Bank>().HasData(new Bank[]
        {
            new Bank()
            {
                Id = 1,
                Name = "PriorBank",
                BankId = 1,
                IsBank = true
            },
            new Bank()
            {
                Id = 2,
                Name = "MTBank",
                BankId = 2,
                IsBank = true
            },
            new Bank()
            {
                Id = 3,
                Name = "BelWeb",
                BankId = 3,
                IsBank = true
            }
        });
        modelBuilder.Entity<Factory>().HasData(new Factory[]
        {
            new Factory()
            {
                Id = 4,
                Name = "Super Compony",
                BankId = 1,
                FactoryType = "Rabotygi",
                UrlAdress = "rabotygi.com",
                UNP = "supercode",
                IsBank = false,
                // Bill = new Bill()
                // {
                //     Id = 1,
                //     Money = 100000,
                //     BankId = 1,
                //     Name = "Super Compony Bill",
                //     State = State.Active,
                //     FactoryId = 4
                // }
            },
            new Factory()
            {
                Id = 5,
                Name = "Mega Compony",
                BankId = 2,
                FactoryType = "NotRabotygi",
                UrlAdress = "notrabotygi.com",
                UNP = "megacode",
                IsBank = false,
                // Bill = new Bill()
                // {
                //     Id = 2,
                //     Money = 100000,
                //     BankId = 2,
                //     Name = "Mega Compony Bill",
                //     State = State.Active,
                //     FactoryId = 5
                // }
            },
            new Factory()
            {
                Id = 6,
                Name = "BSUIR Compony",
                BankId = 3,
                FactoryType = "students",
                UrlAdress = "students.com",
                UNP = "student.com",
                IsBank = false,
                // Bill = new Bill()
                // {
                //     Id = 3,
                //     Money = 100000,
                //     BankId = 3,
                //     Name = "BSUIR Compony Bill",
                //     State = State.Active,
                //     FactoryId = 6
                // }
                //
            },
            new Factory()
            {
                Id = 7,
                Name = "Noone Compony",
                BankId = 1,
                FactoryType = "nones",
                UrlAdress = "nones.com",
                UNP = "nonecode",
                IsBank = false,
                // Bill = new Bill()
                // {
                //     Id = 4,
                //     Money = 100000,
                //     BankId = 1,
                //     Name = "Noone Compony Bill",
                //     State = State.Active,
                //     FactoryId = 7
                // }
            },
            new Factory()
            {
                Id = 8,
                Name = "Fuck Compony",
                BankId = 2,
                FactoryType = "fucks",
                UrlAdress = "fucks.com",
                UNP = "fuckcode",
                IsBank = false,
                // Bill = new Bill()
                // {
                //     Id = 5,
                //     Money = 100000,
                //     BankId = 2,
                //     Name = "Fuck Compony Bill",
                //     State = State.Active,
                //     FactoryId = 8
                // }
            }
        });
        modelBuilder.Entity<CreditInfo>().HasData(new CreditInfo[]
        {
            new CreditInfo()
            {
                Id = 1,
                Duration = "3",
                BankId = 1,
                Procent = 10
            },
            new CreditInfo()
            {
                Id = 2,
                Duration = "6",
                BankId = 1,
                Procent = 200
            },
            new CreditInfo()
            {
                Id = 3,
                Duration = "12",
                BankId = 1,
                Procent = 50

            }, new CreditInfo()
            {
                Id = 4,
                Duration = "24",
                BankId = 1,
                Procent = 11

            },
            new CreditInfo()
            {
                Id = 5,
                Duration = ">24",
                BankId = 1,
                Procent = 12

            },new CreditInfo()
            {
                Id = 6,
                Duration = "3",
                BankId = 2,
                Procent = 13

            },
            new CreditInfo()
            {
                Id = 7,
                Duration = "6",
                BankId = 2,
                Procent = 100

            },
            new CreditInfo()
            {
                Id = 8,
                Duration = "12",
                BankId = 2,
                Procent = 1

            }, new CreditInfo()
            {
                Id = 9,
                Duration = "24",
                BankId = 2,
                Procent = 2000

            },
            new CreditInfo()
            {
                Id = 10,
                Duration = ">24",
                BankId = 2,
                Procent = 2

            },new CreditInfo()
            {
                Id = 11,
                Duration = "3",
                BankId = 3,
                Procent = 3
            },
            new CreditInfo()
            {
                Id = 12,
                Duration = "6",
                BankId = 3,
                Procent = 2

            },
            new CreditInfo()
            {
                Id = 13,
                Duration = "12",
                BankId = 3,
                Procent = 10

            }, new CreditInfo()
            {
                Id = 14,
                Duration = "24",
                BankId = 3,
                Procent = 10

            },
            new CreditInfo()
            {
                Id = 15,
                Duration = ">24",
                BankId = 3,
                Procent = 10

            }
        });
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