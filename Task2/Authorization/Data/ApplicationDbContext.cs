namespace Task.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable
public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }
    public DbSet<Signin> User{get;set;}
}