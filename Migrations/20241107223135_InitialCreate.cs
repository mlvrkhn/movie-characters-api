using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "IsDeleted", "Picture" },
                values: new object[,]
                {
                    { 5, "Nigihayami Kohaku Nushi", "Haku", "Male", false, "https://example.com/haku.jpg" },
                    { 6, "Grandma Sophie", "Sophie Hatter", "Female", false, "https://example.com/sophie.jpg" },
                    { 7, "The Witch", "Kiki", "Female", false, "https://example.com/kiki.jpg" },
                    { 8, "None", "Taeko Okajima", "Female", false, "https://example.com/taeko.jpg" },
                    { 9, "Brunhilde", "Ponyo", "Female", false, "https://example.com/ponyo.jpg" },
                    { 10, "None", "Sosuke", "Male", false, "https://example.com/sosuke.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 5, "Hayao Miyazaki", 4, "Fantasy/Romance", 2004, "Howl's Moving Castle" },
                    { 6, "Hayao Miyazaki", 2, "Fantasy/Coming-of-age", 1989, "Kiki's Delivery Service" },
                    { 7, "Isao Takahata", 3, "Drama", 1991, "Only Yesterday" },
                    { 8, "Hayao Miyazaki", 4, "Fantasy/Family", 2008, "Ponyo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
