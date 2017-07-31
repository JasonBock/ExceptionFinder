using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Testing;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExceptionFinder.Tests
{
	[TestClass]
	public sealed class MethodAlreadyVisitedExceptionTests 
		: ExceptionTests<MethodAlreadyVisitedException, ArgumentException>
	{
		private const string Message = "That method was visited!";

		public MethodAlreadyVisitedExceptionTests()
			: base(MethodAlreadyVisitedExceptionTests.Message)
		{
		}

		[TestMethod]
		public void CreateException()
		{
			this.CreateExceptionTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessage()
		{
			this.CreateExceptionWithMessageTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessageAndInnerException()
		{
			this.CreateExceptionWithMessageAndInnerExceptionTest();
		}

		[TestMethod]
		public void RoundtripException()
		{
			this.RoundtripExceptionTest();
		}
	}
}
