using System;
using System.Collections.Generic;
using System.Web;
using SearchEngineApi.Contracts;
using SearchEngineApi.Models;

namespace SearchEngineApi.Services
{
    public class CustomEngineApi: SearchEngineBase, ISearchEngineApi
    {
        public IEnumerable<SearchResult> FetchSearchResults(string searchQuery, int resultLimit)
        {
            var uri = new Uri("https://infotrack-tests.infotrack.com.au/Google/Page01.html");
            return GetSearchResultList(uri, "//h3");
        }
    }
}