using System.Collections.Generic;
using LibraryService.Models;

namespace LibraryService.Services
{
    public interface ILibraryRepositoryService : IRepository<Book, string>
    {
        IList<Book> GetByTitle(string title);
        
        IList<Book> GetByAuthor(string authorName);
        
        IList<Book> GetByCategory(string category);
    }
}