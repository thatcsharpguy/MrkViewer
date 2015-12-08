using MrkViewer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdViewer.Core;
using Xamarin.Forms;

namespace MrkViewer.Core
{
    public class ViewPage : ContentPage
    {
        readonly WebView _webView;
        readonly IFileManager _fileManager;
        readonly string _baseUrl;


        public ViewPage()
        {

            _fileManager = DependencyService.Get<IFileManager>();
            _baseUrl = DependencyService.Get<IBaseUrl>().Get();

            _webView = new WebView
            {
                Source = new MarkdownWebViewSource(Samples.FullDocument, _baseUrl),
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            // Accomodate iPhone status bar.
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            // Build the page.
            this.Content = _webView;

            var openFileButton = new ToolbarItem
            {
                Text = "Open",
                Icon = "open.png"
            };

            openFileButton.Clicked += async (s, a) =>
            {
                var mdFile = await _fileManager.LoadFile();
                if (mdFile != null)
                    SetExternDocument(mdFile);
            };
            ToolbarItems.Add(openFileButton);
        }

        public void SetExternDocument(MarkdownFile file)
        {
            Title = file.FileName;
            _webView.Source = new MarkdownWebViewSource(file.Content, _baseUrl);
        }

    }

}
