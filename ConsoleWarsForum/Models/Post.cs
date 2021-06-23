using System;

namespace ConsoleWarsForum.Models
{
  public class Post
  {
    public int PostId { get; set; }
    public int ThreadId { get; set; }
    public string Text { get; set; }
    public DateTime DateAndTimeStamp { get; set; }
    public string Username { get; set; }

    public virtual Thread Thread { get; set; }
  }
}