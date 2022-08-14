using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp.ViewModels
{
    public class ChildOneViewModel : Caliburn.Micro.Screen, IChildViewModel
    {
        public int Index { get ; set ; }

        public ChildOneViewModel()
        {
            this.DisplayName = "Child View Model 1";
            this.Index = 1;
        }
    }
}
