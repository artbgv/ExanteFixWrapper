Imports System.Linq
Public Class MovingAverage
    Public windowSize As Integer
    Private windowPoints As List(Of Double)

    Public Sub New(windowSize As Integer)
        Me.windowSize = windowSize
    End Sub
    Public Sub Reinitialize()
        If windowPoints IsNot Nothing Then
            windowPoints.Clear()
        End If
    End Sub
    Public Function RecalculateValue(windowSizeList As List(Of Double)) As Double
        Return windowSizeList.Sum() / windowSize
    End Function
    Public Function Calculate(currentValue As Double) As Double
        Dim sum As Double = 0.0
        'При первом использовании инициализируем список 
        If windowPoints Is Nothing Then
            windowPoints = New List(Of Double)
            windowPoints.Add(currentValue)
            sum = currentValue
        Else
            'Далее все предыдущие значения сдвигаются в конец, а в начало списка добавляется текущее значение
            If windowPoints.Count >= windowSize Then
                Dim windowPointsCopy = New List(Of Double)
                windowPointsCopy.AddRange(windowPoints)
                For i = 0 To windowSize - 1
                    If i < (windowSize - 1) Then
                        windowPointsCopy(i) = windowPointsCopy(i + 1)
                        sum += windowPointsCopy(i)
                    Else
                        windowPointsCopy(i) = currentValue
                        sum += windowPointsCopy(i)
                    End If
                Next
                windowPoints = windowPointsCopy
            Else
                windowPoints.Add(currentValue)
                sum += currentValue
            End If
        End If
        Return sum / windowSize
    End Function
End Class
