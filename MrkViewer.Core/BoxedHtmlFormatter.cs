using CommonMark;
using CommonMark.Syntax;

namespace MrkViewer.Core
{
    internal class BoxedHtmlFormatter : CommonMark.Formatters.HtmlFormatter
    {
        public BoxedHtmlFormatter(System.IO.TextWriter target, CommonMarkSettings settings)
            : base(target, settings)
        {
        }

        protected override void WriteInline(Inline inline, bool isOpening, bool isClosing, out bool ignoreChildNodes)
        {
            if (inline.Tag == InlineTag.Link
                && !this.RenderPlainTextInlines.Peek())
            {
                ignoreChildNodes = false;

                // start and end of each node may be visited separately
                if (isOpening)
                {
                    //this.Write("<a target=\"_blank\" href=\"#\">");
                    this.Write(inline.LiteralContent);
                }

                if (isClosing)
                {
                    //this.Write("</a>");
                }
            }
            else
            {
                base.WriteInline(inline, isOpening, isClosing, out ignoreChildNodes);
            }
        }
    }

}
