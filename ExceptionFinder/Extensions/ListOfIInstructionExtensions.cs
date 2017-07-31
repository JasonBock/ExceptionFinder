using ExceptionFinder.Analyzers;
using ExceptionFinder.Instructions;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExceptionFinder.Extensions
{
	internal static class ListOfIInstructionExtensions
	{
		private static IInstruction GetValidPreviousInstruction(this List<IInstruction> @this, int index)
		{
			IInstruction validInstruction = null;

			for(var i = index - 1; i >= 0; i--)
			{
				var previousInstruction = @this[i];
				
				if(previousInstruction.GetOpCode() != OpCodes.Nop)
				{
					validInstruction = previousInstruction;
					break;
				}	
			}
			
			return validInstruction;
		}
		
		internal static Type GetThrownException(this List<IInstruction> @this, int index, IMethodDeclaration method)
		{
			Type exceptionType = null;

			var instruction = @this[index];

			if(instruction.GetOpCode() == OpCodes.Throw)
			{
				var previousInstruction = @this.GetValidPreviousInstruction(index);
				var previousInstructionCode = previousInstruction.GetOpCode();
				
				if(previousInstruction != null)
				{
					if(previousInstructionCode == OpCodes.Newobj)
					{
						exceptionType = ((previousInstruction.Value as IMethodReference).DeclaringType as ITypeReference).Translate();
					}
					else if(previousInstruction.IsMethodCall())
					{
						exceptionType = (((previousInstruction.Value as IMethodReference).ReturnType as IMethodReturnType).Type as ITypeReference).Translate();
					}
					else if(previousInstructionCode.IsLoadLocal())
					{
						int localIndex = previousInstructionCode.GetLoadLocalIndex(previousInstruction);

						if(localIndex > -1)
						{
							var variables = (method.Body as IMethodBody).LocalVariables;

							if(variables.Count > localIndex)
							{
								exceptionType = (variables[localIndex].VariableType as ITypeReference).Translate();
							}
						}
					}
					else if(previousInstructionCode.IsLoadField())
					{
						exceptionType = ((previousInstruction.Value as IFieldDeclaration).FieldType as ITypeReference).Translate();
					}
					else if(previousInstructionCode.IsLoadArgument())
					{
						int argumentIndex = previousInstructionCode.GetLoadArgumentIndex(previousInstruction);

						if(!method.Static)
						{
							argumentIndex--;
						}

						if(argumentIndex > -1)
						{
							exceptionType = (method.Parameters[argumentIndex].ParameterType as ITypeReference).Translate();
						}
					}				
				}
			}

			return exceptionType;
		}

		private static FoundInstruction<T> Find<T>(
			this List<IInstruction> @this, int offset, int startIndex)
			where T : class, IInstruction
		{
			FoundInstruction<T> found = null;

			for(var i = startIndex; i < @this.Count; i++)
			{
				var instruction = @this[i];

				if(instruction.Offset == offset)
				{
					found = new FoundInstruction<T>(instruction as T, i);
					break;
				}
				else if(instruction.Offset > offset)
				{
					break;
				}
			}

			if(found == null)
			{
				for(var i = startIndex - 1; i >= 0; i--)
				{
					var instruction = @this[i];

					if(instruction.Offset == offset)
					{
						found = new FoundInstruction<T>(instruction as T, i);
						break;
					}
				}
			}

			return found;
		}

		private static int HandleCatch(
			this List<IInstruction> @this, IExceptionHandler handler, int lastInstructionIndexUsed)
		{
			var catchInstruction = @this.Find<IInstruction>(
				handler.HandlerOffset, lastInstructionIndexUsed);
			lastInstructionIndexUsed = catchInstruction.Index;
			@this[catchInstruction.Index] = new CatchInstruction(
				@this[catchInstruction.Index], handler.CatchType);

			lastInstructionIndexUsed = @this.HandleEndHandler(handler, lastInstructionIndexUsed);

			return lastInstructionIndexUsed;
		}

		private static int HandleEndHandler(
			this List<IInstruction> @this, IExceptionHandler handler, int lastInstructionIndexUsed)
		{
			var endHandlerInstruction = @this.Find<IInstruction>(
				handler.HandlerOffset + handler.HandlerLength,
				lastInstructionIndexUsed);
				
			if(endHandlerInstruction == null)
			{
				lastInstructionIndexUsed = @this.Count - 1;
				@this[@this.Count - 1] = new EndHandlerInstruction(
					@this[@this.Count - 1]);
			}
			else
			{
				lastInstructionIndexUsed = endHandlerInstruction.Index;
				@this[endHandlerInstruction.Index - 1] = new EndHandlerInstruction(
					@this[endHandlerInstruction.Index - 1]);			
			}

			return lastInstructionIndexUsed;
		}

		private static int HandleFault(
			this List<IInstruction> @this, IExceptionHandler handler, int lastInstructionIndexUsed)
		{
			var faultInstruction = @this.Find<IInstruction>(
				handler.HandlerOffset, lastInstructionIndexUsed);
			lastInstructionIndexUsed = faultInstruction.Index;
			@this[faultInstruction.Index] = new FaultInstruction(
				@this[faultInstruction.Index]);

			return lastInstructionIndexUsed;
		}

		private static int HandleFinally(
			this List<IInstruction> @this, IExceptionHandler handler, int lastInstructionIndexUsed)
		{
			var finallyInstruction = @this.Find<IInstruction>(
				handler.HandlerOffset, lastInstructionIndexUsed);
			lastInstructionIndexUsed = finallyInstruction.Index;
			@this[finallyInstruction.Index] = new FinallyInstruction(
				@this[finallyInstruction.Index]);

			return lastInstructionIndexUsed;
		}

		private static int HandleTry(
			this List<IInstruction> @this, IExceptionHandler handler, int lastInstructionIndexUsed)
		{
			var tryInstruction = @this.Find<TryInstruction>(
				handler.TryOffset, lastInstructionIndexUsed);

			if(tryInstruction.Instruction == null)
			{
				lastInstructionIndexUsed = tryInstruction.Index;
				@this[tryInstruction.Index] = new TryInstruction(@this[tryInstruction.Index]);
			}

			return lastInstructionIndexUsed;
		}

		internal static List<IInstruction> MapWithHandlerInstructions(
			this List<IInstruction> @this, IExceptionHandlerCollection handlers)
		{
			var mapped = new List<IInstruction>(@this);

			if(handlers.Count > 0)
			{
				var lastInstructionIndexUsed = 0;
				IExceptionHandler lastHandler = null;

				foreach(IExceptionHandler handler in handlers)
				{
					if(lastHandler == null)
					{
						lastHandler = handler;
					}
					else if(lastHandler.TryOffset != handler.TryOffset)
					{
						lastInstructionIndexUsed = mapped.HandleEndHandler(handler, lastInstructionIndexUsed);
						lastHandler = handler;
					}

					lastInstructionIndexUsed = mapped.HandleTry(handler, lastInstructionIndexUsed);

					switch(handler.Type)
					{
						case ExceptionHandlerType.Catch:
							lastInstructionIndexUsed = mapped.HandleCatch(handler, lastInstructionIndexUsed);
							break;
						case ExceptionHandlerType.Finally:
							lastInstructionIndexUsed = mapped.HandleFinally(handler, lastInstructionIndexUsed);
							break;
						case ExceptionHandlerType.Fault:
							lastInstructionIndexUsed = mapped.HandleFault(handler, lastInstructionIndexUsed);
							break;
						case ExceptionHandlerType.Filter:
							// Filters go right before a related catch block. If a 1 is on the stack at the
							// endfilter instruction, the corresponding catch block will execute. Otherwise
							// the catch block will not execute. I'm not doing static analysis, so
							// I'm basically ignoring it. Anything that occurs in the block is treated 
							// as code within the encapsulating try block.
						default:
							break;
					}
				}
			}

			return mapped;
		}

		private sealed class FoundInstruction<T>
			where T : class, IInstruction
		{
			public FoundInstruction(T instruction, int index)
			{
				this.Instruction = instruction;
				this.Index = index;
			}

			public int Index
			{
				get;
				private set;
			}

			public T Instruction
			{
				get;
				private set;
			}
		}
	}
}
