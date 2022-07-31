using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApp
{
    public class Program
    {
        [STAThread]
        public static int Main(string[] args) { 
            var app = new App();
            return app.Run();
        }
    }
}
