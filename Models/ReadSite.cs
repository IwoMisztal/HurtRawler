using HurtRawler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HurtRawler.Models
{
    public class ReadSite
    {
        private static WebClient client = new WebClient();
        public string str { get; set; }

        public string Read(string url)
        {
            str = client.DownloadString(url);
            return str;
        }
    }
}
