using System;
using System.Collections.Generic;

namespace ExceptionFinder.Extensions
{
	internal static class HashSetExtensions
	{
		internal static void AddRange<T>(this HashSet<T> @this, IEnumerable<T> range)
		{
			foreach(T item in range)
			{
				@this.Add(item);
			}
		}
	}
}
