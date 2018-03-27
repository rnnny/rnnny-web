using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;

public partial class _20150518_NormalTest : System.Web.UI.Page
{
    private const int MaxMax = MyTest.MaxMax;
    private ArrayList _ArrRound = new ArrayList();
    private ArrayList _ArrGoal = new ArrayList();
    private DataTable _DT = new DataTable();
    private int[] _BlueBall = new int[MaxMax];
    private int[] _SixSum = new int[MaxMax];
    private int[,] _RedBall = new int[33, MaxMax];
    private int[,] _MiniRedBall = new int[6, MaxMax];
    private int _IDCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        _DT = CreateTable();

        MyTest.ReadFile(_ArrRound,_ArrGoal, _RedBall, _MiniRedBall, _BlueBall, _SixSum, "ball");

        ArrayList al = new ArrayList();
        al = GetSixGoalRound(_ArrRound, _MiniRedBall, _RedBall);

        int upDown = 8;

        Random random = new Random();
        int ii = random.Next(0, al.Count);

        int select = int.Parse(al[ii].ToString());


        if (txtInput.Text == "")
        {
            if (select + upDown >= _ArrRound.Count || select - upDown < 1)
            { haha.InnerHtml = "Select= " + select.ToString() + " 再来一遍！"; }
            else
                DisplaySelect(select, upDown, "");
        }
   
    }

    private void DisplaySelect(int select, int upDown, string input)
    {

        haha.InnerHtml += "Select= " + select.ToString() + " " + _ArrRound[select].ToString() + " " + input + "<input id='checkSelect' type='checkbox' />";
        haha.InnerHtml += NewNumber.DisplayBR();
        //string color = "red";
        for (int i = select + upDown; i > select - upDown; i--)
        {
            if (i == select)
            {
                haha.InnerHtml += "<div title='" + Convert.ToString(i) + "' style='cursor:hand;color:brown;float:left;font-weight:bold; width: 100px; height: 20px;border-style:groove;border-color:red'>" + _ArrRound[i].ToString() + "</div>";
            }
            else
            {
                if(i > 0)
                    haha.InnerHtml += "<div title='" + Convert.ToString(i) + "' style='cursor:hand;color:brown;float:left; width: 100px; height: 20px;border-style:groove;border-color:red'>" + _ArrRound[i].ToString() + "</div>";
                else
                    haha.InnerHtml += "<div title='" + Convert.ToString(i) + "' style='cursor:hand;color:brown;float:left; width: 100px; height: 20px;border-style:groove;border-color:red'>" + i.ToString() + "</div>";
              
            }
            for (int j = 0; j < 33; j++)
            {
                if (i > select)
                {
                    if (_RedBall[j, i] == 0)
                        haha.InnerHtml += "<div title='" + Convert.ToString(j) + "' style='cursor:hand;color:black;float:left; width: 20px; height: 20px;border-style:groove;border-color:red'>00</div>";
                    else
                        haha.InnerHtml += "<div title='" + Convert.ToString(j) + "' style='cursor:hand;color:red;float:left;font-weight:bold; width: 20px; height: 20px;background-color:yellow;border-style:groove;border-color:red'>" + (j + 1).ToString("00") + "</div>";
                }
                else
                {
                    if (i > 1)
                    {
                        if (_RedBall[j, i] == 0)
                            haha.InnerHtml += "<div id='select" + _IDCount.ToString() + Convert.ToString(i) + Convert.ToString(j + 1) + "' title='" + Convert.ToString(j) + "'onclick=SelectClick(id) style='cursor:hand;color:black;float:left; width: 20px; height: 20px;border-style:groove;border-color:red'>00</div>";
                        else
                            haha.InnerHtml += "<div id='select" + _IDCount.ToString() + Convert.ToString(i) + Convert.ToString(j + 1) + "' title='ok'onclick=SelectClick(id) style='cursor:hand;color:black;float:left; width: 20px; height: 20px;border-style:groove;border-color:red'>00</div>";
                    }
                    else
                    {
                        if (i == 1)
                        {
                            if (_RedBall[j, i] == 0)
                                haha.InnerHtml += "<div title='" + Convert.ToString(j) + "' style='cursor:hand;color:black;float:left; width: 20px; height: 20px;border-style:groove;border-color:red'>00</div>";
                            else
                                haha.InnerHtml += "<div title='" + Convert.ToString(j) + "' style='cursor:hand;color:red;float:left;font-weight:bold; width: 20px; height: 20px;background-color:yellow;border-style:groove;border-color:red'>" + (j + 1).ToString("00") + "</div>";            
 
                        }
                        else if (i == 0)
                        {
                            if (input.Contains((j+1).ToString("00")))
                                haha.InnerHtml += "<div id='select" + _IDCount.ToString() + Convert.ToString(i) + Convert.ToString(j + 1) + "' title='ok'onclick=SelectClick(id) style='cursor:hand;color:red;float:left;font-weight:bold;width:20px;height:20px;background-color:yellow;border-style:groove;border-color:blue'>" + (j + 1).ToString("00") + "</div>";
                            else
                                haha.InnerHtml += "<div id='select" + _IDCount.ToString() + Convert.ToString(i) + Convert.ToString(j + 1) + "' title='" + Convert.ToString(j) + "'onclick=SelectClick(id) style='cursor:hand;color:black;float:left; width: 20px; height: 20px;border-style:groove;border-color:red'>00</div>";
      
                        }
                        else
                        {
                            haha.InnerHtml += "<div id='select" + _IDCount.ToString() + Convert.ToString(i) + Convert.ToString(j + 1) + "' title='" + Convert.ToString(j) + "'onclick=SelectClick(id) style='cursor:hand;color:black;float:left; width: 20px; height: 20px;border-style:groove;border-color:red'>00</div>";
                        }
                    }
                }
            }

            haha.InnerHtml += NewNumber.DisplayBR();

        }

    }

    private ArrayList GetSixGoalRound(ArrayList arrRound, int[,] miniRedBall, int[,] redBall)
    {
        ArrayList al = new ArrayList();


        for (int i = arrRound.Count - 1; i > 0; i--)
        {
            int near = 0;
            int repeat = 0;
            int near_22 = 0;
            int repeat_22 = 0;
            if (i != arrRound.Count - 2)
            {
                for (int j = 0; j < miniRedBall.GetLength(0); j++)
                {
                    NewNumber.GetTwoNearRepeat(redBall, miniRedBall[j, i], i, ref near, ref repeat, ref near_22, ref repeat_22);
                }

                if (near + repeat + near_22 + repeat_22 == 6)
                    al.Add(i);
            }
        }


        return al;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string str = txtInput.Text;

        str = str.Replace("\r\n", "-");
        str = str.Replace(" ", "|");
        string[] input = str.Split('-');

        int select = 1;
        int upDown = 8;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].Length == 7)
            {
                int now = 0;
                for (int j = 0; j < _ArrRound.Count; j++)
                {
                    if (input[i] == _ArrRound[j].ToString())
                    {
                        now = j;
                    }
                }
                if(now != 0 && now >= 2)
                    //DisplaySelect(now - 2, upDown, "");
                    DisplaySelect(now - 1, upDown, "");
                else if (now == 1)
                    DisplaySelect(now - 1, upDown, "");

            }
            else
            {
                _IDCount = i + 1;
                DisplaySelect(select, upDown, input[i]);
            }
        }
    }
    protected void btnTest_Click(object sender, EventArgs e)
    {
        NormalDistribution nn = new NormalDistribution();
        List<double> dd;

        string[] str = txtTest.Text.Replace("\r\n", "-").Split('-');

        for (int j = 0; j < str.Length; j++)
        {
            string[] input = str[j].Split('|');
            dd = new List<double>();
            for (int i = 0; i < 6; i++)
                dd.Add(Convert.ToDouble(input[i]));
            double ddd = nn.stdev(dd);
            txtTest.Text += "|\n" +str[j] + "="+ ddd.ToString();
        }

    }
    protected void btnFindFour_Click(object sender, EventArgs e)
    {
        string[] str = txtTest.Text.Replace("\r\n", "-").Replace("\t"," ").Split('-');
        ArrayList al = new ArrayList();
        string strFour="";
        for (int i = 0; i < str.Length; i++)
        {
            int j = i + 1;
            if (j < str.Length && str[i] != str[j])
            {
                strFour = FindFourOK(str[i], str[j], strFour, al);
                if (i == 0)
                    strFour = FindFourOK(str[j], str[i], strFour, al);
            }
        }

        for (int i = 1; i < _ArrRound.Count; i++)
        {
            for (int j = 0; j < al.Count; j++)
            {
                int count = 0; ;
                for (int x = 0; x < 6; x++)
                {
                    string[] strAL = al[j].ToString().Split(' ');
                    for (int y = 0; y < strAL.Length; y++)
                    {
                        if (_MiniRedBall[x, i].ToString() == strAL[y])
                        {
                            count++;
                            break;
                        }
                    }
                }
                if (count == 6 || count == 5)
                {
                    DataRow newRow;

                    newRow = _DT.NewRow();
                    newRow["a11"] = count;
                    newRow["a12"] = al[j].ToString();
                    newRow["round"] = _ArrRound[i].ToString();
                    newRow["a13"] = _MiniRedBall[0, i] + "|" + _MiniRedBall[1, i] + "|" + _MiniRedBall[2, i] + "|" + _MiniRedBall[3, i] + "|" + _MiniRedBall[4, i] + "|" + _MiniRedBall[5, i];
                    newRow["FLAG"] = Define._FourFindStringFlag;//44444400
                    _DT.Rows.Add(newRow);
                }
            }
        }

        System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source = .; Initial Catalog = TestNew; User Id = sa; Password = suyu57501;");
        bcp.DestinationTableName = "dbo.TestOutput";
        bcp.WriteToServer(_DT);
    }
    private string FindFourOK(string strI, string strJ,string strFour,ArrayList al)
    {
        string[] strII = strI.Split(' ')[0].Split('|');
        string[] strJJ = strJ.Split(' ')[0].Split('|');

        if (strI.Split(' ')[1] == strJ.Split(' ')[1])
        {
            string[] strFF = strFour.Split(' ');
            for (int j = 0; j < 6; j++)
            {
                bool find = false;
                for(int i = 0; i < strFF.Length;i++)
                {
                    if(strFF[i] == strJJ[j])
                        find = true;
                }
                if (!find)
                    strFour += strJJ[j] + " ";
            }
        }
        else 
        {
            al.Add(strFour);
            strFour = "";
            for (int j = 0; j < 6; j++)
            {
                strFour += strJJ[j] + " ";
            }
        }
        return strFour;
    }

    private DataTable CreateTable()
    {
        DataTable dt = new DataTable("dirName");

        #region table column

        DataColumn columnID = new DataColumn(); //创建一列
        columnID.DataType = System.Type.GetType("System.Int32"); //数据类型
        columnID.ColumnName = "ID"; //列名
        columnID.AutoIncrement = true; //自动递增ID号
        dt.Columns.Add(columnID);  //添加到table

        DataColumn a0 = new DataColumn();
        a0.DataType = System.Type.GetType("System.Int32");
        a0.ColumnName = "A0";
        dt.Columns.Add(a0);

        DataColumn a1 = new DataColumn();
        a1.DataType = System.Type.GetType("System.Int32");
        a1.ColumnName = "A1";
        dt.Columns.Add(a1);

        DataColumn a2 = new DataColumn();
        a2.DataType = System.Type.GetType("System.Int32");
        a2.ColumnName = "A2";
        dt.Columns.Add(a2);

        DataColumn a3 = new DataColumn();
        a3.DataType = System.Type.GetType("System.Int32");
        a3.ColumnName = "A3";
        dt.Columns.Add(a3);

        DataColumn a4 = new DataColumn();
        a4.DataType = System.Type.GetType("System.Int32");
        a4.ColumnName = "A4";
        dt.Columns.Add(a4);

        DataColumn a5 = new DataColumn();
        a5.DataType = System.Type.GetType("System.Int32");
        a5.ColumnName = "A5";
        dt.Columns.Add(a5);

        DataColumn a6 = new DataColumn();
        a6.DataType = System.Type.GetType("System.Int32");
        a6.ColumnName = "A6";
        dt.Columns.Add(a6);

        DataColumn a7 = new DataColumn();
        a7.DataType = System.Type.GetType("System.Int32");
        a7.ColumnName = "A7";
        dt.Columns.Add(a7);

        DataColumn a8 = new DataColumn();
        a8.DataType = System.Type.GetType("System.Int32");
        a8.ColumnName = "A8";
        dt.Columns.Add(a8);

        DataColumn a9 = new DataColumn();
        a9.DataType = System.Type.GetType("System.Int32");
        a9.ColumnName = "A9";
        dt.Columns.Add(a9);

        DataColumn flag = new DataColumn();
        flag.DataType = System.Type.GetType("System.Int32");
        flag.ColumnName = "FLAG";
        dt.Columns.Add(flag);

        DataColumn a10 = new DataColumn();
        a10.DataType = System.Type.GetType("System.Int32");
        a10.ColumnName = "A10";
        dt.Columns.Add(a10);

        DataColumn a11 = new DataColumn();
        a11.DataType = System.Type.GetType("System.Int32");
        a11.ColumnName = "A11";
        dt.Columns.Add(a11);

        DataColumn a12 = new DataColumn();
        a12.DataType = System.Type.GetType("System.String");
        a12.ColumnName = "A12";
        dt.Columns.Add(a12);

        DataColumn a13 = new DataColumn();
        a13.DataType = System.Type.GetType("System.String");
        a13.ColumnName = "A13";
        dt.Columns.Add(a13);

        DataColumn a14 = new DataColumn();
        a14.DataType = System.Type.GetType("System.String");
        a14.ColumnName = "A14";
        dt.Columns.Add(a14);

        DataColumn a15 = new DataColumn();
        a15.DataType = System.Type.GetType("System.String");
        a15.ColumnName = "A15";
        dt.Columns.Add(a15);

        DataColumn a16 = new DataColumn();
        a16.DataType = System.Type.GetType("System.String");
        a16.ColumnName = "A16";
        dt.Columns.Add(a16);

        DataColumn a17 = new DataColumn();
        a17.DataType = System.Type.GetType("System.String");
        a17.ColumnName = "A17";
        dt.Columns.Add(a17);

        DataColumn a18 = new DataColumn();
        a18.DataType = System.Type.GetType("System.String");
        a18.ColumnName = "A18";
        dt.Columns.Add(a18);

        DataColumn a19 = new DataColumn();
        a19.DataType = System.Type.GetType("System.String");
        a19.ColumnName = "A19";
        dt.Columns.Add(a19);

        DataColumn a20 = new DataColumn();
        a20.DataType = System.Type.GetType("System.String");
        a20.ColumnName = "A20";
        dt.Columns.Add(a20);

        DataColumn a21 = new DataColumn();
        a21.DataType = System.Type.GetType("System.String");
        a21.ColumnName = "A21";
        dt.Columns.Add(a21);

        DataColumn a22 = new DataColumn();
        a22.DataType = System.Type.GetType("System.String");
        a22.ColumnName = "A22";
        dt.Columns.Add(a22);

        DataColumn a23 = new DataColumn();
        a23.DataType = System.Type.GetType("System.String");
        a23.ColumnName = "A23";
        dt.Columns.Add(a23);

        DataColumn a24 = new DataColumn();
        a24.DataType = System.Type.GetType("System.String");
        a24.ColumnName = "A24";
        dt.Columns.Add(a24);

        DataColumn a25 = new DataColumn();
        a25.DataType = System.Type.GetType("System.String");
        a25.ColumnName = "A25";
        dt.Columns.Add(a25);

        DataColumn a26 = new DataColumn();
        a26.DataType = System.Type.GetType("System.String");
        a26.ColumnName = "A26";
        dt.Columns.Add(a26);

        DataColumn a27 = new DataColumn();
        a27.DataType = System.Type.GetType("System.String");
        a27.ColumnName = "A27";
        dt.Columns.Add(a27);

        DataColumn a28 = new DataColumn();
        a28.DataType = System.Type.GetType("System.String");
        a28.ColumnName = "A28";
        dt.Columns.Add(a28);

        DataColumn a29 = new DataColumn();
        a29.DataType = System.Type.GetType("System.String");
        a29.ColumnName = "A29";
        dt.Columns.Add(a29);

        DataColumn a30 = new DataColumn();
        a30.DataType = System.Type.GetType("System.String");
        a30.ColumnName = "A30";
        dt.Columns.Add(a30);

        DataColumn round = new DataColumn();
        round.DataType = System.Type.GetType("System.String");
        round.ColumnName = "ROUND";
        dt.Columns.Add(round);

        #endregion

        //设置主键
        DataColumn[] keys = new DataColumn[1];
        keys[0] = columnID;
        dt.PrimaryKey = keys;


        return dt;
    }
}
