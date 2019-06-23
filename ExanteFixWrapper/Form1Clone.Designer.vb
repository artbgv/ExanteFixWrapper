<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1Clone
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DrawLineTrades0 = New System.Windows.Forms.Button()
        Me.DrawLineQuotes0 = New System.Windows.Forms.Button()
        Me.TimeLabel0 = New System.Windows.Forms.Label()
        Me.PriceLabel0 = New System.Windows.Forms.Label()
        Me.VolumeLabel = New System.Windows.Forms.Label()
        Me.CurVolumeLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AskPriceLabel = New System.Windows.Forms.Label()
        Me.BidPriceLabel = New System.Windows.Forms.Label()
        Me.TradeVolumeLabel = New System.Windows.Forms.Label()
        Me.TradePriceLabel = New System.Windows.Forms.Label()
        Me.TabPage0 = New System.Windows.Forms.TabPage()
        Me.Charts0 = New System.Windows.Forms.TabControl()
        Me.QuotesTab0 = New System.Windows.Forms.TabPage()
        Me.PricesQuotesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.MinusQuotesButton0 = New System.Windows.Forms.Button()
        Me.QuotesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.PlusQuotesButton0 = New System.Windows.Forms.Button()
        Me.RightQuotesButton0 = New System.Windows.Forms.Button()
        Me.LeftQuotesButton0 = New System.Windows.Forms.Button()
        Me.TimesQuotesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.TradesTab0 = New System.Windows.Forms.TabPage()
        Me.BorderPctBox = New System.Windows.Forms.PictureBox()
        Me.VolumesVolumesTradesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.VolumesTradesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.PricesTradesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.MinusTradesButton0 = New System.Windows.Forms.Button()
        Me.TradesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.PlusTradesButton0 = New System.Windows.Forms.Button()
        Me.RightButtonTrades0 = New System.Windows.Forms.Button()
        Me.LeftTradesButton0 = New System.Windows.Forms.Button()
        Me.TimesTradesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.TicksOrSeconds = New System.Windows.Forms.ComboBox()
        Me.TypeOfGraphic = New System.Windows.Forms.ComboBox()
        Me.BuyPlusSell = New System.Windows.Forms.RadioButton()
        Me.BuyAndSell = New System.Windows.Forms.RadioButton()
        Me.Average = New System.Windows.Forms.CheckBox()
        Me.Original = New System.Windows.Forms.CheckBox()
        Me.WindowSizeBtn = New System.Windows.Forms.Button()
        Me.WindowSizeTextBox = New System.Windows.Forms.TextBox()
        Me.TabPage0.SuspendLayout()
        Me.Charts0.SuspendLayout()
        Me.QuotesTab0.SuspendLayout()
        CType(Me.PricesQuotesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuotesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimesQuotesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TradesTab0.SuspendLayout()
        CType(Me.BorderPctBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VolumesVolumesTradesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VolumesTradesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PricesTradesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TradesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimesTradesPctBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'DrawLineTrades0
        '
        Me.DrawLineTrades0.Location = New System.Drawing.Point(1080, 6)
        Me.DrawLineTrades0.Margin = New System.Windows.Forms.Padding(2)
        Me.DrawLineTrades0.Name = "DrawLineTrades0"
        Me.DrawLineTrades0.Size = New System.Drawing.Size(159, 24)
        Me.DrawLineTrades0.TabIndex = 32
        Me.DrawLineTrades0.Text = "Рисовать линию (Сделки)"
        Me.DrawLineTrades0.UseVisualStyleBackColor = True
        '
        'DrawLineQuotes0
        '
        Me.DrawLineQuotes0.Location = New System.Drawing.Point(916, 6)
        Me.DrawLineQuotes0.Margin = New System.Windows.Forms.Padding(2)
        Me.DrawLineQuotes0.Name = "DrawLineQuotes0"
        Me.DrawLineQuotes0.Size = New System.Drawing.Size(159, 24)
        Me.DrawLineQuotes0.TabIndex = 31
        Me.DrawLineQuotes0.Text = "Рисовать линию (Аск / Бид)"
        Me.DrawLineQuotes0.UseVisualStyleBackColor = True
        '
        'TimeLabel0
        '
        Me.TimeLabel0.AutoSize = True
        Me.TimeLabel0.Location = New System.Drawing.Point(710, 25)
        Me.TimeLabel0.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TimeLabel0.Name = "TimeLabel0"
        Me.TimeLabel0.Size = New System.Drawing.Size(10, 13)
        Me.TimeLabel0.TabIndex = 25
        Me.TimeLabel0.Text = "-"
        '
        'PriceLabel0
        '
        Me.PriceLabel0.AutoSize = True
        Me.PriceLabel0.Location = New System.Drawing.Point(650, 25)
        Me.PriceLabel0.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.PriceLabel0.Name = "PriceLabel0"
        Me.PriceLabel0.Size = New System.Drawing.Size(10, 13)
        Me.PriceLabel0.TabIndex = 24
        Me.PriceLabel0.Text = "-"
        '
        'VolumeLabel
        '
        Me.VolumeLabel.AutoSize = True
        Me.VolumeLabel.Location = New System.Drawing.Point(764, 25)
        Me.VolumeLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.VolumeLabel.Name = "VolumeLabel"
        Me.VolumeLabel.Size = New System.Drawing.Size(10, 13)
        Me.VolumeLabel.TabIndex = 33
        Me.VolumeLabel.Text = "-"
        '
        'CurVolumeLabel
        '
        Me.CurVolumeLabel.AutoSize = True
        Me.CurVolumeLabel.Location = New System.Drawing.Point(828, 25)
        Me.CurVolumeLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.CurVolumeLabel.Name = "CurVolumeLabel"
        Me.CurVolumeLabel.Size = New System.Drawing.Size(10, 13)
        Me.CurVolumeLabel.TabIndex = 34
        Me.CurVolumeLabel.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(828, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Cur Volume"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(764, 5)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Volume"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(710, 5)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(650, 5)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Price"
        '
        'AskPriceLabel
        '
        Me.AskPriceLabel.AutoSize = True
        Me.AskPriceLabel.ForeColor = System.Drawing.Color.Red
        Me.AskPriceLabel.Location = New System.Drawing.Point(924, 32)
        Me.AskPriceLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.AskPriceLabel.Name = "AskPriceLabel"
        Me.AskPriceLabel.Size = New System.Drawing.Size(10, 13)
        Me.AskPriceLabel.TabIndex = 39
        Me.AskPriceLabel.Text = "-"
        '
        'BidPriceLabel
        '
        Me.BidPriceLabel.AutoSize = True
        Me.BidPriceLabel.ForeColor = System.Drawing.Color.Blue
        Me.BidPriceLabel.Location = New System.Drawing.Point(1006, 32)
        Me.BidPriceLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.BidPriceLabel.Name = "BidPriceLabel"
        Me.BidPriceLabel.Size = New System.Drawing.Size(10, 13)
        Me.BidPriceLabel.TabIndex = 40
        Me.BidPriceLabel.Text = "-"
        '
        'TradeVolumeLabel
        '
        Me.TradeVolumeLabel.AutoSize = True
        Me.TradeVolumeLabel.ForeColor = System.Drawing.Color.Green
        Me.TradeVolumeLabel.Location = New System.Drawing.Point(1156, 32)
        Me.TradeVolumeLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TradeVolumeLabel.Name = "TradeVolumeLabel"
        Me.TradeVolumeLabel.Size = New System.Drawing.Size(10, 13)
        Me.TradeVolumeLabel.TabIndex = 42
        Me.TradeVolumeLabel.Text = "-"
        '
        'TradePriceLabel
        '
        Me.TradePriceLabel.AutoSize = True
        Me.TradePriceLabel.ForeColor = System.Drawing.Color.Red
        Me.TradePriceLabel.Location = New System.Drawing.Point(1086, 32)
        Me.TradePriceLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TradePriceLabel.Name = "TradePriceLabel"
        Me.TradePriceLabel.Size = New System.Drawing.Size(10, 13)
        Me.TradePriceLabel.TabIndex = 41
        Me.TradePriceLabel.Text = "-"
        '
        'TabPage0
        '
        Me.TabPage0.Controls.Add(Me.Charts0)
        Me.TabPage0.Location = New System.Drawing.Point(4, 22)
        Me.TabPage0.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage0.Name = "TabPage0"
        Me.TabPage0.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage0.Size = New System.Drawing.Size(1280, 684)
        Me.TabPage0.TabIndex = 0
        Me.TabPage0.Text = "TabPage0"
        Me.TabPage0.UseVisualStyleBackColor = True
        '
        'Charts0
        '
        Me.Charts0.Controls.Add(Me.QuotesTab0)
        Me.Charts0.Controls.Add(Me.TradesTab0)
        Me.Charts0.Location = New System.Drawing.Point(2, 5)
        Me.Charts0.Margin = New System.Windows.Forms.Padding(2)
        Me.Charts0.Name = "Charts0"
        Me.Charts0.SelectedIndex = 0
        Me.Charts0.Size = New System.Drawing.Size(1273, 651)
        Me.Charts0.TabIndex = 30
        '
        'QuotesTab0
        '
        Me.QuotesTab0.Controls.Add(Me.PricesQuotesPctBox0)
        Me.QuotesTab0.Controls.Add(Me.MinusQuotesButton0)
        Me.QuotesTab0.Controls.Add(Me.QuotesPctBox0)
        Me.QuotesTab0.Controls.Add(Me.PlusQuotesButton0)
        Me.QuotesTab0.Controls.Add(Me.RightQuotesButton0)
        Me.QuotesTab0.Controls.Add(Me.LeftQuotesButton0)
        Me.QuotesTab0.Controls.Add(Me.TimesQuotesPctBox0)
        Me.QuotesTab0.Location = New System.Drawing.Point(4, 22)
        Me.QuotesTab0.Margin = New System.Windows.Forms.Padding(2)
        Me.QuotesTab0.Name = "QuotesTab0"
        Me.QuotesTab0.Padding = New System.Windows.Forms.Padding(2)
        Me.QuotesTab0.Size = New System.Drawing.Size(1265, 625)
        Me.QuotesTab0.TabIndex = 0
        Me.QuotesTab0.Text = "Аск / Бид"
        Me.QuotesTab0.UseVisualStyleBackColor = True
        '
        'PricesQuotesPctBox0
        '
        Me.PricesQuotesPctBox0.Location = New System.Drawing.Point(2, 0)
        Me.PricesQuotesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.PricesQuotesPctBox0.Name = "PricesQuotesPctBox0"
        Me.PricesQuotesPctBox0.Size = New System.Drawing.Size(79, 557)
        Me.PricesQuotesPctBox0.TabIndex = 20
        Me.PricesQuotesPctBox0.TabStop = False
        '
        'MinusQuotesButton0
        '
        Me.MinusQuotesButton0.Location = New System.Drawing.Point(1226, 273)
        Me.MinusQuotesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.MinusQuotesButton0.Name = "MinusQuotesButton0"
        Me.MinusQuotesButton0.Size = New System.Drawing.Size(35, 258)
        Me.MinusQuotesButton0.TabIndex = 29
        Me.MinusQuotesButton0.Text = "-"
        Me.MinusQuotesButton0.UseVisualStyleBackColor = True
        '
        'QuotesPctBox0
        '
        Me.QuotesPctBox0.Location = New System.Drawing.Point(81, 0)
        Me.QuotesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.QuotesPctBox0.Name = "QuotesPctBox0"
        Me.QuotesPctBox0.Size = New System.Drawing.Size(1141, 557)
        Me.QuotesPctBox0.TabIndex = 18
        Me.QuotesPctBox0.TabStop = False
        '
        'PlusQuotesButton0
        '
        Me.PlusQuotesButton0.Location = New System.Drawing.Point(1226, 2)
        Me.PlusQuotesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.PlusQuotesButton0.Name = "PlusQuotesButton0"
        Me.PlusQuotesButton0.Size = New System.Drawing.Size(36, 266)
        Me.PlusQuotesButton0.TabIndex = 28
        Me.PlusQuotesButton0.Text = "+"
        Me.PlusQuotesButton0.UseVisualStyleBackColor = True
        '
        'RightQuotesButton0
        '
        Me.RightQuotesButton0.Location = New System.Drawing.Point(665, 596)
        Me.RightQuotesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.RightQuotesButton0.Name = "RightQuotesButton0"
        Me.RightQuotesButton0.Size = New System.Drawing.Size(556, 27)
        Me.RightQuotesButton0.TabIndex = 27
        Me.RightQuotesButton0.Text = "Right ->"
        Me.RightQuotesButton0.UseVisualStyleBackColor = True
        '
        'LeftQuotesButton0
        '
        Me.LeftQuotesButton0.Location = New System.Drawing.Point(81, 596)
        Me.LeftQuotesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.LeftQuotesButton0.Name = "LeftQuotesButton0"
        Me.LeftQuotesButton0.Size = New System.Drawing.Size(580, 27)
        Me.LeftQuotesButton0.TabIndex = 26
        Me.LeftQuotesButton0.Text = "<- Left"
        Me.LeftQuotesButton0.UseVisualStyleBackColor = True
        '
        'TimesQuotesPctBox0
        '
        Me.TimesQuotesPctBox0.Location = New System.Drawing.Point(81, 562)
        Me.TimesQuotesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.TimesQuotesPctBox0.Name = "TimesQuotesPctBox0"
        Me.TimesQuotesPctBox0.Size = New System.Drawing.Size(1141, 29)
        Me.TimesQuotesPctBox0.TabIndex = 22
        Me.TimesQuotesPctBox0.TabStop = False
        '
        'TradesTab0
        '
        Me.TradesTab0.Controls.Add(Me.BorderPctBox)
        Me.TradesTab0.Controls.Add(Me.VolumesVolumesTradesPctBox0)
        Me.TradesTab0.Controls.Add(Me.VolumesTradesPctBox0)
        Me.TradesTab0.Controls.Add(Me.PricesTradesPctBox0)
        Me.TradesTab0.Controls.Add(Me.MinusTradesButton0)
        Me.TradesTab0.Controls.Add(Me.TradesPctBox0)
        Me.TradesTab0.Controls.Add(Me.PlusTradesButton0)
        Me.TradesTab0.Controls.Add(Me.RightButtonTrades0)
        Me.TradesTab0.Controls.Add(Me.LeftTradesButton0)
        Me.TradesTab0.Controls.Add(Me.TimesTradesPctBox0)
        Me.TradesTab0.Location = New System.Drawing.Point(4, 22)
        Me.TradesTab0.Margin = New System.Windows.Forms.Padding(2)
        Me.TradesTab0.Name = "TradesTab0"
        Me.TradesTab0.Padding = New System.Windows.Forms.Padding(2)
        Me.TradesTab0.Size = New System.Drawing.Size(1265, 625)
        Me.TradesTab0.TabIndex = 1
        Me.TradesTab0.Text = "Сделки"
        Me.TradesTab0.UseVisualStyleBackColor = True
        '
        'BorderPctBox
        '
        Me.BorderPctBox.BackColor = System.Drawing.Color.LightGray
        Me.BorderPctBox.Location = New System.Drawing.Point(81, 344)
        Me.BorderPctBox.Margin = New System.Windows.Forms.Padding(2)
        Me.BorderPctBox.Name = "BorderPctBox"
        Me.BorderPctBox.Size = New System.Drawing.Size(1180, 4)
        Me.BorderPctBox.TabIndex = 41
        Me.BorderPctBox.TabStop = False
        '
        'VolumesVolumesTradesPctBox0
        '
        Me.VolumesVolumesTradesPctBox0.Location = New System.Drawing.Point(2, 350)
        Me.VolumesVolumesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.VolumesVolumesTradesPctBox0.Name = "VolumesVolumesTradesPctBox0"
        Me.VolumesVolumesTradesPctBox0.Size = New System.Drawing.Size(79, 243)
        Me.VolumesVolumesTradesPctBox0.TabIndex = 39
        Me.VolumesVolumesTradesPctBox0.TabStop = False
        '
        'VolumesTradesPctBox0
        '
        Me.VolumesTradesPctBox0.Location = New System.Drawing.Point(81, 349)
        Me.VolumesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.VolumesTradesPctBox0.Name = "VolumesTradesPctBox0"
        Me.VolumesTradesPctBox0.Size = New System.Drawing.Size(1185, 245)
        Me.VolumesTradesPctBox0.TabIndex = 38
        Me.VolumesTradesPctBox0.TabStop = False
        '
        'PricesTradesPctBox0
        '
        Me.PricesTradesPctBox0.Location = New System.Drawing.Point(2, 2)
        Me.PricesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.PricesTradesPctBox0.Name = "PricesTradesPctBox0"
        Me.PricesTradesPctBox0.Size = New System.Drawing.Size(79, 343)
        Me.PricesTradesPctBox0.TabIndex = 37
        Me.PricesTradesPctBox0.TabStop = False
        '
        'MinusTradesButton0
        '
        Me.MinusTradesButton0.Location = New System.Drawing.Point(1226, 287)
        Me.MinusTradesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.MinusTradesButton0.Name = "MinusTradesButton0"
        Me.MinusTradesButton0.Size = New System.Drawing.Size(35, 280)
        Me.MinusTradesButton0.TabIndex = 36
        Me.MinusTradesButton0.Text = "-"
        Me.MinusTradesButton0.UseVisualStyleBackColor = True
        '
        'TradesPctBox0
        '
        Me.TradesPctBox0.Location = New System.Drawing.Point(81, 0)
        Me.TradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.TradesPctBox0.Name = "TradesPctBox0"
        Me.TradesPctBox0.Size = New System.Drawing.Size(1180, 345)
        Me.TradesPctBox0.TabIndex = 30
        Me.TradesPctBox0.TabStop = False
        '
        'PlusTradesButton0
        '
        Me.PlusTradesButton0.Location = New System.Drawing.Point(1226, 5)
        Me.PlusTradesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.PlusTradesButton0.Name = "PlusTradesButton0"
        Me.PlusTradesButton0.Size = New System.Drawing.Size(36, 277)
        Me.PlusTradesButton0.TabIndex = 35
        Me.PlusTradesButton0.Text = "+"
        Me.PlusTradesButton0.UseVisualStyleBackColor = True
        '
        'RightButtonTrades0
        '
        Me.RightButtonTrades0.Location = New System.Drawing.Point(652, 596)
        Me.RightButtonTrades0.Margin = New System.Windows.Forms.Padding(2)
        Me.RightButtonTrades0.Name = "RightButtonTrades0"
        Me.RightButtonTrades0.Size = New System.Drawing.Size(569, 27)
        Me.RightButtonTrades0.TabIndex = 34
        Me.RightButtonTrades0.Text = "Right ->"
        Me.RightButtonTrades0.UseVisualStyleBackColor = True
        '
        'LeftTradesButton0
        '
        Me.LeftTradesButton0.Location = New System.Drawing.Point(81, 596)
        Me.LeftTradesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.LeftTradesButton0.Name = "LeftTradesButton0"
        Me.LeftTradesButton0.Size = New System.Drawing.Size(567, 27)
        Me.LeftTradesButton0.TabIndex = 33
        Me.LeftTradesButton0.Text = "<- Left"
        Me.LeftTradesButton0.UseVisualStyleBackColor = True
        '
        'TimesTradesPctBox0
        '
        Me.TimesTradesPctBox0.Location = New System.Drawing.Point(86, 594)
        Me.TimesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.TimesTradesPctBox0.Name = "TimesTradesPctBox0"
        Me.TimesTradesPctBox0.Size = New System.Drawing.Size(1141, 29)
        Me.TimesTradesPctBox0.TabIndex = 32
        Me.TimesTradesPctBox0.TabStop = False
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.TabPage0)
        Me.Tabs.Location = New System.Drawing.Point(20, 75)
        Me.Tabs.Margin = New System.Windows.Forms.Padding(2)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1288, 710)
        Me.Tabs.TabIndex = 31
        '
        'TicksOrSeconds
        '
        Me.TicksOrSeconds.FormattingEnabled = True
        Me.TicksOrSeconds.Items.AddRange(New Object() {"Тики", "5 секунд", "10 секунд", "15 секунд", "30 секунд", "1 минута", "5 минут", "10 минут", "15 минут", "30 минут", "1 час"})
        Me.TicksOrSeconds.Location = New System.Drawing.Point(137, 6)
        Me.TicksOrSeconds.Margin = New System.Windows.Forms.Padding(2)
        Me.TicksOrSeconds.Name = "TicksOrSeconds"
        Me.TicksOrSeconds.Size = New System.Drawing.Size(298, 21)
        Me.TicksOrSeconds.TabIndex = 44
        '
        'TypeOfGraphic
        '
        Me.TypeOfGraphic.FormattingEnabled = True
        Me.TypeOfGraphic.Items.AddRange(New Object() {"Линии", "Японские свечи", "Бары"})
        Me.TypeOfGraphic.Location = New System.Drawing.Point(439, 6)
        Me.TypeOfGraphic.Margin = New System.Windows.Forms.Padding(2)
        Me.TypeOfGraphic.Name = "TypeOfGraphic"
        Me.TypeOfGraphic.Size = New System.Drawing.Size(171, 21)
        Me.TypeOfGraphic.TabIndex = 45
        '
        'BuyPlusSell
        '
        Me.BuyPlusSell.AutoSize = True
        Me.BuyPlusSell.Location = New System.Drawing.Point(314, 46)
        Me.BuyPlusSell.Margin = New System.Windows.Forms.Padding(2)
        Me.BuyPlusSell.Name = "BuyPlusSell"
        Me.BuyPlusSell.Size = New System.Drawing.Size(120, 17)
        Me.BuyPlusSell.TabIndex = 52
        Me.BuyPlusSell.TabStop = True
        Me.BuyPlusSell.Text = "Покупка+Продажа"
        Me.BuyPlusSell.UseVisualStyleBackColor = True
        '
        'BuyAndSell
        '
        Me.BuyAndSell.AutoSize = True
        Me.BuyAndSell.Location = New System.Drawing.Point(137, 46)
        Me.BuyAndSell.Margin = New System.Windows.Forms.Padding(2)
        Me.BuyAndSell.Name = "BuyAndSell"
        Me.BuyAndSell.Size = New System.Drawing.Size(173, 17)
        Me.BuyAndSell.TabIndex = 50
        Me.BuyAndSell.TabStop = True
        Me.BuyAndSell.Text = "Покупка / продажа отдельно"
        Me.BuyAndSell.UseVisualStyleBackColor = True
        '
        'Average
        '
        Me.Average.AutoSize = True
        Me.Average.Location = New System.Drawing.Point(507, 48)
        Me.Average.Margin = New System.Windows.Forms.Padding(2)
        Me.Average.Name = "Average"
        Me.Average.Size = New System.Drawing.Size(105, 17)
        Me.Average.TabIndex = 54
        Me.Average.Text = "Сглаживающая"
        Me.Average.UseVisualStyleBackColor = True
        '
        'Original
        '
        Me.Original.AutoSize = True
        Me.Original.Checked = True
        Me.Original.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Original.Location = New System.Drawing.Point(439, 47)
        Me.Original.Margin = New System.Windows.Forms.Padding(2)
        Me.Original.Name = "Original"
        Me.Original.Size = New System.Drawing.Size(69, 17)
        Me.Original.TabIndex = 53
        Me.Original.Text = "Объемы"
        Me.Original.UseVisualStyleBackColor = True
        '
        'WindowSizeBtn
        '
        Me.WindowSizeBtn.Location = New System.Drawing.Point(685, 46)
        Me.WindowSizeBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.WindowSizeBtn.Name = "WindowSizeBtn"
        Me.WindowSizeBtn.Size = New System.Drawing.Size(88, 22)
        Me.WindowSizeBtn.TabIndex = 56
        Me.WindowSizeBtn.Text = "Применить"
        Me.WindowSizeBtn.UseVisualStyleBackColor = True
        '
        'WindowSizeTextBox
        '
        Me.WindowSizeTextBox.Location = New System.Drawing.Point(652, 48)
        Me.WindowSizeTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.WindowSizeTextBox.Name = "WindowSizeTextBox"
        Me.WindowSizeTextBox.Size = New System.Drawing.Size(29, 20)
        Me.WindowSizeTextBox.TabIndex = 55
        Me.WindowSizeTextBox.Text = "5"
        '
        'Form1Clone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 826)
        Me.Controls.Add(Me.WindowSizeBtn)
        Me.Controls.Add(Me.WindowSizeTextBox)
        Me.Controls.Add(Me.Average)
        Me.Controls.Add(Me.BuyPlusSell)
        Me.Controls.Add(Me.BuyAndSell)
        Me.Controls.Add(Me.Original)
        Me.Controls.Add(Me.TypeOfGraphic)
        Me.Controls.Add(Me.TicksOrSeconds)
        Me.Controls.Add(Me.TradeVolumeLabel)
        Me.Controls.Add(Me.BidPriceLabel)
        Me.Controls.Add(Me.AskPriceLabel)
        Me.Controls.Add(Me.TradePriceLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CurVolumeLabel)
        Me.Controls.Add(Me.VolumeLabel)
        Me.Controls.Add(Me.DrawLineTrades0)
        Me.Controls.Add(Me.TimeLabel0)
        Me.Controls.Add(Me.DrawLineQuotes0)
        Me.Controls.Add(Me.PriceLabel0)
        Me.Controls.Add(Me.Tabs)
        Me.Name = "Form1Clone"
        Me.Text = "A&K Trader 1.0"
        Me.TabPage0.ResumeLayout(False)
        Me.Charts0.ResumeLayout(False)
        Me.QuotesTab0.ResumeLayout(False)
        CType(Me.PricesQuotesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuotesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimesQuotesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TradesTab0.ResumeLayout(False)
        CType(Me.BorderPctBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VolumesVolumesTradesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VolumesTradesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PricesTradesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TradesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimesTradesPctBox0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DrawLineTrades0 As Button
    Friend WithEvents DrawLineQuotes0 As Button
    Friend WithEvents TimeLabel0 As Label
    Friend WithEvents PriceLabel0 As Label
    Friend WithEvents VolumeLabel As Label
    Friend WithEvents CurVolumeLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents AskPriceLabel As Label
    Friend WithEvents BidPriceLabel As Label
    Friend WithEvents TradeVolumeLabel As Label
    Friend WithEvents TradePriceLabel As Label
    Friend WithEvents TabPage0 As TabPage
    Friend WithEvents Charts0 As TabControl
    Friend WithEvents QuotesTab0 As TabPage
    Friend WithEvents PricesQuotesPctBox0 As PictureBox
    Friend WithEvents MinusQuotesButton0 As Button
    Friend WithEvents QuotesPctBox0 As PictureBox
    Friend WithEvents PlusQuotesButton0 As Button
    Friend WithEvents RightQuotesButton0 As Button
    Friend WithEvents LeftQuotesButton0 As Button
    Friend WithEvents TimesQuotesPctBox0 As PictureBox
    Friend WithEvents TradesTab0 As TabPage
    Friend WithEvents VolumesVolumesTradesPctBox0 As PictureBox
    Friend WithEvents VolumesTradesPctBox0 As PictureBox
    Friend WithEvents PricesTradesPctBox0 As PictureBox
    Friend WithEvents MinusTradesButton0 As Button
    Friend WithEvents TradesPctBox0 As PictureBox
    Friend WithEvents PlusTradesButton0 As Button
    Friend WithEvents RightButtonTrades0 As Button
    Friend WithEvents LeftTradesButton0 As Button
    Friend WithEvents TimesTradesPctBox0 As PictureBox
    Friend WithEvents Tabs As TabControl
    Friend WithEvents TicksOrSeconds As ComboBox
    Friend WithEvents TypeOfGraphic As ComboBox
    Friend WithEvents BuyPlusSell As RadioButton
    Friend WithEvents BuyAndSell As RadioButton
    Friend WithEvents Average As CheckBox
    Friend WithEvents Original As CheckBox
    Friend WithEvents WindowSizeBtn As Button
    Friend WithEvents WindowSizeTextBox As TextBox
    Friend WithEvents BorderPctBox As PictureBox
End Class
