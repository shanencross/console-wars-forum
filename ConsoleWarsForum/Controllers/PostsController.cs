using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsoleWarsForum.Models;

namespace ConsoleWarsForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ConsoleWarsForumContext _context;

        public PostsController(ConsoleWarsForumContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(DateTime? startDateAndTime, DateTime? endDateAndTime)
        {
            var query = _context.Posts.AsQueryable();

            if (startDateAndTime == null && endDateAndTime != null)
            {
              startDateAndTime = DateTime.MinValue;
            }

            if (startDateAndTime != null && endDateAndTime == null)
            {
              endDateAndTime = DateTime.MaxValue;
            }

            Console.WriteLine(startDateAndTime);
            
            if (startDateAndTime != null && endDateAndTime != null)
            {
              query = _context.Posts.Where(post => post.DateAndTimeStamp >= startDateAndTime && post.DateAndTimeStamp <= endDateAndTime);
            }
            
            return await query.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            post.DateAndTimeStamp = DateTime.Now;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.PostId }, post);
        }

        [HttpDelete("{id}/{username}")]
        public async Task<IActionResult> DeletePost(int id, string username)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            if (post.Username == username)
            { 
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            else 
            {
                return Unauthorized();
            }

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
