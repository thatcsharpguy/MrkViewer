using MrkViewer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MrkViewer.Core
{
    public class ViewPage : ContentPage
    {


        public ViewPage()
        {
            Label header = new Label
            {
                Text = "WebView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "http://www.google.com/",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    webView
                }
            };

            var openFileButton = new ToolbarItem
            {
                Text = "Open",
                //Icon = "open.png"
            };
            openFileButton.Clicked += async (s, a) =>
            {
                var _fileManager = DependencyService.Get<IFileManager>();

                var mdFile = await _fileManager.LoadFile();
                header.Text = mdFile.FileName;
                var html = CommonMark.CommonMarkConverter.Convert(mdFile.Content);

                var content = @"
<head>
<link rel='stylesheet' href='ms-appx-web:///Assets/github-markdown.css'>
<meta name='viewport' content='width=device-width, initial-scale=1.0, user-scalable=no'>
<style>
    .markdown-body {
        min-width: 200px;
        max-width: 790px;
        margin: 0 auto;
        padding: 30px;
    }
</style>
</head><body><article class='markdown-body'>" + html
 + @"</article></body>";
                webView.Source = new HtmlWebViewSource
                    {
                        Html = content
                    };
            };
            ToolbarItems.Add(openFileButton);

            // Trick to make our calculater fullscreen
            //var relativeLayout = new RelativeLayout();
            //relativeLayout.Children.Add(_layout, // <= Original layout
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent(p => p.Width),
            //    Constraint.RelativeToParent(p => p.Height));
            //Content = wb;
        }

    }

}
