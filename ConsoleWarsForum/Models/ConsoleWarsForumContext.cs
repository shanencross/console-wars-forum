using Microsoft.EntityFrameworkCore;

namespace ConsoleWarsForum.Models {
  public class ConsoleWarsForumContext : DbContext {
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Thread> Threads { get; set; }
    public ConsoleWarsForumContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {
      builder.Entity<Thread>()
        .HasData(
          new Thread { ThreadId = 1, Title = "Sega Genesis vs Super Nintendo Entertainment System", Body = "Everyone knows that Sega does with NintenDON'T", DateAndTimeStamp=System.DateTime.Now },
          new Thread { ThreadId = 2, Title = "Nintendo 64 vs Sony PlayStation vs Sega Saturn", Body = "PlayStation was the clear winner", DateAndTimeStamp=System.DateTime.Now},
          new Thread { ThreadId = 3, Title = "PlayStation 2 vs Nintendo GameCube vs Microsoft Xbox vs Sega Dreamcast", Body = "The Xbox was the best because it had Halo", DateAndTimeStamp=System.DateTime.Now}
        );
    }
  }
}