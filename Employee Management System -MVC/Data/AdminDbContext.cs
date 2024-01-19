using Microsoft.EntityFrameworkCore;
namespace ems.Models;

public class AdminDbContext : DbContext
{
    //options  is like a parameterr to acess dbcontext
    //base is used to acess the contents in the parent class
     public AdminDbContext(DbContextOptions<AdminDbContext> options) :base(options)
    {

    }  
    public DbSet<TaskBase>TaskBase{get;set;}
  
}