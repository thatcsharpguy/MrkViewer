using MrkViewer.Core.Services;
using MrkViewer.Windows8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileManager))]
namespace MrkViewer.Windows8.Services
{
    public class FileManager : IFileManager
    {
        public async Task<MarkdownFile> LoadFile()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".md");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var mdFile = new MarkdownFile();
                mdFile.FileName = file.DisplayName;
                mdFile.Content = await FileIO.ReadTextAsync(file);
                return mdFile;

            }
            else
            {
                return null;
            }
        }
    }
}
