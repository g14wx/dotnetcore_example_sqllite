using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication.config;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class marketController: Controller
    {
        private ApplicationDbContext _dbContext;
        private ILogger _logger;
        public marketController(ApplicationDbContext context, ILogger<marketController> logger)
        {
            _logger = logger;
            _dbContext = context;
        }


        [HttpPost]
        [Route("/product")]
        public RedirectResult EditProductForm(Product product)
        {
            Console.WriteLine(product.provider);
            if (product.id > 0)
            {
                //EDIT
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
            }
            else
            {
                //SAVE NEW PRODUCT
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }

            return new RedirectResult("/");
        }

        [HttpGet]
        [Route("/product")]
        [Route("/product/{id}")]
        public ViewResult ProductForm(int? id)
        {
                List<Provider> providers = _dbContext.Providers.ToList();
                List<SelectListItem> selectListProviders =
                    providers.ConvertAll(p => new SelectListItem {Text = p.provider, Value = p.Id.ToString() });
                ViewBag.providers = selectListProviders;
            if (id is not null)
            {
                // LOAD PRODUCT
                Product product = _dbContext.Products.FromSqlRaw($"SELECT * from Products where id={id}").FirstOrDefaultAsync().Result;
                return View(product);
            }
            else
            {
                return View();
            }
        }

    }
}