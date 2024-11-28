using LibraryShared.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        // Конструктор, принимающий HttpClient для выполнения HTTP-запросов
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Асинхронный метод для получения всех книг
        public async Task<List<Book>> GetAllBooksAsync()
        {
            // Выполняем GET запрос для получения списка книг
            var response = await _httpClient.GetAsync("api/books");
            response.EnsureSuccessStatusCode(); // Проверяем успешность запроса
            var json = await response.Content.ReadAsStringAsync(); // Читаем ответ в виде строки

            // Десериализуем строку в список объектов типа Book
            return JsonConvert.DeserializeObject<List<Book>>(json) ?? new List<Book>();
        }

        // Асинхронный метод для добавления новой книги
        public async Task AddBookAsync(Book book)
        {
            // Сериализуем объект книги в JSON
            var json = JsonConvert.SerializeObject(book);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Отправляем POST запрос для добавления книги
            var response = await _httpClient.PostAsync("api/books", content);
            response.EnsureSuccessStatusCode(); // Проверяем успешность запроса
        }

        // Асинхронный метод для обновления списка книг
        public async Task UpdateBookAsync(ObservableCollection<Book> books)
        {
            // Проходим по каждой книге и обновляем её информацию
            foreach (var book in books)
            {
                // Сериализуем данные для текущей книги
                var json = JsonConvert.SerializeObject(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Отправляем PUT запрос для обновления данных о книге
                var response = await _httpClient.PutAsync($"api/books/{book.Id}", content);
                response.EnsureSuccessStatusCode(); // Проверяем успешность запроса
            }
        }

        // Асинхронный метод для удаления книги по её ID
        public async Task DeleteBookAsync(int id)
        {
            // Отправляем DELETE запрос для удаления книги
            var response = await _httpClient.DeleteAsync($"api/books/{id}");
            response.EnsureSuccessStatusCode(); // Проверяем успешность запроса
        }
    }
}
