using ExceptionFinder.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests.Extensions
{
	[TestClass]
	public sealed class IDocumentationProviderExtensionsTests : BaseTests
	{
		[TestMethod]
		public void GetNavigator()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "ThrowReportedExceptions");
			var navigator = (method as IDocumentationProvider).GetNavigator();
			
			Assert.IsNotNull(navigator);
		}

		[TestMethod]
		public void GetNavigatorFromMethodThatHasNoDocumentation()
		{
			var method = AssemblyTests.GetMethod(BaseTests.TestScenariosNamespace,
				"ThrowingScenarios", BaseTests.TestScenariosNamespace, "CreateObjectThatThrowsOnConstruction");
			Assert.IsNull((method as IDocumentationProvider).GetNavigator());
		}

		[TestMethod]
		public void GetNavigatorFromNullReference()
		{
			Assert.IsNull((null as IDocumentationProvider).GetNavigator());
		}
	}
}
