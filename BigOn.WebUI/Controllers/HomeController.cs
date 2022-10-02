using BigOn.WebUI.AppCode.Extensions;
using BigOn.WebUI.Models.DataContexts;
using BigOn.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace BigOn.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BigOnDbContext db;
        private IConfiguration configuration;

        public HomeController(BigOnDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactPost model)
        {
            if (ModelState.IsValid)
            {
                db.ContactPosts.Add(model);
                db.SaveChanges();

                //ViewBag.Message = "Muracietiniz qeyde alindi. Tezlikle geri donush edilecek.";

                //ModelState.Clear();
                //return View();

                var response = new { 
                    error=false,
                    message = "Muracietiniz qeyde alindi. Tezlikle geri donush edilecek."
                };
                return Json(response);
            }

            var responseError = new
            {
                error = true,
                message = "Melumatlar uygun deyil. Duzelish edib yeniden yoxlayin",
                state = ModelState.GetError()
            };

            return Json(responseError);

            //return View(model);
        }

        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();
            return View(data);
        }

        public IActionResult Subscribe()
        {
            configuration.SendMail("raminas@code.edu.az", "<h1>Hello World!</h1>", "Test Mail");
            return Json("Ok");
        }
    }
}
