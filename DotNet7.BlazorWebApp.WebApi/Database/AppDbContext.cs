using Microsoft.EntityFrameworkCore;

namespace DotNet7.BlazorWebApp.WebApi.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<TblBlogs> Blogs { get; set; }
}