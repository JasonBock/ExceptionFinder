using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Instructions
{
	internal sealed class CatchInstruction : IInstruction
	{
		internal CatchInstruction(IInstruction instruction, IType catchType)
		{
			this.Code = instruction.Code;
			this.Offset = instruction.Offset;
			this.Value = instruction.Value;
			this.CatchType = catchType;
		}
		
		internal IType CatchType
		{
			get;
			private set;
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