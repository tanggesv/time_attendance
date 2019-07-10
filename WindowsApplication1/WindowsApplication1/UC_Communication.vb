Public Class UC_Communication
    Public axCZKEM1 As New zkemkeeper.CZKEM
#Region "Communication Device"
    Private bIsConnected = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.




    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtIP.Text.Trim() = "" Or TxtIpPort.Text.Trim() = "" Then
            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor
        If BtnConnect.Text = "Disconnect" Then
            axCZKEM1.Disconnect()

            RemoveHandler axCZKEM1.OnVerify, AddressOf axCZKEM1.OnVerify
            RemoveHandler axCZKEM1.OnAttTransaction, AddressOf axCZKEM1.OnAttTransaction
            RemoveHandler axCZKEM1.OnNewUser, AddressOf axCZKEM1.OnNewUser
            RemoveHandler axCZKEM1.OnWriteCard, AddressOf axCZKEM1.OnWriteCard
            RemoveHandler axCZKEM1.OnEmptyCard, AddressOf axCZKEM1.OnEmptyCard
            RemoveHandler axCZKEM1.OnHIDNum, AddressOf axCZKEM1.OnHIDNum

            bIsConnected = False
            BtnConnect.Text = "Connect"
            lblState.Text = "Disconnected"
            Cursor = Cursors.Default
            Return
        End If
        bIsConnected = axCZKEM1.Connect_Net(TxtIP.Text.Trim(), Convert.ToInt32(TxtIpPort.Text.Trim()))
        If bIsConnected = True Then
            BtnConnect.Text = "Disconnect"
            BtnConnect.Refresh()
            lblState.Text = "Connected"
            Dim smac As String = ""
            Dim SN As String = ""
            axCZKEM1.GetDeviceMAC(iMachineNumber, smac)
            Label9.Text = smac
            axCZKEM1.GetSerialNumber(iMachineNumber, SN)
            Label10.Text = SN
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.

            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                AddHandler axCZKEM1.OnVerify, AddressOf axCZKEM1.OnVerify
                AddHandler axCZKEM1.OnAttTransaction, AddressOf axCZKEM1.OnAttTransaction
                AddHandler axCZKEM1.OnNewUser, AddressOf axCZKEM1.OnNewUser
                AddHandler axCZKEM1.OnWriteCard, AddressOf axCZKEM1.OnWriteCard
                AddHandler axCZKEM1.OnEmptyCard, AddressOf axCZKEM1.OnEmptyCard
                AddHandler axCZKEM1.OnHIDNum, AddressOf axCZKEM1.OnHIDNum

            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
#End Region
End Class
