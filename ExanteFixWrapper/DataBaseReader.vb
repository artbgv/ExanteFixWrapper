Imports System.IO
Imports ADODB

Public Class DataBaseReader
    Private dbPath As String 'Путь до баз данных
    Private currentFileName As String 'Имя текущего файла БД
    Private connectionString As String 'Строка(параметры) соединения с БД
    Private currentConnection As Connection 'Текущее соединение

    Public Sub New(dbPath As String)
        Me.dbPath = dbPath
    End Sub
    'Метод для получения из базы списка точек
    Public Function GetListOfTrades5secPoints(instrumentName As String) As Tuple(Of List(Of PointTradesNsec), Double)
        'Получаем список имен файлов из указанной в dbPath директории
        Dim files = Directory.GetFiles(dbPath, instrumentName.Replace("/", "_" + "_") + "_*.accdb")
        'Переменная для последней даты создания файла
        Dim lastFileCreationDate = New DateTime(0)
        'В цикле ищем файл с последней датой создания
        For Each item As String In files
            If Directory.GetCreationTime(item) > lastFileCreationDate Then
                currentFileName = Path.GetFileName(item)
                lastFileCreationDate = Directory.GetCreationTime(item)
            End If
        Next
        'Определяем строку соединения
        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                   "Data Source=" + dbPath + "\" + currentFileName + ";"
        'Инициализируем соединение
        currentConnection = New Connection()
        'Открываем соединение
        currentConnection.Open(connectionString)
        'Инициализируем переменную для получения данных
        Dim recordSet As ADODB.Recordset = New ADODB.Recordset
        'Указываем соединение
        recordSet.ActiveConnection = currentConnection
        'Открываем таблицу
        recordSet.Open("FiveSecondsDataTable")
        Dim list5sec = New List(Of PointTradesNsec)
        Dim maxVolume As Double = -1
        'Открываем таблицу
        'В цикле берем необходимые данные и оперделяем масимальное значение объема
        While Not recordSet.EOF
            Dim point As New PointTradesNsec
            point.time = recordSet.Fields.Item(3).Value
            point.time.AddMilliseconds(recordSet.Fields.Item(4).Value)
            point.openPrice = recordSet.Fields.Item(6).Value
            point.closePrice = recordSet.Fields.Item(9).Value
            point.highPrice = recordSet.Fields.Item(7).Value
            point.lowPrice = recordSet.Fields.Item(8).Value
            point.volumeSell = recordSet.Fields.Item(10).Value
            point.volumeBuy = recordSet.Fields.Item(11).Value
            If ((point.volumeBuy + point.volumeSell) > maxVolume) Then
                maxVolume = point.volumeBuy + point.volumeSell
            End If
            list5sec.Add(point)
            recordSet.MoveNext()
        End While
        Dim tuple As New Tuple(Of List(Of PointTradesNsec), Double)(list5sec, maxVolume)
        Return tuple
    End Function
End Class
