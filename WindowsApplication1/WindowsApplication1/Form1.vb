Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddDevice1.Visible = False
        AttLogs1.Visible = False
    End Sub


    Private Sub Btn_Device_Click(sender As Object, e As EventArgs) Handles Btn_Device.Click
        AddDevice1.Visible = True
        AttLogs1.Visible = False
    End Sub

   
    Private Sub Btn_Att_Click(sender As Object, e As EventArgs) Handles Btn_Att.Click
        AttLogs1.Visible = True
        AddDevice1.Visible = False
    End Sub
End Class
