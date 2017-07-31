using ExceptionFinder.Analyzers;
using ExceptionFinder.Instructions;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExceptionFinder.Extensions
{
	internal static class IInstructionCollectionExtensions
	{
		internal static List<IInstruction> TranslateToList(this IInstructionCollection @this)
		{
			var instructions = new List<IInstruction>();

			foreach(IInstruction instruction in @this)
			{
				instructions.Add(instruction);
			}

			return instructions;
		}
	}
}
