using System;
using MrkViewer.Core.Services;
using MrkViewer.iOS.Services;
using Xamarin.Forms;


[assembly: Dependency(typeof(BaseUrl))]
namespace MrkViewer.iOS.Services
{
	public class BaseUrl : IBaseUrl
	{

		#region IBaseUrl implementation

		public string Get ()
		{
			return Foundation.NSBundle.MainBundle.BundlePath + "/";
		}

		#endregion
	}
}

