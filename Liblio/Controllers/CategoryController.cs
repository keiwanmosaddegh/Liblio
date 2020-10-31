using Liblio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Liblio.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var category = new Category();

            return View("CategoryForm", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {

            if (!ModelState.IsValid)
            {
                return View("CategoryForm", category);
            }

            if (category.Id == 0)
            {
                _context.Categories.Add(category);

            }
            else
            {
                var categoryInDb = _context.Categories.Single(c => c.Id == category.Id);

                categoryInDb.CategoryName = category.CategoryName;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }

        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View("CategoryForm", category);
        }
    }
}