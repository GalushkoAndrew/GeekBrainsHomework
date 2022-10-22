using System.Collections.Generic;
using LibraryService.Models;

namespace LibraryService.Services
{
    public interface ILibraryDatabaseContextService
    {
        IList<Book> Books { get; }
    }
}