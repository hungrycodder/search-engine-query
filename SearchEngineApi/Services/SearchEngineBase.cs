using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using SearchEngineApi.Models;

namespace SearchEngineApi.Services
{
    public abstract class SearchEngineBase
    {
        private const string UserAgentName = "GoogleSearch.GoogleClient";

        public IEnumerable<SearchResult> GetSearchResultList(Uri queryUrl, string selectNodeBy)
        {
            var result = new List<SearchResult>();
            var request = InstantiateWebRequest(queryUrl, UserAgentName);

            // send request and process result
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                var encoding = GetEncoding(response, Encoding.UTF8);
                using (var responseStream = response.GetResponseStream())
                {
                    using var streamReader = new StreamReader(responseStream, encoding);
                    var responseText = streamReader.ReadToEnd();

                    var document = new HtmlDocument();
                    document.LoadHtml(responseText);

                    var nodes = document.DocumentNode.SelectNodes(selectNodeBy).ToArray();
                    result.AddRange(nodes.Select(node =>
                        new SearchResult { LinkLabel = node.InnerText, Url = node.InnerHtml }));
                }
            }

            return result;
        }

        private static HttpWebRequest InstantiateWebRequest(Uri uri, string userAgentString)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            if (request == null)
            {
                throw new InvalidOperationException("Could not instantiate web request.");
            }

            // configure request
            request.UserAgent = userAgentString ?? UserAgentName;
            return request;
        }

        private static Encoding GetEncoding(HttpWebResponse response, Encoding defaultTo)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    return Encoding.GetEncoding(response.CharacterSet);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            // default
            return defaultTo;
        }
    }
}
