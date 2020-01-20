using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestProject.DataAccess;
using TestProject.ViewModels;
using TestProject.Views;

namespace TestProject
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        private void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<ISampleService, SampleService>();

            services.AddDatabase(Configuration);           

            // Register all ViewModels.
            services.AddSingleton<MainWindowViewModel>();

            // Register all the Windows of the applications.
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            ApplicationStartupAsync();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }


        private void ApplicationStartupAsync()
        {
            var uow = ServiceProvider.GetRequiredService<IUnitOfWork>();

            uow.EnsureDataStoreAsync();           

        }
    }    
}
