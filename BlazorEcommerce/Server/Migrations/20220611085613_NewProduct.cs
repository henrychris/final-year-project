using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class NewProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Deleted", "Name", "Url", "Visible" },
                values: new object[] { 4, false, "Sports", "sports", true });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Deleted", "Name", "Url", "Visible" },
                values: new object[] { 5, false, "Clothing", "clothing", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Description", "Featured", "ImageUrl", "Title", "Visible" },
                values: new object[,]
                {
                    { 12, 4, false, "The Adidas Telstar 18 was the official match ball of the 2018 FIFA World Cup, which was held in the Russian Federation. It was designed by the company Adidas, a FIFA Partner and FIFA World Cup official match ball supplier since 1970, and based on the concept of the first Adidas's World Cup match ball.", false, "https://images.unsplash.com/photo-1511886929837-354d827aae26?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=464&q=80", "Adidas Telstar 18", true },
                    { 13, 4, false, "Pure and simply Liverpudlian red. Show that your support means more than any other club with this Liverpool home Stadium shirt.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/06/9.jpg", "Liverpool FC 21/22 Home Kit", true },
                    { 14, 5, false, "Run with it. Step into these adidas U_Path Run Shoes and take your style game to the finish line. With a sleek feel and futuristic look, the mesh upper has a bungee heel overlay that delivers stretchy support. Move in comfort all day with the EVA midsole.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/04/28-1.jpg", "Adidas U_Path Run Shoes – Black", true },
                    { 15, 5, false, "The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology. The result is better stability for long runs.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/05/38-1.jpg", "Nike Winflo 8 Running Sneaker", true },
                    { 16, 5, false, "Strap up in these adidas running shoes and you’re set for a jog in the park followed by coffee with friends. With a mesh upper for outstanding breathability, they’re meant to deliver comfort all day long. A durable rubber outsole gives you a solid foundation no matter how busy your schedule.", false, "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_800,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/04/20.webp", "Adidas Run Falcon 2.0 Shoes", true },
                    { 17, 4, false, "The Nike Hypervenom is a football boot manufactured by Nike. This type of boot is said to be for traction, power, and agility, designed for deceptive players. Therefore, it is endorsed/worn by players, notably forwards, such as Robert Lewandowski, Harry Kane, Edinson Cavani, Gonzalo Higuaín, Mauro Icardi and Thiago. In 2017, 18-year-old prodigy Kylian Mbappé was given his own personalised boots, Nike Hypervenom 3.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/HypervenomX_Finale_Turf.jpg/250px-HypervenomX_Finale_Turf.jpg", "Nike Hypervenom", true }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "Deleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 12, 1, false, 59.99m, 0m, true },
                    { 13, 1, false, 29.99m, 0m, true },
                    { 14, 1, false, 132.99m, 0m, true },
                    { 15, 1, false, 109.99m, 0m, true },
                    { 16, 1, false, 90.00m, 0m, true },
                    { 17, 1, false, 229.99m, 0m, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
