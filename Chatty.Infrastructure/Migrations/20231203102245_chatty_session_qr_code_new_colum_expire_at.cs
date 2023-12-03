using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatty.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class chatty_session_qr_code_new_colum_expire_at : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "expire_at",
                table: "chatty_session_qr_code",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "expire_at_gmt",
                table: "chatty_session_qr_code",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expire_at",
                table: "chatty_session_qr_code");

            migrationBuilder.DropColumn(
                name: "expire_at_gmt",
                table: "chatty_session_qr_code");
        }
    }
}
