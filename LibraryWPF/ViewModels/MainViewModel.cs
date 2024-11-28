using GalaSoft.MvvmLight.Command;
using LibraryShared.Models;
using LibraryWPF.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryWPF.ViewModels
{
    // ViewModel для главного окна
    public class MainViewModel : INotifyPropertyChanged
    {
        // Сервис для работы с книгами
        private readonly BookService _bookService;

        // Коллекция книг для отображения
        public ObservableCollection<Book> Books { get; set; } = new();

        // Выбранная книга
        public Book SelectedBook { get; set; } = new();

        // Команды для добавления, обновления и удаления книг
        public ICommand AddBookCommand { get; }
        public ICommand UpdateBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        // Конструктор, принимающий BookService и инициализирующий команды
        public MainViewModel(BookService bookService)
        {
            _bookService = bookService;

            // Инициализация команд с асинхронными методами
            AddBookCommand = new RelayCommand(async () => await AddBookAsync());
            UpdateBookCommand = new RelayCommand(async () => await UpdateBookAsync());
            DeleteBookCommand = new RelayCommand(async () => await DeleteBookAsync());

            // Загрузка списка книг при старте приложения
            LoadBooksAsync();
        }

        // Событие изменения свойств
        public event PropertyChangedEventHandler? PropertyChanged;

        // Асинхронный метод для загрузки всех книг
        private async Task LoadBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync(); // Получение всех книг через сервис
            Books.Clear(); // Очистка текущего списка

            // Добавление книг в коллекцию
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        // Асинхронный метод для добавления книги
        private async Task AddBookAsync()
        {
            await _bookService.AddBookAsync(SelectedBook); // Добавление выбранной книги
            await LoadBooksAsync(); // Перезагрузка списка книг
        }

        // Асинхронный метод для обновления списка книг
        private async Task UpdateBookAsync()
        {
            await _bookService.UpdateBookAsync(Books); // Обновление книг через сервис
            await LoadBooksAsync(); // Перезагрузка списка книг
        }

        // Асинхронный метод для удаления книги
        private async Task DeleteBookAsync()
        {
            if (SelectedBook.Id > 0) // Проверка, что книга выбрана
            {
                await _bookService.DeleteBookAsync(SelectedBook.Id); // Удаление книги через сервис
                await LoadBooksAsync(); // Перезагрузка списка книг
            }
        }

        // Метод для уведомления об изменении свойства
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
