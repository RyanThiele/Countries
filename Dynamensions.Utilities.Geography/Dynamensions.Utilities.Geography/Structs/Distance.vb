Public Structure Distance
    ''' <summary>
    ''' The distance in Kilometers.
    ''' </summary>
    Public ReadOnly Property DistanceInKilometers As Double

    ''' <summary>
    ''' The distance in miles.
    ''' </summary>
    Public ReadOnly Property DistanceInMiles As Double


    ''' <summary>
    ''' Initializes a new <see cref="Distance"/> structure.
    ''' </summary>
    ''' <param name="distance">The distance.</param>
    ''' <param name="distanceType">Optional. The distance type. Default is Kilometers.</param>
    Public Sub New(distance As Double, Optional distanceType As DistanceTypes = DistanceTypes.Kilometers)
        If distanceType = DistanceTypes.Kilometers Then
            DistanceInKilometers = distance
            DistanceInMiles = CType(distance, Decimal).ToMiles()
        Else
            DistanceInKilometers = distance
            DistanceInMiles = CType(distance, Decimal).ToKilometers
        End If
    End Sub

    Public Overloads Function ToString(distanceType As DistanceTypes, Optional decimals As Integer = 2) As String
        Dim distance As Double

        If distanceType = DistanceTypes.Kilometers Then
            distance = DistanceInKilometers
        Else
            distance = DistanceInMiles
        End If

        Return $"{Decimal.Round(CType(distance, Decimal), decimals)}²"

    End Function

    Public Overrides Function ToString() As String
        Return $"{DistanceInKilometers}² Kilometers, {DistanceInMiles}² Miles"
    End Function


End Structure
