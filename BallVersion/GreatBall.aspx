<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GreatBall.aspx.cs" Inherits="GreatBall" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns='http://www.w3.org/1999/xhtml'>

<head id="Head1" runat="server">    
    <title>数据分析</title>
      <style>
        v\:*         { behavior: url(#default#VML) }
        o\:*         { behavior: url(#default#VML) }
        .shape       { behavior: url(#default#VML) }
    </style>
    <script type="text/javascript" src="JavaScript/jquery-1.2.6.pack.js" charset="gb2312"></script>
    <script type="text/javascript" src="JavaScript/jquery-1.3.2.min.js" charset="gb2312"></script>    
    <script language="javascript" type="text/javascript">
    var num = [34];
    var count = 0;
    function SelectCount(id)    
    {    
        if (document.getElementById(id).style.backgroundColor == "yellow")
		{
		    document.getElementById(id).style.backgroundColor = "white";		 
		    document.getElementById('txtGraph').value = "";
		}
		else
		{
		    document.getElementById(id).style.backgroundColor = "yellow";		    
		    document.getElementById('txtGraph').value = id;
		}        
    }
    
    function SelectClick(id)
	{
	    //alert(id);
		//alert(document.getElementById(id));
		//alert(parseInt(document.getElementById(id).innerText));
		//alert(document.getElementById(id).style.borderColor);
		if (document.getElementById(id).style.backgroundColor == "yellow")
		{
		    document.getElementById(id).style.backgroundColor = "white";
		    num[parseInt(document.getElementById(id).title)] = 0;
		}
		else
		{
		    document.getElementById(id).style.backgroundColor = "yellow";
		    num[parseInt(document.getElementById(id).title)] = 1;
		}
		//alert(id);
		//if (document.getElementById('txtGraph').value != "" && document.getElementById('txtGraph').value.substring(0, 5) != 'count')
		//    document.getElementById('txtGraph').value += document.getElementById(id).title + " ";
		//else
		 //   document.getElementById('txtGraph').value = document.getElementById(id).title + " ";
		    
		//ToGraph(id);
	}	
	
	function ToGraph(id)
	{
	    var getRandomColor = '#'+(Math.random()*0xffffff<<0).toString(16); 
	    
	    //document.getElementById(id).style.color = getRandomColor;
	    document.getElementById(id).style.borderBottomColor = getRandomColor;
	    document.getElementById(id).style.borderBottomWidth = 'thick';
	    
	    $.ajax({
                    url: "AjaxServer.aspx?Ajax="+ getRandomColor +"&input=" + document.getElementById(id).title,
                    cache: false,
                    success: function(a)
                    {
                        //alert(a);
                        if (count == 5)
                        {
                            document.getElementById('tdGraph').innerHTML = a;count = 0;
                        }
                        else
                        {
                            document.getElementById('tdGraph').innerHTML += a;count++;
                        }
                    }
                });
	}
	
	function OKClick()
	{
	    var str = "";
	    var count = 0;
	    var countSelect = 0;
	    var red = 0;
	    var total = 0;
	    var strSort = [6];
	    //alert(num.length);
	    for(i = 0; i < num.length; i++)
	    {
	        
	        if (num[i] == 1)
	        {//alert(num[i]);
	            if(i < 10)
	                str += " 0" + i;	            
	            else
	                str += " " + i;
	            total += i;
	            strSort[count] = document.getElementById("select" + i).innerText;
	            count++;
	            document.getElementById("select" + i).style.backgroundColor = "white";
	            num[i] = 0;
	            //alert(parseInt(document.getElementById("select" + i).innerHTML));
	            //alert(document.getElementById("select" + i).style.borderColor);
	            countSelect += parseInt(document.getElementById("select" + i).innerText);
	            
	            if (document.getElementById("select" + i).style.borderColor == "red")
	                red++;
	        }
	    }
	    if(count == 6)
	    {
	        var strLike = "";
	        strSort.sort(sortNumber);
	        for(i = 0; i < strSort.length; i++)
	        {
	            strLike += strSort[i];
	        }
	        document.getElementById("txtSelect").value += str + " 总和：" + total +" 合计：" + countSelect + " 命中： " + red + " 样式：" + strLike + "\n";
	    }
	}
	
	function sortNumber(a,b)
    {
        return a - b;
    }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="haha" runat="server" style="float:left; border-style:groove;width:100%" ></div>
    <table><tr>
    <td><asp:TextBox ID="txtSelect" runat="server" TextMode="MultiLine" Height="100px" Width="800px"></asp:TextBox>
    </td>
    <td valign="top"><input id="btnOK" type="button" onclick="OKClick()" value="OK"/></td>
    </tr>
    <tr><td align="left" valign="top">
        <asp:TextBox ID="txtGraph" runat="server"></asp:TextBox>
        <asp:Button ID="btnGraph" runat="server" Text="Graph" OnClick="btnGraph_Click" />
        <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="ReDisplay" /></td></tr></table>
    
    </form>
</body>
</html>
