using ExceptionFinder.Extensions;
using ExceptionFinder.Instructions;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedExceptionsMethodInstructionsAnalyzer :
		LeakedExceptionsInstructionsAnalyzer
	{
		internal LeakedExceptionsMethodInstructionsAnalyzer(IMethodDeclaration method,
			HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack,
			LeakedExceptionsMethodInstructionsAnalyzerContext context)
			: this(method, null, callHistory, callStack, context)
		{
		}

		internal LeakedExceptionsMethodInstructionsAnalyzer(IMethodDeclaration method, IInstruction instruction,
			HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack,
			LeakedExceptionsMethodInstructionsAnalyzerContext context)
			: base(null, method, callHistory, 
				new List<CallStackInformation>(callStack) { new CallStackInformation(method, instruction) }, context)
		{
			this.CallHistory.Add(method);
		}

		protected override void OnAnalyze()
		{
			if(this.Method != null && this.Method.Body != null)
			{
				var body = this.Method.Body as IMethodBody;
				this.Instructions = body.Instructions.TranslateToList();

				var instructions = this.Instructions.MapWithHandlerInstructions(
					body.ExceptionHandlers);

				int i = 0;

				while(i < instructions.Count)
				{
					var instruction = instructions[i];

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
								instructions.GetThrownException(i, this.Method),
								new LeakedExceptionDiscoveryStatuses(false, true)),
								instruction, this.Method, this.CallStack.AsReadOnly());
						}

						instruction.AddExceptionsToLeakedExceptions(
							this.LeakedExceptions, this.Method, 
							this.CallStack.AsReadOnly(), this.Context.OpCodeFilters);
						i++;
					}
				}

				this.StartIndex = 0;
				this.EndIndex = body.Instructions.Count - 1;
			}
		}
	}
}
