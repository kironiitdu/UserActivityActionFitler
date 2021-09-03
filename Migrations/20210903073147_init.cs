using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserActivityLog.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    ulogo_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    login_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    login_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    page_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    http_verb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.ulogo_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLog");
        }
    }
}
