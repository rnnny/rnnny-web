<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LetGo.aspx.cs" Inherits="LetGo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns='http://www.w3.org/1999/xhtml'>

<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
    <title>无标题页</title>
      <style>
        v\:line         { behavior: url(#default#VML) }
        o\:line         { behavior: url(#default#VML) }
        .shape       { behavior: url(#default#VML) }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        
        <tr>
            <td>
                <asp:DropDownList ID="dropRound" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropRound_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:LinkButton ID="linkBtnNumber" runat="server" OnClick="linkBtnNumber_Click">Number</asp:LinkButton>
                <asp:LinkButton ID="LinkBtnNumStDev" runat="server" OnClick="LinkBtnNumStDev_Click">NumberStDev</asp:LinkButton>
                <asp:LinkButton ID="LinkBtnRound" runat="server" OnClick="LinkBtnRound_Click">Round</asp:LinkButton>
                <asp:LinkButton ID="LinkBtnRoundFindLast" runat="server" OnClick="LinkBtnRoundFindLast_Click">RoundFindLast</asp:LinkButton>
                <asp:LinkButton ID="LinkBtnRound30" runat="server" OnClick="LinkBtnRound30_Click">Round30</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkBtnAnalysis" runat="server" BorderStyle="Solid" ForeColor="MediumBlue">Analysis</asp:LinkButton>                
            </td>
        </tr>
        <tr>
            <td>
                <div id="MyGoal" runat="server">
                </div>
            </td>
            <td>
                <div id='divGraph' runat="server">
                </div>
            </td>
        </tr>
    </table>
        
        
    </form>
</body>
</html>
