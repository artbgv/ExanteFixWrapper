Imports QuickFix
Imports System.Threading
Public Class Form1Clone
    Dim fixConfigPath As String = "FIX\fix_vendor.ini"
    Dim feedReciever As QuoteFixReciever
    Public pageList As List(Of Page) = New List(Of Page)
    Public isOnline As Boolean
    Public movingAverageWindowSize As Integer
    Private lastWindowState As FormWindowState = FormWindowState.Normal
    Private currentWidth As Integer
    Private currentHeight As Integer

    'данные из page
    Public cp As ChartPainting
    Public QuotesPctBox As PictureBox
    Public PricesQuotesPctBox As PictureBox
    Public TimesQuotesPctBox As PictureBox
    Public TradesPctBox As PictureBox
    Public PricesTradesPctBox As PictureBox
    Public TimesTradesPctBox As PictureBox
    Public LeftQuotesButton As Button
    Public RightQuotesButton As Button
    Public PlusQuotesButton As Button
    Public MinusQuotesButton As Button
    Public LeftTradesButton As Button
    Public RightTradesButton As Button
    Public PlusTradesButton As Button
    Public MinusTradesButton As Button
    Public Chart As TabControl
    Public VolumesTradesPctBox As PictureBox
    Public VolumesVolumesTradesPctBox As PictureBox
    Public movingAvgBuy As MovingAverage
    Public movingAvgSell As MovingAverage
    Public movingAvgBuyPlusSell As MovingAverage



    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub CaseN_AndDraw()
        If cp.pointsTradesNsec(0).highPrice <> 0 Then
            cp.paintingTradesNsec(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        movingAverageWindowSize = WindowSizeTextBox.Text
        If (Not isOnline) Then
            AskPriceLabel.Dispose()
            BidPriceLabel.Dispose()
            TradePriceLabel.Dispose()
            TradeVolumeLabel.Dispose()
        End If
        'ExanteIDTextBox0.Hide()
        DoubleBuffered = True
        MinusQuotesButton0.Hide()
        MinusTradesButton0.Hide()
        PlusQuotesButton0.Hide()
        PlusTradesButton0.Hide()
        RightButtonTrades0.Hide()
        RightQuotesButton0.Hide()
        LeftQuotesButton0.Hide()
        LeftTradesButton0.Hide()

        TicksOrSeconds.SelectedItem = "5 секунд"
        BuyPlusSell.Checked = True
        AddHandler Me.BuyAndSell.CheckedChanged, AddressOf RadiobuttonOnChange
        AddHandler Me.BuyPlusSell.CheckedChanged, AddressOf RadiobuttonOnChange
        TypeOfGraphic.SelectedItem = "Японские свечи"
        Me.movingAvgBuy = New MovingAverage(movingAverageWindowSize)
        Me.movingAvgSell = New MovingAverage(movingAverageWindowSize)
        Me.movingAvgBuyPlusSell = New MovingAverage(movingAverageWindowSize)
        Try
            cp.isSubscribed = True
            Tabs.TabPages(Tabs.SelectedIndex).Text = Form1.Tabs.TabPages(Form1.Tabs.SelectedIndex).Text
            Me.Text = Form1.Tabs.TabPages(Form1.Tabs.SelectedIndex).Text
        Catch ex As Exception
            MsgBox("Нет подключения")
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If feedReciever IsNot Nothing Then
        '    feedReciever.Logout()
        'End If
        'System.Windows.Forms.Application.Exit()
        Me.Hide()
    End Sub

    Private Sub QuotesPctBox_MouseMove(sender As Object, e As MouseEventArgs) Handles QuotesPctBox0.MouseMove
        cp.pointMouseMoveQuotes.X = e.X
        cp.pointMouseMoveQuotes.Y = e.Y
        If (cp.isSubscribed) Then
            Try
                If (cp.needRePaintingQuotes = False) Then
                    cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
                Else
                    cp.needRePaintingQuotes = False
                    cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
                    cp.needRePaintingQuotes = True
                End If
                Dim proportion As Double = cp.yRangeQuotes - (e.Y / QuotesPctBox.Height) * cp.yRangeQuotes
                PriceLabel0.Text = Format((cp.lowBorderQuotes) + proportion, "0.00")
                cp.currentQuotesPriceMM = Format((cp.lowBorderQuotes) + proportion, "0.00")
                Dim indexOfPoint = CInt(Math.Floor(e.X / cp.intervalQuotes))
                If (indexOfPoint < 0) Then
                    indexOfPoint = 0
                End If
                If (indexOfPoint >= cp.pointsQuotes.Count) Then
                    indexOfPoint = cp.pointsQuotes.Count - 1
                    TimeLabel0.Text = cp.pointsQuotes(indexOfPoint).time.ToLongTimeString
                Else
                    If (cp.currentPointQuotes + indexOfPoint > cp.pointsQuotes.Count) Then
                        TimeLabel0.Text = cp.pointsQuotes(cp.lastPointQuotes).time.ToLongTimeString

                    Else
                        TimeLabel0.Text = cp.pointsQuotes(cp.currentPointQuotes + indexOfPoint).time.ToLongTimeString
                    End If
                End If
                If (cp.isClickedQuotes) Then
                    If (e.X - cp.positionOfClickQuotes.X > 50) Then
                        LeftQuotesButton_Click(sender, e)
                        cp.positionOfClickQuotes = New PointF(e.X, e.Y)
                    End If
                End If

                If (cp.isClickedQuotes) Then
                    If (e.X - cp.positionOfClickQuotes.X < -50) Then
                        RightQuotesButton_Click(sender, e)
                        cp.positionOfClickQuotes = New PointF(e.X, e.Y)
                    End If
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub


    'left quotes
    Private Sub LeftQuotesButton_Click(sender As Object, e As EventArgs) Handles LeftQuotesButton0.Click
        cp.needDrawLineQuotes = False
        cp.isLineReadyQuotes = False
        cp.currentPointQuotes = cp.currentPointQuotes - 10
        If (cp.currentPointQuotes < 0) Then
            cp.currentPointQuotes = 0
        End If
        cp.needRePaintingQuotes = False
        Try
            cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
        Catch ex As Exception
            cp.currentPointQuotes -= 1
            If (cp.currentPointQuotes < 0) Then
                cp.currentPointQuotes = 0
            End If
        End Try
    End Sub

    'rigth quotes
    Private Sub RightQuotesButton_Click(sender As Object, e As EventArgs) Handles RightQuotesButton0.Click
        cp.needDrawLineQuotes = False
        cp.isLineReadyQuotes = False
        If (cp.pointsQuotes.Count > cp.pointsOnScreenQuotes) Then
            cp.currentPointQuotes = cp.currentPointQuotes + 10
            If (cp.currentPointQuotes + cp.pointsOnScreenQuotes > cp.pointsQuotes.Count) Then
                cp.currentPointQuotes = cp.pointsQuotes.Count - cp.pointsOnScreenQuotes
            End If

            If (Not cp.lastPointQuotes = cp.pointsQuotes.Count - 1) Then
                Try
                    cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
                Catch ex As Exception
                    cp.currentPointQuotes -= 1
                    If (cp.currentPointQuotes < 0) Then
                        cp.currentPointQuotes = 0
                    End If
                End Try
            Else
                cp.needRePaintingQuotes = True
            End If
        End If



    End Sub

    '+ quotes
    Private Sub PlusQuotesButton_Click(sender As Object, e As EventArgs) Handles PlusQuotesButton0.Click
        cp.needDrawLineQuotes = False
        cp.isLineReadyQuotes = False
        cp.pointsOnScreenQuotes += 15
        cp.currentPointQuotes -= 16
        If (cp.currentPointQuotes < 0) Then
            cp.currentPointQuotes = 0
        End If
        If (cp.pointsOnScreenQuotes > cp.maxPointsOnScreenQuotes) Then
            cp.pointsOnScreenQuotes = cp.maxPointsOnScreenQuotes
        End If
        cp.needRePaintingQuotes = False
        If (cp.lastPointQuotes < cp.pointsQuotes.Count - 1) Then
            Try
                cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
            Catch ex As Exception
                cp.currentPointQuotes -= 1
                If (cp.currentPointQuotes < 0) Then
                    cp.currentPointQuotes = 0
                End If
            End Try
        Else
            Try
                cp.currentPointQuotes -= 1
                If (cp.currentPointQuotes < 0) Then
                    cp.currentPointQuotes = 0
                End If
                cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
            Catch ex As Exception

            End Try
        End If
    End Sub

    '- quotes
    Private Sub MinusQuotesButton_Click(sender As Object, e As EventArgs) Handles MinusQuotesButton0.Click
        cp.needDrawLineQuotes = False
        cp.isLineReadyQuotes = False
        cp.pointsOnScreenQuotes -= 15
        If (cp.pointsOnScreenQuotes < cp.minPointsOnScreenQuotes) Then
            cp.pointsOnScreenQuotes = cp.minPointsOnScreenQuotes
        End If
        cp.needRePaintingQuotes = False
        Try
            cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
        Catch ex As Exception
            cp.currentPointQuotes -= 1
            If (cp.currentPointQuotes < 0) Then
                cp.currentPointQuotes = 0
            End If
        End Try
    End Sub
    'left trades
    Private Sub LeftTradesButton_Click(sender As Object, e As EventArgs) Handles LeftTradesButton0.Click
        Select Case Me.TicksOrSeconds.SelectedItem
            Case "Тики"
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                cp.currentPointTrades = cp.currentPointTrades - 10
                If (cp.currentPointTrades < 0) Then
                    cp.currentPointTrades = 0
                End If
                cp.needRePaintingTrades = False
                Try
                    cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                Catch ex As Exception
                    cp.currentPointTrades -= 1
                    If (cp.currentPointTrades < 0) Then
                        cp.currentPointTrades = 0
                    End If
                End Try
            Case Else
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                cp.currentPointTradesNsec = cp.currentPointTradesNsec - 10
                If (cp.currentPointTradesNsec < 0) Then
                    cp.currentPointTradesNsec = 0
                End If
                cp.needRePaintingTradesNsec = False
                Try
                    CaseN_AndDraw()
                Catch ex As Exception
                    cp.currentPointTradesNsec -= 1
                    If (cp.currentPointTradesNsec < 0) Then
                        cp.currentPointTradesNsec = 0
                    End If
                End Try
        End Select
    End Sub

    'right trades
    Private Sub RightTradesButton_Click(sender As Object, e As EventArgs) Handles RightButtonTrades0.Click
        Select Case Me.TicksOrSeconds.SelectedItem
            Case "Тики"
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                If (cp.pointsTrades.Count > cp.pointsOnScreenTrades) Then
                    cp.currentPointTrades = cp.currentPointTrades + 10
                    If (cp.currentPointTrades + cp.pointsOnScreenTrades > cp.pointsTrades.Count) Then
                        cp.currentPointTrades = cp.pointsTrades.Count - cp.pointsOnScreenTrades
                    End If

                    If (Not cp.lastPointTrades = cp.pointsTrades.Count - 1) Then
                        Try
                            cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                        Catch ex As Exception
                            cp.currentPointTrades -= 1
                            If (cp.currentPointTrades < 0) Then
                                cp.currentPointTrades = 0
                            End If
                        End Try
                    Else
                        cp.needRePaintingTrades = True
                    End If
                End If
            Case Else
                Dim pointsTradesNsec As List(Of PointTradesNsec)
                Select Case TicksOrSeconds.SelectedItem
                    Case "5 секунд"
                        pointsTradesNsec = cp.pointsTrades5sec
                    Case "10 секунд"
                        pointsTradesNsec = cp.pointsTrades10sec
                    Case "15 секунд"
                        pointsTradesNsec = cp.pointsTrades15sec
                    Case "30 секунд"
                        pointsTradesNsec = cp.pointsTrades30sec
                    Case "1 минута"
                        pointsTradesNsec = cp.pointsTrades60sec
                    Case "5 минут"
                        pointsTradesNsec = cp.pointsTrades300sec
                    Case "10 минут"
                        pointsTradesNsec = cp.pointsTrades600sec
                    Case "15 минут"
                        pointsTradesNsec = cp.pointsTrades900sec
                    Case "30 минут"
                        pointsTradesNsec = cp.pointsTrades1800sec
                    Case "1 час"
                        pointsTradesNsec = cp.pointsTrades3600sec
                    Case Else
                        pointsTradesNsec = cp.pointsTrades5sec
                End Select
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                If pointsTradesNsec.Count > cp.pointsOnScreenTradesNsec Then
                    cp.currentPointTradesNsec = cp.currentPointTradesNsec + 10
                    If (cp.currentPointTradesNsec + cp.pointsOnScreenTradesNsec > pointsTradesNsec.Count) Then
                        cp.currentPointTradesNsec = pointsTradesNsec.Count - cp.pointsOnScreenTradesNsec
                    End If

                    If (Not cp.lastPointTradesNsec = pointsTradesNsec.Count - 1) Then
                        Try
                            CaseN_AndDraw()
                        Catch ex As Exception
                            cp.currentPointTradesNsec -= 1
                            If (cp.currentPointTradesNsec < 0) Then
                                cp.currentPointTradesNsec = 0
                            End If
                        End Try
                    Else
                        cp.needRePaintingTradesNsec = True
                    End If
                End If
        End Select
    End Sub

    '+ trades
    Private Sub PlusTradesButton_Click(sender As Object, e As EventArgs) Handles PlusTradesButton0.Click
        Select Case Me.TicksOrSeconds.SelectedItem
            Case "Тики"
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                cp.pointsOnScreenTrades += 15
                cp.currentPointTrades -= 15
                If (cp.currentPointTrades < 0) Then
                    cp.currentPointTrades = 0
                End If
                If (cp.pointsOnScreenTrades > cp.maxPointsOnScreenTrades) Then
                    cp.pointsOnScreenTrades = cp.maxPointsOnScreenTrades
                    Exit Sub
                End If
                cp.needRePaintingTrades = False
                If (cp.lastPointTrades < cp.pointsTrades.Count - 1) Then
                    Try
                        cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                    Catch ex As Exception
                        cp.currentPointTrades -= 1
                        If (cp.currentPointTrades < 0) Then
                            cp.currentPointTrades = 0
                        End If
                    End Try
                Else
                    cp.currentPointTrades -= 7
                    If (cp.currentPointTrades < 0) Then
                        cp.currentPointTrades = 0
                    End If
                    Try
                        cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                    Catch ex As Exception
                        cp.currentPointTrades -= 1
                        If (cp.currentPointTrades < 0) Then
                            cp.currentPointTrades = 0
                        End If
                    End Try
                End If
            Case Else
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                cp.pointsOnScreenTradesNsec += 15
                cp.currentPointTradesNsec -= 15
                If (cp.currentPointTradesNsec < 0) Then
                    cp.currentPointTradesNsec = 0
                End If
                If (cp.pointsOnScreenTradesNsec > cp.maxPointsOnScreenTradesNsec) Then
                    cp.pointsOnScreenTradesNsec = cp.maxPointsOnScreenTradesNsec
                    Exit Sub
                End If
                cp.needRePaintingTradesNsec = False
                If (cp.lastPointTradesNsec < cp.pointsTrades5sec.Count - 1) Then
                    Try
                        CaseN_AndDraw()
                    Catch ex As Exception
                        cp.currentPointTradesNsec -= 1
                        If (cp.currentPointTradesNsec < 0) Then
                            cp.currentPointTradesNsec = 0
                        End If
                    End Try
                Else
                    cp.currentPointTradesNsec -= 7
                    If (cp.currentPointTradesNsec < 0) Then
                        cp.currentPointTradesNsec = 0
                    End If
                    Try
                        CaseN_AndDraw()
                    Catch ex As Exception
                        cp.currentPointTradesNsec -= 1
                        If (cp.currentPointTradesNsec < 0) Then
                            cp.currentPointTradesNsec = 0
                        End If
                    End Try
                End If
        End Select

    End Sub

    '- trades
    Private Sub MinusTradesButton_Click(sender As Object, e As EventArgs) Handles MinusTradesButton0.Click
        Select Case Me.TicksOrSeconds.SelectedItem
            Case "Тики"
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                cp.pointsOnScreenTrades -= 15
                If (cp.pointsOnScreenTrades < cp.minPointsOnScreenTrades) Then
                    cp.pointsOnScreenTrades = cp.minPointsOnScreenTrades
                End If
                cp.needRePaintingTrades = False
                Try
                    cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                Catch ex As Exception
                    cp.currentPointTrades -= 1
                    If (cp.currentPointTrades < 0) Then
                        cp.currentPointTrades = 0
                    End If
                End Try
            Case Else
                cp.needDrawLineTrades = False
                cp.isLineReadyTrades = False
                cp.pointsOnScreenTradesNsec -= 15
                If (cp.pointsOnScreenTradesNsec < cp.minPointsOnScreenTradesNsec) Then
                    cp.pointsOnScreenTradesNsec = cp.minPointsOnScreenTradesNsec
                End If
                cp.needRePaintingTradesNsec = False
                Try
                    CaseN_AndDraw()
                Catch ex As Exception
                    cp.currentPointTradesNsec -= 1
                    If (cp.currentPointTradesNsec < 0) Then
                        cp.currentPointTradesNsec = 0
                    End If
                End Try
        End Select
    End Sub

    Private Sub TradesPctBox_MouseMove(sender As Object, e As MouseEventArgs) Handles TradesPctBox0.MouseMove
        cp.pointMouseMoveTrades.X = e.X
        cp.pointMouseMoveTrades.Y = e.Y
        If (Me.TicksOrSeconds.SelectedItem = "Тики") Then
            If (cp.needRePaintingTrades = False) Then
                cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
            Else
                cp.needRePaintingTrades = False
                cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                cp.needRePaintingTrades = True
            End If
            If (cp.isSubscribed And Not cp.intervalTrades = 0 And Not cp.pointsTrades.Count = 0) Then
                Dim proportion As Double = cp.yRangeTrades - (e.Y / TradesPctBox.Height) * cp.yRangeTrades
                PriceLabel0.Text = Format((cp.lowBorderTrades) + proportion, "0.00")
                cp.currentTradePriceMM = Format((cp.lowBorderTrades) + proportion, "0.00")
                Dim indexOfPoint = CInt(Math.Floor(e.X / cp.intervalTrades))
                If (indexOfPoint < 0) Then
                    indexOfPoint = 0
                End If
                If (indexOfPoint >= cp.pointsTrades.Count) Then
                    indexOfPoint = cp.pointsTrades.Count - 1
                    If (indexOfPoint < 0) Then
                        indexOfPoint = 0
                    End If
                    TimeLabel0.Text = cp.pointsTrades(indexOfPoint).time.ToLongTimeString
                Else
                    If (cp.currentPointTrades + indexOfPoint > cp.pointsTrades.Count) Then
                        TimeLabel0.Text = cp.pointsTrades(cp.lastPointTrades).time.ToLongTimeString
                    Else
                        TimeLabel0.Text = cp.pointsTrades(cp.currentPointTrades + indexOfPoint).time.ToLongTimeString
                    End If
                End If
            End If

            If (cp.isClickedTrades) Then
                If (e.X - cp.positionOfClickTrades.X > 10) Then
                    LeftTradesButton_Click(sender, e)
                End If
            End If
        Else
            If (cp.needRePaintingTradesNsec = False) Then
                CaseN_AndDraw()
            Else
                cp.needRePaintingTradesNsec = False
                CaseN_AndDraw()
                cp.needRePaintingTradesNsec = True
            End If
            If (cp.isSubscribed And Not cp.intervalTradesNsec = 0 And Not cp.pointsTradesNsec.Count = 0) Then
                Dim proportion As Double = cp.yRangeTradesNsec - (e.Y / TradesPctBox.Height) * cp.yRangeTradesNsec
                PriceLabel0.Text = Format((cp.lowBorderTradesNsec) + proportion, "0.00")
                cp.currentTradePriceMM = Format((cp.lowBorderTradesNsec) + proportion, "0.00")
                Dim indexOfPoint = CInt(Math.Floor(e.X / cp.intervalTradesNsec))
                If (indexOfPoint < 0) Then
                    indexOfPoint = 0
                End If
                If (indexOfPoint >= cp.pointsTradesNsec.Count) Then
                    indexOfPoint = cp.pointsTradesNsec.Count - 1
                    If (indexOfPoint < 0) Then
                        indexOfPoint = 0
                    End If
                    TimeLabel0.Text = cp.pointsTradesNsec(indexOfPoint).time.ToLongTimeString
                Else
                    If (cp.currentPointTradesNsec + indexOfPoint > cp.pointsTradesNsec.Count) Then
                        TimeLabel0.Text = cp.pointsTradesNsec(cp.lastPointTradesNsec).time.ToLongTimeString
                    Else
                        TimeLabel0.Text = cp.pointsTradesNsec(cp.currentPointTradesNsec + indexOfPoint).time.ToLongTimeString
                    End If
                End If
            End If
            If (cp.isClickedTrades) Then
                If (e.X - cp.positionOfClickTrades.X < -50) Then
                    RightTradesButton_Click(sender, e)
                    cp.positionOfClickTrades = New PointF(e.X, e.Y)
                End If
            End If

            If (cp.isClickedTrades) Then
                If (e.X - cp.positionOfClickTrades.X > 50) Then
                    LeftTradesButton_Click(sender, e)
                    cp.positionOfClickTrades = New PointF(e.X, e.Y)
                End If
            End If
        End If
    End Sub

    Private Sub MouseWheelScroll(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If Chart.SelectedIndex = 1 Then
            If cp.isCursorOnTradesChart Then
                Dim currentIndex As Integer
                If Me.TicksOrSeconds.SelectedItem = "Тики" Then
                    currentIndex = cp.currentPointTrades
                Else
                    currentIndex = cp.currentPointTradesNsec
                End If
                If (e.Delta < -30) Then
                    If Me.TicksOrSeconds.SelectedItem = "Тики" Then
                        cp.pointsOnScreenTrades -= 15
                        If (cp.pointsOnScreenTrades < cp.minPointsOnScreenTrades) Then
                            cp.pointsOnScreenTrades = cp.minPointsOnScreenTrades
                        Else
                            cp.currentPointTrades = currentIndex + Math.Floor((e.X / TradesPctBox.Width) * 15)
                            If (cp.currentPointTrades < 0) Then
                                cp.currentPointTrades = 0
                            End If
                        End If
                        cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                    Else
                        cp.pointsOnScreenTradesNsec -= 15
                        If (cp.pointsOnScreenTradesNsec < cp.minPointsOnScreenTradesNsec) Then
                            cp.pointsOnScreenTradesNsec = cp.minPointsOnScreenTradesNsec
                        Else
                            cp.currentPointTradesNsec = currentIndex + Math.Floor((e.X / TradesPctBox.Width) * 15)
                            If (cp.currentPointTradesNsec < 0) Then
                                cp.currentPointTradesNsec = 0
                            End If
                        End If
                        CaseN_AndDraw()
                    End If
                End If

                If (e.Delta > 30) Then
                    If Me.TicksOrSeconds.SelectedItem = "Тики" Then
                        cp.pointsOnScreenTrades += 15
                        If (cp.pointsOnScreenTrades > cp.maxPointsOnScreenTrades) Then
                            cp.pointsOnScreenTrades = cp.maxPointsOnScreenTrades
                        Else
                            cp.currentPointTrades = currentIndex - Math.Floor((e.X / TradesPctBox.Width) * 15)
                            If (cp.currentPointTrades > cp.pointsTrades.Count - cp.pointsOnScreenTrades) Then
                                cp.currentPointTrades = cp.pointsTrades.Count - cp.pointsOnScreenTrades
                            End If
                        End If
                        cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                    Else
                        cp.pointsOnScreenTradesNsec += 15
                        If (cp.pointsOnScreenTradesNsec > cp.maxPointsOnScreenTradesNsec) Then
                            cp.pointsOnScreenTradesNsec = cp.maxPointsOnScreenTradesNsec
                        Else
                            cp.currentPointTradesNsec = currentIndex - Math.Floor((e.X / TradesPctBox.Width) * 15)
                            If (cp.currentPointTradesNsec > cp.pointsTradesNsec.Count - cp.pointsOnScreenTradesNsec) Then
                                cp.currentPointTradesNsec = cp.pointsTradesNsec.Count - cp.pointsOnScreenTradesNsec
                            End If
                        End If
                        CaseN_AndDraw()
                    End If
                End If
            End If

        Else
            If (e.Delta < -30) Then
                MinusQuotesButton_Click(sender, e)
            End If

            If (e.Delta > 30) Then
                PlusQuotesButton_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub DrawLineTrades_Click(sender As Object, e As EventArgs) Handles DrawLineTrades0.Click
        cp.needDrawLineTrades = True
        cp.needRePaintingTrades = False
    End Sub

    Private Sub TradesPctBox_MouseClick(sender As Object, e As MouseEventArgs) Handles TradesPctBox0.MouseClick
        If (cp.needDrawLineTrades And Not cp.isDrawingStartedTrades) Then
            cp.point1Trades.X = e.X
            cp.point1Trades.Y = e.Y
            cp.isDrawingStartedTrades = True
            Exit Sub
        End If
        If (cp.needDrawLineTrades And cp.isDrawingStartedTrades) Then
            cp.point2Trades.X = e.X
            cp.point2Trades.Y = e.Y
            cp.isDrawingStartedTrades = False
            cp.isLineReadyTrades = True
            cp.paintingTrades(TradesPctBox0, TimesTradesPctBox0, PricesTradesPctBox0, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
            Exit Sub
        End If

    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tabs.SelectedIndexChanged
        If (cp.isSubscribed) Then
            Try
                cp.needRePaintingQuotes = False
                cp.needRePaintingTrades = False
                If (Chart.SelectedIndex = 0) Then
                    cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
                Else
                    If (TicksOrSeconds.SelectedItem = "Тики") Then
                        cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                    Else
                        CaseN_AndDraw()
                    End If

                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub VolumesTradesPctBox_MouseMove(sender As Object, e As MouseEventArgs) Handles VolumesTradesPctBox0.MouseMove
        cp.pointMouseMoveVolumes.X = e.X
        cp.pointMouseMoveVolumes.Y = e.Y
        If (TicksOrSeconds.SelectedItem = "Тики") Then
            If (cp.isSubscribed And Not cp.intervalTrades = 0) Then
                Try
                    Dim proportion As Double = cp.yRangeVolumesTrades - (e.Y / VolumesTradesPctBox.Height) * cp.yRangeVolumesTrades
                    VolumeLabel.Text = Format(proportion, "0.00")
                    cp.currentVolumeMM = Format(proportion, "0.00")
                    Dim indexOfPoint = CInt(Math.Floor(e.X / cp.intervalTrades))
                    If (indexOfPoint < 0) Then
                        indexOfPoint = 0
                    End If
                    If (indexOfPoint >= cp.pointsTrades.Count) Then
                        indexOfPoint = cp.pointsTrades.Count - 1
                        CurVolumeLabel.Text = cp.pointsTrades(indexOfPoint).tradeVolume
                    Else
                        If (cp.currentPointTrades + indexOfPoint > cp.pointsTrades.Count) Then
                            CurVolumeLabel.Text = cp.pointsTrades(cp.lastPointTrades).tradeVolume

                        Else
                            CurVolumeLabel.Text = cp.pointsTrades(cp.currentPointTrades + indexOfPoint).tradeVolume
                        End If
                    End If
                    If (cp.needRePaintingTrades = False) Then
                        cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                    Else
                        cp.needRePaintingTrades = False
                        cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                        cp.needRePaintingTrades = True
                    End If
                Catch ex As Exception

                End Try
            End If

        Else
            If (cp.isSubscribed And Not cp.intervalTradesNsec = 0) Then
                Try
                    Dim proportion As Double = cp.yRangeVolumesTradesNsec - (e.Y / VolumesTradesPctBox.Height) * cp.yRangeVolumesTradesNsec
                    VolumeLabel.Text = Format(proportion, "0.00")
                    cp.currentVolumeMM = Format(proportion, "0.00")
                    Dim indexOfPoint = CInt(Math.Floor(e.X / cp.intervalTradesNsec))
                    If (indexOfPoint < 0) Then
                        indexOfPoint = 0
                    End If
                    If (indexOfPoint >= cp.pointsTradesNsec.Count) Then
                        indexOfPoint = cp.pointsTradesNsec.Count - 1
                        CurVolumeLabel.Text = cp.pointsTradesNsec(indexOfPoint).volumeBuy + cp.pointsTradesNsec(indexOfPoint).volumeSell
                    Else
                        If (cp.currentPointTradesNsec + indexOfPoint > cp.pointsTradesNsec.Count) Then
                            CurVolumeLabel.Text = cp.pointsTradesNsec(cp.lastPointTradesNsec).volumeBuy + cp.pointsTradesNsec(cp.lastPointTradesNsec).volumeSell

                        Else
                            CurVolumeLabel.Text = cp.pointsTradesNsec(cp.currentPointTradesNsec + indexOfPoint).volumeSell + cp.pointsTradesNsec(cp.currentPointTradesNsec + indexOfPoint).volumeBuy
                        End If
                    End If
                    If (cp.needRePaintingTradesNsec = False) Then
                        CaseN_AndDraw()
                    Else
                        cp.needRePaintingTradesNsec = False
                        CaseN_AndDraw()
                        cp.needRePaintingTradesNsec = True
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub TicksOrSeconds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TicksOrSeconds.SelectedIndexChanged
        If (TicksOrSeconds.SelectedItem = "Тики") Then
            If cp.pointsTrades(0).tradePrice <> 0 And cp.pointsTrades(0).tradeVolume <> 0 Then
                cp.currentPointTrades = cp.pointsTrades.Count - cp.pointsOnScreenTrades - 1
                If cp.currentPointTrades < 0 Then
                    cp.currentPointTrades = 0
                End If
                cp.needRePaintingTrades = True
                cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
            End If

        Else
            Select Case TicksOrSeconds.SelectedItem
                Case "5 секунд"
                    cp.currentPointTradesNsec = cp.pointsTrades5sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades5sec
                Case "10 секунд"
                    cp.currentPointTradesNsec = cp.pointsTrades10sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades10sec
                Case "15 секунд"
                    cp.currentPointTradesNsec = cp.pointsTrades15sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades15sec
                Case "30 секунд"
                    cp.currentPointTradesNsec = cp.pointsTrades30sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades30sec
                Case "1 минута"
                    cp.currentPointTradesNsec = cp.pointsTrades60sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades60sec
                Case "5 минут"
                    cp.currentPointTradesNsec = cp.pointsTrades300sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades300sec
                Case "10 минут"
                    cp.currentPointTradesNsec = cp.pointsTrades600sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades600sec
                Case "15 минут"
                    cp.currentPointTradesNsec = cp.pointsTrades900sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades900sec
                Case "30 минут"
                    cp.currentPointTradesNsec = cp.pointsTrades1800sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades1800sec
                Case "1 час"
                    cp.currentPointTradesNsec = cp.pointsTrades3600sec.Count - cp.pointsOnScreenTradesNsec - 1
                    cp.pointsTradesNsec = cp.pointsTrades3600sec
            End Select
            If Not isOnline Then
                cp.currentPointTradesNsec += 1
            End If
            If cp.currentPointTradesNsec < 0 Then
                cp.currentPointTradesNsec = 0
            End If
            cp.needRePaintingTradesNsec = True
            CaseN_AndDraw()
        End If
    End Sub

    Private Sub TypeOfGraphic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeOfGraphic.SelectedIndexChanged
        If (Chart.SelectedIndex = 1) Then
            If (Not TicksOrSeconds.SelectedItem = "Тики") Then
                If (cp.needRePaintingTradesNsec = False) Then
                    CaseN_AndDraw()
                Else
                    cp.needRePaintingTradesNsec = False
                    CaseN_AndDraw()
                    cp.needRePaintingTradesNsec = True
                End If
            End If
        End If

    End Sub

    Private Sub Charts0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Charts0.SelectedIndexChanged
        If (Chart.SelectedIndex = 0) Then
            If (cp.needRePaintingQuotes = False) Then
                cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
            Else
                cp.needRePaintingQuotes = False
                cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
                cp.needRePaintingQuotes = True
            End If
        Else
            If (TicksOrSeconds.SelectedItem = "Тики") Then
                If (cp.needRePaintingTrades = False) Then
                    cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                Else
                    cp.needRePaintingTrades = False
                    cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                    cp.needRePaintingTrades = True
                End If
            Else
                If (cp.needRePaintingTradesNsec = False) Then
                    CaseN_AndDraw()
                Else
                    cp.needRePaintingTradesNsec = False
                    CaseN_AndDraw()
                    cp.needRePaintingTradesNsec = True
                End If
            End If
        End If
    End Sub
    Private Sub RadiobuttonOnChange(sender As System.Object, e As System.EventArgs)
        Dim rb = CType(sender, RadioButton)
        TypeOfGraphic_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub Original_CheckedChanged(sender As Object, e As EventArgs) Handles Original.CheckedChanged
        Try
            TypeOfGraphic_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Average_CheckedChanged(sender As Object, e As EventArgs) Handles Average.CheckedChanged
        Original_CheckedChanged(sender, e)
    End Sub

    Private Sub WindowSizeBtn_Click(sender As Object, e As EventArgs) Handles WindowSizeBtn.Click
        movingAverageWindowSize = WindowSizeTextBox.Text
        movingAvgBuy = New MovingAverage(movingAverageWindowSize)
        movingAvgSell = New MovingAverage(movingAverageWindowSize)
        movingAvgBuyPlusSell = New MovingAverage(movingAverageWindowSize)
        ReCalculateMovingAverage()
        TypeOfGraphic_SelectedIndexChanged(sender, e)
    End Sub

    Public Sub ReCalculateLastValueMovingAvg()
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades5sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades10sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades15sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades30sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades60sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades300sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades600sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades900sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades1800sec)
        ReCalculateLastValueMovingAvgList(Me.cp.pointsTrades3600sec)
    End Sub
    Public Sub ReCalculateLastValueMovingAvgList(pointsTradesNsec As List(Of PointTradesNsec))
        Dim windowSize = movingAvgBuyPlusSell.windowSize
        Dim buyList = New List(Of Double)
        Dim sellList = New List(Of Double)
        Dim buyPlusSellList = New List(Of Double)
        If pointsTradesNsec.Count > windowSize Then
            For index = pointsTradesNsec.Count - windowSize To pointsTradesNsec.Count - 1
                buyList.Add(pointsTradesNsec(index).volumeBuy)
                sellList.Add(pointsTradesNsec(index).volumeSell)
                buyPlusSellList.Add(pointsTradesNsec(index).volumeBuy + pointsTradesNsec(index).volumeSell)
            Next
        Else
            For index = 0 To pointsTradesNsec.Count - 1
                buyList.Add(pointsTradesNsec(index).volumeBuy)
                sellList.Add(pointsTradesNsec(index).volumeSell)
                buyPlusSellList.Add(pointsTradesNsec(index).volumeBuy + pointsTradesNsec(index).volumeSell)
            Next
        End If


        pointsTradesNsec(pointsTradesNsec.Count - 1).avgBuy = movingAvgBuy.RecalculateValue(buyList)
        pointsTradesNsec(pointsTradesNsec.Count - 1).avgSell = movingAvgSell.RecalculateValue(sellList)
        pointsTradesNsec(pointsTradesNsec.Count - 1).avgBuyPlusSell = movingAvgBuyPlusSell.RecalculateValue(buyPlusSellList)
    End Sub

    Public Sub ReCalculateMovingAverage()
        ReCalculateMovingAvgList(Me.cp.pointsTrades5sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades10sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades15sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades30sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades60sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades300sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades600sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades900sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades1800sec)
        ReCalculateMovingAvgList(Me.cp.pointsTrades3600sec)
    End Sub

    Public Sub ReCalculateMovingAvgList(pointsTradesNsec As List(Of PointTradesNsec))
        movingAvgBuy.Reinitialize()
        movingAvgSell.Reinitialize()
        movingAvgBuyPlusSell.Reinitialize()
        For index = 0 To pointsTradesNsec.Count - 1
            pointsTradesNsec(index).avgBuy = movingAvgBuy.Calculate(pointsTradesNsec(index).volumeBuy)
            pointsTradesNsec(index).avgSell = movingAvgSell.Calculate(pointsTradesNsec(index).volumeSell)
            pointsTradesNsec(index).avgBuyPlusSell = movingAvgBuyPlusSell.Calculate(pointsTradesNsec(index).volumeBuy + pointsTradesNsec(index).volumeSell)
        Next
    End Sub
    Private Sub TradesPctBox0_MouseEnter(sender As Object, e As EventArgs) Handles TradesPctBox0.MouseEnter
        cp.isCursorOnTradesChart = True
    End Sub

    Private Sub TradesPctBox0_MouseLeave(sender As Object, e As EventArgs) Handles TradesPctBox0.MouseLeave
        cp.isCursorOnTradesChart = False
        If (Me.TicksOrSeconds.SelectedItem = "Тики") Then
            If (cp.needRePaintingTrades = False) Then
                cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
            Else
                cp.needRePaintingTrades = False
                cp.paintingTrades(TradesPctBox, TimesTradesPctBox, PricesTradesPctBox, VolumesTradesPctBox, VolumesVolumesTradesPctBox)
                cp.needRePaintingTrades = True
            End If
        Else
            If (cp.needRePaintingTradesNsec = False) Then
                CaseN_AndDraw()
            Else
                cp.needRePaintingTradesNsec = False
                CaseN_AndDraw()
                cp.needRePaintingTradesNsec = True
            End If
        End If
    End Sub

    Private Sub VolumesTradesPctBox0_MouseEnter(sender As Object, e As EventArgs) Handles VolumesTradesPctBox0.MouseEnter
        cp.isCursorOnVolumesChart = True
    End Sub

    Private Sub VolumesTradesPctBox0_MouseLeave(sender As Object, e As EventArgs) Handles VolumesTradesPctBox0.MouseLeave
        cp.isCursorOnVolumesChart = False
        TradesPctBox0_MouseLeave(sender, e)
    End Sub
    Private Sub Form1_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        Me.currentHeight = Me.Height
        Me.currentWidth = Me.Width
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Dim deltaH, deltaW As Integer
        If Me.currentHeight <> Me.Height Or Me.currentWidth <> Me.Width And Me.WindowState = lastWindowState Then
            deltaH = Me.Height - Me.currentHeight
            deltaW = Me.Width - Me.currentWidth
            Tabs.Height += deltaH
            Tabs.Width += deltaW
            ResizeChildren(Tabs, deltaH, deltaW)
            currentHeight = Me.Size.Height
            currentWidth = Me.Size.Width
        End If
    End Sub
    Private Sub ResizeChildren(control As Control, deltaH As Integer, deltaW As Integer)
        For Each child As Control In control.Controls
            If child.Name.IndexOf("Button") = -1 Then
                If child.Name.IndexOf("Prices") = -1 And child.Name.IndexOf("VolumesVolumes") = -1 Then
                    child.Width += deltaW
                End If
                If child.Name.IndexOf("Times") = -1 And child.Name.IndexOf("VolumesVolumes") = -1 And child.Name.IndexOf("VolumesTrades") = -1 And child.Name.IndexOf("Border") Then
                    child.Height += deltaH
                End If
                If child.Name.IndexOf("Times") <> -1 Or child.Name.IndexOf("VolumesVolumes") <> -1 Or child.Name.IndexOf("VolumesTrades") <> -1 Or child.Name.IndexOf("Border") <> -1 Then
                    child.Top += deltaH
                End If
            Else
                child.Top += deltaH
                child.Left += deltaW
            End If

            If child.HasChildren Then
                ResizeChildren(child, deltaH, deltaW)
            End If
        Next
    End Sub

    Private Sub TradesPctBox0_MouseUp(sender As Object, e As MouseEventArgs) Handles TradesPctBox0.MouseUp
        cp.isClickedTrades = False
    End Sub

    Private Sub TradesPctBox0_MouseDown(sender As Object, e As MouseEventArgs) Handles TradesPctBox0.MouseDown
        cp.isClickedTrades = True
        cp.positionOfClickTrades = New PointF(e.X, e.Y)
    End Sub

    Private Sub QuotesPctBox0_MouseUp(sender As Object, e As MouseEventArgs) Handles QuotesPctBox0.MouseUp
        cp.isClickedQuotes = False
    End Sub

    Private Sub QuotesPctBox0_MouseDown(sender As Object, e As MouseEventArgs) Handles QuotesPctBox0.MouseDown
        cp.isClickedQuotes = True
        cp.positionOfClickQuotes = New PointF(e.X, e.Y)
    End Sub

    Private Sub QuotesPctBox0_MouseEnter(sender As Object, e As EventArgs) Handles QuotesPctBox0.MouseEnter
        cp.isCursorOnQuotesChart = True
    End Sub

    Private Sub QuotesPctBox0_MouseLeave(sender As Object, e As EventArgs) Handles QuotesPctBox0.MouseLeave
        cp.isCursorOnQuotesChart = False
        If (cp.needRePaintingQuotes = False) Then
            cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
        Else
            cp.needRePaintingQuotes = False
            cp.paintingQuotes(QuotesPctBox, TimesQuotesPctBox, PricesQuotesPctBox)
            cp.needRePaintingQuotes = True
        End If
    End Sub

    Private Sub Form1Clone_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState <> lastWindowState Then
            lastWindowState = WindowState
            Dim deltaH, deltaW As Integer
            If Me.currentHeight <> Me.Height Or Me.currentWidth <> Me.Width Then
                deltaH = Me.Height - Me.currentHeight
                deltaW = Me.Width - Me.currentWidth
                Tabs.Height += deltaH
                Tabs.Width += deltaW
                ResizeChildren(Tabs, deltaH, deltaW)
            End If
            currentHeight = Me.Size.Height
            currentWidth = Me.Size.Width
        End If
    End Sub
End Class
