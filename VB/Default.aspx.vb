Imports DevExpress.Web
Imports System
Imports System.Data
Imports System.Web.Script.Serialization

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Function GetBootstrapChartData() As BootstrapChartDataItem()
        Dim gridDataRow As DataRow
        Dim BootstrapChartDataItems(ASPxGridView.VisibleRowCount - 1) As BootstrapChartDataItem

        For i As Integer = 0 To ASPxGridView.VisibleRowCount - 1
            gridDataRow = (TryCast(ASPxGridView.GetRow(i), DataRowView)).Row
            BootstrapChartDataItems(i) = New BootstrapChartDataItem(gridDataRow.Field(Of String)("CategoryName"), gridDataRow.Field(Of Decimal)("CategorySales"))
        Next i

        Return BootstrapChartDataItems
    End Function

    Protected Sub ASPxGridView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            bootstrapChart.DataSource = GetBootstrapChartData()
            bootstrapChart.DataBind()
        End If
    End Sub

    Protected Sub ASPxGridView_AfterPerformCallback(ByVal sender As Object, ByVal e As ASPxGridViewAfterPerformCallbackEventArgs)
        If e.CallbackName.Equals("APPLYCOLUMNFILTER") OrElse e.CallbackName.Equals("SORT") Then
            ASPxGridView.JSProperties("cpJSONData") = (New JavaScriptSerializer()).Serialize(GetBootstrapChartData())
        End If
    End Sub
End Class