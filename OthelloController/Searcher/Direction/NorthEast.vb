Public Class NorthEast
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.DecrementRowIndex()
        position.IncrementColIndex()
    End Sub
End Class
