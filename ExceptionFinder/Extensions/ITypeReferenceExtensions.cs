using Reflector.CodeModel;
using System;
using System.Reflection;

namespace ExceptionFinder.Extensions
{
	internal static class ITypeReferenceExtensions
	{
		private static string GetName(this ITypeReference @this)
		{
			var name = @this.Name;
			
			if(@this.GenericType != null)
			{
				name += "`" + @this.GenericArguments.Count;
			}
			
			return name;
		}	
		
		internal static Type Translate(this ITypeReference @this)
		{
			Type translated = null;

			var assembly = @this.Owner as IAssemblyReference;

			if(assembly != null)
			{
				var fullTypeName = @this.Namespace + "." + @this.GetName() + ", " + assembly.ToString();
				translated = Type.GetType(fullTypeName, false);
			}
			else
			{
				var module = @this.Owner as IModuleReference;

				if(module != null)
				{
					var fullTypeName = @this.Namespace + "." + @this.GetName() + ", " + module.Resolve().Assembly.ToString();
					translated = Type.GetType(fullTypeName, false);				
				}
			}
			
			if(translated == null && (@this.Owner is ITypeReference))
			{
				translated = (@this.Owner as ITypeReference).Translate();
			}

			return translated;
		}
	}
}
