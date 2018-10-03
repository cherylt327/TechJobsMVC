using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using System;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            


            if (String.IsNullOrEmpty(searchTerm))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title =  "All Jobs";
                ViewBag.jobs = jobs;
                return View("Views/List/Jobs.cshtml");
            }


            if (searchType == "all")
			{
				ViewBag.jobs = Models.JobData.FindByValue(searchTerm);
			}
            
            else 
			{
				ViewBag.jobs = Models.JobData.FindByColumnAndValue(searchType, searchTerm);
			}

		
			
			ViewBag.title = "Search";
			
			return View("Views/Search/Index.cshtml");


        }


        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
