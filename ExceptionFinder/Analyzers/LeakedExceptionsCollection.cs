using ExceptionFinder.Extensions;
using Reflector.CodeModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExceptionFinder.Analyzers
{
	internal sealed class LeakedExceptionsCollection
	{
		private Dictionary<LeakedException, List<InstructionLocation>> exceptionItems =
			new Dictionary<LeakedException, List<InstructionLocation>>();
		private Dictionary<LeakedException, List<InstructionLocation>> nonExceptionItems =
			new Dictionary<LeakedException, List<InstructionLocation>>();

		private void Add(LeakedException exception, InstructionLocation location)
		{
			if(typeof(Exception).IsAssignableFrom(exception.Type))
			{
				this.exceptionItems.Get(exception).Add(location);
			}
			else
			{
				this.nonExceptionItems.Get(exception).Add(location);
			}
		}

		internal void Add(LeakedException exception, IInstruction instruction, IMethodDeclaration method,
			ReadOnlyCollection<CallStackInformation> callStack)
		{
			this.Add(exception, new InstructionLocation(instruction, method, callStack));
		}

		internal void Add(LeakedExceptionsCollection leakedExceptions)
		{
			foreach(KeyValuePair<LeakedException, List<InstructionLocation>> pair in leakedExceptions)
			{
				foreach(var location in pair.Value)
				{
					this.Add(pair.Key, location);
				}
			}
		}

		internal void Clear()
		{
			this.exceptionItems.Clear();
			this.nonExceptionItems.Clear();
		}

		internal bool ContainsException(Type exception)
		{
			return LeakedExceptionsCollection.ContainsException(exception, this.exceptionItems) ||
				LeakedExceptionsCollection.ContainsException(exception, this.nonExceptionItems);
		}

		private static bool ContainsException(Type exception,
			IDictionary<LeakedException, List<InstructionLocation>> exceptions)
		{
			var doesContain = false;

			foreach(var exceptionItem in exceptions)
			{
				if(exceptionItem.Key.Type == exception)
				{
					doesContain = true;
					break;
				}
			}

			return doesContain;
		}

		internal bool ContainsKey(LeakedException key)
		{
			return this.exceptionItems.ContainsKey(key) ||
				this.nonExceptionItems.ContainsKey(key);
		}
		
		internal LeakedException Get(Type exceptionType)
		{
			LeakedException leakedException = null;

			if(typeof(Exception).IsAssignableFrom(exceptionType))
			{
				leakedException = LeakedExceptionsCollection.Get(
					exceptionType, this.exceptionItems);
			}
			else
			{
				leakedException = LeakedExceptionsCollection.Get(
					exceptionType, this.nonExceptionItems);
			}

			return leakedException;
		}
		
		private static LeakedException Get(Type exceptionType,
			IDictionary<LeakedException, List<InstructionLocation>> exceptions)
		{
			LeakedException leakedException = null;

			foreach(var exception in exceptions)
			{
				if(exception.Key.Type == exceptionType)
				{
					leakedException = exception.Key;
					break;
				}
			}

			return leakedException;			
		}

		public IEnumerator<KeyValuePair<LeakedException, List<InstructionLocation>>> GetEnumerator()
		{
			foreach(KeyValuePair<LeakedException, List<InstructionLocation>> exceptionItem in this.exceptionItems)
			{
				yield return exceptionItem;
			}

			foreach(KeyValuePair<LeakedException, List<InstructionLocation>> nonExceptionItem in this.nonExceptionItems)
			{
				yield return nonExceptionItem;
			}
		}

		internal void Remove(LeakedException key)
		{
			if(!this.exceptionItems.Remove(key))
			{
				this.nonExceptionItems.Remove(key);
			}
		}

		internal bool UpdateDocumentationStatus(Type exception, bool isDocumented)
		{
			var wasFound = false;
			
			if(typeof(Exception).IsAssignableFrom(exception))
			{
				wasFound = LeakedExceptionsCollection.UpdateDocumentationStatus(
					exception, isDocumented, this.exceptionItems);
			}
			else
			{
				wasFound = LeakedExceptionsCollection.UpdateDocumentationStatus(
					exception, isDocumented, this.nonExceptionItems);
			}
			
			return wasFound;
		}

		private static bool UpdateDocumentationStatus(Type exception, bool isDocumented,
			IDictionary<LeakedException, List<InstructionLocation>> exceptions)
		{
			var wasFound = false;
			
			foreach(var pair in exceptions)
			{
				if(pair.Key.Type == exception)
				{
					wasFound = true;
					pair.Key.DiscoveryStatuses.IsDocumented = isDocumented;
				}
			}
			
			return wasFound;
		}

		internal int Count
		{
			get
			{
				return this.exceptionItems.Count + this.nonExceptionItems.Count;
			}
		}

		internal IDictionary<LeakedException, List<InstructionLocation>> Exceptions
		{
			get
			{
				return this.exceptionItems;
			}
		}

		internal IDictionary<LeakedException, List<InstructionLocation>> NonExceptions
		{
			get
			{
				return this.nonExceptionItems;
			}
		}
	}
}
