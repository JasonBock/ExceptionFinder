using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using Spackle.Testing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class ArgumentsExceptionTests
		: ExceptionTests<ArgumentsException, ArgumentException>
	{
		private const string Message = "What a bad move!";

		public ArgumentsExceptionTests()
			: base(ArgumentsExceptionTests.Message)
		{
		}

		[TestMethod]
		public void CreateException()
		{
			this.CreateExceptionTest();
		}

		[TestMethod]
		public void CreateExceptionWithParameters()
		{
			var exception = new ArgumentsException(
				new List<string>() { "x", "y" }.AsReadOnly());
			Assert.AreEqual(
				"Exception of type 'ExceptionFinder.Analyzers.ArgumentsException' was thrown.", 
				exception.Message);
			Assert.AreEqual(2, exception.ParameterNames.Count);
			Assert.IsTrue(exception.ParameterNames.Contains("x"));
			Assert.IsTrue(exception.ParameterNames.Contains("y"));
		}

		[TestMethod]
		public void CreateExceptionWithMessage()
		{
			this.CreateExceptionWithMessageTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessageAndParameters()
		{
			var exception = new ArgumentsException(ArgumentsExceptionTests.Message, 
				new List<string>() { "x", "y" }.AsReadOnly());
			Assert.AreEqual(ArgumentsExceptionTests.Message, exception.Message);
			Assert.AreEqual(2, exception.ParameterNames.Count);
			Assert.IsTrue(exception.ParameterNames.Contains("x"));
			Assert.IsTrue(exception.ParameterNames.Contains("y"));
		}

		[TestMethod]
		public void CreateExceptionWithMessageAndInnerException()
		{
			this.CreateExceptionWithMessageAndInnerExceptionTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessageInnerExceptionAndParameters()
		{
			var exception = new ArgumentsException(ArgumentsExceptionTests.Message, 
				new ArgumentException("Inner", "z"),
				new List<string>() { "x", "y" }.AsReadOnly());
			Assert.IsTrue(typeof(ArgumentException).IsAssignableFrom(exception.InnerException.GetType()));
			Assert.AreEqual(ArgumentsExceptionTests.Message, exception.Message);
			Assert.AreEqual(2, exception.ParameterNames.Count);
			Assert.IsTrue(exception.ParameterNames.Contains("x"));
			Assert.IsTrue(exception.ParameterNames.Contains("y"));
		}

		[TestMethod]
		public void RoundtripException()
		{
			this.RoundtripExceptionTest();
		}
	}
}
