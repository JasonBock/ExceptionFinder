using ExceptionFinder.Extensions;
using ExceptionFinder.Instructions;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedExceptionsCatchBlockInstructionsAnalyzer :
		LeakedExceptionsInstructionsAnalyzer
	{
		internal LeakedExceptionsCatchBlockInstructionsAnalyzer(List<IInstruction> instructions, IMethodDeclaration method,
			int startIndex, HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack,
			LeakedExceptionsMethodInstructionsAnalyzerContext context) :
			base(instructions, method, startIndex, callHistory, callStack, context)
		{
		}

		protected override void OnAnalyze()
		{
			var i = this.StartIndex;
			var catchException = ((this.Instructions[i] as CatchInstruction).CatchType as ITypeReference).Translate();

			while(i < this.Instructions.Count)
			{
				var instruction = this.Instructions[i];

				var tryInstruction = instruction as TryInstruction;

				if(tryInstruction != null)
				{
					i = LeakedExceptionsInstructionsAnalyzer.HandleTryBlock(
						this.Instructions, this.Method, i, this.CallHistory, 
						this.CallStack, this.Context, this.LeakedExceptions);
				}
				else
				{
					if(instruction.IsMethodCall() && !instruction.IsNativeMethodCall())
					{
						LeakedExceptionsInstructionsAnalyzer.HandleMethodCall(
							instruction, this.CallHistory, this.CallStack, 
							this.Context, this.LeakedExceptions);
					}
					else if(instruction.GetOpCode() == OpCodes.Throw)
					{
						this.LeakedExceptions.Add(new LeakedException(
							this.Instructions.GetThrownException(i, this.Method),
							new LeakedExceptionDiscoveryStatuses(false, true)),
							instruction, this.Method, this.CallStack.AsReadOnly());
					}
					else if(instruction.GetOpCode() == OpCodes.Rethrow)
					{
						this.LeakedExceptions.Add(new LeakedException(
							catchException, new LeakedExceptionDiscoveryStatuses(false, true)), 
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
		}
	}
}
