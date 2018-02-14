namespace LambdaLinq.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LambdaLinq.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LambdaLinq.Models.BookstoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LambdaLinq.Models.BookstoreDbContext";
        }

        protected override void Seed(LambdaLinq.Models.BookstoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  TODO: Add two additional books to the seed data and update the database
            //
            context.Books.AddOrUpdate(b=>b.BookID,
        new Book()
        {
            BookID = 1,
            Title = "Pride and Prejudice",
            Author = "Jane Austin",
            Price = 9.99M
        },
        new Book()
        {
            BookID = 2,
            Title = "Northanger Abbey",
            Author = "Jane Austin",
            Price = 12.95M
        },
        new Book()
        {
            BookID = 3,
            Title = "David Copperfield",
            Author = "Charles Dickens",
            Price = 15.00M
        },
        new Book()
        {
            BookID = 4,
            Title = "The Wizard of EarthSea",
            Author = "Ursula Le Guin",
            Price = 8.95M
        },
        new Book()
        {
            BookID = 5,
            Title = "The Tombs of Atuan",
            Author = "Ursula Le Guin",
            Price = 7.95M
        },
        new Book()
        {
            BookID = 6,
            Title = "Man and the Sea",
            Author = "Ernest Hemingway",
            Price = 10.20M
        },
        new Book()
        {
            BookID = 7,
            Title = "The Hidden History",
            Author = "Donna Tartt",
            Price = 11.00M
        },
        new Book()
        {
            BookID = 8,
            Title = "Crime and Punishment",
            Author = "Fyodor Dostoyevsky",
            Price = 13.55M
        },
        new Book()
        {
            BookID = 9,
            Title = "The Farthest Shore",
            Author = "Ursula Le Guin",
            Price = 9.95M
        });

        }
    }
}
