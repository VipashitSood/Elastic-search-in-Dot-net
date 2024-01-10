using ElasticSearchInDotNet.Models;
using ElasticSearchInDotNet.Rapository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Linq;

namespace ElasticSearchInDotNet.Controllers
{
    public class StudentController : Controller
    {
        private readonly ISearchClient searchClient;
        public StudentController(ISearchClient searchClient)
        {
            this.searchClient = searchClient;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchText)
        {
            var response = searchClient.SearchName(searchText);
            var model = new SearchResultsModel { Results = response.Documents.ToList() };
            return View(model);
        }


        public IActionResult GetAllStudents()
        {
            var response = searchClient.GetAllData();
            var model = new SearchResultsModel { Results = response.Documents.ToList() };
            return View(model);
        }


        public IActionResult SumOfAges()
        {
            var response = searchClient.AgeSumMultiple();
            return View(response);
        }
        //[HttpGet]
        //public IActionResult AddStudent()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddStudent(Student student)
        //{

        //    return View(student);
        //}



    }
}
