using ExceptionFinder.Extensions;
using Reflector.CodeModel;
using Reflector.CodeModel.Memory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExceptionFinder.Analyzers
{
	internal abstract class LeakedExceptionsInstructionsAnalyzer : InstructionsAnalyzer
	{
		private LeakedExceptionsCollection leakedExceptions = new LeakedExceptionsCollection();
		
		protected LeakedExceptionsInstructionsAnalyzer(List<IInstruction> instructions, IMethodDeclaration method,
			HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack,
			LeakedExceptionsMethodInstructionsAnalyzerContext context)
			: base(instructions, method)
		{
			this.SetProperties(callHistory, callStack, context);
		}

		protected LeakedExceptionsInstructionsAnalyzer(List<IInstruction> instructions, IMethodDeclaration method,
			int startIndex, HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack, 
			LeakedExceptionsMethodInstructionsAnalyzerContext context)
			: base(instructions, method, startIndex)
		{
			this.SetProperties(callHistory, callStack, context);
		}

		public sealed override void Analyze()
		{
			this.leakedExceptions.Clear();
			this.OnAnalyze();
		}
		
		protected static void HandleMethodCall(IInstruction instruction, HashSet<IMethodSignature> callHistory,
			List<CallStackInformation> callStack, LeakedExceptionsMethodInstructionsAnalyzerContext context, 
			LeakedExceptionsCollection exceptions)
		{
			var method = instruction.GetValueAsMethodDeclaration();
			
			if(!callHistory.Contains(method))
			{
				var analyzer = new LeakedExceptionsMethodInstructionsAnalyzer(
					method, instruction, callHistory, callStack, context);
				analyzer.Analyze();
				exceptions.Add(analyzer.LeakedExceptions);
			}
		}

		protected static int HandleTryBlock(List<IInstruction> instructions, IMethodDeclaration method, 
			int instructionIndex, HashSet<IMethodSignature> callHistory,
			List<CallStackInformation> callStack, LeakedExceptionsMethodInstructionsAnalyzerContext context,
			LeakedExceptionsCollection exceptions)
		{
			var analyzer = new LeakedExceptionsTryBlockInstructionsAnalyzer(
				instructions, method, instructionIndex, callHistory, callStack, context);
			analyzer.Analyze();
			exceptions.Add(analyzer.LeakedExceptions);
			return analyzer.EndIndex + 1;
		}
		
		protected abstract void OnAnalyze();

		private void SetProperties(HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack,
			LeakedExceptionsMethodInstructionsAnalyzerContext context)
		{
			this.CallHistory = callHistory;
			this.CallStack = callStack;
			this.Context = context;		
		}
		
		protected HashSet<IMethodSignature> CallHistory
		{
			get;
			private set;
		}

		protected List<CallStackInformation> CallStack
		{
			get;
			private set;
		}
		
		protected LeakedExceptionsMethodInstructionsAnalyzerContext Context
		{
			get;
			private set;
		}
		
		internal LeakedExceptionsCollection LeakedExceptions
		{
			get
			{
				return this.leakedExceptions;
			}
		}
	}
}
