using ExceptionFinder.Extensions;
using ExceptionFinder.Instructions;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedExceptionsFaultFinallyBlockInstructionsAnalyzer :
		LeakedExceptionsInstructionsAnalyzer
	{
		internal LeakedExceptionsFaultFinallyBlockInstructionsAnalyzer(List<IInstruction> instructions, IMethodDeclaration method,
			int startIndex, HashSet<IMethodSignature> callHistory, List<CallStackInformation> callStack,
			LeakedExceptionsMethodInstructionsAnalyzerContext context) :
			base(instructions, method, startIndex, callHistory, callStack, context)
		{
		}

		protected override void OnAnalyze()
		{
			var i = this.StartIndex;

			while(i < this.Instructions.Count)
			{
				var instruction = this.Instructions[i];

				if(this.FoundThrowInstruction && instruction.GetOpCode() == OpCodes.Endfinally)
				{
					i++;
					break;				
				}
				else
				{
					var tryInstruction = instruction as TryInstruction;

					if(tryInstruction != null)
					{
						i = LeakedExceptionsInstructionsAnalyzer.HandleTryBlock(
							this.Instructions, this.Method, i, this.CallHistory,
							this.CallStack, this.Context, this.LeakedExceptions);
					}
					else
					{
						instruction.AddExceptionsToLeakedExceptions(
							this.LeakedExceptions, this.Method, 
							this.CallStack.AsReadOnly(), this.Context.OpCodeFilters);

						if(instruction.IsMethodCall() && !instruction.IsNativeMethodCall())
						{
							LeakedExceptionsInstructionsAnalyzer.HandleMethodCall(
								instruction, this.CallHistory, this.CallStack,
								this.Context, this.LeakedExceptions);
						}
						else
						{
							var instructionCode = instruction.GetOpCode();

							if(instructionCode == OpCodes.Throw)
							{
								this.LeakedExceptions.Clear();
								this.LeakedExceptions.Add(new LeakedException(
									this.Instructions.GetThrownException(i, this.Method),
									new LeakedExceptionDiscoveryStatuses(false, true)),
									instruction, this.Method, this.CallStack.AsReadOnly());
								instruction.AddExceptionsToLeakedExceptions(
									this.LeakedExceptions, this.Method, 
									this.CallStack.AsReadOnly(), this.Context.OpCodeFilters);
								this.FoundThrowInstruction = true;
							}
							else if(instructionCode == OpCodes.Endfinally)
							{
								i++;
								break;
							}
						}

						i++;
					}				
				}
			}

			this.EndIndex = i;
		}
		
		internal bool FoundThrowInstruction
		{
			get;
			private set;
		}
	}
}
