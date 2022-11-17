using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WhoWorks.WPF.StartupHelpers;
using WhoWorks.WPF.ViewModels;
using WhoWorks.WPF.Views;

namespace WhoWorks.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder();

            hostBuilder.ConfigureServices((IServiceCollection services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddPageProvider();
            });

            AppHost = hostBuilder.Build();
        }

        protected override async void OnStartup(StartupEventArgs args)
        {
            await AppHost?.StartAsync();

            var startWindow = AppHost.Services.GetRequiredService<MainWindow>();
            startWindow.DataContext = AppHost.Services.GetRequiredService<MainWindowViewModel>();
            startWindow.Show();

            base.OnStartup(args);
        }
    }
}
