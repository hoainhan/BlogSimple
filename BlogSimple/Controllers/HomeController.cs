using BlogSimple.Helpers;
using BlogSimple.Model.Domain;
using BlogSimple.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSimple.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostService _authorService;
        private readonly BlogSimpleConfig _blogSimpleConfig;
        public HomeController(IBlogPostService authorService, BlogSimpleConfig blogSimpleConfig)
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
            return View();
        }
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
