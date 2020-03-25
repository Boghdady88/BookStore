using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()//Test 
            {
            new Book
            {
                Id = 1, Title = "C# Programming" ,
                Description ="No Description" ,
                ImageUrl = "csharp.png",
                Author= new Author{Id = 2}
            },
             new Book
            {
                Id = 2, Title = "Java Programming" ,
                 Description ="Nothing" ,
                  ImageUrl = "Java.png",
                 Author= new Author()
            },
               new Book
            {
                Id = 3, Title = "Python Programming" ,
                   Description ="No Data" ,
                      ImageUrl = "Python.png",
                   Author= new Author()
            },
            };
        }
        public IList<Book> GetAllList()
        {
            return books;
        }
        public Book Find(int id)
        {
            var book = books.SingleOrDefault(r => r.Id == id);
            return book;
        }

        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Update(int id, Book newBook)
        {
            var book = Find(id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            book.ImageUrl = newBook.ImageUrl;

        }
        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public List<Book> Search(string term)
        {
            return books.Where(a => a.Title.Contains(term)).ToList();
        }
    }
}
