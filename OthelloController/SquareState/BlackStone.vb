Public Class BlackStone
    Implements IOthelloSquareState

    Public Function CanPut() As Boolean Implements ISquareState.CanPut
        Return True
    End Function

    Public Function GetReverseState() As IOthelloSquareState Implements IOthelloSquareState.GetReverseState
        Return New WhiteStone()
    End Function

    Public Function IsSameState(state As IOthelloSquareState) As Boolean Implements IOthelloSquareState.IsSameState
        Return TypeOf (state) Is BlackStone
    End Function

    Public Function IsMatchReverseState(state As IOthelloSquareState) As Boolean Implements IOthelloSquareState.IsMatchReverseState
        Return TypeOf (state) Is WhiteStone
    End Function
    Public Function GetImagePath() As String Implements ISquareState.GetImagePath
        Return IO.Path.GetFullPath(".\Image\BlackStone.png")
    End Function
End Class
