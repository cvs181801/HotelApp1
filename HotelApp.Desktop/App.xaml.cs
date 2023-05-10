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
using HotelAppLibrary.Databases;

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            services.AddTransient<MainWindow>();
            services.AddTransient<ISqlDataAccess,SqlDataAccess>();
            services.AddTransient<IDatabaseData, SqlAccessCRUD>();

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json"); //this sets up a connection with the database.

            IConfiguration config = builder.Build(); //Build() typically returns an iconfiguration root. however, we want to return an IConfiguration, so that we get this config when the service(s) request this 
            services.AddSingleton(config); //adds a singleton service of the type specified in IConfiguration()... (returns the same instance each time).
            //according to Tim Corey, we first instantiate the config above (which is now a live instance), then essentialy inject this as a dependency. Now, when the service requests an Iconfiguration, it will receive our live config instance.
        
            var serviceProvider = services.BuildServiceProvider(); 
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show(); 
            //in order to get this code to show (launch) the mainWindow, we added the appsettings.Json file and right clicked on it, then selected 'copy if newer' from drop down menu.This will add a updated copy into the build directory each time you run this project.Otherwise you'll get an exception saying something about the app not finding the path/won't have your recent updates added to the json file.
        }

       
    }
}
