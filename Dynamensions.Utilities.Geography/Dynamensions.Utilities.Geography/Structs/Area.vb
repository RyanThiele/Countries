Public Structure Area

    ''' <summary>
    ''' The area in square Kilometers.
    ''' </summary>
    Public ReadOnly Property AreaSquareKilometers As Double

    ''' <summary>
    ''' The area in square miles.
    ''' </summary>
    Public ReadOnly Property AreaSquareMiles As Double

    ''' <summary>
    ''' Initializes a new <see cref="Area"/>.
    ''' </summary>
    ''' <param name="area">The area in squared measurements.</param>
    ''' <param name="distanceType">Optional. The type of measurement. Default is Kilometers.</param>
    Public Sub New(area As Double, Optional distanceType As DistanceTypes = DistanceTypes.Kilometers)
        If distanceType = DistanceTypes.Kilometers Then
            AreaSquareKilometers = area
            AreaSquareMiles = CType(area, Decimal).ToMiles()
        Else
            AreaSquareKilometers = area
            AreaSquareMiles = CType(area, Decimal).ToKilometers
        End If
    End Sub


    Public Overloads Function ToString(distanceType As DistanceTypes, Optional decimals As Integer = 2) As String
        Dim area As Double

        If distanceType = DistanceTypes.Kilometers Then
            area = AreaSquareKilometers
        Else
            area = AreaSquareMiles
        End If

        Return $"{Decimal.Round(CType(area, Decimal), decimals)}²"

    End Function

    Public Overrides Function ToString() As String
        Return $"{AreaSquareKilometers}² Kilometers, {AreaSquareMiles}² Miles"
    End Function

End Structure
