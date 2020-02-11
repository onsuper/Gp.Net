# Gp.Net
果盘点菜 .NET 接口


果盘接口，传送门店参数
当有新订单时，会产生Gp_DoOrder事件
开源分享，江林 onsuper@qq.com  

vb.net 示例

'定义接口
Public WithEvents Gp As New API("42215", "e381e8360778f4fc395a7f927fc787f2684ec9ca"）

Private Sub Gp_DoOrder(order As GPModels.Order.Order, ByRef doState As API.doState) Handles Gp.DoOrder
  '业务处理
  TextBox1.Text &= "order:" & order.id & vbCrLf
  doState = API.doState.confirm
End Sub
