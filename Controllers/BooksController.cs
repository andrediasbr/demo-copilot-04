using DemoCopilot04.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoCopilot04.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static readonly List<Book> Books = new()
    {
        new Book { Id = 1, Title = "The Phoenix Project", Author = "Gene Kim, Kevin Behr, George Spafford", Year = 2013 },
        new Book { Id = 2, Title = "Accelerate", Author = "Nicole Forsgren, Jez Humble, Gene Kim", Year = 2018 },
        new Book { Id = 3, Title = "The DevOps Handbook", Author = "Gene Kim, Patrick Debois, John Willis, Jez Humble", Year = 2016 }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return Ok(Books);
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }
}
