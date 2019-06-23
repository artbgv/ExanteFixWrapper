Public Class SubscribeInfo
    Public Delegate Sub UpdateQuoteCourseCallBack(quotesinfo As QuotesInfo)
    Public Guid As Guid
    Public ExanteId As String
    Public UpdateQuotesCallback As UpdateQuoteCourseCallBack
    Public Sub New(exanteID As String, callback As UpdateQuoteCourseCallBack)
        Me.UpdateQuotesCallback = callback
        Me.Guid = System.Guid.NewGuid()
        Me.ExanteId = exanteID
    End Sub

End Class
