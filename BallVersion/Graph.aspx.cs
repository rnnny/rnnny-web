using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;

public partial class Graph : System.Web.UI.Page
{
    private float _FF = new float();

    protected void Page_Load(object sender, EventArgs e)
    {
        _FF = float.Parse(dropSelect.SelectedItem.Value);      

        ArrayList al = (ArrayList)Session["Normal"];

        checkBLArr.Items.Clear();

        for (int i = 0; i < al.Count; i++)
        {
            ListItem li = new ListItem();
            li.Text = i.ToString();
            li.Value = i.ToString();
            //li.Attributes.Add("id", "check" + i.ToString());
            //li.Attributes.Add("title", i.ToString());
            li.Attributes.Add("onClick", "ToGraph(id)");
            checkBLArr.Items.Add(li);
        }  
        
        //InitGraph();
    }

    #region last program
    //private void InitGraph()
    //{
    //divGraph.InnerHtml = "<v:shape CoordOrig='0,0' CoordSize='8000,800' style='width:8000;height:800'/>"
    //       + "<v:line id='line' from='0,0' to='0,800' position='absolute' strokeColor='red' strokeWeight='2'></v:line>"
    //       + "<v:line id='line' from='0,0' to='8000,0' position='absolute' strokeColor='red' strokeWeight='2'></v:line>"
    //       + "<v:line id='line' from='8000,0' to='8000,800' position='absolute' strokeColor='red' strokeWeight='2'></v:line>"
    //       + "<v:line id='line' from='0,800' to='8000,800' position='absolute' strokeColor='red' strokeWeight='2'></v:line>";


    //for (int i = 1; i <= 16; i++)
    //{
    //    if (i == 3 || i == 8)
    //        divGraph.InnerHtml += "<v:line id='line' from='0, " + Convert.ToString(i * 50 * _FF) + "' to='" + Convert.ToString(8000 * _FF) + ", " + Convert.ToString(i * 50 * _FF) + "' position='absolute' strokeColor='black' strokeWeight='3'></v:line>";
    //    else
    //        divGraph.InnerHtml += "<v:line id='line' from='0, " + Convert.ToString(i * 50 * _FF) + "' to='" + Convert.ToString(8000 * _FF) + ", " + Convert.ToString(i * 50 * _FF) + "' position='absolute' strokeColor='blue' strokeWeight='1'></v:line>";

    //    if (_FF == 1)
    //        for (int j = 0; j < 7; j++)
    //        {
    //            divGraph.InnerHtml += "<v:RoundRect style='position:absolute;left:" + Convert.ToString(j * 1000) + "px;top:" + Convert.ToString(i * 50) + "px;width:20px;height:20px' strokeColor='black'>"
    //                //+ "<v:shadow on='T' type='single' color='#b3b3b3' offset='5px,5px'/>"
    //                + "<v:TextBox inset='1pt,1pt,1pt,1pt' style='font-size:12.2pt;'>" + Convert.ToString(i - 1) + "</v:TextBox>"
    //                + "</v:RoundRect>";
    //        }
    //}

    //for (int i = 1; i < _ArrLine.Count; i++)
    //{
    //    divGraph.InnerHtml += "<v:line id='line' from='" + Convert.ToString(i * 20 * _FF) + ", 0' to='" + Convert.ToString(i * 20 * _FF) + ", " + Convert.ToString(800 * _FF) + "' position='absolute' strokeColor='blue' strokeWeight='1'></v:line>";
    //    if (_FF == 1)
    //        divGraph.InnerHtml += "<v:RoundRect style='word-break:break-all;position:absolute;left:" + Convert.ToString(i * 20) + "px;width:15px;height:100px' strokeColor='black'>"
    //            + "<v:TextBox inset='1pt,1pt,1pt,1pt' style='font-size:12.2pt;'>" + _ArrLine[i - 1].ToString() + "</v:TextBox>"
    //            + "</v:RoundRect>";
    //}
    //}

    //protected void btnGo_Click(object sender, EventArgs e)
    //{
    //    //int input = int.Parse(txtInput.Text);
    //    string[] str= new string[10];// = txtInput.Text.Trim().Split(' ');

    //    Random rand = new Random();

    //    for (int i = 0; i < str.Length; i++)
    //    {
    //        string color = GetStrColor(rand);
    //        divGraph.InnerHtml += "<v:RoundRect style='word-break:break-all;position:absolute;left:" + Convert.ToString((30 + i * 50) * _FF) + "px;top:60px;width:25px;height:25px' strokeWeight='3' strokeColor='" + color + "'>"
    //            + "<v:TextBox inset='1pt,1pt,1pt,1pt' style='font-size:12.2pt;'>" + int.Parse(str[i]) + "</v:TextBox>"
    //            + "</v:RoundRect>";

    //        divGraph.InnerHtml += DrawOneLine(int.Parse(str[i]), color);
    //    }        
    //}

    //public static string GetStrColor(Random rand)
    //{
    //    Color color = Color.FromArgb(rand.Next());
    //    string strColor = "#" + Convert.ToString(color.ToArgb(), 16).PadLeft(8, '0').Substring(2, 6);
    //    return strColor;
    //}

    //private string DrawOneLine(int input, string color)
    //{
    //    string str = string.Empty;
    //    if (input > 0 && input <= 33)
    //    {            
    //        for (int i = _From; i < _To; i++)
    //        {
    //            if (_TotalBall[input - 1, i - 1] > 0 && _TotalBall[input - 1, i] > 0)
    //                str += "<v:line id='line' from='" + Convert.ToString((i - 1) * 20 * _FF) + ", " + Convert.ToString(_TotalBall[input - 1, i - 1] * 50 * _FF) + "' to='" + Convert.ToString(i * 20 * _FF) + ", " + Convert.ToString(_TotalBall[input - 1, i] * 50 * _FF) + "' position='absolute' strokeColor='" + color + "' strokeWeight='2'></v:line>";

    //            if (_RedBall[input - 1, i] > 0 && _TotalBall[input - 1, i + 1] != 0)
    //            {
    //                switch (_FF.ToString())
    //                {
    //                    case "1":
    //                        str += "<v:RoundRect style='position:absolute;top:" + Convert.ToString((_TotalBall[input - 1, i + 1] + 1) * 50 * _FF - 5) + "px;left:" + Convert.ToString((i + 1) * 20 * _FF + 5) + "px;width:" + Convert.ToString(5 * _FF) + "px;height:" + Convert.ToString(5 * _FF) + "px' strokeColor='" + color + "' strokeWeight='2'>"
    //                            + "</v:RoundRect>";
    //                        break;
    //                    case "0.75":
    //                        str += "<v:RoundRect style='position:absolute;top:" + Convert.ToString((_TotalBall[input - 1, i + 1] + 1) * 50 * _FF + 5) + "px;left:" + Convert.ToString((i + 1) * 20 * _FF + 5) + "px;width:" + Convert.ToString(5 * _FF) + "px;height:" + Convert.ToString(5 * _FF) + "px' strokeColor='" + color + "' strokeWeight='2'>"
    //                            + "</v:RoundRect>";
    //                        break;
    //                    case "0.5":
    //                        str += "<v:RoundRect style='position:absolute;top:" + Convert.ToString((_TotalBall[input - 1, i + 1] + 1) * 50 * _FF + 18) + "px;left:" + Convert.ToString((i + 1) * 20 * _FF + 6) + "px;width:" + Convert.ToString(5 * _FF) + "px;height:" + Convert.ToString(5 * _FF) + "px' strokeColor='" + color + "' strokeWeight='2'>"
    //                            + "</v:RoundRect>";
    //                        break;
    //                    case "0.25":
    //                        str += "<v:RoundRect style='position:absolute;top:" + Convert.ToString((_TotalBall[input - 1, i + 1] + 1) * 50 * _FF + 30) + "px;left:" + Convert.ToString((i + 1) * 20 * _FF + 9) + "px;width:" + Convert.ToString(5 * _FF) + "px;height:" + Convert.ToString(5 * _FF) + "px' strokeColor='" + color + "' strokeWeight='2'>"
    //                            + "</v:RoundRect>";
    //                        break;
    //                }
    //            }
    //        }
    //    }
    //    return str;
    //}
    #endregion
}
