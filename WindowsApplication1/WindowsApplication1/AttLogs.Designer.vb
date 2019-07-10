<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttLogs
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
        Me.UC_Communication1 = New WindowsApplication1.UC_Communication()
        Me.SuspendLayout()
        '
        'UC_Communication1
        '
        Me.UC_Communication1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_Communication1.Location = New System.Drawing.Point(0, 0)
        Me.UC_Communication1.Name = "UC_Communication1"
        Me.UC_Communication1.Size = New System.Drawing.Size(499, 121)
        Me.UC_Communication1.TabIndex = 0
        '
        'AttLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UC_Communication1)
        Me.Name = "AttLogs"
        Me.Size = New System.Drawing.Size(499, 416)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UC_Communication1 As WindowsApplication1.UC_Communication

End Class
