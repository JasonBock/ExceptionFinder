using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class FilterScenariosTests : BaseTests
	{
		[TestMethod]
		public void AnalyzeTryWithCatchAndFilterThatMightThrowException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestFilterScenariosNamespace,
				"FilterHandlerScenarios", BaseTests.TestFilterScenariosNamespace, "TryWithCatchAndFilterThatMightThrowException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));
		}
	}
}
