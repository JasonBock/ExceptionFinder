using ExceptionFinder.Extensions;
using Spackle.Extensions;
using System;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedException : IEquatable<LeakedException>
	{
		internal LeakedException(Type type)
			: base()
		{
			type.CheckParameterForNull("type");

			this.Type = type;
			this.DiscoveryStatuses = new LeakedExceptionDiscoveryStatuses();
		}

		internal LeakedException(Type type, LeakedExceptionDiscoveryStatuses discoveryStatuses)
			: this(type)
		{
			discoveryStatuses.CheckParameterForNull("discoveryStatuses");
			this.DiscoveryStatuses = discoveryStatuses;
		}

		/// <summary>
		/// Determines whether two specified <see cref="LeakedException" /> objects have the same value. 
		/// </summary>
		/// <param name="a">A <see cref="LeakedException" /> or a null reference.</param>
		/// <param name="b">A <see cref="LeakedException" /> or a null reference.</param>
		/// <returns><b>true</b> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, <b>false</b>. </returns>
		public static bool operator ==(LeakedException a, LeakedException b)
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

		/// <summary>
		/// Determines whether two specified <see cref="LeakedException" /> objects have different value. 
		/// </summary>
		/// <param name="a">A <see cref="LeakedException" /> or a null reference.</param>
		/// <param name="b">A <see cref="LeakedException" /> or a null reference.</param>
		/// <returns><b>true</b> if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, <b>false</b>. </returns>
		public static bool operator !=(LeakedException a, LeakedException b)
		{
			return !(a == b);
		}

		public bool Equals(LeakedException other)
		{
			var areEqual = false;

			if(other != null)
			{
				areEqual = this.Type == other.Type && this.DiscoveryStatuses == other.DiscoveryStatuses;
			}

			return areEqual;
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj as LeakedException);
		}

		public override int GetHashCode()
		{
			return this.Type.GetHashCode() ^ this.DiscoveryStatuses.GetHashCode();
		}

		internal LeakedExceptionDiscoveryStatuses DiscoveryStatuses
		{
			get;
			private set;
		}

		internal Type Type
		{
			get;
			private set;
		}
	}
}
