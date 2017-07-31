using System;
using System.Collections.Generic;

namespace ExceptionFinder.Extensions
{
	internal static class DictionaryExtensions
	{
		internal static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> @this, TKey key) 
			where TValue : class, new()
		{
			TValue value = null;

			if(@this.ContainsKey(key))
			{
				value = @this[key];
			}
			else
			{
				value = new TValue();
				@this.Add(key, value);
			}

			return value;
		}
	}
}
