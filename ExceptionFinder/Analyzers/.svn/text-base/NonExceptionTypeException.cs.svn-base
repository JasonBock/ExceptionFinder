using Reflector.CodeModel;
using System;
using System.Runtime.Serialization;

namespace ExceptionFinder.Analyzers
{
	[Serializable]
	public sealed class NonExceptionTypeException : Exception
	{
		/// <summary>
		/// Creates a new <see cref="NonExceptionTypeException" /> instance.
		/// </summary>
		public NonExceptionTypeException()
			: base()
		{
		}

		private NonExceptionTypeException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		/// <summary>
		/// Creates a new <see cref="NonExceptionTypeException" /> instance
		/// with a specified error message.
		/// </summary>
		/// <param name="message">
		/// The message that describes the error.
		/// </param>
		public NonExceptionTypeException(string message, IInstruction instruction, IMethodDeclaration method)
			: base(message)
		{
			this.Instruction = instruction;
			this.Method = method;
		}

		/// <summary>
		/// Creates a new <see cref="NonExceptionTypeException" /> instance
		/// with a specified error message and location information
		/// </summary>
		/// <param name="message">
		/// The message that describes the error.
		/// </param>
		public NonExceptionTypeException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Creates a new <see cref="NonExceptionTypeException" /> instance
		/// with a specified error message and a reference to the inner exception that is the cause of this exception. 
		/// </summary>
		/// <param name="message">
		/// The message that describes the error.
		/// </param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception, 
		/// or a null reference if no inner exception is specified. 
		/// </param>
		public NonExceptionTypeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
		
		/// <summary>
		/// Creates a new <see cref="NonExceptionTypeException" /> instance
		/// with a specified error message and a reference to the inner exception that is the cause of this exception. 
		/// </summary>
		/// <param name="message">
		/// The message that describes the error.
		/// </param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception, 
		/// or a null reference if no inner exception is specified. 
		/// </param>
		public NonExceptionTypeException(string message, Exception innerException, IInstruction instruction, IMethodDeclaration method)
			: base(message, innerException)
		{
			this.Instruction = instruction;
			this.Method = method;
		}

		public IInstruction Instruction
		{
			get;
			private set;
		}
		
		public IMethodDeclaration Method
		{
			get;
			private set;
		}
	}
}
