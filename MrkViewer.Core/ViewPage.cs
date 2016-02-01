using MrkViewer.Core.Services;
using ViewMarkdown.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace MrkViewer.Core
{
    public class ViewPage : ContentPage
    {
        readonly MarkdownView _webView;
        readonly IFileManager _fileManager;


        private readonly string[] _stylesheets = { "markdown", "markdown-alt", "markdown1", "markdown2", "markdown5", "markdown9" };

        public ViewPage()
        {

            _fileManager = DependencyService.Get<IFileManager>();

            _webView = new MarkdownView
            {
                Markdown = Samples.AboutDocument,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            // Accomodate iPhone status bar.
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            // Build the page.
            this.Content = _webView;

            var openFileButton = new ToolbarItem
            {
                Text = "Open"
            };
            openFileButton.Clicked += async (s, a) =>
            {
                var mdFile = await _fileManager.LoadFile();
                if (mdFile != null)
                    SetExternDocument(mdFile);
            };


            int i = 0;
            var changeCssButton = new ToolbarItem
            {
                Text = "CSS"
            };
            changeCssButton.Clicked += async (s, a) =>
            {
                _webView.Stylesheet = _stylesheets[i++ % _stylesheets.Length];
            };

            if (Device.OS == TargetPlatform.Windows)
                ToolbarItems.Add(openFileButton);
            ToolbarItems.Add(changeCssButton);

        }

        public void SetExternDocument(MarkdownFile file)
        {
            Title = file.FileName;
            _webView.Markdown = file.Content;
        }

    }

}
