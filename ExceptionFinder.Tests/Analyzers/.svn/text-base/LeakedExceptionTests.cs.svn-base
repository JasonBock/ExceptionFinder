using ExceptionFinder.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExceptionFinder.Tests.Analyzers
{
	[TestClass]
	public sealed class LeakedExceptionTests : BaseTests
	{
		[TestMethod]
		public void CheckForEquality()
		{
			var leakedOne = new LeakedException(typeof(NotImplementedException), 
				new LeakedExceptionDiscoveryStatuses(true, false));

			var leakedTwo = new LeakedException(typeof(NotImplementedException),
				new LeakedExceptionDiscoveryStatuses(false, false));

			var leakedThree = new LeakedException(typeof(NotSupportedException),
				new LeakedExceptionDiscoveryStatuses(true, false));

			var leakedFour = new LeakedException(typeof(NotImplementedException),
				new LeakedExceptionDiscoveryStatuses(true, false));
				
			Assert.AreNotEqual(leakedOne, leakedTwo);
			Assert.AreNotEqual(leakedOne, leakedThree);
			Assert.AreEqual(leakedOne, leakedFour);
			Assert.AreNotEqual(leakedTwo, leakedThree);
			Assert.AreNotEqual(leakedTwo, leakedFour);
			Assert.AreNotEqual(leakedThree, leakedFour);
		}

		[TestMethod]
		public void CheckForEqualityViaOperation()
		{
			var leakedOne = new LeakedException(typeof(NotImplementedException),
				new LeakedExceptionDiscoveryStatuses(true, false));

			var leakedTwo = new LeakedException(typeof(NotImplementedException),
				new LeakedExceptionDiscoveryStatuses(false, false));

			var leakedThree = new LeakedException(typeof(NotSupportedException),
				new LeakedExceptionDiscoveryStatuses(true, false));

			var leakedFour = new LeakedException(typeof(NotImplementedException),
				new LeakedExceptionDiscoveryStatuses(true, false));

			Assert.IsFalse(leakedOne == leakedTwo);
			Assert.IsTrue(leakedOne != leakedTwo);
			Assert.IsFalse(leakedOne == leakedThree);
			Assert.IsTrue(leakedOne != leakedThree);
			Assert.IsTrue(leakedOne == leakedFour);
			Assert.IsFalse(leakedOne != leakedFour);
			Assert.IsFalse(leakedTwo == leakedThree);
			Assert.IsTrue(leakedTwo != leakedThree);
			Assert.IsFalse(leakedTwo == leakedFour);
			Assert.IsTrue(leakedTwo != leakedFour);
			Assert.IsFalse(leakedThree == leakedFour);
			Assert.IsTrue(leakedThree != leakedFour);
		}

		[TestMethod]
		public void CheckForEqualityWithIncompatibleType()
		{
			var leaked = new LeakedException(typeof(NotImplementedException),
				new LeakedExceptionDiscoveryStatuses(true, false));
			var notLeaked = "wrong";

			Assert.AreNotEqual(leaked, notLeaked);
		}
		
		[TestMethod]
		public void Create()
		{
			var exception = typeof(InvalidCastException);
			var leakedException = new LeakedException(exception);
			Assert.AreEqual(exception, leakedException.Type);
			Assert.IsFalse(leakedException.DiscoveryStatuses.IsDocumented);
			Assert.IsFalse(leakedException.DiscoveryStatuses.WasFoundThroughAnalysis);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNullType()
		{
			new LeakedException(null);
		}

		[TestMethod]
		public void CreateWithDiscoveryStatuses()
		{
			var exception = typeof(InvalidCastException);
			var leakedException = new LeakedException(exception, 
				new LeakedExceptionDiscoveryStatuses(true, false));
			Assert.AreEqual(exception, leakedException.Type);
			Assert.IsTrue(leakedException.DiscoveryStatuses.IsDocumented);
			Assert.IsFalse(leakedException.DiscoveryStatuses.WasFoundThroughAnalysis);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithDiscoveryStatusesAndNullType()
		{
			new LeakedException(null,
				new LeakedExceptionDiscoveryStatuses(true, false));
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithTypeAndNullDiscoveryStatuses()
		{
			new LeakedException(typeof(InvalidCastException), null);
		}

		[TestMethod]
		public void ChangeDiscoveryStatuses()
		{
			var exception = typeof(InvalidCastException);
			var leakedException = new LeakedException(exception,
				new LeakedExceptionDiscoveryStatuses(false, false));

			Assert.IsFalse(leakedException.DiscoveryStatuses.IsDocumented);
			Assert.IsFalse(leakedException.DiscoveryStatuses.WasFoundThroughAnalysis);

			leakedException.DiscoveryStatuses.IsDocumented = true;
			leakedException.DiscoveryStatuses.WasFoundThroughAnalysis = true;			

			Assert.IsTrue(leakedException.DiscoveryStatuses.IsDocumented);
			Assert.IsTrue(leakedException.DiscoveryStatuses.WasFoundThroughAnalysis);
		}
	}
}
