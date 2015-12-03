using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MrkViewer.Core
{
    public class MrkViewerApp : Xamarin.Forms.Application
    {
        public MrkViewerApp()
        {
			MainPage = new NavigationPage(new ViewPage());

        }
    }
}
