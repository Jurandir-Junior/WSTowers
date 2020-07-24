using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WSTower2
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrl = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001/api" : "https://localhost:5001/api";
    }
}
