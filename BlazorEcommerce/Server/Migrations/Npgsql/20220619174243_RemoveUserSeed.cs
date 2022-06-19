﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations.NpgSql
{
    public partial class RemoveUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reviews",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ChatMessages",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ChatMessages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AcceptsMessages", "DateCreated", "Email", "Name", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2022, 6, 19, 18, 34, 41, 193, DateTimeKind.Local).AddTicks(7860), "jennychris2002@yahoo.co.uk", "Jenny", new byte[] { 48, 120, 66, 68, 48, 55, 66, 70, 68, 56, 50, 70, 48, 69, 56, 67, 50, 53, 54, 70, 68, 65, 52, 66, 54, 51, 67, 68, 69, 70, 66, 55, 52, 55, 65, 68, 48, 51, 70, 54, 55, 53, 48, 69, 56, 57, 68, 70, 48, 53, 51, 68, 55, 48, 52, 70, 67, 69, 57, 67, 48, 68, 48, 50, 50, 55, 51, 48, 54, 51, 57, 57, 55, 52, 67, 69, 66, 66, 66, 67, 69, 70, 65, 48, 50, 54, 51, 55, 56, 48, 55, 50, 52, 56, 52, 67, 66, 57, 65, 48, 69, 66, 52, 49, 67, 65, 68, 49, 53, 69, 56, 69, 54, 67, 65, 56, 49, 54, 48, 69, 57, 53, 68, 57, 53, 69, 52, 69, 54, 68 }, new byte[] { 48, 120, 49, 48, 53, 52, 48, 56, 57, 69, 54, 68, 65, 55, 50, 70, 67, 53, 68, 49, 67, 49, 52, 66, 70, 57, 49, 52, 70, 48, 65, 68, 56, 51, 50, 66, 57, 65, 52, 69, 53, 52, 65, 66, 48, 48, 56, 55, 49, 50, 56, 50, 55, 57, 66, 53, 57, 66, 53, 69, 48, 67, 54, 67, 48, 50, 54, 55, 69, 66, 48, 55, 56, 70, 65, 66, 67, 70, 66, 49, 49, 49, 54, 57, 53, 56, 70, 53, 53, 55, 56, 57, 68, 50, 50, 69, 54, 56, 70, 70, 65, 57, 50, 53, 69, 67, 55, 57, 48, 53, 65, 54, 57, 49, 50, 53, 65, 69, 55, 69, 54, 69, 57, 51, 69, 65, 67, 55, 50, 54, 50, 70, 55, 53, 53, 51, 51, 51, 53, 52, 50, 51, 54, 68, 53, 54, 70, 66, 68, 55, 53, 48, 51, 50, 70, 70, 49, 68, 49, 53, 50, 50, 69, 66, 56, 49, 50, 66, 65, 49, 54, 65, 54, 66, 54, 67, 70, 55, 53, 51, 48, 51, 48, 57, 67, 48, 66, 49, 67, 53, 51, 49, 50, 53, 55, 70, 48, 48, 57, 54, 48, 51, 54, 57, 67, 66, 49, 66, 48, 56, 54, 55, 51, 57, 70, 50, 53, 52, 69, 49, 56, 48, 54, 50, 65, 53, 54, 68, 49, 53, 57, 65, 52, 57, 52, 67, 49, 67, 51, 51, 54, 52, 55, 70, 54, 69, 65, 52, 49, 53, 54, 56, 56, 52, 67, 54, 65, 67 }, "Customer" },
                    { 2, true, new DateTime(2022, 6, 19, 18, 34, 41, 193, DateTimeKind.Local).AddTicks(7890), "chukwuemeka.ihenacho@stu.cu.edu.ng", "Chukwuemeka", new byte[] { 48, 120, 69, 57, 67, 49, 65, 48, 52, 69, 68, 49, 65, 50, 50, 67, 54, 48, 66, 50, 52, 65, 56, 66, 55, 57, 68, 55, 52, 68, 49, 50, 55, 70, 65, 52, 67, 51, 49, 70, 69, 67, 55, 50, 70, 66, 54, 49, 67, 55, 51, 53, 51, 66, 68, 48, 49, 65, 57, 51, 50, 51, 56, 68, 48, 69, 50, 56, 65, 68, 57, 56, 65, 52, 56, 56, 50, 55, 54, 66, 55, 69, 50, 51, 67, 56, 66, 68, 65, 51, 54, 70, 51, 55, 50, 70, 55, 67, 56, 55, 52, 54, 54, 53, 50, 48, 52, 66, 49, 66, 65, 48, 70, 55, 51, 55, 55, 54, 49, 68, 48, 50, 70, 68, 57, 70, 57, 57, 54, 70 }, new byte[] { 48, 120, 69, 70, 51, 70, 52, 49, 65, 55, 69, 56, 53, 51, 54, 69, 52, 67, 53, 49, 50, 57, 54, 51, 55, 57, 49, 57, 49, 68, 50, 65, 53, 49, 51, 51, 52, 53, 56, 52, 70, 49, 70, 48, 65, 49, 66, 57, 49, 49, 50, 49, 56, 51, 52, 49, 49, 49, 70, 51, 68, 54, 65, 70, 66, 54, 55, 50, 65, 55, 67, 56, 56, 68, 66, 54, 68, 65, 54, 68, 48, 66, 70, 53, 51, 53, 70, 67, 57, 70, 66, 68, 57, 66, 57, 67, 66, 56, 57, 48, 50, 48, 57, 70, 49, 67, 54, 66, 53, 52, 50, 54, 68, 55, 52, 54, 49, 70, 65, 69, 69, 67, 48, 53, 54, 52, 70, 53, 68, 56, 55, 70, 67, 48, 51, 49, 57, 55, 70, 51, 50, 55, 48, 65, 66, 53, 55, 70, 54, 56, 52, 50, 55, 53, 56, 53, 53, 65, 48, 65, 67, 48, 52, 53, 51, 49, 68, 70, 52, 49, 55, 52, 67, 68, 69, 67, 54, 56, 66, 57, 66, 67, 68, 48, 55, 68, 48, 57, 69, 69, 54, 54, 65, 51, 67, 67, 56, 48, 49, 70, 55, 52, 48, 55, 67, 56, 48, 53, 49, 54, 49, 68, 50, 69, 51, 55, 50, 50, 48, 65, 55, 53, 50, 70, 65, 66, 51, 52, 51, 56, 53, 50, 52, 51, 66, 48, 53, 69, 65, 52, 56, 48, 56, 49, 48, 67, 65, 55, 48, 49, 54, 51, 70, 54, 50, 70, 52, 56 }, "Customer" },
                    { 3, true, new DateTime(2022, 6, 19, 18, 34, 41, 193, DateTimeKind.Local).AddTicks(7904), "admin@gmail.com", "Admin", new byte[] { 48, 120, 57, 52, 52, 48, 54, 55, 51, 50, 66, 70, 56, 49, 50, 51, 66, 52, 49, 56, 48, 67, 65, 69, 52, 67, 54, 69, 68, 49, 65, 68, 50, 56, 55, 56, 57, 53, 67, 55, 70, 57, 70, 53, 57, 66, 54, 50, 49, 54, 56, 48, 68, 57, 67, 51, 50, 52, 56, 70, 52, 52, 50, 66, 66, 51, 52, 65, 48, 66, 65, 56, 52, 53, 67, 53, 65, 50, 57, 48, 53, 51, 66, 54, 53, 57, 70, 65, 50, 67, 50, 70, 51, 67, 65, 69, 66, 53, 49, 57, 65, 55, 70, 51, 69, 54, 68, 56, 67, 70, 49, 67, 66, 69, 49, 52, 49, 65, 49, 50, 70, 53, 66, 56, 65, 51, 55, 56, 66, 53 }, new byte[] { 48, 120, 67, 48, 51, 57, 69, 48, 67, 53, 57, 55, 67, 50, 54, 55, 52, 67, 57, 53, 56, 51, 52, 67, 69, 49, 49, 53, 69, 49, 57, 49, 66, 56, 49, 67, 65, 69, 69, 57, 67, 70, 67, 51, 53, 52, 57, 68, 50, 53, 65, 56, 50, 55, 67, 65, 56, 52, 54, 54, 53, 49, 51, 56, 53, 70, 54, 49, 53, 52, 65, 54, 50, 65, 49, 55, 66, 52, 51, 56, 67, 51, 65, 53, 67, 69, 49, 50, 70, 51, 53, 50, 67, 52, 56, 57, 50, 50, 57, 54, 65, 68, 66, 48, 67, 51, 48, 53, 52, 50, 48, 54, 70, 67, 51, 65, 48, 69, 67, 69, 53, 51, 66, 68, 70, 52, 69, 55, 56, 49, 65, 49, 52, 48, 52, 55, 65, 70, 51, 56, 54, 70, 68, 66, 57, 53, 56, 56, 66, 70, 65, 66, 56, 55, 65, 69, 53, 56, 53, 65, 70, 50, 49, 67, 65, 70, 57, 51, 50, 57, 51, 50, 49, 49, 57, 53, 68, 55, 53, 54, 52, 52, 68, 49, 57, 54, 67, 54, 70, 67, 49, 65, 51, 52, 56, 67, 68, 48, 65, 50, 70, 67, 54, 48, 51, 55, 51, 50, 70, 52, 65, 69, 53, 65, 65, 57, 49, 55, 57, 52, 54, 53, 53, 52, 50, 68, 55, 49, 68, 55, 53, 57, 69, 52, 56, 48, 67, 54, 55, 55, 53, 51, 55, 67, 69, 54, 55, 67, 67, 67, 54, 48, 52, 67, 51, 70, 53, 68 }, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "Books", "Clothing", "Default", "Movies", "Sports", "UserId", "VideoGames" },
                values: new object[,]
                {
                    { 1, true, false, false, true, false, 1, true },
                    { 2, false, false, false, true, true, 2, true },
                    { 3, true, true, false, false, true, 3, false }
                });
        }
    }
}
