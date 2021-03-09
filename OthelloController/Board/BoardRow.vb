Public Class BoardRow
    Implements IBoardRow

    Public ReadOnly Property Rows As IList(Of ISquareState) Implements IBoardRow.Rows

    Public Sub New(ByVal rowSize As Integer)
        Me.Rows = New List(Of ISquareState)
        For i As Integer = 0 To rowSize - 1
            Me._Rows.Add(New EmptySquare())
        Next
    End Sub


    Public Function GetSquareState(rowIndex As Integer) As ISquareState Implements IBoardRow.GetSquareState
        Throw New NotImplementedException()
    End Function

    Public Function GetMaxIndex() As Integer Implements IBoardRow.GetMaxIndex
        Return If(Me.Rows.Count = 0, Me.Rows.Count, Me.Rows.Count - 1)
    End Function

    Public Function Count() As Integer Implements IBoardRow.Count
        Return Me.Rows.Count
    End Function

End Class
