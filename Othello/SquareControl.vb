Imports OthelloController
Partial Public Class SquareControl
    Inherits PictureBox

    Private Property BorderColor As Color

    Private ReadOnly Property Position As SquarePosition

    Public Sub New(ByVal colIndex As Integer, ByVal rowIndex As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.Position = New SquarePosition(colIndex, rowIndex)
        Me.LightOff()
        Me.Margin = New Padding(1, 1, 1, 1)
    End Sub



    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim g As Graphics = Me.Parent.CreateGraphics
        Dim rectangle As Rectangle = New Rectangle(Me.Location, Me.Size)
        rectangle.Inflate(1, 1)

        ControlPaint.DrawBorder(g, rectangle, Me._BorderColor, ButtonBorderStyle.Solid)

        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub

    Public Function GetColIndex() As Integer
        Return Me.Position.GetColIndex
    End Function

    Public Function GetRowIndex() As Integer
        Return Me.Position.GetRowIndex
    End Function

    Public Sub LightOn()
        Me.BackColor = Color.Yellow
        Me.BorderColor = Color.Red
    End Sub

    Public Sub LightOff()
        Me.BackColor = Color.Green
        Me.BackColor = Color.Black
    End Sub

End Class
