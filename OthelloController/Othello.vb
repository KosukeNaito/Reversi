Imports System.Random


Public Class Othello
    Implements IBoardGame

    Public Property board As IBoard Implements IBoardGame.board
    Private ReadOnly Property playerStone As IOthelloSquareState

    Private ReadOnly Property searcher As IOthelloSearcher
    Private Property IsPlayerTurn As Boolean


    Public Sub New(Optional ByVal boardLength As Integer = 8, Optional ByVal isPlayFirst As Boolean = True)
        Me.board = New OthelloBoard(boardLength, boardLength)
        Me.playerStone = New BlackStone
        Me.IsPlayerTurn = isPlayFirst
        Me.searcher = New OthelloSearcher(Me.board)
    End Sub

    Public Function PutPlayerStone(ByVal position As SquarePosition) As Boolean
        If Not IsPlayerTurn Then
            Return False
        End If

        Return Me.PutStone(Me.playerStone, position)
    End Function

    Public Function IsEndGame() As Boolean
        If GetEmptyStateNum() = 0 OrElse GetPlayerStateNum() = 0 OrElse GetComStateNum() = 0 Then
            Return True
        End If

        Return False
    End Function

    Public Sub EndPlayerTurn()
        Me.IsPlayerTurn = False
    End Sub

    Public Sub EndComTurn()
        Me.IsPlayerTurn = True
    End Sub

    Public Function GetEmptyStateNum() As Integer
        Dim count As Integer = 0
        For col As Integer = 0 To Me.board.GetColMaxIndex
            For row As Integer = 0 To Me.board.GetRowMaxIndex
                If TypeOf (Me.board.GetSquareState(New SquarePosition(col, row))) Is EmptySquare Then
                    count += 1
                End If
            Next
        Next
        Return count
    End Function
    Public Function GetComStateNum() As Integer
        Dim count As Integer = 0
        For col As Integer = 0 To Me.board.GetColMaxIndex
            For row As Integer = 0 To Me.board.GetRowMaxIndex
                If Me.playerStone.GetReverseState.IsSameState(Me.board.GetSquareState(New SquarePosition(col, row))) Then
                    count += 1
                End If
            Next
        Next
        Return count
    End Function

    Public Function GetPlayerStateNum() As Integer
        Dim count As Integer = 0
        For col As Integer = 0 To Me.board.GetColMaxIndex
            For row As Integer = 0 To Me.board.GetRowMaxIndex
                If Me.playerStone.IsSameState(Me.board.GetSquareState(New SquarePosition(col, row))) Then
                    count += 1
                End If
            Next
        Next
        Return count
    End Function

    Public Function PutComStone() As Boolean
        Dim canPutIndexes = New List(Of SquarePosition)
        For col As Integer = 0 To Me.board.GetColMaxIndex
            For row As Integer = 0 To Me.board.GetRowMaxIndex
                If searcher.CanPut(Me.playerStone.GetReverseState, New SquarePosition(col, row)) Then
                    canPutIndexes.Add(New SquarePosition(col, row))
                End If
            Next
        Next

        If canPutIndexes.Count = 0 Then
            Return False
        End If

        Dim random As New Random

        Return PutStone(Me.playerStone.GetReverseState, canputIndexes.Item(random.Next(canPutIndexes.Count)))
    End Function

    Public Function PutStone(ByVal state As IOthelloSquareState, ByVal position As SquarePosition) As Boolean
        Dim reverseIndexes = searcher.GetReverseIndexes(state, position.Clone())

        If reverseIndexes.Count = 0 Then
            Return False
        End If


        For Each index As SquarePosition In reverseIndexes
            Me.board.PutSquareState(state, index)
        Next

        Return True
    End Function

End Class
