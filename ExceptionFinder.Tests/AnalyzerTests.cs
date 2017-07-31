using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Linq;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class AnalyzerTests : CoreTests
	{
		[TestMethod]
		public void CallGetYearInfoFromChineseLunisolarCalendar()
		{
			IMethodDeclaration method = AssemblyTests.GetMethod("mscorlib",
				"ChineseLunisolarCalendar", "System.Globalization", "GetYearInfo");

			MethodExceptionAnalyzer analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
		}

		[TestMethod]
		public void CallForwardCallToInvokeMemberOnRuntimeType()
		{
			IMethodDeclaration method = AssemblyTests.GetMethod("mscorlib",
				"RuntimeType", "System", "ForwardCallToInvokeMember");

			MethodExceptionAnalyzer analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
		}

		[TestMethod]
		public void CallSetDefaultDomainManagerOnAppDomain()
		{
			IMethodDeclaration method = AssemblyTests.GetMethod("mscorlib",
				"AppDomain", "System", "SetDefaultDomainManager");

			MethodExceptionAnalyzer analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();
		}

		[TestMethod]
		public void CallCloneOnICloneable()
		{
			IMethodDeclaration method = AssemblyTests.GetMethod("mscorlib",
				"ICloneable", "System", "Clone");

			MethodExceptionAnalyzer analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);		
		}

		[TestMethod]
		public void CallInternalEqualsOnObject()
		{
			IMethodDeclaration method = AssemblyTests.GetMethod("mscorlib",
				"Object", "System", "InternalEquals");

			MethodExceptionAnalyzer analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();

			Assert.AreEqual(0, analyzer.LeakedExceptions.Count);
		}

		[TestMethod]
		public void CallSetAccessControl()
		{
			IMethodDeclaration method = AssemblyTests.GetMethod("mscorlib",
				"RegistryKey", "Microsoft.Win32", "SetAccessControl");

			MethodExceptionAnalyzer analyzer = new MethodExceptionAnalyzer(method);
			analyzer.Analyze();			
		}
	}
}
