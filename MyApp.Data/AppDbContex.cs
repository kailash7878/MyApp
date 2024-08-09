using Microsoft.EntityFrameworkCore;
using MyApp.Data.Models;

namespace MyApp.Data
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}
