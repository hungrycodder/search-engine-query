using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchEngineApi.Models;
using SearchEngineApi.Services;

namespace SearchEngineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        
        // GET: api/search/google/searchtext
        [HttpGet("{engineName}/{searchQuery}", Name = "GetSearchResults")]
        public IEnumerable<SearchResult> Get(string searchQuery, string engineName)
        {
            return new SearchService().GetSearchResult(searchQuery, engineName);
        }
	}
}
