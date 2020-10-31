using Liblio.Models;
using System.Collections.Generic;

namespace Liblio.ViewModels
{
    public class LibraryItemFormViewModel
    {
        public LibraryItem LibraryItem { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}