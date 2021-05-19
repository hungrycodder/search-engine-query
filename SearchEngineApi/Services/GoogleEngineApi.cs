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
using SearchEngineApi.Contracts;
using SearchEngineApi.Models;

namespace SearchEngineApi.Services
{
    public class GoogleEngineApi : SearchEngineBase, ISearchEngineApi
    {
        public IEnumerable<SearchResult> FetchSearchResults(string searchQuery, int resultLimit)
        {
            const string searchEnginePath = "http://www.google.de/search";
            var uri = new Uri($"{searchEnginePath}?q={HttpUtility.UrlEncode(searchQuery)}&start={0}&num={20}");
            return GetSearchResultList(uri, "//h3");
         }
    }
}
