using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            var author = new Author
            {
                Name = "Renan Camargo Lopes"
            };

            var result = await PersistAuthorsAsync(author);
        }

        public async Task<bool>  PersistAuthorsAsync(Author author)
        {
            var dbcontext = new PlutoDbContext();

            dbcontext.Authors.Add(author);
            await dbcontext.SaveChangesAsync();


        }
    }

    public class PlutoDataBasePersist
    {
        public async Task<bool> SaveChangesAsync<T>(T entity) where T : class
        {

        }
    }
}
