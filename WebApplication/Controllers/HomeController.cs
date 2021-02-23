using System.Collections.Generic;
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
            List<Product> products = _dbContext.Products.ToList();
            return View(products);
        }
    }
}