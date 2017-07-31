using ExceptionFinder.Analyzers;
using ExceptionFinder.Extensions;
using ExceptionFinder.Tests.Scenarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace ExceptionFinder.Tests.Extensions
{
	[TestClass]
	public sealed class ITypeReferenceExtensionsTests : BaseTests
	{
		[TestMethod]
		public void TranslateNested()
		{
			var typeReference = (from IAssembly assembly in AssemblyTests.Manager.Assemblies
										where assembly.Name == "ExceptionFinder.Tests.Scenarios"
										from IModule module in assembly.Modules
										from ITypeDeclaration type in module.Types
										where type.Name == "NestedTypeScenarios"
										select type).FirstOrDefault();

			var owningType = (typeReference.NestedTypes[0] as ITypeReference).Translate();
			Assert.AreEqual(typeof(NestedTypeScenarios), owningType);
		}
	}
}
