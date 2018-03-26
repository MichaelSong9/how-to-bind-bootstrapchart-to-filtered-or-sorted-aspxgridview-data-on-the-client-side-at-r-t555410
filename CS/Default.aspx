<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to bind  BootstrapChart to filtered ASPxGridView at runtime</title>
    <script type="text/javascript">
        function gridViewEndCallback(s, e) {
            if (ASPxGridView.cpJSONData != undefined)
            {
                bootstrapChart.SetDataSource(JSON.parse(ASPxGridView.cpJSONData));
                ASPxGridView.cpJSONData = null;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="sqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>" SelectCommand="SELECT CategoryName, CategorySales FROM [Category Sales for 1997]" />
        <dx:ASPxGridView ID="ASPxGridView" runat="server" DataSourceID="sqlDataSource" ClientInstanceName="ASPxGridView" OnDataBound="ASPxGridView_DataBound" 
            OnAfterPerformCallback="ASPxGridView_AfterPerformCallback">
            <ClientSideEvents EndCallback="function(s, e) { gridViewEndCallback(s, e) }" />
            <Settings ShowFilterRow="true" />
        </dx:ASPxGridView>
        <dx:BootstrapChart ID="bootstrapChart" runat="server" ClientInstanceName="bootstrapChart" TitleText="Category Sales for 1997">
            <SettingsCommonAxis GridVisible="true" />
            <SettingsLegend Visible="false" />
            <SeriesCollection>
                <dx:BootstrapChartBarSeries ArgumentField="CategoryName" ValueField="CategorySales" Name="CategorySales" />
            </SeriesCollection>
        </dx:BootstrapChart>
    </form>
</body>
</html>
