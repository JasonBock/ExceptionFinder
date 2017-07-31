using System;

namespace ExceptionFinder.Extensions
{
	internal static class ObjectExtensions
	{
		internal static void CheckArgumentForNull(this object @this, string name)
		{
			if(@this == null)
			{
				throw new ArgumentNullException(name);
			}
		}
	}
}
