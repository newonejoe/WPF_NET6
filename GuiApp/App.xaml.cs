using Caliburn.Micro;
using GuiApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GuiApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                  .ConfigureAppConfiguration((context, configurationBuilder) =>
                  {
                  })
                .ConfigureServices((context, services) =>
                {

                    // Event Aggreagator
                    services.AddSingleton<IEventAggregator, EventAggregator>();
                    // caliburn window manager
                    services.AddSingleton<IWindowManager, WindowManager>();
                    // calibrun root VM
                    services.AddSingleton<IShell, ShellViewModel>();
                    // calibrun Bootstrapper
                    services.AddHostedService<AppBootstrapper>();

                })
                .ConfigureLogging((context, logging) => { })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            // base.OnStartup(e);
            if(AppHost != null)
                await AppHost.StartAsync();
        }

        // [0] Trigger when the exit button on the windows is clicked
        protected override async void OnExit(ExitEventArgs e)
        {
            // base.OnExit(e);
            if (AppHost != null)
            {
                using (AppHost)
                {
                    await AppHost.StopAsync(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}
