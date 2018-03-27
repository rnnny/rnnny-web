<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForNumber.aspx.cs" Inherits="_20150518_ForNumber" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Chart ID="Chart1" runat="server" Width="1500px">
                <series>
                    <asp:Series Name="Series1"  ChartType="Bubble" MarkerSize="8" MarkerStyle="Circle">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1"  BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
    </div>
        <div id="MyGoal" runat="server" style="width:3000px">
           
        </div>
    </form>
</body>
</html>

