using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class CallStackInformationTests : BaseTests
	{
		[TestMethod]
		public void Create()
		{
			var information = new CallStackInformation(
				new MockMethodDeclaration(), new MockInstruction());
			Assert.IsNotNull(information.Method);
			Assert.IsNotNull(information.Instruction);
		}

		[TestMethod]
		public void CreateWithOnlyMethod()
		{
			var information = new CallStackInformation(
				new MockMethodDeclaration());
			Assert.IsNotNull(information.Method);
			Assert.IsNull(information.Instruction);
		}

		[TestMethod]
		public void CreateWithMethodAndNullInstruction()
		{
			var information = new CallStackInformation(
				new MockMethodDeclaration(), null);
			Assert.IsNotNull(information.Method);
			Assert.IsNull(information.Instruction);
		}

		[TestMethod]
		public void CreateWithOnlyInstruction()
		{
			var information = new CallStackInformation(
				new MockInstruction());
			Assert.IsNull(information.Method);
			Assert.IsNotNull(information.Instruction);
		}

		[TestMethod]
		public void CreateWithInstructionAndNullMethod()
		{
			var information = new CallStackInformation(
				null, new MockInstruction());
			Assert.IsNull(information.Method);
			Assert.IsNotNull(information.Instruction);
		}

		[TestMethod, ExpectedException(typeof(ArgumentsException))]
		public void CreateWithBothParametersAsNull()
		{
			new CallStackInformation(null, null);
		}
	}
}
