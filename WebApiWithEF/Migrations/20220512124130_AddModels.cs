using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authorization.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedListSong");

            migrationBuilder.DropIndex(
                name: "IX_LikedList_OwnerId",
                table: "LikedList");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Profiles");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlaylistSong",
                columns: table => new
                {
                    PlaylistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSong", x => new { x.PlaylistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_PlaylistSong_LikedList_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "LikedList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedList_OwnerId",
                table: "LikedList",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_SongsId",
                table: "PlaylistSong",
                column: "SongsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistSong");

            migrationBuilder.DropIndex(
                name: "IX_LikedList_OwnerId",
                table: "LikedList");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Profiles");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LikedListSong",
                columns: table => new
                {
                    LikedListsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedListSong", x => new { x.LikedListsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_LikedListSong_LikedList_LikedListsId",
                        column: x => x.LikedListsId,
                        principalTable: "LikedList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedListSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedList_OwnerId",
                table: "LikedList",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LikedListSong_SongsId",
                table: "LikedListSong",
                column: "SongsId");
        }
    }
}
