Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OthelloController

<TestClass()> Public Class OthelloTest

    Public othello As IBoardGame

    <TestInitialize()> Public Sub TestInitialize()
        othello = New Othello(8, 8)
        For i As Integer = 0 To
    End Sub

    <TestMethod()> Public Sub TestMethod1()

    End Sub
End Class