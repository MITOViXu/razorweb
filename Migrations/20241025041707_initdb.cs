using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace razorweb.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            // Insert data
            // Fake data - Bogus
            //Set the randomizer seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);
            var faker = new Faker<Article>();
            faker.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            faker.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2024, 1, 1), new DateTime(2024, 7, 30)));
            faker.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));

            for (int i = 0; i < 150; i++)
            {
                Article article = faker.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new object[] {
                        article.Title,
                        article.Created,
                        article.Content
                    }
                );
            }

            // migrationBuilder.InsertData(
            //     table: "articles",
            //     columns: new[] {"Title", "Created", "Content"},
            //     values: new object[] {
            //         "Bai viet 2",
            //         new DateTime(2024,8,21),
            //         "Noi dung 2"
            //     }
            // );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
