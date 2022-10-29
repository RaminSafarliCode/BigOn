 using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.AppCode.Services;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace BigOn.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly BigOnDbContext db;
        private readonly CryptoService crypto;
        private readonly EmailService emailService;

        public HomeController(BigOnDbContext db,  CryptoService crypto, EmailService emailService)
        {
            this.db = db;
            this.crypto = crypto;
            this.emailService = emailService;
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

                var response = new
                {
                    error = false,
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

        [HttpPost]
        public async Task<IActionResult> Subscribe(Subscribe model)
        {

            if (!ModelState.IsValid)
            {
                string msg = ModelState.Values.First().Errors[0].ErrorMessage;
                return Json(new
                {
                    error = true,
                    message = msg
                });
            }

            var entity = db.Subscribes.FirstOrDefault(s => s.Email.Equals(model.Email));

            if (entity != null && entity.IsApproved == true)
            {
                return Json(new
                {
                    error = true,
                    message = "Siz artiq abone olmusunuz."
                });
            }

            if (entity == null)
            {
                db.Subscribes.Add(model);
                db.SaveChanges();
            }
            else if (entity != null)
            {
                model.Id = entity.Id;
            }

            string token = $"{model.Id}-{model.Email}-{Guid.NewGuid()}";
            //token = token.Encrypt(Program.key);

            token = crypto.Encrypt(token, true);

            
            string message = $"Aboneliyinizi <a href='https://{Request.Host}/approve-subscribe?token={token}'>link</a> vasitesile tesdiq edin.";

            //configuration.SendMail("raminas@code.edu.az", message, "Subscribe Approve ticket");
            await emailService.SendMailAsync(model.Email, "Subscribe Approve ticket", message);

            return Json(new
            {
                error = false,
                message = "Emailinize tesdiq metni gonderdik."
            });
        }


        [Route("/approve-subscribe")]
        public IActionResult SubscribeApprove(string token)
        {
            //token = token.Decrypt(Program.key);
            token = crypto.Decrypt(token);

            // ^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$

            Match match = Regex.Match(token, @"^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$");

            if (!match.Success)
            {
                //return "Token uygun deyil!";
                ViewBag.Message = "Token uygun deyil!";
            }

            int id = Convert.ToInt32(match.Groups["id"].Value);
            string email = match.Groups["email"].Value;
            string randomKey = match.Groups["randomKey"].Value;

            var entity = db.Subscribes.FirstOrDefault(s => s.Id == id);

            if (entity == null)
            {
                //return "Istifadeci tapilmadi";
                ViewBag.Message = "Istifadeci tapilmadi";
            }
            if (entity.IsApproved)
            {
                //return "Artiq tesdiq olunub";
                ViewBag.Message = "Artiq tesdiq olunub";
            }

            ViewBag.Message = "Ugurla abone oldunuz!";
            entity.IsApproved = true;
            entity.ApprovedDate = DateTime.UtcNow.AddHours(4);
            db.SaveChanges();

            //return $"Id: {id} | Email: {email} | RandomKey: {randomKey}";
            return View();
        }
    }
}
