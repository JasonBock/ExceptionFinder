[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "ExceptionFinder")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", Scope = "member", Target = "ExceptionFinder.Analyzers.InstructionAnalyzer..ctor(Reflector.CodeModel.IInstructionCollection,System.Int32)", MessageId = "System.ArgumentException.#ctor(System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "ExceptionFinder.Analyzers.LeakedExceptionsMethodInstructionAnalyzer.#method")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "newException", Scope = "member", Target = "ExceptionFinder.Analyzers.LeakedExceptionsMethodInstructionAnalyzer.#GetThrownExceptions(Reflector.CodeModel.IInstructionCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "exception", Scope = "member", Target = "ExceptionFinder.Analyzers.LeakedExceptionsMethodInstructionAnalyzer.#GetThrownExceptions(Reflector.CodeModel.IInstructionCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "ExceptionFinder.Analyzers")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "leakedExceptions", Scope = "member", Target = "ExceptionFinder.Analyzers.LeakedExceptionsInstructionsAnalyzer.#AddLeakedExceptions(System.Collections.Generic.Dictionary`2<System.Type,System.Collections.Generic.List`1<ExceptionFinder.Analyzers.InstructionLocation>>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "leakedExceptions", Scope = "member", Target = "ExceptionFinder.Analyzers.LeakedExceptionsCollection.#AddLeakedExceptions(System.Collections.Generic.Dictionary`2<System.Type,System.Collections.Generic.List`1<ExceptionFinder.Analyzers.InstructionLocation>>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "leakedExceptions", Scope = "member", Target = "ExceptionFinder.Analyzers.LeakedExceptionsCollection.#AddLeakedExceptions(System.Collections.Generic.IDictionary`2<System.Type,System.Collections.Generic.List`1<ExceptionFinder.Analyzers.InstructionLocation>>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "method", Scope = "member", Target = "ExceptionFinder.Extensions.ListOfIInstructionExtensions.#GetThrownException(System.Collections.Generic.List`1<Reflector.CodeModel.IInstruction>,System.Int32,Reflector.CodeModel.IMethodDeclaration)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Scope = "member", Target = "ExceptionFinder.ExceptionFinderView.#Resolve(System.Object)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "resolvedObject", Scope = "member", Target = "ExceptionFinder.ExceptionFinderView.#CheckActiveItem(Reflector.CodeModel.IMethodDeclaration)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom", Scope = "member", Target = "ExceptionFinder.ExceptionFinderView.#Resolve(Reflector.CodeModel.IMethodDeclaration)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom", Scope = "member", Target = "ExceptionFinder.Extensions.IAssemblyLocationExtensions.#Load(Reflector.CodeModel.IAssemblyLocation)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "loadedAssembly", Scope = "member", Target = "ExceptionFinder.Extensions.IAssemblyLocationExtensions.#Load(Reflector.CodeModel.IAssemblyLocation)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "targetName", Scope = "member", Target = "ExceptionFinder.Extensions.IAssemblyLocationExtensions.#Load(Reflector.CodeModel.IAssemblyLocation)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object[])", Scope = "member", Target = "ExceptionFinder.Extensions.IAssemblyLocationExtensions.#Load(Reflector.CodeModel.IAssemblyLocation)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type", Target = "ExceptionFinder.ExceptionFinderPackage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "serviceProvider", Scope = "member", Target = "ExceptionFinder.ExceptionFinderPackage.#Load(System.IServiceProvider)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly", Scope = "type", Target = "ExceptionFinder.Analyzers.NonExceptionTypeException")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "leakedExceptions", Scope = "member", Target = "ExceptionFinder.ExceptionFinderView.#ShowLeakedExceptions(System.Collections.Generic.IDictionary`2<ExceptionFinder.Analyzers.LeakedException,System.Collections.Generic.List`1<ExceptionFinder.Analyzers.InstructionLocation>>,System.Windows.Forms.TreeNode)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "leakedExceptions", Scope = "member", Target = "ExceptionFinder.ExceptionFinderView.#ShowLeakedExceptions(System.Collections.Generic.IDictionary`2<ExceptionFinder.Analyzers.LeakedException,System.Collections.Generic.List`1<ExceptionFinder.Analyzers.InstructionLocation>>,System.Windows.Forms.TreeNode,System.Windows.Forms.TreeNode)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "ExceptionFinder.Extensions.OpCodeExtensions.#IsOverflow(System.Reflection.Emit.OpCode)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly", Scope = "type", Target = "ExceptionFinder.Analyzers.ArgumentsException")]