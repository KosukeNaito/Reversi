Public Interface IBoardRow

    ReadOnly Property Rows As IList(Of ISquareState)


    Function GetSquareState(ByVal rowIndex As Integer) As ISquareState

    Function GetMaxIndex() As Integer

    Function Count() As Integer


End Interface
