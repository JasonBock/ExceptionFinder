using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Instructions
{
	internal sealed class FaultInstruction : IInstruction
	{
		internal FaultInstruction(IInstruction instruction)
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