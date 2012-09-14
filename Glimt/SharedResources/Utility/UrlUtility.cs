using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Utility
{
    static class UrlUtility
    {
        private static string BASE_URL = "http://www.glimt.com/api/v1";
        public static string SEARCH_URL = BASE_URL + "/events/search?";

    }
}
