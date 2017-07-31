using ExceptionFinder.Analyzers;
using ExceptionFinder.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Reflection.Emit;

namespace ExceptionFinder.Tests.Extensions
{
	[TestClass]
	public sealed class IInstructionExtensionsTests : BaseTests
	{
		[TestMethod]
		public void IsNativeMethodWithNativeMethod()
		{
			Assert.IsTrue(new MockInstruction()
			{
				Code = 0,
				Offset = 0,
				Value = new MockMethodDeclaration()
				{
					Body = null
				}
			}.IsNativeMethodCall());
		}

		[TestMethod]
		public void IsNativeMethodWithNonNativeMethod()
		{
			Assert.IsFalse(new MockInstruction()
			{
				Code = 0,
				Offset = 0,
				Value = new MockMethodDeclaration()
				{
					Body = new object()
				}
			}.IsNativeMethodCall());
		}

		[TestMethod]
		public void IsNativeMethodWithValueNotMethodDeclaration()
		{
			Assert.IsFalse(new MockInstruction()
			{
				Code = 0,
				Offset = 0,
				Value = 2
			}.IsNativeMethodCall());
		}
	}
}
