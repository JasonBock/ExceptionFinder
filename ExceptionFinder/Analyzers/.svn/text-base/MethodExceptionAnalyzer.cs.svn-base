using ExceptionFinder.Extensions;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Xml.XPath;

namespace ExceptionFinder.Analyzers
{
	internal sealed class MethodExceptionAnalyzer : IAnalyzer
	{
		private LeakedExceptionsMethodInstructionsAnalyzerContext context;
		private IMethodDeclaration method;

		internal MethodExceptionAnalyzer(IMethodDeclaration method)
			: this(method, new LeakedExceptionsMethodInstructionsAnalyzerContext())
		{
			this.method = method;
			this.LeakedExceptions = new LeakedExceptionsCollection();
		}

		internal MethodExceptionAnalyzer(IMethodDeclaration method, LeakedExceptionsMethodInstructionsAnalyzerContext context)
			: base()
		{
			this.method = method;
			this.LeakedExceptions = new LeakedExceptionsCollection();
			this.context = context;
		}

		public void Analyze()
		{
			if(!(this.method.DeclaringType as ITypeDeclaration).Interface)
			{
				var analyzer = new LeakedExceptionsMethodInstructionsAnalyzer(
					this.method, new HashSet<IMethodSignature>(),
					new List<CallStackInformation>(), this.context);
				analyzer.Analyze();
				this.LeakedExceptions.Add(analyzer.LeakedExceptions);
				this.UpdateDocumentationFlags();
			}
		}

		private IEnumerable<Type> GetEnumerator(XPathNavigator navigator)
		{
			if(navigator != null)
			{
				foreach(XPathNavigator crefNode in navigator.Select("//exception/@cref"))
				{
					var exceptionTypeParts = crefNode.Value.Split(':');
					string exceptionType = null;

					if(exceptionTypeParts[0] != "!")
					{
						exceptionType = exceptionTypeParts[1];
					}

					if(exceptionType != null)
					{
						var exception = Type.GetType(exceptionType, false);

						if(exception != null)
						{
							yield return exception;
						}
					}
				}
			}
		}

		private void UpdateDocumentationFlags()
		{
			var documentedExceptionsNotFound = new List<Type>();
			
			foreach(var exceptionType in this.GetEnumerator(this.method.GetNavigator()))
			{
				if(!this.LeakedExceptions.UpdateDocumentationStatus(exceptionType, true))
				{
					documentedExceptionsNotFound.Add(exceptionType);
				}
			}
			
			foreach(var documentedExceptionNotFound in documentedExceptionsNotFound)
			{
				this.LeakedExceptions.Add(new LeakedException(
					documentedExceptionNotFound, new LeakedExceptionDiscoveryStatuses(true, false)), 
					null, null, null);
			}
		}

		internal LeakedExceptionsCollection LeakedExceptions
		{
			get;
			private set;
		}
	}
}
