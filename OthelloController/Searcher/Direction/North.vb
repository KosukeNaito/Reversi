Public Class North
    Implements ISearchDirection

    Public Sub Move(ByRef position As SquarePosition) Implements ISearchDirection.Move
        position.DecrementRowIndex()
    End Sub
End Class
