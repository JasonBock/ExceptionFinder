using Reflector.CodeModel;
using System;
using System.IO;
using System.Reflection;

namespace ExceptionFinder.Extensions
{
	internal static class IAssemblyLocationExtensions
	{
		internal static void Load(this IAssemblyLocation @this)
		{
			var targetName = new AssemblyName(@this.ToString());
			var alreadyLoaded = false;

			foreach(var loadedAssembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				if(loadedAssembly.GetName() == targetName)
				{
					alreadyLoaded = true;
					break;
				}	
			}
			
			if(!alreadyLoaded && File.Exists(@this.Location))
			{
				Assembly.LoadFrom(@this.Location);			
			}
		}
	}
}
