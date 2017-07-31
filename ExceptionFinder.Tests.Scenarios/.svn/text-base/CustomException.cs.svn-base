using System;
using System.Runtime.Serialization;

namespace ExceptionFinder.Tests.Scenarios
{
	[Serializable]
	public sealed class CustomException : Exception
	{
		public CustomException()
			: base()
		{
		}

		public CustomException(string message)
			: base(message)
		{
		}

		public CustomException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		private CustomException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
