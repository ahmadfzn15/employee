using Microsoft.EntityFrameworkCore;

namespace MVC.Models;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employee { get; set; }
}
