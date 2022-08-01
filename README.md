# Modern WPF application with .NET 6 Calibrun Micro and Dependency Injection

## GuiApp with IHost and Caliburn.Micro


Host Builder with Dependency Injection in App.Xmal.cs constructor
``` c#
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
```

App Start Entry Point
```c#
protected override async void OnStartup(StartupEventArgs e)
{
    if(AppHost != null)
        await AppHost.StartAsync();
}
```

App Exit Entry
```c#
protected override async void OnExit(ExitEventArgs e)
{
    if (AppHost != null)
    {
        using (AppHost)
        {
            await AppHost.StopAsync(TimeSpan.FromSeconds(1));
        }
    }
}
```
