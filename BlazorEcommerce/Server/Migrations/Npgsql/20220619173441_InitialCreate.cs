﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorEcommerce.Server.Migrations.NpgSql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.ProductId, x.ProductTypeId });
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    AcceptsMessages = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Featured = table.Column<bool>(type: "boolean", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromUserId = table.Column<int>(type: "integer", nullable: false),
                    ToUserId = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Books = table.Column<bool>(type: "boolean", nullable: false),
                    Movies = table.Column<bool>(type: "boolean", nullable: false),
                    VideoGames = table.Column<bool>(type: "boolean", nullable: false),
                    Sports = table.Column<bool>(type: "boolean", nullable: false),
                    Clothing = table.Column<bool>(type: "boolean", nullable: false),
                    Default = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MadeByUserId = table.Column<int>(type: "integer", nullable: false),
                    OnProductId = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_OnProductId",
                        column: x => x.OnProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_MadeByUserId",
                        column: x => x.MadeByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewLikes",
                columns: table => new
                {
                    LikedByUserId = table.Column<int>(type: "integer", nullable: false),
                    LikedReviewId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewLikes", x => new { x.LikedByUserId, x.LikedReviewId });
                    table.ForeignKey(
                        name: "FK_ReviewLikes_Reviews_LikedReviewId",
                        column: x => x.LikedReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewLikes_Users_LikedByUserId",
                        column: x => x.LikedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Deleted", "Name", "Url", "Visible" },
                values: new object[,]
                {
                    { 1, false, "Books", "books", true },
                    { 2, false, "Movies", "movies", true },
                    { 3, false, "Video Games", "video-games", true },
                    { 4, false, "Sports", "sports", true },
                    { 5, false, "Clothing", "clothing", true }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" },
                    { 5, "Stream" },
                    { 6, "Blu-ray" },
                    { 7, "VHS" },
                    { 8, "PC" },
                    { 9, "PlayStation" },
                    { 10, "Xbox" }
                });

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
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Description", "Featured", "ImageUrl", "Title", "Visible" },
                values: new object[,]
                {
                    { 1, 1, false, "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.", true, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", true },
                    { 2, 1, false, "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]", false, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", true },
                    { 3, 1, false, "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.", false, "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg", "Nineteen Eighty-Four", true },
                    { 4, 2, false, "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", false, "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", true },
                    { 5, 2, false, "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", true, "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", true },
                    { 6, 2, false, "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", false, "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", true },
                    { 7, 3, false, "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", false, "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", true },
                    { 8, 3, false, "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", false, "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", true },
                    { 9, 3, false, "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", true, "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", true },
                    { 10, 3, false, "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", false, "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", true },
                    { 11, 3, false, "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", false, "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", true },
                    { 12, 4, false, "The Adidas Telstar 18 was the official match ball of the 2018 FIFA World Cup, which was held in the Russian Federation. It was designed by the company Adidas, a FIFA Partner and FIFA World Cup official match ball supplier since 1970, and based on the concept of the first Adidas's World Cup match ball.", false, "https://images.unsplash.com/photo-1511886929837-354d827aae26?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=464&q=80", "Adidas Telstar 18", true },
                    { 13, 4, false, "Pure and simply Liverpudlian red. Show that your support means more than any other club with this Liverpool home Stadium shirt.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/06/9.jpg", "Liverpool FC 21/22 Home Kit", true },
                    { 14, 5, false, "Run with it. Step into these adidas U_Path Run Shoes and take your style game to the finish line. With a sleek feel and futuristic look, the mesh upper has a bungee heel overlay that delivers stretchy support. Move in comfort all day with the EVA midsole.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/04/28-1.jpg", "Adidas U_Path Run Shoes – Black", true },
                    { 15, 5, false, "The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology. The result is better stability for long runs.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/05/38-1.jpg", "Nike Winflo 8 Running Sneaker", true },
                    { 16, 5, false, "Strap up in these adidas running shoes and you’re set for a jog in the park followed by coffee with friends. With a mesh upper for outstanding breathability, they’re meant to deliver comfort all day long. A durable rubber outsole gives you a solid foundation no matter how busy your schedule.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_800,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/04/20.webp", "Adidas Run Falcon 2.0 Shoes", true },
                    { 17, 4, false, "The Nike Hypervenom is a football boot manufactured by Nike. This type of boot is said to be for traction, power, and agility, designed for deceptive players. Therefore, it is endorsed/worn by players, notably forwards, such as Robert Lewandowski, Harry Kane, Edinson Cavani, Gonzalo Higuaín, Mauro Icardi and Thiago. In 2017, 18-year-old prodigy Kylian Mbappé was given his own personalised boots, the Nike Hypervenom 3.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/HypervenomX_Finale_Turf.jpg/250px-HypervenomX_Finale_Turf.jpg", "Nike Hypervenom", true }
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

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "Deleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 1, 2, false, 19.99m, 9.99m, true },
                    { 1, 3, false, 0m, 7.99m, true },
                    { 1, 4, false, 29.99m, 19.99m, true },
                    { 2, 2, false, 14.99m, 7.99m, true },
                    { 3, 2, false, 0m, 6.99m, true },
                    { 4, 5, false, 0m, 3.99m, true },
                    { 4, 6, false, 0m, 9.99m, true },
                    { 4, 7, false, 0m, 19.99m, true },
                    { 5, 5, false, 0m, 3.99m, true },
                    { 6, 5, false, 0m, 2.99m, true },
                    { 7, 8, false, 29.99m, 19.99m, true },
                    { 7, 9, false, 0m, 69.99m, true },
                    { 7, 10, false, 59.99m, 49.99m, true },
                    { 8, 8, false, 24.99m, 9.99m, true },
                    { 9, 8, false, 0m, 14.99m, true },
                    { 10, 1, false, 299m, 159.99m, true },
                    { 11, 1, false, 399m, 79.99m, true },
                    { 12, 1, false, 59.99m, 59.99m, true },
                    { 13, 1, false, 29.99m, 29.99m, true },
                    { 14, 1, false, 132.99m, 132.99m, true },
                    { 15, 1, false, 109.99m, 109.99m, true },
                    { 16, 1, false, 90.00m, 90.00m, true },
                    { 17, 1, false, 229.99m, 229.99m, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_FromUserId",
                table: "ChatMessages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ToUserId",
                table: "ChatMessages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductTypeId",
                table: "OrderItems",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLikes_LikedReviewId",
                table: "ReviewLikes",
                column: "LikedReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MadeByUserId",
                table: "Reviews",
                column: "MadeByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OnProductId",
                table: "Reviews",
                column: "OnProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ReviewLikes");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
