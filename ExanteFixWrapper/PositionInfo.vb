Public Class PositionInfo
    Public Instrument As String
    Public Position As Double
    Public AvgPrice As Double
    Public ProfitAndLoss As Double
    Public Function ConvertToListViewItem() As ListViewItem
        Return New ListViewItem(New String() {Me.Instrument, Me.Position, Me.AvgPrice, Me.ProfitAndLoss})
    End Function
End Class
