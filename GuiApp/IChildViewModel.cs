using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp
{
    public interface IChildViewModel : Caliburn.Micro.IScreen
    {
        int Index { get; set; }
    }
}
