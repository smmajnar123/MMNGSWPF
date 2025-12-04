using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMNGS.DataAccess.Data;
using MMNGS.Repository.Interfaces;
using MMNGS.Repository.IRepository;
using MMNGS.Repository.Repository;
using MMNGS.Services.Interfaces;
using MMNGS.Services.IServices;
using MMNGS.Services.Services;
using System.Windows;
using TestWpf.ViewModels;
using TestWpf.Views;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            // 1. Create the Host Builder
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureApplicationServices)
                .Build();
        }
        private void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddDbContext<MMNGSDbContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MessManagementDb;Integrated Security=True;"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();

            // ViewModels
            services.AddTransient<HeaderViewModel>();
            services.AddTransient<SideBarViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddSingleton<MainWindowViewModel>(); // singleton for main window

            // Views
            services.AddSingleton<MainWindow>(sp =>new MainWindow(sp.GetRequiredService<MainWindowViewModel>()));

            services.AddSingleton<MainViewControl>();

            services.AddSingleton<SideBarViewControl>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            // Start the host and resolve/show the main window
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            // Clean up the host gracefully
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
