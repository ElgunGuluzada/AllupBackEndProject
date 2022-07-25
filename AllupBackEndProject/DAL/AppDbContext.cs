using AllupBackEndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AllupBackEndProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductTags> ProductTags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    ImageUrl = "slider-1.jpg"
                },
                new Slider
                {
                    Id = 2,
                    ImageUrl = "slider-2.jpg"
                }
            );
            modelBuilder.Entity<SliderContent>().HasData(
              new SliderContent
              {
                  Id = 1,
                  SliderId = 1,
                  Name = "Fulldive VR.",
                  Offer = "Save $120 when you buy",
                  Title = "2020 Virtual Reality",
                  Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"
              },
              new SliderContent
              {
                  Id = 2,
                  SliderId = 2,
                  Name = "Sony Bravia.",
                  Offer = "Save $120 when you buy",
                  Title = "4K HDR Smart TV 43",
                  Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"
              }
             );
            modelBuilder.Entity<Banner>().HasData(
            new Banner
            {
                Id= 1,
                ImageUrl= "banner-1.png"
            },
            new Banner
            {
                Id=2,
                ImageUrl= "banner-2.png"
            }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Laptop",
                    ImageUrl = "category-1.jpg",
                    CreatedAt = System.DateTime.ParseExact("Saturday, 23 July 2022 01:06:21.5829407", "dddd, dd MMMM yyyy HH:mm:ss.fffffff", null)
                },
                new Category
                {
                    Id = 2,
                    Name = "Computer",
                    ImageUrl = "category-2.jpg",
                    CreatedAt = System.DateTime.ParseExact("Saturday, 23 July 2022 01:06:21.5839145", "dddd, dd MMMM yyyy HH:mm:ss.fffffff", null)
                },
                new Category
                {
                    Id = 3,
                    Name = "Smartphone",
                    ImageUrl = "category-3.jpg",
                    CreatedAt = System.DateTime.ParseExact("Saturday, 23 July 2022 01:06:21.5839173", "dddd, dd MMMM yyyy HH:mm:ss.fffffff", null)
                },
                new Category
                {
                    Id = 4,
                    Name = "Game Consoles",
                    ImageUrl = "category-4.jpg"
                },
                new Category
                {
                    Id = 5,
                    Name = "Tops & Sets",
                    ImageUrl = "category-6.jpg"
                },
                new Category
                {
                    Id = 6,
                    Name = "Audio & Video",
                    ImageUrl = "category-7.jpg"
                },
                new Category
                {
                    Id = 7,
                    Name = "Accessories & Parts",
                    ImageUrl = "category-8.jpg",
                    CreatedAt = System.DateTime.ParseExact("Saturday, 23 July 2022 01:06:21.5839177", "dddd, dd MMMM yyyy HH:mm:ss.fffffff", null)
                },
                new Category
                {
                    Id = 8,
                    Name = "Camera & Photo",
                    ImageUrl = "category-10.jpg"
                },
                new Category
                {
                    Id = 9,
                    Name = "Cables & Adapters",
                    ParentId = 7,
                },
                new Category
                {
                    Id = 10,
                    Name = "Batteries",
                    ParentId = 7,
                },
                new Category
                {
                    Id = 11,
                    Name = "Chargers",
                    ParentId = 7,
                },
                new Category
                {
                    Id = 12,
                    Name = "Watches",
                    ParentId = 7,
                },
                new Category
                {
                    Id = 13,
                    Name = "Bags & Cases",
                    ParentId = 7,
                },
                new Category
                {
                    Id = 14,
                    Name = "Electronic Cigarettes",
                    ParentId = 7
                },
                new Category
                {
                    Id = 15,
                    Name = "Usb Memory Sticks",
                    ParentId = 7
                },
                new Category
                {
                    Id= 16,
                    Name = "Televisions",
                    ParentId= 6,
                },
                new Category
                {
                    Id = 17,
                    Name = "TV Receivers",
                    ParentId = 6,
                },
                new Category
                {
                    Id = 18,
                    Name = "Projectors",
                    ParentId = 6,
                },
                new Category
                {
                    Id = 19,
                    Name = "Audio Amplifier Boards",
                    ParentId = 6,
                },
                new Category
                {
                    Id = 20,
                    Name = "TV Sticks ",
                    ParentId = 6,
                },
                new Category
                {
                    Id=21,
                    Name = "Digital Cameras",
                    ParentId = 8
                },
                new Category
                {
                    Id=22,
                    Name = "Camcorders",
                    ParentId=8
                },
                new Category
                {
                    Id=23,
                    Name = "Camera Drones",
                    ParentId=8
                },
                new Category
                {
                    Id=24,
                    Name = "Action Cameras",
                    ParentId=8
                },
                new Category
                {
                    Id=25,
                    Name = "Photo Studio Supplies",
                    ParentId=8
                }
           );
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id= 1,
                    Name="Camera"
                },
                new Tag
                {
                    Id=2,
                    Name="Drone"
                },
                new Tag
                {
                    Id=3,
                    Name="Music"
                },
                new Tag
                {
                    Id=4,
                    Name="Memory"
                },
                new Tag 
                {
                    Id=5,
                    Name="Gaming"
                },
                new Tag
                {
                    Id=6,
                    Name = "Premium"
                }
           );
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id=1,
                    Name="David Smith",
                    ImageUrl= "brand-1.jpg"
                },
                new Brand
                {
                    Id=2,
                    Name="Avant Garde",
                    ImageUrl="brand-2.jpg",
                },
                new Brand
                {
                    Id=3,
                    Name = "Climb The Mountain",
                    ImageUrl = "brand-3.jpg",
                },
                new Brand
                {
                    Id=4,
                    Name = "Ostrich Cafe",
                    ImageUrl = "brand-4.jpg",
                },
                new Brand
                {
                    Id=5,
                    Name="Golden",
                    ImageUrl = "brand-5.jpg",
                },
                new Brand
                {
                    Id=6,
                    Name="Norcold",
                    ImageUrl= "brand-6.jpg"
                },
                new Brand
                {
                    Id = 7,
                    Name="Apple",
                    ImageUrl="brand-7.png"
                }
           );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id =1,
                    Name = "Macbook Pro",
                    NewArrival = true,
                    BestSeller = true,
                    BrandId = 7,
                    CategoryId = 2,
                    StockCount = 20,
                    Price = 2000,
                    DiscountPercent = 10,
                    DiscountPrice = 1800,
                    TaxPercent = 10,
                    IsFeatured = true,
                    IsDeleted = false,
                    IsAvailability = true,
                    IsSpecial = true,
                    Desc = "This Model Is Special",
                    CreatedAt = System.DateTime.ParseExact("Saturday, 23 July 2022 00:46:20.0311359", "dddd, dd MMMM yyyy HH:mm:ss.fffffff", null)
                }
           );
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    Id = 1,
                    ProductId = 1,
                    ImageUrl = "special-product-21.jpg",
                    IsMain = true,
                },
                new ProductImage
                {
                    Id = 2,
                    ProductId = 1,
                    ImageUrl = "special-product-18.jpg",
                    IsMain = false,
                },
                new ProductImage
                {
                    Id = 3,
                    ProductId = 1,
                    ImageUrl = "special-product-19.jpg",
                    IsMain = false,
                },
                new ProductImage
                {
                    Id = 4,
                    ProductId = 1,
                    ImageUrl = "special-product-20.jpg",
                    IsMain = false,
                },
                new ProductImage
                {
                    Id = 5,
                    ProductId = 1,
                    ImageUrl = "special-product-22.jpg",
                    IsMain = false,
                }
           );
            modelBuilder.Entity<ProductTags>().HasData(
                new ProductTags
                {
                Id =1,
                ProductId=1,
                TagId = 6,
                }
           );
        }
    }
}
