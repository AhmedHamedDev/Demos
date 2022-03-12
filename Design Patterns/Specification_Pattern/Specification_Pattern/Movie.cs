using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification_Pattern
{
    public class Movie
    {
        public string Name { get; }
        public DateTime ReleaseDate { get; }
        public MpaaRating MpaaRating { get; }
        public string Genre { get; }
        public double Rating { get; }
    }

    public enum MpaaRating
    {
        G,
        PG13,
        R
    }
}
