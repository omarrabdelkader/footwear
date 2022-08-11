using Microsoft.EntityFrameworkCore;

namespace ShoesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

       public DbSet<Shoes> ShoesTable { get; set; }
    }
}
