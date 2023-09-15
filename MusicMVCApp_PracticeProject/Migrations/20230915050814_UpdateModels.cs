using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicMVCApp_PracticeProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Artist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_SongId",
                table: "Artist",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Song_SongId",
                table: "Artist",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Song_SongId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_SongId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Artist");
        }
    }
}
