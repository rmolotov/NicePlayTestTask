using System;
using System.Collections.Generic;
using System.Linq;

namespace NicePlayTestTask.Tools.CustomExtensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length) =>
            length == 1 
                ? list.Select(t => new T[] { t })
                : GetPermutations(list, length - 1)
                    .SelectMany(t => list.Where(o => !t.Contains(o)),
                        (t1, t2) => t1.Concat(new T[] { t2 }));

        public static IEnumerable<IEnumerable<T>> GetPermutationsWithRepetition<T>(IEnumerable<T> list, int length) =>
            length == 1 
                ? list.Select(t => new T[] { t })
                : GetPermutationsWithRepetition(list, length - 1)
                    .SelectMany(t => list,
                        (t1, t2) => t1.Concat(new T[] { t2 }));

        public static IEnumerable<IEnumerable<T>> GetKCombosWithRepetition<T>(IEnumerable<T> list, int length) 
            where T : IComparable =>
            length == 1 
                ? list.Select(t => new T[] { t })
                : GetKCombosWithRepetition(list, length - 1)
                    .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) >= 0), 
                        (t1, t2) => t1.Concat(new T[] { t2 }));

        public static IEnumerable<IEnumerable<T>> GetKCombos<T>(IEnumerable<T> list, int length) 
            where T : IComparable =>
            length == 1
                ? list.Select(t => new T[] { t })
                : GetKCombos(list, length - 1)
                    .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                        (t1, t2) => t1.Concat(new T[] { t2 }));
    }
}