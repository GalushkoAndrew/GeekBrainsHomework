using System;
using System.Collections.Generic;
using System.Linq;
using LibraryService.Models;

namespace LibraryService.Services.Impl
{
    public class LibraryRepository : ILibraryRepositoryService
    {
        private readonly ILibraryDatabaseContextService _dbContext;

        public LibraryRepository(ILibraryDatabaseContextService dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Book> GetByTitle(string title)
        {
            try
            {
                return _dbContext.Books.Where(book => book.Title.ToLower().Contains(title.ToLower())).ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public IList<Book> GetByAuthor(string authorName)
        {
            return _dbContext.Books.Where(book =>
                book.Authors.Where(author =>
                    author.Name.ToLower().Contains(authorName.ToLower())).Count() > 0).ToList();
        }

        public IList<Book> GetByCategory(string category)
        {
            try
            {
                return _dbContext.Books.Where(book => book.Category.ToLower().Contains(category.ToLower())).ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public string Add(Book item)
        {
            throw new System.NotImplementedException();
        }

        public int Update(Book item)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(Book item)
        {
            throw new System.NotImplementedException();
        }

        public IList<Book> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Book GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}