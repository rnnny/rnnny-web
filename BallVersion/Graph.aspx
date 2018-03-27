<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Graph.aspx.cs" Inherits="Graph" %>

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
    <script type="text/javascript" src="JavaScript/jquery-1.2.6.pack.js" charset="gb2312"></script>
    <script type="text/javascript" src="JavaScript/jquery-1.3.2.min.js" charset="gb2312"></script>  
    <script language="javascript" type="text/javascript">   
	var count = 0;
	function ToGraph(id)
	{
	    //alert(id);
	    var getRandomColor = '#'+(Math.random()*0xffffff<<0).toString(16); 
	    //alert(getRandomColor);
	    document.getElementById(id).style.backgroundColor = getRandomColor;	    
	    //alert(document.getElementById(id));
	    $.ajax({
                    url: "AjaxServer.aspx?Ajax="+ getRandomColor + "&count=" + count + "&input=" + id.split('_')[1],//document.getElementById(id).title,
                    cache: false,
                    success: function(a)
                    {
                        document.getElementById('divGraph').innerHTML += a;                        
                        count++;
                    }
                });
	}	
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table>
    <tr>
    <td width="1200px">    
        <asp:DropDownList ID="dropSelect" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">100%</asp:ListItem>
            <asp:ListItem Value="0.75">75%</asp:ListItem>
            <asp:ListItem Value="0.5">50%</asp:ListItem>
            <asp:ListItem Value="0.25">25%</asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBoxList ID="checkBLArr" runat="server" RepeatDirection="Horizontal" RepeatColumns="20">
        </asp:CheckBoxList>
    </td>
    </tr>
    </table>
    <div id='divGraph' runat="server">
    </div>
    </form>
</body>
</html>