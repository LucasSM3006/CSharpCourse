using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParserAssignment.Model
{
    public class GameData
    {
        public string Title { get; }
        public int ReleaseYear { get; }
        public double Rating { get; }

        public GameData(string title, int releaseYear, double rating)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"{Title}, released in {ReleaseYear}, with a rating of {Rating}";
        }
    }
}
