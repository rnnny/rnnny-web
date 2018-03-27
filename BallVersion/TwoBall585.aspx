<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TwoBall585.aspx.cs" Inherits="TwoBall585" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据分析</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border='1'>
    <tr>
    <td style="width:35%">
    <asp:Label ID="labInput" runat="server"><B style="color:red; font-size:large">*</B> 请输入：</asp:Label>

    <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
    <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="ok" Width="32px" />
    </td>
    <td>
        <asp:Button ID="btnNext" runat="server" Text="相邻比较" OnClick="btnNext_Click" />
        <asp:TextBox ID="txtMax" runat="server">10|11</asp:TextBox>
        <asp:Button ID="btnLook" runat="server" Text="详细结果" OnClick="btnLook_Click" /></td>
    <td>
        <asp:Button ID="btnHot" runat="server" Text="热度分析" OnClick="btnHot_Click"/>
        <asp:TextBox ID="txtHot" runat="server">9</asp:TextBox>
        <asp:Button ID="btnHotLook" runat="server" Text="详细结果" OnClick="btnHotLook_Click"/></td>
    </tr>
    <tr>
    <td >
        <asp:RadioButtonList ID="radioButtonNum" runat="server" RepeatDirection="Horizontal">
        </asp:RadioButtonList>       
        <asp:RadioButtonList ID="radioButtonTo" runat="server" RepeatDirection="Horizontal">
        </asp:RadioButtonList>
    </td>
    <td>
            <asp:Label ID="lblGoal" runat="server"><B style="color:red; font-size:large">*</B> 一等数：</asp:Label><asp:TextBox ID="txtGoal" runat="server" Width="90px">0</asp:TextBox>
        <asp:Button ID="btnCount" runat="server" Text="冷热号" OnClick="btnCount_Click" />
            
            <asp:Button ID="btnSort" runat="server" OnClick="btnSort_Click" Text="综合分类" /></td>
            <td>
                &nbsp;<asp:ListBox ID="listBNum" runat="server" Height="60px" Width="50px">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                </asp:ListBox>
                <asp:Button ID="btnOneOne" runat="server" OnClick="btnOneOne_Click" Text="一个一个" />
                <asp:Button ID="btnAll" runat="server" Text="一起来" OnClick="btnAll_Click" />
        <asp:Button ID="btnNumber" runat="server" Text="单独统计" OnClick="btnNumber_Click" /></td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="推荐5/7或4/7选号" />
        <asp:Button ID="btnGraph" runat="server" Text="试试看" OnClick="btnGraph_Click" /></td>
    
    <td  colspan=2>
        <asp:Button ID="btnSplitSum" runat="server" Text="分层总和" OnClick="btnSplitSum_Click" />
        <asp:Button ID="btnSplitGoal" runat="server" Text="分层一等注数" OnClick="btnSplitGoal_Click" />
        <asp:Button ID="btnSplitHead" runat="server" Text="分层首尾" OnClick="btnSplitHead_Click" />&nbsp;
        <asp:Button ID="btnSplit" runat="server" Text="分层统计" OnClick="btnSplit_Click" />
        <asp:TextBox ID="txtSplitSum" runat="server" Width="100">0</asp:TextBox>
        <asp:TextBox ID="txtSplitHead" runat="server" Width="100">0</asp:TextBox></td>
    </tr>
    <tr>
    <td colspan=3>
    <asp:TextBox ID="txtDisplay" runat="server" Width="1000px" TextMode="MultiLine" Height="400px"></asp:TextBox>
    </td>

    </tr>
    </table>
    
    <div id="haha" runat="server" style="cursor:hand; float:left; border-style:groove; width:1200px" ></div>
    </div>
    </form>
</body>
</html>
