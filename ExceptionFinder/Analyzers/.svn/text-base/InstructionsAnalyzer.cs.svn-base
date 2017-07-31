using Reflector.CodeModel;
using System;
using System.Collections.Generic;

namespace ExceptionFinder.Analyzers
{
	internal abstract class InstructionsAnalyzer : IInstructionsAnalyzer
	{
		protected InstructionsAnalyzer(List<IInstruction> instructions, IMethodDeclaration method)
			: base()
		{
			this.Instructions = instructions;
			this.Method = method;
		}

		protected InstructionsAnalyzer(List<IInstruction> instructions, IMethodDeclaration method, int startIndex)
			: this(instructions, method)
		{
			this.StartIndex = startIndex;
		}

		public abstract void Analyze();

		public int EndIndex
		{
			get;
			protected set;
		}

		protected List<IInstruction> Instructions
		{
			get;
			set;
		}

		protected IMethodDeclaration Method
		{
			get;
			private set;
		}

		public int StartIndex
		{
			get;
			protected set;
		}
	}
}
