Public Structure CountryPoint
    ''' <summary>
    ''' The name of the point
    ''' </summary>
    Public ReadOnly Property Name As String

    ''' <summary>
    ''' A <see cref="Distance"/> contining the altitude of the point.
    ''' </summary>
    Public ReadOnly Property Altitude As Distance

    ''' <summary>
    ''' Initializes a new <see cref="CountryPoint"/>.
    ''' </summary>
    ''' <param name="name">The name of the country point.</param>
    ''' <param name="altitudeKM">A <see cref="Distance"/> containing the altitude.</param>
    Public Sub New(name As String, altitude As Distance)
        Me.Name = name
        Me.Altitude = altitude
    End Sub

    ''' <summary>
    ''' Initializes a new <see cref="CountryPoint"/> using Kilometers
    ''' </summary>
    ''' <param name="name">The name of the country point.</param>
    ''' <param name="altitudeKM">The altitude in Kilometers.</param>
    Public Sub New(name As String, altitudeKM As Double)
        Me.Name = name
        Me.Altitude = New Distance(altitudeKM)
    End Sub

End Structure
