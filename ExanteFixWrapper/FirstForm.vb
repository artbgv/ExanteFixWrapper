Public Class FirstForm
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If OnlineRB.Checked Then
            Form1.isOnline = True
        Else
            Form1.isOnline = False
        End If
        Form1.Show()
        Me.Close()
    End Sub
End Class