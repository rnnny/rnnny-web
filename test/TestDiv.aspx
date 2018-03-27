<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestDiv.aspx.cs" Inherits="TestDiv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>


<script>
window.onload = movediv;
var a = 1;// 1向右 -1向左
var b = 1;// 1向下 -1向上
function movediv(){
    var div = document.getElementById("div1");
    var xx = new Array();// 横向范围
    var yy = new Array();// 纵向范围
    var speed = 2;// 移动距离
    var speed2 = 10;// 移动间隔

    yy.push(0);
    yy.push((document.documentElement || document.body).offsetHeight / 2 - div.offsetHeight);

    xx.push((document.documentElement || document.body).offsetWidth / 2);
    xx.push((document.documentElement || document.body).offsetWidth - div.offsetWidth - 20);

    var x = parseInt(div.style.left.replace(/^(\d+).*?$/,"$1"));// 当前横向位置
    var y = parseInt(div.style.top.replace(/^(\d+).*?$/,"$1"));// 当前纵向位置
document.getElementById("divmsg").innerHTML = x + "," + y + "<br/>" + xx[0] + "," + xx[1] + ";" + yy[0] + "," + yy[1];
document.getElementById("divmsg").innerHTML += "<br/>" + (x < xx[0]) + "," + (y < yy[0]);
    div.style.left = x + speed * a + "px";
    div.style.top = y + speed * b + "px";
    var names=new Array("业务部的反贼快来送死！","业务部的帅哥在家吗？","我叫孙光贺，今年28，至今未婚。","生活真他妈好玩，因为生活老他妈玩我。","我想早恋，但是已经晚了……","思想有多远，你就给我滚多远！","流氓不害怕，就怕流氓有文化……","客官请自重，小女子只卖身不卖艺。","师太！你就从了老衲吧！","我爱你！关你什么事？");
    var ran = Math.random()
    
    div.innerHTML = "<br/>" + names[parseInt(ran * 10)];//alert(ran);
    if(x < xx[0]){
        a = 1;
    }else if(x >= xx[1]){
        a = -1;
    }

    if(y < yy[0]){
        b = 1;
    }else if(y >= yy[1]){
        b = -1;
    }

    setTimeout("movediv()",1000);
}
</script>
</head>
<body style="width:100%;height:100%; text-align: center;">
<div id="div1" style="position:absolute;top:0;left:500px;width:243px; border-right: black 0px solid; border-top: black 0px solid; background-image: url(images/testdiv.JPG); border-left: black 0px solid; border-bottom: black 0px solid; height: 140px; background-color: transparent;">
<br/><br/></div>
<div id="divmsg"></div>
</body>

</html>
