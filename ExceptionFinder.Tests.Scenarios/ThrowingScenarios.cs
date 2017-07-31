using System;

namespace ExceptionFinder.Tests.Scenarios
{
	public sealed class ThrowingScenarios
	{
		/// <summary>
		/// This is a method to test XML comments
		/// </summary>
		/// <param name="x">The switch to throw different exceptions.</param>
		/// <exception cref="DivideByZeroException">Thrown when <paramref name="x"/> is 0.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="x"/> is 1.</exception>
		/// <exception cref="InvalidCastException">This is reported, but analysis shouldn't find it.</exception>
		/// <exception cref="IHaveNoIdeaWhatThisIsException">Testing what happens with an unknown type.</exception>
		public void ThrowReportedExceptions(int x)
		{
			if(x == 0)
			{
				throw new DivideByZeroException();
			}
			else if(x == 1)
			{
				throw new ArgumentException();
			}
			else
			{
				throw new NotSupportedException();
			}
		}
		
		public void RethrowException()
		{
			try
			{
				throw new NotSupportedException();
			}
			catch(NotSupportedException)
			{
				throw;
			}
		}
		
		public void CreateObjectThatThrowsOnConstruction()
		{
			var constructionFail = new InternalClassThatThrowsExceptionOnConstruction();
			constructionFail.DoSomething();
		}
		
		private TypeLoadException ReturnException()
		{
			return new TypeLoadException();
		}
		
		public void ThrowReturnedException()
		{
			throw this.ReturnException();
		}
		
		public void ThrowArgumentFromInstance(Exception ex)
		{
			throw ex;
		}

		public static void ThrowArgumentFromStatic(Exception ex)
		{
			throw ex;
		}
		
		public void ThrowCustomException()
		{
			throw new CustomException("It's custom!");
		}
	}
}
