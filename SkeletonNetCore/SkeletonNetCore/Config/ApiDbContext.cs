using Microsoft.EntityFrameworkCore;

namespace SkeletonNetCore.Config
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {  }

    }
}
