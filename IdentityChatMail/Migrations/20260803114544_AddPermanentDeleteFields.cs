using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityChatMail.Migrations
{
    /// <inheritdoc />
    public partial class AddPermanentDeleteFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReceiverIsPermanentlyDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SenderIsPermanentlyDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverIsPermanentlyDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderIsPermanentlyDeleted",
                table: "Messages");
        }
    }
}
