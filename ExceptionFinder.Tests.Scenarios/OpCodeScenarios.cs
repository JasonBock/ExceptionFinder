using System;

namespace ExceptionFinder.Tests.Scenarios
{
	internal sealed class OpCodeScenarios
	{
		internal static int CheckedAdd(int x, int y)
		{
			return checked(x + y);
		}
	}
}
