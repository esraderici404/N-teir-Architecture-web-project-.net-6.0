using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace Webçalışanlar.Controllers
{
    public class ÇalışanlarController : Controller
    {
        private readonly IÇalışanlarService _çalışanlarservice;

        public ÇalışanlarController(IÇalışanlarService çalışanlarservice)
        {
            _çalışanlarservice = çalışanlarservice;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _çalışanlarservice.TGetList();
            return View(values);
        }
        public IActionResult DeleteÇalışanlar(int id)
        {

            var values = _çalışanlarservice.TGetByID(id);
            _çalışanlarservice.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddÇalışanlar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddÇalışanlar(çalışanlar çalışanlar)
        {
            _çalışanlarservice.TInsert(çalışanlar);

            return RedirectToAction("Index", "Çalışanlar");
        }

        [HttpGet]
        public IActionResult EditÇalışanlar(int id)
        {
            var values = _çalışanlarservice.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditÇalışanlar(çalışanlar çalışanlar)
        {
            _çalışanlarservice.TUptade(çalışanlar);
            return RedirectToAction("Index");
        }
    }
}
