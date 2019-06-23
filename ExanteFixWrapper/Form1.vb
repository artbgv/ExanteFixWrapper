Imports QuickFix
Imports System.Threading
Imports System.Linq
Imports System.Windows.Forms.ListView

Public Class Form1
    Dim fixVendorConfigPath As String = "FIX\fix_vendor.ini"
    Dim fixBrokerConfigPath As String = "FIX\fix_broker.ini"
    Dim feedReciever As QuoteFixReciever
    Dim orderExecutor As OrderFixExecutor
    Public pageList As List(Of Page) = New List(Of Page)
    Public isOnline As Boolean
    Public Shared movingAverageWindowSize As Integer
    Private lastWindowState As FormWindowState = FormWindowState.Normal
    Private currentWidth As Integer
    Private currentHeight As Integer
    Private positionsUpdateTimer As System.Timers.Timer
    Public mouseSensitivity As Integer
    Private canResize As Boolean = True


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        If feedReciever IsNot Nothing Then
            feedReciever = Nothing
        End If
        feedReciever = New QuoteFixReciever(fixVendorConfigPath, AddressOf CheckingState)
        orderExecutor = New OrderFixExecutor(fixBrokerConfigPath, AddressOf CheckingState, AddressOf UpdatePositionsList)
    End Sub

    Sub CheckingState(state As Boolean)
        If Not Label1.IsDisposed Then
            Label1.Invoke(Sub()
                              If state = True Then
                                  Label1.Text = "OK"
                              Else
                                  Label1.Text = "Disconnect"
                              End If
                          End Sub)
        End If
    End Sub
    Public Sub UpdatePositionsList(position As PositionInfo)
        ListViewOrders.Invoke(Sub()
                                  ListViewOrders.SuspendDrawing()
                                  ListViewOrders.Items.Add(position.ConvertToListViewItem())
                                  ListViewOrders.ResumeDrawing()
                              End Sub)
    End Sub
    Public Sub CaseN_AndDraw()
        pageList(Tabs.SelectedIndex).cp.paintingTradesNsec(pageList(Tabs.SelectedIndex).TradesPctBox, pageList(Tabs.SelectedIndex).TimesTradesPctBox, pageList(Tabs.SelectedIndex).PricesTradesPctBox, pageList(Tabs.SelectedIndex).VolumesTradesPctBox, pageList(Tabs.SelectedIndex).VolumesVolumesTradesPctBox)
    End Sub

    Private Sub GetHistory(sender As Object, e As EventArgs)
        Try
            Tabs.TabPages(Tabs.SelectedIndex).Text = ExanteIDComboBox1.SelectedItem.ToString()
            Dim dbReader As New DataBaseReader("D:\Bases")
            Dim tuple = dbReader.GetListOfTrades5secPoints(ExanteIDComboBox1.SelectedItem.ToString())

            pageList(Tabs.SelectedIndex).cp.isSubscribed = True
            pageList(Tabs.SelectedIndex).cp.needRePaintingTradesNsec = False
            pageList(Tabs.SelectedIndex).cp.currentPointTradesNsec = 0
            pageList(Tabs.SelectedIndex).cp.pointsTrades5sec = tuple.Item1
            Dim movingAvgBuy As New MovingAverage(movingAverageWindowSize)
            Dim movingAvgSell As New MovingAverage(movingAverageWindowSize)
            Dim movingAvgBuyPlusSell As New MovingAverage(movingAverageWindowSize)
            For index = 0 To pageList(Tabs.SelectedIndex).cp.pointsTrades5sec.Count - 1
                pageList(Tabs.SelectedIndex).cp.pointsTrades5sec(index).avgBuy = movingAvgBuy.Calculate(pageList(Tabs.SelectedIndex).cp.pointsTrades5sec(index).volumeBuy)
                pageList(Tabs.SelectedIndex).cp.pointsTrades5sec(index).avgSell = movingAvgSell.Calculate(pageList(Tabs.SelectedIndex).cp.pointsTrades5sec(index).volumeSell)
                pageList(Tabs.SelectedIndex).cp.pointsTrades5sec(index).avgBuyPlusSell = movingAvgBuyPlusSell.Calculate(pageList(Tabs.SelectedIndex).cp.pointsTrades5sec(index).volumeBuy + pageList(Tabs.SelectedIndex).cp.pointsTrades5sec(index).volumeSell)
            Next
            pageList(Tabs.SelectedIndex).AddNSecondsPointOffline(pageList(Tabs.SelectedIndex).cp.pointsTrades5sec)
            CaseN_AndDraw()
            Charts0_SelectedIndexChanged(sender, e)
            pageList(Tabs.SelectedIndex).TabId = Tabs.SelectedIndex
        Catch ex As Exception
            MsgBox("Ошибка")
        End Try
    End Sub

    Private Sub AddPoint()
        With pageList(Tabs.SelectedIndex)
            Dim firstPointNsec As New PointTradesNsec()
            .cp.pointsTrades5sec.Add(firstPointNsec)
            .cp.pointsTrades10sec.Add(firstPointNsec)
            .cp.pointsTrades15sec.Add(firstPointNsec)
            .cp.pointsTrades30sec.Add(firstPointNsec)
            .cp.pointsTrades60sec.Add(firstPointNsec)
            .cp.pointsTrades300sec.Add(firstPointNsec)
            .cp.pointsTrades600sec.Add(firstPointNsec)
            .cp.pointsTrades900sec.Add(firstPointNsec)
            .cp.pointsTrades1800sec.Add(firstPointNsec)
            .cp.pointsTrades3600sec.Add(firstPointNsec)
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles SubscribreButton0.Click
        movingAverageWindowSize = WindowSizeTextBox.Text
        If (isOnline) Then
            Try
                AddPoint()
                pageList(Tabs.SelectedIndex).gettingHistory = True
                GetHistory(sender, e)
                pageList(Tabs.SelectedIndex).gettingHistory = False
                With pageList(Tabs.SelectedIndex)
                    Dim firstPointNsec As New PointTradesNsec()
                    If .cp.pointsTrades5sec.Count = 0 And Not .cp.pointsTrades5sec.Count = 1 Then
                        .cp.pointsTrades5sec.Add(firstPointNsec)
                    End If
                    If .cp.pointsTrades10sec.Count = 0 And Not .cp.pointsTrades10sec.Count = 1 Then
                        .cp.pointsTrades10sec.Add(firstPointNsec)
                    End If
                    If Not .cp.pointsTrades15sec.Count = 0 And Not .cp.pointsTrades15sec.Count = 1 Then
                        .cp.pointsTrades15sec.Add(firstPointNsec)
                    End If
                    If .cp.pointsTrades30sec.Count = 0 And Not .cp.pointsTrades30sec.Count = 1 Then
                        .cp.pointsTrades30sec.Add(firstPointNsec)
                    End If
                    If .cp.pointsTrades60sec.Count = 0 And Not .cp.pointsTrades60sec.Count = 1 Then
                        .cp.pointsTrades60sec.Add(firstPointNsec)
                    End If
                    If .cp.pointsTrades300sec.Count = 0 And Not .cp.pointsTrades300sec.Count = 1 Then
                        .cp.pointsTrades300sec.Add(firstPointNsec)
                    End If
                    If .cp.pointsTrades600sec.Count = 0 And Not .cp.pointsTrades600sec.Count = 1 Then
                        .cp.pointsTrades600sec.Add(firstPointNsec)
                    End If
                    If .cp.pointsTrades900sec.Count = 0 And Not .cp.pointsTrades900sec.Count = 1 Then
                        .cp.pointsTrades900sec.Add(firstPointNsec)
                    End If
                    If Not .cp.pointsTrades1800sec.Count = 0 And Not .cp.pointsTrades1800sec.Count = 1 Then
                        .cp.pointsTrades1800sec.Add(firstPointNsec)
                    End If
                    If Not .cp.pointsTrades3600sec.Count = 0 And Not .cp.pointsTrades3600sec.Count = 1 Then
                        .cp.pointsTrades3600sec.Add(firstPointNsec)
                    End If
                End With
                pageList(Tabs.SelectedIndex).cp.isSubscribed = True
                Tabs.TabPages(Tabs.SelectedIndex).Text = ExanteIDComboBox1.SelectedItem.ToString
                Dim subscribes = feedReciever.GetSubscribeInfos()
                With pageList(Tabs.SelectedIndex)
                    .bufferTrades.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades10sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades15sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades30sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades60sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades300sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades600sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades900sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades1800sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .bufferTrades3600sec.StartWritingData(ExanteIDComboBox1.SelectedItem.ToString())
                    .TabId = Tabs.SelectedIndex
                End With
                feedReciever.SubscribeForQuotes(ExanteIDComboBox1.SelectedItem.ToString(), AddressOf pageList(Tabs.SelectedIndex).OnMarketDataUpdate)
                If positionsUpdateTimer Is Nothing Then
                    positionsUpdateTimer = New Timers.Timer(2000)
                    AddHandler positionsUpdateTimer.Elapsed, AddressOf RefreshButton_Click
                End If
            Catch ex As Exception
                MsgBox("Нет подключения")
            End Try
        Else
            GetHistory(sender, e)
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not isOnline) Then
            Label1.Dispose()
            ConnectButton.Dispose()
            AskPriceLabel.Dispose()
            BidPriceLabel.Dispose()
            TradePriceLabel.Dispose()
            TradeVolumeLabel.Dispose()
            SubscribreButton0.Text = "Загрузить"
        End If
        MinusQuotesButton0.Hide()
        MinusTradesButton0.Hide()
        PlusQuotesButton0.Hide()
        PlusTradesButton0.Hide()
        RightButtonTrades0.Hide()
        RightQuotesButton0.Hide()
        LeftQuotesButton0.Hide()
        LeftTradesButton0.Hide()
        DoubleBuffered = True
        Dim newPage = New Page(New ChartPainting(Me, TradesPctBox0, TimesTradesPctBox0, PricesTradesPctBox0, VolumesTradesPctBox0, VolumesVolumesTradesPctBox0),
                               QuotesPctBox0,
                               PricesQuotesPctBox0,
                               TimesQuotesPctBox0,
                               TradesPctBox0,
                               PricesTradesPctBox0,
                               TimesTradesPctBox0,
                               LeftQuotesButton0,
                               RightQuotesButton0,
                               PlusQuotesButton0,
                               MinusQuotesButton0,
                               LeftTradesButton0,
                               RightButtonTrades0,
                               PlusTradesButton0,
                               MinusTradesButton0,
                               Charts0,
                               VolumesTradesPctBox0,
                               VolumesVolumesTradesPctBox0,
                               WindowSizeTextBox.Text)
        pageList.Add(newPage)
        TicksOrSeconds.SelectedItem = "5 секунд"
        BuyPlusSell.Checked = True
        AddHandler Me.BuyAndSell.CheckedChanged, AddressOf RadiobuttonOnChange
        AddHandler Me.BuyPlusSell.CheckedChanged, AddressOf RadiobuttonOnChange
        AddHandler Me.MouseWheel, AddressOf MouseWheelScroll
        TypeOfGraphic.SelectedItem = "Японские свечи"
        mouseSensitivity = 10
        pageList(Tabs.SelectedIndex).cp.isNeedShowAvg = False
        currentHeight = Me.Size.Height
        currentWidth = Me.Size.Width
        ListViewOrders.Columns.Add("Инструмент", 120, HorizontalAlignment.Left)
        ListViewOrders.Columns.Add("Позиция", 80, HorizontalAlignment.Left)
        ListViewOrders.Columns.Add("Средняя цена", 80, HorizontalAlignment.Left)
        ListViewOrders.Columns.Add("Прибыль/Убыток", 120, HorizontalAlignment.Left)
        ExanteIDComboBox1.SelectedItem = "BTC.EXANTE"
        Me.canResize = False
        Me.Width = 1350
        Me.Height = 850
        Me.canResize = True
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        If feedReciever IsNot Nothing Then
            feedReciever.Logout()
            orderExecutor.Logout()
        End If
        System.Diagnostics.Process.GetCurrentProcess().Kill()
    End Sub

    Private Sub paintQuotes(tabIndex As Integer)
        If (pageList(tabIndex).cp.needRePaintingQuotes = False) Then
            pageList(tabIndex).cp.paintingQuotes(pageList(tabIndex).QuotesPctBox, pageList(tabIndex).TimesQuotesPctBox, pageList(tabIndex).PricesQuotesPctBox)
        Else
            pageList(tabIndex).cp.needRePaintingQuotes = False
            pageList(tabIndex).cp.paintingQuotes(pageList(tabIndex).QuotesPctBox, pageList(tabIndex).TimesQuotesPctBox, pageList(tabIndex).PricesQuotesPctBox)
            pageList(tabIndex).cp.needRePaintingQuotes = True
        End If
    End Sub

    Private Sub paintTrades(tabIndex As Integer)
        If (pageList(tabIndex).cp.needRePaintingTrades = False) Then
            pageList(tabIndex).cp.paintingTrades(pageList(tabIndex).TradesPctBox, pageList(tabIndex).TimesTradesPctBox, pageList(tabIndex).PricesTradesPctBox, pageList(tabIndex).VolumesTradesPctBox, pageList(tabIndex).VolumesVolumesTradesPctBox)
        Else
            pageList(tabIndex).cp.needRePaintingTrades = False
            pageList(tabIndex).cp.paintingTrades(pageList(tabIndex).TradesPctBox, pageList(tabIndex).TimesTradesPctBox, pageList(tabIndex).PricesTradesPctBox, pageList(tabIndex).VolumesTradesPctBox, pageList(tabIndex).VolumesVolumesTradesPctBox)
            pageList(tabIndex).cp.needRePaintingTrades = True
        End If
    End Sub

    Private Sub paintTradesNsec(tabIndex As Integer)
        If (pageList(tabIndex).cp.needRePaintingTradesNsec = False) Then
            CaseN_AndDraw()
        Else
            pageList(tabIndex).cp.needRePaintingTradesNsec = False
            CaseN_AndDraw()
            pageList(tabIndex).cp.needRePaintingTradesNsec = True
        End If
    End Sub

    Private Sub QuotesPctBox_MouseMove(sender As Object, e As MouseEventArgs) Handles QuotesPctBox0.MouseMove
        If (pageList.Count = 0 Or Not pageList(Tabs.SelectedIndex).cp.isSubscribed) Then
            Exit Sub
        End If
        pageList(Tabs.SelectedIndex).cp.pointMouseMoveQuotes.X = e.X
        pageList(Tabs.SelectedIndex).cp.pointMouseMoveQuotes.Y = e.Y

        Dim index = Tabs.SelectedIndex
        If (pageList(index).cp.isClickedQuotes) Then
            If (e.X - pageList(index).cp.positionOfClickQuotes.X > 50) Then
                LeftQuotesButton_Click(sender, e)
                pageList(index).cp.positionOfClickQuotes = New PointF(e.X, e.Y)
            End If
            If (e.X - pageList(index).cp.positionOfClickQuotes.X < -50) Then
                RightQuotesButton_Click(sender, e)
                pageList(index).cp.positionOfClickQuotes = New PointF(e.X, e.Y)
            End If
        Else
            Dim proportion As Double = pageList(index).cp.yRangeQuotes - (e.Y / pageList(index).QuotesPctBox.Height) * pageList(index).cp.yRangeQuotes
            pageList(index).cp.currentQuotesPriceMM = Format((pageList(index).cp.lowBorderQuotes) + proportion, "0.00")
            paintQuotes(index)
        End If
    End Sub

    Private Sub DrawLine_Click(sender As Object, e As EventArgs)
        Dim index = Tabs.SelectedIndex
        paintQuotes(index)
    End Sub

    Private Sub QuotesPctBox_MouseClick(sender As Object, e As MouseEventArgs) Handles QuotesPctBox0.MouseClick
        If (pageList IsNot Nothing) Then
            If (pageList.Count > 0) Then
                If (pageList(Tabs.SelectedIndex).cp.needDrawLineQuotes And Not pageList(Tabs.SelectedIndex).cp.isDrawingStartedQuotes) Then
                    pageList(Tabs.SelectedIndex).cp.point1Quotes.X = e.X
                    pageList(Tabs.SelectedIndex).cp.point1Quotes.Y = e.Y
                    pageList(Tabs.SelectedIndex).cp.isDrawingStartedQuotes = True
                    Exit Sub
                End If
                If (pageList(Tabs.SelectedIndex).cp.needDrawLineQuotes And pageList(Tabs.SelectedIndex).cp.isDrawingStartedQuotes) Then
                    pageList(Tabs.SelectedIndex).cp.point2Quotes.X = e.X
                    pageList(Tabs.SelectedIndex).cp.point2Quotes.Y = e.Y
                    pageList(Tabs.SelectedIndex).cp.isDrawingStartedQuotes = False
                    pageList(Tabs.SelectedIndex).cp.isLineReadyQuotes = True
                    pageList(Tabs.SelectedIndex).cp.paintingQuotes(pageList(Tabs.SelectedIndex).QuotesPctBox, pageList(Tabs.SelectedIndex).TimesQuotesPctBox, pageList(Tabs.SelectedIndex).PricesQuotesPctBox)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    'left quotes
    Private Sub LeftQuotesButton_Click(sender As Object, e As EventArgs) Handles LeftQuotesButton0.Click
        Dim index = Tabs.SelectedIndex
        pageList(index).cp.currentPointQuotes = pageList(index).cp.currentPointQuotes - Me.mouseSensitivity
        pageList(index).cp.needRePaintingQuotes = False
        pageList(index).cp.paintingQuotes(pageList(index).QuotesPctBox, pageList(index).TimesQuotesPctBox, pageList(index).PricesQuotesPctBox)
    End Sub

    'right quotes
    Private Sub RightQuotesButton_Click(sender As Object, e As EventArgs) Handles RightQuotesButton0.Click
        Dim index = Tabs.SelectedIndex
        pageList(index).cp.currentPointQuotes = pageList(index).cp.currentPointQuotes + Me.mouseSensitivity
        If (pageList(index).cp.lastPointQuotes >= pageList(index).cp.pointsQuotes.Count - 1) Then
            pageList(index).cp.needRePaintingQuotes = True
        End If
        pageList(index).cp.paintingQuotes(pageList(index).QuotesPctBox, pageList(index).TimesQuotesPctBox, pageList(index).PricesQuotesPctBox)
    End Sub

    '+ quotes
    Private Sub PlusQuotesButton_Click(sender As Object, e As EventArgs) Handles PlusQuotesButton0.Click
        Dim index = Tabs.SelectedIndex
        pageList(index).cp.pointsOnScreenQuotes += 15
        pageList(index).cp.currentPointQuotes -= 16
        If (pageList(index).cp.pointsOnScreenQuotes > pageList(index).cp.maxPointsOnScreenQuotes) Then
            pageList(index).cp.pointsOnScreenQuotes = pageList(index).cp.maxPointsOnScreenQuotes
        End If
        pageList(index).cp.needRePaintingQuotes = False
        pageList(index).cp.paintingQuotes(pageList(index).QuotesPctBox, pageList(index).TimesQuotesPctBox, pageList(index).PricesQuotesPctBox)
    End Sub

    '- quotes
    Private Sub MinusQuotesButton_Click(sender As Object, e As EventArgs) Handles MinusQuotesButton0.Click
        pageList(Tabs.SelectedIndex).cp.pointsOnScreenQuotes -= 15
        If (pageList(Tabs.SelectedIndex).cp.pointsOnScreenQuotes < pageList(Tabs.SelectedIndex).cp.minPointsOnScreenQuotes) Then
            pageList(Tabs.SelectedIndex).cp.pointsOnScreenQuotes = pageList(Tabs.SelectedIndex).cp.minPointsOnScreenQuotes
        End If
        pageList(Tabs.SelectedIndex).cp.needRePaintingQuotes = False
        pageList(Tabs.SelectedIndex).cp.paintingQuotes(pageList(Tabs.SelectedIndex).QuotesPctBox, pageList(Tabs.SelectedIndex).TimesQuotesPctBox, pageList(Tabs.SelectedIndex).PricesQuotesPctBox)
    End Sub

    'left trades
    Private Sub LeftTradesButton_Click(sender As Object, e As EventArgs) Handles LeftTradesButton0.Click
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        Select Case Me.TicksOrSeconds.SelectedItem
            Case "Тики"
                cp.currentPointTrades = cp.currentPointTrades - Me.mouseSensitivity
                cp.needRePaintingTrades = False
                cp.paintingTrades(pageList(index).TradesPctBox, pageList(index).TimesTradesPctBox, pageList(index).PricesTradesPctBox, pageList(index).VolumesTradesPctBox, pageList(index).VolumesVolumesTradesPctBox)
            Case Else
                cp.currentPointTradesNsec = cp.currentPointTradesNsec - Me.mouseSensitivity
                cp.needRePaintingTradesNsec = False
                CaseN_AndDraw()
        End Select
    End Sub

    'right trades
    Private Sub RightTradesButton_Click(sender As Object, e As EventArgs) Handles RightButtonTrades0.Click
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        Select Case Me.TicksOrSeconds.SelectedItem
            Case "Тики"
                cp.currentPointTrades = cp.currentPointTrades + Me.mouseSensitivity
                If (cp.pointsTrades.Count > cp.pointsOnScreenTrades) Then
                    cp.needRePaintingTrades = True
                End If
                cp.paintingTrades(pageList(index).TradesPctBox, pageList(index).TimesTradesPctBox, pageList(index).PricesTradesPctBox, pageList(index).VolumesTradesPctBox, pageList(index).VolumesVolumesTradesPctBox)
            Case Else
                cp.currentPointTradesNsec = cp.currentPointTradesNsec + Me.mouseSensitivity
                If (cp.currentPointTradesNsec + cp.pointsOnScreenTradesNsec > cp.pointsTrades5sec.Count) Then
                    cp.needRePaintingTradesNsec = True
                End If
                CaseN_AndDraw()
        End Select
    End Sub

    Private Sub MouseWheelScroll(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        If pageList(index).Chart.SelectedIndex = 1 Then
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
                            cp.currentPointTrades = currentIndex + Math.Floor((e.X / pageList(index).TradesPctBox.Width) * 15)
                            If (cp.currentPointTrades < 0) Then
                                cp.currentPointTrades = 0
                            End If
                        End If
                        cp.paintingTrades(pageList(index).TradesPctBox, pageList(index).TimesTradesPctBox, pageList(index).PricesTradesPctBox, pageList(index).VolumesTradesPctBox, pageList(index).VolumesVolumesTradesPctBox)
                    Else
                        cp.pointsOnScreenTradesNsec -= 15
                        If (cp.pointsOnScreenTradesNsec < cp.minPointsOnScreenTradesNsec) Then
                            cp.pointsOnScreenTradesNsec = cp.minPointsOnScreenTradesNsec
                            Exit Sub
                        Else
                            cp.currentPointTradesNsec = currentIndex + Math.Floor((e.X / pageList(index).TradesPctBox.Width) * 15)
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
                            cp.currentPointTrades = currentIndex - Math.Floor((e.X / pageList(index).TradesPctBox.Width) * 15)
                            If (cp.currentPointTrades > cp.pointsTrades.Count - cp.pointsOnScreenTrades) Then
                                cp.currentPointTrades = cp.pointsTrades.Count - cp.pointsOnScreenTrades
                            End If
                        End If
                        cp.paintingTrades(pageList(index).TradesPctBox, pageList(index).TimesTradesPctBox, pageList(index).PricesTradesPctBox, pageList(index).VolumesTradesPctBox, pageList(index).VolumesVolumesTradesPctBox)
                    Else
                        cp.pointsOnScreenTradesNsec += 15
                        If (cp.pointsOnScreenTradesNsec > cp.maxPointsOnScreenTradesNsec) Then
                            cp.pointsOnScreenTradesNsec = cp.maxPointsOnScreenTradesNsec
                        Else
                            cp.currentPointTradesNsec = currentIndex - Math.Floor((e.X / pageList(index).TradesPctBox.Width) * 15)
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

    Private Sub TradesPctBox_MouseMove(sender As Object, e As MouseEventArgs) Handles TradesPctBox0.MouseMove
        If (pageList.Count = 0) Then
            Exit Sub
        End If
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        cp.pointMouseMoveTrades.X = e.X
        cp.pointMouseMoveTrades.Y = e.Y
        If (Me.TicksOrSeconds.SelectedItem = "Тики") Then
            If (cp.isSubscribed And Not cp.intervalTrades = 0 And Not cp.pointsTrades.Count = 0) Then
                Dim proportion As Double = cp.yRangeTrades - (e.Y / pageList(index).TradesPctBox.Height) * cp.yRangeTrades
                cp.currentTradePriceMM = Format((cp.lowBorderTrades) + proportion, "0.00")
            End If
            paintTrades(index)

            If (cp.isClickedTrades) Then
                If (e.X - cp.positionOfClickTrades.X > 50) Then
                    LeftTradesButton_Click(sender, e)
                    cp.positionOfClickTrades = New PointF(e.X, e.Y)
                End If
                If (e.X - cp.positionOfClickTrades.X < -50) Then
                    RightTradesButton_Click(sender, e)
                    cp.positionOfClickTrades = New PointF(e.X, e.Y)
                End If
            End If
        Else
            If (cp.isSubscribed And Not cp.intervalTradesNsec = 0 And Not cp.pointsTradesNsec.Count = 0) Then
                Dim proportion As Double = cp.yRangeTradesNsec - (e.Y / pageList(index).TradesPctBox.Height) * cp.yRangeTradesNsec
                cp.currentTradePriceMM = Format((cp.lowBorderTradesNsec) + proportion, "0.00")
            End If
            paintTradesNsec(index)
        End If
        If (cp.isClickedTrades) Then
            If (e.X - cp.positionOfClickTrades.X < -50) Then
                RightTradesButton_Click(sender, e)
                cp.positionOfClickTrades = New PointF(e.X, e.Y)
            End If
            If (e.X - cp.positionOfClickTrades.X > 50) Then
                LeftTradesButton_Click(sender, e)
                cp.positionOfClickTrades = New PointF(e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub TradesPctBox_MouseClick(sender As Object, e As MouseEventArgs) Handles TradesPctBox0.MouseClick
        If (pageList IsNot Nothing) Then
            If (pageList.Count > 0) Then
                If (pageList(Tabs.SelectedIndex).cp.needDrawLineTrades And Not pageList(Tabs.SelectedIndex).cp.isDrawingStartedTrades) Then
                    pageList(Tabs.SelectedIndex).cp.point1Trades.X = e.X
                    pageList(Tabs.SelectedIndex).cp.point1Trades.Y = e.Y
                    pageList(Tabs.SelectedIndex).cp.isDrawingStartedTrades = True
                    Exit Sub
                End If
                If (pageList(Tabs.SelectedIndex).cp.needDrawLineTrades And pageList(Tabs.SelectedIndex).cp.isDrawingStartedTrades) Then
                    pageList(Tabs.SelectedIndex).cp.point2Trades.X = e.X
                    pageList(Tabs.SelectedIndex).cp.point2Trades.Y = e.Y
                    pageList(Tabs.SelectedIndex).cp.isDrawingStartedTrades = False
                    pageList(Tabs.SelectedIndex).cp.isLineReadyTrades = True
                    pageList(Tabs.SelectedIndex).cp.paintingTrades(TradesPctBox0, TimesTradesPctBox0, PricesTradesPctBox0, pageList(Tabs.SelectedIndex).VolumesTradesPctBox, pageList(Tabs.SelectedIndex).VolumesVolumesTradesPctBox)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tabs.SelectedIndexChanged
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        If pageList Is Nothing Then
            Exit Sub
        End If
        If Not pageList(Tabs.SelectedIndex).cp.isSubscribed Then
            Exit Sub
        End If
        cp.needRePaintingQuotes = False
        cp.needRePaintingTrades = False
        If (pageList(index).Chart.SelectedIndex = 0) Then
            cp.paintingQuotes(pageList(index).QuotesPctBox, pageList(index).TimesQuotesPctBox, pageList(index).PricesQuotesPctBox)
        Else
            If (TicksOrSeconds.SelectedItem = "Тики") Then
                cp.paintingTrades(pageList(index).TradesPctBox, pageList(index).TimesTradesPctBox, pageList(index).PricesTradesPctBox, pageList(index).VolumesTradesPctBox, pageList(index).VolumesVolumesTradesPctBox)
            Else
                CaseN_AndDraw()
            End If
        End If

    End Sub

    Private Sub VolumesTradesPctBox_MouseMove(sender As Object, e As MouseEventArgs) Handles VolumesTradesPctBox0.MouseMove
        If (pageList.Count = 0) Then
            Exit Sub
        End If
        pageList(Tabs.SelectedIndex).cp.pointMouseMoveVolumes.X = e.X
        pageList(Tabs.SelectedIndex).cp.pointMouseMoveVolumes.Y = e.Y
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        If (TicksOrSeconds.SelectedItem = "Тики") Then
            If (cp.isSubscribed And Not cp.intervalTrades = 0) Then
                Dim proportion As Double = cp.yRangeVolumesTrades - (e.Y / pageList(index).VolumesTradesPctBox.Height) * cp.yRangeVolumesTrades
                cp.currentVolumeMM = Format(proportion, "0.00")
                paintTrades(index)
            End If
        Else
            If (cp.isSubscribed And Not cp.intervalTradesNsec = 0) Then
                Dim proportion As Double = cp.yRangeVolumesTradesNsec - (e.Y / pageList(index).VolumesTradesPctBox.Height) * cp.yRangeVolumesTradesNsec
                cp.currentVolumeMM = Format(proportion, "0.00")
                paintTradesNsec(index)
            End If
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles AddTab.Click
        Dim QuotesPctBox = New PictureBox()
        Dim PricesQuotesPctBox = New PictureBox()
        Dim TimesQuotesPctBox = New PictureBox()
        Dim TradesPctBox = New PictureBox()
        Dim PricesTradesPctBox = New PictureBox()
        Dim TimesTradesPctBox = New PictureBox()
        Dim VolumesTradesPctBox = New PictureBox()
        Dim VolumesVolumesTradesPctBox = New PictureBox()
        Dim BorderPctBox = New PictureBox()
        Dim LeftQuotesButton = New Button()
        Dim RightQuotesButton = New Button()
        Dim PlusQuotesButton = New Button()
        Dim MinusQuotesButton = New Button()
        Dim LeftTradesButton = New Button()
        Dim RightTradesButton = New Button()
        Dim PlusTradesButton = New Button()
        Dim MinusTradesButton = New Button()
        Dim Charts = New TabControl()
        Dim TabPage = New TabPage()
        Dim QuotesTab = New TabPage()
        Dim TradesTab = New TabPage()

        TabPage.Controls.Add(Charts)
        TabPage.Location = New System.Drawing.Point(4, 25)
        TabPage.Name = "TabPage"
        TabPage.Padding = New System.Windows.Forms.Padding(3)
        TabPage.Size = New System.Drawing.Size(1709, 845)
        TabPage.TabIndex = 0
        TabPage.Text = "TabPage"
        TabPage.UseVisualStyleBackColor = True
        Tabs.Controls.Add(TabPage)

        Charts.Location = New System.Drawing.Point(3, 6)
        Charts.Name = "Charts"
        Charts.SelectedIndex = 0
        Charts.Size = New System.Drawing.Size(1270, 650)
        Charts.TabIndex = 30
        PricesQuotesPctBox.Location = New System.Drawing.Point(2, 2)
        PricesQuotesPctBox.Name = "PricesQuotesPctBox"
        PricesQuotesPctBox.Size = New System.Drawing.Size(79, 545)
        PricesQuotesPctBox.TabIndex = 20
        PricesQuotesPctBox.TabStop = False
        '
        'MinusQuotesButton0
        '
        MinusQuotesButton.Location = New System.Drawing.Point(1225, 268)
        MinusQuotesButton.Name = "MinusQuotesButton"
        MinusQuotesButton.Size = New System.Drawing.Size(34, 265)
        MinusQuotesButton.TabIndex = 29
        MinusQuotesButton.Text = "-"
        MinusQuotesButton.UseVisualStyleBackColor = True
        '
        'QuotesPctBox0
        '
        QuotesPctBox.Location = New System.Drawing.Point(82, 2)
        'QuotesPctBox.BackColor = Color.Gray
        QuotesPctBox.Name = "QuotesPctBox"
        QuotesPctBox.Size = New System.Drawing.Size(1177, 575)
        QuotesPctBox.TabIndex = 18
        QuotesPctBox.TabStop = False
        '
        'PlusQuotesButton0
        '
        PlusQuotesButton.Location = New System.Drawing.Point(1225, 2)
        PlusQuotesButton.Name = "PlusQuotesButton"
        PlusQuotesButton.Size = New System.Drawing.Size(34, 260)
        PlusQuotesButton.TabIndex = 28
        PlusQuotesButton.Text = "+"
        PlusQuotesButton.UseVisualStyleBackColor = True
        '
        'RightQuotesButton0
        '
        RightQuotesButton.Location = New System.Drawing.Point(655, 595)
        RightQuotesButton.Name = "RightQuotesButton"
        RightQuotesButton.Size = New System.Drawing.Size(570, 27)
        RightQuotesButton.TabIndex = 27
        RightQuotesButton.Text = "Right ->"
        RightQuotesButton.UseVisualStyleBackColor = True
        '
        'LeftQuotesButton0
        '
        LeftQuotesButton.Location = New System.Drawing.Point(80, 595)
        LeftQuotesButton.Name = "LeftQuotesButton"
        LeftQuotesButton.Size = New System.Drawing.Size(570, 27)
        LeftQuotesButton.TabIndex = 26
        LeftQuotesButton.Text = "<- Left"
        LeftQuotesButton.UseVisualStyleBackColor = True
        '
        'TimesQuotesPctBox0
        '
        TimesQuotesPctBox.Location = New System.Drawing.Point(82, 579)
        TimesQuotesPctBox.Name = "TimesQuotesPctBox"
        TimesQuotesPctBox.Size = New System.Drawing.Size(1177, 36)
        TimesQuotesPctBox.TabIndex = 22
        TimesQuotesPctBox.TabStop = False
        '
        'VolumesVolumesTradesPctBox0
        '
        VolumesVolumesTradesPctBox.Location = New System.Drawing.Point(2, 350)
        VolumesVolumesTradesPctBox.Name = "VolumesVolumesTradesPctBox"
        VolumesVolumesTradesPctBox.Size = New System.Drawing.Size(79, 225)
        VolumesVolumesTradesPctBox.TabIndex = 39
        VolumesVolumesTradesPctBox.TabStop = False
        '
        'VolumesTradesPctBox0
        '
        VolumesTradesPctBox.Location = New System.Drawing.Point(82, 350)
        VolumesTradesPctBox.Name = "VolumesTradesPctBox"
        VolumesTradesPctBox.Size = New System.Drawing.Size(1177, 225)
        VolumesTradesPctBox.TabIndex = 38
        VolumesTradesPctBox.TabStop = False
        '
        'PricesTradesPctBox0
        '
        PricesTradesPctBox.Location = New System.Drawing.Point(2, 2)
        PricesTradesPctBox.Name = "PricesTradesPctBox"
        PricesTradesPctBox.Size = New System.Drawing.Size(79, 342)
        PricesTradesPctBox.TabIndex = 37
        PricesTradesPctBox.TabStop = False
        '
        'MinusTradesButton0
        '
        MinusTradesButton.Location = New System.Drawing.Point(1225, 268)
        MinusTradesButton.Name = "MinusTradesButton"
        MinusTradesButton.Size = New System.Drawing.Size(34, 265)
        MinusTradesButton.TabIndex = 29
        MinusTradesButton.Text = "-"
        MinusTradesButton.UseVisualStyleBackColor = True
        '
        'TradesPctBox0
        '
        TradesPctBox.Location = New System.Drawing.Point(82, 2)
        TradesPctBox.Name = "TradesPctBox"
        TradesPctBox.Size = New System.Drawing.Size(1177, 342)
        TradesPctBox.TabIndex = 30
        TradesPctBox.TabStop = False
        '
        'PlusTradesButton0
        '
        PlusTradesButton.Location = New System.Drawing.Point(1225, 2)
        PlusTradesButton.Name = "PlusTradesButton"
        PlusTradesButton.Size = New System.Drawing.Size(34, 260)
        PlusTradesButton.Text = "+"
        PlusTradesButton.UseVisualStyleBackColor = True
        '
        'RightButtonTrades0
        '
        RightTradesButton.Location = New System.Drawing.Point(655, 595)
        RightTradesButton.Name = "RightTradesButton"
        RightTradesButton.Size = New System.Drawing.Size(570, 27)
        RightTradesButton.TabIndex = 27
        RightTradesButton.Text = "Right ->"
        RightTradesButton.UseVisualStyleBackColor = True
        '
        'LeftTradesButton0
        '
        LeftTradesButton.Location = New System.Drawing.Point(80, 595)
        LeftTradesButton.Name = "LeftTradesButton"
        LeftTradesButton.Size = New System.Drawing.Size(570, 27)
        LeftTradesButton.TabIndex = 26
        LeftTradesButton.Text = "<- Left"
        LeftTradesButton.UseVisualStyleBackColor = True
        '
        'TimesTradesPctBox0
        '
        TimesTradesPctBox.Location = New System.Drawing.Point(82, 579)
        TimesTradesPctBox.Name = "TimesTradesPctBox"
        TimesTradesPctBox.Size = New System.Drawing.Size(1177, 36)
        TimesTradesPctBox.TabIndex = 22
        TimesTradesPctBox.TabStop = False
        '
        'BorderPctBox
        '
        BorderPctBox.BackColor = System.Drawing.Color.LightGray
        BorderPctBox.Location = New System.Drawing.Point(82, 344)
        BorderPctBox.Name = "BorderPctBox"
        BorderPctBox.Size = New System.Drawing.Size(1574, 5)
        BorderPctBox.TabIndex = 40
        BorderPctBox.TabStop = False

        QuotesTab.Controls.Add(PricesQuotesPctBox)
        QuotesTab.Controls.Add(MinusQuotesButton)
        QuotesTab.Controls.Add(QuotesPctBox)
        QuotesTab.Controls.Add(PlusQuotesButton)
        QuotesTab.Controls.Add(RightQuotesButton)
        QuotesTab.Controls.Add(LeftQuotesButton)
        QuotesTab.Controls.Add(TimesQuotesPctBox)
        QuotesTab.Location = New System.Drawing.Point(4, 25)
        QuotesTab.Name = "QuotesTab"
        QuotesTab.Padding = New System.Windows.Forms.Padding(3)
        QuotesTab.Size = New System.Drawing.Size(1689, 772)
        QuotesTab.Text = "Аск / Бид"
        QuotesTab.UseVisualStyleBackColor = True
        '
        'TradesTab0
        '
        TradesTab.Controls.Add(VolumesVolumesTradesPctBox)
        TradesTab.Controls.Add(VolumesTradesPctBox)
        TradesTab.Controls.Add(PricesTradesPctBox)
        TradesTab.Controls.Add(MinusTradesButton)
        TradesTab.Controls.Add(TradesPctBox)
        TradesTab.Controls.Add(PlusTradesButton)
        TradesTab.Controls.Add(RightTradesButton)
        TradesTab.Controls.Add(LeftTradesButton)
        TradesTab.Controls.Add(TimesTradesPctBox)
        TradesTab.Controls.Add(BorderPctBox)
        TradesTab.Location = New System.Drawing.Point(4, 25)
        TradesTab.Name = "TradesTab"
        TradesTab.Padding = New System.Windows.Forms.Padding(3)
        TradesTab.Size = New System.Drawing.Size(1689, 772)
        TradesTab.TabIndex = 1
        TradesTab.Text = "Сделки"
        TradesTab.UseVisualStyleBackColor = True

        Charts.Controls.Add(QuotesTab)
        Charts.Controls.Add(TradesTab)

        AddHandler LeftQuotesButton.Click, AddressOf Me.LeftQuotesButton_Click
        AddHandler RightQuotesButton.Click, AddressOf Me.RightQuotesButton_Click
        AddHandler PlusQuotesButton.Click, AddressOf Me.PlusQuotesButton_Click
        AddHandler MinusQuotesButton.Click, AddressOf Me.MinusQuotesButton_Click
        AddHandler LeftTradesButton.Click, AddressOf Me.LeftTradesButton_Click
        AddHandler RightTradesButton.Click, AddressOf Me.RightTradesButton_Click
        AddHandler TradesPctBox.MouseMove, AddressOf Me.TradesPctBox_MouseMove
        AddHandler QuotesPctBox.MouseMove, AddressOf Me.QuotesPctBox_MouseMove
        AddHandler VolumesTradesPctBox.MouseMove, AddressOf Me.VolumesTradesPctBox_MouseMove
        AddHandler Charts.SelectedIndexChanged, AddressOf Me.Charts0_SelectedIndexChanged
        AddHandler TradesPctBox.MouseDown, AddressOf Me.TradesPctBox0_MouseDown
        AddHandler TradesPctBox.MouseUp, AddressOf Me.TradesPctBox0_MouseUp
        AddHandler TradesPctBox.MouseEnter, AddressOf Me.TradesPctBox0_MouseEnter
        AddHandler TradesPctBox.MouseLeave, AddressOf Me.TradesPctBox0_MouseLeave
        AddHandler VolumesTradesPctBox.MouseEnter, AddressOf Me.VolumesTradesPctBox0_MouseEnter
        AddHandler VolumesTradesPctBox.MouseLeave, AddressOf Me.VolumesTradesPctBox0_MouseLeave
        AddHandler QuotesPctBox.MouseEnter, AddressOf Me.QuotesPctBox0_MouseEnter
        AddHandler QuotesPctBox.MouseLeave, AddressOf Me.QuotesPctBox0_MouseLeave
        AddHandler QuotesPctBox.MouseDown, AddressOf Me.QuotesPctBox0_MouseDown
        AddHandler QuotesPctBox.MouseUp, AddressOf Me.QuotesPctBox0_MouseUp

        MinusQuotesButton.Hide()
        MinusTradesButton.Hide()
        PlusQuotesButton.Hide()
        PlusTradesButton.Hide()
        RightTradesButton.Hide()
        RightQuotesButton.Hide()
        LeftQuotesButton.Hide()
        LeftTradesButton.Hide()

        Dim newPage = New Page(New ChartPainting(Me, TradesPctBox0, TimesTradesPctBox0, PricesTradesPctBox0, VolumesTradesPctBox0, VolumesVolumesTradesPctBox0),
                               QuotesPctBox,
                               PricesQuotesPctBox,
                               TimesQuotesPctBox,
                               TradesPctBox,
                               PricesTradesPctBox,
                               TimesTradesPctBox,
                               LeftQuotesButton,
                               RightQuotesButton,
                               PlusQuotesButton,
                               MinusQuotesButton,
                               LeftTradesButton,
                               RightTradesButton,
                               PlusTradesButton,
                               MinusTradesButton,
                               Charts,
                               VolumesTradesPctBox,
                               VolumesVolumesTradesPctBox,
                               WindowSizeTextBox.Text)
        pageList.Add(newPage)
    End Sub

    Private Sub TicksOrSeconds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TicksOrSeconds.SelectedIndexChanged
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        If (TicksOrSeconds.SelectedItem = "Тики") Then
            cp.currentPointTrades = cp.pointsTrades.Count - cp.pointsOnScreenTrades - 1
            If cp.currentPointTrades < 0 Then
                cp.currentPointTrades = 0
            End If
            cp.needRePaintingTrades = True
            cp.paintingTrades(pageList(index).TradesPctBox, pageList(index).TimesTradesPctBox, pageList(index).PricesTradesPctBox, pageList(index).VolumesTradesPctBox, pageList(index).VolumesVolumesTradesPctBox)
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
        If pageList.Count = 0 Then
            Exit Sub
        End If
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        If (pageList(index).Chart.SelectedIndex = 1) Then
            If (Not TicksOrSeconds.SelectedItem = "Тики") Then
                paintTradesNsec(index)
            End If
        End If
    End Sub

    Private Sub Charts0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Charts0.SelectedIndexChanged
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        If (pageList(index).Chart.SelectedIndex = 0) Then
            cp.currentPointQuotes = cp.pointsQuotes.Count - cp.pointsOnScreenQuotes - 1
            If cp.currentPointQuotes < 0 Then
                cp.currentPointQuotes = 0
            End If
            cp.needRePaintingQuotes = True
            cp.paintingQuotes(pageList(index).QuotesPctBox, pageList(index).TimesQuotesPctBox, pageList(index).PricesQuotesPctBox)
        Else
            TicksOrSeconds_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CopyTradesNsec(pointsTradesNsec As List(Of PointTradesNsec), clonedPointsTradesNsec As List(Of PointTradesNsec))
        For index = 0 To pointsTradesNsec.Count - 1
            Dim newPoint As New PointTradesNsec()
            newPoint.openPrice = pointsTradesNsec(index).openPrice
            newPoint.closePrice = pointsTradesNsec(index).closePrice
            newPoint.highPrice = pointsTradesNsec(index).highPrice
            newPoint.lowPrice = pointsTradesNsec(index).lowPrice
            newPoint.volumeBuy = pointsTradesNsec(index).volumeBuy
            newPoint.volumeSell = pointsTradesNsec(index).volumeSell
            newPoint.time = pointsTradesNsec(index).time
            newPoint.avgBuy = pointsTradesNsec(index).avgBuy
            newPoint.avgSell = pointsTradesNsec(index).avgSell
            newPoint.avgBuyPlusSell = pointsTradesNsec(index).avgBuyPlusSell
            clonedPointsTradesNsec.Add(newPoint)
        Next
    End Sub

    Private Sub AddWindowButton_Click(sender As Object, e As EventArgs) Handles AddWindowButton.Click
        Dim cloneForm As Form1Clone = New Form1Clone()
        cloneForm.isOnline = Me.isOnline
        cloneForm.QuotesPctBox = cloneForm.QuotesPctBox0
        cloneForm.PricesQuotesPctBox = cloneForm.PricesQuotesPctBox0
        cloneForm.TimesQuotesPctBox = cloneForm.TimesQuotesPctBox0
        cloneForm.TradesPctBox = cloneForm.TradesPctBox0
        cloneForm.PricesTradesPctBox = cloneForm.PricesTradesPctBox0
        cloneForm.TimesTradesPctBox = cloneForm.TimesTradesPctBox0
        cloneForm.LeftQuotesButton = cloneForm.LeftQuotesButton0
        cloneForm.RightQuotesButton = cloneForm.RightQuotesButton0
        cloneForm.PlusQuotesButton = cloneForm.PlusQuotesButton0
        cloneForm.MinusQuotesButton = cloneForm.MinusQuotesButton0
        cloneForm.LeftTradesButton = cloneForm.LeftTradesButton0
        cloneForm.RightTradesButton = cloneForm.RightButtonTrades0
        cloneForm.PlusTradesButton = cloneForm.PlusTradesButton0
        cloneForm.MinusTradesButton = cloneForm.MinusTradesButton0
        cloneForm.Chart = cloneForm.Charts0
        cloneForm.VolumesTradesPctBox = cloneForm.VolumesTradesPctBox0
        cloneForm.VolumesVolumesTradesPctBox = cloneForm.VolumesVolumesTradesPctBox0
        cloneForm.cp = New ChartPainting(cloneForm, cloneForm.TradesPctBox, cloneForm.TimesTradesPctBox, cloneForm.PricesTradesPctBox, cloneForm.VolumesTradesPctBox, cloneForm.VolumesVolumesTradesPctBox)
        cloneForm.cp.isCloned = True
        If (Not isOnline) Then
            cloneForm.cp.pointsTrades5sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades5sec
            cloneForm.cp.pointsTrades10sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades10sec
            cloneForm.cp.pointsTrades15sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades15sec
            cloneForm.cp.pointsTrades30sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades30sec
            cloneForm.cp.pointsTrades60sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades60sec
            cloneForm.cp.pointsTrades300sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades300sec
            cloneForm.cp.pointsTrades600sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades600sec
            cloneForm.cp.pointsTrades900sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades900sec
            cloneForm.cp.pointsTrades1800sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades1800sec
            cloneForm.cp.pointsTrades3600sec = Me.pageList(Tabs.SelectedIndex).cp.pointsTrades3600sec
        Else
            With cloneForm
                Dim clonedPointsTrades5sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades10sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades15sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades30sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades60sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades300sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades600sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades900sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades1800sec As New List(Of PointTradesNsec)
                Dim clonedPointsTrades3600sec As New List(Of PointTradesNsec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades5sec, clonedPointsTrades5sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades10sec, clonedPointsTrades10sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades15sec, clonedPointsTrades15sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades30sec, clonedPointsTrades30sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades60sec, clonedPointsTrades60sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades300sec, clonedPointsTrades300sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades600sec, clonedPointsTrades600sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades900sec, clonedPointsTrades900sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades1800sec, clonedPointsTrades1800sec)
                CopyTradesNsec(Me.pageList(Tabs.SelectedIndex).cp.pointsTrades3600sec, clonedPointsTrades3600sec)
                cloneForm.cp.pointsTrades5sec = clonedPointsTrades5sec
                cloneForm.cp.pointsTrades10sec = clonedPointsTrades10sec
                cloneForm.cp.pointsTrades15sec = clonedPointsTrades15sec
                cloneForm.cp.pointsTrades30sec = clonedPointsTrades30sec
                cloneForm.cp.pointsTrades60sec = clonedPointsTrades60sec
                cloneForm.cp.pointsTrades300sec = clonedPointsTrades300sec
                cloneForm.cp.pointsTrades600sec = clonedPointsTrades600sec
                cloneForm.cp.pointsTrades900sec = clonedPointsTrades900sec
                cloneForm.cp.pointsTrades1800sec = clonedPointsTrades1800sec
                cloneForm.cp.pointsTrades3600sec = clonedPointsTrades3600sec
            End With
        End If
        cloneForm.Show()
        pageList(Tabs.SelectedIndex).listOfClonedForms.Add(cloneForm)
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
        pageList(Tabs.SelectedIndex).movingAvgBuy = New MovingAverage(WindowSizeTextBox.Text)
        pageList(Tabs.SelectedIndex).movingAvgSell = New MovingAverage(WindowSizeTextBox.Text)
        pageList(Tabs.SelectedIndex).movingAvgBuyPlusSell = New MovingAverage(WindowSizeTextBox.Text)
        pageList(Tabs.SelectedIndex).ReCalculateMovingAverage()
        TypeOfGraphic_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub TradesPctBox0_MouseEnter(sender As Object, e As EventArgs) Handles TradesPctBox0.MouseEnter
        pageList(Tabs.SelectedIndex).cp.isCursorOnTradesChart = True
    End Sub

    Private Sub TradesPctBox0_MouseLeave(sender As Object, e As EventArgs) Handles TradesPctBox0.MouseLeave
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        cp.isCursorOnTradesChart = False
        If (Me.TicksOrSeconds.SelectedItem = "Тики") Then
            paintTrades(index)
        Else
            paintTradesNsec(index)
        End If
    End Sub

    Private Sub VolumesTradesPctBox0_MouseEnter(sender As Object, e As EventArgs) Handles VolumesTradesPctBox0.MouseEnter
        pageList(Tabs.SelectedIndex).cp.isCursorOnVolumesChart = True
    End Sub

    Private Sub VolumesTradesPctBox0_MouseLeave(sender As Object, e As EventArgs) Handles VolumesTradesPctBox0.MouseLeave
        pageList(Tabs.SelectedIndex).cp.isCursorOnVolumesChart = False
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
        pageList(Tabs.SelectedIndex).cp.isClickedTrades = False
    End Sub

    Private Sub TradesPctBox0_MouseDown(sender As Object, e As MouseEventArgs) Handles TradesPctBox0.MouseDown
        pageList(Tabs.SelectedIndex).cp.isClickedTrades = True
        pageList(Tabs.SelectedIndex).cp.positionOfClickTrades = New PointF(e.X, e.Y)
    End Sub

    Private Sub QuotesPctBox0_MouseUp(sender As Object, e As MouseEventArgs) Handles QuotesPctBox0.MouseUp
        pageList(Tabs.SelectedIndex).cp.isClickedQuotes = False
    End Sub

    Private Sub QuotesPctBox0_MouseDown(sender As Object, e As MouseEventArgs) Handles QuotesPctBox0.MouseDown
        pageList(Tabs.SelectedIndex).cp.isClickedQuotes = True
        pageList(Tabs.SelectedIndex).cp.positionOfClickQuotes = New PointF(e.X, e.Y)
    End Sub

    Private Sub QuotesPctBox0_MouseEnter(sender As Object, e As EventArgs) Handles QuotesPctBox0.MouseEnter
        pageList(Tabs.SelectedIndex).cp.isCursorOnQuotesChart = True
    End Sub

    Private Sub QuotesPctBox0_MouseLeave(sender As Object, e As EventArgs) Handles QuotesPctBox0.MouseLeave
        Dim index = Tabs.SelectedIndex
        Dim cp = pageList(index).cp
        cp.isCursorOnQuotesChart = False
        If (cp.needRePaintingQuotes = False) Then
            cp.paintingQuotes(pageList(index).QuotesPctBox, pageList(index).TimesQuotesPctBox, pageList(index).PricesQuotesPctBox)
        Else
            cp.needRePaintingQuotes = False
            cp.paintingQuotes(pageList(index).QuotesPctBox, pageList(index).TimesQuotesPctBox, pageList(index).PricesQuotesPctBox)
            cp.needRePaintingQuotes = True
        End If
    End Sub

    Private Sub SetSensitivityButton_Click(sender As Object, e As EventArgs) Handles SetSensitivityButton.Click
        Try
            Me.mouseSensitivity = SetSensitivityTextBox.Text
        Catch ex As Exception
            MsgBox("Ошибка при попытке изменения чувствительности мыши. Необходимо ввести целое число")
        End Try
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Not Me.canResize Then
            Exit Sub
        End If

        If Me.WindowState <> lastWindowState And Me.WindowState <> FormWindowState.Minimized Then
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

    Private Sub BuyOrderButton_Click(sender As Object, e As EventArgs) Handles BuyOrderButton.Click
        orderExecutor.PlaceOrder(New OrderInfo(Tabs.SelectedTab.Text, OrderInfo.OrderSide.BUY, Double.Parse(QuantityTextBox.Text), OrderInfo.OrderType.MARKET, OrderInfo.OrderTimeInForce.GTC))
        RefreshButton_Click(sender, e)
    End Sub

    Private Sub SellOrderButton_Click(sender As Object, e As EventArgs) Handles SellOrderButton.Click
        orderExecutor.PlaceOrder(New OrderInfo(Tabs.SelectedTab.Text, OrderInfo.OrderSide.SELL, Double.Parse(QuantityTextBox.Text), OrderInfo.OrderType.MARKET, OrderInfo.OrderTimeInForce.GTC))
        RefreshButton_Click(sender, e)
    End Sub

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        ListViewOrders.Invoke(Sub()
                                  ListViewOrders.Items.Clear()
                                  orderExecutor.UpdatePositionsInfo()
                              End Sub)
    End Sub
End Class
