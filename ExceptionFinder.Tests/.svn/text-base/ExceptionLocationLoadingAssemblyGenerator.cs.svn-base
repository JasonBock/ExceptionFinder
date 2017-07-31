using AssemblyVerifier;
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace ExceptionFinder.Tests
{
	internal sealed class ExceptionLocationLoadingAssemblyGenerator : AssemblyGenerator
	{
		internal const string MethodThrowExceptionFromLdfldInstruction =
			"ThrowExceptionFromLdfldInstruction";
		internal const string MethodThrowExceptionFromLdsfldInstruction =
			"ThrowExceptionFromLdsfldInstruction";
		internal const string MethodThrowExceptionFromLdlocInstruction =
			"ThrowExceptionFromLdlocInstruction";
		internal const string MethodThrowExceptionFromLdloc_0Instruction =
			"ThrowExceptionFromLdloc_0Instruction";
		internal const string MethodThrowExceptionFromLdloc_1Instruction =
			"ThrowExceptionFromLdloc_1Instruction";
		internal const string MethodThrowExceptionFromLdloc_2Instruction =
			"ThrowExceptionFromLdloc_2Instruction";
		internal const string MethodThrowExceptionFromLdloc_3Instruction =
			"ThrowExceptionFromLdloc_3Instruction";
		internal const string MethodThrowExceptionFromLdargInstruction =
			"ThrowExceptionFromLdargInstruction";
		internal const string MethodThrowExceptionFromLdargSInstruction =
			"ThrowExceptionFromLdargSInstruction";
		internal const string MethodThrowExceptionFromLdarg_0Instruction =
			"ThrowExceptionFromLdarg_0Instruction";
		internal const string MethodThrowExceptionFromLdarg_1Instruction =
			"ThrowExceptionFromLdarg_1Instruction";
		internal const string MethodThrowExceptionFromLdarg_2Instruction =
			"ThrowExceptionFromLdarg_2Instruction";
		internal const string MethodThrowExceptionFromLdarg_3Instruction =
			"ThrowExceptionFromLdarg_3Instruction";
		internal const string MethodThrowExceptionFromLdarg_1InstructionWithManyNops =
			"ThrowExceptionFromLdarg_1InstructionWithManyNops";

		internal const string ExceptionLocationLoadingNamespace = "ExceptionFinder.Tests.ExceptionLocationLoading";
		internal const string ExceptionLocationLoadingTypeName = "ExceptionLocationLoadingScenarios";

		internal ExceptionLocationLoadingAssemblyGenerator()
			: base(ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingNamespace, ExceptionLocationLoadingAssemblyGenerator.ExceptionLocationLoadingTypeName)
		{
		}

		protected override void GenerateMethods(TypeBuilder typeBuilder)
		{
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdfldInstruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdsfldInstruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdlocInstruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdloc_0Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdloc_1Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdloc_2Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdloc_3Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdargInstruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdargSInstruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdarg_0Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdarg_1Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdarg_2Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdarg_3Instruction(typeBuilder);
			ExceptionLocationLoadingAssemblyGenerator.GenerateMethodThrowExceptionFromLdarg_1InstructionWithManyNops(typeBuilder);
		}

		private static void GenerateMethodThrowExceptionFromLdarg_1InstructionWithManyNops(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_1InstructionWithManyNops,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				 null, new Type[] { typeof(InvalidTimeZoneException) });

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg_1);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Nop);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdarg_0Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_0Instruction,
				 MethodAttributes.Public | MethodAttributes.Static,
				 null, new Type[] { typeof(InvalidTimeZoneException) });

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg_0);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdarg_1Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_1Instruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				 null, new Type[] { typeof(InvalidTimeZoneException) });

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg_1);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdarg_2Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_2Instruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				 null, new Type[] { typeof(Guid), typeof(InvalidTimeZoneException) });

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg_2);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdarg_3Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdarg_3Instruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				 null, new Type[] { typeof(Guid), typeof(Guid), typeof(InvalidTimeZoneException) });

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg_3);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdargInstruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdargInstruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				 null, new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(InvalidTimeZoneException) });

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg, 4);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdargSInstruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdargSInstruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				 null, new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(InvalidTimeZoneException) });

			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg_S, 4);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdfldInstruction(TypeBuilder typeBuilder)
		{
			var instanceField = typeBuilder.DefineField("instanceField", typeof(NotImplementedException),
				FieldAttributes.Private);

			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdfldInstruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var ctor = typeof(NotImplementedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Ldarg_0);
			methodGenerator.Emit(OpCodes.Newobj, ctor);
			methodGenerator.Emit(OpCodes.Stfld, instanceField);
			methodGenerator.Emit(OpCodes.Ldarg_0);
			methodGenerator.Emit(OpCodes.Ldfld, instanceField);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdsfldInstruction(TypeBuilder typeBuilder)
		{
			var staticField = typeBuilder.DefineField("staticField", typeof(NotImplementedException),
				FieldAttributes.Private | FieldAttributes.Static);

			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdsfldInstruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var ctor = typeof(NotImplementedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.Emit(OpCodes.Newobj, ctor);
			methodGenerator.Emit(OpCodes.Stsfld, staticField);
			methodGenerator.Emit(OpCodes.Ldsfld, staticField);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdlocInstruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdlocInstruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var ctor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			var local = methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.Emit(OpCodes.Newobj, ctor);
			methodGenerator.Emit(OpCodes.Stloc, local);
			methodGenerator.Emit(OpCodes.Ldloc, local);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdloc_0Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_0Instruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var ctor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.Emit(OpCodes.Newobj, ctor);
			methodGenerator.Emit(OpCodes.Stloc_0);
			methodGenerator.Emit(OpCodes.Ldloc_0);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdloc_1Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_1Instruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var ctor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.Emit(OpCodes.Newobj, ctor);
			methodGenerator.Emit(OpCodes.Stloc_1);
			methodGenerator.Emit(OpCodes.Ldloc_1);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdloc_2Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_2Instruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var ctor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.Emit(OpCodes.Newobj, ctor);
			methodGenerator.Emit(OpCodes.Stloc_2);
			methodGenerator.Emit(OpCodes.Ldloc_2);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}

		private static void GenerateMethodThrowExceptionFromLdloc_3Instruction(TypeBuilder typeBuilder)
		{
			var methodBuilder = typeBuilder.DefineMethod(
				 ExceptionLocationLoadingAssemblyGenerator.MethodThrowExceptionFromLdloc_3Instruction,
				 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var ctor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);
			var methodGenerator = methodBuilder.GetILGenerator();
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.DeclareLocal(typeof(NotSupportedException));
			methodGenerator.Emit(OpCodes.Newobj, ctor);
			methodGenerator.Emit(OpCodes.Stloc_3);
			methodGenerator.Emit(OpCodes.Ldloc_3);
			methodGenerator.Emit(OpCodes.Throw);
			methodGenerator.Emit(OpCodes.Ret);
		}
	}
}
