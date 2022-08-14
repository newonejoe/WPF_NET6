using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp.ViewModels;
public class ChildThreeViewModel : Caliburn.Micro.Screen, IChildViewModel
{
    public int Index { get ; set ; }


	public ChildThreeViewModel()
	{
		this.DisplayName = "Child View Model 3";
		this.Index = 3;
	}
}
