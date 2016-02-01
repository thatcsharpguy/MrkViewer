using CommonMark;
using MrkViewer.Core.Services;
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
            if (Device.OS == TargetPlatform.Windows)
                MainPage = new ViewPage();
            else
                MainPage = new NavigationPage(new ViewPage());
        }

        public void SetExternDocument(MarkdownFile file)
        {
            (MainPage as ViewPage).SetExternDocument(file);
        }
    }
}
