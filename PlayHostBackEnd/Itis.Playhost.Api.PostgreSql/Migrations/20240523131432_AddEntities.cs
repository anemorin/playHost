using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itis.Playhost.Api.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Image = table.Column<string>(type: "text", nullable: false, comment: "Url картинки"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Url картинки"),
                    Price = table.Column<int>(type: "integer", nullable: false, comment: "Url картинки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.Id);
                },
                comment: "Игры");

            migrationBuilder.CreateTable(
                name: "news",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Text = table.Column<string>(type: "text", nullable: false, comment: "Текст"),
                    Title = table.Column<string>(type: "text", nullable: false, comment: "Заголовок"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()", comment: "Время создания")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.Id);
                },
                comment: "Новости");

            migrationBuilder.CreateTable(
                name: "reviews",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Rate = table.Column<int>(type: "integer", nullable: false, comment: "Оценка от 1 до 5"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()", comment: "Время создания"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Пользователь")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Обзоры");

            migrationBuilder.CreateTable(
                name: "servers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Название"),
                    Ram = table.Column<int>(type: "integer", nullable: false, comment: "Оперативная память"),
                    MaxUsers = table.Column<int>(type: "integer", nullable: false, comment: "Максимальное количество пользователей"),
                    Price = table.Column<int>(type: "integer", nullable: false, comment: "Цена")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servers", x => x.Id);
                },
                comment: "Сервера");

            migrationBuilder.CreateTable(
                name: "subscriptions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Price = table.Column<int>(type: "integer", nullable: false, comment: "Цена"),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата начала"),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата окончания"),
                    ServerId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Сервер"),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Игра"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Пользователь")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subscriptions_games_GameId",
                        column: x => x.GameId,
                        principalSchema: "public",
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subscriptions_servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "public",
                        principalTable: "servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subscriptions_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Подписки");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                schema: "public",
                table: "reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_GameId",
                schema: "public",
                table: "subscriptions",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_ServerId",
                schema: "public",
                table: "subscriptions",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_UserId",
                schema: "public",
                table: "subscriptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reviews",
                schema: "public");

            migrationBuilder.DropTable(
                name: "subscriptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "games",
                schema: "public");

            migrationBuilder.DropTable(
                name: "servers",
                schema: "public");
        }
    }
}
