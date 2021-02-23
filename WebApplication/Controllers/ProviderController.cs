using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.config;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProviderController: Controller
    {
        private ApplicationDbContext _applicationDbContext;
        public ProviderController(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }

        [HttpGet]
        [Route("/providers")]
        public ViewResult Index()
        {
            // get all providers
            List<Provider> providersList = _applicationDbContext.Providers.ToList();
            ViewBag.titulo = "All Providers";
            return View(providersList);
        }

        [HttpGet]
        [Route("/provider")]
        [Route("/provider/{id}")]
        public ViewResult ProviderForm(int? id)
        {
            ViewBag.titulo = "Edit/Add a new Provider";
            if (id is not null)
            {
                // edit a provider
                // look for a provider by its own id
                Provider selectedProvider = _applicationDbContext.Providers
                    .FromSqlRaw($"SELECT * from Provider where id = {id}").FirstOrDefaultAsync().Result;
                return View(selectedProvider);

            }
            return View();
        }
        
        [HttpPost]
        [Route("/provider")]
        public RedirectResult EditProvider(Provider pro)
        {
            if (pro.Id > 0)
            {
                // perform edit 
                _applicationDbContext.Providers.Update(pro);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                // add a new provider
                _applicationDbContext.Providers.Add(pro);
                _applicationDbContext.SaveChanges();
            }
            return new RedirectResult("/providers");
        }

    }
}