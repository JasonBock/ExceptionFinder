using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class LeakedExceptionsMethodInstructionsAnalyzerTests : BaseTests
	{
		[TestMethod]
		public void AnalyzeNativeMethod()
		{
			var analyzer = new LeakedExceptionsMethodInstructionsAnalyzer(
				new MockMethodDeclaration(), new HashSet<IMethodSignature>(),
				new List<CallStackInformation>(), new LeakedExceptionsMethodInstructionsAnalyzerContext());
			analyzer.Analyze();
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void AnalyzeNullMethod()
		{
			var analyzer = new LeakedExceptionsMethodInstructionsAnalyzer(
				null, new MockInstruction(), new HashSet<IMethodSignature>(), new List<CallStackInformation>(), 
				new LeakedExceptionsMethodInstructionsAnalyzerContext());
			analyzer.Analyze();
			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}
	}
}
