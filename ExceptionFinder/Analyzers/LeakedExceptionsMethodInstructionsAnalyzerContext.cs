using ExceptionFinder.Extensions;
using System;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedExceptionsMethodInstructionsAnalyzerContext
	{
		internal LeakedExceptionsMethodInstructionsAnalyzerContext()
			: base()
		{
		}

		internal LeakedExceptionsMethodInstructionsAnalyzerContext(OpCodeFilters opCodeFilters)
			: base()
		{
			this.OpCodeFilters = opCodeFilters;
		}

		internal OpCodeFilters OpCodeFilters
		{
			get;
			private set;
		}
	}
}
