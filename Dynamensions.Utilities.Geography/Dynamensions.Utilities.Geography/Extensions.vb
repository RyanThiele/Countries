Imports System.Runtime.CompilerServices

Module Extensions

    <Extension>
    Friend Function ToMiles(kilometers As Decimal) As Decimal
        If kilometers = 0 Then
            Return 0
        Else
            Return Decimal.Divide(kilometers, 1.609344)
        End If
    End Function

    <Extension>
    Friend Function ToKilometers(miles As Decimal) As Decimal
        Return Decimal.Multiply(miles, 1.609344)
    End Function


End Module
