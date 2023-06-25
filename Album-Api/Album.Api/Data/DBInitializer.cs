using Album.Api.Models;
using Album.Api.Data;
using System.Linq;

namespace Album.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AlbumDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Albums.Any())
            {
                return;   // DB has been seeded
            }

            var album = new AlbumModel[]
            {
                new AlbumModel{Id=1, Name="Dead or dead",
                    Artist="John Wick",ImageUrl="https://i.pinimg.com/originals/2b/27/a4/2b27a434b46a9d20b34e0711ef38d076.jpg"},
                new AlbumModel{Id=2, Name="Toss a coin to your witcher",
                    Artist="The Witcher",ImageUrl="https://i.pinimg.com/originals/e0/0b/a9/e00ba9feab4190ff90452a30c17ad55a.jpg"},
                new AlbumModel{Id=3, Name="Rings that ring",
                    Artist="Frodo Baggins",ImageUrl="https://i.pinimg.com/originals/7e/cc/17/7ecc171c6010bbe34b143018b7643e8c.png"}
            };
            foreach (AlbumModel s in album)
            {
                context.Albums.Add(s);
            }
            context.SaveChanges();
        }
    }
}
