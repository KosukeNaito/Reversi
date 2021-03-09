Public Interface IOthelloSearcher

    Function CanPut(ByVal state As IOthelloSquareState, ByVal position As SquarePosition) As Boolean

    Function GetReverseIndexes(ByVal state As IOthelloSquareState, ByVal position As SquarePosition) As IList(Of SquarePosition)

End Interface
