Public Class NorthWest
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.DecrementColIndex()
        position.DecrementRowIndex()
    End Sub
End Class
