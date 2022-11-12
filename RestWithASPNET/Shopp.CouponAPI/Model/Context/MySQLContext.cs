using Microsoft.EntityFrameworkCore;

namespace Shopp.CouponAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; }
    }
}
