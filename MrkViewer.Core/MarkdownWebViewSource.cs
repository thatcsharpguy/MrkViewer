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


        private const string HtmlSegment1 = @"
<html>
    <head>
        <link rel='stylesheet' href='";

        private const string HtmlSegment2 =
            @"'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0, user-scalable=no'>
        <style>
            .markdown-body {
                min-width: 200px;
                max-width: 790px;
                margin: 0 auto;
                padding: 30px;
            }
        </style>
    </head>
    <body>
        <article class='markdown-body'>";

        private const string HtmlSegment3 = @"
        </article>
    </body>
</html>";

        private readonly string _baseUrl;

        public MarkdownWebViewSource(string markdown, string baseUrl)
        {
            Markdown = markdown;
            _baseUrl = baseUrl;

            


            base.Html = HtmlSegment1 +
                GetCss() +
                HtmlSegment2 +
                CommonMark.CommonMarkConverter.Convert(markdown) +
                HtmlSegment3;
        }

        public string Markdown { get; private set; }

        private string GetCss()
        {
            return _baseUrl + "github-markdown.css";
        }
    }
}
