using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WSTower2.Services
{
    public static class Utils
    {
        private static HttpClient client;

        public static HttpClient getClient
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://192.168.1.212:5000/api/");
                }

                return client;
            }
        }
    }
}
