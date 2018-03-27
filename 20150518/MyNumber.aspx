
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyNumber.aspx.cs" Inherits="_20150518_MyNumber" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title></title></head><body><form id="form1" runat="server">
    <div>
    
    
    <asp:TextBox ID="txtInput" runat="server" Height="340px" TextMode="MultiLine" Width="500px"></asp:TextBox>
         <asp:TextBox ID="txtInput1" runat="server" Height="340px" TextMode="MultiLine" Width="500px"></asp:TextBox>
        
        <br/>
        <asp:Button ID="btnOK" runat="server" Text="OK" onclick="btnOK_Click" />
        <asp:Button ID="btnResult" runat="server" Text="导入Result" 
            onclick="btnResult_Click" />
        <asp:Button ID="btnOK8" runat="server" Text="OK8" onclick="btnOK_Click" />
        <br/>
        <asp:TextBox ID="txtHand" runat="server" Height="340px" TextMode="MultiLine" Width="500px"></asp:TextBox>
         <asp:TextBox ID="txtHand1" runat="server" Height="340px" TextMode="MultiLine" Width="500px"></asp:TextBox>
        <br/>        
        <asp:Button ID="btnHand" runat="server" Text="确定" onclick="btnHand_Click" />
    </div>
            <div id="MyGoal" runat="server" style="width:3000px">
        </div>
        <input id="hiddenTxt" runat="server" type="hidden" />
    </form>
</body>
</html>

