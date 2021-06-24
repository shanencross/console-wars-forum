using System;
using System.Collections.Generic;

namespace ConsoleWarsForum.Models
{
  public class Thread
  {
    public int ThreadId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateAndTimeStamp { get; set; }
  }
}


