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
                    CreatedAt = System.DateTime.Now,
                },
                new Category
                {
                    Id = 2,
                    Name = "Computer",
                    ImageUrl = "category-2.jpg",
                    CreatedAt = System.DateTime.Now,
                },
                new Category
                {
                    Id = 3,
                    Name = "Smartphone",
                    ImageUrl = "category-3.jpg",
                    CreatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                },
                new Category
                {
                    Id = 8,
                    Name = "Video Games",
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
                    Name="Apple"
                }
           );
           // modelBuilder.Entity<Product>().HasData(
           //     new Product
           //     {

           //     },
           //     new Product
           //     {

           //     }
           //);
           // modelBuilder.Entity<ProductImage>().HasData(
           //     new ProductImage
           //     {
                    
           //     },
           //     new ProductImage
           //     {

           //     }
           //);
           // modelBuilder.Entity<ProductTags>().HasData(
           //     new ProductTags
           //     {

           //     }
           //);
            
        }
    }
}
