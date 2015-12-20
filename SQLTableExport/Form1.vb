Imports System.Data.SqlClient

Public Class Form1

    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click

        Dim Host As String = Me.txtHost.Text
        Dim Username As String = Me.txtUsername.Text
        Dim Password As String = Me.txtPassword.Text
        Dim Database As String = Me.txtDatabase.Text
        Dim ConnStr As String = Me.txtConnString.Text
        Dim Table As String = Me.txtTable.Text

        If ConnStr = "" And Host <> "" And Username <> "" And Password <> "" And Database <> "" Then
            myConn = New SqlConnection("Server=" & Host & ";Database=" & Database & ";User Id=" & Username & ";Password=" & Password & ";")
        ElseIf ConnStr <> "" Then
            myConn = New SqlConnection(ConnStr)
        End If

        If Table <> "" Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\" & Table & ".txt", False)
            myCmd = myConn.CreateCommand
            myCmd.CommandText = "SELECT * from " & Table
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            Dim datastr = ""
            Do While myReader.Read()
                datastr = ""
                For i As Integer = 0 To myReader.FieldCount - 1
                    If i = 0 Then
                        datastr = myReader.Item(i)
                    Else
                        datastr = datastr & "~" & myReader.GetString(i)
                    End If
                Next
                datastr = datastr & "}"
                file.Write(datastr)
            Loop
            file.Close()

            lblMessage.Text = "Export Complete."
        End If
    End Sub
End Class
