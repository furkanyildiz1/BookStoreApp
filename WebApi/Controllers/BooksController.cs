using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context; // newlemek yerine Dependency Injection ile alıyoruz resoruce işlemini program.cs de yaptık , bookcontroller.cs de kullanıyoruz
        }

        [HttpGet]

        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList(); // DbSet<Book> Books { get; set; }  RepositoryContext.cs de tanımladık
            return Ok(books); // 200 OK ile birlikte books listesini döndürüyoruz
        }

        [HttpPost]

        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book== null)
                {
                    return BadRequest();
                }

                _context.Books.Add(book);
                _context.SaveChanges(); // Değişiklikleri kaydet
                 return StatusCode(201, book); // 201 Created ile birlikte book nesnesini döndürüyoruz

            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir yanıt döndürebilirsiniz
                return StatusCode(500, $"Internal server error: {ex.Message}");
                //throw new Exception("Hata oluştu", ex.Message); 
            }
        }
    }
}
