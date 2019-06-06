using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbFirst
{
    class Program
    {
        public enum Level : byte
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3
        }
        static void Main(string[] args)
        {
            //PersistenceTest();
            var course = new Course
            {
                Level = Level.Beginner
            };
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

    



}
