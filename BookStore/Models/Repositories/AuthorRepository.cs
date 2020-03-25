using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        IList<Author> Authors;
        public AuthorRepository()
        {
            Authors = new List<Author>() {
            new Author{Id = 1 , FullName = "MESH HEMDANI"},
            new Author{Id = 2 , FullName = "AHMED  BOGHDADY"},
            new Author{Id = 4 , FullName = "MOHAMMED 3MAD 3RFAA"},
            };
        }
        public IList<Author> GetAllList()
        {
           return Authors;
        }
        public Author Find(int id)
        {
            var author = Authors.SingleOrDefault(r => r.Id == id);
            return author;
        }
        public void Add(Author entity)
        {
            entity.Id = Authors.Max(b => b.Id) + 1;
            Authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            Authors.Remove(author);
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;
        }

        public List<Author> Search(string term)
        {
            return Authors.Where(a => a.FullName.Contains(term)).ToList();
        }
    }
}
