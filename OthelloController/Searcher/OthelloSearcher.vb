Public Class OthelloSearcher
    Implements IOthelloSearcher

    Private _board As IBoard

    Public Sub New(ByVal board As IBoard)
        Me._board = board
    End Sub

    Public Function CanPut(state As IOthelloSquareState, ByVal position As SquarePosition) As Boolean Implements IOthelloSearcher.CanPut
        If Not state.CanPut OrElse
            Not TypeOf Me._board.GetSquareState(position) Is EmptySquare Then
            Return False
        End If

        Return IsSandwich(position.Clone(), state, New North()) OrElse IsSandwich(position.Clone(), state, New South()) OrElse
                IsSandwich(position.Clone(), state, New West()) OrElse IsSandwich(position.Clone(), state, New East()) OrElse
                IsSandwich(position.Clone(), state, New NorthWest()) OrElse IsSandwich(position.Clone(), state, New NorthEast()) OrElse
                IsSandwich(position.Clone(), state, New SouthWest()) OrElse IsSandwich(position.Clone(), state, New SouthEast())
    End Function

    Public Function GetReverseIndexes(state As IOthelloSquareState, position As SquarePosition) As IList(Of SquarePosition) Implements IOthelloSearcher.GetReverseIndexes
        Dim indexes As List(Of SquarePosition) = New List(Of SquarePosition)

        If Not state.CanPut OrElse Not TypeOf Me._board.GetSquareState(position) Is EmptySquare Then
            Return indexes
        End If

        If IsSandwich(position.Clone(), state, New North()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New North()))
        End If

        If IsSandwich(position.Clone(), state, New South()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New South()))
        End If

        If IsSandwich(position.Clone(), state, New West()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New West()))
        End If

        If IsSandwich(position.Clone(), state, New East()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New East()))
        End If

        If IsSandwich(position.Clone(), state, New NorthWest()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New NorthWest()))
        End If

        If IsSandwich(position.Clone(), state, New NorthEast()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New NorthEast()))
        End If

        If IsSandwich(position.Clone(), state, New SouthWest()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New SouthWest()))
        End If

        If IsSandwich(position.Clone(), state, New SouthEast()) Then
            indexes.AddRange(Me.GetPartOfReverseIndexes(state, position.Clone(), New SouthEast()))
        End If

        Return indexes
    End Function

#Region "非公開メソッド"
    Private Function IsSandwich(ByVal position As SquarePosition, ByVal putStoneState As IOthelloSquareState, ByVal direction As ISearchDirection, Optional ByVal hasReverseStone As Boolean = False) As Boolean
        direction.Move(position)

        'インデックスがボード内でない場合false
        If position.IsNotEnabled(Me._board.GetColLength, Me._board.GetRowLength) Then
            Return False
        End If

        '探索先に石がない場合false
        If TypeOf (Me._board.GetSquareState(position)) Is EmptySquare Then
            Return False
        End If

        '挟める石がある状態でおいた石と同じ色の石を見つける
        If putStoneState.IsSameState(Me._board.GetSquareState(position)) And hasReverseStone Then
            Return True
        End If

        '挟める石が見つかっていない状態で先においた石と同じ色の石を見つける
        If putStoneState.IsSameState(Me._board.GetSquareState(position)) And Not hasReverseStone Then
            Return False
        End If

        '挟める石を見つける
        If putStoneState.IsMatchReverseState(Me._board.GetSquareState(position)) Then
            hasReverseStone = True
        End If

        Return IsSandwich(position, putStoneState, direction, hasReverseStone)
    End Function

    Private Function GetPartOfReverseIndexes(ByVal state As IOthelloSquareState, ByVal position As SquarePosition, ByVal direction As ISearchDirection) As IList(Of SquarePosition)
        Dim indexes As IList(Of SquarePosition) = New List(Of SquarePosition)
        indexes.Add(position.Clone())
        While True
            direction.Move(position)
            If state.IsSameState(Me._board.GetSquareState(position)) Then
                Exit While
            Else
                indexes.Add(position.Clone())
            End If
        End While

        Return indexes
    End Function

#End Region

End Class
