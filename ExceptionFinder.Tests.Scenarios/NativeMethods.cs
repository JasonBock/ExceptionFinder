using System;
using System.Runtime.InteropServices;

namespace ExceptionFinder.Tests.Scenarios
{
	internal static class NativeMethods
	{
		[DllImport("kernel32.dll")]
		internal static extern uint GetTickCount();
	}
}
