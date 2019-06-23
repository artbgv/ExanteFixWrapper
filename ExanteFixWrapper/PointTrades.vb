Public Class PointTrades
    Public tradePrice As Double
    Public tradeVolume As Double
    Public time As DateTime

    Public Sub New()

    End Sub

    Public Sub New(tradePrice As Double, tradeVolume As Double, time As DateTime)
        Me.tradePrice = tradePrice
        Me.tradeVolume = tradeVolume
        Me.time = time

    End Sub
End Class
