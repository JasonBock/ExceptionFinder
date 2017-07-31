using AssemblyVerifier;
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace ExceptionFinder.Tests
{
	internal abstract class AssemblyGenerator
	{
		internal AssemblyGenerator(string @namespace, string typeName)
			: base()
		{
			this.Namespace = @namespace;
			this.TypeName = typeName;
		}
		
		internal Assembly Generate()
		{
			var name = new AssemblyName();
			name.Name = this.Namespace;
			name.Version = new Version(1, 0, 0, 0);
			var fileName = name.Name + ".dll";

			var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
				 name, AssemblyBuilderAccess.Save);

			var moduleBuilder = assemblyBuilder.DefineDynamicModule(name.Name, fileName, false);

			var typeBuilder = moduleBuilder.DefineType(
				 this.Namespace + "." + this.TypeName,
				 TypeAttributes.Class | TypeAttributes.Public,
				 typeof(object));

			AssemblyGenerator.GenerateConstructor(typeBuilder);
			this.GenerateMethods(typeBuilder);
			typeBuilder.CreateType();
			assemblyBuilder.Save(fileName);
			AssemblyVerification.Verify(assemblyBuilder);

			return assemblyBuilder;
		}

		private static void GenerateConstructor(TypeBuilder typeBuilder)
		{
			var constructor = typeBuilder.DefineConstructor(
				 MethodAttributes.Public | MethodAttributes.SpecialName |
				 MethodAttributes.RTSpecialName,
				 CallingConventions.Standard, Type.EmptyTypes);

			var constructorMethod = typeof(object).GetConstructor(Type.EmptyTypes);
			var constructorGenerator = constructor.GetILGenerator();

			constructorGenerator.Emit(OpCodes.Ldarg_0);
			constructorGenerator.Emit(OpCodes.Call, constructorMethod);
			constructorGenerator.Emit(OpCodes.Ret);
		}

		protected abstract void GenerateMethods(TypeBuilder typeBuilder);
		
		internal string Namespace
		{
			get;
			private set;
		}

		internal string TypeName
		{
			get;
			private set;
		}
	}
}
