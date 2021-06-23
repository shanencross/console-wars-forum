using Microsoft.EntityFrameworkCore;

namespace ConsoleWarsForum.Models {
  public class ConsoleWarsForumContext : DbContext {
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Thread> Threads { get; set; }
    public ConsoleWarsForumContext(DbContextOptions options) : base(options) { }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //   optionsBuilder.UseLazyLoadingProxies();
    // }
  }
}