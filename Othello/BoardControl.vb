Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class BoardControl
    Inherits TableLayoutPanel
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private _width As Integer
    Private _height As Integer

    Public Property Width As Integer
        Get
            Return Me._width
        End Get
        Set(value As Integer)
            If value.Equals(Me._width) Then Return
            Me._width = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Width)))
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return Me._height
        End Get
        Set(value As Integer)
            If value.Equals(Me._height) Then Return
            Me._height = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Height)))
        End Set
    End Property

    Public Sub New(Optional ByVal colSize As Integer = 8, Optional ByVal rowSize As Integer = 8)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.ColumnCount = colSize
        Me.RowCount = rowSize
        Me.InitSquareHeight()
        Me.InitSquareWidth()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub

    Public Function GetSquareHeight(ByVal rowIndex As Integer) As Integer
        If IsExistRowIndex(rowIndex) Then
            Return Me.RowStyles.Item(rowIndex).Height * Me.Height / 100
        End If

        Return 0
    End Function

    Public Function GetSquareWidth(ByVal colIndex As Integer) As Integer
        If IsExistColIndex(colIndex) Then
            Return Me.ColumnStyles.Item(colIndex).Width * Me.Width / 100
        End If

        Return 0
    End Function

    Public Function IsExistRowIndex(ByVal rowIndex As Integer) As Integer
        Return Me.RowCount > rowIndex
    End Function

    Public Function IsExistColIndex(ByVal colIndex As Integer) As Integer
        Return Me.ColumnCount > colIndex
    End Function



#Region "非公開メソッド"
    Private Sub InitSquares(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Handles Me.PropertyChanged
        If e.PropertyName.Equals(NameOf(Width)) Then
            InitSquareWidth()
        End If

        If e.PropertyName.Equals(NameOf(Height)) Then
            InitSquareHeight()
        End If

    End Sub
    Private Sub InitSquareWidth()
        If Me.ColumnCount = 0 Then
            Return
        End If

        Me.ColumnStyles.Clear()

        For col As Integer = 0 To Me.ColumnCount - 1
            Me.ColumnStyles.Add(New ColumnStyle)
            Me.ColumnStyles.Item(col).SizeType = SizeType.Percent
            Me.ColumnStyles.Item(col).Width = 100 / Me.ColumnCount
        Next
    End Sub

    Private Sub InitSquareHeight()
        If Me.RowCount = 0 Then
            Return
        End If

        Me.RowStyles.Clear()

        For row As Integer = 0 To Me.RowCount - 1
            Me.RowStyles.Add(New RowStyle)
            Me.RowStyles.Item(row).SizeType = SizeType.Percent
            Me.RowStyles.Item(row).Height = 100 / Me.RowCount
        Next
    End Sub
#End Region

End Class
