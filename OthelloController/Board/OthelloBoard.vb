Public Class OthelloBoard
    Implements IBoard

    Private ReadOnly Property Board As IList(Of IBoardRow) Implements IBoard.board

    Public Sub New(ByVal colLength As Integer, ByVal rowLength As Integer)
        Me.Board = New List(Of IBoardRow)
        For i As Integer = 0 To colLength - 1
            Me.Board.Add(New BoardRow(rowLength))
        Next

        Me.Board.Item(colLength / 2).Rows(rowLength / 2) = New BlackStone
        Me.Board.Item(colLength / 2 - 1).Rows(rowLength / 2) = New WhiteStone
        Me.Board.Item(colLength / 2).Rows(rowLength / 2 - 1) = New WhiteStone
        Me.Board.Item(colLength / 2 - 1).Rows(rowLength / 2 - 1) = New BlackStone

    End Sub

    Public Function GetSquareState(ByVal position As SquarePosition) As ISquareState Implements IBoard.GetSquareState
        Return Me._Board.Item(position.GetColIndex).Rows.Item(position.GetRowIndex)
    End Function

    Public Sub PutSquareState(squareState As ISquareState, ByVal position As SquarePosition) Implements IBoard.PutSquareState
        Me.Board.Item(position.GetColIndex).Rows(position.GetRowIndex) = squareState
    End Sub

    Public Function GetRow(colIndex As Integer) As IBoardRow Implements IBoard.GetRow
        Return Me.Board.Item(colIndex)
    End Function

    Public Function GetRowLength() As Integer Implements IBoard.GetRowLength
        If Me.Board.Count < 0 Then
            Return 0
        Else
            Return Me.Board.Item(0).Count
        End If
    End Function

    Public Function GetRowMaxIndex() As Integer Implements IBoard.GetRowMaxIndex
        If Me.Board.Count < 0 Then
            Return -1
        Else
            Return Me.Board.Item(0).Count - 1
        End If
    End Function

    Public Function GetColLength() As Integer Implements IBoard.GetColLength
        Return Me.Board.Count
    End Function

    Public Function GetColMaxIndex() As Integer Implements IBoard.GetColMaxIndex
        Return Me.Board.Count - 1
    End Function

End Class
