using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Artysan_DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_events_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_events_tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "eventArtists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventArtists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventArtists_artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventArtists_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSale_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventSaleDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EventSaleId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSaleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSaleDetail_EventSale_EventSaleId",
                        column: x => x.EventSaleId,
                        principalTable: "EventSale",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventSaleDetail_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "Id", "ArtImageUrl", "ArtistLink", "ArtistName" },
                values: new object[,]
                {
                    { 1, "../img/resim.com", "www.example.com", "Hande" },
                    { 2, "../img/resim.com", "www.example.com", "Volkan Konak" },
                    { 3, "../img/resim.com", "www.example.com", "The White Buffalo" },
                    { 4, "../img/resim.com", "www.example.com", "maNga" },
                    { 5, "../img/resim.com", "www.example.com", "İbrahim Tatlıses" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "CatDescription", "CatName" },
                values: new object[,]
                {
                    { 1, null, "Konser" },
                    { 2, "Müzikal gösteri", "Konser" },
                    { 3, "Müzikal gösteri", "Konser" },
                    { 4, null, "Konser" },
                    { 5, null, "Konser" }
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

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "EventUrl", "LocImageUrl", "Venue" },
                values: new object[,]
                {
                    { 1, "www.example.com", "../img/resim.jpg", "Ankara Oran Açıkhava Sahnesi" },
                    { 2, "www.example.com", "../img/resim.jpg", "Antalya Alanya Açıkhava Tiyatrosu" },
                    { 3, "www.example.com", "../img/resim.jpg", "İstanbul KüçükÇiftlik Park" },
                    { 4, "www.example.com", "../img/resim.jpg", "Ankara CSO ADA" },
                    { 5, "www.example.com", "../img/resim.jpg", "Gaziantep Gaün Açıkhava Sahnesi" }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "Price", "TicketName" },
                values: new object[,]
                {
                    { 1, 500m, "Standart" },
                    { 2, 500m, "Standart" },
                    { 3, 500m, "Standart" },
                    { 4, 500m, "Standart" },
                    { 5, 500m, "Standart" }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "Id", "CategoryId", "EventDate", "ImageUrl", "LocationId", "Name", "Stock", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, "21.08.2024", "../img/resim.jpg", 1, "Rock Festivali", 500, null },
                    { 2, 2, "21.08.2024", "../img/resim.jpg", 2, "Rock Festivali", 500, null },
                    { 3, 3, "21.08.2024", "../img/resim.jpg", 3, "Rock Festivali", 500, null },
                    { 4, 4, "21.08.2024", "../img/resim.jpg", 4, "Rock Festivali", 500, null },
                    { 5, 5, "21.08.2024", "../img/resim.jpg", 5, "Rock Festivali", 500, null }
                });

            migrationBuilder.InsertData(
                table: "EventSale",
                columns: new[] { "Id", "CustomerId", "EventId", "SalDate", "TotalPrice", "TotalQuantity" },
                values: new object[,]
                {
                    { 1, 2, 1, "09.11.2024", 1000m, 300 },
                    { 2, 2, 2, "09.11.2024", 1000m, 300 },
                    { 3, 3, 3, "09.11.2024", 1000m, 300 },
                    { 4, 4, 4, "09.11.2024", 1000m, 300 },
                    { 5, 5, 5, "09.11.2024", 1000m, 300 }
                });

            migrationBuilder.InsertData(
                table: "eventArtists",
                columns: new[] { "Id", "ArtistId", "EventId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "EventSaleDetail",
                columns: new[] { "Id", "EventId", "EventSaleId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 400m },
                    { 2, 2, 2, 2, 400m },
                    { 3, 3, 3, 2, 400m },
                    { 4, 4, 4, 2, 400m },
                    { 5, 5, 5, 2, 400m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventArtists_ArtistId",
                table: "eventArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_eventArtists_EventId",
                table: "eventArtists",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_events_CategoryId",
                table: "events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_events_LocationId",
                table: "events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_events_TicketId",
                table: "events",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSale_EventId",
                table: "EventSale",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSaleDetail_EventId",
                table: "EventSaleDetail",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSaleDetail_EventSaleId",
                table: "EventSaleDetail",
                column: "EventSaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "eventArtists");

            migrationBuilder.DropTable(
                name: "EventSaleDetail");

            migrationBuilder.DropTable(
                name: "artists");

            migrationBuilder.DropTable(
                name: "EventSale");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "tickets");
        }
    }
}
