using LibraryWPF.Services;
using LibraryWPF.ViewModels;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Создаём экземпляр HttpClient
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086/") // Базовый адрес для вашего API
            };

            // Передаём httpClient в BookService
            BookService bookService = new BookService(httpClient);

            // Устанавливаем DataContext с использованием экземпляра BookService
            DataContext = new MainViewModel(bookService);
        }

    }
}