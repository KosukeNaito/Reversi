Public Class SouthEast
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.IncrementColIndex()
        position.IncrementRowIndex()
    End Sub
End Class
