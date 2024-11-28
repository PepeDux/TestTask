using LibraryAPI.Data;
using LibraryShared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [ApiController]  // Атрибут для указания, что класс является контроллером API
    [Route("api/[controller]")]  // Указывает маршрут для контроллера
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;  // Контекст базы данных

        public BooksController(LibraryContext context)
        {
            _context = context;  // Инициализация контекста через конструктор
        }

        [HttpGet]  // Метод для получения всех книг
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();  // Возвращаем список всех книг
        }

        [HttpGet("{id}")]  // Метод для получения книги по ID
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);  // Поиск книги по ID

            // Если книга не найдена, возвращаем ошибку 404
            if (book == null)
            {
                return NotFound();
            }

            return book;  // Возвращаем книгу
        }

        [HttpPost]  // Метод для создания новой книги
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.Books.Add(book);  // Добавляем книгу в контекст
            await _context.SaveChangesAsync();  // Сохраняем изменения в базе данных

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);  // Возвращаем созданную книгу с её ID
        }

        [HttpPut("{id}")]  // Метод для обновления данных книги по ID
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            // Если ID не совпадает, возвращаем ошибку 400
            if (id != book.Id)
            {
                return BadRequest();
            } 

            _context.Entry(book).State = EntityState.Modified;  // Устанавливаем состояние записи как изменённое
            await _context.SaveChangesAsync();  // Сохраняем изменения

            return NoContent();  // Возвращаем статус 204 (нет содержимого)
        }

        [HttpDelete("{id}")]  // Метод для удаления книги по ID
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);  // Поиск книги по ID

            // Если книга не найдена, возвращаем ошибку 404
            if (book == null)
            {
                return NotFound();  
            }

            _context.Books.Remove(book);  // Удаляем книгу из контекста
            await _context.SaveChangesAsync();  // Сохраняем изменения

            return NoContent();  // Возвращаем статус 204 (нет содержимого)
        }
    }
}
