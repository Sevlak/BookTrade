using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookTrade.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddsEntities_ChangesAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomainUserId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PublishedOn = table.Column<DateOnly>(type: "date", nullable: false),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    Categories = table.Column<int[]>(type: "integer[]", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location_ZipCode = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Location_City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksAvailableForTradeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksAvailableForTradeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BookUser_Book_BooksAvailableForTradeId",
                        column: x => x.BooksAvailableForTradeId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TraderId = table.Column<int>(type: "integer", nullable: false),
                    TradedWithId = table.Column<int>(type: "integer", nullable: false),
                    BookToTradeId = table.Column<int>(type: "integer", nullable: false),
                    TradedForId = table.Column<int>(type: "integer", nullable: false),
                    TradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_Book_BookToTradeId",
                        column: x => x.BookToTradeId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trade_Book_TradedForId",
                        column: x => x.TradedForId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trade_User_TradedWithId",
                        column: x => x.TradedWithId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Trade_User_TraderId",
                        column: x => x.TraderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Trade_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DomainUserId",
                table: "AspNetUsers",
                column: "DomainUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UserId",
                table: "BookUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_BookToTradeId",
                table: "Trade",
                column: "BookToTradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_TradedForId",
                table: "Trade",
                column: "TradedForId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_TradedWithId",
                table: "Trade",
                column: "TradedWithId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_TraderId",
                table: "Trade",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_UserId",
                table: "Trade",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_User_DomainUserId",
                table: "AspNetUsers",
                column: "DomainUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_User_DomainUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "Trade");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DomainUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DomainUserId",
                table: "AspNetUsers");
        }
    }
}
