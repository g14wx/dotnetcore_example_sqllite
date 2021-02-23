using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.config;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController: Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [Route("/")]
        public ViewResult Index()
        {
            _dbContext.Products.Add(new Product() {id = 1, price = 0.2555, title = "desde la base de datos"});
            _dbContext.SaveChanges();
            ViewBag.products = _dbContext.Products.ToList();
            return View();
        }
    }
}