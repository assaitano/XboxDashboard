using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Media.Imaging;

namespace XboxDesktop
{
    internal class Net
    {

        public static BitmapImage LoadImages(string Url)
        {
            if (Url == "")
            {
                Url = "https://www.digiseller.ru/preview/782212/p1_3328528_eb540d10.jpg";
            }
            var imgUrl = new Uri(Url);
            var imageData = new WebClient().DownloadData(imgUrl);

            // or you can download it Async won't block your UI
            // var imageData = await new WebClient().DownloadDataTaskAsync(imgUrl);

            var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imageData);
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public static HtmlAgilityPack.HtmlDocument LoadContentFromURL(string URL)
        {
            // Call the page and get the generated HTML
            var doc = new HtmlAgilityPack.HtmlDocument();
            if (CheckConnection(URL)) {

                HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
                doc.OptionWriteEmptyNodes = true;

                var webRequest = HttpWebRequest.Create(URL);
                Stream stream = webRequest.GetResponse().GetResponseStream();
                doc.Load(stream);
                stream.Close();
            }           
            return doc;
        }

        public static void OpenURLExternal(string URL)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = URL,
                UseShellExecute = true
            });
        }

        public static bool CheckConnection(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
