using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleWarsForum.Models
{
  public class SweetAndSavoryTreatsContextFactory : IDesignTimeDbContextFactory<ConsoleWarsForumContext>
  {
    ConsoleWarsForumContext IDesignTimeDbContextFactory<ConsoleWarsForumContext>.CreateDbContext(string[] args)
    {
      IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
      
      var builder = new DbContextOptionsBuilder<ConsoleWarsForumContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new ConsoleWarsForumContext(builder.Options);
    }
  }
}