﻿using Reflector.CodeModel;
using System;

namespace ExceptionFinder.Tests
{
	internal sealed class MockMethodDeclaration : IMethodDeclaration
	{
		public bool Abstract
		{
			get;
			set;
		}

		public object Body
		{
			get;
			set;
		}

		public bool Final
		{
			get;
			set;
		}

		public bool HideBySignature
		{
			get;
			set;
		}

		public bool NewSlot
		{
			get;
			set;
		}

		public IMethodReferenceCollection Overrides
		{
			get;
			set;
		}

		public bool RuntimeSpecialName
		{
			get;
			set;
		}

		public bool SpecialName
		{
			get;
			set;
		}

		public bool Static
		{
			get;
			set;
		}

		public bool Virtual
		{
			get;
			set;
		}

		public MethodVisibility Visibility
		{
			get;
			set;
		}

		public IMethodReference GenericMethod
		{
			get;
			set;
		}

		public IMethodDeclaration Resolve()
		{
			throw new NotImplementedException();
		}

		public IType DeclaringType
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}

		public MethodCallingConvention CallingConvention
		{
			get;
			set;
		}

		public bool ExplicitThis
		{
			get;
			set;
		}

		public bool HasThis
		{
			get;
			set;
		}

		public IParameterDeclarationCollection Parameters
		{
			get;
			private set;
		}

		public IMethodReturnType ReturnType
		{
			get;
			set;
		}

		public ITypeCollection GenericArguments
		{
			get;
			private set;
		}

		public ICustomAttributeCollection Attributes
		{
			get;
			private set;
		}

		public string Documentation
		{
			get;
			set;
		}

		public int Token
		{
			get { throw new NotImplementedException(); }
		}
	}
}
