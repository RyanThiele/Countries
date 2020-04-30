Imports System.Drawing
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Dynamensions.Utilities.Geography.Tests
    <TestClass>
    Public Class CountriesTests


        <TestMethod>
        Sub Countries_ShouldHaveFlagImages()
            ' Arrange
            Dim countries As New Countries
            Dim countriesMissingFlags As New List(Of Country)

            ' Act
            For Each country As Country In countries
                Dim image As Image = country.Image
                If image Is Nothing Then
                    countriesMissingFlags.Add(country)
                    Continue For
                End If

                If image.Width = 0 Or image.Height = 0 Then
                    countriesMissingFlags.Add(country)
                    Continue For
                End If
            Next

            ' Assert
            Assert.IsTrue(countriesMissingFlags.Count = 0, $"There are {countriesMissingFlags.Count} countries missing flags: {vbCrLf & String.Join(",", countriesMissingFlags.Select(Function(c) c.Name))}")
        End Sub


        <TestMethod>
        Sub Countries_ShouldHaveCurrency()
            ' Arrange
            Dim countries As New Countries
            Dim countriesMissingCurrencies As New List(Of Country)

            ' Act
            For Each country As Country In countries
                Dim currency As Currency = country.Currency
                If String.IsNullOrWhiteSpace(currency.Name) Then
                    countriesMissingCurrencies.Add(country)
                    Continue For
                End If
            Next

            ' Assert
            Assert.IsTrue(countriesMissingCurrencies.Count = 0,
                          $"There are {countriesMissingCurrencies.Count} countries missing currencies: {vbCrLf & String.Join(",", countriesMissingCurrencies.Select(Function(c) $"{c.Name}"))}")

        End Sub

    End Class
End Namespace

