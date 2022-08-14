using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp.ViewModels;
public class ChildTwoViewModel : Caliburn.Micro.Screen, IChildViewModel
{
    public int Index { get ; set ; }


	public ChildTwoViewModel()
	{
		this.DisplayName = "Child View Model 2";
		this.Index = 2;
	}
}
