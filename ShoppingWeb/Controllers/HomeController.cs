using IdentitySample.Models;
using ShoppingWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [ChildActionOnly]
        public ActionResult Listele()
        {
            List<Category> listCategory = db.Categories.ToList();
            ViewData["listCategories"] = listCategory;
            return PartialView(listCategory);
        }
        public ActionResult Index()
        {
            List<Category> listCategory = db.Categories.ToList();
            ViewData["listCategories"] = listCategory;
            List<Product> listProduct = db.Products.ToList();
            ViewData["listProducts"] = listProduct;
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("alicanbalik@outlook.com"));
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    ViewBag.Message = "Message has been sent successfully.";
                    return View("Index");
                }
            } else
            {
                ViewBag.Message = "Error occured. Please check the form once again!";
                return View(model);
            }
        }

        //public ActionResult SendFeedback()
        //{
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SendFeedback([Bind(Include = "Id,Message")] Feedback feedback)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Feedbacks.Add(feedback);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(feedback);
        //}
    }
}
