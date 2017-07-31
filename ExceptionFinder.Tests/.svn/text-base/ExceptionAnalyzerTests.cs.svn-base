using ExceptionFinder.Analyzers;
using ExceptionFinder.TestTarget;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflector;
using Reflector.CodeModel;
using Reflector.CodeModel.Memory;

namespace ExceptionFinder.Tests
{
	/// <summary>
	/// Note: http://msdn2.microsoft.com/en-us/magazine/cc163641.aspx
	/// </summary>
	[TestClass]
	public sealed class ExceptionAnalyzerTests
	{
		public const string AssemblyFileName = "ExceptionFinder.TestTarget.dll";

		[ClassInitialize]
		public static void ClassInitialize(TestContext context)
		{
			IServiceProvider provider = new ApplicationManager(null);

			IAssemblyManager manager = provider.GetService(
				typeof(IAssemblyManager)) as IAssemblyManager;

			ExceptionAnalyzerTests.Targets = manager.LoadFile(ExceptionAnalyzerTests.AssemblyFileName);
		}

		private static IMethodDeclaration GetMethod(string typeName, string methodName)
		{
			return (from IModule module in ExceptionAnalyzerTests.Targets.Modules
					  where module.Name == ExceptionAnalyzerTests.AssemblyFileName
					  from ITypeDeclaration type in module.Types
					  where type.Name == typeName
					  from IMethodDeclaration method in type.Methods
					  where method.Name == methodName
					  select method).Single();
		}
		
		[TestMethod]
		public void AnalyzeNoHandlers()
		{
			IMethodDeclaration method = ExceptionAnalyzerTests.GetMethod(
				"ExceptionHandlerScenarios", "NoHandlers");

			ExceptionAnalyzer analyzer = new ExceptionAnalyzer(method);

			Assert.AreEqual(2, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.Contains(typeof(ArithmeticException)));
			Assert.IsTrue(analyzer.LeakedExceptions.Contains(typeof(ArgumentException)));
		}

		[TestMethod]
		public void AnalyzeTryCatchWithEscapingException()
		{
			IMethodDeclaration method = ExceptionAnalyzerTests.GetMethod(
				"ExceptionHandlerScenarios", "TryCatchWithEscapingException");
			
			ExceptionAnalyzer analyzer = new ExceptionAnalyzer(method);		
			
			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.Contains(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void AnalyzeTryCatchWithCaughtException()
		{
			IMethodDeclaration method = ExceptionAnalyzerTests.GetMethod(
				"ExceptionHandlerScenarios", "TryCatchWithCaughtException");

			ExceptionAnalyzer analyzer = new ExceptionAnalyzer(method);

			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryTwoCatchesWithCaughtException()
		{
			IMethodDeclaration method = ExceptionAnalyzerTests.GetMethod(
				"ExceptionHandlerScenarios", "TryTwoCatchesWithCaughtException");

			ExceptionAnalyzer analyzer = new ExceptionAnalyzer(method);

			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeTryTwoCatchesWithEscapingException()
		{
			IMethodDeclaration method = ExceptionAnalyzerTests.GetMethod(
				"ExceptionHandlerScenarios", "TryTwoCatchesWithEscapingException");

			ExceptionAnalyzer analyzer = new ExceptionAnalyzer(method);

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.Contains(typeof(DivideByZeroException)));
		}

		private static IAssembly Targets
		{
			get;
			set;
		}

		public TestContext TestContext
		{
			get;
			set;
		}
	}
}
