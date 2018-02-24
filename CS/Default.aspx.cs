using DevExpress.Web;
using System;
using System.Data;
using System.Web.Script.Serialization;

public partial class _Default : System.Web.UI.Page
{
    protected BootstrapChartDataItem[] GetBootstrapChartData()
    {
        DataRow gridDataRow;
        BootstrapChartDataItem[] BootstrapChartDataItems = new BootstrapChartDataItem[ASPxGridView.VisibleRowCount];

        for (int i = 0; i < ASPxGridView.VisibleRowCount; i++)
        {
            gridDataRow = (ASPxGridView.GetRow(i) as DataRowView).Row;
            BootstrapChartDataItems[i] = new BootstrapChartDataItem(gridDataRow.Field<string>("CategoryName"), gridDataRow.Field<decimal>("CategorySales"));
        }

        return BootstrapChartDataItems;
    }

    protected void ASPxGridView_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bootstrapChart.DataSource = GetBootstrapChartData();
            bootstrapChart.DataBind();
        }
    }

    protected void ASPxGridView_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
    {
        if (e.CallbackName.Equals("APPLYCOLUMNFILTER") || e.CallbackName.Equals("SORT"))
            ASPxGridView.JSProperties["cpJSONData"] = new JavaScriptSerializer().Serialize(GetBootstrapChartData());
    }
}