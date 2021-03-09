Public Class West
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.DecrementColIndex()
    End Sub
End Class
