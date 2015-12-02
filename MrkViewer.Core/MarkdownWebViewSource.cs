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
        public string FileName { get; set; }

        public string Text { get; set; }
    }
}
