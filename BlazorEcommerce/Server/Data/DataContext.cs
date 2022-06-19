using Shared;

namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(_configuration.GetConnectionString("SqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

            modelBuilder.Entity<ProductVariant>()
                .HasKey(p => new { p.ProductId, p.ProductTypeId });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

            modelBuilder.Entity<ProductType>().HasData(
                    new ProductType { Id = 1, Name = "Default" },
                    new ProductType { Id = 2, Name = "Paperback" },
                    new ProductType { Id = 3, Name = "E-Book" },
                    new ProductType { Id = 4, Name = "Audiobook" },
                    new ProductType { Id = 5, Name = "Stream" },
                    new ProductType { Id = 6, Name = "Blu-ray" },
                    new ProductType { Id = 7, Name = "VHS" },
                    new ProductType { Id = 8, Name = "PC" },
                    new ProductType { Id = 9, Name = "PlayStation" },
                    new ProductType { Id = 10, Name = "Xbox" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 2,
                    Name = "Movies",
                    Url = "movies"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                },
                new Category
                {
                    Id = 4,
                    Name = "Sports",
                    Url = "sports"
                },
                new Category
                {
                    Id = 5,
                    Name = "Clothing",
                    Url = "clothing"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "The Hitchhiker's Guide to the Galaxy",
                        Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                        CategoryId = 1,
                        Featured = true
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "Ready Player One",
                        Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "Nineteen Eighty-Four",
                        Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 4,
                        CategoryId = 2,
                        Title = "The Matrix",
                        Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                    },
                    new Product
                    {
                        Id = 5,
                        CategoryId = 2,
                        Title = "Back to the Future",
                        Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                        Featured = true
                    },
                    new Product
                    {
                        Id = 6,
                        CategoryId = 2,
                        Title = "Toy Story",
                        Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",

                    },
                    new Product
                    {
                        Id = 7,
                        CategoryId = 3,
                        Title = "Half-Life 2",
                        Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",

                    },
                    new Product
                    {
                        Id = 8,
                        CategoryId = 3,
                        Title = "Diablo II",
                        Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                    },
                    new Product
                    {
                        Id = 9,
                        CategoryId = 3,
                        Title = "Day of the Tentacle",
                        Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                        Featured = true
                    },
                    new Product
                    {
                        Id = 10,
                        CategoryId = 3,
                        Title = "Xbox",
                        Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                    },
                    new Product
                    {
                        Id = 11,
                        CategoryId = 3,
                        Title = "Super Nintendo Entertainment System",
                        Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg"
                    },
                    new Product
                    {
                        Id = 17,
                        CategoryId = 4,
                        Title = "Nike Hypervenom",
                        Description = "The Nike Hypervenom is a football boot manufactured by Nike. This type of boot is said to be for traction, power, and agility, designed for deceptive players. Therefore, it is endorsed/worn by players, notably forwards, such as Robert Lewandowski, Harry Kane, Edinson Cavani, Gonzalo Higuaín, Mauro Icardi and Thiago. In 2017, 18-year-old prodigy Kylian Mbappé was given his own personalised boots, the Nike Hypervenom 3.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/HypervenomX_Finale_Turf.jpg/250px-HypervenomX_Finale_Turf.jpg"
                    },
                    new Product
                    {
                        Id = 12,
                        CategoryId = 4,
                        Title = "Adidas Telstar 18",
                        Description = "The Adidas Telstar 18 was the official match ball of the 2018 FIFA World Cup, which was held in the Russian Federation. It was designed by the company Adidas, a FIFA Partner and FIFA World Cup official match ball supplier since 1970, and based on the concept of the first Adidas's World Cup match ball.",
                        ImageUrl = "https://images.unsplash.com/photo-1511886929837-354d827aae26?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=464&q=80"
                    },
                    new Product
                    {
                        Id = 13,
                        CategoryId = 4,
                        Title = "Liverpool FC 21/22 Home Kit",
                        Description = "Pure and simply Liverpudlian red. Show that your support means more than any other club with this Liverpool home Stadium shirt.",
                        ImageUrl = "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/06/9.jpg"
                    },
                    new Product
                    {
                        Id = 14,
                        CategoryId = 5,
                        Title = "Adidas U_Path Run Shoes – Black",
                        Description = "Run with it. Step into these adidas U_Path Run Shoes and take your style game to the finish line. With a sleek feel and futuristic look, the mesh upper has a bungee heel overlay that delivers stretchy support. Move in comfort all day with the EVA midsole.",
                        ImageUrl = "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/04/28-1.jpg"
                    },
                    new Product
                    {
                        Id = 15,
                        CategoryId = 5,
                        Title = "Nike Winflo 8 Running Sneaker",
                        Description = "The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology. The result is better stability for long runs.",
                        ImageUrl = "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_705,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/05/38-1.jpg"
                    },
                    new Product
                    {
                        Id = 16,
                        CategoryId = 5,
                        Title = "Adidas Run Falcon 2.0 Shoes",
                        Description = "Strap up in these adidas running shoes and you’re set for a jog in the park followed by coffee with friends. With a mesh upper for outstanding breathability, they’re meant to deliver comfort all day long. A durable rubber outsole gives you a solid foundation no matter how busy your schedule.",
                        ImageUrl = "https://sp-ao.shortpixel.ai/client/to_webp,q_glossy,ret_img,w_800,h_800/https://www.mysportskit.com.ng/wp-content/uploads/2022/04/20.webp"
                    }
            );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 17,
                    ProductTypeId = 1,
                    Price = 229.99m,
                    OriginalPrice = 229.99m
                },
                new ProductVariant
                {
                    ProductId = 12,
                    ProductTypeId = 1,
                    Price = 59.99m,
                    OriginalPrice = 59.99m
                },
                new ProductVariant
                {
                    ProductId = 13,
                    ProductTypeId = 1,
                    Price = 29.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 14,
                    ProductTypeId = 1,
                    Price = 132.99m,
                    OriginalPrice = 132.99m
                },
                new ProductVariant
                {
                    ProductId = 15,
                    ProductTypeId = 1,
                    Price = 109.99m,
                    OriginalPrice = 109.99m
                },
                new ProductVariant
                {
                    ProductId = 16,
                    ProductTypeId = 1,
                    Price = 90.00m,
                    OriginalPrice = 90.00m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 9.99m,
                    OriginalPrice = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 3,
                    Price = 7.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 4,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 7.99m,
                    OriginalPrice = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    Price = 6.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 5,
                    Price = 3.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 6,
                    Price = 9.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 7,
                    Price = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 5,
                    Price = 3.99m,
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 5,
                    Price = 2.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 8,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 9,
                    Price = 69.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 10,
                    Price = 49.99m,
                    OriginalPrice = 59.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 8,
                    Price = 9.99m,
                    OriginalPrice = 24.99m,
                },
                new ProductVariant
                {
                    ProductId = 9,
                    ProductTypeId = 8,
                    Price = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 10,
                    ProductTypeId = 1,
                    Price = 159.99m,
                    OriginalPrice = 299m
                },
                new ProductVariant
                {
                    ProductId = 11,
                    ProductTypeId = 1,
                    Price = 79.99m,
                    OriginalPrice = 399m
                }
            );

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ChatMessagesFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ChatMessagesToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                // how should this work?
                // one user can make many reviews.
                // one product can have many reviews
                entity.HasOne(d => d.MadeBy)
                    .WithMany(p => p.UserReviews)
                    .HasForeignKey(d => d.MadeByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.OnProduct)
                    .WithMany(p => p.ReviewsOnProduct)
                    .HasForeignKey(d => d.OnProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ReviewLikes>(entity =>
            {
                entity.HasKey(k => new { k.LikedByUserId, k.LikedReviewId });
            });

            modelBuilder.Entity<ReviewLikes>(entity =>
            {
                entity.HasOne(k => k.LikedByUser)
                    .WithMany(l => l.UserReviewLikes)
                    .HasForeignKey(k => k.LikedByUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReviewLikes>(entity =>
            {
                entity.HasOne(s => s.LikedReview)
                    .WithMany(k => k.LikedByUsers)
                    .HasForeignKey(f => f.LikedReviewId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 1,
            //        Name = "Jenny",
            //        Email = "jennychris2002@yahoo.co.uk",
            //        DateCreated = DateTime.Now,
            //        PasswordHash = System.Text.Encoding.UTF8.GetBytes("0xBD07BFD82F0E8C256FDA4B63CDEFB747AD03F6750E89DF053D704FCE9C0D022730639974CEBBBCEFA026378072484CB9A0EB41CAD15E8E6CA8160E95D95E4E6D"),
            //        PasswordSalt = System.Text.Encoding.UTF8.GetBytes("0x1054089E6DA72FC5D1C14BF914F0AD832B9A4E54AB0087128279B59B5E0C6C0267EB078FABCFB1116958F55789D22E68FFA925EC7905A69125AE7E6E93EAC7262F75533354236D56FBD75032FF1D1522EB812BA16A6B6CF7530309C0B1C531257F00960369CB1B086739F254E18062A56D159A494C1C33647F6EA4156884C6AC"),
            //        AcceptsMessages = false,
            //        Role = "Customer"
            //    },
            //    new User
            //    {
            //        Id = 2,
            //        Name = "Chukwuemeka",
            //        Email = "chukwuemeka.ihenacho@stu.cu.edu.ng",
            //        DateCreated = DateTime.Now,
            //        PasswordHash = System.Text.Encoding.UTF8.GetBytes("0xE9C1A04ED1A22C60B24A8B79D74D127FA4C31FEC72FB61C7353BD01A93238D0E28AD98A488276B7E23C8BDA36F372F7C874665204B1BA0F737761D02FD9F996F"),
            //        PasswordSalt = System.Text.Encoding.UTF8.GetBytes("0xEF3F41A7E8536E4C51296379191D2A51334584F1F0A1B91121834111F3D6AFB672A7C88DB6DA6D0BF535FC9FBD9B9CB890209F1C6B5426D7461FAEEC0564F5D87FC03197F3270AB57F684275855A0AC04531DF4174CDEC68B9BCD07D09EE66A3CC801F7407C805161D2E37220A752FAB34385243B05EA480810CA70163F62F48"),
            //        AcceptsMessages = true,
            //        Role = "Customer"
            //    },
            //    new User
            //    {
            //        Id = 3,
            //        Name = "Admin",
            //        Email = "admin@gmail.com",
            //        DateCreated = DateTime.Now,
            //        PasswordHash = System.Text.Encoding.UTF8.GetBytes("0x94406732BF8123B4180CAE4C6ED1AD287895C7F9F59B621680D9C3248F442BB34A0BA845C5A29053B659FA2C2F3CAEB519A7F3E6D8CF1CBE141A12F5B8A378B5"),
            //        PasswordSalt = System.Text.Encoding.UTF8.GetBytes("0xC039E0C597C2674C95834CE115E191B81CAEE9CFC3549D25A827CA846651385F6154A62A17B438C3A5CE12F352C4892296ADB0C3054206FC3A0ECE53BDF4E781A14047AF386FDB9588BFAB87AE585AF21CAF9329321195D75644D196C6FC1A348CD0A2FC603732F4AE5AA9179465542D71D759E480C677537CE67CCC604C3F5D"),
            //        AcceptsMessages = true,
            //        Role = "Customer"
            //    });

            //modelBuilder.Entity<UserInterest>().HasData(
            //    new UserInterest
            //    {
            //        Id = 1,
            //        UserId = 1,
            //        Books = true,
            //        Movies = true,
            //        VideoGames = true,
            //        Sports = false,
            //        Clothing = false,
            //        Default = false
            //    },
            //    new UserInterest
            //    {
            //        Id = 2,
            //        UserId = 2,
            //        Books = false,
            //        Movies = true,
            //        VideoGames = true,
            //        Sports = true,
            //        Clothing = false,
            //        Default = false
            //    },
            //    new UserInterest
            //    {
            //        Id = 3,
            //        UserId = 3,
            //        Books = true,
            //        Movies = false,
            //        VideoGames = false,
            //        Sports = true,
            //        Clothing = true,
            //        Default = false
            //    });
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ReviewLikes> ReviewLikes { get; set; }
    }
}
