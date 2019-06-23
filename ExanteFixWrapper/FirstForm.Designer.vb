<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FirstForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.OnlineRB = New System.Windows.Forms.RadioButton()
        Me.OfflaneRB = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(45, 98)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(161, 59)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "OK"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'OnlineRB
        '
        Me.OnlineRB.AutoSize = True
        Me.OnlineRB.Location = New System.Drawing.Point(12, 54)
        Me.OnlineRB.Name = "OnlineRB"
        Me.OnlineRB.Size = New System.Drawing.Size(70, 21)
        Me.OnlineRB.TabIndex = 1
        Me.OnlineRB.Text = "Online"
        Me.OnlineRB.UseVisualStyleBackColor = True
        '
        'OfflaneRB
        '
        Me.OfflaneRB.AutoSize = True
        Me.OfflaneRB.Location = New System.Drawing.Point(172, 54)
        Me.OfflaneRB.Name = "OfflaneRB"
        Me.OfflaneRB.Size = New System.Drawing.Size(70, 21)
        Me.OfflaneRB.TabIndex = 2
        Me.OfflaneRB.Text = "Offline"
        Me.OfflaneRB.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Выберите режим работы"
        '
        'FirstForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 178)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OfflaneRB)
        Me.Controls.Add(Me.OnlineRB)
        Me.Controls.Add(Me.StartButton)
        Me.Name = "FirstForm"
        Me.Text = "Запуск"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StartButton As Button
    Friend WithEvents OnlineRB As RadioButton
    Friend WithEvents OfflaneRB As RadioButton
    Friend WithEvents Label1 As Label
End Class
