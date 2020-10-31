using AutoMapper;
using Liblio.Dtos;
using Liblio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Liblio.Controllers
{
    public class LibraryItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public LibraryItemsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/libraryItems
        public IEnumerable<LibraryItemDto> GetLibraryItems(string query = null)
        {
            var libraryItemsQuery = _context.LibraryItems
                .Include(b => b.Category);

            if (!String.IsNullOrWhiteSpace(query))
            {
                libraryItemsQuery = libraryItemsQuery.Where(b => b.Title.Contains(query));
            }

            return libraryItemsQuery
                .ToList()
                .Select(Mapper.Map<LibraryItem, LibraryItemDto>);
        }

        // GET /api/libraryItems/1
        public IHttpActionResult GetLibraryItem(int id)
        {
            var libraryItem = _context.LibraryItems.SingleOrDefault(b => b.Id == id);

            if (libraryItem == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<LibraryItem, LibraryItemDto>(libraryItem));
        }

        // POST /api/libraryItems
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult CreateLibraryItem(LibraryItemDto libraryItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var libraryItem = Mapper.Map<LibraryItemDto, LibraryItem>(libraryItemDto);
            _context.LibraryItems.Add(libraryItem);
            _context.SaveChanges();

            libraryItemDto.Id = libraryItem.Id;

            return Created(new Uri(Request.RequestUri + "/" + libraryItem.Id), libraryItemDto);
        }

        // PUT /api/libraryItems/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult UpdateLibraryItem(int id, LibraryItemDto libraryItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var libraryItemInDb = _context.LibraryItems.SingleOrDefault(b => b.Id == id);

            if (libraryItemInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(libraryItemDto, libraryItemInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/libraryItems/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult DeleteLibraryItem(int id)
        {
            var libraryItemInDb = _context.LibraryItems.SingleOrDefault(b => b.Id == id);

            if (libraryItemInDb == null)
            {
                return NotFound();
            }

            _context.LibraryItems.Remove(libraryItemInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
