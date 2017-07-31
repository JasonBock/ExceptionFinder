Public Module FilterHandlerScenarios
	Public Function TryWithCatchAndFilterThatMightThrowException(ByVal denominator As Integer) As Integer
		Dim x As Integer

		Try
			x = 3 \ denominator
		Catch ex As DivideByZeroException _
			When FilterHandlerScenarios.DoesThisThrowException(2)
			Throw New NotSupportedException("Can't divide by zero.", ex)
		End Try

		Return x
	End Function

	Public Function DoesThisThrowException(ByVal i As Integer) As Boolean
		If i Mod 2 = 0 Then
			Throw New NotImplementedException()
		End If

		Return False
	End Function
End Module
