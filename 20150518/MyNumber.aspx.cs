using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;

public partial class _20150518_MyNumber : System.Web.UI.Page
{
    private const int MaxMax = MyTest.MaxMax;
    private ArrayList _ArrRound = new ArrayList();
    private ArrayList _ArrGoal = new ArrayList();
    private DataTable _DT = new DataTable();
    private int[] _BlueBall = new int[MaxMax];
    private int[] _SixSum = new int[MaxMax];
    private int[,] _RedBall = new int[33, MaxMax];
    private bool _One = false;
    private string[] _MiniRedNow = new string[6];
    private int[,] _MiniRedBall = new int[6, MaxMax];
    private string _UPUP_NoSelect = string.Empty;
    private int _UPUP_NoCount = 0;
    private string _UPUP_NoSelectEndSelect = string.Empty;
    private int _UPUP_33_Count = 0;
    private int _People_NoCount = 0;
    private string[] _People_Str = new string[10];
    private string _People_NoSelect = string.Empty;
    private string _People_NoSelectEndSelect = string.Empty;
    private string _NearRepeat22_NoSelect = string.Empty;
    private int _NearRepeat22_NoCount = 0;
    private string _NearRepeat22_NoSelectEndSelect = string.Empty;
    private string _Repeat22_Select = string.Empty;
    private string _Repeat22_SelectEndSelect = string.Empty;
    //private int _No_NormalCount = 0;
    private int _MiniRedCount = 0;
    private string[] _UpSum30Ball = new string[33];
    private string[] _UpUpSumBall = new string[33];
    private string _NoSelectBlueBall = string.Empty;
    private string _NoSelectSixSum = string.Empty;
    private string _TwoDimension2 = string.Empty;
    private string _TwoDimension3 = string.Empty;
    private int GameOver = 1;
    private string[] _StrRedBall01 = new string[10];
    private string _PrimeStr = string.Empty;
    private string _TwoStr = string.Empty;
    private string _NearRepeatStr = string.Empty;
    private hangzhou _HangZhou = new hangzhou();
    //private string _ThreePTNRStr = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {   
        GameOver = 1;//模拟为1，计算结果为2.  下面用做输入参数

        _HangZhou.Sum = 0;// 116.4;//162.9
        _HangZhou.LeftRight = 0;// 30.9;//17.2
        _HangZhou.BlueBall = 0;// 6.9;//6.9
        _HangZhou.UpUp = 0;// 25.8;//22.2
        _HangZhou.Data33 = "";

        _HangZhou.Two = 0;// 4.1;//2.5
        _HangZhou.Prime = 0;// 1.7;//2.8
        _HangZhou.NearRepeat = 0;// 4.1;//3.3
        _HangZhou.TPNRSum = 0;// 5.4;//10.3

        _HangZhou.Mini0 = 0;//0.1
        _HangZhou.Mini1 = 0;//8.1
        _HangZhou.Mini2 = 0;//12.9
        _HangZhou.Mini3 = 0;//16.5
        _HangZhou.Mini4 = 0;//26.3
        _HangZhou.Mini5 = 0;//23.1
        
        txtInput.Text = "2018018NSelect-2|9|11|15|18|22|24|25|28|31|33| 黑色-4|5|7|8|10|14|16|17|23|29| 绿色- 蓝色-1|3|13|20|21|24|26|27|28|31| 红色-11|12|18|25| 棕色-2|6|9|15|19|22|30|32|33| UpNumber-2|0|1|24|9|1|12|5|4|7|1|0|0|11|3|15|8|0|6|3|3|5|7|4|0|1|0|4|12|1|4|1|3";  
        
        //string[] strUP;
        //if (txtInput.Text != "")
        //{
        //    strUP = txtInput.Text.Split(' ')[6].Split('-')[1].Split('|');
        //}

        if (txtInput.Text != "")
        {
            _UpUpSumBall = txtInput.Text.Split(' ')[6].Split('-')[1].Split('|');
            for (int i = 0; i < _UpUpSumBall.Length; i++)
            {
                _UPUP_33_Count += int.Parse(_UpUpSumBall[i]);
            }
        }

        _MiniRedCount = 2;
        //two:2 prime:3 nearrepeat:4 sum:90  rightLeft<30 upup<30 sum33>40
        _TwoStr = "|610_|->234";//A16--214313
        _PrimeStr = "|650_|->234";//A22--112322
        _NearRepeatStr = "|650_|->234";//A28--521335  

        _UPUP_NoSelect = "";//
        _UPUP_NoCount = 2;     
   
        _People_NoCount = 1;
        _People_NoSelect = "";//01 21 15

        _People_Str[0] = "";
        _People_Str[1] = "";
        _People_Str[2] = "";
        _People_Str[3] = "";
        _People_Str[4] = "";
        _People_Str[5] = "";
        _People_Str[6] = "";
        _People_Str[7] = "";
        _People_Str[8] = "";
        _People_Str[9] = "";

        _NearRepeat22_NoSelect = "";//
        _NearRepeat22_NoCount = 2;

        _Repeat22_Select = "";//

        //06|14|19|22
        //17|21|32
        string str = "05 05 04 02 05 06 06 05 06 04 08 07 06 07 04 02 06 06 06 11 06 02 04 02 07 09 07 05 05 03 09 04 06";

        _UpSum30Ball = str.Split(' ');//30累计




        _TwoDimension3 = "";
        _TwoDimension2 = "";

        _DT = CreateTable();

        MyTest.ReadFile(_ArrRound,_ArrGoal, _RedBall, _MiniRedBall, _BlueBall, _SixSum, "ball");
        //ReadFile();

        if(GameOver == 1)            
            MyGoal.InnerHtml += NewNumber.DisplayStr("GameOver:生成模拟", "blue");
        else
            MyGoal.InnerHtml += NewNumber.DisplayStr("GameOver:分析结果", "blue");

        MyGoal.InnerHtml += NewNumber.DisplayBR();


    }

    //private string DisplayStr(string input, string color)
    //{
    //    return "<span style='color:" + color + "'>" + input + "</span>";
    //}

    //private string DisplayBR()
    //{
    //    return "<br>";//"<br><br>";
    //}
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

    private DataTable CreateTableHangZhou()
    {
        DataTable dt = new DataTable("dirName");

        #region table column

        DataColumn columnID = new DataColumn(); //创建一列
        columnID.DataType = System.Type.GetType("System.String"); //数据类型
        columnID.ColumnName = "Round"; //列名
        dt.Columns.Add(columnID);  //添加到table

        DataColumn flag = new DataColumn(); //创建一列
        flag.DataType = System.Type.GetType("System.String"); //数据类型
        flag.ColumnName = "Flag"; //列名
        dt.Columns.Add(flag);  //添加到table

        DataColumn resultTwo = new DataColumn(); //创建一列
        resultTwo.DataType = System.Type.GetType("System.String"); //数据类型
        resultTwo.ColumnName = "ResultTwo"; //列名
        dt.Columns.Add(resultTwo);  //添加到table

        DataColumn resultOne = new DataColumn(); //创建一列
        resultOne.DataType = System.Type.GetType("System.String"); //数据类型
        resultOne.ColumnName = "ResultOne"; //列名
        dt.Columns.Add(resultOne);  //添加到table

        DataColumn a0 = new DataColumn();
        a0.DataType = System.Type.GetType("System.Int32");
        a0.ColumnName = "UPUP_NoCount";
        dt.Columns.Add(a0);

        DataColumn a1 = new DataColumn();
        a1.DataType = System.Type.GetType("System.Int32");
        a1.ColumnName = "NearRepeat22_NoCount";
        dt.Columns.Add(a1);

        DataColumn a2 = new DataColumn();
        a2.DataType = System.Type.GetType("System.Int32");
        a2.ColumnName = "Repeat22_Select";
        dt.Columns.Add(a2);

        DataColumn a3 = new DataColumn();
        a3.DataType = System.Type.GetType("System.Int32");
        a3.ColumnName = "StrMiniRed";
        dt.Columns.Add(a3);

        DataColumn a4 = new DataColumn();
        a4.DataType = System.Type.GetType("System.Int32");
        a4.ColumnName = "Str456";
        dt.Columns.Add(a4);

        DataColumn a5 = new DataColumn();
        a5.DataType = System.Type.GetType("System.Int32");
        a5.ColumnName = "IsPrime";
        dt.Columns.Add(a5);

        DataColumn a6 = new DataColumn();
        a6.DataType = System.Type.GetType("System.Int32");
        a6.ColumnName = "IsTwo";
        dt.Columns.Add(a6);

        DataColumn a7 = new DataColumn();
        a7.DataType = System.Type.GetType("System.Int32");
        a7.ColumnName = "IsNearRepeat";
        dt.Columns.Add(a7);

        DataColumn a8 = new DataColumn();
        a8.DataType = System.Type.GetType("System.Int32");
        a8.ColumnName = "SubSub";
        dt.Columns.Add(a8);

        DataColumn a9 = new DataColumn();
        a9.DataType = System.Type.GetType("System.Int32");
        a9.ColumnName = "SumUp30Ball";
        dt.Columns.Add(a9);

        DataColumn sumUpUpBall = new DataColumn();
        sumUpUpBall.DataType = System.Type.GetType("System.Int32");
        sumUpUpBall.ColumnName = "SumUpUpBall";
        dt.Columns.Add(sumUpUpBall);

        DataColumn a10 = new DataColumn();
        a10.DataType = System.Type.GetType("System.Int32");
        a10.ColumnName = "PrimeTwoNearRepeat";
        dt.Columns.Add(a10);

        DataColumn a11 = new DataColumn();
        a11.DataType = System.Type.GetType("System.Int32");
        a11.ColumnName = "SixBallSum";
        dt.Columns.Add(a11);        

        DataColumn a23 = new DataColumn();
        a23.DataType = System.Type.GetType("System.Int32");
        a23.ColumnName = "FindCount0";
        dt.Columns.Add(a23);

        DataColumn a24 = new DataColumn();
        a24.DataType = System.Type.GetType("System.Int32");
        a24.ColumnName = "FindCount1";
        dt.Columns.Add(a24);

        DataColumn a25 = new DataColumn();
        a25.DataType = System.Type.GetType("System.Int32");
        a25.ColumnName = "FindCount2";
        dt.Columns.Add(a25);

        DataColumn a26 = new DataColumn();
        a26.DataType = System.Type.GetType("System.Int32");
        a26.ColumnName = "FindCount3";
        dt.Columns.Add(a26);

        DataColumn a27 = new DataColumn();
        a27.DataType = System.Type.GetType("System.Int32");
        a27.ColumnName = "FindCount4";
        dt.Columns.Add(a27);

        DataColumn a28 = new DataColumn();
        a28.DataType = System.Type.GetType("System.Int32");
        a28.ColumnName = "FindCount5";
        dt.Columns.Add(a28);

        DataColumn a29 = new DataColumn();
        a29.DataType = System.Type.GetType("System.Int32");
        a29.ColumnName = "FindCount6";
        dt.Columns.Add(a29);

        DataColumn a30 = new DataColumn();
        a30.DataType = System.Type.GetType("System.Int32");
        a30.ColumnName = "FindCount7";
        dt.Columns.Add(a30);

        DataColumn a12 = new DataColumn();
        a12.DataType = System.Type.GetType("System.Decimal");
        a12.ColumnName = "Data";
        dt.Columns.Add(a12);

        DataColumn a13 = new DataColumn();
        a13.DataType = System.Type.GetType("System.Decimal");
        a13.ColumnName = "Data1";
        dt.Columns.Add(a13);

        DataColumn a14 = new DataColumn();
        a14.DataType = System.Type.GetType("System.Decimal");
        a14.ColumnName = "Data2";
        dt.Columns.Add(a14);

        DataColumn a15 = new DataColumn();
        a15.DataType = System.Type.GetType("System.Decimal");
        a15.ColumnName = "Data3";
        dt.Columns.Add(a15);

        DataColumn a16 = new DataColumn();
        a16.DataType = System.Type.GetType("System.String");
        a16.ColumnName = "Data33";
        dt.Columns.Add(a16);

        DataColumn a17 = new DataColumn();
        a17.DataType = System.Type.GetType("System.Decimal");
        a17.ColumnName = "Mini0";
        dt.Columns.Add(a17);

        DataColumn a18 = new DataColumn();
        a18.DataType = System.Type.GetType("System.Decimal");
        a18.ColumnName = "Mini1";
        dt.Columns.Add(a18);

        DataColumn a19 = new DataColumn();
        a19.DataType = System.Type.GetType("System.Decimal");
        a19.ColumnName = "Mini2";
        dt.Columns.Add(a19);

        DataColumn a20 = new DataColumn();
        a20.DataType = System.Type.GetType("System.Decimal");
        a20.ColumnName = "Mini3";
        dt.Columns.Add(a20);

        DataColumn a21 = new DataColumn();
        a21.DataType = System.Type.GetType("System.Decimal");
        a21.ColumnName = "Mini4";
        dt.Columns.Add(a21);

        DataColumn a22 = new DataColumn();
        a22.DataType = System.Type.GetType("System.Decimal");
        a22.ColumnName = "Mini5";
        dt.Columns.Add(a22);

        DataColumn two = new DataColumn();
        two.DataType = System.Type.GetType("System.Decimal");
        two.ColumnName = "TwoSpss";
        dt.Columns.Add(two);

        DataColumn prime = new DataColumn();
        prime.DataType = System.Type.GetType("System.Decimal");
        prime.ColumnName = "PrimeSpss";
        dt.Columns.Add(prime);

        DataColumn nearRepeat = new DataColumn();
        nearRepeat.DataType = System.Type.GetType("System.Decimal");
        nearRepeat.ColumnName = "NearRepeatSpss";
        dt.Columns.Add(nearRepeat);

        DataColumn tPNRSum = new DataColumn();
        tPNRSum.DataType = System.Type.GetType("System.Decimal");
        tPNRSum.ColumnName = "TPNRSum";
        dt.Columns.Add(tPNRSum);

        DataColumn add0 = new DataColumn();
        add0.DataType = System.Type.GetType("System.String");
        add0.ColumnName = "Add0";
        dt.Columns.Add(add0);

        DataColumn add1 = new DataColumn();
        add1.DataType = System.Type.GetType("System.String");
        add1.ColumnName = "Add1";
        dt.Columns.Add(add1);

        DataColumn add2 = new DataColumn();
        add2.DataType = System.Type.GetType("System.String");
        add2.ColumnName = "Add2";
        dt.Columns.Add(add2);

        DataColumn add3 = new DataColumn();
        add3.DataType = System.Type.GetType("System.String");
        add3.ColumnName = "Add3";
        dt.Columns.Add(add3);

        DataColumn add4 = new DataColumn();
        add4.DataType = System.Type.GetType("System.Int32");
        add4.ColumnName = "Add4";
        dt.Columns.Add(add4);

        DataColumn add5 = new DataColumn();
        add5.DataType = System.Type.GetType("System.Int32");
        add5.ColumnName = "Add5";
        dt.Columns.Add(add5);

        DataColumn add6 = new DataColumn();
        add6.DataType = System.Type.GetType("System.Int32");
        add6.ColumnName = "Add6";
        dt.Columns.Add(add6);

        DataColumn add7 = new DataColumn();
        add7.DataType = System.Type.GetType("System.Decimal");
        add7.ColumnName = "Add7";
        dt.Columns.Add(add7);

        DataColumn add8 = new DataColumn();
        add8.DataType = System.Type.GetType("System.Decimal");
        add8.ColumnName = "Add8";
        dt.Columns.Add(add8);

        DataColumn add9 = new DataColumn();
        add9.DataType = System.Type.GetType("System.Decimal");
        add9.ColumnName = "Add9";
        dt.Columns.Add(add9);
        #endregion

        //设置主键
        DataColumn[] keys = new DataColumn[1];
        keys[0] = columnID;
        dt.PrimaryKey = keys;


        return dt;
    }
    

    protected void btnOK_Click(object sender, EventArgs e)
    {
        GameOver = 1;
        int sumLast = _MiniRedBall[0,1] + _MiniRedBall[1,1] + _MiniRedBall[2,1] + _MiniRedBall[3,1] + _MiniRedBall[4,1] + _MiniRedBall[5,1];
        for (int a1 = 1; a1 <= 33; a1++)
            for (int a2 = 1; a2 <= 33; a2++)
                for (int a3 = 1; a3 <= 33; a3++)
                    for (int a4 = 1; a4 <= 33; a4++)
                        for (int a5 = 1; a5 <= 33; a5++)
                            for (int a6 = 1; a6 <= 33; a6++)
                            {
                                if (a1 < a2 && a2 < a3 && a3 < a4 && a4 < a5 && a5 < a6)
                                {
                                    int[] begin = new int[4];
                                    int[] end = new int[10];
                                    string strBegin = "";
                                    string strEnd = "";
                                    if (a1 < 10)
                                    {
                                        begin[0]++;
                                        end[int.Parse(a1.ToString().Substring(0, 1))]++;
                                    }
                                    else
                                    {
                                        begin[int.Parse(a1.ToString().Substring(0, 1))]++;
                                        end[int.Parse(a1.ToString().Substring(1, 1))]++;
                                    }
                                    if (a2 < 10)
                                    {
                                        begin[0]++;
                                        end[int.Parse(a2.ToString().Substring(0, 1))]++;
                                    }
                                    else
                                    {
                                        begin[int.Parse(a2.ToString().Substring(0, 1))]++;
                                        end[int.Parse(a2.ToString().Substring(1, 1))]++;
                                    }
                                    if (a3 < 10)
                                    {
                                        begin[0]++;
                                        end[int.Parse(a3.ToString().Substring(0, 1))]++;
                                    }
                                    else
                                    {
                                        begin[int.Parse(a3.ToString().Substring(0, 1))]++;
                                        end[int.Parse(a3.ToString().Substring(1, 1))]++;
                                    }
                                    if (a4 < 10)
                                    {
                                        begin[0]++;
                                        end[int.Parse(a4.ToString().Substring(0, 1))]++;
                                    }
                                    else
                                    {
                                        begin[int.Parse(a4.ToString().Substring(0, 1))]++;
                                        end[int.Parse(a4.ToString().Substring(1, 1))]++;
                                    }
                                    if (a5 < 10)
                                    {
                                        begin[0]++;
                                        end[int.Parse(a5.ToString().Substring(0, 1))]++;
                                    }
                                    else
                                    {
                                        begin[int.Parse(a5.ToString().Substring(0, 1))]++;
                                        end[int.Parse(a5.ToString().Substring(1, 1))]++;
                                    }
                                    if (a6 < 10)
                                    {
                                        begin[0]++;
                                        end[int.Parse(a6.ToString().Substring(0, 1))]++;
                                    }
                                    else
                                    {
                                        begin[int.Parse(a6.ToString().Substring(0, 1))]++;
                                        end[int.Parse(a6.ToString().Substring(1, 1))]++;
                                    }
                                    bool endBool = false;
                                    bool beginBool = false;
                                    int endSum = 0;
                                    for (int x = 0; x < 10; x++)
                                    {
                                        if (end[x] != 0)
                                        {
                                            if (end[x] >= 2)
                                                endBool = true;
                                            for (int y = 0; y < end[x]; y++)
                                            {
                                                endSum += x;
                                                strEnd += x.ToString();
                                            }
                                        }
                                    }

                                    for (int x = 0; x < 4; x++)
                                    {
                                        if (begin[x] != 0)
                                        {
                                            if (begin[x] >= 4)
                                                beginBool = true;
                                            for (int y = 0; y < begin[x]; y++)
                                            {
                                                strBegin += x.ToString();
                                            }
                                        }
                                    }
                                    int sumNow = a1 + a2 + a3 + a4 + a5 + a6;
                                    if (beginBool && endBool && endSum >= 17 && endSum <= 35 && sumNow >=41 && sumNow <=159)//(Math.Abs(sumLast - sumNow) == 12)
                                    {
                                        int prime = MyTest.ISPrime(a1) + MyTest.ISPrime(a2) + MyTest.ISPrime(a3) + MyTest.ISPrime(a4) + MyTest.ISPrime(a5) + MyTest.ISPrime(a6);
                                        int two = MyTest.ISTwo(a1) + MyTest.ISTwo(a2) + MyTest.ISTwo(a3) + MyTest.ISTwo(a4) + MyTest.ISTwo(a5) + MyTest.ISTwo(a6);
                                        int nearRepeat = MyTest.ISNearRepeat(_RedBall, a1, GameOver) + MyTest.ISNearRepeat(_RedBall, a2, GameOver) + MyTest.ISNearRepeat(_RedBall, a3, GameOver) + MyTest.ISNearRepeat(_RedBall, a4, GameOver) + MyTest.ISNearRepeat(_RedBall, a5, GameOver) + MyTest.ISNearRepeat(_RedBall, a6, GameOver);
                                        int repeat = MyTest.ISRepeat(_RedBall, a1, GameOver) + MyTest.ISRepeat(_RedBall, a2, GameOver) + MyTest.ISRepeat(_RedBall, a3, GameOver) + MyTest.ISRepeat(_RedBall, a4, GameOver) + MyTest.ISRepeat(_RedBall, a5, GameOver) + MyTest.ISRepeat(_RedBall, a6, GameOver);

                                        //int sum30 = int.Parse(_UpSum30Ball[a1 - 1]) + int.Parse(_UpSum30Ball[a2 - 1]) + int.Parse(_UpSum30Ball[a3 - 1]) + int.Parse(_UpSum30Ball[a4 - 1]) + int.Parse(_UpSum30Ball[a5 - 1]) + int.Parse(_UpSum30Ball[a6 - 1]);

                                        //int sumUPUP = int.Parse(_UpUpSumBall[a1 - 1]) + int.Parse(_UpUpSumBall[a2 - 1]) + int.Parse(_UpUpSumBall[a3 - 1]) + int.Parse(_UpUpSumBall[a4 - 1]) + int.Parse(_UpUpSumBall[a5 - 1]) + int.Parse(_UpUpSumBall[a6 - 1]);
                                        if ((repeat <= 3 && nearRepeat >= 1 && nearRepeat <= 4) || repeat == 4)
                                        {

                                            DataRow newRow;
                                            newRow = _DT.NewRow();
                                            for (int j = 1; j <= _ArrRound.Count - 1; j++)
                                            {
                                                if (_RedBall[a1 - 1, j] + _RedBall[a2 - 1, j] + _RedBall[a3 - 1, j] + _RedBall[a4 - 1, j] + _RedBall[a5 - 1, j] + _RedBall[a6 - 1, j] >= 4)
                                                {
                                                    newRow["a2"] = j;
                                                    break;
                                                }
                                            }
                                            int max = int.Parse(_UpUpSumBall[a1 - 1]);
                                            int min = int.Parse(_UpUpSumBall[a1 - 1]);

                                            if (int.Parse(_UpUpSumBall[a2 - 1]) > max)
                                                max = int.Parse(_UpUpSumBall[a2 - 1]);
                                            if (int.Parse(_UpUpSumBall[a3 - 1]) > max)
                                                max = int.Parse(_UpUpSumBall[a3 - 1]);
                                            if (int.Parse(_UpUpSumBall[a4 - 1]) > max)
                                                max = int.Parse(_UpUpSumBall[a4 - 1]);
                                            if (int.Parse(_UpUpSumBall[a5 - 1]) > max)
                                                max = int.Parse(_UpUpSumBall[a5 - 1]);
                                            if (int.Parse(_UpUpSumBall[a6 - 1]) > max)
                                                max = int.Parse(_UpUpSumBall[a6 - 1]);

                                            if (int.Parse(_UpUpSumBall[a2 - 1]) < min)
                                                min = int.Parse(_UpUpSumBall[a2 - 1]);
                                            if (int.Parse(_UpUpSumBall[a3 - 1]) < min)
                                                min = int.Parse(_UpUpSumBall[a3 - 1]);
                                            if (int.Parse(_UpUpSumBall[a4 - 1]) < min)
                                                min = int.Parse(_UpUpSumBall[a4 - 1]);
                                            if (int.Parse(_UpUpSumBall[a5 - 1]) < min)
                                                min = int.Parse(_UpUpSumBall[a5 - 1]);
                                            if (int.Parse(_UpUpSumBall[a6 - 1]) < min)
                                                min = int.Parse(_UpUpSumBall[a6 - 1]);
                                            int sumUp30Ball =/*6 +*/ int.Parse(_UpSum30Ball[a1 - 1]) + int.Parse(_UpSum30Ball[a2 - 1]) + int.Parse(_UpSum30Ball[a3 - 1]) + int.Parse(_UpSum30Ball[a4 - 1]) + int.Parse(_UpSum30Ball[a5 - 1]) + int.Parse(_UpSum30Ball[a6 - 1]);
                                            int sumUpUp = int.Parse(_UpUpSumBall[a1 - 1]) + int.Parse(_UpUpSumBall[a2 - 1]) + int.Parse(_UpUpSumBall[a3 - 1]) + int.Parse(_UpUpSumBall[a4 - 1]) + int.Parse(_UpUpSumBall[a5 - 1]) + int.Parse(_UpUpSumBall[a6 - 1]);

                                            newRow["A2"] = sumUp30Ball;
                                            newRow["A3"] = sumUpUp;
                                            newRow["A4"] = min;
                                            newRow["A5"] = max;
                                            newRow["A6"] = sumNow;
                                            newRow["A7"] = repeat;
                                            newRow["A8"] = nearRepeat - repeat;
                                            newRow["A9"] = two;
                                            newRow["A10"] = prime;
                                            newRow["A11"] = nearRepeat;
                                            newRow["A12"] = a1.ToString("00") + "|" + a2.ToString("00") + "|" + a3.ToString("00") + "|" + a4.ToString("00") + "|" + a5.ToString("00") + "|" + a6.ToString("00");

                                            if (_RedBall[a1 - 1, 1] + _RedBall[a2 - 1, 1] + _RedBall[a3 - 1, 1] + _RedBall[a4 - 1, 1] + _RedBall[a5 - 1, 1] + _RedBall[a6 - 1, 1] == 4)
                                                newRow["A13"] = 14;
                                            else if (_RedBall[a1 - 1, 2] + _RedBall[a2 - 1, 2] + _RedBall[a3 - 1, 2] + _RedBall[a4 - 1, 2] + _RedBall[a5 - 1, 2] + _RedBall[a6 - 1, 2] == 4)
                                                newRow["A13"] = 24;
                                            else if (_RedBall[a1 - 1, 3] + _RedBall[a2 - 1, 3] + _RedBall[a3 - 1, 3] + _RedBall[a4 - 1, 3] + _RedBall[a5 - 1, 3] + _RedBall[a6 - 1, 3] == 4)
                                                newRow["A13"] = 34;
                                            else if (_RedBall[a1 - 1, 1] + _RedBall[a2 - 1, 1] + _RedBall[a3 - 1, 1] + _RedBall[a4 - 1, 1] + _RedBall[a5 - 1, 1] + _RedBall[a6 - 1, 1] == 3)
                                                newRow["A13"] = 13;
                                            else if (_RedBall[a1 - 1, 2] + _RedBall[a2 - 1, 2] + _RedBall[a3 - 1, 2] + _RedBall[a4 - 1, 2] + _RedBall[a5 - 1, 2] + _RedBall[a6 - 1, 2] == 3)
                                                newRow["A13"] = 23;
                                            else if (_RedBall[a1 - 1, 3] + _RedBall[a2 - 1, 3] + _RedBall[a3 - 1, 3] + _RedBall[a4 - 1, 3] + _RedBall[a5 - 1, 3] + _RedBall[a6 - 1, 3] == 3)
                                                newRow["A13"] = 33;
                                            //newRow["A14"] = strMiniRed;//"ok";//MiniRed
                                            //newRow["A15"] = countPeople;//GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[0]);
                                            //newRow["A16"] = b1 + b2 + b3;
                                            //newRow["A17"] = styleUpSum30;
                                            //newRow["A17"] = 
                                            //newRow["A16"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[1]);
                                            //newRow["A17"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[2]);
                                            //newRow["A18"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[3]);
                                            //newRow["A19"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[4]);
                                            //newRow["A20"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[5]);
                                            //newRow["A21"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[6]);
                                            //newRow["A22"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[7]);
                                            newRow["A23"] = NewNumber.GetTwoNearRepeatRound(_RedBall, a1, a2, a3, a4, a5, a6, GameOver - 1);

                                            int[] sub = new int[7];
                                            sub[0] = a1;
                                            sub[1] = a2 - a1;
                                            sub[2] = a3 - a2;
                                            sub[3] = a4 - a3;
                                            sub[4] = a5 - a4;
                                            sub[5] = a6 - a5;
                                            sub[6] = 34 - a6;
                                            newRow["A24"] = sub[0].ToString("00") + "-" + sub[1].ToString("00") + "-" + sub[2].ToString("00") + "-" + sub[3].ToString("00") + "-" + sub[4].ToString("00") + "-" + sub[5].ToString("00") + "-" + sub[6].ToString("00");//无用
                                            newRow["A25"] = MyTest.GetSubStr(sub);
                                            int maxSub = 0;
                                            for (int xx = 0; xx <= 6; xx++)
                                            {
                                                if (sub[xx] > maxSub)
                                                    maxSub = sub[xx];
                                            }
                                            newRow["a27"] = maxSub.ToString("00");
                                            string strC = "";

                                            if (int.Parse(_UpSum30Ball[a1 - 1]) >= 9)
                                                newRow["a26"] = "A" + newRow["a26"];
                                            else if (int.Parse(_UpSum30Ball[a1 - 1]) >= 3)
                                                newRow["a26"] += "B";
                                            else
                                                strC += "C";

                                            if (int.Parse(_UpSum30Ball[a2 - 1]) >= 9)
                                                newRow["a26"] = "A" + newRow["a26"];
                                            else if (int.Parse(_UpSum30Ball[a2 - 1]) >= 3)
                                                newRow["a26"] += "B";
                                            else
                                                strC += "C";

                                            if (int.Parse(_UpSum30Ball[a3 - 1]) >= 9)
                                                newRow["a26"] = "A" + newRow["a26"];
                                            else if (int.Parse(_UpSum30Ball[a3 - 1]) >= 3)
                                                newRow["a26"] += "B";
                                            else
                                                strC += "C";

                                            if (int.Parse(_UpSum30Ball[a4 - 1]) >= 9)
                                                newRow["a26"] = "A" + newRow["a26"];
                                            else if (int.Parse(_UpSum30Ball[a4 - 1]) >= 3)
                                                newRow["a26"] += "B";
                                            else
                                                strC += "C";

                                            if (int.Parse(_UpSum30Ball[a5 - 1]) >= 9)
                                                newRow["a26"] = "A" + newRow["a26"];
                                            else if (int.Parse(_UpSum30Ball[a5 - 1]) >= 3)
                                                newRow["a26"] += "B";
                                            else
                                                strC += "C";

                                            if (int.Parse(_UpSum30Ball[a6 - 1]) >= 9)
                                                newRow["a26"] = "A" + newRow["a26"];
                                            else if (int.Parse(_UpSum30Ball[a6 - 1]) >= 3)
                                                newRow["a26"] += "B";
                                            else
                                                strC += "C";

                                            newRow["a26"] += strC;

                                            //newRow["A26"] = SimpleRedSix210(a1, _MiniRedBall[0, GameOver]) + SimpleRedSix210(a2, _MiniRedBall[1, GameOver]) + SimpleRedSix210(a3, _MiniRedBall[2, GameOver]) + SimpleRedSix210(a4, _MiniRedBall[3, GameOver]) + SimpleRedSix210(a5, _MiniRedBall[4, GameOver]) + SimpleRedSix210(a6, _MiniRedBall[5, GameOver]);
                                            //newRow["A26"] = 7 - countOK;
                                            //newRow["A26"] = strTwoDimensionChange;// MyTest.ReturnChangeStr(_TwoDimension2, _TwoDimension3, a1, a2, a3, a4, a5, a6);
                                            newRow["A27"] = strBegin;
                                            newRow["A28"] = strEnd;
                                            // strSimple 
                                            newRow["A29"] = SimpleRedSix210(a1, _MiniRedBall[0, GameOver]) + SimpleRedSix210(a2, _MiniRedBall[1, GameOver]) + SimpleRedSix210(a3, _MiniRedBall[2, GameOver]) + SimpleRedSix210(a4, _MiniRedBall[3, GameOver]) + SimpleRedSix210(a5, _MiniRedBall[4, GameOver]) + SimpleRedSix210(a6, _MiniRedBall[5, GameOver]);
                                            //newRow["A30"] = "UpSum30:" + sumUp30Ball.ToString() + "_UPUP:" + sumUpUp.ToString() + "_UP33:" +_UPUP_33_Count.ToString();
                                            newRow["A30"] = endSum;
                                            newRow["FLAG"] = Define._MyNumber88Flag;
                                            newRow["ROUND"] = a6 - a1;
                                            _DT.Rows.Add(newRow);
                                        }
                                    }
                                }
                            }

        if (!_One)
        {
            System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source = .; Initial Catalog = Test; User Id = sa; Password = suyu57501;");
            bcp.DestinationTableName = "dbo.TestOutput";
            bcp.WriteToServer(_DT);

            MyGoal.InnerHtml += NewNumber.DisplayStr("GameOver", "red");
        }


    }

    private void PrintRoundResult(int a1, int a2, int a3, int a4, int a5, int a6, int blueBall, int[] findCount, string str456, string strMiniRed, string[] strNewInput, string[] miniRedNow, string noSelectBlueBall, string noSelectSixSum, string[] strRedBall01, string strSub, string strSubSub, string strSimple)
    {
        //Right--   3\10\11
        //Blue      1\2\12\13\14\15\16\17
        //OneByOne  4\5\6\7\8\9
        MyGoal.InnerHtml = NewNumber.DisplayStr("------------------------------------------------------------------------------------------------------------------------", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("ROUND:" + _ArrRound[1].ToString() + "------goal:" + a1.ToString() + " " + a2.ToString() + " " + a3.ToString() + " " + a4.ToString() + " " + a5.ToString() + " " + a6.ToString(), "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("------------------------------------------------------------------------------------------------------------------------", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*0、*/_UPUP_NoSelect=\"" + _UPUP_NoSelect + "\";", "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("_UPUP_NoCount=" + _UPUP_NoCount.ToString() + ";//_" + _UPUP_NoSelectEndSelect, "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*0.0、*/_NearRepeat22_NoSelect=\"" + _NearRepeat22_NoSelect + "\";", "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("_NearRepeat22_NoCount=" + _NearRepeat22_NoCount.ToString() + ";//_" + _NearRepeat22_NoSelectEndSelect, "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*0.1、*/_Repeat22_Select=\"" + _Repeat22_Select + "\";", "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("_Repeat22_Select=" + _Repeat22_SelectEndSelect + ";//13", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*0.2、*/_People_NoSelect=\"" + _People_NoSelect + "\";", "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("_People_NoCount=" + _People_NoCount.ToString() + ";//_" + _People_NoSelectEndSelect, "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        int countPeople = 0;
        for (int i = 0; i < _People_Str.Length; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr("/*0.3、*/_People_Str_"+ i.ToString() +"=\"" + _People_Str[i] + "\";//", "blue");
            if (_People_Str[i].Contains(a1.ToString("00")))
                MyGoal.InnerHtml += NewNumber.DisplayStr(a1.ToString() +"|","red");
            if (_People_Str[i].Contains(a2.ToString("00")))
                MyGoal.InnerHtml += NewNumber.DisplayStr(a2.ToString() + "|", "red");
            if (_People_Str[i].Contains(a3.ToString("00")))
                MyGoal.InnerHtml += NewNumber.DisplayStr(a3.ToString() + "|", "red");
            if (_People_Str[i].Contains(a4.ToString("00")))
                MyGoal.InnerHtml += NewNumber.DisplayStr(a4.ToString() + "|", "red");
            if (_People_Str[i].Contains(a5.ToString("00")))
                MyGoal.InnerHtml += NewNumber.DisplayStr(a5.ToString() + "|", "red");
            if (_People_Str[i].Contains(a6.ToString("00")))
                MyGoal.InnerHtml += NewNumber.DisplayStr(a6.ToString() + "|", "red");
            MyGoal.InnerHtml += NewNumber.DisplayBROne();
            countPeople += FindHowMany00(a1, a2, a3, a4, a5, a6, _People_Str[i]);
            MyGoal.InnerHtml += NewNumber.DisplayStr("_People_Str_Count_One" + i.ToString() + "(<=4)=" + FindHowMany00(a1, a2, a3, a4, a5, a6, _People_Str[i]).ToString(), "red");
            MyGoal.InnerHtml += NewNumber.DisplayBROne();

        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*0.3、*/_People_Str_Count_All（15-30）=" + countPeople.ToString(), "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*1、*/_NoSelectBlueBall=\"" + noSelectBlueBall + "\";", "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("//_NoSelectBlueBall:", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(blueBall.ToString() + "-->Data2:" + _HangZhou.BlueBall, "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        int sum = a1 + a2 + a3 + a4 + a5 + a6;
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*2、*/_NoSelectSixSum=\"" + noSelectSixSum + "\";", "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("//_NoSelectSixSum:", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(sum.ToString() + "-->Data:" + _HangZhou.Sum, "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*FindCount*/txtInput.Text=\"" + txtInput.Text + "\";", "green");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        for (int i = 0; i <= 7; i++)
        {
            if (i == 0)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr("//3、a1 - 1:" + (a1 - 1).ToString(), "blue");
                MyGoal.InnerHtml += NewNumber.DisplayStr("|a2 - a1:" + (a2 - a1).ToString(), "blue");
                MyGoal.InnerHtml += NewNumber.DisplayStr("|a3 - a2:" + (a3 - a2).ToString(), "blue");
                MyGoal.InnerHtml += NewNumber.DisplayStr("|a4 - a3:" + (a4 - a3).ToString(), "blue");
                MyGoal.InnerHtml += NewNumber.DisplayStr("|a5 - a4:" + (a5 - a4).ToString(), "blue");
                MyGoal.InnerHtml += NewNumber.DisplayStr("|a6 - a5:" + (a6 - a5).ToString(), "blue");
                MyGoal.InnerHtml += NewNumber.DisplayBROne();
                MyGoal.InnerHtml += NewNumber.DisplayStr("//FindCount[0]4321:" + findCount[0].ToString(), "red");
            }
            else
            {
                string str = "";
                switch (i)
                {
                    case 1: 
                        str = "43210";
                        break;
                    case 2:
                        str = "3210";
                        break;
                    case 3:
                        str = "";
                        break;
                    case 4:
                        str = "3210";
                        break;
                    case 5:
                        str = "210";
                        break;
                    case 6:
                        str = "43210";
                        break;
                    case 7:
                        str = "54321";
                        break;
                }
                MyGoal.InnerHtml += NewNumber.DisplayStr("//" + (i + 3).ToString() + "、StrNewInput" + (i - 1).ToString() + ":" + strNewInput[i - 1], "blue");
                MyGoal.InnerHtml += NewNumber.DisplayBROne();
                MyGoal.InnerHtml += NewNumber.DisplayStr("//FindCount[" + i.ToString() + "]" + str + ":" + findCount[i].ToString(), "red");
            }

            MyGoal.InnerHtml += NewNumber.DisplayBROne(); 
        }

        MyGoal.InnerHtml += NewNumber.DisplayStr("//11、Str456:" + str456, "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        string strInput = a1.ToString() + "|" + a2.ToString() + "|" + a3.ToString() + "|" + a4.ToString() + "|" + a5.ToString() + "|" + a6.ToString();
        MyGoal.InnerHtml += NewNumber.DisplayStr("//strSix:" + strInput, "green");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        strInput = MyTest.GetFive(strInput);
        string[] strFiveFour = strInput.Split('-');
        MyGoal.InnerHtml += NewNumber.DisplayStr("//strFourFiveAll:" + strInput, "green");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        for (int i = 0; i < strFiveFour.Length; i++ )
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr("//strFourFive:" + strFiveFour[i], "green");
            MyGoal.InnerHtml += NewNumber.DisplayBROne();
        }

        for (int i = 0; i < miniRedNow.Length; i++)
        {
            switch (i)
            {
                case 0:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*12、NoSelectRedBall---One*/_MiniRedNow[0]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedNow[0] + "\";", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//RedBallRed:" + a1.ToString() + "-->Mini0" + _HangZhou.Mini0, "red");
                    break;
                case 1:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*13、NoSelectRedBall---Two*/_MiniRedNow[1]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedNow[1] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//RedBallRed:" + a2.ToString() + "-->Mini1" + _HangZhou.Mini1, "red");
                    break;
                case 2:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*14、NoSelectRedBall---Three*/_MiniRedNow[2]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedNow[2] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//RedBallRed:" + a3.ToString() + "-->Mini2" + _HangZhou.Mini2, "red");
                    break;
                case 3:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*15、NoSelectRedBall---Four*/_MiniRedNow[3]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedNow[3] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//RedBallRed:" + a4.ToString() + "-->Mini3" + _HangZhou.Mini3, "red");
                    break;
                case 4:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*16、NoSelectRedBall---Five*/_MiniRedNow[4]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedNow[4] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//RedBallRed:" + a5.ToString() + "-->Mini4" + _HangZhou.Mini4, "red");
                    break;
                case 5:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*17、NoSelectRedBall---Six*/_MiniRedNow[5]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedNow[5] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//RedBallRed:" + a6.ToString() + "-->Mini5" + _HangZhou.Mini5, "red");
                    break;
            }
            MyGoal.InnerHtml += NewNumber.DisplayBROne();


        }

        MyGoal.InnerHtml += NewNumber.DisplayStr("//StrMiniRed_" + _MiniRedCount.ToString() + ":" + strMiniRed, "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("//strRedBall01:自己写sql!", "blue");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        for (int i = 0; i < strRedBall01.Length; i++)
        {
            switch (i)
            {
                case 0:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*18、strRedBall01---One*/_StrRedBall01[0]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[0] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//AddNow2---------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[0]), "red");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    break;
                case 1:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*19、strRedBall01---Two*/_StrRedBall01[1]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[1] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//AddNow3---------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[1]), "red");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    break;
                case 2:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*20、strRedBall01---Three*/_StrRedBall01[2]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[2] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//AddNow4-----------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[2]), "red");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    break;
                case 3:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*21、strRedBall01---Four*/_StrRedBall01[3]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[3] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//AddNow5----------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[3]), "red");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    break;
                case 4:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*22、strRedBall01---Five*/_StrRedBall01[4]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[4] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//AddNow6----------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[4]), "red");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    break;
                case 5:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*23、strRedBall01---Six*/_StrRedBall01[5]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[5] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//AddNow7---------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[5]), "red");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    break;
                case 6:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("/*24、strRedBall01---Seven*/_StrRedBall01[6]=\"", "green");
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[6] + "\"; ", "blue");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    MyGoal.InnerHtml += NewNumber.DisplayStr("//AddNow8-----------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[6]), "red");
                    MyGoal.InnerHtml += NewNumber.DisplayBROne();
                    break;
                case 7:
                    //MyGoal.InnerHtml += DisplayStr("25、strRedBall01---Eight:", "green");
                    //MyGoal.InnerHtml += DisplayStr(strRedBall01[7] + " ", "blue");
                    //MyGoal.InnerHtml += DisplayBR();
                    //MyGoal.InnerHtml += DisplayStr("AddNow9-----------------:" + GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[7]), "red");
                    //MyGoal.InnerHtml += DisplayBR();
                    break;
            }
        }

        int isPrime = MyTest.ISPrime(a1) + MyTest.ISPrime(a2) + MyTest.ISPrime(a3) + MyTest.ISPrime(a4) + MyTest.ISPrime(a5) + MyTest.ISPrime(a6);
        int isTwo = MyTest.ISTwo(a1) + MyTest.ISTwo(a2) + MyTest.ISTwo(a3) + MyTest.ISTwo(a4) + MyTest.ISTwo(a5) + MyTest.ISTwo(a6);
        int isNearRepeat = MyTest.ISNearRepeat(_RedBall, a1, GameOver) + MyTest.ISNearRepeat(_RedBall, a2, GameOver) + MyTest.ISNearRepeat(_RedBall, a3, GameOver) + MyTest.ISNearRepeat(_RedBall, a4, GameOver) + MyTest.ISNearRepeat(_RedBall, a5, GameOver) + MyTest.ISNearRepeat(_RedBall, a6, GameOver);
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*26、ISTwo_*/_TwoStr=\"" + _TwoStr + "\"; //", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(isTwo.ToString() + " ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*25、ISPrime_*/_PrimeStr=\"" + _PrimeStr + "\"; //", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(isPrime.ToString() + " ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*27、ISNearRepeat_*/_NearRepeatStr=\"" + _NearRepeatStr + "\"; //", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(isNearRepeat.ToString() + " ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*28、SubSub=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(strSubSub + "--'b2b2c2','a2b2c2','a2c4','b2c4','c6'*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*28、Sub=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(strSub + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*29、strSimple=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(strSimple + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        int sumUp30Ball = /*6 +*/ int.Parse(_UpSum30Ball[a1 - 1]) + int.Parse(_UpSum30Ball[a2 - 1]) + int.Parse(_UpSum30Ball[a3 - 1]) + int.Parse(_UpSum30Ball[a4 - 1]) + int.Parse(_UpSum30Ball[a5 - 1]) + int.Parse(_UpSum30Ball[a6 - 1]);
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*30_SumUp30Ball(30-49)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(sumUp30Ball.ToString() + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        int sumUpUp = int.Parse(_UpUpSumBall[a1 - 1]) + int.Parse(_UpUpSumBall[a2 - 1]) + int.Parse(_UpUpSumBall[a3 - 1]) + int.Parse(_UpUpSumBall[a4 - 1]) + int.Parse(_UpUpSumBall[a5 - 1]) + int.Parse(_UpUpSumBall[a6 - 1]);
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*31_SumUpUpBall(11-45)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(sumUpUp.ToString() + "--_UPUP_33_Count:" + _UPUP_33_Count.ToString() + "-->Data3:" + _HangZhou.UpUp + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*32PrimeTwoNearRepeat(5-11)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr((isPrime + isTwo + isNearRepeat).ToString() + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*33_SixBallSum(65-135)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr((a1 + a2 + a3 + a4 + a5 + a6).ToString() + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*34_BlueBall2Sum(10-29)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr((_BlueBall[1] + _BlueBall[2]).ToString() + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        int last = FindLastBlue(1, _BlueBall);
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*35FindLastBlue(<20)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(last.ToString() + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*36FirstLast=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr((a6 - a1).ToString() + "-->Data1:" + _HangZhou.LeftRight + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        int count = 0;
        if (_HangZhou.Data33.Contains(a1.ToString("00")))
            count++;
        if (_HangZhou.Data33.Contains(a2.ToString("00")))
            count++;
        if (_HangZhou.Data33.Contains(a3.ToString("00")))
            count++;
        if (_HangZhou.Data33.Contains(a4.ToString("00")))
            count++;
        if (_HangZhou.Data33.Contains(a5.ToString("00")))
            count++;
        if (_HangZhou.Data33.Contains(a6.ToString("00")))
            count++;

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*37Data33(" + count.ToString() + ")=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(a1.ToString() + "|" + a2.ToString() + "|" + a3.ToString() + "|" + a4.ToString() + "|" + a5.ToString() + "|" + a6.ToString() + "-->Data33:" + _HangZhou.Data33 + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*38TwoNearRepeat=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(NewNumber.GetTwoNearRepeatRound(_RedBall, a1, a2, a3, a4, a5, a6, GameOver - 1) + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        int lastPrime = MyTest.ISPrime(_MiniRedBall[0, 2]) + MyTest.ISPrime(_MiniRedBall[1, 2]) + MyTest.ISPrime(_MiniRedBall[2, 2]) + MyTest.ISPrime(_MiniRedBall[3, 2]) + MyTest.ISPrime(_MiniRedBall[4, 2]) + MyTest.ISPrime(_MiniRedBall[5, 2]);
        int lastTwo = MyTest.ISTwo(_MiniRedBall[0, 2]) + MyTest.ISTwo(_MiniRedBall[1, 2]) + MyTest.ISTwo(_MiniRedBall[2, 2]) + MyTest.ISTwo(_MiniRedBall[3, 2]) + MyTest.ISTwo(_MiniRedBall[4, 2]) + MyTest.ISTwo(_MiniRedBall[5, 2]);
        int lastNearRepeat = MyTest.ISNearRepeat(_RedBall, _MiniRedBall[0, 2], GameOver + 1) + MyTest.ISNearRepeat(_RedBall, _MiniRedBall[1, 2], GameOver + 1) + MyTest.ISNearRepeat(_RedBall, _MiniRedBall[2, 2], GameOver + 1) + MyTest.ISNearRepeat(_RedBall, _MiniRedBall[3, 2], GameOver + 1) + MyTest.ISNearRepeat(_RedBall, _MiniRedBall[4, 2], GameOver + 1) + MyTest.ISNearRepeat(_RedBall, _MiniRedBall[5, 2], GameOver + 1);
       

        MyGoal.InnerHtml += NewNumber.DisplayStr("/*39TwoDimension(6-10)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(MyTest.ReturnChangeStr(_TwoDimension2, _TwoDimension3, a1, a2, a3, a4, a5, a6) + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("//" + sum.ToString() + "_" + _HangZhou.Sum + "_" + (_MiniRedBall[0, 2] + _MiniRedBall[1, 2] + _MiniRedBall[2, 2] + _MiniRedBall[3, 2] + _MiniRedBall[4, 2] + _MiniRedBall[5, 2]).ToString() + "|" + (a6 - a1).ToString() + "_" + _HangZhou.LeftRight + "_" + (_MiniRedBall[5, 2] - _MiniRedBall[0, 2]).ToString() + "|" + blueBall.ToString() + "_" + _HangZhou.BlueBall + "_" + _BlueBall[2].ToString() + "|" + sumUpUp.ToString() + "_" + _HangZhou.UpUp + "|" + count.ToString() + "|" + a1.ToString() + "_" + _HangZhou.Mini0 + "_" + _MiniRedBall[0, 2].ToString() + "|" + a2.ToString() + "_" + _HangZhou.Mini1 + "_" + _MiniRedBall[1, 2].ToString() + "|" + a3.ToString() + "_" + _HangZhou.Mini2 + "_" + _MiniRedBall[2, 2].ToString() + "|" + a4.ToString() + "_" + _HangZhou.Mini3 + "_" + _MiniRedBall[3, 2].ToString() + "|" + a5.ToString() + "_" + _HangZhou.Mini4 + "_" + _MiniRedBall[4, 2].ToString() + "|" + a6.ToString() + "_" + _HangZhou.Mini5 + "_" + _MiniRedBall[5, 2].ToString() + "|" + isTwo.ToString() + "_" + _HangZhou.Two + "_" + lastTwo.ToString() + "|" + isPrime.ToString() + "_" + _HangZhou.Prime + "_" + lastPrime.ToString() + "|" + isNearRepeat.ToString() + "_" + _HangZhou.NearRepeat + "_" + lastNearRepeat.ToString() + "|" + (isTwo+isPrime+isNearRepeat).ToString() + "_" + _HangZhou.TPNRSum.ToString() + "_" + (lastTwo + lastPrime + lastNearRepeat).ToString(), "green");

        MyGoal.InnerHtml += NewNumber.DisplayBROne();

        string hope = MyTest.Belong(_MiniRedBall, 1, 1) + "%" + MyTest.Belong(_MiniRedBall, 1, 2) + "%" + MyTest.Belong(_MiniRedBall, 1, 3);
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*40Analyze_Belong(345)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(hope + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
        MyGoal.InnerHtml += NewNumber.DisplayStr("/*41StyleUpSum30(ABBBBB,BBBBBB,BBBBBC)=", "green");
        MyGoal.InnerHtml += NewNumber.DisplayStr(StyleUpSum30(a1, a2, a3, a4, a5, a6) + "*/ ", "red");
        MyGoal.InnerHtml += NewNumber.DisplayBROne();
                 
    }

    private int FindLastBlue(int now, int[] blueBall)
    {
        bool find = false;
        int count = 1;
        while (!find)
        {
            if (now + count == blueBall.Length)
            {
                find = true; count = 0;
            }
            else if (blueBall[now + count] == blueBall[now])
                find = true;
            else
                count++;
        }
        return count;
    }

    private string StyleUpSum30(int a1, int a2, int a3, int a4, int a5, int a6)
    {
        int a = 0;
        int c = 0;
        if (int.Parse(_UpSum30Ball[a1 - 1]) >= 9)
            a++;
        else if (int.Parse(_UpSum30Ball[a1 - 1]) <= 2)
            c++;
        if (int.Parse(_UpSum30Ball[a2 - 1]) >= 9)
            a++;
        else if (int.Parse(_UpSum30Ball[a2 - 1]) <= 2)
            c++;
        if (int.Parse(_UpSum30Ball[a3 - 1]) >= 9)
            a++;
        else if (int.Parse(_UpSum30Ball[a3 - 1]) <= 2)
            c++;
        if (int.Parse(_UpSum30Ball[a4 - 1]) >= 9)
            a++;
        else if (int.Parse(_UpSum30Ball[a4 - 1]) <= 2)
            c++;
        if (int.Parse(_UpSum30Ball[a5 - 1]) >= 9)
            a++;
        else if (int.Parse(_UpSum30Ball[a5 - 1]) <= 2)
            c++;
        if (int.Parse(_UpSum30Ball[a6 - 1]) >= 9)
            a++;
        else if (int.Parse(_UpSum30Ball[a6 - 1]) <= 2)
            c++;
        if (c == 5 && a == 0)
            return "BCCCCC";
        else if (c == 6)
            return "CCCCCC";
        else if (a + c > 1)
            return "false_" + a.ToString() + "|" + c.ToString();
        else if (a == 1)
            return "ABBBBB";
        else if (c == 1)
            return "BBBBBC";
        else
            return "BBBBBB";
    }

    private int[] FindMyBoal(int a1, int a2, int a3, int a4, int a5, int a6, string[] strSixBall, string[] strFiveBall, string[] strSixUpBall, string[] strFiveUpBall, string[] strSixNowBall, string[] strFiveNowBall, string[] miniRedNow)
    {
        int[] findCount = new int[10];
        int sixBallSum = a1 + a2 + a3 + a4 + a5 + a6;

        //30累计数
        int sumUp30Ball =/*6 +*/ int.Parse(_UpSum30Ball[a1 - 1]) + int.Parse(_UpSum30Ball[a2 - 1]) + int.Parse(_UpSum30Ball[a3 - 1]) + int.Parse(_UpSum30Ball[a4 - 1]) + int.Parse(_UpSum30Ball[a5 - 1]) + int.Parse(_UpSum30Ball[a6 - 1]);
        string styleUpSum30 = StyleUpSum30(a1,a2,a3,a4,a5,a6);
        if (!styleUpSum30.Contains("false") || _One)
        {


            int sumUpUp = int.Parse(_UpUpSumBall[a1 - 1]) + int.Parse(_UpUpSumBall[a2 - 1]) + int.Parse(_UpUpSumBall[a3 - 1]) + int.Parse(_UpUpSumBall[a4 - 1]) + int.Parse(_UpUpSumBall[a5 - 1]) + int.Parse(_UpUpSumBall[a6 - 1]);

            if ((sixBallSum >= 65 && sixBallSum <= 135 && sumUp30Ball >= 30 && sumUp30Ball <= 49 && sumUpUp >= 11 && sumUpUp <= 45) || _One)
            {
                int upCount = 0;
                if (_UPUP_NoSelect.Contains(a1.ToString("00")))
                {
                    upCount++;
                    if (_One)
                    {
                        _UPUP_NoSelectEndSelect += a1.ToString("00") + "|";
                    }
                }
                if (_UPUP_NoSelect.Contains(a2.ToString("00")))
                {
                    upCount++;
                    if (_One)
                    {
                        _UPUP_NoSelectEndSelect += a2.ToString("00") + "|";
                    }
                }
                if (_UPUP_NoSelect.Contains(a3.ToString("00")))
                {
                    upCount++;
                    if (_One)
                    {
                        _UPUP_NoSelectEndSelect += a3.ToString("00") + "|";
                    }
                }
                if (_UPUP_NoSelect.Contains(a4.ToString("00")))
                {
                    upCount++;
                    if (_One)
                    {
                        _UPUP_NoSelectEndSelect += a4.ToString("00") + "|";
                    }
                }
                if (_UPUP_NoSelect.Contains(a5.ToString("00")))
                {
                    upCount++;
                    if (_One)
                    {
                        _UPUP_NoSelectEndSelect += a5.ToString("00") + "|";
                    }
                }
                if (_UPUP_NoSelect.Contains(a6.ToString("00")))
                {
                    upCount++;
                    if (_One)
                    {
                        _UPUP_NoSelectEndSelect += a6.ToString("00") + "|";
                    }
                }
                int peopleNoCount = 0;
                if (_People_NoSelect.Contains(a1.ToString("00")))
                {
                    peopleNoCount++;
                    if (_One)
                    {
                        _People_NoSelectEndSelect += a1.ToString("00") + "|";
                    }
                }
                if (_People_NoSelect.Contains(a2.ToString("00")))
                {
                    peopleNoCount++;
                    if (_One)
                    {
                        _People_NoSelectEndSelect += a2.ToString("00") + "|";
                    }
                }
                if (_People_NoSelect.Contains(a3.ToString("00")))
                {
                    peopleNoCount++;
                    if (_One)
                    {
                        _People_NoSelectEndSelect += a3.ToString("00") + "|";
                    }
                }
                if (_People_NoSelect.Contains(a4.ToString("00")))
                {
                    peopleNoCount++;
                    if (_One)
                    {
                        _People_NoSelectEndSelect += a4.ToString("00") + "|";
                    }
                }
                if (_People_NoSelect.Contains(a5.ToString("00")))
                {
                    peopleNoCount++;
                    if (_One)
                    {
                        _People_NoSelectEndSelect += a5.ToString("00") + "|";
                    }
                }
                if (_People_NoSelect.Contains(a6.ToString("00")))
                {
                    peopleNoCount++;
                    if (_One)
                    {
                        _People_NoSelectEndSelect += a6.ToString("00") + "|";
                    }
                }
                if ((upCount <= _UPUP_NoCount + 1 && peopleNoCount <= _People_NoCount + 1) || _One)
                {
                    int nearRepeatCount = 0;
                    if (_NearRepeat22_NoSelect.Contains(a1.ToString("00")))
                    {
                        nearRepeatCount++;
                        if (_One)
                        {
                            _NearRepeat22_NoSelectEndSelect += a1.ToString("00") + "|";
                        }
                    }
                    if (_NearRepeat22_NoSelect.Contains(a2.ToString("00")))
                    {
                        nearRepeatCount++;
                        if (_One)
                        {
                            _NearRepeat22_NoSelectEndSelect += a2.ToString("00") + "|";
                        }
                    }
                    if (_NearRepeat22_NoSelect.Contains(a3.ToString("00")))
                    {
                        nearRepeatCount++;
                        if (_One)
                        {
                            _NearRepeat22_NoSelectEndSelect += a3.ToString("00") + "|";
                        }
                    }
                    if (_NearRepeat22_NoSelect.Contains(a4.ToString("00")))
                    {
                        nearRepeatCount++;
                        if (_One)
                        {
                            _NearRepeat22_NoSelectEndSelect += a4.ToString("00") + "|";
                        }
                    }
                    if (_NearRepeat22_NoSelect.Contains(a5.ToString("00")))
                    {
                        nearRepeatCount++;
                        if (_One)
                        {
                            _NearRepeat22_NoSelectEndSelect += a5.ToString("00") + "|";
                        }
                    }
                    if (_NearRepeat22_NoSelect.Contains(a6.ToString("00")))
                    {
                        nearRepeatCount++;
                        if (_One)
                        {
                            _NearRepeat22_NoSelectEndSelect += a6.ToString("00") + "|";
                        }
                    }

                    int repeatCount = 0;
                    if (_Repeat22_Select.Contains(a1.ToString("00")))
                    {
                        repeatCount++;
                        if (_One)
                        {
                            _Repeat22_SelectEndSelect += a1.ToString("00") + "|";
                        }
                    }
                    if (_Repeat22_Select.Contains(a2.ToString("00")))
                    {
                        repeatCount++;
                        if (_One)
                        {
                            _Repeat22_SelectEndSelect += a2.ToString("00") + "|";
                        }
                    }
                    if (_Repeat22_Select.Contains(a3.ToString("00")))
                    {
                        repeatCount++;
                        if (_One)
                        {
                            _Repeat22_SelectEndSelect += a3.ToString("00") + "|";
                        }
                    }
                    if (_Repeat22_Select.Contains(a4.ToString("00")))
                    {
                        repeatCount++;
                        if (_One)
                        {
                            _Repeat22_SelectEndSelect += a4.ToString("00") + "|";
                        }
                    }
                    if (_Repeat22_Select.Contains(a5.ToString("00")))
                    {
                        repeatCount++;
                        if (_One)
                        {
                            _Repeat22_SelectEndSelect += a5.ToString("00") + "|";
                        }
                    }
                    if (_Repeat22_Select.Contains(a6.ToString("00")))
                    {
                        repeatCount++;
                        if (_One)
                        {
                            _Repeat22_SelectEndSelect += a6.ToString("00") + "|";
                        }
                    }

                    if ((nearRepeatCount <= _NearRepeat22_NoCount + 1 && repeatCount >= 1 && repeatCount <= 3) || _One)
                    {


                        int[] sub = new int[7];
                        findCount[8] = upCount;


                        if (a1 - 1 <= 3)
                            findCount[0]++;
                        else if (a1 - 1 >= 15)
                            findCount[0] = 6;
                        if (a2 - a1 <= 3)
                            findCount[0]++;
                        else if (a2 - a1 >= 15)
                            findCount[0] = 6;
                        if (a3 - a2 <= 3)
                            findCount[0]++;
                        else if (a3 - a2 >= 15)
                            findCount[0] = 6;
                        if (a4 - a3 <= 3)
                            findCount[0]++;
                        else if (a4 - a3 >= 15)
                            findCount[0] = 6;
                        if (a5 - a4 <= 3)
                            findCount[0]++;
                        else if (a5 - a4 >= 15)
                            findCount[0] = 6;
                        if (a6 - a5 <= 3)
                            findCount[0]++;
                        else if (a6 - a5 >= 15)
                            findCount[0] = 6;

                        if (findCount[0] == 4 || findCount[0] == 3 || findCount[0] == 2 || findCount[0] == 1 || _One)//right--
                        {
                            string input = txtInput.Text;
                            string[] str = input.Split(' ');

                            findCount[1] = FindHowMany(a1, a2, a3, a4, a5, a6, str[0].Split('-')[1]);
                            if (findCount[1] == 0 || findCount[1] == 1 || findCount[1] == 2 || findCount[1] == 3 || findCount[1] == 4 || _One)//NSelect可选择的个数为23456
                            {
                                findCount[2] = FindHowMany(a1, a2, a3, a4, a5, a6, str[1].Split('-')[1]);
                                if (findCount[2] == 0 || findCount[2] == 1 || findCount[2] == 2 || findCount[2] == 3 || _One)//黑色0123
                                {
                                    //findCount = FindHowMany(a1, a2, a3, a4, a5, a6, str[2].Split('-')[1]);
                                    //if (findCount != 1 || findCount != 2)
                                    //    break;
                                    findCount[4] = FindHowMany(a1, a2, a3, a4, a5, a6, str[3].Split('-')[1]);
                                    if (findCount[4] == 0 || findCount[4] == 1 || findCount[4] == 2 || findCount[4] == 3 || _One)//蓝色0123
                                    {
                                        findCount[5] = FindHowMany(a1, a2, a3, a4, a5, a6, str[4].Split('-')[1]);
                                        if (findCount[5] == 0 || findCount[5] == 1 || findCount[5] == 2 || _One)//红色012
                                        {
                                            findCount[6] = FindHowMany(a1, a2, a3, a4, a5, a6, str[5].Split('-')[1]);
                                            if (findCount[6] == 0 || findCount[6] == 1 || findCount[6] == 2 || findCount[6] == 3 || findCount[6] == 4 || _One)//棕色01234
                                            {
                                                findCount[7] = FindHowManyUp(a1, a2, a3, a4, a5, a6, str[6].Split('-')[1]);
                                                if (findCount[7] == 5 || findCount[7] == 4 || findCount[7] == 3 || findCount[7] == 2 || findCount[7] == 1 || _One)//up
                                                {
                                                    bool people = true;
                                                    int countPeople = 0;
                                                    for (int i = 0; i < _People_Str.Length; i++)
                                                    {
                                                        int cc = FindHowMany00(a1, a2, a3, a4, a5, a6, _People_Str[i]);
                                                        if (cc > 4)
                                                        {
                                                            people = false;
                                                            break;
                                                        }
                                                        else
                                                            countPeople += cc;
                                                    }
                                                    if (people && countPeople >= 15 && countPeople <= 30)
                                                    {
                                                        string strTwoDimensionChange = MyTest.ReturnChangeStr(_TwoDimension2, _TwoDimension3, a1, a2, a3, a4, a5, a6);

                                                        int change = int.Parse(strTwoDimensionChange.Split('|')[1]);

                                                        if (change >= 6 && change <= 10)
                                                        {
                                                            int prime = MyTest.ISPrime(a1) + MyTest.ISPrime(a2) + MyTest.ISPrime(a3) + MyTest.ISPrime(a4) + MyTest.ISPrime(a5) + MyTest.ISPrime(a6);
                                                            int two = MyTest.ISTwo(a1) + MyTest.ISTwo(a2) + MyTest.ISTwo(a3) + MyTest.ISTwo(a4) + MyTest.ISTwo(a5) + MyTest.ISTwo(a6);
                                                            int nearRepeat = MyTest.ISNearRepeat(_RedBall, a1, GameOver) + MyTest.ISNearRepeat(_RedBall, a2, GameOver) + MyTest.ISNearRepeat(_RedBall, a3, GameOver) + MyTest.ISNearRepeat(_RedBall, a4, GameOver) + MyTest.ISNearRepeat(_RedBall, a5, GameOver) + MyTest.ISNearRepeat(_RedBall, a6, GameOver);

                                                            if ((prime + two + nearRepeat >= 5 && prime + two + nearRepeat <= 11) || (two == 6 && prime + two + nearRepeat > 11) || (two == 0 && prime + two + nearRepeat < 5))
                                                            {

                                                                int countOK = 0;
                                                                string strCountOk = "";
                                                                string strMiniRed = GetMiniRedOK(a1, a2, a3, a4, a5, a6, miniRedNow);
                                                                if (int.Parse(strMiniRed.Split('_')[1]) <= _MiniRedCount + 1)
                                                                {
                                                                    if (strMiniRed.Contains("ok"))
                                                                        countOK++;
                                                                    else
                                                                        strCountOk += "Mini_";

                                                                    if (_PrimeStr.Split('|')[2].Contains(prime.ToString()))
                                                                        countOK++;
                                                                    else
                                                                        strCountOk += "Prime_";
                                                                    if (_TwoStr.Split('|')[2].Contains(two.ToString()))
                                                                        countOK++;
                                                                    else
                                                                        strCountOk += "Two_";
                                                                    if (_NearRepeatStr.Split('|')[2].Contains(nearRepeat.ToString()))
                                                                        countOK++;
                                                                    else
                                                                        strCountOk += "NearRepeat_";

                                                                    if (upCount <= _UPUP_NoCount)
                                                                        countOK++;
                                                                    else
                                                                        strCountOk += "UpUp_";

                                                                    if (peopleNoCount <= _People_NoCount)
                                                                        countOK++;
                                                                    else
                                                                        strCountOk += "People_";

                                                                    if (nearRepeatCount <= _NearRepeat22_NoCount)
                                                                        countOK++;
                                                                    else
                                                                        strCountOk += "NearRepeatNoSelect_";

                                                                    //if (countOK >= 2 && countOK <= 4)//可以错两个-4个
                                                                    //{
                                                                    string str456 = OldFindStr(str, a1, a2, a3, a4, a5, a6, strSixBall, strFiveBall, strSixUpBall, strFiveUpBall, strSixNowBall, strFiveNowBall);
                                                                    if (!str456.Contains("&"))
                                                                    {
                                                                        if (str456.Contains("ok"))
                                                                            countOK++;
                                                                        else
                                                                            strCountOk += "456_";
                                                                        //if (countOK >= 3 && countOK <= 5)
                                                                        //{
                                                                        _MiniRedBall[0, 0] = a1;
                                                                        _MiniRedBall[1, 0] = a2;
                                                                        _MiniRedBall[2, 0] = a3;
                                                                        _MiniRedBall[3, 0] = a4;
                                                                        _MiniRedBall[4, 0] = a5;
                                                                        _MiniRedBall[5, 0] = a6;
                                                                        string b1 = MyTest.Belong(_MiniRedBall, 0, 1).Split('_')[1];
                                                                        if ("345".Contains(b1))
                                                                        {
                                                                            string b2 = MyTest.Belong(_MiniRedBall, 0, 2).Split('_')[1];
                                                                            if ("345".Contains(b2))
                                                                            {
                                                                                string b3 = MyTest.Belong(_MiniRedBall, 0, 3).Split('_')[1];
                                                                                if ("345".Contains(b2))
                                                                                {
                                                                                    DataRow newRow;
                                                                                    newRow = _DT.NewRow();

                                                                                    newRow["A0"] = findCount[0];
                                                                                    newRow["A1"] = findCount[1];
                                                                                    newRow["A2"] = findCount[2];
                                                                                    newRow["A3"] = findCount[3];
                                                                                    newRow["A4"] = findCount[4];
                                                                                    newRow["A5"] = findCount[5];
                                                                                    newRow["A6"] = findCount[6];
                                                                                    newRow["A7"] = findCount[7];
                                                                                    newRow["A8"] = sixBallSum;
                                                                                    newRow["A9"] = two;
                                                                                    newRow["A10"] = prime;
                                                                                    newRow["A11"] = nearRepeat;
                                                                                    newRow["A12"] = a1.ToString("00") + "|" + a2.ToString("00") + "|" + a3.ToString("00") + "|" + a4.ToString("00") + "|" + a5.ToString("00") + "|" + a6.ToString("00");
                                                                                    newRow["A13"] = str456;
                                                                                    newRow["A14"] = strMiniRed;//"ok";//MiniRed
                                                                                    newRow["A15"] = countPeople;//GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[0]);
                                                                                    newRow["A16"] = b1 + b2 + b3;
                                                                                    newRow["A17"] = styleUpSum30;
                                                                                    newRow["A17"] = MyTest.ISRepeat(_RedBall, a1, GameOver) + MyTest.ISRepeat(_RedBall, a2, GameOver) + MyTest.ISRepeat(_RedBall, a3, GameOver) + MyTest.ISRepeat(_RedBall, a4, GameOver) + MyTest.ISRepeat(_RedBall, a5, GameOver) + MyTest.ISRepeat(_RedBall, a6, GameOver); 
                                                                                    //newRow["A16"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[1]);
                                                                                    //newRow["A17"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[2]);
                                                                                    //newRow["A18"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[3]);
                                                                                    //newRow["A19"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[4]);
                                                                                    //newRow["A20"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[5]);
                                                                                    //newRow["A21"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[6]);
                                                                                    //newRow["A22"] = GetNowStrRedBall01(a1, a2, a3, a4, a5, a6, _StrRedBall01[7]);
                                                                                    newRow["A23"] = NewNumber.GetTwoNearRepeatRound(_RedBall, a1, a2, a3, a4, a5, a6, GameOver - 1);
                                                                                    sub[0] = a1 - 1;
                                                                                    sub[1] = a2 - a1 - 1;
                                                                                    sub[2] = a3 - a2 - 1;
                                                                                    sub[3] = a4 - a3 - 1;
                                                                                    sub[4] = a5 - a4 - 1;
                                                                                    sub[5] = a6 - a5 - 1;
                                                                                    sub[6] = 33 - a6;
                                                                                    newRow["A24"] = sub[0].ToString("00") + "-" + sub[1].ToString("00") + "-" + sub[2].ToString("00") + "-" + sub[3].ToString("00") + "-" + sub[4].ToString("00") + "-" + sub[5].ToString("00") + "-" + sub[6].ToString("00");//无用
                                                                                    newRow["A25"] = MyTest.GetSubStr(sub);
                                                                                    //newRow["A26"] = SimpleRedSix210(a1, _MiniRedBall[0, GameOver]) + SimpleRedSix210(a2, _MiniRedBall[1, GameOver]) + SimpleRedSix210(a3, _MiniRedBall[2, GameOver]) + SimpleRedSix210(a4, _MiniRedBall[3, GameOver]) + SimpleRedSix210(a5, _MiniRedBall[4, GameOver]) + SimpleRedSix210(a6, _MiniRedBall[5, GameOver]);
                                                                                    //newRow["A26"] = 7 - countOK;
                                                                                    newRow["A26"] = strTwoDimensionChange;// MyTest.ReturnChangeStr(_TwoDimension2, _TwoDimension3, a1, a2, a3, a4, a5, a6);
                                                                                    newRow["A27"] = strCountOk;
                                                                                    newRow["A28"] = upCount.ToString() + "_" + nearRepeatCount.ToString();//upup_nearRepeat
                                                                                    // strSimple 
                                                                                    newRow["A29"] = SimpleRedSix210(a1, _MiniRedBall[0, GameOver]) + SimpleRedSix210(a2, _MiniRedBall[1, GameOver]) + SimpleRedSix210(a3, _MiniRedBall[2, GameOver]) + SimpleRedSix210(a4, _MiniRedBall[3, GameOver]) + SimpleRedSix210(a5, _MiniRedBall[4, GameOver]) + SimpleRedSix210(a6, _MiniRedBall[5, GameOver]);
                                                                                    //newRow["A30"] = "UpSum30:" + sumUp30Ball.ToString() + "_UPUP:" + sumUpUp.ToString() + "_UP33:" +_UPUP_33_Count.ToString();
                                                                                    newRow["A30"] = sumUpUp.ToString();
                                                                                    newRow["FLAG"] = Define._MyNumberFlag;
                                                                                    newRow["ROUND"] = a6 - a1;
                                                                                    _DT.Rows.Add(newRow);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return findCount;
    }

    private string SimpleRedSix210(int redJ, int redJNext)
    {
        if (redJ == redJNext)
            return "1";
        else if (redJ > redJNext)
            return "2";
        else
            return "0";
    }

    private string GetNowStrRedBall01(int a1, int a2, int a3, int a4, int a5, int a6, string strRedBall01)
    {
        strRedBall01 = strRedBall01.Substring(0, a1 - 1) + "1" + strRedBall01.Substring(a1, 33 - a1);
        strRedBall01 = strRedBall01.Substring(0, a2 - 1) + "1" + strRedBall01.Substring(a2, 33 - a2);
        strRedBall01 = strRedBall01.Substring(0, a3 - 1) + "1" + strRedBall01.Substring(a3, 33 - a3);
        strRedBall01 = strRedBall01.Substring(0, a4 - 1) + "1" + strRedBall01.Substring(a4, 33 - a4);
        strRedBall01 = strRedBall01.Substring(0, a5 - 1) + "1" + strRedBall01.Substring(a5, 33 - a5);
        strRedBall01 = strRedBall01.Substring(0, a6 - 1) + "1" + strRedBall01.Substring(a6, 33 - a6);

        return strRedBall01;
    }

    private string GetMiniRedOK(int a1, int a2, int a3, int a4, int a5, int a6, string[] miniRedNow)
    {
        string strMiniRed = string.Empty;
        int count = 0;
        if (miniRedNow[0].Contains(a1.ToString("00")))
        {
            strMiniRed += "One:" + a1.ToString("00");
            count++;
        }
        if (miniRedNow[1].Contains(a2.ToString("00")))
        {
            strMiniRed += "|Two:" + a2.ToString("00");     
            count++;
        }
        if (miniRedNow[2].Contains(a3.ToString("00")))
        {
            strMiniRed += "|Three:" + a3.ToString("00");     
            count++;
        }
        if (miniRedNow[3].Contains(a4.ToString("00")))
        {
            strMiniRed += "|Four:" + a4.ToString("00");     
            count++;
        }
        if (miniRedNow[4].Contains(a5.ToString("00")))
        {
            strMiniRed += "|Five:" + a5.ToString("00");     
            count++;
        }
        if (miniRedNow[5].Contains(a6.ToString("00")))
        {
            strMiniRed += "|Six:" + a6.ToString("00");     
            count++;
        }
        if (count <= _MiniRedCount)
            strMiniRed += "|ok";

        return strMiniRed + "_" + count.ToString();
    }

    private string OldFindStr(string[] str, int a1, int a2, int a3, int a4, int a5, int a6, string[] strSixBall, string[] strFiveBall,  string[] strSixUpBall, string[] strFiveUpBall,  string[] strSixNowBall, string[] strFiveNowBall)
    {
        bool data = true;
        string str456 = string.Empty;
        string strLeft = string.Empty;
        string strUp = string.Empty;
        string strNow = string.Empty;
        string ssNow = string.Empty;
        string ssUp = string.Empty;
        string ssLeft = string.Empty;
        if (data)
        {
            string[] strNowUp = str[6].Split('-')[1].Split('|');
            //if (strNowUp[a1 - 1].Length == 1)
            //    strNowUp[a1 - 1] = "0" + strNowUp[a1 - 1];
            //if (strNowUp[a2 - 1].Length == 1)
            //    strNowUp[a2 - 1] = "0" + strNowUp[a2 - 1];
            //if (strNowUp[a3 - 1].Length == 1)
            //    strNowUp[a3 - 1] = "0" + strNowUp[a3 - 1];
            //if (strNowUp[a4 - 1].Length == 1)
            //    strNowUp[a4 - 1] = "0" + strNowUp[a4 - 1];
            //if (strNowUp[a5 - 1].Length == 1)
            //    strNowUp[a5 - 1] = "0" + strNowUp[a5 - 1];
            //if (strNowUp[a6 - 1].Length == 1)
            //    strNowUp[a6 - 1] = "0" + strNowUp[a6 - 1];
            strUp = strNowUp[a1 - 1] + "/" + strNowUp[a2 - 1] + "/" + strNowUp[a3 - 1] + "/" + strNowUp[a4 - 1] + "/" + strNowUp[a5 - 1] + "/" + strNowUp[a6 - 1];
            if (data)
            {
                //for (int j = 0; j < 2; j++)
                //{
                //    if (strFiveUpBall.Contains(strUp.Substring(j * 2, 10)))
                //    {
                //        data = false;
                //        str456 += "|5&";
                //        if (!_One)
                //            break;
                //    }
                //}


                string[] strU = strUp.Split('/');

                for (int i = 0; i < strU.Length; i++)
                {
                    string strFive = string.Empty;
                    for (int j = 0; j < strU.Length; j++)
                    {
                        if (i != j)
                        {
                            strFive += strU[j] + "/";
                        }
                    }
                    if (strFiveUpBall.Contains(strFive.Substring(0, strFive.Length -1)))
                    {
                        //data = false;
                        str456 += "|5";
                        if (!_One)
                            break;
                    }
                }

            }
            if (data && strSixUpBall.Contains(strUp))
            {
                data = false;
                str456 += "|6&";
            }
        }
        if (data || _One)
        {
            strNow = a1.ToString() + "|" + a2.ToString() + "|" + a3.ToString() + "|" + a4.ToString() + "|" + a5.ToString() + "|" + a6.ToString();
            if (data || _One)
            {
                //for (int j = 0; j < 2; j++)
                //{
                //    if (strFiveNowBall.Contains(strNow.Substring(j * 2, 10)))
                //    {
                //        data = false;
                //        str456 += "*5&";
                //        if (!_One)
                //            break;
                //    }
                //}

                string[] strNN = strNow.Split('|');

                for (int i = 0; i < strNN.Length; i++)
                {
                    string strFive = string.Empty;
                    for (int j = 0; j < strNN.Length; j++)
                    {
                        if (i != j)
                        {
                            strFive += strNN[j] + "|";
                        }
                    }

                    if (strFiveNowBall.Contains(strFive.Substring(0, strFive.Length - 1)))
                    {
                        //data = false;
                        str456 += "*5";
                        string[] strN = strFive.Split('|');
                        strFive = (int.Parse(strN[1]) - int.Parse(strN[0])).ToString() + "_" + (int.Parse(strN[2]) - int.Parse(strN[1])).ToString() + "_" + (int.Parse(strN[3]) - int.Parse(strN[2])).ToString() + "_" + (int.Parse(strN[4]) - int.Parse(strN[3])).ToString();
                        if (strFiveBall.Contains(strFive))
                        {
                            //data = false;
                            str456 += "-5";                            
                        }
                        if (!_One)
                            break;
                    }
                    else
                    {
                        string[] strN = strFive.Split('|');
                        strFive = (int.Parse(strN[1]) - int.Parse(strN[0])).ToString() + "_" + (int.Parse(strN[2]) - int.Parse(strN[1])).ToString() + "_" + (int.Parse(strN[3]) - int.Parse(strN[2])).ToString() + "_" + (int.Parse(strN[4]) - int.Parse(strN[3])).ToString();
                        if (strFiveBall.Contains(strFive))
                        {
                            //data = false;
                            str456 += "-5";
                            if (!_One)
                                break;
                        }
                    }
                }
            }
            if (data && strSixNowBall.Contains(strNow))
            {
                data = false;
                str456 += "*6&";
            }
        }
        if (data || _One)
        {
            //strLeft = (a2 - a1).ToString() + "_" + (a3 - a2).ToString() + "_" + (a4 - a3).ToString() + "_" + (a5 - a4).ToString() + "_" + (a6 - a5).ToString();
            strLeft = MyTest.GetOneCircle(a1, a2, a3, a4, a5, a6, _RedBall);
            if (data || _One)
            {
                //for (int j = 0; j < 2; j++)
                //{
                //    if (strFiveBall.Contains(strLeft.Substring(j * 2, 10)))
                //    {
                //        data = false;
                //        str456 += "-5&";
                //        if (!_One)
                //            break;
                //    }
                //}
            }
            if (data && strSixBall.Contains(strLeft.Split('|')[0]))
            {
                data = false;
                str456 += "-6&";
            }
        }
        //if (data || _One)
        //{
        //    int countNow = 0;
        //    int countLeft = 0;
        //    int countUp = 0;
        //    for (int j = 0; j < 3; j++)
        //    {
        //        ssNow = strNow.Substring(j * 2, 8);
        //        ssLeft = strLeft.Substring(j * 2, 8);
        //        ssUp = strUp.Substring(j * 2, 8);
        //        if (strFourNNow.Contains(ssNow))
        //        {
        //            str456 = str456.Replace("ok", "o");
        //            str456 += "*4";
        //            countNow++;
        //        }
        //        if (strFourNUp.Contains(ssUp))
        //        {
        //            str456 = str456.Replace("ok", "o");
        //            str456 += "|4";
        //            countUp++;
        //        }
        //        if (strFourN.Contains(ssLeft))
        //        {
        //            str456 = str456.Replace("ok", "o");
        //            str456 += "-4";
        //            countLeft++;
        //        }
        //        if (countUp + countNow + countLeft >= 2)
        //        {
        //            data = false;
        //            if (!_One)
        //                break;
        //        }
        //    }
        //    if (countLeft == 0 && countNow == 0 && countUp == 0)
        //    {
        //        if (strFourNowBall.Contains(ssNow))
        //        {
        //            str456 += "*ok4";
        //        }
        //        if (strFourUpBall.Contains(ssUp))
        //        {
        //            str456 += "|ok4";
        //        }
        //        if (strFourBall.Contains(ssLeft))
        //        {
        //            str456 += "-ok4";
        //        }
        //    }
        //}     
        if (str456 == "")
            str456 = "ok";
        if (!str456.Contains("ok") && data)
            str456 += "ok";

        return "Left:" + strLeft + "/Up:" + strUp + "/456:" + str456;
    }

    private int FindHowManyUp(int a1, int a2, int a3, int a4, int a5, int a6, string strInput)
    {
        int count = 0;
        string[] str = strInput.Split('|');
        if (int.Parse(str[a1 - 1]) < 3)
            count++;
        else if (int.Parse(str[a1 - 1]) > 20)
            count = 6;
        if (int.Parse(str[a2 - 1]) < 3)
            count++;
        else if (int.Parse(str[a2 - 1]) > 20)
            count = 6;
        if (int.Parse(str[a3 - 1]) < 3)
            count++;
        else if (int.Parse(str[a3 - 1]) > 20)
            count = 6;
        if (int.Parse(str[a4 - 1]) < 3)
            count++;
        else if (int.Parse(str[a4 - 1]) > 20)
            count = 6;
        if (int.Parse(str[a5 - 1]) < 3)
            count++;
        else if (int.Parse(str[a5 - 1]) > 20)
            count = 6;
        if (int.Parse(str[a6 - 1]) < 3)
            count++;
        else if (int.Parse(str[a6 - 1]) > 20)
            count = 6;
        return count;
    }
    private int FindHowMany(int a1,int a2, int a3, int a4, int a5, int a6, string strInput)
    {
        string[] str = strInput.Split('|'); 
        int count = 0;
        if (str.Contains(a1.ToString()))
            count++;
        if (str.Contains(a2.ToString()))
            count++;
        if (str.Contains(a3.ToString()))
            count++;
        if (str.Contains(a4.ToString()))
            count++;
        if (str.Contains(a5.ToString()))
            count++;
        if (str.Contains(a6.ToString()))
            count++;
        return count;
    }

    private int FindHowMany00(int a1, int a2, int a3, int a4, int a5, int a6, string strInput)
    {
        string[] str = strInput.Split(' ');
        int count = 0;
        if (str.Contains(a1.ToString("00")))
            count++;
        if (str.Contains(a2.ToString("00")))
            count++;
        if (str.Contains(a3.ToString("00")))
            count++;
        if (str.Contains(a4.ToString("00")))
            count++;
        if (str.Contains(a5.ToString("00")))
            count++;
        if (str.Contains(a6.ToString("00")))
            count++;
        return count;
    }

    private void Right_Left(int[,] redBall, int arrLintCount, string[] sameBall, string[] sameUpBall, string[] NowBall )
    {       

        for (int i = 1; i < arrLintCount; i++)
        {      
            int min = 0;
            for (int j = 0; j < 33; j++)
            {
                if (redBall[j, i] == 1)
                {
                    sameBall[i] += (j - min).ToString("00"); 
                    min = j + 1;

                    int up = FindUpNumber(i, j, arrLintCount, redBall);                    

                    sameUpBall[i] += up.ToString("00");

                    NowBall[i] += (j + 1).ToString("00");
                }
            }

        }       
    }

    private int FindUpNumber(int i, int j, int arrLintCount, int[,] redBall)
    {
        int output = 0;
        bool find = false;
        int ii = i + 1;
        while (!find)
        {
            if (ii >= arrLintCount && arrLintCount != 2)
                find = true;
            else if (redBall[j, ii] == 1)
            {
                output = ii - i - 1;
                find = true;
            }
            else
                ii++;
        }

        return output;
    }

    protected void btnResult_Click(object sender, EventArgs e)
    {
        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        StreamReader smRead = new StreamReader(strPath + "\\Result.txt", System.Text.Encoding.Default);
        string line;
        _DT = CreateTableHangZhou();
        bool result = true;
        bool find = false;
        while ((line = smRead.ReadLine()) != null && result)
        {
            if (find)
            {
                string[] str = line.Split(' ');
                string[] spss = line.Split('#');
                DataRow newRow;
                newRow = _DT.NewRow();

                string[] round = str[0].Split('-');
                newRow["Round"] = round[2];
                newRow["Flag"] = "ball";
                newRow["ResultTwo"] = round[0].Substring(0, 1);
                newRow["ResultOne"] = round[0].Substring(1, 1);
 
                if (str.Length >= 2)
                {
                    if (str[0].Contains("ROUND:2017059"))
                    {

                    }

                    if (str[1].Contains("UPUP_NoCount"))
                    {
                        if (str[1].Contains("UPUP_NoCount1"))
                            newRow["UPUP_NoCount"] = 2;
                        else
                            newRow["UPUP_NoCount"] = 1;
                    }
                    else
                        newRow["UPUP_NoCount"] = 0;

                    if (str[1].Contains("People_NoCount"))
                    {
                        if (str[1].Contains("People_NoCount1"))
                            newRow["Add0"] = 2;
                        else
                            newRow["Add0"] = 1;
                    }
                    else
                        newRow["Add0"] = 0;

                    if (str[1].Contains("_People_Str_Count_All"))
                        newRow["Add1"] = 2;
                    else
                        newRow["Add1"] = 0;

                    if (str[1].Contains("TwoDimension"))
                        newRow["add2"] = 2;
                    else
                        newRow["add2"] = 0;

                    if (str[1].Contains("_People_Str_Count_One"))
                        newRow["Add3"] = 2;
                    else
                        newRow["Add3"] = 0;

                    if (str[1].Contains("Analyze_Belong"))
                        newRow["Add4"] = 2;
                    else
                        newRow["Add4"] = 0;

                    if (str[1].Contains("StyleUpSum30"))
                        newRow["Add5"] = 2;
                    else
                        newRow["Add5"] = 0;

                    if (str[1].Contains("NearRepeat22_NoCount"))
                    {
                        if (str[1].Contains("NearRepeat22_NoCount1"))
                            newRow["NearRepeat22_NoCount"] = 2;
                        else
                            newRow["NearRepeat22_NoCount"] = 1;
                    }
                    else
                        newRow["NearRepeat22_NoCount"] = 0;

                    if (str[1].Contains("Repeat22_Select"))
                    {
                        //if (str[1].Contains("Repeat22_Select1"))
                            newRow["Repeat22_Select"] = 2;
                        //else
                        //    newRow["Repeat22_Select"] = 1;
                    }
                    else
                        newRow["Repeat22_Select"] = 0;

                    if (str[1].Contains("StrMiniRed"))
                    {
                        if (str[1].Contains("StrMiniRed1"))
                            newRow["StrMiniRed"] = 2;
                        else
                            newRow["StrMiniRed"] = 1;
                    }
                    else
                        newRow["StrMiniRed"] = 0;

                    if (str[1].Contains("Str456"))
                    {
                        if (str[1].Contains("Str4561"))
                            newRow["Str456"] = 2;
                        else
                            newRow["Str456"] = 1;
                    }
                    else
                        newRow["Str456"] = 0;

                    if (str[1].Contains("ISPrime"))
                        newRow["ISPrime"] = 1;
                    else
                        newRow["ISPrime"] = 0;

                    if (str[1].Contains("ISTwo"))
                        newRow["ISTwo"] = 1;
                    else
                        newRow["ISTwo"] = 0;

                    if (str[1].Contains("ISNearRepeat"))
                        newRow["ISNearRepeat"] = 1;
                    else
                        newRow["ISNearRepeat"] = 0;

                    if (str[1].Contains("SubSub"))
                        newRow["SubSub"] = 2;
                    else
                        newRow["SubSub"] = 0;

                    if (str[1].Contains("SumUp30Ball"))
                        newRow["SumUp30Ball"] = 2;
                    else
                        newRow["SumUp30Ball"] = 0;

                    if (str[1].Contains("SumUpUpBall"))
                        newRow["SumUpUpBall"] = 2;
                    else
                        newRow["SumUpUpBall"] = 0;

                    if (str[1].Contains("PrimeTwoNearRepeat"))
                        newRow["PrimeTwoNearRepeat"] = 2;
                    else
                        newRow["PrimeTwoNearRepeat"] = 0;

                    if (str[1].Contains("SixBallSum"))
                        newRow["SixBallSum"] = 2;
                    else
                        newRow["SixBallSum"] = 0;
                    
                    if (str[1].Contains("FindCount"))
                    {
                        if (str[1].Contains("[7]"))
                            newRow["FindCount7"] = 2;
                        else
                            newRow["FindCount7"] = 0;
                        if (str[1].Contains("[6]"))
                            newRow["FindCount6"] = 2;
                        else
                            newRow["FindCount6"] = 0;
                        if (str[1].Contains("[5]"))
                            newRow["FindCount5"] = 2;
                        else
                            newRow["FindCount5"] = 0;
                        if (str[1].Contains("[4]"))
                            newRow["FindCount4"] = 2;
                        else
                            newRow["FindCount4"] = 0;
                        if (str[1].Contains("[3]"))
                            newRow["FindCount3"] = 2;
                        else
                            newRow["FindCount3"] = 0;
                        if (str[1].Contains("[2]"))
                            newRow["FindCount2"] = 2; 
                        else
                            newRow["FindCount2"] = 0;
                        if (str[1].Contains("[1]"))                        
                            newRow["FindCount1"] = 2;                        
                        else
                            newRow["FindCount1"] = 0;
                        if (str[1].Contains("[0]"))
                            newRow["FindCount0"] = 2;
                        else
                            newRow["FindCount0"] = 0;
                    }
                }


                if (spss.Length >= 2)
                {
                    string[] spssNew = spss[1].Split('|');
                    int count = 0;
                    newRow["Data"] = GetSpssResult(spssNew[0], ref count);
                    newRow["Data1"] = GetSpssResult(spssNew[1], ref count);
                    newRow["Data2"] = GetSpssResult(spssNew[2], ref count);
                    newRow["Data3"] = GetSpssResult(spssNew[3], ref count);
                    count = count * 10;

                    newRow["Mini0"] = GetSpssResult(spssNew[5], ref count);
                    newRow["Mini1"] = GetSpssResult(spssNew[6], ref count);
                    newRow["Mini2"] = GetSpssResult(spssNew[7], ref count);
                    newRow["Mini3"] = GetSpssResult(spssNew[8], ref count);
                    newRow["Mini4"] = GetSpssResult(spssNew[9], ref count);
                    newRow["Mini5"] = GetSpssResult(spssNew[10], ref count);
                    count = count * 10;

                    //newRow["Data"] = Convert.ToDecimal(spssNew[0].Split('_')[0]) - Convert.ToDecimal(spssNew[0].Split('_')[1]);
                    //newRow["Data1"] = Convert.ToDecimal(spssNew[1].Split('_')[0]) - Convert.ToDecimal(spssNew[1].Split('_')[1]);
                    //newRow["Data2"] = Convert.ToDecimal(spssNew[2].Split('_')[0]) - Convert.ToDecimal(spssNew[2].Split('_')[1]);
                    //newRow["Data3"] = Convert.ToDecimal(spssNew[3].Split('_')[0]) - Convert.ToDecimal(spssNew[3].Split('_')[1]);
                    //newRow["Data33"] = spssNew[4];

                    //newRow["Mini0"] = Convert.ToDecimal(spssNew[5].Split('_')[0]) - Convert.ToDecimal(spssNew[5].Split('_')[1]);
                    //newRow["Mini1"] = Convert.ToDecimal(spssNew[6].Split('_')[0]) - Convert.ToDecimal(spssNew[6].Split('_')[1]);
                    //newRow["Mini2"] = Convert.ToDecimal(spssNew[7].Split('_')[0]) - Convert.ToDecimal(spssNew[7].Split('_')[1]);
                    //newRow["Mini3"] = Convert.ToDecimal(spssNew[8].Split('_')[0]) - Convert.ToDecimal(spssNew[8].Split('_')[1]);
                    //newRow["Mini4"] = Convert.ToDecimal(spssNew[9].Split('_')[0]) - Convert.ToDecimal(spssNew[9].Split('_')[1]);
                    //newRow["Mini5"] = Convert.ToDecimal(spssNew[10].Split('_')[0]) - Convert.ToDecimal(spssNew[10].Split('_')[1]);

                    if (spssNew.Length > 11)
                    {
                        newRow["TwoSpss"] = GetSpssResult(spssNew[11], ref count);
                        newRow["PrimeSpss"] = GetSpssResult(spssNew[12], ref count);
                        newRow["NearRepeatSpss"] = GetSpssResult(spssNew[13], ref count);

                        if (spssNew.Length > 14)
                        {
                            newRow["TPNRSum"] = GetSpssResult(spssNew[14], ref count);
                        }
                        else
                            newRow["TPNRSum"] = 0;
                        //newRow["TwoSpss"] = Convert.ToDecimal(spssNew[11].Split('_')[0]) - Convert.ToDecimal(spssNew[11].Split('_')[1]);
                        //newRow["PrimeSpss"] = Convert.ToDecimal(spssNew[12].Split('_')[0]) - Convert.ToDecimal(spssNew[12].Split('_')[1]);
                        //newRow["NearRepeatSpss"] = Convert.ToDecimal(spssNew[13].Split('_')[0]) - Convert.ToDecimal(spssNew[13].Split('_')[1]);
                    }
                    else
                    {
                        newRow["TwoSpss"] = 0;
                        newRow["PrimeSpss"] = 0;
                        newRow["NearRepeatSpss"] = 0;
                        newRow["TPNRSum"] = 0;

                    }
                    newRow["Data33"] = count;
                }
                else 
                {
                    newRow["Data"] = 0;
                    newRow["Data1"] = 0;
                    newRow["Data2"] = 0;
                    newRow["Data3"] = 0;
                    newRow["Data33"] = 0;

                    newRow["Mini0"] = 0;
                    newRow["Mini1"] = 0;
                    newRow["Mini2"] = 0;
                    newRow["Mini3"] = 0;
                    newRow["Mini4"] = 0;
                    newRow["Mini5"] = 0;
                    newRow["TPNRSum"] = 0;
                }

                //newRow["Add0"] = 0;
                //newRow["Add1"] = 0;
                //newRow["Add2"] = 0;
                //newRow["Add3"] = 0;
                //newRow["Add4"] = 0;
                //newRow["Add5"] = 0;
                newRow["Add6"] = 0;
                newRow["Add7"] = 0;
                newRow["Add8"] = 0;
                newRow["Add9"] = 0;

                _DT.Rows.Add(newRow);
            }

            if (line == "------------------------------------------------------------------------------------------------------------------------")
            {
                find = true;
            }

            if (line.Contains("00--ROUND:0000000"))
            {
                result = false;
            }
        }
        smRead.Close();
        System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source = .; Initial Catalog = Test; User Id = sa; Password = suyu57501;");
        bcp.DestinationTableName = "dbo.HangZhou";
        bcp.WriteToServer(_DT);
        MyGoal.InnerHtml += NewNumber.DisplayStr("ResultOK", "red");
    }

    //private decimal GetSpssResult(string input)
    //{
    //    string[] str = input.Split('_');

    //    if (str.Length == 2)
    //    { return Convert.ToDecimal(str[0]) - Convert.ToDecimal(str[1]); }
    //    else if (str.Length == 3)
    //    {
    //        if(str[0] == str[2])
    //            return Convert.ToDecimal(str[1]) - Convert.ToDecimal(str[2]);
    //        else if (str[1] == str[2])
    //            return Convert.ToDecimal(str[0]) - Convert.ToDecimal(str[2]);
    //        else if ((Convert.ToDouble(str[0]) - Convert.ToDouble(str[2])) * (Convert.ToDouble(str[1]) - Convert.ToDouble(str[2])) > 0)            
    //            return  Convert.ToDecimal(Math.Sqrt(Math.Abs((Convert.ToDouble(str[0]) - Convert.ToDouble(str[2]))) * Math.Abs((Convert.ToDouble(str[1]) - Convert.ToDouble(str[2])))));
    //        else
    //            return -1 * Convert.ToDecimal(Math.Sqrt(Math.Abs((Convert.ToDouble(str[0]) - Convert.ToDouble(str[2]))) * Math.Abs((Convert.ToDouble(str[1]) - Convert.ToDouble(str[2])))));
    //    }
    //    else
    //    { return 0; }
    //}

    private decimal GetSpssResult(string input, ref int count)
    {
        string[] str = input.Split('_');

        if (str.Length == 2)
        { return Convert.ToDecimal(str[0]) - Convert.ToDecimal(str[1]); }
        else if (str.Length == 3)
        {
            if (Math.Abs(Convert.ToDouble(str[1]) - Convert.ToDouble(str[0])) <= 1)
            {
                count++;
                return 100;
            }
            else if (str[0] == str[2])
            {                
                return 0;
            }
            else
            {
                if ((Convert.ToDouble(str[0]) - Convert.ToDouble(str[2])) * (Convert.ToDouble(str[1]) - Convert.ToDouble(str[2])) > 0)
                {
                    count++;
                    return Convert.ToDecimal(Math.Sqrt(Math.Abs((Convert.ToDouble(str[0]) - Convert.ToDouble(str[2]))) * Math.Abs((Convert.ToDouble(str[1]) - Convert.ToDouble(str[2])))));

                }
                else
                    return -1 * Convert.ToDecimal(Math.Sqrt(Math.Abs((Convert.ToDouble(str[0]) - Convert.ToDouble(str[2]))) * Math.Abs((Convert.ToDouble(str[1]) - Convert.ToDouble(str[2])))));

            }
        }
        else
        { return 0; }
    }

    protected void btnHand_Click(object sender, EventArgs e)
    {
        //_DT = new DataTable();


        string str = txtHand.Text;

        str = str.Replace("\r\n", "-");
        str = str.Replace("\t", "#");
        string[] input = str.Split('-');
        ArrayList al = new ArrayList();
        if (input[0].Contains('#'))
        {
            str = hiddenTxt.Value;
            if (str == "")
                txtHand1.Text = "hiddenTxt.Value = ''";
            else
                al = MyTest.MyFourToSix(input, 33, ref _DT, _RedBall, str);
        }
        else
        {            
            al = MyTest.MySelect(input, 33, ref _DT);
            hiddenTxt.Value = str;
        }

        System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source = .; Initial Catalog = Test; User Id = sa; Password = suyu57501;");
        bcp.DestinationTableName = "dbo.TestOutput";
        bcp.WriteToServer(_DT);
        MyGoal.InnerHtml += NewNumber.DisplayStr("ResultOK", "red");
    }
}


            