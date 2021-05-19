using System;
using System.Collections.Generic;
using System.Web;
using SearchEngineApi.Contracts;
using SearchEngineApi.Models;

namespace SearchEngineApi.Services
{
    public class BingEngineApi: SearchEngineBase, ISearchEngineApi
    {
        public IEnumerable<SearchResult> FetchSearchResults(string searchQuery, int resultLimit)
        {
            const string searchEnginePath = "https://www.google.de/search";
            var uri = new Uri($"{searchEnginePath}?q={HttpUtility.UrlEncode(searchQuery)}&count={resultLimit}");
            return GetSearchResultList(uri, "//h2");
        }
    }
}