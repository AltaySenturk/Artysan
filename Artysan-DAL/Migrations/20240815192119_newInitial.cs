using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Artysan_DAL.Migrations
{
    /// <inheritdoc />
    public partial class newInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "Address", "CustomerName", "Email", "Password", "Phone", "Surname" },
                values: new object[,]
                {
                    { 1, "Beşiktaş-İstanbul", "neşe", "aucar@gmail.com", "123", "05340743588", "Uçar" },
                    { 2, "Beşiktaş-İstanbul", "Altay", "ucar@gmail.com", "123", "05340742386", "Uçar" },
                    { 3, "Beşiktaş-İstanbul", "Sarper", "lubnan@gmail.com", "123", "05340743234", "Uçar" },
                    { 4, "Beşiktaş-İstanbul", "james", "aabc@gmail.com", "123", "05340743586", "Uçar" },
                    { 5, "Beşiktaş-İstanbul", "Ahmet", "acar@gmail.com", "123", "05340731286", "acar" }
                });
        }
    }
}
