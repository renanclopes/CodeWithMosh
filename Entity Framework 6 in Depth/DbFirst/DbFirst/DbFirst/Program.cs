using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            var author = new Author { Name = "Renan Camargo Lopes" };

            var persist = new PlutoDataBasePersist<Author> { Entity = author };

            var result = persist.SaveChangesAsync();

            while (persist.Executing)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
        }

    }

    public class PlutoDataBasePersist<T> where T : class
    {
        public bool Executing;
        public T Entity { get; set; }

        public void SaveChanges()
        {
            Thread.Sleep(6000);
            this.Executing = true;

            SaveChangesAsync();

            Executing = false;

        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var type = Entity.GetType();

                var dbcontext = new PlutoDbContext();

                switch (type.Name)
                {
                    case "Author":
                        var author = (Author)(object)Entity;
                        dbcontext.Authors.Add(author);
                        break;
                    case "Course":
                        var course = (Course)(object)Entity;
                        dbcontext.Courses.Add(course);
                        break;
                    default:
                        break;
                }

                await dbcontext.SaveChangesAsync();
                Executing = false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Executing = false;
                return false;
            }
            finally
            {
                Executing = false;
            }
        }
    }
}
