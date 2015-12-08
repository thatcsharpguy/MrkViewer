using MrkViewer.Core;
using MrkViewer.Windows8.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms.Platform.WinRT;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MrkViewer.Windows8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : WindowsPage //: Page
    {
        MrkViewerApp app;
        public MainPage()
        {
            this.InitializeComponent();
            app = new MrkViewerApp();
            LoadApplication(app);
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            StorageFile storageFile = e.Parameter as StorageFile;
            if (storageFile != null)
            {
                FileManager fileManager = new FileManager();
                app.SetExternDocument(await fileManager.ConvertFile(storageFile));
            }
            base.OnNavigatedTo(e);
        }
    }
}
