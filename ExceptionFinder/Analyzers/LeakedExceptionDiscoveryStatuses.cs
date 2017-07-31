using System;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedExceptionDiscoveryStatuses : IEquatable<LeakedExceptionDiscoveryStatuses>
	{
		internal	LeakedExceptionDiscoveryStatuses()
			: base()
		{		
		}

		internal LeakedExceptionDiscoveryStatuses(bool isDocumented, bool wasFoundThroughAnalysis)
			: this()
		{
			this.IsDocumented = isDocumented;
			this.WasFoundThroughAnalysis = wasFoundThroughAnalysis;
		}

		public static bool operator ==(LeakedExceptionDiscoveryStatuses a, LeakedExceptionDiscoveryStatuses b)
		{
			var areEqual = false;

			if(object.ReferenceEquals(a, b))
			{
				areEqual = true;
			}

			if((object)a != null && (object)b != null)
			{
				areEqual = a.Equals(b);
			}

			return areEqual;
		}

		public static bool operator !=(LeakedExceptionDiscoveryStatuses a, LeakedExceptionDiscoveryStatuses b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj as LeakedExceptionDiscoveryStatuses);
		}
		
		public bool Equals(LeakedExceptionDiscoveryStatuses other)
		{
			var areEqual = false;

			if(other != null)
			{
				areEqual = this.IsDocumented == other.IsDocumented &&
					this.WasFoundThroughAnalysis == other.WasFoundThroughAnalysis;
			}

			return areEqual;
		}

		public override int GetHashCode()
		{
			return this.IsDocumented.GetHashCode() ^ this.WasFoundThroughAnalysis.GetHashCode();
		}

		internal bool IsDocumented
		{
			get;
			set;
		}
		
		internal bool WasFoundThroughAnalysis
		{
			get;
			set;
		}
	}
}
