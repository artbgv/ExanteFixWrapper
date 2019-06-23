Public Class PaintingTools
    ' данный класс содержит инструменты рисования
    ' экземпляр данного класса создается при инициализации экземпляра класса ChartPainting
    Public btmTrades As Bitmap
    Public btmTimes As Bitmap
    Public btmPrices As Bitmap
    Public btmVolumes As Bitmap
    Public btmVolumesVolumes As Bitmap

    Public brush As SolidBrush
    Public font As Font
    Public P_RedLine As Pen
    Public P_RedLine2 As Pen
    Public P_BlueLine As Pen
    Public P_BlueLine2 As Pen
    Public P_OrangeLine2 As Pen
    Public P_GrayLine As Pen
    Public P_DashedLine As Pen
    Public P_LightBlueLine As Pen
    Public P_LightPinkLine As Pen
    Public P_BlackLine As Pen
    Public GreenBrush As SolidBrush
    Public rectangleForPrice As RectangleF
    Public rectangleForVolume As RectangleF
    Public rectangleForCandle As RectangleF
    Public G_Trades As Graphics
    Public G_Times As Graphics
    Public G_Prices As Graphics
    Public G_Volumes As Graphics
    Public G_VolumesVolumes As Graphics

    Public Sub New(TradesPctBox As PictureBox,
                   TimesTradesPctBox As PictureBox,
                   PricesTradesPctBox As PictureBox,
                   VolumesTradesPctBox As PictureBox,
                   VolumesVolumesTradesPctBox As PictureBox)

        Me.btmTrades = New Bitmap(TradesPctBox.Width, TradesPctBox.Height)
        Me.btmTimes = New Bitmap(TimesTradesPctBox.Width, TimesTradesPctBox.Height)
        Me.btmPrices = New Bitmap(PricesTradesPctBox.Width, PricesTradesPctBox.Height)
        Me.btmVolumes = New Bitmap(VolumesTradesPctBox.Width, VolumesTradesPctBox.Height)
        Me.btmVolumesVolumes = New Bitmap(VolumesVolumesTradesPctBox.Width, VolumesVolumesTradesPctBox.Height)

        Me.brush = New SolidBrush(Color.Black)
        Me.font = New Font("Arial", 8, FontStyle.Regular)
        Me.P_RedLine = New Pen(Color.Red, 1)
        Me.P_RedLine2 = New Pen(Color.Red, 2)
        Me.P_BlueLine = New Pen(Color.Blue, 1)
        Me.P_BlueLine2 = New Pen(Color.Blue, 2)
        Me.P_OrangeLine2 = New Pen(Color.Orange, 2)
        Me.P_GrayLine = New Pen(Color.Gray, 0.3)
        Me.P_DashedLine = New Pen(Color.Black)
        P_DashedLine.DashStyle = Drawing2D.DashStyle.Dash
        Me.P_LightBlueLine = New Pen(Color.LightBlue, 2)
        Me.P_LightPinkLine = New Pen(Color.LightPink, 2)
        Me.P_BlackLine = New Pen(Color.Black, 1)
        Me.GreenBrush = New SolidBrush(Color.Green)
        Me.rectangleForPrice = New RectangleF
        Me.rectangleForVolume = New RectangleF
        Me.rectangleForCandle = New RectangleF


        G_Trades = TradesPctBox.CreateGraphics
        G_Trades.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        G_Times = TimesTradesPctBox.CreateGraphics
        G_Times.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        G_Prices = PricesTradesPctBox.CreateGraphics
        G_Prices.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        G_Volumes = VolumesTradesPctBox.CreateGraphics
        G_Volumes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        G_VolumesVolumes = VolumesVolumesTradesPctBox.CreateGraphics
    End Sub
End Class
