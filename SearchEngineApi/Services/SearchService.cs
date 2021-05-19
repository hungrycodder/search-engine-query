using System;
using System.Collections.Generic;
using SearchEngineApi.Contracts;
using SearchEngineApi.Models;

namespace SearchEngineApi.Services
{
    public class SearchService : ISearchService
    {
        public IEnumerable<SearchResult> GetSearchResult(string query, string engineName)
        {
            var searchEngine = GetSearchEngine(engineName);
            return searchEngine.FetchSearchResults(query, 20);
        }

        private static ISearchEngineApi GetSearchEngine(string engineName)
        {
            switch (engineName.ToLower())
            {
                case "google":
                    return new GoogleEngineApi();
                case "bing":
                    return new BingEngineApi();
                case "custom":
                    return new CustomEngineApi();
                    
                default:
                    throw new InvalidOperationException("Invalid Search Engine name");
            }
        }
    }
}