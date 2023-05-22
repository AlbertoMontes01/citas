using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace citas.Server.Migrations.Appointment
{
    public partial class two_tabless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Appoitments_AppoitmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacients_Appoitments_AppoitmentId",
                table: "Pacients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appoitments",
                table: "Appoitments");

            migrationBuilder.RenameTable(
                name: "Appoitments",
                newName: "Appointments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Appointments_AppoitmentId",
                table: "Doctors",
                column: "AppoitmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacients_Appointments_AppoitmentId",
                table: "Pacients",
                column: "AppoitmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Appointments_AppoitmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacients_Appointments_AppoitmentId",
                table: "Pacients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appoitments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appoitments",
                table: "Appoitments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Appoitments_AppoitmentId",
                table: "Doctors",
                column: "AppoitmentId",
                principalTable: "Appoitments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacients_Appoitments_AppoitmentId",
                table: "Pacients",
                column: "AppoitmentId",
                principalTable: "Appoitments",
                principalColumn: "Id");
        }
    }
}
