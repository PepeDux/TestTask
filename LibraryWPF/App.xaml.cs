using LibraryWPF.Services;
using LibraryWPF.ViewModels;
using LibraryWPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Windows;

namespace LibraryWPF
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            services.AddSingleton(new HttpClient { BaseAddress = new Uri("https://localhost:7086/") });
            services.AddSingleton<BookService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
        }
    }
}
