using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //PersistenceTest();

            var context = new PlutoDbContext();
            var courses = context.GetCourses();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Title);
            }
            Console.ReadKey();
        }

        public static void PersistenceTest()
        {
            var author = new Author { Name = "Renan Camargo Lopes" };
            var authorPersistence = new PlutoDataBasePersist<Author>(author);

            authorPersistence.SaveChanges();

            while (authorPersistence.Executing)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }

            Console.WriteLine("End of execution");

            Console.ReadKey();
        }
    }

    public class PlutoDataBasePersist<T> where T : class
    {
        public PlutoDbContext Context;
        public bool Executing;
        public T Entity { get; set; }

        public PlutoDataBasePersist(T entity)
        {
            Context = new PlutoDbContext();
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
                Thread.Sleep(6000);

                switch (Entity.GetType().Name)
                {
                    case "Author":
                        var author = (Author)(object)Entity;
                        Context.Authors.Add(author);
                        Context.SaveChanges();
                        break;

                    case "Course":
                        var course = (Course)(object)Entity;
                        Context.Courses.Add(course);
                        Context.SaveChanges();
                        break;

                    default:
                        throw new NotImplementedException($"Persist method not implemented for the class {Entity.GetType().Name}");
                }
            });
        }



    }



}
