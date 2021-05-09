using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Core.Extensions
{
    public static partial class Extensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        //public static void TryUpdateManyToMany<T, TKey>(this DbContext db, IEnumerable<T> currentItems, IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class
        //{
        //    db.Set<T>().RemoveRange(currentItems.Except(newItems, getKey));
        //    db.Set<T>().AddRange(newItems.Except(currentItems, getKey));
        //}

        //public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKeyFunc)
        //{
        //    return items
        //        .GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
        //        .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
        //        .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
        //        .Select(t => t.t.item);
        //}
    }
}
