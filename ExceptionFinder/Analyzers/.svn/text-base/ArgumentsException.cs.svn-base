using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ExceptionFinder.Analyzers
{
	[Serializable]
	public sealed class ArgumentsException : Exception
	{
		public ArgumentsException()
			: base()
		{
		}

		public ArgumentsException(ReadOnlyCollection<string> parameterNames)
			: base()
		{
			this.ParameterNames = parameterNames;
		}

		private ArgumentsException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public ArgumentsException(string message)
			: base(message)
		{
		}

		public ArgumentsException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public ArgumentsException(string message, ReadOnlyCollection<string> parameterNames)
			: base(message)
		{
			this.ParameterNames = parameterNames;
		}

		public ArgumentsException(string message, Exception innerException, ReadOnlyCollection<string> parameterNames)
			: base(message, innerException)
		{
			this.ParameterNames = parameterNames;
		}

		public ReadOnlyCollection<string> ParameterNames
		{
			get;
			private set;
		}		
	}
}
