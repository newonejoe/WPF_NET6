using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IShell
    {
        private readonly IEventAggregator _eventAggregator;

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


        #endregion

        public ShellViewModel(
            IEventAggregator eventAggregator
            )
        {
            _eventAggregator = eventAggregator;
        }

    }
}
