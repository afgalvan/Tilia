using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TEntity> ForEach<TEntity>(this IEnumerable<TEntity> enumerable,
            Action<TEntity, int> action)
        {
            TEntity[] array = enumerable.ToArray();
            for (var i = 0; i < array.Length; ++i)
            {
                action(array[i], i);
            }

            return array;
        }
    }
}
