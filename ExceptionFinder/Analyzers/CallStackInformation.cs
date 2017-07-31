using Reflector.CodeModel;
using Spackle.Extensions;
using System;
using System.Collections.Generic;

namespace ExceptionFinder.Analyzers
{
	internal sealed class CallStackInformation
	{
		internal CallStackInformation(IMethodDeclaration method)
			: this(method, null)
		{
		}

		internal CallStackInformation(IInstruction instruction)
			: this(null, instruction)
		{
		}

		internal CallStackInformation(IMethodDeclaration method, IInstruction instruction)
		{			
			if(method == null && instruction == null)
			{
				throw new ArgumentsException("Both parameters cannot be null.", 
					new List<string>() { "method", "instruction" }.AsReadOnly());
			}
			
			this.Method = method;
			this.Instruction = instruction;
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
