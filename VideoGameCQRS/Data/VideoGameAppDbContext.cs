using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Entities;

namespace VideoGameCQRS.Data
{
    public class VideoGameAppDbContext(DbContextOptions<VideoGameAppDbContext> options) : DbContext(options)
    {
        public DbSet<Player> Players { get; set; }
    }
}
