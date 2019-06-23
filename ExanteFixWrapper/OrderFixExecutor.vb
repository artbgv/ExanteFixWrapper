Imports System.Threading
Imports QuickFix
Imports QuickFix44

Public Class OrderFixExecutor
    Dim initiator As SocketInitiator
    Dim settings As SessionSettings
    Dim application As QuickFIXBrokerApplication
    Dim activeOrders As Dictionary(Of String, OrderInfo)
    Dim currentState As Boolean
    Delegate Sub UpdateConnectionStateCallBack(State As Boolean)
    Delegate Sub PositionStateCallbackFIX(position As PositionInfo)

    Public updateConnStateCallback As UpdateConnectionStateCallBack
    Public positionStateCallback As PositionStateCallbackFIX
    Dim updateConnStatusThread As Thread
    Public Sub New(fixFeedConfigPath As String, updStateCallback As UpdateConnectionStateCallBack, positionStateCallback As PositionStateCallbackFIX)
        currentState = False
        Try
            settings = New SessionSettings(fixFeedConfigPath)
            Dim sessions As ArrayList = settings.getSessions()
            Dim dict As QuickFix.Dictionary = settings.get(CType(sessions(0), QuickFix.SessionID))
            Dim fixBrokerPass As String = dict.getString("password")
            Dim storeFactory As FileStoreFactory = New FileStoreFactory(settings)
            application = New QuickFIXBrokerApplication(fixBrokerPass, AddressOf UpdateOrder, AddressOf GetPositionsInfo)
            Dim logFactory As FileLogFactory = New FileLogFactory(settings)
            Dim messageFactory As QuickFix.MessageFactory = New DefaultMessageFactory()
            initiator = New SocketInitiator(application, storeFactory, settings, logFactory, messageFactory)
            initiator.start()
            updateConnStateCallback = updStateCallback
            If updateConnStateCallback <> Nothing Then
                updateConnStatusThread = New Thread(AddressOf CheckingConnectonState)
                updateConnStatusThread.Start()
            End If
            Me.PositionStateCallback = positionStateCallback
            activeOrders = New Dictionary(Of String, OrderInfo)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub PlaceOrder(order As OrderInfo)
        activeOrders(order.ClientOrderID) = order
        Dim clientOrderID As ClOrdID = New ClOrdID(order.ClientOrderID)
        Dim orderSide As Side = If(order.Side = OrderInfo.OrderSide.BUY, New Side(Side.BUY), New Side(Side.SELL))
        Dim placeOrder As NewOrderSingle = New NewOrderSingle(clientOrderID, orderSide, New TransactTime(order.OrderDateTime), New OrdType(OrdType.MARKET))
        placeOrder.set(New TimeInForce(TimeInForce.GOOD_TILL_CANCEL))
        placeOrder.set(New OrderQty(order.OrderQuantity))
        placeOrder.set(New Symbol(order.Instrument))
        placeOrder.set(New SecurityID(order.Instrument))
        placeOrder.set(New SecurityIDSource("111"))
        QuickFix.Session.sendToTarget(placeOrder, initiator.getSessions(0))
        'updateOrderStateCallback.Invoke(order)
    End Sub
    Public Sub UpdatePositionsInfo()
        Dim message As QuickFix44.Message = New QuickFix44.Message(New MsgType("UASQ"))
        message.setString(20020, System.Guid.NewGuid().ToString())
        Session.sendToTarget(message, initiator.getSessions(0))
    End Sub
    Public Sub Logout()
        Try
            updateConnStatusThread.Abort()
            updateConnStatusThread.Join()
            updateConnStatusThread = Nothing
        Catch ex As Exception
            Console.WriteLine("Logout errors")
        End Try
    End Sub
    Public Sub CheckingConnectonState()
        While True
            Thread.Sleep(1000)
            If isConnected() <> currentState Then
                currentState = isConnected()
                If updateConnStatusThread IsNot Nothing Then
                    updateConnStateCallback.Invoke(currentState)
                Else
                    Exit While
                End If
            End If
        End While
    End Sub
    Public Function isConnected() As Boolean
        If (initiator Is Nothing) Then
            Return False
        End If
        Return initiator.isLoggedOn
    End Function
    Private Sub UpdateOrder(message As QuickFix.Message)
        Dim orderStatus As OrdStatus = New OrdStatus
        Dim parsedOrderStatus As OrderInfo.OrderStatus
        message.getField(orderStatus)
        Select Case orderStatus.getValue()
            Case "0"
                parsedOrderStatus = OrderInfo.OrderStatus.NEWORDER
            Case "1"
                parsedOrderStatus = OrderInfo.OrderStatus.PARTIALLY_FILLED
            Case "2"
                parsedOrderStatus = OrderInfo.OrderStatus.FILLED
            Case "4"
                parsedOrderStatus = OrderInfo.OrderStatus.CANCELED
            Case "6"
                parsedOrderStatus = OrderInfo.OrderStatus.PENDING_CANCEL
            Case "8"
                parsedOrderStatus = OrderInfo.OrderStatus.REJECTED
            Case "A"
                parsedOrderStatus = OrderInfo.OrderStatus.PENDING_NEW
        End Select
        Dim ClientOrderID As ClOrdID = New ClOrdID()
        message.getField(ClientOrderID)
        If activeOrders.ContainsKey(ClientOrderID.getValue()) Then
            activeOrders(ClientOrderID.getValue()).Status = parsedOrderStatus
        End If
        Dim order = activeOrders(ClientOrderID.getValue())
        Console.WriteLine("Client Order ID: " + order.ClientOrderID + " " +
                         "Client Order ID: " + order.Instrument + " " +
                         "Client Order ID: " + order.OrderDateTime.ToString() + " " +
                         "Client Order ID: " + order.OrderQuantity.ToString() + " " +
                         "Client Order ID: " + order.Type.ToString() + " " +
                         "Client Order ID: " + order.Status.ToString())
        'updateOrderStateCallback.Invoke(activeOrders(ClientOrderID.getValue()))
    End Sub
    Private Sub GetPositionsInfo(message As QuickFix.Message)
        Console.WriteLine(message.ToString())
        Dim posInfo = New PositionInfo()
        Dim symbol = New SecurityID()
        posInfo.Instrument = message.getField(symbol).getValue()
        Dim positionFieldLong = New DoubleField(704)
        Dim positionFieldShort = New DoubleField(705)
        Dim posLong = message.getField(positionFieldLong)
        Dim posShort = message.getField(positionFieldShort)
        If posShort.getValue() = 0 Then
            posInfo.Position = posLong.getValue()
        Else
            posInfo.Position = -posShort.getValue()
        End If
        Dim avgPrice = New DoubleField(6)
        Dim profitAndLoss = New DoubleField(20030)
        Try
            posInfo.AvgPrice = message.getField(avgPrice).getValue()
            posInfo.ProfitAndLoss = message.getField(profitAndLoss).getValue()
        Catch ex As QuickFix.FieldNotFound
            posInfo.AvgPrice = 0.0
            posInfo.ProfitAndLoss = 0.0
        End Try
        positionStateCallback.Invoke(posInfo)
    End Sub

End Class
