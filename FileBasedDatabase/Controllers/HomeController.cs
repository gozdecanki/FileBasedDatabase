using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileBasedDatabase.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FileBasedDatabase.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BaseDatabase baseDatabase = Helper.JsonHelper.GetDatabase();
            return View(baseDatabase);
        }

        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult GetBaseDatabase()
        {
            return new JsonResult(Helper.JsonHelper.GetDatabase());
        }

        public IActionResult SetLibraryProperties([FromBody] Data.Dtos.LibraryPropertiesDto libraryProperties)
        {
            var baseDatabase = Helper.JsonHelper.GetDatabase();
            baseDatabase.Name = libraryProperties.Name;
            baseDatabase.Address = libraryProperties.Address;
            baseDatabase.Capacity = libraryProperties.Capacity;
            Helper.JsonHelper.SetDatabase(baseDatabase);

            return new JsonResult(baseDatabase);
        }

        [Route("home/manageVisitor/{id}")]
        public IActionResult ManageVisitor()
        {
            return View();
        }
        [Route("home/managebook/{id}")]
        public IActionResult ManageBook()
        {
            return View();
        }
    }
}