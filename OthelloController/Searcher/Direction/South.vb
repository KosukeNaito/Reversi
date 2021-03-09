Public Class South
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.IncrementRowIndex()
    End Sub
End Class
