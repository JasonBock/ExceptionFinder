using Reflector.CodeModel;
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace ExceptionFinder.Extensions
{
	internal static class IDocumentationProviderExtensions
	{
		internal static XPathNavigator GetNavigator(this IDocumentationProvider @this)
		{
			XPathNavigator navigator = null;
			
			if(@this != null && !string.IsNullOrEmpty(@this.Documentation))
			{
				using(var stream = new StringReader(
					IDocumentationProviderExtensions.FormatDocumentation(@this.Documentation)))
				{
					navigator = new XPathDocument(stream).CreateNavigator();
				}
			}
			
			return navigator;
		}
		
		private static string FormatDocumentation(string documentation)
		{
			return "<doc>" + documentation + "</doc>";
		}
	}
}
