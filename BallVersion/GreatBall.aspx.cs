using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;

public partial class GreatBall : System.Web.UI.Page
{
    #region 变量和常量
    private const int MaxMax = 400;
    private const int MaxCount = 29;
    private ArrayList _Arr = new ArrayList();
    private ArrayList _ArrLine = new ArrayList();
    private string _From = string.Empty;
    private string _To = string.Empty;
    private int _One = 0;
    private int _Two = 0;
    private int[,] _RedBall = new int[33, MaxMax];
    private int _High = 0;
    private int _Low = 0;
    //private string[] _SessionInput = new string[15];
    #endregion

    #region Page_Load
    private void InitPage()
    {
        if (Request.QueryString["ID"].ToString() != "select")
        {
            _From = Request.QueryString["ID"].ToString().Split('-')[0];
            _To = Request.QueryString["ID"].ToString().Split('-')[1];
            _Arr = ReadFile(_From, _To);
        }
        else
            _Arr = ReadFile(30);

        _High = int.Parse(Request.QueryString["Color"].ToString().Split('-')[1]);
        _Low = int.Parse(Request.QueryString["Color"].ToString().Split('-')[0]);

        _One = int.Parse(Request.QueryString["Like"].ToString().Split('|')[0]);
        _Two = int.Parse(Request.QueryString["Like"].ToString().Split('|')[1]);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        haha.InnerHtml = "";

        InitPage();

        Display30Ball();
    }

    #endregion

    #region ReadFile
    private ArrayList ReadFile(int select)
    {
        StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
        string line;
        ArrayList arrSource = new ArrayList();
        int count = 0;
        string round;
        while ((line = smRead.ReadLine()) != null)
        {
            round = line.Substring(0, 5);


            string str = line.Substring(6, 17);
            _ArrLine.Add(round);

            ArrayList arrLine = new ArrayList();
            for (int k = 0; k < str.Split(' ').Length; k++)
            {
                arrLine.Add(str.Split(' ')[k]);
            }
            string[] strLine = new string[33];
            for (int i = 1; i <= 33; i++)
            {
                string a = i.ToString();
                if (i < 10)
                    a = "0" + i.ToString();
                if (arrLine.Contains(a))
                {
                    strLine[i - 1] = a;
                    _RedBall[i - 1, count] = 1;
                }
                else
                {
                    strLine[i - 1] = "";
                    _RedBall[i - 1, count] = 0;
                }
            }
            arrSource.Add(strLine);
            count++;


            if (count == select)
                break;
        }

        return arrSource;
    }
    private ArrayList ReadFile(string from, string to)
    {
        StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
        string line;
        ArrayList arrSource = new ArrayList();
        int count = 0;
        string round;
        bool ok = false;
        while ((line = smRead.ReadLine()) != null)
        {
            round = line.Substring(0, 5);

            if (round == _From)
                ok = true;
            if (ok)
            {
                string str = line.Substring(6, 17);
                _ArrLine.Add(round);

                ArrayList arrLine = new ArrayList();
                for (int k = 0; k < str.Split(' ').Length; k++)
                {
                    arrLine.Add(str.Split(' ')[k]);
                }
                string[] strLine = new string[33];
                for (int i = 1; i <= 33; i++)
                {
                    string a = i.ToString();
                    if (i < 10)
                        a = "0" + i.ToString();
                    if (arrLine.Contains(a))
                    {
                        strLine[i - 1] = a;
                        _RedBall[i - 1, count] = 1;
                    }
                    else
                    {
                        strLine[i - 1] = "";
                        _RedBall[i - 1, count] = 0;
                    }
                }
                arrSource.Add(strLine);
                count++;
            }

            if (round == _To)
                break;
        }

        return arrSource;
    }
    #endregion

    #region Graph
    protected void btnGraph_Click(object sender, EventArgs e)
    {
        //if (txtGraph.Text.Trim() != string.Empty)
        //{
        //    haha.InnerHtml = "";
            
        //    if (txtGraph.Text.Contains("count"))
        //    {
        //        _SessionInput = (string[])Session["SessionInput"];
        //        Session["TxtInput"] = _SessionInput[int.Parse(txtGraph.Text.Trim().Replace("count", ""))];
        //    }
        //    else
        //        Session["TxtInput"] = txtGraph.Text;
        //    Response.Write("<script> window.open('Graph.aspx')</script>");
        //}
    }    
    #endregion 

    #region Display
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        //Display30Ball();
    }


    private void Display30Ball()
    {
        int sum = 9;
        int fiveFrom = 1;
        int fiveTo = sum;
        if (_Arr.Count == 30)
        {
            _One--;
            _Two--;

            fiveFrom--;
            fiveTo--;
        }

        int[] total = new int[33];
        string[] strNow = new string[6];

        int inTotal = 0;
        int goalTotal = 0;

        int selectSub = 0;
        int selectNum = 0;

        int count = 0, sub29 = 0, num29 = 0;

        for (int i = 0; i < _Arr.Count; i++)
        {
            string[] str = (string[])_Arr[i];
            int strNowCount = 0;
            int num = 0;

            string color = "color:black";
            if (i >= fiveFrom && i <= fiveTo)
                color = "color:red";

            for (int j = str.Length - 1; j >= 0; j--)
            {
                if (_Arr.Count == 31 && i == 0)
                {

                }
                else
                {
                    total[j] += _RedBall[j, i];

                    if ((i == _One || i == _Two) && str[j] != string.Empty)
                    {
                        color = "color:blue";
                        haha.InnerHtml = "<div title='" + Convert.ToString(j + 1) + "' style='cursor:hand;" + color + ";float:left; width: 16px; height: 12px;border-style:groove;border-color:red'>" + str[j].ToString() + "</div>" + haha.InnerHtml;
                    }
                    else
                        haha.InnerHtml = "<div title='" + Convert.ToString(j + 1) + "' style='cursor:hand;" + color + ";float:left; width: 16px; height: 12px;border-style:groove'>" + str[j].ToString() + "</div>" + haha.InnerHtml;
                }

                if (str[j].ToString() != string.Empty)
                {
                    strNow[strNowCount] = str[j];
                    num += int.Parse(strNow[strNowCount]);
                    strNowCount++;
                }

            }

            int sub = int.Parse(strNow[0]) - int.Parse(strNow[5]);

            if (_Arr.Count == 31 && i == 0)
            {
                selectSub = sub; selectNum = num;
            }
            else
            {
                if (count != 29)
                {
                    count++; sub29 += sub; num29 += num;
                }
                haha.InnerHtml = "<div style='float:left; width: 60px; height: 12px;border-style:groove'>" + "总和" + num.ToString() + "</div>" + haha.InnerHtml;
                haha.InnerHtml = "<div style='float:left; width: 60px; height: 12px;border-style:groove'>" + "首尾" + sub.ToString() + "</div>" + haha.InnerHtml;

                haha.InnerHtml = "<div style='cursor:hand;float:left;color:red; width: 40px; height: 12px;border-style:groove'>" + (string)_ArrLine[i] + "</div>" + haha.InnerHtml;
            }

            haha.InnerHtml = "<br><br>" + haha.InnerHtml;
        }
        if (_Arr.Count == 31)
        {
            haha.InnerHtml += "<div style='cursor:hand;float:left;color:red; width: 40px; height: 12px;border-style:groove'>" + (string)_ArrLine[0] + "</div>";

            haha.InnerHtml += "<div style='float:left; width: 60px; height: 12px;border-style:groove'>" + "首尾" + selectSub.ToString() + "</div>";
            haha.InnerHtml += "<div style='float:left; width: 60px; height: 12px;border-style:groove'>" + "总和" + selectNum.ToString() + "</div>";

            string[] str = (string[])_Arr[0];

            for (int j = 0; j < str.Length; j++)
            {
                if (_RedBall[j, 0] > 0)
                {
                    if (total[j] >= _Low && total[j] <= _High)
                        haha.InnerHtml += "<div title='" + Convert.ToString(j + 1) + "' style='cursor:hand;font-size:large;color:red;float:left; width: 16px; height: 12px;border-style:groove;border-color:yellow'>" + total[j].ToString() + "</div>";
                    else
                        haha.InnerHtml += "<div title='" + Convert.ToString(j + 1) + "' style='cursor:hand;font-size:large;color:blue;float:left; width: 16px; height: 12px;border-style:groove;border-color:yellow'>" + total[j].ToString() + "</div>";
                }
                else
                {
                    if (total[j] >= _Low && total[j] <= _High)
                        haha.InnerHtml += "<div title='" + Convert.ToString(j + 1) + "' style='cursor:hand;color:red;float:left; width: 16px; height: 12px;border-style:groove'>" + total[j].ToString() + "</div>";
                    else
                        haha.InnerHtml += "<div title='" + Convert.ToString(j + 1) + "' style='cursor:hand;color:blue;float:left; width: 16px; height: 12px;border-style:groove'>" + total[j].ToString() + "</div>";
                }

                if (total[j] >= _Low && total[j] <= _High)
                {
                    inTotal++;
                    if (_RedBall[j, 0] > 0)
                        goalTotal++;
                }
            }

            haha.InnerHtml += "<div style='float:left; color:blue; width:60px; height:12px;border-style:groove'>" + ">" + _Low.ToString() + "<" + _High.ToString() + "=" + inTotal + "</div>";
            if (goalTotal == 6)
                haha.InnerHtml += "<div style='float:left; color:red; width:60px; height:12px;border-style:groove'>" + "命中=" + goalTotal + "</div>";
            else if (goalTotal == 5)
                haha.InnerHtml += "<div style='float:left; color:black; width:60px; height:12px;border-style:groove'>" + "命中=" + goalTotal + "</div>";
            else
                haha.InnerHtml += "<div style='float:left; color:blue; width:60px; height:12px;border-style:groove'>" + "命中=" + goalTotal + "</div>";

            haha.InnerHtml += "<br><br>";
            haha.InnerHtml += HotAnalysisHtml(_Arr, _RedBall, sum, _ArrLine);
        }

        haha.InnerHtml += "<br><br>";
        haha.InnerHtml += "<div style='cursor:hand;float:left; color:red; width: 178px; height: 12px;border-style:groove'>请选择：</div>";

        int[] sumRedBall = new int[33];
        for (int j = 0; j < 33; j++)
        {
            for (int x = 0; x < sum; x++)
            {
                if (_Arr.Count == 31)
                    sumRedBall[j] += _RedBall[j, x + 1];
                else
                    sumRedBall[j] += _RedBall[j, x];
            }

            if (sumRedBall[j] > 0)
                haha.InnerHtml += "<div style='float:left;color:red; width: 16px; height: 12px;border-style:groove;border-color:red'>1</div>";
            else
                haha.InnerHtml += "<div style='float:left;color:blue; width: 16px; height: 12px;border-style:groove;border-color:blue'>0</div>";
        }

        haha.InnerHtml += "<br><br>";
        haha.InnerHtml += "<div style='cursor:hand;float:left; color:red; width: 178px; height: 12px;border-style:groove'>请选择：</div>";

        ArrayList alSession = new ArrayList();
        string colorStDev = "blue";
        if (Session["ToGreatBall"] != null)
            alSession = (ArrayList)Session["ToGreatBall"];
        for (int i = 0; i < total.Length; i++)
        {
            if (alSession.Count != 0 && alSession.Contains(i))
                colorStDev = "red";
            else
                colorStDev = "blue";

            if (_RedBall[i, _One] > 0 || _RedBall[i, _Two] > 0)
                haha.InnerHtml += "<div style='cursor:hand;color:green;float:left; width: 16px; height: 12px;border-style:groove;border-color:" + colorStDev + "'>" + Convert.ToString(i + 1) + "</div>";
            else
                haha.InnerHtml += "<div style='cursor:hand;color:red;float:left; width: 16px; height: 12px;border-style:groove;border-color:" + colorStDev + "'>" + Convert.ToString(i + 1) + "</div>";
        }

        haha.InnerHtml += "<br><br>";
        haha.InnerHtml += "<div style='cursor:hand;float:left; color:red; width: 178px; height: 12px;border-style:groove'>请选择：</div>";
        for (int i = 0; i < total.Length; i++)
        {
            string str = total[i].ToString().Trim();
            //if (total[i].ToString().Trim().Length == 1)
            //    str = "0" + total[i].ToString().Trim();
            if (total[i] >= _Low && total[i] <= _High)
                haha.InnerHtml += "<div id='select" + Convert.ToString(i + 1) + "' title='" + Convert.ToString(i + 1) + "' onclick=SelectClick(id) style='cursor:hand;float:left; width: 16px; height: 12px;border-style:groove;border-color:red'>" + str + "</div>";
            else
                haha.InnerHtml += "<div id='select" + Convert.ToString(i + 1) + "' title='" + Convert.ToString(i + 1) + "' onclick=SelectClick(id) style='cursor:hand;float:left; width: 16px; height: 12px;border-style:groove;border-color:blue'>" + str + "</div>";
        }
        haha.InnerHtml += "<br><br>";
        haha.InnerHtml += "<div style='cursor:hand;float:left;color:red; width: 400px; height: 12px;border-style:groove'>总和80-120；合计>28<39；>" + _Low.ToString() + "<" + _High.ToString() + "命中5、6；样式4、5</div>";

        string[] strChange = new string[15];

        for (int i = 0; i < total.Length; i++)
        {
            if (sumRedBall[i] > 0)
                strChange[total[i]] += "<div style='cursor:hand;color:red;float:left; width: 16px; height: 12px;border-style:groove;border-color:red'>" + Convert.ToString(i + 1) + "</div>";
            else
                strChange[total[i]] += "<div style='cursor:hand;color:red;float:left; width: 16px; height: 12px;border-style:groove;border-color:blue'>" + Convert.ToString(i + 1) + "</div>";

            //_SessionInput[total[i]] += " " + Convert.ToString(i + 1);
        }

        //Session["SessionInput"] = _SessionInput;

        haha.InnerHtml += "<br><br><div><table><tr><td  style='hight:500px;width:30%;border-style:groove'>";

        for (int i = 0; i < strChange.Length; i++)
        {
            if (strChange[i] != null)
                haha.InnerHtml += "<br><br><div id='count" + i.ToString() + "' onclick=SelectCount(id) style='cursor:hand;float:left; color:red; width: 100px; height: 12px;border-style:groove'>Count为" + i.ToString() + "：</div>" + strChange[i];
        }

        haha.InnerHtml += "</td><td id='tdGraph' style='float:left; color:red; hight:500px;width:70%;border-style:groove'></td></tr></table></div>";

        float averageSum = (float)num29 / (float)29;
        float averageHead = (float)sub29 / (float)29;

        haha.InnerHtml += "<br><br>";
        haha.InnerHtml += "<div style='float:left; color:red; width:135px; height:12px;border-style:groove'>" + "29总和=" + averageSum.ToString() + "</div>";
        haha.InnerHtml += "<div style='float:left; color:red; width:135px; height:12px;border-style:groove'>" + "29首尾=" + averageHead.ToString() + "</div>";

    }

    private string HotAnalysisHtml(ArrayList arr, int[,] redBall, int sum, ArrayList arrLine)
    {
        string returnStr = string.Empty;
        string str = string.Empty;

        int total = 0;
        int goal = 0;
        int[] sumRedBall = new int[33];
        int five = 0;
        returnStr += "<div style='float:left; color:red; width: 40px; height: 12px;border-style:groove'>" + (string)arrLine[0] + "</div>";
        for (int j = 0; j < 33; j++)
        {
            for (int x = 0; x < sum; x++)
                sumRedBall[j] += redBall[j, x + 1];

            if (sumRedBall[j] > 0)
            {
                total++;
                if (redBall[j, 0] > 0)
                {
                    five++;
                    goal++;
                    str += "<div style='float:left;font-size:large;color:red; width: 16px; height: 12px;border-style:groove;border-color:yellow'>1</div>";
                }
                else
                    str += "<div style='float:left;font-size:large;color:red; width: 16px; height: 12px;border-style:groove'>1</div>";
            }
            else if (redBall[j, 0] > 0)
                str += "<div style='float:left; color:blue; width: 16px; height: 12px;border-style:groove;border-color:yellow'>0</div>";
            else
                str += "<div style='float:left; color:blue; width: 16px; height: 12px;border-style:groove'>0</div>";
        }

        returnStr += "<div style='float:left; color:blue; width:60px; height:12px;border-style:groove'>" + "包含=" + total.ToString() + "</div>";
        if (five >= 5)
        {
            if (five == 5)
                returnStr += "<div style='float:left; color:black; width:60px; height:12px;border-style:groove'>" + "命中=" + goal.ToString() + "</div>";
            else
                returnStr += "<div style='float:left; color:red; width:60px; height:12px;border-style:groove'>" + "命中=" + goal.ToString() + "</div>";
        }
        else
            returnStr += "<div style='float:left; color:blue; width:60px; height:12px;border-style:groove'>" + "命中=" + goal.ToString() + "</div>";

        returnStr += str + "<br><br>";

        return returnStr;
    }
    #endregion
}
