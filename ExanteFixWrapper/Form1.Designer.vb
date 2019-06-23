<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SubscribreButton0 = New System.Windows.Forms.Button()
        Me.AskPriceLabel = New System.Windows.Forms.Label()
        Me.BidPriceLabel = New System.Windows.Forms.Label()
        Me.TradeVolumeLabel = New System.Windows.Forms.Label()
        Me.TradePriceLabel = New System.Windows.Forms.Label()
        Me.AddTab = New System.Windows.Forms.Button()
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
        Me.TimesTradesPctBox0 = New System.Windows.Forms.PictureBox()
        Me.LeftTradesButton0 = New System.Windows.Forms.Button()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.TicksOrSeconds = New System.Windows.Forms.ComboBox()
        Me.TypeOfGraphic = New System.Windows.Forms.ComboBox()
        Me.AddWindowButton = New System.Windows.Forms.Button()
        Me.BuyAndSell = New System.Windows.Forms.RadioButton()
        Me.BuyPlusSell = New System.Windows.Forms.RadioButton()
        Me.Original = New System.Windows.Forms.CheckBox()
        Me.Average = New System.Windows.Forms.CheckBox()
        Me.WindowSizeTextBox = New System.Windows.Forms.TextBox()
        Me.WindowSizeBtn = New System.Windows.Forms.Button()
        Me.WindowsSizeLabel = New System.Windows.Forms.Label()
        Me.SetSensitivityButton = New System.Windows.Forms.Button()
        Me.SetSensitivityTextBox = New System.Windows.Forms.TextBox()
        Me.SetSensitivityLabel = New System.Windows.Forms.Label()
        Me.BuyOrderButton = New System.Windows.Forms.Button()
        Me.QuantityTextBox = New System.Windows.Forms.TextBox()
        Me.SellOrderButton = New System.Windows.Forms.Button()
        Me.ListViewOrders = New System.Windows.Forms.ListView()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.SettingsPage = New System.Windows.Forms.TabPage()
        Me.TradePage = New System.Windows.Forms.TabPage()
        Me.ExanteIDComboBox1 = New System.Windows.Forms.ComboBox()
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
        Me.Tab.SuspendLayout()
        Me.SettingsPage.SuspendLayout()
        Me.TradePage.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(160, 5)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(150, 23)
        Me.ConnectButton.TabIndex = 0
        Me.ConnectButton.Text = "Соединиться"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Нет соединения"
        '
        'SubscribreButton0
        '
        Me.SubscribreButton0.Location = New System.Drawing.Point(160, 33)
        Me.SubscribreButton0.Name = "SubscribreButton0"
        Me.SubscribreButton0.Size = New System.Drawing.Size(149, 23)
        Me.SubscribreButton0.TabIndex = 11
        Me.SubscribreButton0.Text = "Подписаться"
        Me.SubscribreButton0.UseVisualStyleBackColor = True
        '
        'AskPriceLabel
        '
        Me.AskPriceLabel.AutoSize = True
        Me.AskPriceLabel.ForeColor = System.Drawing.Color.Red
        Me.AskPriceLabel.Location = New System.Drawing.Point(21, 67)
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
        Me.BidPriceLabel.Location = New System.Drawing.Point(79, 67)
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
        Me.TradeVolumeLabel.Location = New System.Drawing.Point(79, 84)
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
        Me.TradePriceLabel.Location = New System.Drawing.Point(21, 84)
        Me.TradePriceLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TradePriceLabel.Name = "TradePriceLabel"
        Me.TradePriceLabel.Size = New System.Drawing.Size(10, 13)
        Me.TradePriceLabel.TabIndex = 41
        Me.TradePriceLabel.Text = "-"
        '
        'AddTab
        '
        Me.AddTab.Location = New System.Drawing.Point(161, 60)
        Me.AddTab.Margin = New System.Windows.Forms.Padding(2)
        Me.AddTab.Name = "AddTab"
        Me.AddTab.Size = New System.Drawing.Size(149, 23)
        Me.AddTab.TabIndex = 43
        Me.AddTab.Text = "Добавить вкладку"
        Me.AddTab.UseVisualStyleBackColor = True
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
        Me.Charts0.Location = New System.Drawing.Point(2, 3)
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
        Me.PricesQuotesPctBox0.Size = New System.Drawing.Size(79, 591)
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
        Me.QuotesPctBox0.Size = New System.Drawing.Size(1184, 591)
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
        Me.RightQuotesButton0.Location = New System.Drawing.Point(652, 596)
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
        Me.TimesQuotesPctBox0.Location = New System.Drawing.Point(80, 594)
        Me.TimesQuotesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.TimesQuotesPctBox0.Name = "TimesQuotesPctBox0"
        Me.TimesQuotesPctBox0.Size = New System.Drawing.Size(1182, 29)
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
        Me.TradesTab0.Controls.Add(Me.TimesTradesPctBox0)
        Me.TradesTab0.Controls.Add(Me.LeftTradesButton0)
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
        Me.BorderPctBox.Location = New System.Drawing.Point(80, 345)
        Me.BorderPctBox.Margin = New System.Windows.Forms.Padding(2)
        Me.BorderPctBox.Name = "BorderPctBox"
        Me.BorderPctBox.Size = New System.Drawing.Size(1180, 4)
        Me.BorderPctBox.TabIndex = 40
        Me.BorderPctBox.TabStop = False
        '
        'VolumesVolumesTradesPctBox0
        '
        Me.VolumesVolumesTradesPctBox0.Location = New System.Drawing.Point(2, 350)
        Me.VolumesVolumesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.VolumesVolumesTradesPctBox0.Name = "VolumesVolumesTradesPctBox0"
        Me.VolumesVolumesTradesPctBox0.Size = New System.Drawing.Size(79, 240)
        Me.VolumesVolumesTradesPctBox0.TabIndex = 39
        Me.VolumesVolumesTradesPctBox0.TabStop = False
        '
        'VolumesTradesPctBox0
        '
        Me.VolumesTradesPctBox0.Location = New System.Drawing.Point(81, 350)
        Me.VolumesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.VolumesTradesPctBox0.Name = "VolumesTradesPctBox0"
        Me.VolumesTradesPctBox0.Size = New System.Drawing.Size(1179, 240)
        Me.VolumesTradesPctBox0.TabIndex = 38
        Me.VolumesTradesPctBox0.TabStop = False
        '
        'PricesTradesPctBox0
        '
        Me.PricesTradesPctBox0.Location = New System.Drawing.Point(2, 0)
        Me.PricesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.PricesTradesPctBox0.Name = "PricesTradesPctBox0"
        Me.PricesTradesPctBox0.Size = New System.Drawing.Size(79, 345)
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
        Me.TradesPctBox0.Size = New System.Drawing.Size(1179, 345)
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
        'TimesTradesPctBox0
        '
        Me.TimesTradesPctBox0.Location = New System.Drawing.Point(80, 593)
        Me.TimesTradesPctBox0.Margin = New System.Windows.Forms.Padding(2)
        Me.TimesTradesPctBox0.Name = "TimesTradesPctBox0"
        Me.TimesTradesPctBox0.Size = New System.Drawing.Size(1179, 29)
        Me.TimesTradesPctBox0.TabIndex = 32
        Me.TimesTradesPctBox0.TabStop = False
        '
        'LeftTradesButton0
        '
        Me.LeftTradesButton0.Location = New System.Drawing.Point(81, 593)
        Me.LeftTradesButton0.Margin = New System.Windows.Forms.Padding(2)
        Me.LeftTradesButton0.Name = "LeftTradesButton0"
        Me.LeftTradesButton0.Size = New System.Drawing.Size(567, 27)
        Me.LeftTradesButton0.TabIndex = 33
        Me.LeftTradesButton0.Text = "<- Left"
        Me.LeftTradesButton0.UseVisualStyleBackColor = True
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.TabPage0)
        Me.Tabs.Location = New System.Drawing.Point(18, 118)
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
        Me.TicksOrSeconds.Location = New System.Drawing.Point(2, 48)
        Me.TicksOrSeconds.Margin = New System.Windows.Forms.Padding(2)
        Me.TicksOrSeconds.Name = "TicksOrSeconds"
        Me.TicksOrSeconds.Size = New System.Drawing.Size(149, 21)
        Me.TicksOrSeconds.TabIndex = 44
        '
        'TypeOfGraphic
        '
        Me.TypeOfGraphic.FormattingEnabled = True
        Me.TypeOfGraphic.Items.AddRange(New Object() {"Линии", "Японские свечи", "Бары"})
        Me.TypeOfGraphic.Location = New System.Drawing.Point(155, 48)
        Me.TypeOfGraphic.Margin = New System.Windows.Forms.Padding(2)
        Me.TypeOfGraphic.Name = "TypeOfGraphic"
        Me.TypeOfGraphic.Size = New System.Drawing.Size(150, 21)
        Me.TypeOfGraphic.TabIndex = 45
        '
        'AddWindowButton
        '
        Me.AddWindowButton.Location = New System.Drawing.Point(161, 88)
        Me.AddWindowButton.Name = "AddWindowButton"
        Me.AddWindowButton.Size = New System.Drawing.Size(149, 25)
        Me.AddWindowButton.TabIndex = 46
        Me.AddWindowButton.Text = "Добавить окно"
        Me.AddWindowButton.UseVisualStyleBackColor = True
        '
        'BuyAndSell
        '
        Me.BuyAndSell.AutoSize = True
        Me.BuyAndSell.Location = New System.Drawing.Point(121, 26)
        Me.BuyAndSell.Margin = New System.Windows.Forms.Padding(2)
        Me.BuyAndSell.Name = "BuyAndSell"
        Me.BuyAndSell.Size = New System.Drawing.Size(173, 17)
        Me.BuyAndSell.TabIndex = 47
        Me.BuyAndSell.TabStop = True
        Me.BuyAndSell.Text = "Покупка / продажа отдельно"
        Me.BuyAndSell.UseVisualStyleBackColor = True
        '
        'BuyPlusSell
        '
        Me.BuyPlusSell.AutoSize = True
        Me.BuyPlusSell.Location = New System.Drawing.Point(121, 6)
        Me.BuyPlusSell.Margin = New System.Windows.Forms.Padding(2)
        Me.BuyPlusSell.Name = "BuyPlusSell"
        Me.BuyPlusSell.Size = New System.Drawing.Size(120, 17)
        Me.BuyPlusSell.TabIndex = 49
        Me.BuyPlusSell.TabStop = True
        Me.BuyPlusSell.Text = "Покупка+Продажа"
        Me.BuyPlusSell.UseVisualStyleBackColor = True
        '
        'Original
        '
        Me.Original.AutoSize = True
        Me.Original.Checked = True
        Me.Original.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Original.Location = New System.Drawing.Point(2, 26)
        Me.Original.Margin = New System.Windows.Forms.Padding(2)
        Me.Original.Name = "Original"
        Me.Original.Size = New System.Drawing.Size(69, 17)
        Me.Original.TabIndex = 50
        Me.Original.Text = "Объемы"
        Me.Original.UseVisualStyleBackColor = True
        '
        'Average
        '
        Me.Average.AutoSize = True
        Me.Average.Location = New System.Drawing.Point(2, 6)
        Me.Average.Margin = New System.Windows.Forms.Padding(2)
        Me.Average.Name = "Average"
        Me.Average.Size = New System.Drawing.Size(105, 17)
        Me.Average.TabIndex = 51
        Me.Average.Text = "Сглаживающая"
        Me.Average.UseVisualStyleBackColor = True
        '
        'WindowSizeTextBox
        '
        Me.WindowSizeTextBox.Location = New System.Drawing.Point(498, 4)
        Me.WindowSizeTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.WindowSizeTextBox.Name = "WindowSizeTextBox"
        Me.WindowSizeTextBox.Size = New System.Drawing.Size(50, 20)
        Me.WindowSizeTextBox.TabIndex = 52
        Me.WindowSizeTextBox.Text = "5"
        '
        'WindowSizeBtn
        '
        Me.WindowSizeBtn.Location = New System.Drawing.Point(552, 2)
        Me.WindowSizeBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.WindowSizeBtn.Name = "WindowSizeBtn"
        Me.WindowSizeBtn.Size = New System.Drawing.Size(74, 22)
        Me.WindowSizeBtn.TabIndex = 53
        Me.WindowSizeBtn.Text = "Применить"
        Me.WindowSizeBtn.UseVisualStyleBackColor = True
        '
        'WindowsSizeLabel
        '
        Me.WindowsSizeLabel.AutoSize = True
        Me.WindowsSizeLabel.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.WindowsSizeLabel.Location = New System.Drawing.Point(322, 7)
        Me.WindowsSizeLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.WindowsSizeLabel.Name = "WindowsSizeLabel"
        Me.WindowsSizeLabel.Size = New System.Drawing.Size(111, 13)
        Me.WindowsSizeLabel.TabIndex = 55
        Me.WindowsSizeLabel.Text = "Задать размер окна"
        '
        'SetSensitivityButton
        '
        Me.SetSensitivityButton.Location = New System.Drawing.Point(552, 28)
        Me.SetSensitivityButton.Margin = New System.Windows.Forms.Padding(2)
        Me.SetSensitivityButton.Name = "SetSensitivityButton"
        Me.SetSensitivityButton.Size = New System.Drawing.Size(74, 23)
        Me.SetSensitivityButton.TabIndex = 56
        Me.SetSensitivityButton.Text = "Применить"
        Me.SetSensitivityButton.UseVisualStyleBackColor = True
        '
        'SetSensitivityTextBox
        '
        Me.SetSensitivityTextBox.Location = New System.Drawing.Point(498, 29)
        Me.SetSensitivityTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.SetSensitivityTextBox.Name = "SetSensitivityTextBox"
        Me.SetSensitivityTextBox.Size = New System.Drawing.Size(50, 20)
        Me.SetSensitivityTextBox.TabIndex = 57
        Me.SetSensitivityTextBox.Text = "10"
        '
        'SetSensitivityLabel
        '
        Me.SetSensitivityLabel.AutoSize = True
        Me.SetSensitivityLabel.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.SetSensitivityLabel.Location = New System.Drawing.Point(322, 32)
        Me.SetSensitivityLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SetSensitivityLabel.Name = "SetSensitivityLabel"
        Me.SetSensitivityLabel.Size = New System.Drawing.Size(170, 13)
        Me.SetSensitivityLabel.TabIndex = 58
        Me.SetSensitivityLabel.Text = "Задать чувствительность мыши"
        '
        'BuyOrderButton
        '
        Me.BuyOrderButton.Location = New System.Drawing.Point(6, 6)
        Me.BuyOrderButton.Name = "BuyOrderButton"
        Me.BuyOrderButton.Size = New System.Drawing.Size(57, 23)
        Me.BuyOrderButton.TabIndex = 59
        Me.BuyOrderButton.Text = "Купить"
        Me.BuyOrderButton.UseVisualStyleBackColor = True
        '
        'QuantityTextBox
        '
        Me.QuantityTextBox.Location = New System.Drawing.Point(69, 8)
        Me.QuantityTextBox.Name = "QuantityTextBox"
        Me.QuantityTextBox.Size = New System.Drawing.Size(100, 20)
        Me.QuantityTextBox.TabIndex = 60
        '
        'SellOrderButton
        '
        Me.SellOrderButton.Location = New System.Drawing.Point(6, 32)
        Me.SellOrderButton.Name = "SellOrderButton"
        Me.SellOrderButton.Size = New System.Drawing.Size(163, 23)
        Me.SellOrderButton.TabIndex = 61
        Me.SellOrderButton.Text = "Продать"
        Me.SellOrderButton.UseVisualStyleBackColor = True
        '
        'ListViewOrders
        '
        Me.ListViewOrders.Location = New System.Drawing.Point(175, 5)
        Me.ListViewOrders.Name = "ListViewOrders"
        Me.ListViewOrders.Size = New System.Drawing.Size(801, 74)
        Me.ListViewOrders.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.ListViewOrders.TabIndex = 62
        Me.ListViewOrders.UseCompatibleStateImageBehavior = False
        Me.ListViewOrders.View = System.Windows.Forms.View.Details
        '
        'RefreshButton
        '
        Me.RefreshButton.Location = New System.Drawing.Point(6, 58)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(163, 23)
        Me.RefreshButton.TabIndex = 63
        Me.RefreshButton.Text = "Обновить"
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Tab
        '
        Me.Tab.Controls.Add(Me.SettingsPage)
        Me.Tab.Controls.Add(Me.TradePage)
        Me.Tab.Location = New System.Drawing.Point(316, 6)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(989, 111)
        Me.Tab.TabIndex = 64
        '
        'SettingsPage
        '
        Me.SettingsPage.Controls.Add(Me.Average)
        Me.SettingsPage.Controls.Add(Me.TypeOfGraphic)
        Me.SettingsPage.Controls.Add(Me.BuyPlusSell)
        Me.SettingsPage.Controls.Add(Me.TicksOrSeconds)
        Me.SettingsPage.Controls.Add(Me.BuyAndSell)
        Me.SettingsPage.Controls.Add(Me.Original)
        Me.SettingsPage.Controls.Add(Me.WindowSizeBtn)
        Me.SettingsPage.Controls.Add(Me.SetSensitivityLabel)
        Me.SettingsPage.Controls.Add(Me.WindowSizeTextBox)
        Me.SettingsPage.Controls.Add(Me.SetSensitivityTextBox)
        Me.SettingsPage.Controls.Add(Me.WindowsSizeLabel)
        Me.SettingsPage.Controls.Add(Me.SetSensitivityButton)
        Me.SettingsPage.Location = New System.Drawing.Point(4, 22)
        Me.SettingsPage.Name = "SettingsPage"
        Me.SettingsPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SettingsPage.Size = New System.Drawing.Size(981, 85)
        Me.SettingsPage.TabIndex = 0
        Me.SettingsPage.Text = "Настройки"
        Me.SettingsPage.UseVisualStyleBackColor = True
        '
        'TradePage
        '
        Me.TradePage.Controls.Add(Me.RefreshButton)
        Me.TradePage.Controls.Add(Me.QuantityTextBox)
        Me.TradePage.Controls.Add(Me.ListViewOrders)
        Me.TradePage.Controls.Add(Me.BuyOrderButton)
        Me.TradePage.Controls.Add(Me.SellOrderButton)
        Me.TradePage.Location = New System.Drawing.Point(4, 22)
        Me.TradePage.Name = "TradePage"
        Me.TradePage.Padding = New System.Windows.Forms.Padding(3)
        Me.TradePage.Size = New System.Drawing.Size(981, 85)
        Me.TradePage.TabIndex = 1
        Me.TradePage.Text = "Торговля"
        Me.TradePage.UseVisualStyleBackColor = True
        '
        'ExanteIDComboBox1
        '
        Me.ExanteIDComboBox1.FormattingEnabled = True
        Me.ExanteIDComboBox1.Items.AddRange(New Object() {"BTC.EXANTE", "TSLA.NASDAQ", "SBER.MICEX"})
        Me.ExanteIDComboBox1.Location = New System.Drawing.Point(17, 33)
        Me.ExanteIDComboBox1.Name = "ExanteIDComboBox1"
        Me.ExanteIDComboBox1.Size = New System.Drawing.Size(137, 21)
        Me.ExanteIDComboBox1.TabIndex = 65
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1412, 843)
        Me.Controls.Add(Me.ExanteIDComboBox1)
        Me.Controls.Add(Me.AddWindowButton)
        Me.Controls.Add(Me.AddTab)
        Me.Controls.Add(Me.TradeVolumeLabel)
        Me.Controls.Add(Me.BidPriceLabel)
        Me.Controls.Add(Me.AskPriceLabel)
        Me.Controls.Add(Me.TradePriceLabel)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.SubscribreButton0)
        Me.Controls.Add(Me.Tab)
        Me.Name = "Form1"
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
        Me.Tab.ResumeLayout(False)
        Me.SettingsPage.ResumeLayout(False)
        Me.SettingsPage.PerformLayout()
        Me.TradePage.ResumeLayout(False)
        Me.TradePage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConnectButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SubscribreButton0 As Button
    Friend WithEvents AskPriceLabel As Label
    Friend WithEvents BidPriceLabel As Label
    Friend WithEvents TradeVolumeLabel As Label
    Friend WithEvents TradePriceLabel As Label
    Friend WithEvents AddTab As Button
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
    Friend WithEvents AddWindowButton As System.Windows.Forms.Button
    Friend WithEvents BuyAndSell As RadioButton
    Friend WithEvents BuyPlusSell As RadioButton
    Friend WithEvents Original As CheckBox
    Friend WithEvents Average As CheckBox
    Friend WithEvents WindowSizeTextBox As TextBox
    Friend WithEvents WindowSizeBtn As Button
    Friend WithEvents BorderPctBox As PictureBox
    Friend WithEvents WindowsSizeLabel As Label
    Friend WithEvents SetSensitivityButton As Button
    Friend WithEvents SetSensitivityTextBox As TextBox
    Friend WithEvents SetSensitivityLabel As Label
    Friend WithEvents BuyOrderButton As System.Windows.Forms.Button
    Friend WithEvents QuantityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SellOrderButton As System.Windows.Forms.Button
    Friend WithEvents ListViewOrders As System.Windows.Forms.ListView
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Tab As TabControl
    Friend WithEvents SettingsPage As TabPage
    Friend WithEvents TradePage As TabPage
    Friend WithEvents ExanteIDComboBox1 As ComboBox
End Class
