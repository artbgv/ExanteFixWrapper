Public Class PointTradesNsec
    Public openPrice As Double
    Public closePrice As Double
    Public highPrice As Double
    Public lowPrice As Double
    Public volumeSell As Double
    Public volumeBuy As Double
    Public time As DateTime
    Public avgBuy As Double
    Public avgSell As Double
    Public avgBuyPlusSell As Double
    Public Sub New()
        openPrice = 0
        closePrice = 0
        highPrice = 0
        lowPrice = 0
        volumeBuy = 0
        volumeSell = 0
        time = Nothing
        avgBuy = 0
        avgSell = 0
        avgBuyPlusSell = 0
    End Sub
    Public Sub New(buffer As Buffer)
        openPrice = buffer.openPrice
        closePrice = buffer.closePrice
        highPrice = buffer.highPrice
        lowPrice = buffer.lowPrice
        volumeBuy = buffer.volumeBuy
        volumeSell = buffer.volumeSell
        time = buffer.startTimeFrame
        'avgBuy = buffer.avgVolumeBuy
        'avgSell = buffer.avgVolumeSell
        'avgBuyPlusSell = buffer.avgVolumeCommon
    End Sub
End Class
