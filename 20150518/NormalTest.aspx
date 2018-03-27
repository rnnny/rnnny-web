<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NormalTest.aspx.cs" Inherits="_20150518_NormalTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
    function SelectClick(id)
	{
	    //alert(id);
		//alert(document.getElementById(id));
		//alert(parseInt(document.getElementById(id).innerText));
	    //alert(document.getElementById(id).style.borderColor);
	    if (document.getElementById(id).title == 'ok')  
        {
            if (document.getElementById(id).style.backgroundColor == "red")
		    {
		        document.getElementById(id).style.backgroundColor = "white";
		    //num[parseInt(document.getElementById(id).title)] = 0;
		    }
		    else
		    {
		        document.getElementById(id).style.backgroundColor = "red";
		    //num[parseInt(document.getElementById(id).title)] = 1;
		    }
        }
		else 
        {
            if (document.getElementById(id).style.backgroundColor == "blue")
		    {
		        document.getElementById(id).style.backgroundColor = "white";
		    //num[parseInt(document.getElementById(id).title)] = 0;
		    }
		    else
		    {
		        document.getElementById(id).style.backgroundColor = "blue";
		    //num[parseInt(document.getElementById(id).title)] = 1;
		    }
        }
		//alert(id);
		//if (document.getElementById('txtGraph').value != "" && document.getElementById('txtGraph').value.substring(0, 5) != 'count')
		//    document.getElementById('txtGraph').value += document.getElementById(id).title + " ";
		//else
		 //   document.getElementById('txtGraph').value = document.getElementById(id).title + " ";
		    
		//ToGraph(id);
	}
     </script>
</head>
<body>
    <form id="form1" runat="server" value="Select">
    
    
    <asp:TextBox ID="txtInput" runat="server" Height="340px" TextMode="MultiLine" Width="623px"></asp:TextBox>
    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="ok" />
    <asp:TextBox ID="txtTest" runat="server" Height="340px" TextMode="MultiLine" Width="623px"></asp:TextBox>
    <asp:Button ID="btnTest" runat="server" onclick="btnTest_Click" Text="测试" />
    <div id="haha" runat="server" style="float:left; border-style:groove;width:100%" ></div>
    <asp:Button ID="btnFindFour" runat="server" Text="FindFour" 
        onclick="btnFindFour_Click" />
    </form>
</body>
</html>
