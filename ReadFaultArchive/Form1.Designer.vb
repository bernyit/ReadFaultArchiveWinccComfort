﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnSelectOrigin = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.btnSelectDestination = New System.Windows.Forms.Button()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.WinCCComfort = New ReadFaultArchive.WinCCComfort()
        Me.AlarmListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AlarmListTableAdapter = New ReadFaultArchive.WinCCComfortTableAdapters.alarmListTableAdapter()
        Me.btnFillTable = New System.Windows.Forms.Button()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinCCComfort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AlarmListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(287, 141)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(333, 72)
        Me.btnRead.TabIndex = 0
        Me.btnRead.Text = "CONVERT"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'btnSelectOrigin
        '
        Me.btnSelectOrigin.Location = New System.Drawing.Point(62, 32)
        Me.btnSelectOrigin.Name = "btnSelectOrigin"
        Me.btnSelectOrigin.Size = New System.Drawing.Size(176, 37)
        Me.btnSelectOrigin.TabIndex = 1
        Me.btnSelectOrigin.Text = "Select Wincc Fault File"
        Me.btnSelectOrigin.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "WinCC Alarms|Faults_Archive*.txt|All Files|*.*"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(244, 41)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(531, 20)
        Me.txtSource.TabIndex = 2
        '
        'btnSelectDestination
        '
        Me.btnSelectDestination.Location = New System.Drawing.Point(62, 75)
        Me.btnSelectDestination.Name = "btnSelectDestination"
        Me.btnSelectDestination.Size = New System.Drawing.Size(176, 37)
        Me.btnSelectDestination.TabIndex = 3
        Me.btnSelectDestination.Text = "Select Destination"
        Me.btnSelectDestination.UseVisualStyleBackColor = True
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(244, 84)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(531, 20)
        Me.txtDestination.TabIndex = 4
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.Filter = "CSV File|*.csv|All Files|*.*"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "CSV File|*.csv|All Files|*.*"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToOrderColumns = True
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(12, 238)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(763, 172)
        Me.dgv1.TabIndex = 5
        '
        'WinCCComfort
        '
        Me.WinCCComfort.DataSetName = "WinCCComfort"
        Me.WinCCComfort.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AlarmListBindingSource
        '
        Me.AlarmListBindingSource.DataMember = "alarmList"
        Me.AlarmListBindingSource.DataSource = Me.WinCCComfort
        '
        'AlarmListTableAdapter
        '
        Me.AlarmListTableAdapter.ClearBeforeFill = True
        '
        'btnFillTable
        '
        Me.btnFillTable.Location = New System.Drawing.Point(11, 211)
        Me.btnFillTable.Name = "btnFillTable"
        Me.btnFillTable.Size = New System.Drawing.Size(51, 27)
        Me.btnFillTable.TabIndex = 6
        Me.btnFillTable.Text = "Button1"
        Me.btnFillTable.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnFillTable)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.btnSelectDestination)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.btnSelectOrigin)
        Me.Controls.Add(Me.btnRead)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinCCComfort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AlarmListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRead As Button
    Friend WithEvents btnSelectOrigin As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtSource As TextBox
    Friend WithEvents btnSelectDestination As Button
    Friend WithEvents txtDestination As TextBox
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents WinCCComfort As WinCCComfort
    Friend WithEvents AlarmListBindingSource As BindingSource
    Friend WithEvents AlarmListTableAdapter As WinCCComfortTableAdapters.alarmListTableAdapter
    Friend WithEvents btnFillTable As Button
End Class
