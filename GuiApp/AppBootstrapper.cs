using Caliburn.Micro;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp
{
    public class AppBootstrapper : BootstrapperBase, IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWindowManager _windowManager;

        public AppBootstrapper(IServiceProvider serviceProvider, IWindowManager windowManager)
        {
            this._serviceProvider = serviceProvider;
            this._windowManager = windowManager;

            // Initialize Caliburn view and viewModel mapping
            Initialize();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // get root viewModel corresponding to ShellView
            var rootVm = _serviceProvider.GetService<IShell>();

            // show the ShellView 
            if(_windowManager != null)
                await _windowManager.ShowWindowAsync(rootVm);

        }

        // [1] Trigger when AppHost stop
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
