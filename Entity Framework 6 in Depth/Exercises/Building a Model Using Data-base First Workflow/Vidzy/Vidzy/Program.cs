using System;
using System.Globalization;
using System.Linq;

namespace Vidzy
{
   
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new VidzyDbContext();

            var genres = dbContext.Genres.ToList();

            var video = new Video
            {
                Name = "Teste 2",
                ReleaseDate = DateTime.Parse("12/23/2015", CultureInfo.InvariantCulture),
                Genre = new Genre() { Name = "Comedy" },
                Classification = Classification.Gold
            };

            var result = dbContext.AddVideo(video.Name, video.ReleaseDate, video.Genre.Name, (byte)video.Classification);
        }
    }
}
