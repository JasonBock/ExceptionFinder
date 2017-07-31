using ExceptionFinder.Analyzers;
using ExceptionFinder.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Reflection.Emit;
using System.Security;

namespace ExceptionFinder.Tests.Extensions
{
	[TestClass]
	public sealed class OpCodeExtensionsGetLoadLocalIndexTests : BaseTests
	{
		[TestMethod]
		public void GetLoadLocalIndexForLdloc0()
		{
			Assert.AreEqual(0, OpCodes.Ldloc_0.GetLoadLocalIndex(
				new MockInstruction()
				{
					Code = 0,
					Offset = 0,
					Value = 0
				}));
		}

		[TestMethod]
		public void GetLoadLocalIndexForLdloc1()
		{
			Assert.AreEqual(1, OpCodes.Ldloc_1.GetLoadLocalIndex(
				new MockInstruction()
				{
					Code = 0,
					Offset = 0,
					Value = 0
				}));
		}

		[TestMethod]
		public void GetLoadLocalIndexForLdloc2()
		{
			Assert.AreEqual(2, OpCodes.Ldloc_2.GetLoadLocalIndex(
				new MockInstruction()
				{
					Code = 0,
					Offset = 0,
					Value = 0
				}));
		}

		[TestMethod]
		public void GetLoadLocalIndexForLdloc3()
		{
			Assert.AreEqual(3, OpCodes.Ldloc_3.GetLoadLocalIndex(
				new MockInstruction()
				{
					Code = 0,
					Offset = 0,
					Value = 0
				}));
		}

		[TestMethod]
		public void GetLoadLocalIndexForLdlocS()
		{
			Assert.AreEqual(10, OpCodes.Ldloc_S.GetLoadLocalIndex(
				new MockInstruction()
				{
					Code = 0,
					Offset = 0,
					Value = 10
				}));
		}

		[TestMethod]
		public void GetLoadLocalIndexForLdloc()
		{
			Assert.AreEqual(20, OpCodes.Ldloc.GetLoadLocalIndex(
				new MockInstruction()
				{
					Code = 0,
					Offset = 0,
					Value = 20
				}));
		}
	}
}
