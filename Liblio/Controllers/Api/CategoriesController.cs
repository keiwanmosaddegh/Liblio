using Liblio.Models;
using System.Linq;
using System.Web.Http;

namespace Liblio.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetCategories()
        {
            return Ok(_context.Categories.ToList());
        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryInDb == null)
            {
                return NotFound();
            }

            if (_context.LibraryItems.ToList().Exists(li => li.CategoryId == categoryInDb.Id))
            {
                return BadRequest();
            }

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
