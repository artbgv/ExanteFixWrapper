Public Class OrderInfo
    Public OrderDateTime As DateTime
    Public ClientOrderID As String
    Public Instrument As String
    Public Side As OrderSide
    Public OrderQuantity As Double
    Public Type As OrderType
    Public TimeInForce As OrderTimeInForce
    Public Status As OrderStatus

    Public Sub New(instrument As String, side As OrderSide, orderQuantity As Double, type As OrderType, timeInForce As OrderTimeInForce)
        OrderDateTime = DateTime.Now
        ClientOrderID = System.Guid.NewGuid().ToString()
        Me.Instrument = instrument
        Me.Side = side
        Me.OrderQuantity = orderQuantity
        Me.Type = type
        Me.TimeInForce = timeInForce
        Me.Status = OrderStatus.NEWORDER
    End Sub
    Public Enum OrderSide As Integer
        BUY = 1
        SELL = 2
    End Enum
    Public Enum OrderType As Integer
        MARKET = 1
        LIMIT = 2
        STOPMARKET = 3
        STOPLIMIT = 4
    End Enum
    Public Enum OrderTimeInForce As Integer
        DAY = 0
        GTC = 1
    End Enum
    Public Enum OrderStatus As Integer
        NEWORDER = 0
        PARTIALLY_FILLED = 1
        FILLED = 2
        CANCELED = 3
        PENDING_CANCEL = 4
        REJECTED = 5
        PENDING_NEW = 6
    End Enum
End Class
