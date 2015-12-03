using System;
using MrkViewer.Core.Services;

namespace MrkViewer.iOS.Services
{
	public class FileManager : IFileManager
	{
		public FileManager ()
		{
		}

		#region IFileManager implementation

		public System.Threading.Tasks.Task<MarkdownFile> LoadFile ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}

	public class GenericTextDocument : UIDocument
	{
		#region Private Variable Storage
		private NSString _dataModel;
		#endregion

		#region Computed Properties
		public string Contents {
			get { return _dataModel.ToString (); }
			set { _dataModel = new NSString(value); }
		}
		#endregion

		#region Constructors
		public GenericTextDocument (NSUrl url) : base (url)
		{
			// Set the default document text
			this.Contents = "";
		}

		public GenericTextDocument (NSUrl url, string contents) : base (url)
		{
			// Set the default document text
			this.Contents = contents;
		}
		#endregion

		#region Override Methods
		public override bool LoadFromContents (NSObject contents, string typeName, out NSError outError)
		{
			// Clear the error state
			outError = null;

			// Were any contents passed to the document?
			if (contents != null) {
				_dataModel = NSString.FromData( (NSData)contents, NSStringEncoding.UTF8 );
			}

			// Inform caller that the document has been modified
			RaiseDocumentModified (this);

			// Return success
			return true;
		}

		public override NSObject ContentsForType (string typeName, out NSError outError)
		{
			// Clear the error state
			outError = null;

			// Convert the contents to a NSData object and return it
			NSData docData = _dataModel.Encode(NSStringEncoding.UTF8);
			return docData;
		}
		#endregion

		#region Events
		public delegate void DocumentModifiedDelegate(GenericTextDocument document);
		public event DocumentModifiedDelegate DocumentModified;

		internal void RaiseDocumentModified(GenericTextDocument document) {
			// Inform caller
			if (this.DocumentModified != null) {
				this.DocumentModified (document);
			}
		}
		#endregion
	}
}

