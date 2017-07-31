using ExceptionFinder.Analyzers;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using System.Security;

namespace ExceptionFinder.Extensions
{
	internal static class OpCodeExtensions
	{
		private static Dictionary<OpCode, ReadOnlyCollection<Type>> exceptions = new Dictionary<OpCode, ReadOnlyCollection<Type>>()
			{
				{ OpCodes.Box, new List<Type>() 
					{ typeof(OutOfMemoryException), 
					  typeof(TypeLoadException) 
					 }.AsReadOnly() },
				{ OpCodes.Call, new List<Type>() 
					{ typeof(SecurityException), 
					  typeof(MethodAccessException),
					  typeof(MissingMethodException) 
					 }.AsReadOnly() },
				{ OpCodes.Calli, new List<Type>() { typeof(SecurityException) }.AsReadOnly() },
				{ OpCodes.Callvirt, new List<Type>() 
					{ typeof(SecurityException), 
					  typeof(NullReferenceException),
					  typeof(MissingMethodException) 
					 }.AsReadOnly() },
				{ OpCodes.Castclass, new List<Type>() 
					{ typeof(InvalidCastException), 
					  typeof(TypeLoadException)
					 }.AsReadOnly() },
				{ OpCodes.Ckfinite, new List<Type>() { typeof(ArithmeticException) }.AsReadOnly() },
				{ OpCodes.Cpblk, new List<Type>() { typeof(NullReferenceException) }.AsReadOnly() },
				{ OpCodes.Cpobj, new List<Type>() 
					{ typeof(NullReferenceException), 
					  typeof(TypeLoadException)
					 }.AsReadOnly() },
				{ OpCodes.Div, new List<Type>() 
					{ typeof(ArithmeticException),
					  typeof(DivideByZeroException)
					}.AsReadOnly() },
				{ OpCodes.Div_Un, new List<Type>() { typeof(DivideByZeroException) }.AsReadOnly() },
				{ OpCodes.Initblk, new List<Type>() { typeof(NullReferenceException) }.AsReadOnly() },
				{ OpCodes.Isinst, new List<Type>() { typeof(TypeLoadException) }.AsReadOnly() },
				{ OpCodes.Ldelema, new List<Type>() 
					{ typeof(ArrayTypeMismatchException),
					  typeof(IndexOutOfRangeException),
					  typeof(NullReferenceException)
					}.AsReadOnly() },
				{ OpCodes.Ldfld, new List<Type>() 
					{ typeof(FieldAccessException),
					  typeof(MissingFieldException),
					  typeof(NullReferenceException)
					}.AsReadOnly() },
				{ OpCodes.Ldflda, new List<Type>() 
					{ typeof(FieldAccessException),
					  typeof(InvalidOperationException),
					  typeof(MissingFieldException),
					  typeof(NullReferenceException)
					}.AsReadOnly() },
				{ OpCodes.Ldlen, new List<Type>() { typeof(NullReferenceException) }.AsReadOnly() },
				{ OpCodes.Ldobj, new List<Type>() 
					{ typeof(NullReferenceException),
					  typeof(TypeLoadException)
					}.AsReadOnly() },
				{ OpCodes.Ldsfld, new List<Type>() 
					{ typeof(FieldAccessException),
					  typeof(MissingFieldException)
					}.AsReadOnly() },
				{ OpCodes.Ldsflda, new List<Type>() 
					{ typeof(FieldAccessException),
					  typeof(MissingFieldException)
					}.AsReadOnly() },
				{ OpCodes.Ldvirtftn, new List<Type>() { typeof(NullReferenceException) }.AsReadOnly() },
				{ OpCodes.Localloc, new List<Type>() { typeof(StackOverflowException) }.AsReadOnly() },
				{ OpCodes.Mkrefany, new List<Type>() { typeof(TypeLoadException) }.AsReadOnly() },
				{ OpCodes.Newarr, new List<Type>() 
					{ typeof(OutOfMemoryException),
					  typeof(OverflowException)
					}.AsReadOnly() },
				{ OpCodes.Newobj, new List<Type>() 
					{ typeof(InvalidOperationException),
					  typeof(OutOfMemoryException),
					  typeof(MissingMethodException)
					}.AsReadOnly() },
				{ OpCodes.Refanyval, new List<Type>() 
					{ typeof(InvalidCastException),
					  typeof(TypeLoadException)
					}.AsReadOnly() },
				{ OpCodes.Rem, new List<Type>() 
					{ typeof(ArithmeticException),
					  typeof(DivideByZeroException)
					}.AsReadOnly() },
				{ OpCodes.Rem_Un, new List<Type>() { typeof(DivideByZeroException) }.AsReadOnly() },
				{ OpCodes.Stfld, new List<Type>() 
					{ typeof(FieldAccessException),
					  typeof(NullReferenceException),
					  typeof(MissingFieldException)
					}.AsReadOnly() },
				{ OpCodes.Stobj, new List<Type>() 
					{ typeof(NullReferenceException),
					  typeof(TypeLoadException)
					}.AsReadOnly() },
				{ OpCodes.Stsfld, new List<Type>() 
					{ typeof(FieldAccessException),
					  typeof(MissingFieldException)
					}.AsReadOnly() },
				{ OpCodes.Throw, new List<Type>() { typeof(NullReferenceException) }.AsReadOnly() },
				{ OpCodes.Unbox, new List<Type>() 
					{ typeof(InvalidCastException), 
					  typeof(NullReferenceException),
					  typeof(TypeLoadException),
					 }.AsReadOnly() },
				{ OpCodes.Unbox_Any, new List<Type>() 
					{ typeof(InvalidCastException), 
					  typeof(NullReferenceException)
					 }.AsReadOnly() },
			};

		internal static ReadOnlyCollection<Type> GetExceptions(this OpCode @this)
		{
			return @this.GetExceptions(OpCodeFilters.IncludeNone);
		}
		
		internal static ReadOnlyCollection<Type> GetExceptions(this OpCode @this, OpCodeFilters filters)
		{
			return (filters.ContainsFlag(OpCodeFilters.IncludeOverflow) && @this.IsOverflow()) ? new List<Type>() { typeof(OverflowException) }.AsReadOnly() :
				(filters.ContainsFlag(OpCodeFilters.IncludeLoadValueIndirect) && @this.IsLoadValueIndirect()) ? new List<Type>() { typeof(NullReferenceException) }.AsReadOnly() :
				(filters.ContainsFlag(OpCodeFilters.IncludeLoadLocal) && @this.IsLoadLocal()) ? new List<Type>() { typeof(VerificationException) }.AsReadOnly() :
				(filters.ContainsFlag(OpCodeFilters.IncludeLoadLocalAddress) && @this.IsLoadLocalAddress()) ? new List<Type>() { typeof(VerificationException) }.AsReadOnly() :
				(filters.ContainsFlag(OpCodeFilters.IncludeStoreValueIndirect) && @this.IsStoreValueIndirect()) ? new List<Type>() { typeof(NullReferenceException) }.AsReadOnly() :
				(filters.ContainsFlag(OpCodeFilters.IncludeLoadElement) && @this.IsLoadElement()) ? new List<Type>() { typeof(IndexOutOfRangeException), typeof(NullReferenceException) }.AsReadOnly() :
				(filters.ContainsFlag(OpCodeFilters.IncludeStoreElement) && @this.IsStoreElement()) ? new List<Type>() { typeof(ArrayTypeMismatchException), typeof(IndexOutOfRangeException), typeof(NullReferenceException) }.AsReadOnly() :
				(filters.ContainsFlag(OpCodeFilters.IncludeMiscellaneous) && OpCodeExtensions.exceptions.ContainsKey(@this)) ?
					OpCodeExtensions.exceptions[@this] :
					new List<Type>().AsReadOnly();
		}

		internal static int GetLoadArgumentIndex(this OpCode @this, IInstruction instruction)
		{
			var index = -1;

			if(@this == OpCodes.Ldarg_0)
			{
				index = 0;
			}
			else if(@this == OpCodes.Ldarg_1)
			{
				index = 1;
			}
			else if(@this == OpCodes.Ldarg_2)
			{
				index = 2;
			}
			else if(@this == OpCodes.Ldarg_3)
			{
				index = 3;
			}
			else
			{
				index = (int)instruction.Value;
			}

			return index;
		}

		internal static int GetLoadLocalIndex(this OpCode @this, IInstruction instruction)
		{
			var index = -1;

			if(@this == OpCodes.Ldloc_0)
			{
				index = 0;
			}
			else if(@this == OpCodes.Ldloc_1)
			{
				index = 1;
			}
			else if(@this == OpCodes.Ldloc_2)
			{
				index = 2;
			}
			else if(@this == OpCodes.Ldloc_3)
			{
				index = 3;
			}
			else
			{
				index = (int)instruction.Value;
			}

			return index;
		}

		internal static bool IsLoadArgument(this OpCode @this)
		{
			return (@this == OpCodes.Ldarg || @this == OpCodes.Ldarg_0 ||
				@this == OpCodes.Ldarg_1 || @this == OpCodes.Ldarg_2 ||
				@this == OpCodes.Ldarg_3 || @this == OpCodes.Ldarg_S);
		}

		internal static bool IsLoadElement(this OpCode @this)
		{
			return (@this == OpCodes.Ldelem || @this == OpCodes.Ldelem_I ||
				@this == OpCodes.Ldelem_I1 || @this == OpCodes.Ldelem_I2 ||
				@this == OpCodes.Ldelem_I4 || @this == OpCodes.Ldelem_I8 ||
				@this == OpCodes.Ldelem_R4 || @this == OpCodes.Ldelem_R8 ||
				@this == OpCodes.Ldelem_Ref || @this == OpCodes.Ldelem_U1 ||
				@this == OpCodes.Ldelem_U2 || @this == OpCodes.Ldelem_U4);
		}

		internal static bool IsLoadField(this OpCode @this)
		{
			return (@this == OpCodes.Ldfld || @this == OpCodes.Ldsfld);
		}

		internal static bool IsLoadLocal(this OpCode @this)
		{
			return (@this == OpCodes.Ldloc || @this == OpCodes.Ldloc_0 ||
				@this == OpCodes.Ldloc_1 || @this == OpCodes.Ldloc_2 ||
				@this == OpCodes.Ldloc_3 || @this == OpCodes.Ldloc_S);
		}

		internal static bool IsLoadLocalAddress(this OpCode @this)
		{
			return (@this == OpCodes.Ldloca || @this == OpCodes.Ldloca_S);
		}

		internal static bool IsLoadValueIndirect(this OpCode @this)
		{
			return (@this == OpCodes.Ldind_I || @this == OpCodes.Ldind_I1 ||
				@this == OpCodes.Ldind_I2 || @this == OpCodes.Ldind_I4 ||
				@this == OpCodes.Ldind_I8 || @this == OpCodes.Ldind_U1 ||
				@this == OpCodes.Ldind_U2 || @this == OpCodes.Ldind_U4 ||
				@this == OpCodes.Ldind_R4 || @this == OpCodes.Ldind_R8 ||
				@this == OpCodes.Ldind_Ref);
		}

		internal static bool IsOverflow(this OpCode @this)
		{
			return (@this == OpCodes.Add_Ovf || @this == OpCodes.Add_Ovf_Un ||
				@this == OpCodes.Conv_Ovf_I || @this == OpCodes.Conv_Ovf_I_Un ||
				@this == OpCodes.Conv_Ovf_I1 || @this == OpCodes.Conv_Ovf_I1_Un ||
				@this == OpCodes.Conv_Ovf_I2 || @this == OpCodes.Conv_Ovf_I2_Un ||
				@this == OpCodes.Conv_Ovf_I4 || @this == OpCodes.Conv_Ovf_I4_Un ||
				@this == OpCodes.Conv_Ovf_I8 || @this == OpCodes.Conv_Ovf_I8_Un ||
				@this == OpCodes.Conv_Ovf_U || @this == OpCodes.Conv_Ovf_U_Un ||
				@this == OpCodes.Conv_Ovf_U1 || @this == OpCodes.Conv_Ovf_U1_Un ||
				@this == OpCodes.Conv_Ovf_U2 || @this == OpCodes.Conv_Ovf_U2_Un ||
				@this == OpCodes.Conv_Ovf_U4 || @this == OpCodes.Conv_Ovf_U4_Un ||
				@this == OpCodes.Conv_Ovf_U8 || @this == OpCodes.Conv_Ovf_U8_Un ||
				@this == OpCodes.Mul_Ovf || @this == OpCodes.Mul_Ovf_Un ||
				@this == OpCodes.Sub_Ovf || @this == OpCodes.Sub_Ovf_Un);
		}

		internal static bool IsStoreElement(this OpCode @this)
		{
			return (@this == OpCodes.Stelem || @this == OpCodes.Stelem_I ||
				@this == OpCodes.Stelem_I1 || @this == OpCodes.Stelem_I2 ||
				@this == OpCodes.Stelem_I4 || @this == OpCodes.Stelem_I8 ||
				@this == OpCodes.Stelem_R4 || @this == OpCodes.Stelem_R8 ||
				@this == OpCodes.Stelem_Ref);
		}

		internal static bool IsStoreValueIndirect(this OpCode @this)
		{
			return (@this == OpCodes.Stind_I || @this == OpCodes.Stind_I1 ||
				@this == OpCodes.Stind_I2 || @this == OpCodes.Stind_I4 ||
				@this == OpCodes.Stind_I8 || @this == OpCodes.Stind_R4 || 
				@this == OpCodes.Stind_R8 || @this == OpCodes.Stind_Ref);
		}
	}
}
