<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body text="#16">
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>
        <asp:TextBox ID="txtTwo" runat="server">236751498</asp:TextBox>
        <asp:Button ID="btnTwo" runat="server" Text="第一题" OnClick="btnTwo_Click" />        
    <asp:Button ID="btnMoney" runat="server" Text="第二题" OnClick="btnMoney_Click"/>        
        <asp:TextBox ID="txtThree" runat="server">4</asp:TextBox>
        <asp:Button ID="btnThree" runat="server" Text="第三题" OnClick="btnThree_Click" />        
    </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="btnOne1011" runat="server" OnClick="btnOne1011_Click" Text="第一题" />
        <asp:TextBox ID="txtTwo1011" runat="server">15</asp:TextBox>
        <asp:Button ID="btnTwo1011" runat="server" Text="第二题" OnClick="btnTwo1011_Click" />
        <asp:TextBox ID="txtThree1011" runat="server">1,2,89,6,42,3,9,99,6,24,9,2,50,2,60,12</asp:TextBox>
        <asp:Button ID="btnThree1011" runat="server" Text="第三题" OnClick="btnThree1011_Click" /></td>
    </tr>
    <tr>
    <td>
        &nbsp;<asp:TextBox ID="txtFiveLove" runat="server">1</asp:TextBox>
        <asp:Button ID="btnFiveLove" runat="server" Text="五福棋" OnClick="btnFiveLove_Click" /></td>
    </tr>
    <tr>
    <td>    
    </td>
    </tr>
    </table>
    <asp:TextBox ID="txtResult" runat="server" Height="400px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        <asp:Button ID="btnTest" runat="server" OnClick="btnTest_Click" Text="Test" /></div>
    </form>
</body>
</html>
