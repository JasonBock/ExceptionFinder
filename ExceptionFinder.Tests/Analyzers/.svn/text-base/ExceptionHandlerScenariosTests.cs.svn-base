using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Security;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class ExceptionHandlerScenariosTests : BaseTests
	{
		[TestMethod]
		public void AnalyzeComplexHandlers()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "ComplexHandlers");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeFrameworkCalls()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "FrameworkCalls");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			this.PrintFoundExceptions(analyzer.LeakedExceptions);
			
			Assert.IsTrue(analyzer.LeakedExceptions.Count > 0);
		}

		[TestMethod]
		public void AnalyzeNoHandlers()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "NoHandlers");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(2, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(ArithmeticException)));
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(ArgumentException)));
		}

		[TestMethod]
		public void AnalyzeTryCatchWithEmbeddedTryAndCaughtException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryCatchWithEmbeddedTryAndCaughtException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryCatchWithRecursiveCall()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryCatchWithRecursiveCall");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));
		}

		[TestMethod]
		public void AnalyzeTryFinallyWithRecursiveCall()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace,  "TryFinallyWithRecursiveCall");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));
		}

		[TestMethod]
		public void AnalyzeTryFinallyWithMethodCallsThatThrowExceptions()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryFinallyWithMethodCallsThatThrowExceptions");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(3, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(DataMisalignedException)));
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));
		}

		[TestMethod]
		public void AnalyzeTryFinallyWithEmbeddedTryAndEscapingException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryFinallyWithEmbeddedTryAndEscapingException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeTryFinallyWithEscapingExceptionFromFinallyBlockViaMethodCall()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, 
				"TryFinallyWithEscapingExceptionFromFinallyBlockViaMethodCall");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeTryFinallyWithEscapingException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryFinallyWithEscapingException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void AnalyzeTryFinallyWithNoException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryFinallyWithNoException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryCatchFinallyWithEscapingException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryCatchFinallyWithEscapingException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void AnalyzeTryCatchFinallyWithCaughtException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryCatchFinallyWithCaughtException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryCatchWithEscapingException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryCatchWithEscapingException");
			
			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void AnalyzeTryCatchWithCaughtException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryCatchWithCaughtException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryTwoCatchesWithCaughtException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryTwoCatchesWithCaughtException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryTwoCatchesWithEscapingException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ExceptionHandlerScenarios", BaseTests.TestScenariosNamespace, "TryTwoCatchesWithEscapingException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(DivideByZeroException)));
		}
	}
}
