using System.Collections.Generic;
using SearchEngineApi.Models;

namespace SearchEngineApi.Contracts
{
    public interface ISearchEngineApi
    {
        IEnumerable<SearchResult> FetchSearchResults(string searchQuery, int resultLimit);
    }
}