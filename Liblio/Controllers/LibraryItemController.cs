using Liblio.Models;
using Liblio.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Liblio.Controllers
{
    public class LibraryItemController : Controller
    {
        private ApplicationDbContext _context;

        public LibraryItemController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageBooks))
            {
                return View("List");
            }

            return View("ReadOnlyList");
        }

        public ActionResult LibraryItemDetails(int id)
        {
            var libraryItems = _context.LibraryItems;

            var libraryItem = libraryItems.Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            if (libraryItem == null)
            {
                return HttpNotFound();
            }

            return View(libraryItem);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new LibraryItemFormViewModel
            {
                LibraryItem = new LibraryItem(),
                Categories = categories
            };

            return View("LibraryItemForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(LibraryItem libraryItem)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LibraryItemFormViewModel()
                {
                    LibraryItem = libraryItem,
                    Categories = _context.Categories.ToList()
                };

                return View("LibraryItemForm", viewModel);
            }

            if (libraryItem.Id == 0)
            {
                if (libraryItem.Type == "Book" || libraryItem.Type == "DVD" || libraryItem.Type == "Audio Book")
                {
                    libraryItem.IsBorrowable = true;
                }

                _context.LibraryItems.Add(libraryItem);
            }
            else
            {
                var libraryItemInDb = _context.LibraryItems.Single(b => b.Id == libraryItem.Id);

                libraryItemInDb.Title = libraryItem.Title;
                libraryItemInDb.Type = libraryItem.Type;
                libraryItemInDb.CategoryId = libraryItem.CategoryId;
                libraryItemInDb.Author = libraryItem.Author;
                libraryItemInDb.Pages = libraryItem.Pages;
                libraryItemInDb.RunTimeMinutes = libraryItem.RunTimeMinutes;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "LibraryItem");
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {

            var libraryItem = _context.LibraryItems.SingleOrDefault(b => b.Id == id);

            if (libraryItem == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LibraryItemFormViewModel()
            {
                LibraryItem = libraryItem,
                Categories = _context.Categories.ToList()
            };

            return View("LibraryItemForm", viewModel);
        }
    }
}