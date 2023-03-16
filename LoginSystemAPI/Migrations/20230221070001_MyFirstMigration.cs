using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSystemAPI.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_city",
                columns: table => new
                {
                    city_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    city_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    state_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_city__031420605E1D8FF7", x => x.city_cd);
                });

            migrationBuilder.CreateTable(
                name: "tbl_claim",
                columns: table => new
                {
                    claim_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    claim_disc = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_clai__F9CC0896EB431BF8", x => x.claim_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_country",
                columns: table => new
                {
                    country_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    country_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_coun__7E9504D90A6A2C81", x => x.country_cd);
                });

            migrationBuilder.CreateTable(
                name: "tbl_gender",
                columns: table => new
                {
                    gender_cd = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    gender_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_gend__9DF1BFC055AC3D2D", x => x.gender_cd);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_disc = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_role__760965CC6632414B", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_state",
                columns: table => new
                {
                    state_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    state_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    country_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_stat__81DDA61B744D39C8", x => x.state_cd);
                });

            migrationBuilder.CreateTable(
                name: "tbl_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_first_nam = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    student_last_nam = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    student_email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    student_mobile = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    gender_cd = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    country_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    state_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    city_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_stud__2A33069A284C6779", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    usr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usr_nam = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    usr_pwd = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    usr_mobile = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    usr_email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    usr_type = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_user__60621ABCC9050417", x => x.usr_id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__tbl_stud__820A8F3ECEC5CFB7",
                table: "tbl_student",
                column: "student_email",
                unique: true,
                filter: "[student_email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_city");

            migrationBuilder.DropTable(
                name: "tbl_claim");

            migrationBuilder.DropTable(
                name: "tbl_country");

            migrationBuilder.DropTable(
                name: "tbl_gender");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_state");

            migrationBuilder.DropTable(
                name: "tbl_student");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
