using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ExtensionMethods
{
    public static class Paging
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int start = 1, int take = 10) => query.Skip((start - 1) * take).Take(take);
    }
}
