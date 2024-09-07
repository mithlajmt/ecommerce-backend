using backendecom.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace backendecom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Additional initialization logic if needed
        }

        public DbSet<UserModel> Users { get; set; }
    }
}