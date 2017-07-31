using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExceptionFinder.Tests
{
	/// <summary>
	/// Note: 
	/// http://msdn2.microsoft.com/en-us/magazine/cc163641.aspx
	/// http://bartdesmet.net/blogs/bart/archive/2006/04/04/clr-exception-handling-from-a-to-z-everything-you-didn-t-want-to-know-about-try-catch-finally-fault-filter.aspx
	/// </summary>
	[TestClass]
	public static class AssemblyTests
	{
		private const string FrameworkDirectory = @"%SystemRoot%\Microsoft.net\Framework";
		private const string ReferenceAssembliesDirectory = @"%ProgramFiles%\Reference Assemblies";
		public const string TestsAssemblyFileName = "ExceptionFinder.Tests.dll";
		public const string TestsScenariosAssemblyFileName = "ExceptionFinder.Tests.Scenarios.dll";
		public const string TestsFilterScenariosAssemblyFileName = "ExceptionFinder.Tests.FilterScenarios.dll";

		[AssemblyInitialize]
		public static void AssemblyInitialize(TestContext context)
		{
			var provider = new ApplicationManager(null);
			var cache = provider.GetService(
				typeof(IAssemblyCache)) as IAssemblyCache;
			cache.Directories.Clear();

			cache.Directories.Add(
				Environment.ExpandEnvironmentVariables(AssemblyTests.FrameworkDirectory));
			cache.Directories.Add(
				Environment.ExpandEnvironmentVariables(AssemblyTests.ReferenceAssembliesDirectory));

			AssemblyTests.Manager = provider.GetService(
				typeof(IAssemblyManager)) as IAssemblyManager;

			AssemblyTests.Manager.Symbols = true;
			AssemblyTests.Manager.Resolver = new AssemblyResolver(AssemblyTests.Manager, cache);
			AssemblyTests.Manager.LoadFile(AssemblyTests.TestsAssemblyFileName);
			AssemblyTests.Manager.LoadFile(AssemblyTests.TestsScenariosAssemblyFileName);
			AssemblyTests.Manager.LoadFile(AssemblyTests.TestsFilterScenariosAssemblyFileName);
			AssemblyTests.Initialize();
		}

		internal static IMethodDeclaration GetMethod(string assemblyName, string typeName, string typeNamespace, string methodName)
		{
			return (from IAssembly assembly in AssemblyTests.Manager.Assemblies
					  where assembly.Name == assemblyName
					  from ITypeDeclaration type in assembly.Modules[0].Types
					  where type.Name == typeName
					  where type.Namespace == typeNamespace
					  from IMethodDeclaration method in type.Methods
					  where method.Name == methodName
					  select method).FirstOrDefault();
		}

		private static void Initialize()
		{
			AssemblyTests.InitializeMscorlib();
			AssemblyTests.InitializeAssembly(new FaultAssemblyGenerator());
			AssemblyTests.InitializeAssembly(new ExceptionLocationLoadingAssemblyGenerator());
		}

		private static void InitializeAssembly(AssemblyGenerator generator)
		{
			generator.Generate();
			AssemblyTests.Manager.LoadFile(generator.Namespace + ".dll");
		}
		
		private static void InitializeMscorlib()
		{
			var method = AssemblyTests.GetMethod("ExceptionFinder.Tests",
				"FrameworkInitialization", "ExceptionFinder.Tests", "Initialize");
			var analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
		}
		
		private sealed class AssemblyResolver : IAssemblyResolver
		{
			private IAssemblyCache cache;
			private IAssemblyManager manager;

			public AssemblyResolver(IAssemblyManager manager, IAssemblyCache cache)
			{
				this.manager = manager;
				this.cache = cache;
			}

			public IAssembly Resolve(IAssemblyReference assemblyReference, string localPath)
			{
				return this.manager.LoadFile(
					this.cache.QueryLocation(assemblyReference, localPath));
			}
		}
		
		internal static IAssemblyManager Manager
		{
			get;
			private set;
		}
	}
}
