using Reflector.CodeModel;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ExceptionFinder.Instructions
{
	internal sealed class MappedInstructionCollection : IInstructionCollection
	{
		private List<IInstruction> instructions = new List<IInstruction>();

		internal MappedInstructionCollection(IInstructionCollection instructions)
			: base()
		{
			this.AddRange(instructions);
		}

		public void Add(IInstruction value)
		{
			this.instructions.Add(value);
		}

		public void AddRange(ICollection values)
		{
			foreach(IInstruction instruction in values)
			{
				this.instructions.Add(instruction);
			}
		}

		public void Clear()
		{
			this.instructions.Clear();
		}

		public bool Contains(IInstruction value)
		{
			return this.instructions.Contains(value);
		}

		public int IndexOf(IInstruction value)
		{
			return this.instructions.IndexOf(value);
		}

		public void Insert(int index, IInstruction value)
		{
			this.instructions.Insert(index, value);
		}

		public void Remove(IInstruction value)
		{
			this.instructions.Remove(value);
		}

		public void RemoveAt(int index)
		{
			this.instructions.RemoveAt(index);
		}

		public IInstruction this[int index]
		{
			get
			{
				return this.instructions[index];
			}
			set
			{
				this.instructions[index] = value;
			}
		}

		public void CopyTo(Array array, int index)
		{
			this.instructions.CopyTo((IInstruction[])array, index);
		}

		public int Count
		{
			get
			{
				return this.instructions.Count;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		public object SyncRoot
		{
			get
			{
				return null;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return this.instructions.GetEnumerator();
		}
	}
}
