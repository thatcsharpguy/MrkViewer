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
                var fileManager = DependencyService.Get<IFileManager>();

                var mdFile = await fileManager.LoadFile();
                header.Text = mdFile.FileName;
                var html = CommonMark.CommonMarkConverter.Convert(mdFile.Content);
                webView.Source = new MarkdownWebViewSource(mdFile.FileName, html);
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
