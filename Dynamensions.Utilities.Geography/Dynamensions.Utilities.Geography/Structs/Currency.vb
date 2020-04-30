
Public Structure Currency

    ''' <summary>
    ''' Read only. The name of the currency.
    ''' </summary>
    Public ReadOnly Property Name As String

    ''' <summary>
    ''' Read only. The ISO-Code of the currency.
    ''' </summary>
    Public ReadOnly Property IsoCode As String

    ''' <summary>
    ''' Creates a new <see cref="Currency"/>.
    ''' </summary>
    ''' <param name="name">The name of the currency.</param>
    ''' <param name="isoCode">The ISO-Code of the currency.</param>
    Public Sub New(name As String, isoCode As String)
        Me.Name = name
        Me.IsoCode = isoCode
    End Sub

End Structure