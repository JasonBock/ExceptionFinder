using System;
using System.Text;

namespace ExceptionFinder.Tests.Scenarios
{
	public static class ExceptionHandlerScenarios
	{
		public static void FrameworkCalls()
		{
			var x = new StringBuilder();
			x.Append("Hi");
			Console.WriteLine(x);
		}
		
		public static void ComplexHandlers(string x)
		{
			try
			{
				try
				{
					if(x == null)
					{
						throw new ArgumentNullException("x");
					}
				}
				catch(ArgumentNullException)
				{
					ExceptionHandlerScenarios.ThrowNotSupportedException();
				}
			}
			finally
			{
			}
		}

		private static void ThrowNotSupportedException()
		{
			throw new NotSupportedException();
		}

		private static void ThrowNotImplementedException()
		{
			throw new NotImplementedException();
		}	
		
		public static void NoHandlers(int x)
		{
			if(x == 0)
			{
				throw new ArgumentException("x");
			}
			else if((x % 2) == 0)
			{
				throw new ArithmeticException();
			}

			if(x == int.MinValue)
			{
				throw new ArgumentException("x");
			}
		}

		public static void TryCatchWithEmbeddedTryAndCaughtException()
		{
			try
			{
				ExceptionHandlerScenarios.ThrowNotSupportedException();
			}
			catch(NotSupportedException)
			{
				try
				{
					throw new NotImplementedException();
				}
				catch(NotImplementedException)
				{
				}
			}
		}

		public static void TryCatchWithRecursiveCall()
		{
			try
			{
				ExceptionHandlerScenarios.ThrowNotSupportedException();
			}
			catch(NotSupportedException)
			{
				ExceptionHandlerScenarios.TryCatchWithRecursiveCall();
				throw new NotImplementedException();
			}
		}

		public static void TryFinallyWithRecursiveCall()
		{
			try
			{
				ExceptionHandlerScenarios.ThrowNotSupportedException();
			}
			finally
			{
				ExceptionHandlerScenarios.TryFinallyWithRecursiveCall();
				throw new NotImplementedException();
			}
		}

		public static void TryFinallyWithMethodCallsThatThrowExceptions()
		{
			try
			{
				throw new DataMisalignedException();
			}
			finally
			{
				ExceptionHandlerScenarios.ThrowNotSupportedException();
				ExceptionHandlerScenarios.ThrowNotImplementedException();;
			}
		}
		
		public static void TryFinallyWithEmbeddedTryAndEscapingException()
		{
			try
			{
				var x = 2;
				x++;
			}
			finally
			{
				try
				{
					ExceptionHandlerScenarios.ThrowNotSupportedException();
				}
				catch(ArgumentException)
				{
				}
			}
		}

		public static void TryFinallyWithEscapingExceptionFromFinallyBlockViaMethodCall()
		{
			try
			{
				var x = 2;
				x++;
			}
			finally
			{
				ExceptionHandlerScenarios.ThrowNotSupportedException();
			}
		}

		public static void TryFinallyWithEscapingException()
		{
			try
			{
				throw new DivideByZeroException();
			}
			finally
			{
			}
		}

		public static void TryFinallyWithNoException()
		{
			try
			{
				var x = 3;
				x++;
			}
			finally
			{
			}
		}

		public static void TryCatchFinallyWithEscapingException()
		{
			try
			{
				throw new DivideByZeroException();
			}
			catch(ArgumentException)
			{
			}
			finally
			{
			}
		}

		public static void TryCatchFinallyWithCaughtException()
		{
			try
			{
				throw new DivideByZeroException();
			}
			catch(ArithmeticException)
			{
			}
			finally
			{
			}
		}

		public static void TryCatchWithEscapingException()
		{
			try
			{
				throw new DivideByZeroException();
			}
			catch(ArgumentException)
			{
			}
		}

		public static void TryCatchWithCaughtException()
		{
			try
			{
				throw new ArgumentException();
			}
			catch(ArgumentException)
			{
			}
		}

		public static void TryTwoCatchesWithEscapingException()
		{
			try
			{
				throw new DivideByZeroException();
			}
			catch(NullReferenceException)
			{
			}
			catch(ArgumentException)
			{
			}
		}

		public static void TryTwoCatchesWithCaughtException()
		{
			try
			{
				throw new DivideByZeroException();
			}
			catch(NullReferenceException)
			{
			}
			catch(ArithmeticException)
			{
			}
		}
	}
}
