Public Interface IBoard

    ReadOnly Property board As IList(Of IBoardRow)

    Function GetSquareState(ByVal position As SquarePosition) As ISquareState

    Sub PutSquareState(ByVal squareState As ISquareState, ByVal position As SquarePosition)

    Function GetRow(ByVal colIndex As Integer) As IBoardRow

    Function GetRowLength() As Integer

    Function GetRowMaxIndex() As Integer

    Function GetColLength() As Integer

    Function GetColMaxIndex() As Integer
End Interface
