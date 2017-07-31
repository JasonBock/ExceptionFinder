using System;
using System.Runtime.Serialization;

namespace ExceptionFinder.Analyzers
{
	/// <summary>
	/// The exception that is thrown if a method is already visited.
	/// </summary>
	[Serializable]
	public sealed class MethodAlreadyVisitedException : Exception
	{
		/// <summary>
		/// Creates a new <see cref="MethodAlreadyVisitedException" /> instance.
		/// </summary>
		public MethodAlreadyVisitedException()
			: base()
		{
		}

		private MethodAlreadyVisitedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		/// <summary>
		/// Creates a new <see cref="MethodAlreadyVisitedException" /> instance
		/// with a specified error message.
		/// </summary>
		/// <param name="message">
		/// The message that describes the error.
		/// </param>
		public MethodAlreadyVisitedException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Creates a new <see cref="MethodAlreadyVisitedException" /> instance
		/// with a specified error message and a reference to the inner exception that is the cause of this exception. 
		/// </summary>
		/// <param name="message">
		/// The message that describes the error.
		/// </param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception, 
		/// or a null reference if no inner exception is specified. 
		/// </param>
		public MethodAlreadyVisitedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
