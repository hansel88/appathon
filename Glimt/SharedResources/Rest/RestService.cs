using System;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Net.NetworkInformation;
using Newtonsoft.Json;

namespace SharedResources.Rest
{
    class RestService
    {
        public static void Get(string number, string type, Action<Number> callback)
        {
            string url = "http://numbersapi.com/" + number + "/" + type + "?json";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            webRequest.BeginGetResponse(responseResult =>
            {
                try
                {
                    var response = webRequest.EndGetResponse(responseResult);
                    var result = default(Number);
                    var settings = new JsonSerializerSettings();
                    result = JsonConvert.DeserializeObject<Number>(new StreamReader(response.GetResponseStream()).ReadToEnd(), settings);

                    response.Close();
                    callback(result);
                }
                catch (Exception)
                {
                    if (type.Substring(0, 6).Equals("random"))
                    {
                        Get(number, type, callback);
                    }
                }

            }, webRequest);



        }

    }
}
