using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RecipeManagementSyst.Controllers
{
    public class FilterController : Controller
    {
        // GET: FilterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FilterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
