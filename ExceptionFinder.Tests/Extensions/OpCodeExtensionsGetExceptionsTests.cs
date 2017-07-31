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
	public sealed class OpCodeExtensionsGetExceptionsTests : BaseTests
	{
		[TestMethod]
		public void GetExceptionsIncludeNone()
		{
			Assert.AreEqual(0, OpCodes.Add_Ovf.GetExceptions().Count);
		}

		[TestMethod]
		public void GetExceptionsForAdd()
		{
			Assert.AreEqual(0, OpCodes.Add.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForAddOvf()
		{
			var exceptions = OpCodes.Add_Ovf.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForAnd()
		{
			Assert.AreEqual(0, OpCodes.And.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForArglist()
		{
			Assert.AreEqual(0, OpCodes.Arglist.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBeq()
		{
			Assert.AreEqual(0, OpCodes.Beq.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBeqS()
		{
			Assert.AreEqual(0, OpCodes.Beq_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBge()
		{
			Assert.AreEqual(0, OpCodes.Bge.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBgeS()
		{
			Assert.AreEqual(0, OpCodes.Bge_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBgeUn()
		{
			Assert.AreEqual(0, OpCodes.Bge_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBgeUnS()
		{
			Assert.AreEqual(0, OpCodes.Bge_Un_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBgt()
		{
			Assert.AreEqual(0, OpCodes.Bgt.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBgtS()
		{
			Assert.AreEqual(0, OpCodes.Bgt_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBgtUn()
		{
			Assert.AreEqual(0, OpCodes.Bgt_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBgtUnS()
		{
			Assert.AreEqual(0, OpCodes.Bgt_Un_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBle()
		{
			Assert.AreEqual(0, OpCodes.Ble.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBleS()
		{
			Assert.AreEqual(0, OpCodes.Ble_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBleUn()
		{
			Assert.AreEqual(0, OpCodes.Ble_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBleUnS()
		{
			Assert.AreEqual(0, OpCodes.Ble_Un_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBlt()
		{
			Assert.AreEqual(0, OpCodes.Blt.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBltS()
		{
			Assert.AreEqual(0, OpCodes.Blt_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBltUn()
		{
			Assert.AreEqual(0, OpCodes.Blt_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBltUnS()
		{
			Assert.AreEqual(0, OpCodes.Blt_Un_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBneUn()
		{
			Assert.AreEqual(0, OpCodes.Bne_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBneUnS()
		{
			Assert.AreEqual(0, OpCodes.Bne_Un_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBox()
		{
			var exceptions = OpCodes.Box.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OutOfMemoryException)));
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForBr()
		{
			Assert.AreEqual(0, OpCodes.Br.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBrS()
		{
			Assert.AreEqual(0, OpCodes.Br_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBreak()
		{
			Assert.AreEqual(0, OpCodes.Break.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBrfalse()
		{
			Assert.AreEqual(0, OpCodes.Brfalse.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBrfalseS()
		{
			Assert.AreEqual(0, OpCodes.Brfalse_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBrtrue()
		{
			Assert.AreEqual(0, OpCodes.Brtrue.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForBrtrueS()
		{
			Assert.AreEqual(0, OpCodes.Brtrue_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForCall()
		{
			var exceptions = OpCodes.Call.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(MethodAccessException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingMethodException)));
			Assert.IsTrue(exceptions.Contains(typeof(SecurityException)));
		}

		[TestMethod]
		public void GetExceptionsForCalli()
		{
			var exceptions = OpCodes.Calli.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(SecurityException)));
		}

		[TestMethod]
		public void GetExceptionsForCallvirt()
		{
			var exceptions = OpCodes.Callvirt.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(MissingMethodException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
			Assert.IsTrue(exceptions.Contains(typeof(SecurityException)));
		}

		[TestMethod]
		public void GetExceptionsForCastclass()
		{
			var exceptions = OpCodes.Castclass.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(InvalidCastException)));
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForCeq()
		{
			Assert.AreEqual(0, OpCodes.Ceq.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForCgt()
		{
			Assert.AreEqual(0, OpCodes.Cgt.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForCgtUn()
		{
			Assert.AreEqual(0, OpCodes.Cgt_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForCkfinite()
		{
			var exceptions = OpCodes.Ckfinite.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArithmeticException)));
		}

		[TestMethod]
		public void GetExceptionsForClt()
		{
			Assert.AreEqual(0, OpCodes.Clt.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForCltUn()
		{
			Assert.AreEqual(0, OpCodes.Clt_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConstrained()
		{
			Assert.AreEqual(0, OpCodes.Constrained.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvI()
		{
			Assert.AreEqual(0, OpCodes.Conv_I.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvI1()
		{
			Assert.AreEqual(0, OpCodes.Conv_I1.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvI2()
		{
			Assert.AreEqual(0, OpCodes.Conv_I2.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvI4()
		{
			Assert.AreEqual(0, OpCodes.Conv_I4.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvI8()
		{
			Assert.AreEqual(0, OpCodes.Conv_I8.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI()
		{
			var exceptions = OpCodes.Conv_Ovf_I.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfIUn()
		{
			var exceptions = OpCodes.Conv_Ovf_I_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI1()
		{
			var exceptions = OpCodes.Conv_Ovf_I1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI1Un()
		{
			var exceptions = OpCodes.Conv_Ovf_I1_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI2()
		{
			var exceptions = OpCodes.Conv_Ovf_I2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI2Un()
		{
			var exceptions = OpCodes.Conv_Ovf_I2_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI4()
		{
			var exceptions = OpCodes.Conv_Ovf_I4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI4Un()
		{
			var exceptions = OpCodes.Conv_Ovf_I4_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI8()
		{
			var exceptions = OpCodes.Conv_Ovf_I8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfI8Un()
		{
			var exceptions = OpCodes.Conv_Ovf_I8_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU()
		{
			var exceptions = OpCodes.Conv_Ovf_U.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfUUn()
		{
			var exceptions = OpCodes.Conv_Ovf_U_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU1()
		{
			var exceptions = OpCodes.Conv_Ovf_U1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU1Un()
		{
			var exceptions = OpCodes.Conv_Ovf_U1_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU2()
		{
			var exceptions = OpCodes.Conv_Ovf_U2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU2Un()
		{
			var exceptions = OpCodes.Conv_Ovf_U2_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU4()
		{
			var exceptions = OpCodes.Conv_Ovf_U4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU4Un()
		{
			var exceptions = OpCodes.Conv_Ovf_U4_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU8()
		{
			var exceptions = OpCodes.Conv_Ovf_U8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvOvfU8Un()
		{
			var exceptions = OpCodes.Conv_Ovf_U8_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForConvRUn()
		{
			Assert.AreEqual(0, OpCodes.Conv_R_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvR4()
		{
			Assert.AreEqual(0, OpCodes.Conv_R4.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvR8()
		{
			Assert.AreEqual(0, OpCodes.Conv_R8.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvU()
		{
			Assert.AreEqual(0, OpCodes.Conv_U.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvU1()
		{
			Assert.AreEqual(0, OpCodes.Conv_U1.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvU2()
		{
			Assert.AreEqual(0, OpCodes.Conv_U2.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvU4()
		{
			Assert.AreEqual(0, OpCodes.Conv_U4.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForConvU8()
		{
			Assert.AreEqual(0, OpCodes.Conv_U8.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForCpblk()
		{
			var exceptions = OpCodes.Cpblk.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForCpobj()
		{
			var exceptions = OpCodes.Cpobj.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForDiv()
		{
			var exceptions = OpCodes.Div.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArithmeticException)));
			Assert.IsTrue(exceptions.Contains(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void GetExceptionsForDivUn()
		{
			var exceptions = OpCodes.Div_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void GetExceptionsForDup()
		{
			Assert.AreEqual(0, OpCodes.Dup.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForEndfilter()
		{
			Assert.AreEqual(0, OpCodes.Endfilter.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForEndfinally()
		{
			Assert.AreEqual(0, OpCodes.Endfinally.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForInitblk()
		{
			var exceptions = OpCodes.Initblk.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForInitobj()
		{
			Assert.AreEqual(0, OpCodes.Initobj.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForIsinst()
		{
			var exceptions = OpCodes.Isinst.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForJmp()
		{
			Assert.AreEqual(0, OpCodes.Jmp.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdarg()
		{
			Assert.AreEqual(0, OpCodes.Ldarg.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdarg0()
		{
			Assert.AreEqual(0, OpCodes.Ldarg_0.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdarg1()
		{
			Assert.AreEqual(0, OpCodes.Ldarg_1.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdarg2()
		{
			Assert.AreEqual(0, OpCodes.Ldarg_2.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdarg3()
		{
			Assert.AreEqual(0, OpCodes.Ldarg_3.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdargS()
		{
			Assert.AreEqual(0, OpCodes.Ldarg_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdarga()
		{
			Assert.AreEqual(0, OpCodes.Ldarga.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdargaS()
		{
			Assert.AreEqual(0, OpCodes.Ldarga_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI4()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI40()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_0.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI41()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_1.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI42()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_2.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI43()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_3.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI44()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_4.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI45()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_5.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI46()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_6.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI47()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_7.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI48()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_8.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI4M1()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_M1.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI4S()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I4_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcI8()
		{
			Assert.AreEqual(0, OpCodes.Ldc_I8.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcR4()
		{
			Assert.AreEqual(0, OpCodes.Ldc_R4.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdcR8()
		{
			Assert.AreEqual(0, OpCodes.Ldc_R8.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdelem()
		{
			var exceptions = OpCodes.Ldelem.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemI()
		{
			var exceptions = OpCodes.Ldelem_I.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemI1()
		{
			var exceptions = OpCodes.Ldelem_I1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemI2()
		{
			var exceptions = OpCodes.Ldelem_I2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemI4()
		{
			var exceptions = OpCodes.Ldelem_I4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemI8()
		{
			var exceptions = OpCodes.Ldelem_I8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemR4()
		{
			var exceptions = OpCodes.Ldelem_R4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemR8()
		{
			var exceptions = OpCodes.Ldelem_R8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemRef()
		{
			var exceptions = OpCodes.Ldelem_Ref.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemU1()
		{
			var exceptions = OpCodes.Ldelem_U1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemU2()
		{
			var exceptions = OpCodes.Ldelem_U2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelemU4()
		{
			var exceptions = OpCodes.Ldelem_U4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdelema()
		{
			var exceptions = OpCodes.Ldelema.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdfld()
		{
			var exceptions = OpCodes.Ldfld.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(FieldAccessException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingFieldException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdflda()
		{
			var exceptions = OpCodes.Ldflda.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(4, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(FieldAccessException)));
			Assert.IsTrue(exceptions.Contains(typeof(InvalidOperationException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingFieldException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdftn()
		{
			Assert.AreEqual(0, OpCodes.Ldftn.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdindI()
		{
			var exceptions = OpCodes.Ldind_I.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindI1()
		{
			var exceptions = OpCodes.Ldind_I1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindI2()
		{
			var exceptions = OpCodes.Ldind_I2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindI4()
		{
			var exceptions = OpCodes.Ldind_I4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindI8()
		{
			var exceptions = OpCodes.Ldind_I8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindR4()
		{
			var exceptions = OpCodes.Ldind_R4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindR8()
		{
			var exceptions = OpCodes.Ldind_R8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindRef()
		{
			var exceptions = OpCodes.Ldind_Ref.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindU1()
		{
			var exceptions = OpCodes.Ldind_U1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindU2()
		{
			var exceptions = OpCodes.Ldind_U2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdindU4()
		{
			var exceptions = OpCodes.Ldind_U4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdlen()
		{
			var exceptions = OpCodes.Ldlen.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLdloc()
		{
			var exceptions = OpCodes.Ldloc.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdloc0()
		{
			var exceptions = OpCodes.Ldloc_0.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdloc1()
		{
			var exceptions = OpCodes.Ldloc_1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdloc2()
		{
			var exceptions = OpCodes.Ldloc_2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdloc3()
		{
			var exceptions = OpCodes.Ldloc_3.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdlocS()
		{
			var exceptions = OpCodes.Ldloc_S.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdloca()
		{
			var exceptions = OpCodes.Ldloca.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdlocaS()
		{
			var exceptions = OpCodes.Ldloca_S.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(VerificationException)));
		}

		[TestMethod]
		public void GetExceptionsForLdnull()
		{
			Assert.AreEqual(0, OpCodes.Ldnull.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdobj()
		{
			var exceptions = OpCodes.Ldobj.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForLdsfld()
		{
			var exceptions = OpCodes.Ldsfld.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(FieldAccessException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingFieldException)));
		}

		[TestMethod]
		public void GetExceptionsForLdsflda()
		{
			var exceptions = OpCodes.Ldsflda.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(FieldAccessException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingFieldException)));
		}

		[TestMethod]
		public void GetExceptionsForLdstr()
		{
			Assert.AreEqual(0, OpCodes.Ldstr.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdtoken()
		{
			Assert.AreEqual(0, OpCodes.Ldtoken.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLdvirtftn()
		{
			var exceptions = OpCodes.Ldvirtftn.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForLeave()
		{
			Assert.AreEqual(0, OpCodes.Leave.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLeaveS()
		{
			Assert.AreEqual(0, OpCodes.Leave_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForLocalloc()
		{
			var exceptions = OpCodes.Localloc.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(StackOverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForMkrefany()
		{
			var exceptions = OpCodes.Mkrefany.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForMul()
		{
			Assert.AreEqual(0, OpCodes.Mul.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForMulOvf()
		{
			var exceptions = OpCodes.Mul_Ovf.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForMulOvfUn()
		{
			var exceptions = OpCodes.Mul_Ovf_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForNeg()
		{
			Assert.AreEqual(0, OpCodes.Neg.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForNewarr()
		{
			var exceptions = OpCodes.Newarr.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OutOfMemoryException)));
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForNewobj()
		{
			var exceptions = OpCodes.Newobj.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(InvalidOperationException)));
			Assert.IsTrue(exceptions.Contains(typeof(OutOfMemoryException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingMethodException)));
		}

		[TestMethod]
		public void GetExceptionsForNop()
		{
			Assert.AreEqual(0, OpCodes.Nop.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForNot()
		{
			Assert.AreEqual(0, OpCodes.Not.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForOr()
		{
			Assert.AreEqual(0, OpCodes.Or.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPop()
		{
			Assert.AreEqual(0, OpCodes.Pop.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefix1()
		{
			Assert.AreEqual(0, OpCodes.Prefix1.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefix2()
		{
			Assert.AreEqual(0, OpCodes.Prefix2.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefix3()
		{
			Assert.AreEqual(0, OpCodes.Prefix3.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefix4()
		{
			Assert.AreEqual(0, OpCodes.Prefix4.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefix5()
		{
			Assert.AreEqual(0, OpCodes.Prefix5.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefix6()
		{
			Assert.AreEqual(0, OpCodes.Prefix6.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefix7()
		{
			Assert.AreEqual(0, OpCodes.Prefix7.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForPrefixref()
		{
			Assert.AreEqual(0, OpCodes.Prefixref.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForReadonly()
		{
			Assert.AreEqual(0, OpCodes.Readonly.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForRefanytype()
		{
			Assert.AreEqual(0, OpCodes.Refanytype.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForRefanyval()
		{
			var exceptions = OpCodes.Refanyval.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(InvalidCastException)));
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForRem()
		{
			var exceptions = OpCodes.Rem.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArithmeticException)));
			Assert.IsTrue(exceptions.Contains(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void GetExceptionsForRemUn()
		{
			var exceptions = OpCodes.Rem_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(DivideByZeroException)));
		}

		[TestMethod]
		public void GetExceptionsForRet()
		{
			Assert.AreEqual(0, OpCodes.Ret.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForRethrow()
		{
			Assert.AreEqual(0, OpCodes.Rethrow.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForShl()
		{
			Assert.AreEqual(0, OpCodes.Shl.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForShr()
		{
			Assert.AreEqual(0, OpCodes.Shr.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForShrUn()
		{
			Assert.AreEqual(0, OpCodes.Shr_Un.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForSizeof()
		{
			Assert.AreEqual(0, OpCodes.Sizeof.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStarg()
		{
			Assert.AreEqual(0, OpCodes.Starg.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStargS()
		{
			Assert.AreEqual(0, OpCodes.Starg_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStelem()
		{
			var exceptions = OpCodes.Stelem.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemI()
		{
			var exceptions = OpCodes.Stelem_I.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemI1()
		{
			var exceptions = OpCodes.Stelem_I1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemI2()
		{
			var exceptions = OpCodes.Stelem_I2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemI4()
		{
			var exceptions = OpCodes.Stelem_I4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemI8()
		{
			var exceptions = OpCodes.Stelem_I8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemR4()
		{
			var exceptions = OpCodes.Stelem_R4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemR8()
		{
			var exceptions = OpCodes.Stelem_R8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStelemRef()
		{
			var exceptions = OpCodes.Stelem_Ref.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(ArrayTypeMismatchException)));
			Assert.IsTrue(exceptions.Contains(typeof(IndexOutOfRangeException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStfld()
		{
			var exceptions = OpCodes.Stfld.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(FieldAccessException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingFieldException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindI()
		{
			var exceptions = OpCodes.Stind_I.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindI1()
		{
			var exceptions = OpCodes.Stind_I1.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindI2()
		{
			var exceptions = OpCodes.Stind_I2.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindI4()
		{
			var exceptions = OpCodes.Stind_I4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindI8()
		{
			var exceptions = OpCodes.Stind_I8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindR4()
		{
			var exceptions = OpCodes.Stind_R4.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindR8()
		{
			var exceptions = OpCodes.Stind_R8.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStindRef()
		{
			var exceptions = OpCodes.Stind_Ref.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForStloc()
		{
			Assert.AreEqual(0, OpCodes.Stloc.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStloc0()
		{
			Assert.AreEqual(0, OpCodes.Stloc_0.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStloc1()
		{
			Assert.AreEqual(0, OpCodes.Stloc_1.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStloc2()
		{
			Assert.AreEqual(0, OpCodes.Stloc_2.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStloc3()
		{
			Assert.AreEqual(0, OpCodes.Stloc_3.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStlocS()
		{
			Assert.AreEqual(0, OpCodes.Stloc_S.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForStobj()
		{
			var exceptions = OpCodes.Stobj.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForStsfld()
		{
			var exceptions = OpCodes.Stsfld.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(FieldAccessException)));
			Assert.IsTrue(exceptions.Contains(typeof(MissingFieldException)));
		}

		[TestMethod]
		public void GetExceptionsForSub()
		{
			Assert.AreEqual(0, OpCodes.Sub.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForSubOvf()
		{
			var exceptions = OpCodes.Sub_Ovf.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForSubOvfUn()
		{
			var exceptions = OpCodes.Sub_Ovf_Un.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(OverflowException)));
		}

		[TestMethod]
		public void GetExceptionsForSwitch()
		{
			Assert.AreEqual(0, OpCodes.Switch.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForTailcall()
		{
			Assert.AreEqual(0, OpCodes.Tailcall.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForThrow()
		{
			var exceptions = OpCodes.Throw.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(1, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForUnaligned()
		{
			Assert.AreEqual(0, OpCodes.Unaligned.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForUnbox()
		{
			var exceptions = OpCodes.Unbox.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(3, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(InvalidCastException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
			Assert.IsTrue(exceptions.Contains(typeof(TypeLoadException)));
		}

		[TestMethod]
		public void GetExceptionsForUnboxAny()
		{
			var exceptions = OpCodes.Unbox_Any.GetExceptions(OpCodeFilters.IncludeAll);
			Assert.AreEqual(2, exceptions.Count);
			Assert.IsTrue(exceptions.Contains(typeof(InvalidCastException)));
			Assert.IsTrue(exceptions.Contains(typeof(NullReferenceException)));
		}

		[TestMethod]
		public void GetExceptionsForVolatile()
		{
			Assert.AreEqual(0, OpCodes.Volatile.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}

		[TestMethod]
		public void GetExceptionsForXor()
		{
			Assert.AreEqual(0, OpCodes.Xor.GetExceptions(OpCodeFilters.IncludeAll).Count);
		}
	}
}
