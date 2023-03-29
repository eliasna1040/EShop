using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ExtensionMethods
{
    public static class Paging
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int start, int? take = 10) => query.Skip(start * take.Value).Take(take.Value);
    }
}
