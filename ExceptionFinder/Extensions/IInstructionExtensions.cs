using ExceptionFinder;
using ExceptionFinder.Analyzers;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Reflection.Emit;

namespace ExceptionFinder.Extensions
{
	internal static class IInstructionExtensions
	{
		private static Dictionary<short, OpCode> opCodeMappings = IInstructionExtensions.GetOpCodeMappings();

		internal static void AddExceptionsToLeakedExceptions(
			this IInstruction @this, LeakedExceptionsCollection leakedExceptions, IMethodDeclaration method, 
			ReadOnlyCollection<CallStackInformation> callStack, OpCodeFilters filters)
		{
			foreach(var instructionExceptionType in @this.GetOpCode().GetExceptions(filters))
			{
				leakedExceptions.Add(new LeakedException(instructionExceptionType,
					new LeakedExceptionDiscoveryStatuses(false, true)), @this, method, callStack);
			}					
		}

		internal static OpCode GetOpCode(this IInstruction @this)
		{
			return IInstructionExtensions.opCodeMappings[(short)@this.Code];
		}

		private static Dictionary<short, OpCode> GetOpCodeMappings()
		{
			var opCodeMappings = new Dictionary<short, OpCode>();

			foreach(var codeField in typeof(OpCodes).GetFields())
			{
				if(typeof(OpCode).IsAssignableFrom(codeField.FieldType))
				{
					var code = (OpCode)codeField.GetValue(null);
					opCodeMappings.Add(code.Value, code);
				}
			}

			return opCodeMappings;
		}
		
		internal static IMethodDeclaration GetValueAsMethodDeclaration(this IInstruction @this)
		{
			var method = @this.Value as IMethodDeclaration;
			
			if(method == null)
			{
				var methodRef = @this.Value as IMethodReference;

				if(methodRef != null)
				{
					method = methodRef.Resolve();
				}
			}			
			
			return method;
		}
		
		internal static bool IsMethodCall(this IInstruction @this)
		{
			var code = @this.GetOpCode();

			return (code == OpCodes.Call || code == OpCodes.Calli ||
				code == OpCodes.Callvirt || code == OpCodes.Tailcall || 
				code == OpCodes.Newobj);
		}

		internal static bool IsNativeMethodCall(this IInstruction @this)
		{
			var isNativeMethodCall = false;

			var method = @this.GetValueAsMethodDeclaration();

			if(method != null && method.Body == null)
			{
				isNativeMethodCall = true;
			}				
			
			return isNativeMethodCall;
		}
	}
}
