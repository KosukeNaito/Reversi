Imports OthelloController
Imports System.Threading

Public Class Form1

    Dim _boardPanel As New BoardControl
    Dim passButton As New Button
    Dim othelloController As Othello
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        othelloController = New Othello()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.InitBoardPanel()
        Me.InitSquares()
        Me.InitPassButton()
        Me._boardPanel.Visible = True
        Me.Controls.Add(Me._boardPanel)
        Repaint()
    End Sub

    Private Sub InitPassButton()
        passButton.Text = "パス"
        passButton.Location = New Point(10, 530)
        passButton.Size = New Size(100, 20)
        passButton.Top = 10
        passButton.Left = 530
        passButton.Width = 100
        passButton.Height = 20
        passButton.Visible = True
        AddHandler passButton.Click, AddressOf PutComStone
        Me.Controls.Add(passButton)
    End Sub

    Private Sub InitBoardPanel()
        Me._boardPanel.Name = "BoardPanel"
        Me._boardPanel.Size = New Size(500, 500)
        Me._boardPanel.Location = New Point(10, 10)
        Me._boardPanel.Top = 10
        Me._boardPanel.Left = 10
        Me._boardPanel.Width = 500
        Me._boardPanel.Height = 500
    End Sub

    Private Sub InitSquares()
        For col As Integer = 0 To Me._boardPanel.ColumnCount - 1
            For row As Integer = 0 To Me._boardPanel.RowCount - 1
                Dim square As New SquareControl(col, row)
                square.Name = "Square" & CType(col, String) & CType(row, String)
                square.Height = Me._boardPanel.GetSquareHeight(row)
                square.Width = Me._boardPanel.GetSquareWidth(col)
                square.SizeMode = PictureBoxSizeMode.StretchImage
                square.Visible = True
                AddHandler square.Click, AddressOf PutPlayerStone
                AddHandler square.MouseHover, AddressOf LightSquare

                Me._boardPanel.Controls.Add(square, col, row)
            Next
        Next
    End Sub

    Private Sub Repaint()
        For col As Integer = 0 To Me.othelloController.board.GetColMaxIndex
            For row As Integer = 0 To Me.othelloController.board.GetRowMaxIndex
                Dim position As New SquarePosition(col, row)
                If Not TypeOf (Me.othelloController.board.GetSquareState(position)) Is EmptySquare Then
                    Dim square As SquareControl = Me._boardPanel.GetControlFromPosition(col, row)

                    square.ImageLocation = Me.othelloController.board.GetSquareState(position).GetImagePath()
                    'Me._boardPanel.GetControlFromPosition(col, row).BackgroundImage = Image.FromFile(Me.othelloController.board.GetSquareState(col, row).GetImagePath())
                    'Me._boardPanel.GetControlFromPosition(col, row).BackgroundImageLayout = ImageLayout.Stretch
                End If
            Next
        Next
    End Sub

    Private Sub PutPlayerStone(ByVal sender As SquareControl, ByVal e As MouseEventArgs)
        If Not Me.othelloController.PutPlayerStone(New SquarePosition(sender.GetColIndex, sender.GetRowIndex)) Then
            Return
        End If

        Me.Repaint()
        Me.othelloController.EndPlayerTurn()

        If IsEndGame() Then
            Return
        End If

        Dim comThread As New Thread(New ThreadStart(AddressOf Me.PutComStone))
        comThread.Start()
    End Sub

    Private Sub PutComStone()
        Thread.Sleep(1000)
        If Not Me.othelloController.PutComStone() Then
            MessageBox.Show("置けません！あなたのターンです！")
        End If
        Me.Repaint()
        Me.othelloController.EndComTurn()
        Me.IsEndGame()
    End Sub

    Private Sub LightSquare(ByVal sender As SquareControl, ByVal e As EventArgs)

    End Sub

    Private Function IsEndGame() As Boolean
        If Me.othelloController.IsEndGame() Then
            Dim playerStoneNum As Integer = Me.othelloController.GetPlayerStateNum
            Dim comStoneNum As Integer = Me.othelloController.GetComStateNum
            Dim message As String = playerStoneNum & ":" & comStoneNum & "で"
            If playerStoneNum > comStoneNum Then
                message &= "プレイヤーの勝ち！"
            ElseIf playerStoneNum < comStoneNum Then
                message &= "コンピュータの勝ち！"
            Else
                message &= "同点！"
            End If
            MessageBox.Show(message)
            Return True
        End If
        Return False
    End Function

End Class
