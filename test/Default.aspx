<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="ok" Width="32px" /> 
        <asp:Button ID="btnHaHa" runat="server" OnClick="btnHaHa_Click" Text="HAHA" />
        <asp:Button ID="btnHoHo" runat="server" OnClick="btnHoHo_Click" Text="HOHO" />
        <asp:Button ID="btnNear" runat="server" OnClick="btnNear_Click" Text="临号和重号" />
        <asp:Button ID="btnFive" runat="server" OnClick="btnFive_Click" Text="五轮相加结果" />
        <asp:Button ID="btnMove" runat="server" OnClick="btnMove_Click" Text="统计平移" />
        <asp:TextBox ID="txtInput" runat="server" Width="511px"></asp:TextBox><div>
       <div id="haha" runat="server" style="float:left; border-style:groove; width:765px" ></div>
       <div id="over" runat="server" style="float:left; border-style:groove; width:200px" ></div>

        </div>
    </form>
</body>
</html>
