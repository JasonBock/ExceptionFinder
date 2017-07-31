using ExceptionFinder.Analyzers;
using ExceptionFinder.Tests.Scenarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class RecursiveCallScenariosTests : BaseTests
	{
		[TestMethod]
		public void AnalyzeNoExceptions()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"RecursiveCallScenarios", BaseTests.TestScenariosNamespace, "NoExceptions");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTwoExceptions()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"RecursiveCallScenarios", BaseTests.TestScenariosNamespace, "TwoExceptions");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(2, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(ArithmeticException)));
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}
	}
}
