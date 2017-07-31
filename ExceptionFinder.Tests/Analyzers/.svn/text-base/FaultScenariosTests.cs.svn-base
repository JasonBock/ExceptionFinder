using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class FaultScenariosTests : BaseTests
	{
		[TestMethod]
		public void AnalyzeTryWithExceptionAndFaultWithDifferentExceptionMethod()
		{
			var method = AssemblyTests.GetMethod(FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.FaultTypeName, FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.MethodTryWithExceptionAndFaultWithDifferentException);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));
		}

		[TestMethod]
		public void AnalyzeTryWithExceptionAndFaultWithNoExceptionMethod()
		{
			var method = AssemblyTests.GetMethod(FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.FaultTypeName, FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.MethodTryWithExceptionAndFaultWithNoException);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeTryWithExceptionAndFaultWithSameExceptionMethod()
		{
			var method = AssemblyTests.GetMethod(FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.FaultTypeName, FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.MethodTryWithExceptionAndFaultWithSameException);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeTryWithNoExceptionAndFaultWithExceptionMethod()
		{
			var method = AssemblyTests.GetMethod(FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.FaultTypeName, FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.MethodTryWithNoExceptionAndFaultWithException);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryWithNoExceptionAndFaultWithNoExceptionMethod()
		{
			var method = AssemblyTests.GetMethod(FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.FaultTypeName, FaultAssemblyGenerator.FaultNamespace,
				FaultAssemblyGenerator.MethodTryWithNoExceptionAndFaultWithNoException);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}
	}
}
