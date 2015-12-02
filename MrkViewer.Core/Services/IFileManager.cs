using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrkViewer.Core.Services
{
    public interface IFileManager
    {
        Task<MarkdownFile> LoadFile();
    }

    public class MarkdownFile
    {
        public string FileName { get; set; }

        public string Content { get; set; }
    }
}
