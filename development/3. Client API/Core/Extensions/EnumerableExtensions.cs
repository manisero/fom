﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> collection)
        {
            return collection == null || !collection.Any();
        }

        public static void ForEach<TItem>(this IEnumerable<TItem> collection, Action<TItem> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
