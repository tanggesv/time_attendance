Imports System.Data.Sql
Imports System.Data.SqlClient
Module ModConnection
    Public conn As SqlConnection
    Public datast As DataSet
    Public sqlreader As SqlDataReader
    Public sqladapter As SqlDataAdapter
    Public cmd As SqlCommand
    Public ass As DataTable
    Public sql As String
    Public Save, Delete, ubah As String

    Public Sub OpenDB()
        sql = "Data Source=192.168.86.3;Initial Catalog=HITFPTA;Persist Security Info=True;UID=sa;PWD=asd"

        conn = New SqlConnection(sql)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
            End
        End Try
    End Sub
End Module
