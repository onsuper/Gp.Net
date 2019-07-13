Imports GPApi
Imports GPModels
Imports GPModels.Order

Public Class Form1
    Public WithEvents Gp As New API("42215", "e381e8360778f4fc395a7f927fc787f2684ec9ca"）

    Private Sub 同步菜品ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 同步菜品ToolStripMenuItem.Click
        GPApi.Menu.Upload()
    End Sub

    Private Sub 同步餐桌ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 同步餐桌ToolStripMenuItem.Click
        GPApi.Table.Upload()
    End Sub

    Private Sub 上传图片ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 上传图片ToolStripMenuItem.Click
        GPApi.Menu.UpImage("10001", "D:\图片\2.jpg”)
    End Sub

    Private Sub 菜品沽清ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 菜品沽清ToolStripMenuItem.Click
        GPApi.Menu.sellout("10001")
    End Sub

    Private Sub Gp_DoOrder(order As GPModels.Order.Order, ByRef doState As API.doState) Handles Gp.DoOrder

        TextBox1.Text &= "order:" & order.id & vbCrLf
        doState = API.doState.confirm
    End Sub
End Class
