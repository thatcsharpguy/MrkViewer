using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MrkViewer.Core.Services;
using MrkViewer.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace MrkViewer.Droid.Services
{
    public class BaseUrl : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }
    }
}