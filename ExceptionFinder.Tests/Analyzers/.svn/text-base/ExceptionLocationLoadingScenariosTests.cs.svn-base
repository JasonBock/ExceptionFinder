using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public class ExceptionLocationLoadingScenariosTests : BaseTests
	{
		[TestMethod]
		public void AnalyzeThrowExceptionFromLdarg_1InstructionWithManyNopsMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_1InstructionWithManyNops);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidTimeZoneException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdarg_0InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_0Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidTimeZoneException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdarg_1InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_1Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidTimeZoneException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdarg_2InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_2Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidTimeZoneException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdarg_3InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_3Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidTimeZoneException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdargInstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdargInstruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidTimeZoneException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdargSInstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdargSInstruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(InvalidTimeZoneException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdfldInstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdfldInstruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdsfldInstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdsfldInstruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotImplementedException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdlocInstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName, 
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdlocInstruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdloc_0InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_0Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdloc_1InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,			
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_1Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdloc_2InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_2Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void AnalyzeThrowExceptionFromLdloc_3InstructionMethod()
		{
			var method = AssemblyTests.GetMethod(
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName,
				ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace,
				ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_3Instruction);

			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(1, analyzer.LeakedExceptions.Count);
			Assert.IsTrue(analyzer.LeakedExceptions.ContainsException(typeof(NotSupportedException)));
		}
	}
}
