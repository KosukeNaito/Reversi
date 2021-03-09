Public Class SouthWest
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.IncrementRowIndex()
        position.DecrementColIndex()
    End Sub
End Class
