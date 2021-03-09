Public Class SquarePosition
    Implements ICloneable

    Private RowIndex As Integer
    Private ColIndex As Integer

    Public Sub New(ByVal colIndex As Integer, ByVal rowIndex As Integer)
        Me.ColIndex = colIndex
        Me.RowIndex = rowIndex
    End Sub

    Public Sub IncrementRowIndex()
        Me.RowIndex += 1
    End Sub


    Public Sub IncrementColIndex()
        Me.ColIndex += 1
    End Sub

    Public Sub DecrementRowIndex()
        Me.RowIndex -= 1
    End Sub

    Public Sub DecrementColIndex()
        Me.ColIndex -= 1
    End Sub

    Public Function GetRowIndex() As Integer
        Return Me.RowIndex
    End Function

    Public Function GetColIndex() As Integer
        Return Me.ColIndex
    End Function

    Public Function IsLessThanLength(ByVal colLength As Integer, ByVal rowLength As Integer) As Boolean
        Return colLength > Me.ColIndex And rowLength > Me.RowIndex
    End Function

    Public Function IsZeroOrMore() As Boolean
        Return Me.ColIndex >= 0 And Me.RowIndex >= 0
    End Function

    Public Function IsEnabled(ByVal colLength As Integer, ByVal rowLength As Integer) As Boolean
        Return IsLessThanLength(colLength, rowLength) And IsZeroOrMore()
    End Function

    Public Function IsNotEnabled(ByVal colLength As Integer, ByVal rowLength As Integer) As Boolean
        Return Not IsEnabled(colLength, rowLength)
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New SquarePosition(Me.GetColIndex, Me.GetRowIndex)
    End Function
End Class
