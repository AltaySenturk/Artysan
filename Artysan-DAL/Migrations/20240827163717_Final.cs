using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Artysan_DAL.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    IsPopular = table.Column<bool>(type: "bit", nullable: true),
                    IsFuture = table.Column<bool>(type: "bit", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 3, "/img/resim.com", "www.example.com", null },
                    { 4, "/img/resim.com", "www.example.com", null },
                    { 5, "../img/resim.com", "www.example.com", null },
                    { 6, "../img/artists/sezen-aksu.jpg", "www.example.com/sezen-aksu", "Sezen Aksu" },
                    { 7, "../img/theatre/hamlet.jpg", "www.example.com/devlet-tiyatrolari", null },
                    { 8, "../img/sports/basketball.jpg", "www.example.com/turkish-basketball-league", null },
                    { 9, "../img/directors/james-cameron.jpg", "www.example.com/james-cameron", null },
                    { 10, "../img/workshop/photoshop-icon.jpg", "www.example.com/adobe-experts", null },
                    { 11, "../img/artists/coldplay.jpg", "www.example.com/coldplay", null },
                    { 12, "../img/directors/nolan-icon.jpg", "www.example.com/christopher-nolan", null },
                    { 13, "../img/actors/macbeth-oyuncular.jpg", "www.example.com/oyuncular", null },
                    { 14, "../img/sports/superlig-logo.jpg", "www.example.com/superlig", null },
                    { 15, "../img/artists/duman.jpg", "www.example.com/duman", null },
                    { 16, "../img/directors/denis-villeneuve.jpg", "www.example.com/denis-villeneuve", null },
                    { 17, "../img/speakers/elon-musk.jpg", "www.example.com/elon-musk", null },
                    { 18, "../img/sports/anadoluefes.jpg", "www.example.com/anadolu-efes", null },
                    { 19, "../img/sports/tbl-logo.jpg", "www.example.com/tbl", null },
                    { 20, "../img/musicals/les-miserables.jpg", "www.example.com/les-miserables", null },
                    { 21, "../img/sports/superlig-logo.jpg", "www.example.com/superlig", null },
                    { 22, "../img/concerts/rockfestival.jpg", "www.example.com/rock-festival", null },
                    { 23, "../img/movies/blockbuster.jpg", "www.example.com/blockbuster-movie", null },
                    { 24, "../img/sports/milli-takim-logo.jpg", "www.example.com/milli-takim", null },
                    { 25, "../img/concerts/tarkan.jpg", "www.example.com/tarkan", null },
                    { 26, "../img/movies/iff-logo.jpg", "www.example.com/istanbul-film-festivali", null },
                    { 27, "../img/sports/champions-league-logo.jpg", "www.example.com/champions-league", null },
                    { 28, "../img/concert/muzik-festivali-logo.jpg", "www.example.com/muzik-festivali", null },
                    { 29, "../img/theater/tiyatro-festivali-logo.jpg", "www.example.com/tiyatro-festivali", null },
                    { 30, "../img/cinema/star-wars-poster.jpg", "www.example.com/star-wars", null },
                    { 31, "../img/cinema/avengers-poster.jpg", "www.example.com/avengers", null },
                    { 32, "../img/cinema/frozen-poster.jpg", "www.example.com/frozen", null }
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
                    { 10, null, "Workshop" },
                    { 11, null, "Konser" },
                    { 12, null, "Sinema" },
                    { 13, null, "Tiyatro" },
                    { 14, null, "Spor" },
                    { 15, null, "Konser" },
                    { 16, null, "Sinema" },
                    { 17, null, "Workshop" },
                    { 18, null, "Basketbol" },
                    { 19, null, "Spor" },
                    { 20, null, "Müzikal" },
                    { 21, null, "Spor" },
                    { 22, null, "Konser" },
                    { 23, null, "Sinema" },
                    { 24, null, "Spor" },
                    { 25, null, "Konser" },
                    { 26, null, "Sinema" },
                    { 27, null, "Spor" },
                    { 28, null, "Konser" },
                    { 29, null, "Tiyatro" },
                    { 30, null, "Sinema" },
                    { 31, null, "Sinema" },
                    { 32, null, "Sinema" }
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "EventUrl", "LocImageUrl", "Venue" },
                values: new object[,]
                {
                    { 1, "www.example.com", "/img/hande.jpeg", "Ankara Oran Açıkhava Sahnesi" },
                    { 2, "www.example.com", "../img/resim.jpg", "Antalya Alanya Açıkhava Tiyatrosu" },
                    { 3, "www.example.com", "../img/gs.jpg", "Rams Park Arena" },
                    { 4, "www.example.com", "/img/resim.jpg", "Paribu Istinye Park" },
                    { 5, "www.example.com", "/img/resim.jpg", "Istanbul Workshop" },
                    { 6, "www.example.com/sezen-aksu-izmir", "../img/izmir-kulturpark.jpg", "İzmir Kültürpark Açıkhava Tiyatrosu" },
                    { 7, "www.example.com/hamlet-ankara", "../img/ankara-devlet-tiyatrosu.jpg", "Ankara Devlet Tiyatrosu" },
                    { 8, "www.example.com/fenerbahce-efes", "../img/ulker-sports-arena.jpg", "Ülker Sports Arena" },
                    { 9, "www.example.com/avatar3-premiere", "../img/cinemaximum-zorlu.jpg", "Cinemaximum Zorlu Center" },
                    { 10, "www.example.com/photoshop-masterclass", "../img/atasehir-sanat-merkezi.jpg", "Ataşehir Sanat Merkezi" },
                    { 11, "www.example.com/coldplay-istanbul", "../img/volkswagen-arena.jpg", "Volkswagen Arena" },
                    { 12, "www.example.com/inception-imax-screening", "../img/cinemaximum-zorlu.jpg", "Cinemaximum Zorlu Center" },
                    { 13, "www.example.com/macbeth-2025", "../img/zorlu-psm.jpg", "Zorlu Performans Sanatları Merkezi" },
                    { 14, "www.example.com/fenerbahce-galatasaray-2025", "../img/ulker-stadyumu.jpg", "Ülker Stadyumu Fenerbahçe Şükrü Saracoğlu Spor Kompleksi" },
                    { 15, "www.example.com/duman-konseri-2025", "../img/kucukciftlik-park.jpg", "KüçükÇiftlik Park" },
                    { 16, "www.example.com/dune-part-three-premiere", "../img/kanyon-cinemaximum.jpg", "Kanyon Cinemaximum" },
                    { 17, "www.example.com/tech-summit-2025", "../img/istanbul-kongre-merkezi.jpg", "İstanbul Kongre Merkezi" },
                    { 18, "www.example.com/anadolu-efes-fenerbahce-2025", "../img/sinan-erdem-arena.jpg", "Sinan Erdem Spor Salonu" },
                    { 19, "www.example.com/basketbol-all-star-2026", "../img/turk-telekom-arena.jpg", "Rams Park Arena" },
                    { 20, "www.example.com/les-miserables-2026", "../img/zorlu-psm.jpg", "Zorlu PSM" },
                    { 21, "www.example.com/superlig-derbi-2026", "../img/vodafone-park.jpg", "Vodafone Park" },
                    { 22, "www.example.com/rock-festival-2026", "../img/kucukciftlik-park.jpg", "Küçükçiftlik Park" },
                    { 23, "www.example.com/blockbuster-premiere-2026", "../img/cinemaximum-kanyon.jpg", "Cinemaximum Kanyon" },
                    { 24, "www.example.com/milli-takim-2026", "../img/ulker-stadyumu.jpg", "Ülker Stadyumu" },
                    { 25, "www.example.com/yaz-konseri-2026", "../img/harbiye-acik-hava.jpg", "Harbiye Açık Hava Tiyatrosu" },
                    { 26, "www.example.com/ters yüz-2026", "../img/atlas-1948-sinemasi.jpg", "Ters yüz 2 " },
                    { 27, "www.example.com/champions-league-final-2026", "../img/ataturk-olimpiyat-stadyumu.jpg", "Atatürk Olimpiyat Stadyumu" },
                    { 28, "www.example.com/muzik-festivali-2026", "../img/volkswagen-arena.jpg", "Volkswagen Arena" },
                    { 29, "www.example.com/tiyatro-festivali-2026", "../img/zorlu-psm.jpg", "Zorlu PSM" },
                    { 30, "www.example.com/star-wars-premiere-2026", "../img/cinemaximum-istinyepark.jpg", "Cinemaximum İstinyePark" },
                    { 31, "www.example.com/avengers-premiere-2026", "../img/cinemaximum-kanyon.jpg", "Cinemaximum Kanyon" },
                    { 32, "www.example.com/frozen-premiere-2026", "../img/cinemaximum-citys-nisantasi.jpg", "Cinemaximum City’s Nişantaşı" }
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
                    { 10, 1000m, "Premium" },
                    { 11, 500m, "VIP" },
                    { 12, 60m, "Standart" },
                    { 13, 300m, "Ön Sıra" },
                    { 14, 200m, "Maraton" },
                    { 15, 300m, "Genel Giriş" },
                    { 16, 120m, "IMAX" },
                    { 17, 750m, "Platinum" },
                    { 18, 300m, "VIP" },
                    { 19, 500m, "VIP Tribün" },
                    { 20, 180m, "Öğrenci" },
                    { 21, 300m, "Numaralı Tribün" },
                    { 22, 250m, "Genel Giriş" },
                    { 23, 120m, "Premium" },
                    { 24, 350m, "Kapalı Tribün" },
                    { 25, 400m, "Sahne Önü" },
                    { 26, 150m, "Loca" },
                    { 27, 300m, "Açık Tribün" },
                    { 28, 500m, "VIP" },
                    { 29, 200m, "Orta Sıra" },
                    { 30, 150m, "VIP Koltuk" },
                    { 31, 100m, "Standart Koltuk" },
                    { 32, 200m, "Aile Salonu" }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "Id", "CategoryId", "Description", "EventDate", "ImageUrl", "IsFuture", "IsPopular", "LocationId", "Name", "Stock", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, "Hande Yener'in yıllar sonra tekrar döndüğü Oran sahnesinde ankara yerinde oynayacak", "21.08.2024", "/img/Concert/hande.jpeg", false, false, 1, "POP Gecesi Festivali", 500, 1 },
                    { 2, 2, "Yıllar'ın eskitemediği Efsane oyun lüküs hayat seyirciyle tekrar buluşuyor", "21.09.2024", "/img/Theatre/lukus.jpg", false, true, 2, "Lüküs Hayat", 500, 2 },
                    { 3, 3, "Galatasaray'ın ev sahibi olduğu süper lig'in 2.haftasında rakip Konyaspor ", "21.08.2024", "/img/Sport/gs.jpg", false, true, 3, "Galatasaray-Konyaspor", 500, 3 },
                    { 4, 4, "Denis Villeneuve efsane bilim kurgu romanı Dune ile seyirci karşısına çıkmaya hazırlanıyor", "10.09.2024", "/img/Cinema/dune.jpg", false, true, 4, "Dune Çöl Gezegeni", 500, 4 },
                    { 5, 5, "Heykel yapmayı Gandalf ile öğrenin", "21.08.2024", "/img/Workshop/gandalf.jpg", false, true, 5, "Gandalf Heykel Workshop", 500, 5 },
                    { 6, 1, "Sezen aksuyla harika bir müzik gecesine hazır olun", "15.12.2024", "/img/Concert/sezen.jpg", false, true, 6, "Sezen Aksu Yılbaşı Özel Konseri", 400, 6 },
                    { 7, 2, "Shakespeare'in müthiş kaleminden tiyatro sahnesine uyarlanan harika bir oyun Hamlet karşınızda", "05.01.2025", "/img/Theatre/hamlet.jpg", false, true, 7, "Hamlet", 300, 7 },
                    { 8, 3, "Fenerbahçe ülker arena da anadolu efesi ağırlıyor Šarūnas Jasikevičius'un takımı Tomislav Mijatović'in takımına karşı bu muazzam karşılaşma da kozlarını paylaşacaklar", "22.02.2025", "/img/Sport/efes.jpg", false, false, 8, "Fenerbahçe Beko - Anadolu Efes", 1000, 8 },
                    { 9, 4, "James Cameron'ın sinema için yarattığı avatar evreni 3.filmi ile devam ediyor", "10.03.2025", "/img/Cinema/avatar.jpg", false, true, 9, "Avatar 3 Galası", 200, 9 },
                    { 10, 5, "Photoshop yeteneklerinizi geliştireceğiniz harika bir eğitim", "18.04.2025", "/img/Workshop/psdw.jpg", false, true, 10, "Adobe Photoshop Masterclass", 50, 10 },
                    { 11, 1, "Coldplay'in muhteşem performansıyla unutulmaz bir gece", "22.05.2025", "/img/Concert/coldplay.jpg", false, true, 11, "Coldplay Istanbul Konseri", 1000, 11 },
                    { 12, 4, "Christopher Nolan'ın başyapıtı Inception'ın IMAX formatında özel gösterimi", "20.07.2025", "/img/Cinema/inception.jpg", true, true, 15, "Inception: IMAX Özel Gösterimi", 300, 12 },
                    { 13, 2, "Shakespeare'in Macbeth eseri, Zorlu PSM'de unutulmaz bir gösteri", "15.08.2025", "/img/Theatre/macbeth.jpg", false, true, 13, "Macbeth", 250, 13 },
                    { 14, 3, "Türk futbolunun en büyük derbisi, Fenerbahçe ile Galatasaray karşı karşıya", "10.08.2025", "/img/Sport/derby.jpg", false, true, 14, "Fenerbahçe - Galatasaray", 5000, 14 },
                    { 15, 1, "Duman grubu, en sevilen şarkılarıyla KüçükÇiftlik Park'ta", "25.09.2025", "/img/Concert/duman.jpg", false, true, 15, "Duman Konseri", 3000, 15 },
                    { 16, 4, "Denis Villeneuve'ün yönettiği Dune serisinin üçüncü filminin gösterimi", "30.10.2025", "/img/Cinema/dunelll.jpg", true, true, 16, "Dune Part Three", 400, 16 },
                    { 17, 5, "Dünya çapında teknoloji liderlerinin bir araya geldiği ve Elon Musk'ın edindiği tecrübeleri dinleyecilere aktaracağı harika bir eğitim zirvesi", "15.11.2025", "/img/Workshop/Elon.jpg", false, true, 17, "Global Tech Summit 2025", 1000, 17 },
                    { 18, 3, "Türk basketbolunun iki devi Euroleague maçında karşı karşıya geliyor", "12.11.2025", "/img/Sport/efes.jpg", false, false, 18, "Anadolu Efes - Fenerbahçe Beko Euroleague Maçı", 1000, 18 },
                    { 19, 3, "Galatasaray Kasımpaşa'yı evinde ağırlıyor", "20.01.2026", "/img/Sport/Kasımpaşa.jpg", false, true, 19, "Galatasaray - Kasımpaşa", 1500, 19 },
                    { 20, 1, "Dünyaca ünlü Les Misérables müzikali Türkçe prodüksiyonu ile Zorlu PSM'de", "14.02.2026", "/img/Concert/misera.jpg", false, true, 20, "Les Misérables Müzikali", 800, 20 },
                    { 21, 3, "Türkiye Süper Ligi'nin en büyük derbilerinden biri Beşiktaş ile Galatasaray karşı karşıya", "05.03.2026", "/img/Sport/bjk.jpg", false, true, 21, "Süper Lig Derbisi: Beşiktaş vs Galatasaray", 2000, 21 },
                    { 22, 1, "Türkiye'nin en büyük rock festivali, yerli ve yabancı sanatçıların katılımıyla Küçükçiftlik Park'ta", "18.04.2025", "/img/Concert/Metallica.jpg", false, true, 22, "Metallica Konseri", 5000, 22 },
                    { 23, 4, "Yılın en çok beklenen aksiyon filmi", "30.05.2026", "/img/Cinema/blockbuster.jpg", true, true, 23, "Blockbuster", 300, 23 },
                    { 24, 3, "Türkiye A Milli Futbol Takımı'nın Almanya ile oynayacağı önemli hazırlık maçı", "15.06.2025", "/img/Sport/Almanya.jpg", false, true, 24, "Türkiye - Almanya Milli Maç", 2500, 24 },
                    { 25, 1, "Megastar Tarkan'ın muhteşem yaz konseri, en sevilen şarkılarıyla Harbiye Açık Hava'da", "22.07.2025", "/img/Concert/tarkan.jpg", false, true, 25, "Tarkan Yaz Konseri", 3000, 25 },
                    { 26, 4, "Ters yüz filminin devam filmi izlyeciyle buluşuyor", "10.08.2026", "/img/Cinema/ters.jpg", false, true, 26, "Ters yüz 2", 200, 26 },
                    { 27, 3, "2026 UEFA Şampiyonlar Ligi final maçı", "22.07.2025", "/img/Sport/uefa.jpg", false, true, 27, "UEFA Champions League Final", 5000, 27 },
                    { 28, 1, "2026 İstanbul Müzik Festivali VIP biletleri", "12.09.2026", "/img/Concert/Demet.jpg", false, true, 28, "Demet Akalın konseri", 1500, 28 },
                    { 29, 2, "Istanbul Efedisi Zorlu PSM'de seyirci karşısına tekrardan çıkıyor", "30.10.2026", "/img/Theatre/Istanbulefe.jpg", false, false, 29, "İstanbul Efendisi", 1000, 29 },
                    { 30, 4, "Star Wars filmi Skywalker Saga'dan sonra yeni bir filme karşınızda olmaya geliyor", "10.11.2026", "/img/Cinema/starwars.jpg", true, true, 30, "Star Wars Mandalorian ve Grogu'nun maceraları ", 200, 30 },
                    { 31, 4, "Yeni Avengers filmi galasında standart koltuk", "18.11.2026", "/img/Cinema/avengers.jpg", true, true, 31, "Avengers Secret Wars", 300, 31 },
                    { 32, 4, "Frozen III filmi galasında aile salonu keyfi", "25.12.2026", "/img/Cinema/frozen.jpg", true, false, 32, "Frozen III ", 150, 32 }
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
                    { 10, 10, 10, "01.03.2025", 3000m, 30 },
                    { 11, 11, 11, "01.04.2025", 10000m, 200 },
                    { 12, 12, 12, "01.06.2025", 240m, 4 },
                    { 13, 13, 13, "01.07.2025", 900m, 30 },
                    { 14, 14, 14, "01.07.2025", 2000m, 100 },
                    { 15, 15, 15, "01.08.2025", 1800m, 60 },
                    { 16, 16, 16, "01.09.2025", 960m, 80 },
                    { 17, 17, 17, "01.10.2025", 3750m, 50 },
                    { 18, 18, 18, "15.10.2025", 600m, 2 },
                    { 19, 19, 19, "01.12.2025", 2000m, 40 },
                    { 20, 20, 20, "01.01.2026", 1080m, 60 },
                    { 21, 21, 21, "05.02.2026", 1500m, 50 },
                    { 22, 22, 22, "18.02.2026", 2000m, 80 },
                    { 23, 23, 23, "30.04.2026", 360m, 30 },
                    { 24, 24, 24, "15.05.2026", 1575m, 45 },
                    { 25, 25, 25, "22.06.2026", 2800m, 70 },
                    { 26, 26, 26, "10.07.2026", 300m, 20 },
                    { 27, 27, 27, "01.06.2026", 15000m, 50 },
                    { 28, 28, 28, "01.08.2026", 15000m, 30 },
                    { 29, 29, 29, "01.09.2026", 4000m, 20 },
                    { 30, 30, 30, "01.10.2026", 1500m, 10 },
                    { 31, 31, 31, "01.10.2026", 1500m, 15 },
                    { 32, 32, 32, "01.11.2026", 2000m, 10 }
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
                    { 10, 10, 10 },
                    { 11, 11, 11 },
                    { 12, 8, 12 },
                    { 13, 13, 13 },
                    { 14, 14, 14 },
                    { 15, 15, 15 },
                    { 16, 16, 16 },
                    { 17, 17, 17 },
                    { 18, 18, 18 },
                    { 19, 19, 19 },
                    { 20, 20, 20 },
                    { 21, 21, 21 },
                    { 22, 22, 22 },
                    { 23, 23, 23 },
                    { 24, 24, 24 },
                    { 25, 25, 25 },
                    { 26, 26, 26 },
                    { 27, 27, 27 },
                    { 28, 28, 28 },
                    { 29, 29, 29 },
                    { 30, 30, 30 },
                    { 31, 31, 31 },
                    { 32, 32, 32 }
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
                    { 10, 10, 10, 3, 1000m },
                    { 11, 11, 11, 20, 500m },
                    { 12, 12, 12, 4, 60m },
                    { 13, 13, 13, 3, 300m },
                    { 14, 14, 14, 10, 200m },
                    { 15, 15, 15, 6, 300m },
                    { 16, 16, 16, 8, 120m },
                    { 17, 17, 17, 5, 750m },
                    { 18, 18, 18, 2, 300m },
                    { 19, 19, 19, 4, 500m },
                    { 20, 20, 20, 6, 180m },
                    { 21, 21, 21, 5, 300m },
                    { 22, 22, 22, 8, 250m },
                    { 23, 23, 23, 3, 120m },
                    { 24, 24, 24, 5, 350m },
                    { 25, 25, 25, 7, 400m },
                    { 26, 26, 26, 2, 150m },
                    { 27, 27, 27, 10, 300m },
                    { 28, 28, 28, 10, 500m },
                    { 29, 29, 29, 20, 200m },
                    { 30, 30, 30, 10, 150m },
                    { 31, 31, 31, 15, 100m },
                    { 32, 32, 32, 10, 200m }
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
