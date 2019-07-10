Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class AddDevice
    '    Public axCZKEM1 As New zkemkeeper.CZKEM
    '#Region "Communication Device"
    '    Private bIsConnected = False 'the boolean value identifies whether the device is connected
    '    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.




    '    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If TxtIP.Text.Trim() = "" Or TxtIpPort.Text.Trim() = "" Then
    '            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
    '            Return
    '        End If
    '        Dim idwErrorCode As Integer
    '        Cursor = Cursors.WaitCursor
    '        If BtnConnect.Text = "Disconnect" Then
    '            axCZKEM1.Disconnect()

    '            RemoveHandler axCZKEM1.OnVerify, AddressOf axCZKEM1.OnVerify
    '            RemoveHandler axCZKEM1.OnAttTransaction, AddressOf axCZKEM1.OnAttTransaction
    '            RemoveHandler axCZKEM1.OnNewUser, AddressOf axCZKEM1.OnNewUser
    '            RemoveHandler axCZKEM1.OnWriteCard, AddressOf axCZKEM1.OnWriteCard
    '            RemoveHandler axCZKEM1.OnEmptyCard, AddressOf axCZKEM1.OnEmptyCard
    '            RemoveHandler axCZKEM1.OnHIDNum, AddressOf axCZKEM1.OnHIDNum

    '            bIsConnected = False
    '            BtnConnect.Text = "Connect"
    '            lblState.Text = "Disconnected"
    '            Cursor = Cursors.Default
    '            Return
    '        End If
    '        bIsConnected = axCZKEM1.Connect_Net(TxtIP.Text.Trim(), Convert.ToInt32(TxtIpPort.Text.Trim()))
    '        If bIsConnected = True Then
    '            BtnConnect.Text = "Disconnect"
    '            BtnConnect.Refresh()
    '            lblState.Text = "Connected"
    '            Dim smac As String = ""
    '            Dim SN As String = ""
    '            axCZKEM1.GetDeviceMAC(iMachineNumber, smac)
    '            Label9.Text = smac
    '            axCZKEM1.GetSerialNumber(iMachineNumber, SN)
    '            Label10.Text = SN
    '            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.

    '            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

    '                AddHandler axCZKEM1.OnVerify, AddressOf axCZKEM1.OnVerify
    '                AddHandler axCZKEM1.OnAttTransaction, AddressOf axCZKEM1.OnAttTransaction
    '                AddHandler axCZKEM1.OnNewUser, AddressOf axCZKEM1.OnNewUser
    '                AddHandler axCZKEM1.OnWriteCard, AddressOf axCZKEM1.OnWriteCard
    '                AddHandler axCZKEM1.OnEmptyCard, AddressOf axCZKEM1.OnEmptyCard
    '                AddHandler axCZKEM1.OnHIDNum, AddressOf axCZKEM1.OnHIDNum

    '            End If
    '        Else
    '            axCZKEM1.GetLastError(idwErrorCode)
    '            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
    '        End If
    '        Cursor = Cursors.Default
    '    End Sub
    '#End Region

#Region "Communication DB"
    Sub view_grid()
        Call OpenDB()
        sqladapter = New SqlDataAdapter("SELECT * from TerminalInfo", conn)
        datast = New DataSet

        sqladapter.Fill(datast, "TerminalInfo")
        DgvListDevice.DataSource = datast.Tables("TerminalInfo")
        DgvListDevice.ReadOnly = True
    End Sub
    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        If UC_Communication1.TxtId.Text = "" Or UC_Communication1.TxtDesc.Text = "" Or UC_Communication1.TxtIP.Text = "" Or UC_Communication1.TxtIpPort.Text = "" Then
            MsgBox("Not Null", MsgBoxStyle.Critical, "Error")
        Else
            Dim conntypes As String = "Ethernet"
            Call OpenDB()
            Save = "Insert Into TerminalInfo(TerminalID,Description,COnnection,TerminalPort,IPPort)VALUES(@P0,@P1,@P2,@P3,@P4)"
            cmd = conn.CreateCommand
            With cmd
                .CommandText = Save
                .Connection = conn
                .Parameters.Add("p0", SqlDbType.Int).Value = UC_Communication1.TxtId.Text
                .Parameters.Add("p1", SqlDbType.VarChar, 40).Value = UC_Communication1.TxtDesc.Text
                .Parameters.Add("p2", SqlDbType.VarChar, 15).Value = conntypes.ToString
                .Parameters.Add("p3", SqlDbType.VarChar, 15).Value = UC_Communication1.TxtIP.Text
                .Parameters.Add("p4", SqlDbType.Int).Value = UC_Communication1.TxtIpPort.Text
                .ExecuteNonQuery()
            End With
            MsgBox("successful", MsgBoxStyle.Information, "Information Success")
            cmd.Dispose()
            conn.Close()
            DgvListDevice.Rows.Clear()
            Call view_grid()
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Call OpenDB()
        Delete = "DELETE From TerminalInfo Where TerminalID =@p0"
        cmd = conn.CreateCommand
        With cmd
            .CommandText = Delete
            .Connection = conn
            .Parameters.Add("@p0", SqlDbType.Int).Value = UC_Communication1.TxtId.Text
            .ExecuteNonQuery()
        End With
        MsgBox("Data Has Been Delete", MsgBoxStyle.Information, "Information")
        cmd.Dispose()
        conn.Close()
        DgvListDevice.Rows.Clear()
        Call view_grid()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If UC_Communication1.TxtId.Text = "" Or UC_Communication1.TxtDesc.Text = "" Or UC_Communication1.TxtIP.Text = "" Or UC_Communication1.TxtIpPort.Text = "" Then
            MsgBox("Not Null", MsgBoxStyle.Critical, "Error")
        Else
            Dim conntypes As String = "Ethernet"
            Call OpenDB()
            ubah = "UPDATE TerminalInfo SET TerminalID=@P0,Description=@P1,TerminalPort=@P2,IPPort=@P3 WHERE TerminalID =@P0"
            '"UPDATE tbbarang SET namabarang=@p2,harga=@p3,stok=@p4 WHERE kodebarang = @p1"
            cmd = conn.CreateCommand
            With cmd
                .CommandText = ubah
                .Connection = conn
                .Parameters.Add("p0", SqlDbType.Int).Value = UC_Communication1.TxtId.Text
                .Parameters.Add("p1", SqlDbType.VarChar, 40).Value = UC_Communication1.TxtDesc.Text
                .Parameters.Add("p2", SqlDbType.VarChar, 15).Value = UC_Communication1.TxtIP.Text
                .Parameters.Add("p3", SqlDbType.Int).Value = UC_Communication1.TxtIpPort.Text
                .ExecuteNonQuery()
            End With
            MsgBox("successful", MsgBoxStyle.Information, "Information Success")
            cmd.Dispose()
            conn.Close()
            'DgvListDevice.Rows.Clear()
            Call view_grid()
        End If
    End Sub
    Private Sub DgvListDevice_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListDevice.CellClick
        If DgvListDevice.RowCount > 0 Then
            Dim line As Integer
            With DgvListDevice
                line = .CurrentRow.Index
                UC_Communication1.TxtId.Text = .Item(0, line).Value.ToString
                UC_Communication1.TxtDesc.Text = .Item(1, line).Value.ToString
                UC_Communication1.TxtIP.Text = .Item(3, line).Value.ToString
                UC_Communication1.TxtIpPort.Text = .Item(4, line).Value.ToString
            End With
        End If
    End Sub
#End Region
   
    
    
  
    Private Sub AddDevice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call view_grid()
    End Sub

   

    
   

    
    
   
End Class
