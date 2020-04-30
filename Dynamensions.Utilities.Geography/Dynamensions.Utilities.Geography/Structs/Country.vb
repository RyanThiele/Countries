Imports System.Drawing
Imports System.IO
Imports System.Reflection

Public Structure Country


    ''' <summary>
    ''' Read only. The name of the country.
    ''' </summary>
    Public ReadOnly Property Name As String

    ''' <summary>
    ''' Read only. The official name of the country.
    ''' </summary>
    Public ReadOnly Property OfficialName As String


    ''' <summary>
    ''' Read only. The capitol city of the country.
    ''' </summary>
    Public ReadOnly Property CapitalCity As String

    ''' <summary>
    ''' Read only. The Country Code (ISO 3166-1) of the country.
    ''' </summary>
    Public ReadOnly Property CountryCode As String

    ''' <summary>
    ''' Read only. The continent of the country.
    ''' </summary>
    Public ReadOnly Property Continent As String

    ''' <summary>
    ''' Read only. The affilitions of the country.
    ''' </summary>
    Public ReadOnly Property Affiliations As String()


    ''' <summary>
    ''' Read only. The <see cref="Area"/> of the country.
    ''' </summary>
    Public ReadOnly Property Area As Area

    ''' <summary>
    ''' Read only. The highest point of the country.
    ''' </summary>
    Public ReadOnly Property HighestPoint As CountryPoint

    ''' <summary>
    ''' Read only. The lowest point of the country.
    ''' </summary>
    Public ReadOnly Property LowestPoint As CountryPoint


    ''' <summary>
    ''' Read only. The currency of the country.
    ''' </summary>
    Public ReadOnly Property Currency As Currency


    ''' <summary>
    ''' Read only. The emoji of the country.
    ''' </summary>
    Public ReadOnly Property Emoji As String

    ''' <summary>
    ''' Read only. The Alt-code of the country.
    ''' </summary>
    Public ReadOnly Property AltCode As String

    ''' <summary>
    ''' Read only. The flag of the country.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Image As Image

    ''' <summary>
    ''' Read only. The independent status of the country.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property IsIndependent As Boolean

    ''' <summary>
    ''' The calling code used when calling the country.
    ''' </summary>
    Public ReadOnly Property CallingCode As Integer

    ''' <summary>
    ''' The domain extension affiliated with the country.
    ''' </summary>
    Public ReadOnly Property InternetTopLevelDomain As String


    ''' <summary>
    ''' Initializes a new <see cref="Country" /> structure.
    ''' </summary>
    ''' <param name="name">The name of the country.</param>
    ''' <param name="officialName">The official name of the country.</param>
    ''' <param name="capitalCity">The capital city of the country.</param>
    ''' <param name="countryCode">The ISO 1366-1 country code.</param>
    ''' <param name="continent">The continent the country belongs to.</param>
    ''' <param name="affiliations">The affiliaitons the country is a member.</param>
    ''' <param name="area">The <see cref="Area"/> of the country.</param>
    ''' <param name="highestPoint">A <see cref="CountryPoint"/> containing the heighest point.</param>
    ''' <param name="lowestPoint">A <see cref="CountryPoint"/> containing the lowest point.</param>
    ''' <param name="currency">A <see cref="Currency"/> containing the currency the country uses.</param>
    ''' <param name="emoji">The emoji for the country.</param>
    ''' <param name="flagImagePath">The internal file image path that will be loaded at runtime.</param>
    ''' <param name="isIndependent">The country's independence.</param>
    ''' <param name="callingCode">The calling code (long distance) for the country.</param>
    ''' <param name="toplevelDomain">The internet top level domain for the country.</param>
    Friend Sub New(name As String, officialName As String,
                   capitalCity As String, countryCode As String, continent As String,
                   affiliations() As String, area As Area,
                   highestPoint As CountryPoint, lowestPoint As CountryPoint, currency As Currency,
                   emoji As String, flagImagePath As String, isIndependent As Boolean,
                   callingCode As Integer, toplevelDomain As String)

        Me.Name = name
        Me.CapitalCity = capitalCity
        Me.CountryCode = countryCode
        Me.Continent = continent
        Me.Affiliations = affiliations
        Me.Area = area
        Me.HighestPoint = highestPoint
        Me.LowestPoint = lowestPoint
        Me.Currency = currency
        Me.Emoji = emoji
        Me.AltCode = AltCode
        Me.IsIndependent = isIndependent
        Me.CallingCode = callingCode
        Me.InternetTopLevelDomain = toplevelDomain

        If Not String.IsNullOrWhiteSpace(flagImagePath) Then
            Dim assembly As Assembly = Me.GetType().Assembly
            Dim resourceName As String = "Dynamensions.Utilties.Countries.Images." & flagImagePath

            Using resourceStream As Stream = assembly.GetManifestResourceStream(resourceName)
                If resourceStream IsNot Nothing Then
                    Image = Image.FromStream(resourceStream)
                End If
            End Using
        End If
    End Sub


    ''' <summary>
    ''' Initializes a new <see cref="Country" /> structure using metric measurements.
    ''' </summary>
    ''' <param name="name">The name of the country.</param>
    ''' <param name="officialName">The official name of the country.</param>
    ''' <param name="capitalCity">The capital city of the country.</param>
    ''' <param name="countryCode">The ISO 1366-1 country code.</param>
    ''' <param name="continent">The continent the country belongs to.</param>
    ''' <param name="affiliations">The affiliaitons the country is a member.</param>
    ''' <param name="areaInKM">The area of the country measured in Kilometers.</param>
    ''' <param name="highestPoint">A <see cref="CountryPoint"/> containing the heighest point.</param>
    ''' <param name="lowestPoint">A <see cref="CountryPoint"/> containing the lowest point.</param>
    ''' <param name="currency">A <see cref="Currency"/> containing the currency the country uses.</param>
    ''' <param name="emoji">The emoji for the country.</param>
    ''' <param name="flagImagePath">The internal file image path that will be loaded at runtime.</param>
    ''' <param name="isIndependent">The country's independence.</param>
    ''' <param name="callingCode">The calling code (long distance) for the country.</param>
    ''' <param name="toplevelDomain">The internet top level domain for the country.</param>
    Friend Sub New(name As String, officialName As String, capitalCity As String, countryCode As String, continent As String,
                   affiliations() As String, areaInKM As Integer,
                   highestPoint As CountryPoint, lowestPoint As CountryPoint, currency As Currency,
                   emoji As String, flagImagePath As String, isIndependent As Boolean,
                   callingCode As Integer, topleveldomain As String)

        MyClass.New(name:=name,
                    officialName:=officialName,
                    capitalCity:=capitalCity,
                    countryCode:=countryCode,
                    continent:=continent,
                    affiliations:=affiliations,
                    area:=New Area(areaInKM),
                    highestPoint:=highestPoint,
                    lowestPoint:=lowestPoint,
                    currency:=currency,
                    emoji:=emoji,
                    flagImagePath:=flagImagePath,
                    isIndependent:=isIndependent,
                    callingCode:=callingCode,
                    toplevelDomain:=topleveldomain)
    End Sub

End Structure
