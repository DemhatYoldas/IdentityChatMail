using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityChatMail.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageDraftField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Messages");
        }
    }
}
