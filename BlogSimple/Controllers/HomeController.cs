using BlogSimple.Helpers;
using BlogSimple.Model.Domain;
using BlogSimple.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSimple.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly BlogSimpleConfig _blogSimpleConfig;
        public HomeController(IAuthorService authorService, BlogSimpleConfig blogSimpleConfig)
        {
            _authorService = authorService;
            _blogSimpleConfig = blogSimpleConfig;
        }    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestPage()
        {
          
            _authorService.Create(new Author{Email = "n",FirstName = "test", LastName = "a"});
            return View();
        }
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
