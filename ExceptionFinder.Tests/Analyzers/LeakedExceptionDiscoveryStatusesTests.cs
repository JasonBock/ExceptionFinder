using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class LeakedExceptionDiscoveryStatusesTests : BaseTests
	{
		[TestMethod]
		public void Create()
		{
			var statuses = new LeakedExceptionDiscoveryStatuses();
			Assert.IsFalse(statuses.IsDocumented);
			Assert.IsFalse(statuses.WasFoundThroughAnalysis);
		}

		[TestMethod]
		public void CreateWithParameters()
		{
			var statuses = new LeakedExceptionDiscoveryStatuses(true, true);
			Assert.IsTrue(statuses.IsDocumented);
			Assert.IsTrue(statuses.WasFoundThroughAnalysis);
		}

		[TestMethod]
		public void CreateAndChange()
		{
			var statuses = new LeakedExceptionDiscoveryStatuses(true, true);
			statuses.IsDocumented = false;
			statuses.WasFoundThroughAnalysis = false;
			Assert.IsFalse(statuses.IsDocumented);
			Assert.IsFalse(statuses.WasFoundThroughAnalysis);
		}
		
		[TestMethod]
		public void CheckForEquality()
		{
			var statusesOne = new LeakedExceptionDiscoveryStatuses(false, true);
			var statusesTwo = new LeakedExceptionDiscoveryStatuses(false, true);
			
			Assert.AreEqual(statusesOne, statusesTwo);
			Assert.IsTrue(statusesOne == statusesTwo);
			Assert.IsFalse(statusesOne != statusesTwo);
		}

		[TestMethod]
		public void CheckForEqualityWithNulls()
		{
			var statuses = new LeakedExceptionDiscoveryStatuses(false, true);

			Assert.IsFalse(statuses == null);
			Assert.IsFalse((null as LeakedExceptionDiscoveryStatuses) == statuses);
		}

		[TestMethod]
		public void CheckForInequality()
		{
			var statusesOne = new LeakedExceptionDiscoveryStatuses(false, true);
			var statusesTwo = new LeakedExceptionDiscoveryStatuses(true, true);

			Assert.AreNotEqual(statusesOne, statusesTwo);
			Assert.IsFalse(statusesOne == statusesTwo);
			Assert.IsTrue(statusesOne != statusesTwo);
		}

		[TestMethod]
		public void CheckForInequalityWithNulls()
		{
			var statuses = new LeakedExceptionDiscoveryStatuses(false, true);

			Assert.IsTrue(statuses != null);
			Assert.IsTrue((null as LeakedExceptionDiscoveryStatuses) != statuses);
		}
	}
}
