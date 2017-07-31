using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Instructions
{
	internal sealed class EndHandlerInstruction : IInstruction
	{
		internal EndHandlerInstruction(IInstruction instruction)
		{
			this.Code = instruction.Code;
			this.Offset = instruction.Offset;
			this.Value = instruction.Value;
		}

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