Public Class East
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.IncrementColIndex()
    End Sub
End Class
