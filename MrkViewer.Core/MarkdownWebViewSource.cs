using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MdViewer.Core
{
    public class MarkdownWebViewSource : HtmlWebViewSource
    {


        private const string HtmlSegment1 = @"<html><head><link rel='stylesheet' href='";


        private const string HtmlSegment2 =
            @"'><meta name='viewport' content='width=device-width, initial-scale=1.0, user-scalable=no'><style>
    .markdown-body {
        min-width: 200px;
        max-width: 790px;
        margin: 0 auto;
        padding: 30px;
    }
</style></head><body><article class='markdown-body'>";

        private const string HtmlSegment3 = @"</article></body>";

        public MarkdownWebViewSource(string fileName, string content)
        {
            FileName = fileName;
            Content = content;
            base.Html = HtmlSegment1 + GetCssResorurceUri() + HtmlSegment2 + Content + HtmlSegment3;
        }

        public string FileName { get; private set; }

        public string Content { get; private set; }



        private string GetCssResorurceUri()
        {
            string uri = "";

            //if (TargetPlatform.Windows == Device.OS) // Weird error
            {
                uri = "ms-appx-web:///Assets/github-markdown.css";
            }

            return uri;
        }
    }
}
