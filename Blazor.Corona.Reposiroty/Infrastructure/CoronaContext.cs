using Blazor.Corona.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Corona.DAL.Infrastructure
{
    public class CoronaContext : DbContext
    {
        public CoronaContext(DbContextOptions<CoronaContext> options) : base(options)
        {

        }

        public DbSet<CoronaStatusInfo> CoronaStatusInfo { get; set; }
        public DbSet<CoronaStatusForLocal> CoronaStatusForLocal { get; set; }
        public DbSet<Board195> Board195 { get; set; }
        public DbSet<Board196> Board196 { get; set; }
    }
}
