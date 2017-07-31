using System;

namespace ExceptionFinder.Tests.Scenarios
{
	public static class NativeCallScenarios
	{
		public static void CallNativeMethod()
		{
			var tick = NativeMethods.GetTickCount();

			if((tick % 2) == 0)
			{
				throw new NotSupportedException();
			}
		}

		public static void CallDelegate()
		{
			Func<int> call = () =>
			{
				return 2;
			};
			
			if((call() % 2) == 0)
			{
				throw new ArithmeticException();			
			}
		}
	}
}
