// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project. 
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc. 
//
// To add a suppression to this file, right-click the message in the 
// Error List, point to "Suppress Message(s)", and click 
// "In Project Suppression File". 
// You do not need to add suppressions to this file manually. 

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "ExceptionFinder.TestTarget.ExceptionHandlerScenarios.#TryCatchWithCaughtException()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "ExceptionFinder.TestTarget.IndirectRecursiveCall")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "ExceptionFinder.TestTarget.NestedExceptionHandlers")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ExceptionFinder.TestTarget.NestedExceptionHandlers.#ParseMe(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "ExceptionFinder.TestTarget.NestedExceptionHandlers.#ParseMe(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.TestTarget.NestedExceptionHandlers.#ParseMe(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Scope = "member", Target = "ExceptionFinder.TestTarget.ExceptionHandlerScenarios.#NoHandlers(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "ExceptionFinder.TestTarget.ExceptionHandlerScenarios.#NoHandlers(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "ExceptionFinder.TestTarget.RecursiveCallScenarios")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "COM", Scope = "member", Target = "ExceptionFinder.TestTarget.OddballCallScenarios.#CallCOMServer()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "COM", Scope = "member", Target = "ExceptionFinder.TestTarget.NativeCallScenarios.#CallCOMServer()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Scope = "member", Target = "ExceptionFinder.TestTarget.ExceptionHandlerScenarios.#ComplexHandlers(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2219:DoNotRaiseExceptionsInExceptionClauses", Scope = "member", Target = "ExceptionFinder.TestTarget.ExceptionHandlerScenarios.#TryFinallyWithEmbeddedTryAndEscapingException()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2219:DoNotRaiseExceptionsInExceptionClauses", Scope = "member", Target = "ExceptionFinder.TestTarget.ExceptionHandlerScenarios.#TryFinallyWithRecursiveCall()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "s", Scope = "member", Target = "ExceptionFinder.TestTarget.FrameworkScenarios.#WarmUp()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "ExceptionFinder.TestTarget")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "s", Scope = "member", Target = "ExceptionFinder.TestTarget.FrameworkInitialization.#Initialize()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "ExceptionFinder.TestTarget.FrameworkInitialization.#Initialize()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ExceptionHandlerScenarios.#ComplexHandlers(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ExceptionHandlerScenarios.#NoHandlers(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ExceptionHandlerScenarios.#NoHandlers(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ExceptionHandlerScenarios.#TryCatchWithCaughtException()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "COM", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.NativeCallScenarios.#CallCOMServer()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2219:DoNotRaiseExceptionsInExceptionClauses", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ExceptionHandlerScenarios.#TryFinallyWithRecursiveCall()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#ThrowArgument(System.Exception)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "ExceptionFinder.Tests.Scenarios")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#ThrowArgumentFromInstance(System.Exception)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#ReturnException()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#CreateObjectThatThrowsOnConstruction()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.InternalClassThatThrowsExceptionOnConstruction.#DoSomething()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#ThrowReportedExceptions(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#ThrowReportedExceptions(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#ThrowReportedExceptions(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#RethrowException()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ExceptionFinder.Tests.Scenarios.ThrowingScenarios.#ThrowCustomException()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Scope = "type", Target = "ExceptionFinder.Tests.Scenarios.CustomException")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Scope = "type", Target = "ExceptionFinder.Tests.Scenarios.CustomException")]
