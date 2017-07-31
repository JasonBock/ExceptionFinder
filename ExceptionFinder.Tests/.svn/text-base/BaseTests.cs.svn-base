using ExceptionFinder.Analyzers;
using ExceptionFinder.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using Spackle.Testing;
using System;
using System.Collections.Generic;

namespace ExceptionFinder.Tests
{
	[TestClass]
	public class BaseTests : CoreTests
	{
		protected const string TestFilterScenariosNamespace = "ExceptionFinder.Tests.FilterScenarios";
		protected const string TestScenariosNamespace = "ExceptionFinder.Tests.Scenarios";
		
		internal void PrintFoundExceptions(LeakedExceptionsCollection foundExceptions)
		{
			foreach(var pair in foundExceptions)
			{
				this.TestContext.WriteLine(pair.Key.Type.FullName);
				
				foreach(var location in pair.Value)
				{
					var container = (location.Method.DeclaringType as ITypeDeclaration).Translate();
					this.TestContext.WriteLine("\tAssembly: " + container.Assembly.FullName);
					this.TestContext.WriteLine("\tType: " + container.FullName);
					this.TestContext.WriteLine("\tMethod: " + location.Method.Name);
					this.TestContext.WriteLine("\tLocation: " + location.Instruction.Offset);
				}
			}
		}
	}
}
