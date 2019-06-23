Public Class PointQuotes
    Public askPrice As Double
    Public askVolume As Double
    Public bidPrice As Double
    Public bidVolume As Double
    Public time As DateTime

    Public Sub New()

    End Sub

    Public Sub New(askPrice As Double, askVolume As Double, bidPrice As Double, bidVolume As Double, time As DateTime)
        Me.askPrice = askPrice
        Me.askVolume = askVolume
        Me.bidPrice = bidPrice
        Me.bidVolume = bidVolume
        Me.time = time
    End Sub
End Class
