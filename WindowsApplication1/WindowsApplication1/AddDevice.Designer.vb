<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddDevice
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DgvListDevice = New System.Windows.Forms.DataGridView()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.UC_Communication1 = New WindowsApplication1.UC_Communication()
        CType(Me.DgvListDevice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvListDevice
        '
        Me.DgvListDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvListDevice.Location = New System.Drawing.Point(3, 218)
        Me.DgvListDevice.Name = "DgvListDevice"
        Me.DgvListDevice.Size = New System.Drawing.Size(493, 195)
        Me.DgvListDevice.TabIndex = 11
        '
        'Btn_Save
        '
        Me.Btn_Save.Location = New System.Drawing.Point(225, 189)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(85, 23)
        Me.Btn_Save.TabIndex = 16
        Me.Btn_Save.Text = "&Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(407, 189)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(85, 23)
        Me.BtnDelete.TabIndex = 25
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(316, 189)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(85, 23)
        Me.BtnUpdate.TabIndex = 26
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'UC_Communication1
        '
        Me.UC_Communication1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_Communication1.Location = New System.Drawing.Point(0, 0)
        Me.UC_Communication1.Name = "UC_Communication1"
        Me.UC_Communication1.Size = New System.Drawing.Size(499, 121)
        Me.UC_Communication1.TabIndex = 27
        '
        'AddDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UC_Communication1)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.DgvListDevice)
        Me.Name = "AddDevice"
        Me.Size = New System.Drawing.Size(499, 416)
        CType(Me.DgvListDevice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvListDevice As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Save As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents UC_Communication1 As WindowsApplication1.UC_Communication

End Class
