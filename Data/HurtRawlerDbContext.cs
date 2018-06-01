using HurtRawler.Models;
using Microsoft.EntityFrameworkCore;

namespace HurtRawler
{
    public class HurtRawlerDbContext : DbContext
    {
        public HurtRawlerDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Item> Items { get; set; }
    }
}