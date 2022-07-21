using AllupBackEndProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AllupBackEndProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }

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
                  SliderId= 2,
                  Name = "Sony Bravia.",
                  Offer = "Save $120 when you buy",
                  Title = "4K HDR Smart TV 43",
                  Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"

              }
          );
        }
    }
}
