using ElasticSearchInDotNet.Models;
using ElasticSearchInDotNet.Rapository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchInDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchClient searchClient;
        public HomeController(ILogger<HomeController> logger, ISearchClient searchClient)
        {
            _logger = logger;
            this.searchClient = searchClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Search(string searchText)
        {
            var response = searchClient.SearchName(searchText);
            var model = new SearchResultsModel { Results = response.Documents.ToList() };
            return View(model);
        }
    }
}
