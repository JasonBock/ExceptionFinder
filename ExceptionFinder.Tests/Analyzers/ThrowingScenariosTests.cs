using ExceptionFinder.Analyzers;
using ExceptionFinder.Tests.Scenarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class ThrowingScenariosTests : BaseTests
	{
		[TestMethod]
		public void ThrowCustomException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "ThrowCustomException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, analyzer.LeakedExceptions.NonExceptions.Count);
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);

			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(CustomException)));

 			var callStack = analyzer.LeakedExceptions.Exceptions[analyzer.LeakedExceptions.Get(typeof(CustomException))][0].CallStack;
			Assert.AreEqual(1, callStack.Count);
			Assert.AreEqual("ThrowCustomException", callStack[0].Method.Name);
			Assert.AreEqual("ThrowingScenarios", (callStack[0].Method.DeclaringType as ITypeDeclaration).Name);
		}

		[TestMethod]
		public void RethrowException()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "RethrowException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, analyzer.LeakedExceptions.NonExceptions.Count);
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);

			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}
		
		[TestMethod]
		public void ThrowReportedExceptions()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "ThrowReportedExceptions");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(4, analyzer.LeakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, analyzer.LeakedExceptions.NonExceptions.Count);
			Assert.AreEqual(4, analyzer.LeakedExceptions.Count);
			
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(DivideByZeroException)));
			Assert.IsTrue(analyzer.LeakedExceptions.Get(typeof(DivideByZeroException)).DiscoveryStatuses.IsDocumented);
			Assert.IsTrue(analyzer.LeakedExceptions.Get(typeof(DivideByZeroException)).DiscoveryStatuses.WasFoundThroughAnalysis);
			
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(ArgumentException)));
			Assert.IsTrue(analyzer.LeakedExceptions.Get(typeof(ArgumentException)).DiscoveryStatuses.IsDocumented);
			Assert.IsTrue(analyzer.LeakedExceptions.Get(typeof(ArgumentException)).DiscoveryStatuses.WasFoundThroughAnalysis);
			
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
			Assert.IsFalse(analyzer.LeakedExceptions.Get(typeof(NotSupportedException)).DiscoveryStatuses.IsDocumented);
			Assert.IsTrue(analyzer.LeakedExceptions.Get(typeof(NotSupportedException)).DiscoveryStatuses.WasFoundThroughAnalysis);

			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidCastException)));
			Assert.IsTrue(analyzer.LeakedExceptions.Get(typeof(InvalidCastException)).DiscoveryStatuses.IsDocumented);
			Assert.IsFalse(analyzer.LeakedExceptions.Get(typeof(InvalidCastException)).DiscoveryStatuses.WasFoundThroughAnalysis);
		}
		
		[TestMethod]
		public void ThrowExceptionFromObjectCreation()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "CreateObjectThatThrowsOnConstruction");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, analyzer.LeakedExceptions.NonExceptions.Count);
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));

			var callStack = analyzer.LeakedExceptions.Exceptions[analyzer.LeakedExceptions.Get(typeof(NotImplementedException))][0].CallStack;
			Assert.AreEqual(2, callStack.Count);
			Assert.AreEqual("CreateObjectThatThrowsOnConstruction", callStack[0].Method.Name);
			Assert.AreEqual("ThrowingScenarios", (callStack[0].Method.DeclaringType as ITypeDeclaration).Name);
			Assert.AreEqual(".ctor", callStack[1].Method.Name);
			Assert.AreEqual("InternalClassThatThrowsExceptionOnConstruction",
				(callStack[1].Method.DeclaringType as ITypeDeclaration).Name);
		}

		[TestMethod]
		public void ThrowExceptionFromMethodReturn()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "ThrowReturnedException");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, analyzer.LeakedExceptions.NonExceptions.Count);
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void ThrowExceptionAsArgumentFromInstance()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "ThrowArgumentFromInstance");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(Exception)));
		}

		[TestMethod]
		public void ThrowExceptionAsArgumentFromStatic()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "ThrowArgumentFromStatic");

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(Exception)));
		}
	}
}
