Imports ExanteFixWrapper.Form1
'данный класс реализует логику отрисовки графиков
'класс содержит три метода - отрисовка котировок и отрисовка сделок для тикового и пятисекундного графика
Public Class ChartPainting
    Public pointsQuotes As List(Of PointQuotes) 'список котировок
    Public pointsTrades As List(Of PointTrades) 'список сделок
    Public pointsTrades5sec As List(Of PointTradesNsec) 'список сделок для 5-секундного графика
    Public pointsTrades10sec As List(Of PointTradesNsec)
    Public pointsTrades15sec As List(Of PointTradesNsec)
    Public pointsTrades30sec As List(Of PointTradesNsec)
    Public pointsTrades60sec As List(Of PointTradesNsec)
    Public pointsTrades300sec As List(Of PointTradesNsec)
    Public pointsTrades600sec As List(Of PointTradesNsec)
    Public pointsTrades900sec As List(Of PointTradesNsec)
    Public pointsTrades1800sec As List(Of PointTradesNsec)
    Public pointsTrades3600sec As List(Of PointTradesNsec)
    Public pointsTradesNsec As List(Of PointTradesNsec)

    'котировки - тики
    Public pointsOnScreenQuotes As Integer 'количество точек на экране
    Public intervalQuotes As Double 'интервал, приходящийся на одну точку графика в пикселях (по оси Х)
    Public currentPointQuotes As Integer 'первая точка графика на экране
    Public lastPointQuotes As Integer 'последняя точка графика на экране
    Public yRangeQuotes As Double 'интервал, приходящйся на ось Y в пикселях
    Public needRePaintingQuotes As Boolean 'нужно ли обновлять график (если да, то при каждом тике currentPointQuotes увеличивается на 1, график сдвигается вправо)
    Public lowBorderQuotes As Double 'нижняя граница в денежных единицах
    Public highBorderQuotes As Double 'верхняя граница в денежных единицах
    Public maxPointsOnScreenQuotes As Integer 'максимальное количество точек на экране
    Public minPointsOnScreenQuotes As Integer 'минимальное количество точек на экране
    'сделки - тики
    Public pointsOnScreenTrades As Integer
    Public intervalTrades As Double
    Public currentPointTrades As Integer
    Public lastPointTrades As Integer
    Public yRangeTrades As Double
    Public needRePaintingTrades As Boolean
    Public lowBorderTrades As Double
    Public highBorderTrades As Double
    Public maxPointsOnScreenTrades As Integer
    Public minPointsOnScreenTrades As Integer
    Public maxVolumeTrades As Double
    Public highBorderVolumesTrades As Double
    Public yRangeVolumesTrades As Double
    'сделки - 5 секунд (линии)
    Public pointsOnScreenTradesNsec As Integer
    Public intervalTradesNsec As Double
    Public currentPointTradesNsec As Integer
    Public lastPointTradesNsec As Integer
    Public yRangeTradesNsec As Double
    Public needRePaintingTradesNsec As Boolean
    Public lowBorderTradesNsec As Double
    Public highBorderTradesNsec As Double
    Public maxPointsOnScreenTradesNsec As Integer
    Public minPointsOnScreenTradesNsec As Integer
    Public highBorderVolumesTradesAvgNsec As Double
    Public highBorderVolumesTradesNsec As Double
    Public yRangeVolumesTradesNsec As Double
    'рисование линии - котировки
    Public needDrawLineQuotes As Boolean
    Public point1Quotes As PointF
    Public point2Quotes As PointF
    Public isDrawingStartedQuotes As Boolean
    Public isLineReadyQuotes As Boolean
    'рисование линии - сделки
    Public needDrawLineTrades As Boolean
    Public point1Trades As PointF
    Public point2Trades As PointF
    Public isDrawingStartedTrades As Boolean
    Public isLineReadyTrades As Boolean

    Public isCloned As Boolean
    Public usedForm As Form
    Public isSubscribed As Boolean
    Public isNeedShowAvg As Boolean
    Public isCursorOnTradesChart As Boolean
    Public pointMouseMoveTrades As PointF
    Public currentTradePriceMM As Double
    Public isCursorOnVolumesChart As Boolean
    Public pointMouseMoveVolumes As PointF
    Public currentVolumeMM As Double
    Public isCursorOnQuotesChart As Boolean
    Public pointMouseMoveQuotes As PointF
    Public currentQuotesPriceMM As Double
    Public isClickedTrades As Boolean
    Public positionOfClickTrades As PointF
    Public isClickedQuotes As Boolean
    Public positionOfClickQuotes As PointF

    Private stopWatch As Stopwatch
    Private pt As PaintingTools

    Public Sub New(usedForm As Form,
                   TradesPctBox As PictureBox,
                   TimesTradesPctBox As PictureBox,
                   PricesTradesPctBox As PictureBox,
                   VolumesTradesPctBox As PictureBox,
                   VolumesVolumesTradesPctBox As PictureBox)
        'котировки - тики
        Me.pointsQuotes = New List(Of PointQuotes)
        Me.pointsOnScreenQuotes = 20
        Me.currentPointQuotes = 0
        Me.needRePaintingQuotes = True
        Me.maxPointsOnScreenQuotes = 800
        Me.minPointsOnScreenQuotes = 10
        'сделки - тики
        Me.pointsTrades = New List(Of PointTrades)
        Me.pointsOnScreenTrades = 40
        Me.currentPointTrades = 0
        Me.needRePaintingTrades = True
        Me.maxPointsOnScreenTrades = 800
        Me.minPointsOnScreenTrades = 10
        Me.maxVolumeTrades = 0
        'сделки - N секунд
        Me.pointsTrades5sec = New List(Of PointTradesNsec)
        Me.pointsTrades10sec = New List(Of PointTradesNsec)
        Me.pointsTrades15sec = New List(Of PointTradesNsec)
        Me.pointsTrades30sec = New List(Of PointTradesNsec)
        Me.pointsTrades60sec = New List(Of PointTradesNsec)
        Me.pointsTrades300sec = New List(Of PointTradesNsec)
        Me.pointsTrades600sec = New List(Of PointTradesNsec)
        Me.pointsTrades900sec = New List(Of PointTradesNsec)
        Me.pointsTrades1800sec = New List(Of PointTradesNsec)
        Me.pointsTrades3600sec = New List(Of PointTradesNsec)

        Me.pointsOnScreenTradesNsec = 40
        Me.currentPointTradesNsec = 0
        Me.needRePaintingTradesNsec = True
        Me.maxPointsOnScreenTradesNsec = 800
        Me.minPointsOnScreenTradesNsec = 10
        If (Not Form1.isOnline) Then
            Me.currentPointTradesNsec = 0
        End If
        'рисование линий
        Me.needDrawLineQuotes = False
        Me.isDrawingStartedQuotes = False
        Me.isLineReadyQuotes = False
        Me.needDrawLineTrades = False
        Me.isDrawingStartedTrades = False
        Me.isLineReadyTrades = False

        Me.isCloned = False
        Me.usedForm = usedForm
        Me.isSubscribed = False

        Me.stopWatch = New Stopwatch
        Me.pt = New PaintingTools(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)

    End Sub

    Public Sub paintingQuotes(QuotesPctBox As PictureBox, TimesQuotesPctBox As PictureBox, PricesQuotesPctBox As PictureBox)
        Try
            If (needRePaintingQuotes) Then
                If (Me.pointsQuotes.Count > Me.pointsOnScreenQuotes) Then
                    currentPointQuotes += 1
                End If
            End If

            If pointsQuotes.Count > pointsOnScreenQuotes Then
                Dim numberToCompare As Integer = pointsQuotes.Count - pointsOnScreenQuotes - 1
                If currentPointQuotes > numberToCompare Then
                    currentPointQuotes = numberToCompare
                End If
                If currentPointQuotes < 0 Then
                    currentPointQuotes = 0
                End If
                lastPointQuotes = currentPointQuotes + pointsOnScreenQuotes
            Else
                currentPointQuotes = 0
                lastPointQuotes = pointsQuotes.Count - 1
            End If


            intervalQuotes = QuotesPctBox.Width / pointsOnScreenQuotes

            Dim G_Quotes As Graphics = QuotesPctBox.CreateGraphics
            G_Quotes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim btm As New Bitmap(QuotesPctBox.Width, QuotesPctBox.Height)
            Dim G_btm = Graphics.FromImage(btm)
            G_btm.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim G_Times = TimesQuotesPctBox.CreateGraphics
            G_Times.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim btmTimes As New Bitmap(TimesQuotesPctBox.Width, TimesQuotesPctBox.Height)
            Dim G_btmTimes = Graphics.FromImage(btmTimes)
            G_btmTimes.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            G_btmTimes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim G_Prices As Graphics = PricesQuotesPctBox.CreateGraphics
            G_Prices.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim btmPrices As New Bitmap(PricesQuotesPctBox.Width, PricesQuotesPctBox.Height)
            Dim G_btmPrices = Graphics.FromImage(btmPrices)
            G_btmPrices.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            G_btmPrices.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim brush As New SolidBrush(Color.Black)
            Dim redBrush As New SolidBrush(Color.Red)
            Dim blueBrush As New SolidBrush(Color.Blue)
            Dim font As New Font("Arial", 8, FontStyle.Regular)
            Dim P_RedLine As New Pen(Color.Red, 1)
            Dim P_BlueLine As New Pen(Color.Blue, 1)
            Dim P_GrayLine As New Pen(Color.Gray, 1)
            If (Me.pointsQuotes.Count > 1) Then

                For index = Me.currentPointQuotes To Me.lastPointQuotes - 1
                    If (index = Me.currentPointQuotes) Then
                        If (Me.pointsQuotes(index).askPrice > Me.pointsQuotes(index).bidPrice) Then
                            highBorderQuotes = Me.pointsQuotes(index).askPrice
                            lowBorderQuotes = Me.pointsQuotes(index).bidPrice
                        Else
                            highBorderQuotes = Me.pointsQuotes(index).bidPrice
                            lowBorderQuotes = Me.pointsQuotes(index).askPrice
                        End If
                    Else
                        If (Me.pointsQuotes(index).askPrice > highBorderQuotes) Then
                            highBorderQuotes = Me.pointsQuotes(index).askPrice
                        End If
                        If (Me.pointsQuotes(index).bidPrice > highBorderQuotes) Then
                            highBorderQuotes = Me.pointsQuotes(index).bidPrice
                        End If

                        If (Me.pointsQuotes(index).askPrice < lowBorderQuotes) Then
                            lowBorderQuotes = Me.pointsQuotes(index).askPrice
                        End If
                        If (Me.pointsQuotes(index).bidPrice < lowBorderQuotes) Then
                            lowBorderQuotes = Me.pointsQuotes(index).bidPrice
                        End If
                    End If
                Next

                highBorderQuotes += highBorderQuotes * 0.0001
                lowBorderQuotes -= lowBorderQuotes * 0.0001
                yRangeQuotes = highBorderQuotes - lowBorderQuotes

                For index = Me.currentPointQuotes To Me.lastPointQuotes - 1
                    If (Me.pointsQuotes.Count > 1 And Me.yRangeQuotes = 0) Then
                        Exit Sub
                    End If
                    Dim procentsAsk1 As Double = ((Me.pointsQuotes(index).askPrice - lowBorderQuotes) / yRangeQuotes)
                    Dim procentsAsk2 As Double = ((Me.pointsQuotes(index + 1).askPrice - lowBorderQuotes) / yRangeQuotes)
                    Dim procentsBid1 As Double = ((Me.pointsQuotes(index).bidPrice - lowBorderQuotes) / yRangeQuotes)
                    Dim procentsBid2 As Double = ((Me.pointsQuotes(index + 1).bidPrice - lowBorderQuotes) / yRangeQuotes)
                    Dim p1Ask As Drawing.PointF
                    Dim p2Ask As Drawing.PointF
                    Dim p1Bid As Drawing.PointF
                    Dim p2Bid As Drawing.PointF
                    p1Ask.X = (index - Me.currentPointQuotes) * Me.intervalQuotes
                    p1Ask.Y = QuotesPctBox.Height - QuotesPctBox.Height * procentsAsk1
                    p2Ask.X = (index + 1 - Me.currentPointQuotes) * Me.intervalQuotes
                    p2Ask.Y = QuotesPctBox.Height - QuotesPctBox.Height * procentsAsk2
                    p1Bid.X = (index - Me.currentPointQuotes) * Me.intervalQuotes
                    p1Bid.Y = QuotesPctBox.Height - QuotesPctBox.Height * procentsBid1
                    p2Bid.X = (index + 1 - Me.currentPointQuotes) * Me.intervalQuotes
                    p2Bid.Y = QuotesPctBox.Height - QuotesPctBox.Height * procentsBid2

                    G_btm.DrawLine(P_RedLine, p1Ask, p2Ask)
                    G_btm.DrawLine(P_BlueLine, p1Bid, p2Bid)

                    If (Me.pointsOnScreenQuotes <= 20) Then
                        G_btm.DrawLine(P_GrayLine, p1Ask.X, 0, p1Ask.X, QuotesPctBox.Height)
                        G_btmTimes.DrawString(Me.pointsQuotes(index).time.ToLongTimeString, font, brush, p1Ask.X, TimesQuotesPctBox.Height / 2)
                    Else
                        If (Me.pointsOnScreenQuotes > 20 And Me.pointsOnScreenQuotes <= 45) Then
                            If (index Mod 2 = 0) Then
                                G_btm.DrawLine(P_GrayLine, p1Ask.X, 0, p1Ask.X, QuotesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsQuotes(index).time.ToLongTimeString, font, brush, p1Ask.X, TimesQuotesPctBox.Height / 2)
                            End If
                        ElseIf (Me.pointsOnScreenQuotes > 45 And Me.pointsOnScreenQuotes <= 100) Then
                            If (index Mod 5 = 0) Then
                                G_btm.DrawLine(P_GrayLine, p1Ask.X, 0, p1Ask.X, QuotesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsQuotes(index).time.ToLongTimeString, font, brush, p1Ask.X, TimesQuotesPctBox.Height / 2)
                            End If
                        ElseIf (Me.pointsOnScreenQuotes > 100 And Me.pointsOnScreenQuotes <= 200) Then
                            If (index Mod 20 = 0) Then
                                G_btm.DrawLine(P_GrayLine, p1Ask.X, 0, p1Ask.X, QuotesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsQuotes(index).time.ToLongTimeString, font, brush, p1Ask.X, TimesQuotesPctBox.Height / 2)
                            End If
                        ElseIf (Me.pointsOnScreenQuotes > 200 And Me.pointsOnScreenQuotes <= 300) Then
                            If (index Mod 40 = 0) Then
                                G_btm.DrawLine(P_GrayLine, p1Ask.X, 0, p1Ask.X, QuotesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsQuotes(index).time.ToLongTimeString, font, brush, p1Ask.X, TimesQuotesPctBox.Height / 2)
                            End If
                        ElseIf (Me.pointsOnScreenQuotes > 300 And Me.pointsOnScreenQuotes <= 400) Then
                            If (index Mod 75 = 0) Then
                                G_btm.DrawLine(P_GrayLine, p1Ask.X, 0, p1Ask.X, QuotesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsQuotes(index).time.ToLongTimeString, font, brush, p1Ask.X, TimesQuotesPctBox.Height / 2)
                            End If
                        End If

                    End If

                    If (index = Me.lastPointQuotes - 1 Or index = 0) Then
                        Dim p1 As Drawing.PointF = New PointF()
                        Dim p2 As Drawing.PointF = New PointF()

                        If yRangeQuotes < 1 Then
                            Dim stepOfGrid As Double = 0.1
                            Dim currentValue As Double = Math.Floor(lowBorderQuotes)
                            While highBorderQuotes > currentValue
                                Dim procents As Double = ((currentValue - lowBorderQuotes) / yRangeQuotes)
                                p1 = New PointF(0.0, QuotesPctBox.Height - QuotesPctBox.Height * procents)
                                p2 = New PointF(QuotesPctBox.Width, QuotesPctBox.Height - QuotesPctBox.Height * procents)
                                G_btm.DrawLine(P_GrayLine, p1, p2)
                                G_btmPrices.DrawString(currentValue, font, brush, PricesQuotesPctBox.Width / 2 - 15, PricesQuotesPctBox.Height - PricesQuotesPctBox.Height * procents)
                                currentValue += stepOfGrid
                            End While
                        Else
                            Dim stepOfGrid As Integer = MakeDigitBeauty(yRangeQuotes / 10)
                            Dim currentValue As Integer = MakeDigitBeauty(lowBorderQuotes)
                            If yRangeQuotes <= 10 And yRangeQuotes >= 1 Then
                                stepOfGrid = 1
                                currentValue = Math.Floor(lowBorderQuotes)
                            ElseIf yRangeQuotes > 10 And yRangeQuotes <= 20 Then
                                stepOfGrid = 2
                                currentValue = Math.Floor(lowBorderQuotes)
                            End If
                            For i = 1 To 10
                                Dim procents As Double = ((currentValue - lowBorderQuotes) / yRangeQuotes)
                                p1 = New PointF(0.0, QuotesPctBox.Height - QuotesPctBox.Height * procents)
                                p2 = New PointF(QuotesPctBox.Width, QuotesPctBox.Height - QuotesPctBox.Height * procents)
                                G_btm.DrawLine(P_GrayLine, p1, p2)
                                G_btmPrices.DrawString(currentValue, font, brush, PricesQuotesPctBox.Width / 2 - 15, PricesQuotesPctBox.Height - PricesQuotesPctBox.Height * procents)
                                currentValue += stepOfGrid
                            Next
                        End If
                    End If
                Next

                Dim P_DashedLine As New Pen(Color.Black)
                P_DashedLine.DashStyle = Drawing2D.DashStyle.Dash

                If (Me.isCursorOnQuotesChart) Then
                    G_btm.DrawLine(P_DashedLine, pointMouseMoveQuotes.X, 0, pointMouseMoveQuotes.X, QuotesPctBox.Height)
                    G_btm.DrawLine(P_DashedLine, 0, pointMouseMoveQuotes.Y, QuotesPctBox.Width, pointMouseMoveQuotes.Y)
                    G_btmPrices.DrawLine(P_DashedLine, 0, pointMouseMoveQuotes.Y, PricesQuotesPctBox.Width, pointMouseMoveQuotes.Y)
                    Dim rectangleForPrice As New RectangleF
                    Dim heightOfRectangle As Double = 20
                    rectangleForPrice.X = 0
                    rectangleForPrice.Width = PricesQuotesPctBox.Width
                    rectangleForPrice.Height = heightOfRectangle
                    If pointMouseMoveQuotes.Y < QuotesPctBox.Height / 2 Then
                        rectangleForPrice.Y = pointMouseMoveQuotes.Y
                        G_btmPrices.FillRectangle(Brushes.DarkRed, rectangleForPrice)
                        G_btmPrices.DrawString(currentQuotesPriceMM, font, Brushes.White, New PointF(22, pointMouseMoveQuotes.Y + 4))
                    Else
                        rectangleForPrice.Y = pointMouseMoveQuotes.Y - heightOfRectangle
                        G_btmPrices.FillRectangle(Brushes.DarkRed, rectangleForPrice)
                        G_btmPrices.DrawString(currentQuotesPriceMM, font, Brushes.White, New PointF(22, pointMouseMoveQuotes.Y - 17))
                    End If
                End If
                QuotesPctBox.Refresh()
                TimesQuotesPctBox.Refresh()
                PricesQuotesPctBox.Refresh()
                QuotesPctBox.Image = btm
                TimesQuotesPctBox.Image = btmTimes
                PricesQuotesPctBox.Image = btmPrices
            End If

            If (Me.isLineReadyQuotes) Then
                Dim P_BlackLine As New Pen(Color.Black, 1)
                G_btm.DrawLine(P_BlackLine, Me.point1Quotes, Me.point2Quotes)
            End If
        Catch ex As Exception
            Me.currentPointQuotes = pointsQuotes.Count - pointsOnScreenQuotes
            If Me.currentPointQuotes < 0 Then
                Me.currentPointQuotes = 0
            End If
            If (Me.needRePaintingQuotes = False) Then
                Me.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
            Else
                Me.needRePaintingQuotes = False
                Me.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
                Me.needRePaintingQuotes = True
            End If
        End Try
    End Sub

    Public Sub paintingTrades(TradesPctBox As PictureBox, TimesTradesPctBox As PictureBox, PricesTradesPctBox As PictureBox, VolumesTradesPctBox As PictureBox, VolumesVolumesTradesPctBox As PictureBox)
        Try
            If (needRePaintingTrades) Then
                If (Me.pointsTrades.Count > Me.pointsOnScreenTrades) Then
                    currentPointTrades += 1
                End If
            End If

            If pointsTrades.Count > pointsOnScreenTrades Then
                Dim numberToCompare As Integer = pointsTrades.Count - pointsOnScreenTrades - 1
                If currentPointTrades > numberToCompare Then
                    currentPointTrades = numberToCompare
                End If
                If currentPointTrades < 0 Then
                    currentPointTrades = 0
                End If
                lastPointTrades = currentPointTrades + pointsOnScreenTrades
            Else
                currentPointTrades = 0
                lastPointTrades = pointsTrades.Count - 1
            End If

            intervalTrades = TradesPctBox.Width / pointsOnScreenTrades

            Dim G_Trades As Graphics = TradesPctBox.CreateGraphics
            G_Trades.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim btmTrades As New Bitmap(TradesPctBox.Width, TradesPctBox.Height)
            Dim G_btmTrades = Graphics.FromImage(btmTrades)
            G_btmTrades.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim G_Times = TimesTradesPctBox.CreateGraphics
            G_Times.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim btmTimes As New Bitmap(TimesTradesPctBox.Width, TimesTradesPctBox.Height)
            Dim G_btmTimes = Graphics.FromImage(btmTimes)
            G_btmTimes.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            G_btmTimes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim G_Prices As Graphics = PricesTradesPctBox.CreateGraphics
            G_Prices.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim btmPrices As New Bitmap(PricesTradesPctBox.Width, PricesTradesPctBox.Height)
            Dim G_btmPrices = Graphics.FromImage(btmPrices)
            G_btmPrices.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            G_btmPrices.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim G_Volumes As Graphics = VolumesTradesPctBox.CreateGraphics
            G_Volumes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim btmVolumes As New Bitmap(VolumesTradesPctBox.Width, VolumesTradesPctBox.Height)
            Dim G_btmVolumes = Graphics.FromImage(btmVolumes)
            G_btmVolumes.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            G_btmVolumes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim G_VolumesVolumes = VolumesVolumesTradesPctBox.CreateGraphics
            Dim btmVolumesVolumes As New Bitmap(VolumesTradesPctBox.Width, VolumesTradesPctBox.Height)
            Dim G_btmVolumesVolumes = Graphics.FromImage(btmVolumesVolumes)
            G_btmVolumesVolumes.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            G_VolumesVolumes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim brush As New SolidBrush(Color.Black)
            Dim font As New Font("Arial", 8, FontStyle.Regular)
            Dim P_RedLine As New Pen(Color.Red, 1)
            Dim P_BlueLine As New Pen(Color.Blue, 1)
            Dim P_GrayLine As New Pen(Color.Gray, 0.3)
            Dim GreenBrush As New SolidBrush(Color.Green)

            If (Me.pointsTrades.Count > 1) Then
                TradesPctBox.Refresh()
                VolumesTradesPctBox.Refresh()
                VolumesVolumesTradesPctBox.Refresh()
                PricesTradesPctBox.Refresh()
                TimesTradesPctBox.Refresh()

                For index = Me.currentPointTrades To Me.lastPointTrades - 1
                    If (index = Me.currentPointTrades) Then
                        highBorderTrades = Me.pointsTrades(index).tradePrice
                        lowBorderTrades = Me.pointsTrades(index).tradePrice
                        highBorderVolumesTrades = Me.pointsTrades(index).tradeVolume
                    Else
                        If (Me.pointsTrades(index).tradePrice > highBorderTrades) Then
                            highBorderTrades = Me.pointsTrades(index).tradePrice
                        End If
                        If (Me.pointsTrades(index).tradePrice < lowBorderTrades) Then
                            lowBorderTrades = Me.pointsTrades(index).tradePrice
                        End If
                        If (Me.pointsTrades(index).tradeVolume > highBorderVolumesTrades) Then
                            highBorderVolumesTrades = Me.pointsTrades(index).tradeVolume
                        End If
                    End If
                Next

                highBorderTrades += highBorderTrades * 0.0001
                lowBorderTrades -= lowBorderTrades * 0.0001
                yRangeTrades = highBorderTrades - lowBorderTrades

                For index = Me.currentPointTrades To Me.lastPointTrades - 1
                    If (Me.pointsTrades.Count > 1 And Me.yRangeTrades = 0) Then
                        Exit Sub
                    End If
                    Dim procents1 As Double = ((Me.pointsTrades(index).tradePrice - lowBorderTrades) / yRangeTrades)
                    Dim procents2 As Double = ((Me.pointsTrades(index + 1).tradePrice - lowBorderTrades) / yRangeTrades)
                    Dim p1Trades As Drawing.PointF
                    Dim p2Trades As Drawing.PointF
                    p1Trades.X = (index - Me.currentPointTrades) * Me.intervalTrades
                    p1Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents1
                    p2Trades.X = (index + 1 - Me.currentPointTrades) * Me.intervalTrades
                    p2Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents2

                    yRangeVolumesTrades = highBorderVolumesTrades
                    Dim procentsRectangle As Double = Me.pointsTrades(index).tradeVolume / yRangeVolumesTrades
                    Dim rectangle As RectangleF
                    rectangle.X = (index - Me.currentPointTrades) * Me.intervalTrades
                    rectangle.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsRectangle
                    rectangle.Height = VolumesTradesPctBox.Height * procentsRectangle
                    rectangle.Width = Me.intervalTrades - 1
                    G_btmVolumes.FillRectangle(GreenBrush, rectangle)

                    If (Me.pointsTrades(index).tradePrice < Me.pointsTrades(index + 1).tradePrice) Then
                        G_btmTrades.DrawLine(P_BlueLine, p1Trades, p2Trades)
                        Form1.TradePriceLabel.ForeColor = Color.Blue
                    Else
                        G_btmTrades.DrawLine(P_RedLine, p1Trades, p2Trades)
                        Form1.TradePriceLabel.ForeColor = Color.Red
                    End If

                    If (Me.pointsTrades(index).tradePrice < Me.pointsTrades(index + 1).tradePrice) Then
                        G_btmTrades.DrawLine(P_BlueLine, p1Trades, p2Trades)
                        Form1.TradePriceLabel.ForeColor = Color.Blue
                    Else
                        G_btmTrades.DrawLine(P_RedLine, p1Trades, p2Trades)
                        Form1.TradePriceLabel.ForeColor = Color.Red
                    End If

                    If (Me.pointsOnScreenTrades <= 20) Then
                        G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                        G_btmTimes.DrawString(Me.pointsTrades(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                        G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                    Else
                        If (Me.pointsOnScreenTrades > 20 And Me.pointsOnScreenTrades <= 45) Then
                            If (index Mod 2 = 0) Then
                                G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsTrades(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                                G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                            End If
                        ElseIf (Me.pointsOnScreenTrades > 45 And Me.pointsOnScreenTrades <= 100) Then
                            If (index Mod 5 = 0) Then
                                G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsTrades(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                                G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                            End If
                        ElseIf (Me.pointsOnScreenTrades > 100 And Me.pointsOnScreenTrades <= 200) Then
                            If (index Mod 20 = 0) Then
                                G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsTrades(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                                G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                            End If
                        ElseIf (Me.pointsOnScreenTrades > 200 And Me.pointsOnScreenTrades <= 300) Then
                            If (index Mod 40 = 0) Then
                                G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsTrades(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                                G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                            End If
                        ElseIf (Me.pointsOnScreenTrades > 300 And Me.pointsOnScreenTrades <= 400) Then
                            If (index Mod 75 = 0) Then
                                G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                                G_btmTimes.DrawString(Me.pointsTrades(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                                G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                            End If
                        End If
                    End If

                    If (index = Me.lastPointTrades - 1) Then
                        Dim p1 As Drawing.PointF = New PointF(0.0, VolumesTradesPctBox.Height / 2)
                        Dim p2 As Drawing.PointF = New PointF(VolumesTradesPctBox.Width * 1.0, VolumesTradesPctBox.Height / 2)
                        G_btmVolumes.DrawLine(P_GrayLine, p1, p2)

                        Dim stepOfGrid As Integer = MakeDigitBeauty(yRangeTrades / 10)
                        Dim currentValue As Integer = MakeDigitBeauty(lowBorderTrades)
                        If yRangeTrades <= 10 Then
                            stepOfGrid = 1
                            currentValue = Math.Floor(lowBorderTrades)
                        ElseIf yRangeTradesNsec < 1 Then
                            G_btmPrices.DrawString(Format(lowBorderTrades + (highBorderTrades - lowBorderTradesNsec) / 2, "0.00"), font, brush, PricesTradesPctBox.Width / 2 - 15, VolumesVolumesTradesPctBox.Height / 2)
                            G_btmTrades.DrawLine(P_GrayLine, New PointF(0.0, TradesPctBox.Height * 0.5), New PointF(TradesPctBox.Width, TradesPctBox.Height * 0.5))
                        ElseIf yRangeTrades > 10 And yRangeTrades <= 20 Then
                            stepOfGrid = 2
                            currentValue = Math.Floor(lowBorderTrades)
                        End If
                        For i = 1 To 10
                            Dim procents As Double = ((currentValue - lowBorderTrades) / yRangeTrades)
                            p1 = New PointF(0.0, TradesPctBox.Height - TradesPctBox.Height * procents)
                            p2 = New PointF(TradesPctBox.Width, TradesPctBox.Height - TradesPctBox.Height * procents)
                            G_btmTrades.DrawLine(P_GrayLine, p1, p2)
                            G_btmPrices.DrawString(Format(currentValue, "0.00"), font, brush, PricesTradesPctBox.Width / 2 - 15, PricesTradesPctBox.Height - PricesTradesPctBox.Height * procents)
                            currentValue += stepOfGrid
                        Next
                        G_btmVolumesVolumes.DrawString(Format(highBorderVolumesTrades, "0.00"), font, brush, VolumesVolumesTradesPctBox.Width / 2 - 15, 7)
                        G_btmVolumesVolumes.DrawString(Format(highBorderVolumesTrades / 2, "0.00"), font, brush, VolumesVolumesTradesPctBox.Width / 2 - 15, VolumesVolumesTradesPctBox.Height / 2)
                    End If
                Next
                TradesPctBox.Image = btmTrades
                VolumesTradesPctBox.Image = btmVolumes
                TimesTradesPctBox.Image = btmTimes
                VolumesVolumesTradesPctBox.Image = btmVolumesVolumes
                PricesTradesPctBox.Image = btmPrices
            End If

            If (Me.isLineReadyTrades) Then
                Dim P_BlackLine As New Pen(Color.Black, 1)
                G_btmTrades.DrawLine(P_BlackLine, Me.point1Trades, Me.point2Trades)
            End If

            Dim P_DashedLine As New Pen(Color.Black)
            P_DashedLine.DashStyle = Drawing2D.DashStyle.Dash
            If (Me.isCursorOnTradesChart) Then
                G_btmTrades.DrawLine(P_DashedLine, pointMouseMoveTrades.X, 0, pointMouseMoveTrades.X, TradesPctBox.Height)
                G_btmTrades.DrawLine(P_DashedLine, 0, pointMouseMoveTrades.Y, TradesPctBox.Width, pointMouseMoveTrades.Y)
                G_btmVolumes.DrawLine(P_DashedLine, pointMouseMoveTrades.X, 0, pointMouseMoveTrades.X, VolumesTradesPctBox.Height)
                G_btmPrices.DrawLine(P_DashedLine, 0, pointMouseMoveTrades.Y, PricesTradesPctBox.Width, pointMouseMoveTrades.Y)
                Dim rectangleForPrice As New RectangleF
                Dim heightOfRectangle As Double = 20
                rectangleForPrice.X = 0
                rectangleForPrice.Width = PricesTradesPctBox.Width
                rectangleForPrice.Height = heightOfRectangle
                If pointMouseMoveTrades.Y < TradesPctBox.Height / 2 Then
                    rectangleForPrice.Y = pointMouseMoveTrades.Y
                    G_btmPrices.FillRectangle(Brushes.DarkRed, rectangleForPrice)
                    G_btmPrices.DrawString(currentTradePriceMM, font, Brushes.White, New PointF(22, pointMouseMoveTrades.Y + 4))
                Else
                    rectangleForPrice.Y = pointMouseMoveTrades.Y - heightOfRectangle
                    G_btmPrices.FillRectangle(Brushes.DarkRed, rectangleForPrice)
                    G_btmPrices.DrawString(currentTradePriceMM, font, Brushes.White, New PointF(22, pointMouseMoveTrades.Y - 17))
                End If
            End If

            If (Me.isCursorOnVolumesChart) Then
                G_btmVolumes.DrawLine(P_DashedLine, pointMouseMoveVolumes.X, 0, pointMouseMoveVolumes.X, VolumesTradesPctBox.Height)
                G_btmVolumes.DrawLine(P_DashedLine, 0, pointMouseMoveVolumes.Y, VolumesTradesPctBox.Width, pointMouseMoveVolumes.Y)
                G_btmTrades.DrawLine(P_DashedLine, pointMouseMoveVolumes.X, 0, pointMouseMoveVolumes.X, TradesPctBox.Height)
                G_btmVolumesVolumes.DrawLine(P_DashedLine, 0, pointMouseMoveVolumes.Y, VolumesVolumesTradesPctBox.Width, pointMouseMoveVolumes.Y)
                Dim rectangleForVolume As New RectangleF
                Dim heightOfRectangle As Double = 20
                rectangleForVolume.X = 0
                rectangleForVolume.Width = VolumesTradesPctBox.Width
                rectangleForVolume.Height = heightOfRectangle
                If pointMouseMoveVolumes.Y < VolumesTradesPctBox.Height / 2 Then
                    rectangleForVolume.Y = pointMouseMoveVolumes.Y
                    G_btmVolumesVolumes.FillRectangle(Brushes.DarkGreen, rectangleForVolume)
                    G_btmVolumesVolumes.DrawString(currentVolumeMM, font, Brushes.White, New PointF(22, pointMouseMoveVolumes.Y + 4))
                Else
                    rectangleForVolume.Y = pointMouseMoveVolumes.Y - heightOfRectangle
                    G_btmVolumesVolumes.FillRectangle(Brushes.DarkGreen, rectangleForVolume)
                    G_btmVolumesVolumes.DrawString(currentVolumeMM, font, Brushes.White, New PointF(22, pointMouseMoveVolumes.Y - 17))
                End If
            End If
            Refreshing(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox, pt)
        Catch ex As Exception
            Me.currentPointTrades = pointsTrades.Count - pointsOnScreenTrades
            If (Me.currentPointTrades < 0) Then
                Me.currentPointTrades = 0
            End If
            If (Me.needRePaintingTrades = False) Then
                Me.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
            Else
                Me.needRePaintingTrades = False
                Me.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                Me.needRePaintingTrades = True
            End If
        End Try

    End Sub

    Public Sub paintingTradesNsec(TradesPctBox As PictureBox, TimesTradesPctBox As PictureBox, PricesTradesPctBox As PictureBox, VolumesTradesPctBox As PictureBox, VolumesVolumesTradesPctBox As PictureBox)
        stopWatch.Start()
        Dim pointsCnt = pointsTradesNsec.Count
        If (Not Form1.isOnline) Then
            needRePaintingTradesNsec = False
        End If

        If (needRePaintingTradesNsec) Then
            If (pointsCnt > Me.pointsOnScreenTradesNsec) Then
                currentPointTradesNsec += 1
            End If
        End If

        ' --- удержание индексов в пределах размера массива
        If pointsCnt > pointsOnScreenTradesNsec Then
            Dim numberToCompare As Integer = pointsCnt - pointsOnScreenTradesNsec
            If currentPointTradesNsec > numberToCompare Then
                currentPointTradesNsec = numberToCompare
            End If
            If currentPointTradesNsec < 0 Then
                currentPointTradesNsec = 0
            End If
            lastPointTradesNsec = currentPointTradesNsec + pointsOnScreenTradesNsec - 1
        Else
            currentPointTradesNsec = 0
            lastPointTradesNsec = pointsCnt - 1
        End If
        ' --------------------------------------------------

        intervalTradesNsec = TradesPctBox.Width / pointsOnScreenTradesNsec

        Dim G_btmTrades = Graphics.FromImage(pt.btmTrades) ' !!!
        G_btmTrades.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim G_btmTimes = Graphics.FromImage(pt.btmTimes) '!!!
        G_btmTimes.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        G_btmTimes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim G_btmPrices = Graphics.FromImage(pt.btmPrices) '!!!
        G_btmPrices.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        G_btmPrices.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim G_btmVolumes = Graphics.FromImage(pt.btmVolumes)
        G_btmVolumes.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        G_btmVolumes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim G_VolumesVolumes = VolumesVolumesTradesPctBox.CreateGraphics
        Dim G_btmVolumesVolumes = Graphics.FromImage(pt.btmVolumesVolumes)
        G_btmVolumesVolumes.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        G_btmVolumesVolumes.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        If Not pointsCnt > 0 Then
            Exit Sub
        End If

        Dim typeOfGraphic As ComboBox ' требуется фикс
        If (isCloned) Then
            typeOfGraphic = CType(Me.usedForm, Form1Clone).TypeOfGraphic
        Else
            typeOfGraphic = CType(Me.usedForm, Form1).TypeOfGraphic
        End If

        For index = Me.currentPointTradesNsec To Me.lastPointTradesNsec
            If (index = Me.currentPointTradesNsec) Then
                highBorderTradesNsec = pointsTradesNsec(index).highPrice
                lowBorderTradesNsec = pointsTradesNsec(index).lowPrice
                highBorderVolumesTradesAvgNsec = pointsTradesNsec(index).avgBuyPlusSell
                highBorderVolumesTradesNsec = pointsTradesNsec(index).volumeSell + pointsTradesNsec(index).volumeBuy
            Else
                If (pointsTradesNsec(index).highPrice > highBorderTradesNsec) Then
                    highBorderTradesNsec = pointsTradesNsec(index).highPrice
                End If
                If (pointsTradesNsec(index).lowPrice < lowBorderTradesNsec) Then
                    lowBorderTradesNsec = pointsTradesNsec(index).lowPrice
                End If
                If (pointsTradesNsec(index).avgBuyPlusSell > highBorderVolumesTradesAvgNsec) Then
                    highBorderVolumesTradesAvgNsec = pointsTradesNsec(index).avgBuyPlusSell
                End If
                If pointsTradesNsec(index).volumeSell + pointsTradesNsec(index).volumeBuy > highBorderVolumesTradesNsec Then
                    highBorderVolumesTradesNsec = pointsTradesNsec(index).volumeSell + pointsTradesNsec(index).volumeBuy
                End If
            End If
        Next


        highBorderTradesNsec += highBorderTradesNsec * 0.0001
        lowBorderTradesNsec -= lowBorderTradesNsec * 0.0001
        yRangeTradesNsec = highBorderTradesNsec - lowBorderTradesNsec

        If (typeOfGraphic.SelectedItem = "Линии") Then 'тип графика - линейный
            For index = currentPointTradesNsec To lastPointTradesNsec - 1
                If (pointsCnt > 1 And yRangeTradesNsec = 0) Then
                    Exit Sub
                End If

                Dim procents1 As Double = ((pointsTradesNsec(index).closePrice - lowBorderTradesNsec) / yRangeTradesNsec)
                Dim procents2 As Double = ((pointsTradesNsec(index + 1).closePrice - lowBorderTradesNsec) / yRangeTradesNsec)
                Dim p1Trades As Drawing.PointF
                Dim p2Trades As Drawing.PointF

                If (Not index = Me.lastPointTradesNsec) Then
                    p1Trades.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec
                    p1Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents1
                    p2Trades.X = (index + 1 - Me.currentPointTradesNsec) * Me.intervalTradesNsec
                    p2Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents2

                    If (pointsTradesNsec(index).closePrice < pointsTradesNsec(index + 1).closePrice) Then
                        G_btmTrades.DrawLine(pt.P_BlueLine, p1Trades, p2Trades)
                        Form1.TradePriceLabel.ForeColor = Color.Blue
                    Else
                        G_btmTrades.DrawLine(pt.P_RedLine, p1Trades, p2Trades)
                        Form1.TradePriceLabel.ForeColor = Color.Red
                    End If
                End If

                yRangeVolumesTradesNsec = highBorderVolumesTradesNsec

                DrawAvg(index, G_btmVolumes, VolumesTradesPctBox, pt.GreenBrush, pt.P_RedLine, pt.P_BlueLine)
                DrawVerticalLines(index, G_btmVolumes, G_btmTrades, G_btmTimes, pt.font, pt.brush, pt.P_GrayLine, p1Trades, TradesPctBox, TimesTradesPctBox, VolumesTradesPctBox, pointsTradesNsec, lastPointTradesNsec, pointsOnScreenTradesNsec)
                DrawHorizontalLines(index, G_btmVolumes, G_btmTrades, G_btmPrices, G_btmVolumesVolumes, VolumesTradesPctBox, VolumesVolumesTradesPctBox, PricesTradesPctBox, TradesPctBox, pt.font, pt.brush, pt.P_GrayLine)
            Next
        Else 'тип графика - японские свечи / бары
            For index = Me.currentPointTradesNsec To Me.lastPointTradesNsec
                If (pointsCnt > 1 And Me.yRangeTradesNsec = 0) Then
                    Exit Sub
                End If
                Dim procents1 As Double = ((pointsTradesNsec(index).highPrice - lowBorderTradesNsec) / yRangeTradesNsec)
                Dim procents2 As Double = ((pointsTradesNsec(index).lowPrice - lowBorderTradesNsec) / yRangeTradesNsec)
                Dim procents3 As Double = ((pointsTradesNsec(index).openPrice - lowBorderTradesNsec) / yRangeTradesNsec)
                Dim procents4 As Double = ((pointsTradesNsec(index).closePrice - lowBorderTradesNsec) / yRangeTradesNsec)
                Dim p1Trades As Drawing.PointF
                Dim p2Trades As Drawing.PointF
                Dim p3Trades As Drawing.PointF
                Dim p4Trades As Drawing.PointF

                p1Trades.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                p1Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents1

                p2Trades.X = p1Trades.X
                p2Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents2

                p3Trades.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec
                p3Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents3

                p4Trades.X = p3Trades.X
                p4Trades.Y = TradesPctBox.Height - TradesPctBox.Height * procents4

                yRangeVolumesTradesNsec = highBorderVolumesTradesNsec
                DrawAvg(index, G_btmVolumes, VolumesTradesPctBox, pt.GreenBrush, pt.P_RedLine, pt.P_BlueLine)

                If (typeOfGraphic.SelectedItem = "Японские свечи") Then
                    If (p3Trades.Y > p4Trades.Y) Then
                        pt.rectangleForCandle.X = p4Trades.X
                        pt.rectangleForCandle.Y = p4Trades.Y
                        pt.rectangleForCandle.Width = Me.intervalTradesNsec - 1
                        pt.rectangleForCandle.Height = p3Trades.Y - p4Trades.Y
                        If (p3Trades.Y - p4Trades.Y < 2) Then
                            pt.rectangleForCandle.Height = 2
                        End If
                    Else
                        pt.rectangleForCandle.X = p3Trades.X
                        pt.rectangleForCandle.Y = p3Trades.Y
                        pt.rectangleForCandle.Width = Me.intervalTradesNsec - 1
                        pt.rectangleForCandle.Height = p4Trades.Y - p3Trades.Y
                        If (p4Trades.Y - p3Trades.Y < 2) Then
                            pt.rectangleForCandle.Height = 2
                        End If
                    End If

                    If (index = 0) Then
                        G_btmTrades.FillRectangle(Brushes.Red, pt.rectangleForCandle)
                        G_btmTrades.DrawLine(pt.P_RedLine2, p1Trades, p2Trades)
                    Else
                        If (pointsTradesNsec(index).closePrice < pointsTradesNsec(index).openPrice) Then
                            G_btmTrades.FillRectangle(Brushes.Red, pt.rectangleForCandle)
                            G_btmTrades.DrawLine(pt.P_RedLine, p1Trades, p2Trades)
                        Else
                            G_btmTrades.FillRectangle(Brushes.Blue, pt.rectangleForCandle)
                            G_btmTrades.DrawLine(pt.P_BlueLine, p1Trades, p2Trades)
                        End If
                    End If
                Else
                    If (index = 0) Then
                        G_btmTrades.DrawLine(pt.P_RedLine2, New PointF(p3Trades.X, p3Trades.Y), New PointF(p3Trades.X + intervalTradesNsec / 2, p3Trades.Y))
                        G_btmTrades.DrawLine(pt.P_RedLine2, New PointF(p4Trades.X + intervalTradesNsec / 2, p4Trades.Y), New PointF(p4Trades.X + intervalTradesNsec - 1, p4Trades.Y))
                        G_btmTrades.DrawLine(pt.P_RedLine2, p1Trades, p2Trades)
                    Else
                        If (pointsTradesNsec(index).closePrice < pointsTradesNsec(index).openPrice) Then
                            G_btmTrades.DrawLine(pt.P_RedLine2, New PointF(p3Trades.X, p3Trades.Y), New PointF(p3Trades.X + intervalTradesNsec / 2, p3Trades.Y))
                            G_btmTrades.DrawLine(pt.P_RedLine2, New PointF(p4Trades.X + intervalTradesNsec / 2, p4Trades.Y), New PointF(p4Trades.X + intervalTradesNsec - 1, p4Trades.Y))
                            G_btmTrades.DrawLine(pt.P_RedLine2, p1Trades, p2Trades)
                        Else
                            G_btmTrades.DrawLine(pt.P_BlueLine2, New PointF(p3Trades.X, p3Trades.Y), New PointF(p3Trades.X + intervalTradesNsec / 2, p3Trades.Y))
                            G_btmTrades.DrawLine(pt.P_BlueLine2, New PointF(p4Trades.X + intervalTradesNsec / 2, p4Trades.Y), New PointF(p4Trades.X + intervalTradesNsec - 1, p4Trades.Y))
                            G_btmTrades.DrawLine(pt.P_BlueLine2, p1Trades, p2Trades)
                        End If
                    End If
                End If

                p1Trades.X -= intervalTradesNsec / 2

                If (Not index = Me.lastPointTradesNsec) Then
                    If (Not pointsTradesNsec(index).time.Date = pointsTradesNsec(index + 1).time.Date) Then
                        G_btmTrades.DrawLine(pt.P_OrangeLine2, p1Trades.X + CType(intervalTradesNsec, Single), 0, p1Trades.X + CType(intervalTradesNsec, Single), TradesPctBox.Height)
                        G_btmVolumes.DrawLine(pt.P_OrangeLine2, p1Trades.X + CType(intervalTradesNsec, Single), 0, p1Trades.X + CType(intervalTradesNsec, Single), VolumesTradesPctBox.Height)
                    End If
                End If

                DrawVerticalLines(index, G_btmVolumes, G_btmTrades, G_btmTimes, pt.font, pt.brush, pt.P_GrayLine, p1Trades, TradesPctBox, TimesTradesPctBox, VolumesTradesPctBox, pointsTradesNsec, lastPointTradesNsec, pointsOnScreenTradesNsec)
                DrawHorizontalLines(index, G_btmVolumes, G_btmTrades, G_btmPrices, G_btmVolumesVolumes, VolumesTradesPctBox, VolumesVolumesTradesPctBox, PricesTradesPctBox, TradesPctBox, pt.font, pt.brush, pt.P_GrayLine)
            Next
        End If

        If (Me.isLineReadyTrades) Then
            G_btmTrades.DrawLine(pt.P_BlackLine, Me.point1Trades, Me.point2Trades)
        End If

        DrawLinesByMouseMove(G_btmVolumes, G_btmTrades, G_btmVolumesVolumes, G_btmPrices, pt.font, pt.brush, TradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
        TradesPctBox.Image = pt.btmTrades
        VolumesTradesPctBox.Image = pt.btmVolumes
        TimesTradesPctBox.Image = pt.btmTimes
        VolumesVolumesTradesPctBox.Image = pt.btmVolumesVolumes
        PricesTradesPctBox.Image = pt.btmPrices

        Refreshing(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox, pt)
        stopWatch.Stop()
        Console.WriteLine(stopWatch.Elapsed.Milliseconds)
        stopWatch.Reset()
    End Sub

    Private Function MakeDigitBeauty(digit As Integer)
        digit = Math.Floor(digit)
        If digit Mod 10 = 0 Then
            digit = digit
        Else
            digit += 10 - (digit Mod 10)
        End If
        Return digit
    End Function

    Private Sub Refreshing(TradesPctBox As PictureBox, TimesTradesPctBox As PictureBox, PricesTradesPctBox As PictureBox, VolumesTradesPctBox As PictureBox, VolumesVolumesTradesPctBox As PictureBox, pt As PaintingTools)
        TradesPctBox.Refresh()
        VolumesTradesPctBox.Refresh()
        VolumesVolumesTradesPctBox.Refresh()
        PricesTradesPctBox.Refresh()
        TimesTradesPctBox.Refresh()
        pt.btmTrades = New Bitmap(TradesPctBox.Width, TradesPctBox.Height)
        pt.btmTimes = New Bitmap(TimesTradesPctBox.Width, TimesTradesPctBox.Height)
        pt.btmPrices = New Bitmap(PricesTradesPctBox.Width, PricesTradesPctBox.Height)
        pt.btmVolumes = New Bitmap(VolumesTradesPctBox.Width, VolumesTradesPctBox.Height)
        pt.btmVolumesVolumes = New Bitmap(VolumesVolumesTradesPctBox.Width, VolumesVolumesTradesPctBox.Height)
    End Sub

    Private Sub DrawHorizontalLines(index As Integer, G_btmVolumes As Graphics, G_btmTrades As Graphics, G_btmPrices As Graphics, G_btmVolumesVolumes As Graphics,
                                    VolumesTradesPctBox As PictureBox, VolumesVolumesTradesPctBox As PictureBox, PricesTradesPctBox As PictureBox, TradesPctBox As PictureBox,
                                    font As Font, brush As Brush, P_GrayLine As Pen)
        If (index = Me.lastPointTradesNsec - 1 Or index = 0) Then
            Dim p1 As Drawing.PointF = New PointF(0.0, VolumesTradesPctBox.Height / 2)
            Dim p2 As Drawing.PointF = New PointF(VolumesTradesPctBox.Width * 1.0, VolumesTradesPctBox.Height / 2)
            G_btmVolumes.DrawLine(P_GrayLine, p1, p2)

            If yRangeTradesNsec < 1 Then
                Dim stepOfGrid As Double = 0.1
                Dim currentValue As Double = Math.Floor(lowBorderTradesNsec)
                While highBorderTradesNsec > currentValue
                    Dim procents As Double = ((currentValue - lowBorderTradesNsec) / yRangeTradesNsec)
                    p1 = New PointF(0.0, TradesPctBox.Height - TradesPctBox.Height * procents)
                    p2 = New PointF(TradesPctBox.Width, TradesPctBox.Height - TradesPctBox.Height * procents)
                    G_btmTrades.DrawLine(P_GrayLine, p1, p2)
                    G_btmPrices.DrawString(currentValue, font, brush, PricesTradesPctBox.Width / 2 - 15, PricesTradesPctBox.Height - PricesTradesPctBox.Height * procents)
                    currentValue += stepOfGrid
                End While
            Else
                Dim stepOfGrid As Integer = MakeDigitBeauty(yRangeTradesNsec / 10)
                Dim currentValue As Integer = MakeDigitBeauty(lowBorderTradesNsec)
                If yRangeTradesNsec <= 10 And yRangeTradesNsec >= 1 Then
                    stepOfGrid = 1
                    currentValue = Math.Floor(lowBorderTradesNsec)
                ElseIf yRangeTradesNsec > 10 And yRangeTradesNsec <= 20 Then
                    stepOfGrid = 2
                    currentValue = Math.Floor(lowBorderTradesNsec)
                End If
                For i = 1 To 10
                    Dim procents As Double = ((currentValue - lowBorderTradesNsec) / yRangeTradesNsec)
                    p1 = New PointF(0.0, TradesPctBox.Height - TradesPctBox.Height * procents)
                    p2 = New PointF(TradesPctBox.Width, TradesPctBox.Height - TradesPctBox.Height * procents)
                    G_btmTrades.DrawLine(P_GrayLine, p1, p2)
                    G_btmPrices.DrawString(currentValue, font, brush, PricesTradesPctBox.Width / 2 - 15, PricesTradesPctBox.Height - PricesTradesPctBox.Height * procents)
                    currentValue += stepOfGrid
                Next
            End If
            G_btmVolumesVolumes.DrawString(Format(highBorderVolumesTradesNsec, "0.00"), font, brush, VolumesVolumesTradesPctBox.Width / 2 - 15, 7)
            G_btmVolumesVolumes.DrawString(Format(highBorderVolumesTradesNsec / 2, "0.00"), font, brush, VolumesVolumesTradesPctBox.Width / 2 - 15, VolumesVolumesTradesPctBox.Height / 2)
        End If
    End Sub

    Private Sub DrawVerticalLines(index As Integer, G_btmVolumes As Graphics, G_btmTrades As Graphics, G_btmTimes As Graphics, font As Font, brush As Brush, P_GrayLine As Pen,
                                  p1Trades As PointF, TradesPctBox As PictureBox, TimesTradesPctBox As PictureBox, VolumesTradesPctBox As PictureBox, listOfPoints As List(Of PointTradesNsec),
                                  lastPoint As Integer, pointsOnScreen As Integer)
        If (Not index = lastPoint) Then
            If (Not listOfPoints(index).time.Date = listOfPoints(index + 1).time.Date) Then
                G_btmTrades.DrawLine(pt.P_OrangeLine2, p1Trades.X + CType(intervalTradesNsec, Single), 0, p1Trades.X + CType(intervalTradesNsec, Single), TradesPctBox.Height)
                G_btmVolumes.DrawLine(pt.P_OrangeLine2, p1Trades.X + CType(intervalTradesNsec, Single), 0, p1Trades.X + CType(intervalTradesNsec, Single), VolumesTradesPctBox.Height)
            End If
        End If
        If (pointsOnScreen <= 20) Then
            G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
            G_btmTimes.DrawString(listOfPoints(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
            G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
        Else
            If (pointsOnScreen > 20 And pointsOnScreen <= 45) Then
                If (index Mod 2 = 0) Then
                    G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                    G_btmTimes.DrawString(listOfPoints(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                    G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                End If
            ElseIf (pointsOnScreen > 45 And pointsOnScreen <= 100) Then
                If (index Mod 5 = 0) Then
                    G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                    G_btmTimes.DrawString(listOfPoints(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                    G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                End If
            ElseIf (pointsOnScreen > 100 And pointsOnScreen <= 200) Then
                If (index Mod 20 = 0) Then
                    G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                    G_btmTimes.DrawString(listOfPoints(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                    G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                End If
            ElseIf (pointsOnScreen > 200 And pointsOnScreen <= 300) Then
                If (index Mod 40 = 0) Then
                    G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                    G_btmTimes.DrawString(listOfPoints(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                    G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                End If
            ElseIf (pointsOnScreen > 300 And pointsOnScreen <= 400) Then
                If (index Mod 75 = 0) Then
                    G_btmTrades.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, TradesPctBox.Height)
                    G_btmTimes.DrawString(listOfPoints(index).time.ToLongTimeString, font, brush, p1Trades.X, TimesTradesPctBox.Height / 2)
                    G_btmVolumes.DrawLine(P_GrayLine, p1Trades.X, 0, p1Trades.X, VolumesTradesPctBox.Height)
                End If
            End If
        End If
    End Sub

    Private Sub DrawLinesByMouseMove(G_btmVolumes As Graphics, G_btmTrades As Graphics, G_btmVolumesVolumes As Graphics, G_btmPrices As Graphics, font As Font, brush As Brush,
                                     TradesPctBox As PictureBox, PricesTradesPctBox As PictureBox, VolumesTradesPctBox As PictureBox, VolumesVolumesTradesPctBox As PictureBox)

        If (Me.isCursorOnTradesChart) Then
            G_btmTrades.DrawLine(pt.P_DashedLine, pointMouseMoveTrades.X, 0, pointMouseMoveTrades.X, TradesPctBox.Height)
            G_btmTrades.DrawLine(pt.P_DashedLine, 0, pointMouseMoveTrades.Y, TradesPctBox.Width, pointMouseMoveTrades.Y)
            G_btmVolumes.DrawLine(pt.P_DashedLine, pointMouseMoveTrades.X, 0, pointMouseMoveTrades.X, VolumesTradesPctBox.Height)
            G_btmPrices.DrawLine(pt.P_DashedLine, 0, pointMouseMoveTrades.Y, PricesTradesPctBox.Width, pointMouseMoveTrades.Y)

            Dim heightOfRectangle As Double = 20
            pt.rectangleForPrice.X = 0
            pt.rectangleForPrice.Width = PricesTradesPctBox.Width
            pt.rectangleForPrice.Height = heightOfRectangle
            If pointMouseMoveTrades.Y < TradesPctBox.Height / 2 Then
                pt.rectangleForPrice.Y = pointMouseMoveTrades.Y
                G_btmPrices.FillRectangle(Brushes.DarkRed, pt.rectangleForPrice)
                G_btmPrices.DrawString(currentTradePriceMM, font, Brushes.White, New PointF(22, pointMouseMoveTrades.Y + 4))
            Else
                pt.rectangleForPrice.Y = pointMouseMoveTrades.Y - heightOfRectangle
                G_btmPrices.FillRectangle(Brushes.DarkRed, pt.rectangleForPrice)
                G_btmPrices.DrawString(currentTradePriceMM, font, Brushes.White, New PointF(22, pointMouseMoveTrades.Y - 17))
            End If
        End If

        If (Me.isCursorOnVolumesChart) Then
            G_btmVolumes.DrawLine(pt.P_DashedLine, pointMouseMoveVolumes.X, 0, pointMouseMoveVolumes.X, VolumesTradesPctBox.Height)
            G_btmVolumes.DrawLine(pt.P_DashedLine, 0, pointMouseMoveVolumes.Y, VolumesTradesPctBox.Width, pointMouseMoveVolumes.Y)
            G_btmTrades.DrawLine(pt.P_DashedLine, pointMouseMoveVolumes.X, 0, pointMouseMoveVolumes.X, TradesPctBox.Height)
            G_btmVolumesVolumes.DrawLine(pt.P_DashedLine, 0, pointMouseMoveVolumes.Y, VolumesVolumesTradesPctBox.Width, pointMouseMoveVolumes.Y)

            Dim heightOfRectangle As Double = 20
            pt.rectangleForVolume.X = 0
            pt.rectangleForVolume.Width = VolumesTradesPctBox.Width
            pt.rectangleForVolume.Height = heightOfRectangle
            If pointMouseMoveVolumes.Y < VolumesTradesPctBox.Height / 2 Then
                pt.rectangleForVolume.Y = pointMouseMoveVolumes.Y
                G_btmVolumesVolumes.FillRectangle(Brushes.DarkGreen, pt.rectangleForVolume)
                G_btmVolumesVolumes.DrawString(currentVolumeMM, font, Brushes.White, New PointF(22, pointMouseMoveVolumes.Y + 4))
            Else
                pt.rectangleForVolume.Y = pointMouseMoveVolumes.Y - heightOfRectangle
                G_btmVolumesVolumes.FillRectangle(Brushes.DarkGreen, pt.rectangleForVolume)
                G_btmVolumesVolumes.DrawString(currentVolumeMM, font, Brushes.White, New PointF(22, pointMouseMoveVolumes.Y - 17))
            End If
        End If
    End Sub

    Private Sub DrawAvg(index As Integer, G_btmVolumes As Graphics, VolumesTradesPctBox As PictureBox, GreenBrush As Brush, P_RedLine As Pen, P_BlueLine As Pen)
        Dim buyPlusSell As Boolean = False
        Dim original As Boolean = False
        Dim average As Boolean = False
        If (isCloned) Then
            buyPlusSell = CType(Me.usedForm, Form1Clone).BuyPlusSell.Checked
            original = CType(Me.usedForm, Form1Clone).Original.Checked
            average = CType(Me.usedForm, Form1Clone).Average.Checked
        Else
            buyPlusSell = CType(Me.usedForm, Form1).BuyPlusSell.Checked
            original = CType(Me.usedForm, Form1).Original.Checked
            average = CType(Me.usedForm, Form1).Average.Checked
        End If

        If (buyPlusSell) Then
            If (original) Then
                Dim procentsRectangle As Double = (pointsTradesNsec(index).volumeBuy + pointsTradesNsec(index).volumeSell) / yRangeVolumesTradesNsec
                Dim rectangle As RectangleF
                rectangle.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec
                rectangle.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsRectangle
                rectangle.Height = VolumesTradesPctBox.Height * procentsRectangle
                rectangle.Width = Me.intervalTradesNsec - 1
                G_btmVolumes.FillRectangle(GreenBrush, rectangle)
            End If
            If (average) Then
                If (Not index = Me.lastPointTradesNsec) Then
                    If (Not original) Then
                        yRangeVolumesTradesNsec = highBorderVolumesTradesAvgNsec
                        highBorderVolumesTradesNsec = highBorderVolumesTradesAvgNsec
                    Else
                        yRangeVolumesTradesNsec = highBorderVolumesTradesNsec
                        highBorderVolumesTradesNsec = highBorderVolumesTradesNsec
                    End If
                    If yRangeVolumesTradesNsec > 0 Then
                        Dim procentsAvg1 As Double = ((pointsTradesNsec(index).avgBuyPlusSell) / yRangeVolumesTradesNsec)
                        Dim procentsAvg2 As Double = ((pointsTradesNsec(index + 1).avgBuyPlusSell) / yRangeVolumesTradesNsec)
                        Dim p1Avg As Drawing.PointF
                        Dim p2Avg As Drawing.PointF
                        p1Avg.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec
                        p1Avg.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsAvg1
                        p2Avg.X = (index + 1 - Me.currentPointTradesNsec) * Me.intervalTradesNsec
                        p2Avg.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsAvg2
                        G_btmVolumes.DrawLine(pt.P_LightPinkLine, p1Avg, p2Avg)
                    End If
                End If
            End If
        Else
            If (original) Then
                If (Not index = Me.lastPointTradesNsec) Then
                    Dim procentsSell1 As Double = ((pointsTradesNsec(index).volumeSell) / yRangeVolumesTradesNsec)
                    Dim procentsSell2 As Double = ((pointsTradesNsec(index + 1).volumeSell) / yRangeVolumesTradesNsec)
                    Dim procentsBuy1 As Double = ((pointsTradesNsec(index).volumeBuy) / yRangeVolumesTradesNsec)
                    Dim procentsBuy2 As Double = ((pointsTradesNsec(index + 1).volumeBuy) / yRangeVolumesTradesNsec)
                    Dim p1Sell As Drawing.PointF
                    Dim p2Sell As Drawing.PointF
                    Dim p1Buy As Drawing.PointF
                    Dim p2Buy As Drawing.PointF
                    p1Sell.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p1Sell.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsSell1
                    p2Sell.X = (index + 1 - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p2Sell.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsSell2
                    p1Buy.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p1Buy.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsBuy1
                    p2Buy.X = (index + 1 - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p2Buy.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsBuy2
                    G_btmVolumes.DrawLine(P_RedLine, p1Sell, p2Sell)
                    G_btmVolumes.DrawLine(P_BlueLine, p1Buy, p2Buy)
                End If

            End If
            If (average) Then
                If (Not index = Me.lastPointTradesNsec) Then
                    If (Not original) Then
                        yRangeVolumesTradesNsec = highBorderVolumesTradesAvgNsec
                        highBorderVolumesTradesNsec = highBorderVolumesTradesAvgNsec
                    Else
                        yRangeVolumesTradesNsec = highBorderVolumesTradesNsec
                        highBorderVolumesTradesNsec = highBorderVolumesTradesNsec
                    End If
                    Dim procentsAvgBuy1 As Double = ((pointsTradesNsec(index).avgBuy) / yRangeVolumesTradesNsec)
                    Dim procentsAvgBuy2 As Double = ((pointsTradesNsec(index + 1).avgBuy) / yRangeVolumesTradesNsec)
                    Dim p1AvgBuy As Drawing.PointF
                    Dim p2AvgBuy As Drawing.PointF
                    p1AvgBuy.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p1AvgBuy.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsAvgBuy1
                    p2AvgBuy.X = (index + 1 - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p2AvgBuy.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsAvgBuy2
                    G_btmVolumes.DrawLine(pt.P_LightBlueLine, p1AvgBuy, p2AvgBuy)

                    Dim procentsAvgSell1 As Double = ((pointsTradesNsec(index).avgSell) / yRangeVolumesTradesNsec)
                    Dim procentsAvgSell2 As Double = ((pointsTradesNsec(index + 1).avgSell) / yRangeVolumesTradesNsec)
                    Dim p1AvgSell As Drawing.PointF
                    Dim p2AvgSell As Drawing.PointF
                    p1AvgSell.X = (index - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p1AvgSell.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsAvgSell1
                    p2AvgSell.X = (index + 1 - Me.currentPointTradesNsec) * Me.intervalTradesNsec + Me.intervalTradesNsec / 2
                    p2AvgSell.Y = VolumesTradesPctBox.Height - VolumesTradesPctBox.Height * procentsAvgSell2
                    G_btmVolumes.DrawLine(pt.P_LightPinkLine, p1AvgSell, p2AvgSell)
                End If
            End If
        End If
    End Sub
End Class