using AssemblyVerifier;
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace ExceptionFinder.Tests
{
	internal sealed class FaultAssemblyGenerator : AssemblyGenerator
	{
		internal const string MethodTryWithExceptionAndFaultWithDifferentException = 
			"TryWithExceptionAndFaultWithDifferentException";
		internal const string MethodTryWithExceptionAndFaultWithNoException = 
			"TryWithExceptionAndFaultWithNoException";
		internal const string MethodTryWithExceptionAndFaultWithSameException =
			"TryWithExceptionAndFaultWithSameException";
		internal const string MethodTryWithNoExceptionAndFaultWithException = 
			"TryWithNoExceptionAndFaultWithException";
		internal const string MethodTryWithNoExceptionAndFaultWithNoException =
			"TryWithNoExceptionAndFaultWithNoException";
		internal const string FaultNamespace = "ExceptionFinder.Tests.Faults";
		internal const string FaultTypeName = "FaultScenarios";
		
		internal FaultAssemblyGenerator()
			: base(FaultAssemblyGenerator.FaultNamespace, FaultAssemblyGenerator.FaultTypeName)
		{
		}

		protected override void GenerateMethods(TypeBuilder typeBuilder)
		{
			FaultAssemblyGenerator.GenerateTryWithExceptionAndFaultWithDifferentException(typeBuilder);
			FaultAssemblyGenerator.GenerateTryWithExceptionAndFaultWithNoException(typeBuilder);
			FaultAssemblyGenerator.GenerateTryWithExceptionAndFaultWithSameException(typeBuilder);
			FaultAssemblyGenerator.GenerateTryWithNoExceptionAndFaultWithException(typeBuilder);
			FaultAssemblyGenerator.GenerateTryWithNoExceptionAndFaultWithNoException(typeBuilder);
		}

		private static void GenerateTryWithNoExceptionAndFaultWithNoException(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 FaultAssemblyGenerator.MethodTryWithNoExceptionAndFaultWithNoException,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.BeginExceptionBlock();
			methodGenerator.BeginFaultBlock();
			methodGenerator.EndExceptionBlock();
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateTryWithNoExceptionAndFaultWithException(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 FaultAssemblyGenerator.MethodTryWithNoExceptionAndFaultWithException,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var notImplementedCtor = typeof(NotImplementedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.BeginExceptionBlock();
			methodGenerator.BeginFaultBlock();
			methodGenerator.Emit(OpCodes.Newobj, notImplementedCtor);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.EndExceptionBlock();
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateTryWithExceptionAndFaultWithSameException(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 FaultAssemblyGenerator.MethodTryWithExceptionAndFaultWithSameException,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var notSupportedCtor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.BeginExceptionBlock();
			methodGenerator.Emit(OpCodes.Newobj, notSupportedCtor);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.BeginFaultBlock();
			methodGenerator.Emit(OpCodes.Newobj, notSupportedCtor);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.EndExceptionBlock();
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateTryWithExceptionAndFaultWithNoException(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 FaultAssemblyGenerator.MethodTryWithExceptionAndFaultWithNoException,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var notSupportedCtor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.BeginExceptionBlock();
			methodGenerator.Emit(OpCodes.Newobj, notSupportedCtor);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.BeginFaultBlock();
			methodGenerator.EndExceptionBlock();
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateTryWithExceptionAndFaultWithDifferentException(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 FaultAssemblyGenerator.MethodTryWithExceptionAndFaultWithDifferentException, 
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var notSupportedCtor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var notImplementedCtor = typeof(NotImplementedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.BeginExceptionBlock();
			methodGenerator.Emit(OpCodes.Newobj, notSupportedCtor);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.BeginFaultBlock();
			methodGenerator.Emit(OpCodes.Newobj, notImplementedCtor);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.EndExceptionBlock();
			methodGenerator.Emit(OpCodes.Ret);
		}
	}
}
