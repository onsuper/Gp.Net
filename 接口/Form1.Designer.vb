<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.同步菜品ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.同步餐桌ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.上传图片ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.菜品沽清ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 32)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(937, 587)
        Me.TextBox1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.同步菜品ToolStripMenuItem, Me.同步餐桌ToolStripMenuItem, Me.上传图片ToolStripMenuItem, Me.菜品沽清ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(937, 32)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '同步菜品ToolStripMenuItem
        '
        Me.同步菜品ToolStripMenuItem.Name = "同步菜品ToolStripMenuItem"
        Me.同步菜品ToolStripMenuItem.Size = New System.Drawing.Size(98, 28)
        Me.同步菜品ToolStripMenuItem.Text = "同步菜品"
        '
        '同步餐桌ToolStripMenuItem
        '
        Me.同步餐桌ToolStripMenuItem.Name = "同步餐桌ToolStripMenuItem"
        Me.同步餐桌ToolStripMenuItem.Size = New System.Drawing.Size(98, 28)
        Me.同步餐桌ToolStripMenuItem.Text = "同步餐桌"
        '
        '上传图片ToolStripMenuItem
        '
        Me.上传图片ToolStripMenuItem.Name = "上传图片ToolStripMenuItem"
        Me.上传图片ToolStripMenuItem.Size = New System.Drawing.Size(98, 28)
        Me.上传图片ToolStripMenuItem.Text = "上传图片"
        '
        '菜品沽清ToolStripMenuItem
        '
        Me.菜品沽清ToolStripMenuItem.Name = "菜品沽清ToolStripMenuItem"
        Me.菜品沽清ToolStripMenuItem.Size = New System.Drawing.Size(98, 28)
        Me.菜品沽清ToolStripMenuItem.Text = "菜品沽清"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 619)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dc"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 同步菜品ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 同步餐桌ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 上传图片ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 菜品沽清ToolStripMenuItem As ToolStripMenuItem
End Class
