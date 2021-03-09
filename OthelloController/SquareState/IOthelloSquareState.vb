Public Interface IOthelloSquareState
    Inherits ISquareState

    Function GetReverseState() As IOthelloSquareState

    Function IsSameState(ByVal state As IOthelloSquareState) As Boolean

    Function IsMatchReverseState(ByVal state As IOthelloSquareState) As Boolean
End Interface
