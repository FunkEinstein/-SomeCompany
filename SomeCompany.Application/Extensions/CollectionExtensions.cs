using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace SomeCompany.Application.Extensions
{
    internal static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            var collection = enumerable as ICollection<T>;
            if (collection != null)
                return IsNullOrEmpty(collection);

            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }
    }
}
