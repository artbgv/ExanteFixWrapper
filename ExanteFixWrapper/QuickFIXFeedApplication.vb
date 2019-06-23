Imports QuickFix
Imports QuickFix44


Public Class QuickFIXFeedApplication
    Implements QuickFix.Application

    Public subscribeInfos As List(Of SubscribeInfo)
    Private fixPassword As String
    Private lastInfo As QuotesInfo

    Sub New(password As String)
        Me.fixPassword = password
        Me.subscribeInfos = New List(Of SubscribeInfo)
    End Sub
    
    Public Sub fromAdmin(message As QuickFix.Message, sessionID As SessionID) Implements Application.fromAdmin

    End Sub

    Public Sub fromApp(message As QuickFix.Message, sessionID As SessionID) Implements Application.fromApp
        Dim msgType As MsgType = New MsgType()
        Dim timeStampField As UtcTimeStampField = New UtcTimeStampField(52, True)
        Dim marketSnapshotDataMessage As MarketDataSnapshotFullRefresh = CType(message, MarketDataSnapshotFullRefresh)
        marketSnapshotDataMessage.getHeader().getField(msgType)
        Dim localTimeStamp As DateTime = DateTime.Now
        If msgType.getValue() = msgType.MarketDataSnapshotFullRefresh Then
            Try
                marketSnapshotDataMessage.getHeader().getField(timeStampField)
                Dim requestId As String = marketSnapshotDataMessage.getMDReqID().ToString()
                Dim noMDEntries As NoMDEntries = marketSnapshotDataMessage.getNoMDEntries()
                Dim mdEntriesGroup As QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries = New QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries()
                Dim mdEntryType As MDEntryType = New MDEntryType()
                Dim mdEntryPx As MDEntryPx = New MDEntryPx()
                Dim mDEntrySize As MDEntrySize = New MDEntrySize()
                Dim quotesInfo As QuotesInfo = New QuotesInfo()
                quotesInfo.TimeStamp = localTimeStamp
                quotesInfo.ExanteId = marketSnapshotDataMessage.getField(55)
                For index As UInteger = 1 To noMDEntries.getValue()
                    message.getGroup(index, mdEntriesGroup)
                    mdEntriesGroup.get(mdEntryType)
                    mdEntriesGroup.get(mdEntryPx)
                    mdEntriesGroup.get(mDEntrySize)
                    Select Case mdEntryType.getValue()
                        Case mdEntryType.BID
                            quotesInfo.BidPrice = mdEntryPx.getValue()
                            quotesInfo.BidVolume = mDEntrySize.getValue()
                        Case mdEntryType.OFFER
                            quotesInfo.AskPrice = mdEntryPx.getValue()
                            quotesInfo.AskVolume = mDEntrySize.getValue()
                        Case MDEntryType.TRADE
                            quotesInfo.TradePrice = mdEntryPx.getValue()
                            quotesInfo.TradeVolume = mDEntrySize.getValue()
                            quotesInfo.Message = message.ToString()
                            If lastInfo Is Nothing Then
                                quotesInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Undefined
                            Else
                                If quotesInfo.TradePrice > lastInfo.TradePrice Then
                                    quotesInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Buy
                                ElseIf quotesInfo.TradePrice < lastInfo.TradePrice Then
                                    quotesInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Sell
                                Else
                                    If lastInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Buy Then
                                        quotesInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Buy
                                    ElseIf lastInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Sell Then
                                        quotesInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Sell
                                    Else
                                        quotesInfo.Direction = ExanteFixWrapper.QuotesInfo.Directions.Undefined
                                    End If
                                End If
                            End If
                            lastInfo = quotesInfo
                        Case Else
                    End Select
                Next
                For Each info As SubscribeInfo In subscribeInfos
                    If info.Guid.ToString() = requestId Then
                        quotesInfo.LocalTimeStamp = DateTime.Now
                        info.UpdateQuotesCallback.Invoke(quotesInfo)
                    End If
                Next
            Catch ex As Exception

            End Try
        End If

    End Sub

    Public Sub onCreate(sessionID As SessionID) Implements Application.onCreate

    End Sub

    Public Sub onLogon(sessionID As SessionID) Implements Application.onLogon

    End Sub

    Public Sub onLogout(sessionID As SessionID) Implements Application.onLogout

    End Sub

    Public Sub toAdmin(message As QuickFix.Message, sessionID As SessionID) Implements Application.toAdmin
        Dim msgType As MsgType = New MsgType()
        message.getHeader().getField(msgType)
        If msgType.getValue = QuickFix.MsgType.Logon Then
            message.setField(New Password(Me.fixPassword))
        End If
    End Sub

    Public Sub toApp(message As QuickFix.Message, sessionID As SessionID) Implements Application.toApp

    End Sub
    Public Sub SubscribeOnQuoteInfo(subscribeInfo As SubscribeInfo)
        Me.subscribeInfos.Add(subscribeInfo)
    End Sub
End Class
