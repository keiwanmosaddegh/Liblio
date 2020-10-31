using Liblio.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Liblio.Controllers
{
    public class CheckOutController : Controller
    {
        private ApplicationDbContext _context;

        public CheckOutController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New(int id)
        {
            var libraryItem = _context.LibraryItems.Single(li => li.Id == id);

            return View(libraryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(LibraryItem libraryItem)
        {
            if (!ModelState.IsValid)
            {
                return View("New", libraryItem);
            }

            var libraryItemInDb = _context.LibraryItems.Single(b => b.Id == libraryItem.Id);

            libraryItemInDb.Borrower = libraryItem.Borrower;
            libraryItemInDb.BorrowDate = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index", "LibraryItem");
        }

        public ActionResult CheckIn(int id)
        {
            var libraryItem = _context.LibraryItems.Single(li => li.Id == id);

            libraryItem.Borrower = null;
            libraryItem.BorrowDate = null;

            _context.SaveChanges();

            return RedirectToAction("Index", "LibraryItem");
        }
    }
}