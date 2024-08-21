using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myownplatform.Migrations
{
    /// <inheritdoc />
    public partial class addingpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "passwordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "passwordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "passwordSalt",
                table: "Users");
        }
    }
}
