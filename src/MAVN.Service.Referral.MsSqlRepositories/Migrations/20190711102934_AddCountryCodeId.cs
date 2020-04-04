using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.Referral.MsSqlRepositories.Migrations
{
    public partial class AddCountryCodeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone_country_code",
                schema: "referral",
                table: "referral_lead");

            migrationBuilder.DropColumn(
                name: "phone_country_name",
                schema: "referral",
                table: "referral_lead");

            migrationBuilder.AddColumn<int>(
                name: "phone_country_code_id",
                schema: "referral",
                table: "referral_lead",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone_country_code_id",
                schema: "referral",
                table: "referral_lead");

            migrationBuilder.AddColumn<string>(
                name: "phone_country_code",
                schema: "referral",
                table: "referral_lead",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone_country_name",
                schema: "referral",
                table: "referral_lead",
                type: "varchar(90)",
                nullable: true);
        }
    }
}
