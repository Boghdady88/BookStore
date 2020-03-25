using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookDbRepository : IBookstoreRepository<Book>
    {
        BookStoreDbContext db;
        public BookDbRepository(BookStoreDbContext _db)
        {
            db = _db;
        }
        public IList<Book> GetAllList()
        {
            return db.Books.Include(a => a.Author).ToList();
        }
        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(r => r.Id == id);
            return book;
        }

        public void Add(Book entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Update(int id, Book newBook)
        {
            db.Update(newBook);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public List<Book> Search(string term)
        {
            var result = db.Books.Include(i => i.Author)
                .Where(r => r.Title.Contains(term)
                         || r.Description.Contains(term) 
                         || r.Author.FullName.Contains(term)).ToList();

            return result;
        }
    }
}
