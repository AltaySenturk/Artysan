using System;
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "../img/resim.com", "www.example.com", "Hande Yener" },
                    { 2, "../img/resim.com", "www.example.com", null },
                    { 3, "../img/resim.com", "www.example.com", null },
                    { 4, "../img/resim.com", "www.example.com", null },
                    { 5, "../img/resim.com", "www.example.com", null },
                    { 6, "../img/artists/sezen-aksu.jpg", "www.example.com/sezen-aksu", "Sezen Aksu" },
                    { 7, "../img/theatre/hamlet.jpg", "www.example.com/devlet-tiyatrolari", null },
                    { 8, "../img/sports/basketball.jpg", "www.example.com/turkish-basketball-league", null },
                    { 9, "../img/directors/james-cameron.jpg", "www.example.com/james-cameron", null },
                    { 10, "../img/workshop/photoshop-icon.jpg", "www.example.com/adobe-experts", null }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "CatDescription", "CatName" },
                values: new object[,]
                {
                    { 1, null, "Konser" },
                    { 2, "Tiyatro oyunu", "Tiyatro" },
                    { 3, "Futbol Maçı", "Spor" },
                    { 4, null, "Sinema" },
                    { 5, null, "Workshop" },
                    { 6, null, "Konser" },
                    { 7, "Klasik tiyatro oyunu", "Tiyatro" },
                    { 8, "Basketbol Maçı", "Spor" },
                    { 9, null, "Sinema" },
                    { 10, null, "Workshop" }
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "EventUrl", "LocImageUrl", "Venue" },
                values: new object[,]
                {
                    { 1, "www.example.com", "../img/resim.jpg", "Ankara Oran Açıkhava Sahnesi" },
                    { 2, "www.example.com", "../img/resim.jpg", "Antalya Alanya Açıkhava Tiyatrosu" },
                    { 3, "www.example.com", "../img/resim.jpg", "Rams Park Arena" },
                    { 4, "www.example.com", "../img/resim.jpg", "PAribu Istinye Park" },
                    { 5, "www.example.com", "../img/resim.jpg", "Istanbul Workshop" },
                    { 6, "www.example.com/sezen-aksu-izmir", "../img/izmir-kulturpark.jpg", "İzmir Kültürpark Açıkhava Tiyatrosu" },
                    { 7, "www.example.com/hamlet-ankara", "../img/ankara-devlet-tiyatrosu.jpg", "Ankara Devlet Tiyatrosu" },
                    { 8, "www.example.com/fenerbahce-efes", "../img/ulker-sports-arena.jpg", "Ülker Sports Arena" },
                    { 9, "www.example.com/avatar3-premiere", "../img/cinemaximum-zorlu.jpg", "Cinemaximum Zorlu Center" },
                    { 10, "www.example.com/photoshop-masterclass", "../img/atasehir-sanat-merkezi.jpg", "Ataşehir Sanat Merkezi" }
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
                    { 5, 500m, "Standart" },
                    { 6, 750m, "VIP" },
                    { 7, 200m, "Öğrenci" },
                    { 8, 300m, "Tribün" },
                    { 9, 150m, "Gold Class" },
                    { 10, 1000m, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "Id", "CategoryId", "EventDate", "ImageUrl", "LocationId", "Name", "Stock", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, "21.08.2024", "../img/Concert/resim.jpg", 1, "POP Gecesi Festivali", 500, null },
                    { 2, 2, "21.09.2024", "../img/Theatre/resim.jpg", 2, "Lüküs Hayat", 500, null },
                    { 3, 3, "21.08.2024", "../img/Sport/resim.jpg", 3, "Galatasaray-Konyaspor", 500, null },
                    { 4, 4, "10.09.2024", "../img/Cinema/resim.jpg", 4, "Dune Çöl Gezegeni", 500, null },
                    { 5, 5, "21.08.2024", "../img/Workshop/resim.jpg", 5, "Gandalf Heykel Workshop", 500, null },
                    { 6, 1, "15.12.2024", "../img/Concert/sezen-aksu-concert.jpg", 6, "Sezen Aksu Yılbaşı Özel Konseri", 400, null },
                    { 7, 2, "05.01.2025", "../img/Theatre/hamlet-poster.jpg", 7, "Hamlet", 300, null },
                    { 8, 3, "22.02.2025", "../img/Sport/fenerbahce-efes.jpg", 8, "Fenerbahçe Beko - Anadolu Efes", 1000, null },
                    { 9, 4, "10.03.2025", "../img/Cinema/avatar3-poster.jpg", 9, "Avatar 3 Galası", 200, null },
                    { 10, 5, "18.04.2025", "../img/Workshop/photoshop-masterclass.jpg", 10, "Adobe Photoshop Masterclass", 50, null }
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
                    { 5, 5, 5, "09.11.2024", 1000m, 300 },
                    { 6, 6, 6, "01.10.2024", 1500m, 250 },
                    { 7, 7, 7, "15.11.2024", 600m, 150 },
                    { 8, 8, 8, "10.01.2025", 1500m, 500 },
                    { 9, 9, 9, "01.02.2025", 1500m, 100 },
                    { 10, 10, 10, "01.03.2025", 3000m, 30 }
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
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
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
                    { 5, 5, 5, 2, 400m },
                    { 6, 6, 6, 2, 750m },
                    { 7, 7, 7, 3, 200m },
                    { 8, 8, 8, 5, 300m },
                    { 9, 9, 9, 10, 150m },
                    { 10, 10, 10, 3, 1000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "eventArtists");

            migrationBuilder.DropTable(
                name: "EventSaleDetail");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
