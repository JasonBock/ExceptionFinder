using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExceptionFinder.Analyzers
{
	internal sealed class InstructionLocation
	{
		internal InstructionLocation(IInstruction instruction, IMethodDeclaration method,
			ReadOnlyCollection<CallStackInformation> callStack)
			: base()
		{
			this.Instruction = instruction;
			this.Method = method;
			this.CallStack = callStack;
		}

		internal ReadOnlyCollection<CallStackInformation> CallStack
		{
			get;
			private set;
		}
		
		internal IInstruction Instruction
		{
			get;
			private set;
		}

		internal IMethodDeclaration Method
		{
			get;
			private set;
		}
	}
}
