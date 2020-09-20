using Microsoft.EntityFrameworkCore;

namespace LJAF.Infra.Data.Context
{
    public class LjafContext : DbContext
    {
        public LjafContext() { }

        public LjafContext(DbContextOptions<LjafContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
