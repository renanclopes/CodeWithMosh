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
            var authorPersistence = new PlutoDataBasePersist<Author>(author);

            var course = new Course {
                Title = "Teste",
                Description = "Teste",
                Price = 49,
                Level = 1,
                LevelString = "Advanced",
                AuthorID = 13
            };
            var coursePersistence = new PlutoDataBasePersist<Course>(course);

            authorPersistence.SaveChanges();
            while (authorPersistence.Executing)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            coursePersistence.SaveChanges();
            while (authorPersistence.Executing)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("End of execution");


            Console.ReadKey();
        }

    }

    public class PlutoDataBasePersist<T> where T : class
    {
        public PlutoDbContext _context;
        public bool Executing;
        public T Entity { get; set; }

        public PlutoDataBasePersist(T entity)
        {
            _context = new PlutoDbContext();
            Entity = entity;
        }

        public async void SaveChanges()
        {
            try
            {
                Executing = true;
                Console.WriteLine($"Saving changes to {Entity.GetType().Name}");

                await SaveAsync();

                Console.WriteLine("Done!");

                Executing = false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException entityValidation)
            {
                Console.WriteLine($"Save changes error on entity {Entity.GetType().Name}: {entityValidation.Message}");

                var validationErrors = entityValidation.EntityValidationErrors;

                foreach (var errorCollection in validationErrors)
                {
                    foreach (var error in errorCollection.ValidationErrors)
                    {
                        Console.WriteLine($"{ error.PropertyName} : {error.ErrorMessage}");
                    }
                }

                Executing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save changes error on entity {Entity.GetType().Name}: {ex.Message}");
                Executing = false;
            }
            
        }

        private Task SaveAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                switch (Entity.GetType().Name)
                {
                    case "Author":
                        var author = (Author)(object)Entity;
                        _context.Authors.Add(author);
                        _context.SaveChanges();
                        break;

                    case "Course":
                        var course = (Course)(object)Entity;
                        _context.Courses.Add(course);
                        _context.SaveChanges();
                        break;

                    default:
                        throw new NotImplementedException($"Persist method not implemented for the class {Entity.GetType().Name}");
                }
            });
        }
    }
}
