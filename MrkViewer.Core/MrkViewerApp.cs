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
            CommonMarkSettings.Default.OutputDelegate = 
                (doc, output, settings) => new BoxedHtmlFormatter(output, settings).WriteDocument(doc);
            MainPage = new ViewPage();
        }

        public void SetExternDocument(MarkdownFile file)
        {
            (MainPage as ViewPage).SetExternDocument(file);
        }
    }
}
