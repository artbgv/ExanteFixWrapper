Public Class QuotesInfo
    Public AskPrice As Double?
    Public AskVolume As Double?
    Public BidPrice As Double?
    Public BidVolume As Double?
    Public TradePrice As Double?
    Public TradeVolume As Double?
    Public MovingAverage As Double?
    Public TimeStamp As DateTime
    Public LocalTimeStamp As DateTime
    Public ExanteId As String
    Public Direction As Directions
    Public Message As String
    Public Enum Directions
        Sell
        Buy
        Undefined
    End Enum

    Sub New()
        Me.AskPrice = Nothing
        Me.AskVolume = Nothing
        Me.BidPrice = Nothing
        Me.BidVolume = Nothing
        Me.TradePrice = Nothing
        Me.TradeVolume = Nothing
        Me.Direction = Directions.Undefined
    End Sub
End Class
