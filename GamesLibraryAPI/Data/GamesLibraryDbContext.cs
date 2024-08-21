using GamesLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Data
{
    public class GamesLibraryDbContext : DbContext
    {
        public GamesLibraryDbContext(DbContextOptions<GamesLibraryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Games> Games { get; set; }
    }
}
