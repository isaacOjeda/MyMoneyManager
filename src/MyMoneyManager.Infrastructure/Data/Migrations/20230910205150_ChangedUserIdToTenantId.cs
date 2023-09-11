using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMoneyManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserIdToTenantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RecurringMovements",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Incomes",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "IncomeCategories",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Egresses",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EgressCategories",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BankAccounts",
                newName: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "RecurringMovements",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Incomes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "IncomeCategories",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Egresses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "EgressCategories",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "BankAccounts",
                newName: "UserId");
        }
    }
}
