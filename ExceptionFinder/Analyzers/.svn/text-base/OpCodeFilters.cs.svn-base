using System;

namespace ExceptionFinder.Analyzers
{
	[Flags]
	internal enum OpCodeFilters
	{
		IncludeNone = 0,
		IncludeLoadElement = 1,
		IncludeLoadLocal = 2,
		IncludeLoadLocalAddress = 4,
		IncludeLoadValueIndirect = 8,
		IncludeOverflow = 16,
		IncludeStoreElement = 32,
		IncludeStoreValueIndirect = 64,
		IncludeMiscellaneous = 128,
		IncludeAll = IncludeNone | IncludeLoadElement | IncludeLoadLocal |
			IncludeLoadLocalAddress | IncludeLoadValueIndirect | IncludeOverflow |
			IncludeStoreElement | IncludeStoreValueIndirect | IncludeMiscellaneous
	}
}
