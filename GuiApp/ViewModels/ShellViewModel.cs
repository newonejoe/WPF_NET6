using Caliburn.Micro;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp.ViewModels
{
    public class ShellViewModel : Conductor<IChildViewModel>.Collection.OneActive, IShell
    {
        // event aggregator
        private readonly IEventAggregator _eventAggregator;
        // children models
        private readonly IEnumerable<IChildViewModel> _childrenViewModels;
        // hosting life time
        private readonly CancellationToken _lifeTimeApplicationStopping;

        #region Binding Properties

        private string title = "Hello";

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string info = string.Empty;

        public string Info
        {
            get { return info; }
            set { 
                info = value; 
                NotifyOfPropertyChange(() => Info);
            }
        }



        #endregion

        #region Cons
        public ShellViewModel(
            IEventAggregator eventAggregator,
            IEnumerable<IChildViewModel> childrenViewModels,
            IHostApplicationLifetime hostApplicationLifetime
            )
        {
            // event aggregator
            _eventAggregator = eventAggregator;
            // children View Models
            this._childrenViewModels = childrenViewModels;
            // application stopping token
            this._lifeTimeApplicationStopping= hostApplicationLifetime.ApplicationStopping;
        }
        #endregion

        #region LifeTime Hooks
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            // get the default inactive View Model
            IChildViewModel? firstInactiveChild = _childrenViewModels.FirstOrDefault(vm => vm.IsActive == false);

            if (firstInactiveChild != null) {
                this.ActivateItemAsync(firstInactiveChild, cancellationToken);
                Info = $"ViewModel {firstInactiveChild.Index} is activated";
            }

            return base.OnActivateAsync(cancellationToken);
        }
        #endregion

        #region Action
        public void ActivateVM(int index) { 

            // find the target View Model which is not active
            IChildViewModel? targetVM = _childrenViewModels.SingleOrDefault(vm => vm.Index == index);
            if (targetVM != null)
            {
                if (!targetVM.IsActive)
                {
                    this.ActivateItemAsync(targetVM, _lifeTimeApplicationStopping);
                    Info = $"ViewModel {targetVM.Index} is activated!";
                }
                else { 
                
                    Info = $"ViewModel {targetVM.Index} is already activated! Skip activation!";
                }
            }
            else {
                this.Info = $"Fail to find Child ViewModel {index}";
            }
        }
        #endregion

    }
}
