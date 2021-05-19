using System.Collections.Generic;
using SearchEngineApi.Models;

namespace SearchEngineApi.Contracts
{
    public interface ISearchService
    {
        IEnumerable<SearchResult> GetSearchResult(string query, string engineName);
    }
}