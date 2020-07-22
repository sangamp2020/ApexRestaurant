using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApexRestaurant.Mvc.Data.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealDishViewModel",
                columns: table => new
                {
                    MealDishesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MealId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDishViewModel", x => x.MealDishesId);
                });

            migrationBuilder.CreateTable(
                name: "MealViewModel",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Date_of_Meal = table.Column<DateTime>(nullable: false),
                    Cost_of_Meal = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealViewModel", x => x.MealId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemViewModel",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuId = table.Column<int>(nullable: false),
                    Menu_Items_Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemViewModel", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "MenuViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Menu_Name = table.Column<string>(nullable: true),
                    Available_Date_From = table.Column<DateTime>(nullable: false),
                    Available_Date_To = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffRoleViewModel",
                columns: table => new
                {
                    Staff_Roles_Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Staff_Roles_Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRoleViewModel", x => x.Staff_Roles_Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Staff_Role_Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneRes = table.Column<string>(nullable: true),
                    PhoneMob = table.Column<string>(nullable: true),
                    EnrollDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealDishViewModel");

            migrationBuilder.DropTable(
                name: "MealViewModel");

            migrationBuilder.DropTable(
                name: "MenuItemViewModel");

            migrationBuilder.DropTable(
                name: "MenuViewModel");

            migrationBuilder.DropTable(
                name: "StaffRoleViewModel");

            migrationBuilder.DropTable(
                name: "StaffViewModel");
        }
    }
}
