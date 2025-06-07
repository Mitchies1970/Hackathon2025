using Microsoft.EntityFrameworkCore;

namespace Hackathon2025.DbRepo.Data
{
    public class HackathonDbContext : DbContext
    {
        public HackathonDbContext(DbContextOptions<HackathonDbContext> options) : base(options) { }

        public DbSet<Models.ProductEntity> Products { get; set; }
    }
}
