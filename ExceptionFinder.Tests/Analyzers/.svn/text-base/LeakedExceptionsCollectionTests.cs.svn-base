using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class LeakedExceptionsCollectionTests : BaseTests
	{
		[TestMethod]
		public void AddWithObjectType()
		{
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(new LeakedException(typeof(object)),
				new MockInstruction(), new MockMethodDeclaration(), 
				new List<CallStackInformation>().AsReadOnly());
			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.IsTrue(leakedExceptions.ContainsException(typeof(object)));
			Assert.AreEqual(0, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(1, leakedExceptions.NonExceptions.Count);
		}

		[TestMethod]
		public void AddWithObjectTypeAndFirstCollection()
		{
			var firstLeakedExceptions = new LeakedExceptionsCollection();
			firstLeakedExceptions.Add(new LeakedException(typeof(object)),
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());

			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(firstLeakedExceptions);

			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.IsTrue(leakedExceptions.ContainsException(typeof(object)));
			Assert.AreEqual(0, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(1, leakedExceptions.NonExceptions.Count);
		}

		[TestMethod]
		public void ContainsNonExceptionKeyThatDoesNotExist()
		{
			var leakedExceptions = new LeakedExceptionsCollection();
			Assert.IsFalse(leakedExceptions.ContainsKey(
				new LeakedException(typeof(string))));
		}

		[TestMethod]
		public void AddWithExceptionType()
		{
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(new LeakedException(typeof(Exception)),
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.IsTrue(leakedExceptions.ContainsException(typeof(Exception)));
			Assert.AreEqual(1, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, leakedExceptions.NonExceptions.Count);
		}

		[TestMethod]
		public void AddWithExceptionTypeAndFirstCollection()
		{
			var firstLeakedExceptions = new LeakedExceptionsCollection();
			firstLeakedExceptions.Add(new LeakedException(typeof(Exception)),
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());

			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(firstLeakedExceptions);

			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.IsTrue(leakedExceptions.ContainsException(typeof(Exception)));
			Assert.AreEqual(1, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, leakedExceptions.NonExceptions.Count);
		}

		[TestMethod]
		public void AddWithArgumentExceptionType()
		{
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(new LeakedException(typeof(ArgumentException)),
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.IsTrue(leakedExceptions.ContainsException(typeof(ArgumentException)));
			Assert.AreEqual(1, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, leakedExceptions.NonExceptions.Count);
		}

		[TestMethod]
		public void AddWithArgumentExceptionTypeAndFirstCollection()
		{
			var firstLeakedExceptions = new LeakedExceptionsCollection();
			firstLeakedExceptions.Add(new LeakedException(typeof(ArgumentException)),
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());

			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(firstLeakedExceptions);

			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.IsTrue(leakedExceptions.ContainsException(typeof(ArgumentException)));
			Assert.AreEqual(1, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, leakedExceptions.NonExceptions.Count);
		}

		[TestMethod]
		public void ContainsExceptionKey()
		{
			var leakedException = new LeakedException(typeof(NotSupportedException));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsTrue(leakedExceptions.ContainsKey(leakedException));
		}

		[TestMethod]
		public void ContainsExceptionKeyThatDoesNotExist()
		{
			var leakedExceptions = new LeakedExceptionsCollection();
			Assert.IsFalse(leakedExceptions.ContainsKey(
				new LeakedException(typeof(NotSupportedException))));
		}

		[TestMethod]
		public void ContainsNonExceptionKey()
		{
			var leakedException = new LeakedException(typeof(string));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsTrue(leakedExceptions.ContainsKey(leakedException));
		}
	
		[TestMethod]
		public void GetException()
		{
			var leakedException = new LeakedException(typeof(NotSupportedException));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsNotNull(leakedExceptions.Get(typeof(NotSupportedException)));
		}

		[TestMethod]
		public void GetExceptionThatDoesNotExistInCollection()
		{
			var leakedException = new LeakedException(typeof(NotSupportedException));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsNull(leakedExceptions.Get(typeof(NotImplementedException)));
		}

		[TestMethod]
		public void GetNonException()
		{
			var leakedException = new LeakedException(typeof(string));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsNotNull(leakedExceptions.Get(typeof(string)));
		}

		[TestMethod]
		public void GetNonExceptionThatDoesNotExistInCollection()
		{
			var leakedException = new LeakedException(typeof(string));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsNull(leakedExceptions.Get(typeof(Guid)));
		}
		
		[TestMethod]
		public void RemoveArgumentExceptionType()
		{
			var leakedExceptions = new LeakedExceptionsCollection();
			var leakedException = new LeakedException(typeof(ArgumentException));
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			leakedExceptions.Add(new LeakedException(typeof(object)),
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());

			Assert.AreEqual(2, leakedExceptions.Count);
			Assert.AreEqual(1, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(1, leakedExceptions.NonExceptions.Count);

			leakedExceptions.Remove(leakedException);

			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.AreEqual(0, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(1, leakedExceptions.NonExceptions.Count);
		}

		[TestMethod]
		public void RemoveObjectType()
		{
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(new LeakedException(typeof(ArgumentException)),
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			var leakedException = new LeakedException(typeof(object));
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());

			Assert.AreEqual(2, leakedExceptions.Count);
			Assert.AreEqual(1, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(1, leakedExceptions.NonExceptions.Count);

			leakedExceptions.Remove(leakedException);

			Assert.AreEqual(1, leakedExceptions.Count);
			Assert.AreEqual(1, leakedExceptions.Exceptions.Count);
			Assert.AreEqual(0, leakedExceptions.NonExceptions.Count);
		}
		
		[TestMethod]
		public void UpdateDocumentationStatusOnException()
		{
			var leakedException = new LeakedException(typeof(NotSupportedException), 
				new LeakedExceptionDiscoveryStatuses(false, false));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsTrue(leakedExceptions.UpdateDocumentationStatus(
				typeof(NotSupportedException), true));
			Assert.IsTrue(leakedException.DiscoveryStatuses.IsDocumented);
		}

		[TestMethod]
		public void UpdateDocumentationStatusOnExceptionThatDoesNotExistInCollection()
		{
			var leakedException = new LeakedException(typeof(NotSupportedException),
				new LeakedExceptionDiscoveryStatuses(false, false));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsFalse(leakedExceptions.UpdateDocumentationStatus(
				typeof(NotImplementedException), true));
			Assert.IsFalse(leakedException.DiscoveryStatuses.IsDocumented);
		}

		[TestMethod]
		public void UpdateDocumentationStatusOnNonException()
		{
			var leakedException = new LeakedException(typeof(string),
				new LeakedExceptionDiscoveryStatuses(false, false));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsTrue(leakedExceptions.UpdateDocumentationStatus(
				typeof(string), true));
			Assert.IsTrue(leakedException.DiscoveryStatuses.IsDocumented);
		}

		[TestMethod]
		public void UpdateDocumentationStatusOnNonExceptionThatDoesNotExistInCollection()
		{
			var leakedException = new LeakedException(typeof(string),
				new LeakedExceptionDiscoveryStatuses(false, false));
			var leakedExceptions = new LeakedExceptionsCollection();
			leakedExceptions.Add(leakedException,
				new MockInstruction(), new MockMethodDeclaration(),
				new List<CallStackInformation>().AsReadOnly());
			Assert.IsFalse(leakedExceptions.UpdateDocumentationStatus(
				typeof(Guid), true));
			Assert.IsFalse(leakedException.DiscoveryStatuses.IsDocumented);
		}
	}
}
