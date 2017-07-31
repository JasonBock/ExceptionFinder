using System;

namespace ExceptionFinder.Tests.Scenarios
{
	internal sealed class RecursiveCallScenarios
	{
		public void NoExceptions()
		{
			this.NoExceptionsMiddleCall();
		}

		private void NoExceptionsMiddleCall()
		{
			this.NoExceptionsRecursiveCall();		
		}

		private void NoExceptionsRecursiveCall()
		{
			this.NoExceptions();
		}

		public void TwoExceptions()
		{
			this.TwoExceptionsMiddleCall();
		}

		private void TwoExceptionsMiddleCall()
		{
			var x = 1;
			
			if(x == 1)
			{
				throw new ArithmeticException();
			}
			
			this.TwoExceptionsRecursiveCall();
		}

		private void TwoExceptionsRecursiveCall()
		{
			var x = 1;

			if(x == 0)
			{
				throw new NotSupportedException();
			}

			this.NoExceptions();
		}
	}
}
