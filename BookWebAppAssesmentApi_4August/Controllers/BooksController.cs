
using BookWebAppAssesmentApi_4August.Data;
using BookWebAppAssesmentApi_4August.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookWebAppAssesmentApi_4August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookApiDbContext _context;

        public BooksController(BookApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            return await _context.Books.ToListAsync();
        }

        [HttpGet("id")]
        public ActionResult Details(int id)
        {
            var books = _context.Books.Where(b => b.ID == id).FirstOrDefault();
            var book = JsonConvert.SerializeObject(books);
            return Ok(book);
        }


        [HttpGet("{searchString}")]
        public async Task<IActionResult> Search(string searchString)
        {
            if (searchString == null)
            {
                return BadRequest("input can't be null");
            }
            if (_context.Books == null)
            {
                return NotFound("Table doesn't exists");
            }
            var book = await _context.Books.Where(e => e.BookName.Contains(searchString) || e.Zoner.Contains(searchString) || e.ReleaseDate.ToString().Contains(searchString) || e.Cost.ToString().Contains(searchString)).ToListAsync();
            if (book == null)
            {
                return NotFound("Record doesn't exists");
            }
            return Ok(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(int id, Books books)
        {
            if (id != books.ID)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Books>> PostBook(Books books)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookApiDbContext.Books'  is null.");
            }
            _context.Books.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.ID }, books);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return NoContent();
        }





        private bool BooksExists(int id)
        {
            return (_context.Books?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}



