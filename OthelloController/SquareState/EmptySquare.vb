Public Class EmptySquare
    Implements IOthelloSquareState

    Public Function CanPut() As Boolean Implements ISquareState.CanPut
        Return True
    End Function

    Public Function GetReverseState() As IOthelloSquareState Implements IOthelloSquareState.GetReverseState
        Return New EmptySquare()
    End Function

    Public Function IsSameState(state As IOthelloSquareState) As Boolean Implements IOthelloSquareState.IsSameState
        Return TypeOf (state) Is EmptySquare
    End Function

    Public Function IsMatchReverseState(state As IOthelloSquareState) As Boolean Implements IOthelloSquareState.IsMatchReverseState
        Return TypeOf (state) Is EmptySquare
    End Function

    Public Function GetImagePath() As String Implements ISquareState.GetImagePath
        Return ""
    End Function
End Class
