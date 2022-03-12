using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification_Pattern
{
    public class Reposatory<T>
    {
        public IReadOnlyList<T> Find(Specification<T> specification)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<T>()
                    .Where(specification.ToExpression())
                    .ToList();
            }
        }
    }
}
