using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests
{
	internal sealed class MockInstruction : IInstruction
	{
		public int Code
		{
			get;
			set;
		}

		public int Offset
		{
			get;
			set;
		}

		public object Value
		{
			get;
			set;
		}
	}
}
