using ExceptionFinder.Analyzers;
using ExceptionFinder.Tests.Scenarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class NativeCallScenariosTests : BaseTests
	{
		[TestMethod]
		public void AnalyzeCallNativeMethod()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"NativeCallScenarios", BaseTests.TestScenariosNamespace, "CallNativeMethod");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeCallDelegate()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"NativeCallScenarios", BaseTests.TestScenariosNamespace, "CallDelegate");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(ArithmeticException)));
		}
	}
}
