using Album.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Album.Api.Data
{
    public class AlbumDBContext : DbContext
    {
        public DbSet<AlbumModel> Albums { get; set; }

        public AlbumDBContext(DbContextOptions<AlbumDBContext> options)
            : base(options)
        {
        }
    }
}