using ExceptionFinder.Extensions;
using ExceptionFinder.Instructions;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedExceptionsTryBlockInstructionsAnalyzer :
		LeakedExceptionsInstructionsAnalyzer
	{
		internal LeakedExceptionsTryBlockInstructionsAnalyzer(List<IInstruction> instructions, IMethodDeclaration method,
			int startIndex, HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack, 
			LeakedExceptionsMethodInstructionsAnalyzerContext context) :
			base(instructions, method, startIndex, callHistory, callStack, context)
		{
		}

		private int AnalyzeCatchBlock(LeakedExceptionsCollection tryExceptions, int i, CatchInstruction catchInstruction)
		{
			var caughtException = (catchInstruction.CatchType as ITypeReference).Translate();
			var handledExceptions = new List<LeakedException>();

			foreach(KeyValuePair<LeakedException, List<InstructionLocation>> pair in tryExceptions)
			{
				if(caughtException.IsAssignableFrom(pair.Key.Type))
				{
					handledExceptions.Add(pair.Key);
				}
			}

			foreach(var handledException in handledExceptions)
			{
				tryExceptions.Remove(handledException);
			}

			var catchAnalyzer = new LeakedExceptionsCatchBlockInstructionsAnalyzer(
				this.Instructions, this.Method, i, this.CallHistory, this.CallStack, this.Context);
			catchAnalyzer.Analyze();
			this.LeakedExceptions.Add(catchAnalyzer.LeakedExceptions);
			return catchAnalyzer.EndIndex + 1;
		}

		private int AnalyzeEmbeddedTryBlock(LeakedExceptionsCollection tryExceptions, int i)
		{
			return LeakedExceptionsInstructionsAnalyzer.HandleTryBlock(
				this.Instructions, this.Method, i, this.CallHistory,
				this.CallStack, this.Context, tryExceptions);
		}

		private int AnalyzeFaultFinallyBlock(LeakedExceptionsCollection tryExceptions, int i, bool isFaultBlock)
		{
			var faultFinallyAnalyzer = new LeakedExceptionsFaultFinallyBlockInstructionsAnalyzer(
				this.Instructions, this.Method, i, this.CallHistory, this.CallStack, this.Context);
			faultFinallyAnalyzer.Analyze();

			if(!isFaultBlock || tryExceptions.Count > 0)
			{
				if(faultFinallyAnalyzer.FoundThrowInstruction)
				{
					this.LeakedExceptions.Clear();
					tryExceptions.Clear();
				}

				this.LeakedExceptions.Add(faultFinallyAnalyzer.LeakedExceptions);			
			}

			return faultFinallyAnalyzer.EndIndex + 1;
		}

		protected override void OnAnalyze()
		{
			var tryExceptions = new LeakedExceptionsCollection();

			var i = this.StartIndex;

			while(i < this.Instructions.Count)
			{
				var instruction = this.Instructions[i];

				var tryInstruction = instruction as TryInstruction;
				var catchInstruction = instruction as CatchInstruction;
				var finallyInstruction = instruction as FinallyInstruction;
				var faultInstruction = instruction as FaultInstruction;

				if(tryInstruction != null && i > this.StartIndex)
				{
					i = this.AnalyzeEmbeddedTryBlock(tryExceptions, i);
				}
				else if(catchInstruction != null)
				{
					i = this.AnalyzeCatchBlock(tryExceptions, i, catchInstruction);
				}
				else if(finallyInstruction != null)
				{
					i = this.AnalyzeFaultFinallyBlock(tryExceptions, i, false);
				}
				else if(faultInstruction != null)
				{
					i = this.AnalyzeFaultFinallyBlock(tryExceptions, i, true);									
				}
				else
				{
					if(instruction.IsMethodCall() && !instruction.IsNativeMethodCall())
					{
						LeakedExceptionsInstructionsAnalyzer.HandleMethodCall(
							instruction, this.CallHistory, this.CallStack,
							this.Context, tryExceptions);
					}
					else if(instruction.GetOpCode() == OpCodes.Throw)
					{
						tryExceptions.Add(new LeakedException(
							this.Instructions.GetThrownException(i, this.Method),
							new LeakedExceptionDiscoveryStatuses(false, true)),
							instruction, this.Method, this.CallStack.AsReadOnly());
					}

					instruction.AddExceptionsToLeakedExceptions(this.LeakedExceptions, this.Method, 
						this.CallStack.AsReadOnly(), this.Context.OpCodeFilters);
					var endInstruction = instruction as EndHandlerInstruction;

					if(endInstruction != null)
					{
						break;
					}

					i++;
				}
			}

			this.EndIndex = i;
			this.LeakedExceptions.Add(tryExceptions);
		}
	}
}
