using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Security;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class OpCodeScenariosTests : BaseTests
	{
		[TestMethod]
		public void CheckedAdd()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"OpCodeScenarios", BaseTests.TestScenariosNamespace, "CheckedAdd");

			var analyzer = new MethodExceptionAnalyzer(
				method, new LeakedExceptionsMethodInstructionsAnalyzerContext(OpCodeFilters.IncludeOverflow));
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, analyzer.LeakedExceptions.NonExceptions.Count);
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);

			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(OverflowException)));
		}
	}
}
