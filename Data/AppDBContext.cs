using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Model_Produtos> Produtos { get; set; }
        public DbSet<Model_Usuario> Usuarios { get; set; }
    }
}
