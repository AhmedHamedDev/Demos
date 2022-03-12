using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Specification_Pattern
{
    public class MpaaRatingAtMostSpecification : Specification<Movie>
    {
        private readonly MpaaRating _rating;
 
    public MpaaRatingAtMostSpecification(MpaaRating rating)
        {
            _rating = rating;
        }

        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.MpaaRating <= _rating;
        }
    }
}
