using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artysan_DAL.Migrations
{
    /// <inheritdoc />
    public partial class Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArtImageUrl",
                value: "/img/resim.com");

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArtImageUrl",
                value: "/img/resim.com");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/img/Concert/resim.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/img/Theatre/lukus.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/img/Sport/gs.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "../img/Cinema/dune.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/img/Workshop/gandalf.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/img/Concert/sezen.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/img/Theatre/hamlet.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/img/Sport/efes.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/img/Cinema/avatar.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/img/Workshop/psdw.jpg");

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocImageUrl",
                value: "/img/hande.jpeg");

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocImageUrl",
                value: "../img/gs.jpg");

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LocImageUrl", "Venue" },
                values: new object[] { "/img/resim.jpg", "Paribu Istinye Park" });

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocImageUrl",
                value: "/img/resim.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArtImageUrl",
                value: "../img/resim.com");

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArtImageUrl",
                value: "../img/resim.com");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "../img/Concert/resim.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "../img/Theatre/resim.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "../img/Sport/resim.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "../img/Cinema/resim.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "../img/Workshop/resim.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "../img/Concert/sezen-aksu-concert.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "../img/Theatre/hamlet-poster.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "../img/Sport/fenerbahce-efes.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "../img/Cinema/avatar3-poster.jpg");

            migrationBuilder.UpdateData(
                table: "events",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "../img/Workshop/photoshop-masterclass.jpg");

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocImageUrl",
                value: "../img/resim.jpg");

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocImageUrl",
                value: "../img/resim.jpg");

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LocImageUrl", "Venue" },
                values: new object[] { "../img/resim.jpg", "PAribu Istinye Park" });

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocImageUrl",
                value: "../img/resim.jpg");
        }
    }
}
