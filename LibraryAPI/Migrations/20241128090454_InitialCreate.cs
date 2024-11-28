using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    YearPublished = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, "Лев Толстой", "Роман", "Война и мир", 1869 },
                    { 2, "Фёдор Достоевский", "Роман", "Преступление и наказание", 1866 },
                    { 3, "Михаил Булгаков", "Роман", "Мастер и Маргарита", 1940 },
                    { 4, "Александр Пушкин", "Поэма", "Евгений Онегин", 1833 },
                    { 5, "Иван Тургенев", "Роман", "Отцы и дети", 1862 },
                    { 6, "Лев Толстой", "Роман", "Анна Каренина", 1877 },
                    { 7, "Михаил Шолохов", "Роман", "Тихий Дон", 1940 },
                    { 8, "Борис Пастернак", "Роман", "Доктор Живаго", 1957 },
                    { 9, "Михаил Лермонтов", "Роман", "Герой нашего времени", 1840 },
                    { 10, "Андрей Платонов", "Роман", "Чевенгур", 1929 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
