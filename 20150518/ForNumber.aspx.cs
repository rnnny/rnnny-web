using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using SplashCheck;

public partial class _20150518_ForNumber : System.Web.UI.Page
{

    #region 变量
    private const int MaxMax = MyTest.MaxMax;
    private ArrayList _ArrRound = new ArrayList();
    private ArrayList _ArrGoal = new ArrayList();
    //private const int MaxCount = 5;
    private DataTable _DT = new DataTable();
    private int[] _BlueBall = new int[MaxMax];
    private int[] _SixSum = new int[MaxMax];//6个红ball和值
    private int[,] _RedBall = new int[33, MaxMax];
    private int[,] _MiniRedBall = new int[6, MaxMax];
    private bool _Data = false;
    private bool _Print = false;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        _DT = CreateTable();

        string dataBase = "";

        int maxCount = 10000;
        //string dataBase = "Test";

        //int maxCount = 1000;
        //string dataBase = "TestNew";

        MyTest.ReadFile(_ArrRound,_ArrGoal, _RedBall, _MiniRedBall, _BlueBall, _SixSum, maxCount, "ball");

        //_Data = true;
        //Combination(_Data);

        #region ForSpssModeler
        //dataBase = "TestNew";
        //_Data = false;
        //_Print = true;
        //CreateSpssModelerData(_ArrRound, _MiniRedBall, _RedBall, _BlueBall, _ArrGoal);
        #endregion

        #region TwoNearRepeat
        //777788
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //TwoNearRepeat(_ArrRound, _MiniRedBall, _RedBall);
        #endregion

        #region UpSumMyGame
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //UpSumMyGame(_RedBall, _ArrRound, 30);
        #endregion

        #region GM(1,1)
        //int a = 1;//几维
        //int b = 8;//一维几个输入的数字
        //int d = 10;//要向下预测几个结果
        //double[] input = { 9.93, 9.96, 9.98, 9.95, 9.93, 9.92, 9.94, 9.93 };//{ 188, 208, 215, 192, 224, 215, 176, 207, 214, 191, 154, 172, 223, 257, 281, 231, 199, 240, 251, 194 };
        //_Data = false;
        //_Print = true;
        //GMOneOne(a, b, d, input);
        #endregion

        #region Score
        //33个红球打分之旅
        //_Data = false;
        //_Print = true;
        //Score01(_RedBall, _ArrRound);

        //Score33(_RedBall, _ArrRound);
        #endregion

        #region SelectSomeRed
        //遗传算法
        //dataBase = "TestNew";
        //_Data = true;//777777
        //_Print = true;
        //SelectTwoDimension(_ArrRound, _MiniRedBall, _RedBall);//3-11二维组合 <5

        //SelectSomeRed(_ArrRound, _MiniRedBall, _RedBall);
        #endregion

        #region OftenGoal
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //OftenGoal(_MiniRedBall, _ArrRound, _RedBall);
        #endregion

        #region NoNormal
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //DoBeiJing(_ArrRound, _MiniRedBall, _RedBall);

        //NoNormal(_ArrRound, _MiniRedBall);
        #endregion

        #region UPUP
        //获得不可能出现的数字
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //UPUP(_RedBall, _ArrRound);

        //UPUPEverySum(_RedBall, _ArrRound);
        //UPUP33Sum(_RedBall, _MiniRedBall, _ArrRound);
        #endregion

        #region BlueAndSix
        //以及6个红球之和的统计分析
        //dataBase = "Test";
        //_Data = true;
        //_Print = true;
        //BlueLeftRight(_BlueBall, _ArrRound, _SixSum, _MiniRedBall, _RedBall);



        //BlueAndSixGroup(_BlueBall, _RedBall,_ArrRound);
        #endregion

        #region OneByOne
        //分析按照每个数字一定范围内出现的次数分类
        //dataBase = "Test";
        //_Data = false;
        //_Print = true;
        //DisplayOneByOne(_RedBall, _ArrRound, 3, 7);
        //Right_Left(_RedBall, _ArrRound, 2);

        //_Data = true;
        //_Print = false;
        //for (int i = 3; i <= 9; i++)//i不能大于10
        //    for (int j = 4; j <= 20; j++)
        //    {
        //        if (j >= i)
        //            DisplayOneByOne(_RedBall, _ArrRound, i, j);
        //    }     
        
        #endregion

        #region Right--
        //分析按照左右上下相邻命中数字之差
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //Right_Left(_RedBall, _ArrRound, _ArrRound.Count);
        #endregion

        #region Graph
        //_Data = false;
        //_Print = true;
        //GraphFindAllLine(_RedBall, _ArrRound, 5);
        ////GraphFindBlueLine(_BlueBall, _ArrRound, 10);

        //GraphFind(_RedBall, _ArrRound);
        #endregion

        #region Analyze
        dataBase = "TestNew";
        _Data = true;
        _Print = true;
        Analyze(_RedBall, _MiniRedBall, _ArrRound);

        //AnalyzeOneBall(_RedBall, _MiniRedBall, _ArrRound);
        //Analyze_01(_RedBall, _MiniRedBall, _ArrRound);
        //AnalyzeSumSix(_RedBall, _MiniRedBall, _ArrRound);
        #endregion

        #region FourOrThree
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //Four(_RedBall, _MiniRedBall, _ArrRound);
        //Three(_RedBall, _MiniRedBall, _ArrRound);
        #endregion

        #region TestHMMCS
        //dataBase = "TestNew";
        //_Data = true;
        //_Print = true;
        //string hmmStr = TestHMMCS.CheckForwardAndBackward();
        //MyGoal.InnerHtml += NewNumber.DisplayStr("前向算法：双精度运算:" + hmmStr.Split('|')[0], "blue", _Print);
        //MyGoal.InnerHtml += NewNumber.DisplayStr("后向算法：双精度运算:" + hmmStr.Split('|')[1], "blue", _Print); 
        //// 测试维特比算法
        //TestHMMCS.CheckViterbi();

        //// 测试HMM学习算法
        //TestHMMCS.CheckBaumWelch();
        #endregion

        if (_Data)
        {
            System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source = .; Initial Catalog = " + dataBase + "; User Id = sa; Password = suyu57501;");
            bcp.DestinationTableName = "dbo.TestOutput";
            bcp.WriteToServer(_DT);
        }


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

    #region FourOrThree
    private void Three(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        for (int i = arrRound.Count - 2; i >= 1; i--)
        {
            string strInput = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
            bool one = true;
            for (int j = i + 1; j <= arrRound.Count - 1; j++)
            {
                if (redBall[miniRedBall[0, i] - 1, j] + redBall[miniRedBall[1, i] - 1, j] + redBall[miniRedBall[2, i] - 1, j] + redBall[miniRedBall[3, i] - 1, j] + redBall[miniRedBall[4, i] - 1, j] + redBall[miniRedBall[5, i] - 1, j] == 3)
                {
                    DataRow newRow;
                    newRow = _DT.NewRow();
                    int[] newJ = new int[3];
                    int jj = 0;
                    for (int x = 0; x < 6;  x++ )
                    {
                        if (redBall[miniRedBall[x, i] - 1, j] == 0)
                        {
                            newJ[jj] = miniRedBall[x, i] - 1;
                            jj++;
                            
                        }
                        else
                        {
                            newRow["a29"] += miniRedBall[x, i].ToString() + "|";
                        }
                    }

                    bool two = false;
                    for (int y = 1; y <= arrRound.Count - 1 - j; y++ )
                    {
                        if (redBall[newJ[0], j + y] + redBall[newJ[1], j + y] + redBall[newJ[2], j + y] == 3)
                        {
                            newRow["a28"] = arrRound[j + y].ToString();
                            newRow["a27"] = (newJ[0] + 1).ToString() + "|" + (newJ[1] + 1).ToString() + "|" + (newJ[2] + 1).ToString() + "|";
                            newRow["a1"] = y;
                            two = true;
                            break;
                        }
                    }
                    if(!two)
                        newRow["a1"] = -1;
                    newRow["a12"] = strInput;
                    newRow["round"] = arrRound[i].ToString();
                    newRow["a30"] = arrRound[j].ToString();
                    newRow["a13"] = miniRedBall[0, j] + "|" + miniRedBall[1, j] + "|" + miniRedBall[2, j] + "|" + miniRedBall[3, j] + "|" + miniRedBall[4, j] + "|" + miniRedBall[5, j];

                    newRow["a2"] = j - i;
                    newRow["a26"] = one;
                    newRow["FLAG"] = Define._ThreeFindFlag;//44444433
                    _DT.Rows.Add(newRow);

                    if (one)
                        one = false;
                    //break;
                }
            }           
        }
    }
    private void Four(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        for (int i = arrRound.Count - 2; i >= 1; i--)
        {
            string strInput = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
            string[] strFourFive = MyTest.GetFive(strInput).Split('-');
            bool one = true;
            for (int j = i + 1; j <= arrRound.Count - 1; j++)
            {
                if (redBall[miniRedBall[0, i] - 1, j] + redBall[miniRedBall[1, i] - 1, j] + redBall[miniRedBall[2, i] - 1, j] + redBall[miniRedBall[3, i] - 1, j] + redBall[miniRedBall[4, i] - 1, j] + redBall[miniRedBall[5, i] - 1, j] == 4)
                {
                    DataRow newRow;

                    newRow = _DT.NewRow();
                    newRow["a12"] = strInput;
                    newRow["round"] = arrRound[i].ToString();
                    newRow["a30"] = arrRound[j].ToString();
                    newRow["a13"]  = miniRedBall[0, j] + "|" + miniRedBall[1, j] + "|" + miniRedBall[2, j] + "|" + miniRedBall[3, j] + "|" + miniRedBall[4, j] + "|" + miniRedBall[5, j];
            
                    newRow["a2"] = j - i;
                    newRow["a30"] = one;
                    newRow["FLAG"] = Define._FourFindFlag;//44444488
                    _DT.Rows.Add(newRow);

                    if (one)
                        one = false;
                    //break;
                }
            }

            for (int j = 0; j < strFourFive.Length; j++)
            {
                if (strFourFive[j] != "")
                {
                    DataRow newRow;

                    newRow = _DT.NewRow();
                    if (j < 6)
                        newRow["a0"] = 5;
                    else
                        newRow["a0"] = 4;
                    newRow["round"] = arrRound[i].ToString();
                    newRow["a12"] = strInput;
                    newRow["a13"] = strFourFive[j];
                    if (strInput.Contains(strFourFive[j]))
                    {
                        string[] strMaxMin = strFourFive[j].Split('|');
                        newRow["a10"] = int.Parse(strMaxMin[0]);
                        newRow["a11"] = int.Parse(strMaxMin[strMaxMin.Length - 1]);
                        newRow["a9"] = int.Parse(strMaxMin[strMaxMin.Length - 1]) - int.Parse(strMaxMin[0]);
                    }
                    newRow["FLAG"] = Define._FourFlag;//444444
                    _DT.Rows.Add(newRow);
                }
            }
        }
    }
    #endregion

    #region Analyze
    private void Analyze_01(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        //sum two prime near repeat
        //平均命中率

        int[] countSum30 = new int[20];
        for (int i = arrRound.Count - 2; i >= 1; i--)
        {
            DataRow newRow;

            newRow = _DT.NewRow();
            newRow["round"] = arrRound[i].ToString();
            int sum = miniRedBall[0, i] + miniRedBall[1, i] + miniRedBall[2, i] + miniRedBall[3, i] + miniRedBall[4, i] + miniRedBall[5, i];
            int isPrime = MyTest.ISPrime(miniRedBall[0, i]) + MyTest.ISPrime(miniRedBall[1, i]) + MyTest.ISPrime(miniRedBall[2, i]) + MyTest.ISPrime(miniRedBall[3, i]) + MyTest.ISPrime(miniRedBall[4, i]) + MyTest.ISPrime(miniRedBall[5, i]);
            int isTwo = MyTest.ISTwo(miniRedBall[0, i]) + MyTest.ISTwo(miniRedBall[1, i]) + MyTest.ISTwo(miniRedBall[2, i]) + MyTest.ISTwo(miniRedBall[3, i]) + MyTest.ISTwo(miniRedBall[4, i]) + MyTest.ISTwo(miniRedBall[5, i]);
            int near = MyTest.ISNear(redBall, miniRedBall[0, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[1, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[2, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[3, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[4, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[5, i], i + 1);
            int repeat = MyTest.ISRepeat(redBall, miniRedBall[0, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[1, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[2, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[3, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[4, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[5, i], i + 1);
            newRow["a0"] = sum;
            newRow["a1"] = repeat;
            newRow["a2"] = near;
            newRow["a3"] = near + repeat;
            newRow["a4"] = isPrime;
            newRow["a5"] = isTwo;
            newRow["a6"] = miniRedBall[5, i] - miniRedBall[0, i];
            newRow["a7"] = MyTest.FindUpNumber(i, miniRedBall[0, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[1, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[2, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[3, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[4, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[5, i] - 1, arrRound.Count - 1, redBall);
            newRow["a8"] = near + repeat + isPrime + isTwo;
            newRow["a12"] = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
            newRow["a13"] = repeat + "|" + near + "|" + isPrime + "|" + isTwo;

            
            int sum30 = 0;
            int[] miniSum30 = new int[6];
            int min30 = 0;
            int max30 = 0;

            if (i + 30 <= arrRound.Count - 1)
            {

                for (int x = 0; x < 6; x++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        sum30 += redBall[miniRedBall[x, i] - 1, i + j + 1];
                        miniSum30[x] += redBall[miniRedBall[x, i] - 1, i + j + 1];
                    }
                    if (min30 == 0)
                        min30 = miniSum30[x];

                    if (min30 > miniSum30[x])
                        min30 = miniSum30[x];
                    if (max30 < miniSum30[x])
                        max30 = miniSum30[x];


                   // newRow["a2" + x.ToString()] = miniSum30[x];
                    countSum30[miniSum30[x]]++;
                }

                string strC = "";
                for (int x = 0; x < 6; x++)
                {
                    if (miniSum30[x] >= 9)
                        newRow["a26"] = "A" + newRow["a26"];
                    else if (miniSum30[x] >= 3)
                        newRow["a26"] += "B";
                    else
                        strC += "C";
                }
                newRow["a26"] += strC;
            }
            newRow["a27"] = NewNumber.GetTwoNearRepeatRound(redBall, miniRedBall[0, i], miniRedBall[1, i], miniRedBall[2, i], miniRedBall[3, i], miniRedBall[4, i], miniRedBall[5, i], i);

            int[] sub = new int[6];
            sub[0] = miniRedBall[0, i] - 1 + 33 - miniRedBall[5, i];
            sub[1] = miniRedBall[1, i] - miniRedBall[0, i] - 1;
            sub[2] = miniRedBall[2, i] - miniRedBall[1, i] - 1;
            sub[3] = miniRedBall[3, i] - miniRedBall[2, i] - 1;
            sub[4] = miniRedBall[4, i] - miniRedBall[3, i] - 1;
            sub[5] = miniRedBall[5, i] - miniRedBall[4, i] - 1;
            //sub[6] = 33 - a6;
            // string strSub = sub[0].ToString() + "-" + sub[1].ToString() + "-" + sub[2].ToString() + "-" + sub[3].ToString() + "-" + sub[4].ToString() + "-" + sub[5].ToString();// +"-" + sub[6].ToString();//无用
            string strSubSub = MyTest.GetSubStr(sub);
            newRow["a28"] = strSubSub;

            ArrayList al = new ArrayList();
            al.Add(MyTest.FindUpNumber(i, miniRedBall[0, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[1, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[2, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[3, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[4, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[5, i] - 1, arrRound.Count - 1, redBall));
            newRow["a29"] = al[0].ToString() + "|" + al[1].ToString() + "|" + al[2].ToString() + "|" + al[3].ToString() + "|" + al[4].ToString() + "|" + al[5].ToString();
            al.Sort();

            newRow["a9"] = sum30;
            newRow["a10"] = int.Parse(al[0].ToString());
            newRow["a11"] = int.Parse(al[5].ToString());
            //for (int j = 0; j < al.Count; j++)
            //{
            //    newRow["a12"] += int.Parse(al[j].ToString()).ToString("00") + " ";
            //}
            newRow["FLAG"] = Define._Analyze01Flag;//99999901


            int[] lastNum = new int[10];
            int oneNumSum = 0;
            int lastNumSum = 0;
            int mathSum = 0;
            string strOne = "";
            al = new ArrayList();
            al.Add(miniRedBall[0, i]);
            al.Add(miniRedBall[1, i] - miniRedBall[0, i]);
            al.Add(miniRedBall[2, i] - miniRedBall[1, i]);
            al.Add(miniRedBall[3, i] - miniRedBall[2, i]);
            al.Add(miniRedBall[4, i] - miniRedBall[3, i]);
            al.Add(miniRedBall[5, i] - miniRedBall[4, i]);
            al.Add(33 - miniRedBall[5, i]);
            for (int x = 0; x < al.Count; x++)
            {
                newRow["a17"] += al[x].ToString() + "|";
            }
            al.Sort();
            for (int x = 0; x < al.Count; x++)
            {
                newRow["a18"] = al[x].ToString() + "|" + newRow["a18"];
            }
            for (int x = 0; x < 6; x++)
            {
                mathSum += Math.Abs(miniRedBall[x, i] - miniRedBall[x, i + 1]);
                newRow["a" + x.ToString()] = Math.Abs(miniRedBall[x, i] - miniRedBall[x, i + 1]);
                if (miniRedBall[x, i] < 10)
                {
                    strOne += "0";
                    lastNumSum += miniRedBall[x, i];
                    newRow["a2" + x.ToString()] = miniRedBall[x, i];
                    lastNum[miniRedBall[x, i]]++;
                }
                else
                {
                    string begin = miniRedBall[x, i].ToString().Substring(0, 1);
                    strOne += begin;
                    oneNumSum += int.Parse(begin);
                    string end = miniRedBall[x, i].ToString().Substring(1, 1);
                    newRow["a2" + x.ToString()] = end;
                    lastNumSum += int.Parse(end);
                    lastNum[int.Parse(end)]++;
                }
            }
            newRow["a6"] = mathSum;
            newRow["a10"] = min30;
            newRow["a11"] = max30;
            newRow["a27"] = lastNumSum;
            newRow["a28"] = strOne;
            newRow["a29"] = oneNumSum;
            newRow["a19"] = sum;
            for (int x = 0; x < 10; x++)
            {
                if (lastNum[x] != 0)
                    for (int y = 0; y < lastNum[x]; y++)
                    {
                        newRow["a26"] += x.ToString();
                    }
            }

            newRow["FLAG"] = Define._AnalyzeTwoFlag;//99999900
            _DT.Rows.Add(newRow);
        }

    }
    private void AnalyzeOneBall(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        for (int i = arrRound.Count - 2; i >= 1; i--)
        {
            DataRow newRow;
            int sum = miniRedBall[0, i] + miniRedBall[1, i] + miniRedBall[2, i] + miniRedBall[3, i] + miniRedBall[4, i] + miniRedBall[5, i];
            int isPrime = MyTest.ISPrime(miniRedBall[0, i]) + MyTest.ISPrime(miniRedBall[1, i]) + MyTest.ISPrime(miniRedBall[2, i]) + MyTest.ISPrime(miniRedBall[3, i]) + MyTest.ISPrime(miniRedBall[4, i]) + MyTest.ISPrime(miniRedBall[5, i]);
            int isTwo = MyTest.ISTwo(miniRedBall[0, i]) + MyTest.ISTwo(miniRedBall[1, i]) + MyTest.ISTwo(miniRedBall[2, i]) + MyTest.ISTwo(miniRedBall[3, i]) + MyTest.ISTwo(miniRedBall[4, i]) + MyTest.ISTwo(miniRedBall[5, i]);
            int near = MyTest.ISNear(redBall, miniRedBall[0, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[1, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[2, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[3, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[4, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[5, i], i + 1);
            int repeat = MyTest.ISRepeat(redBall, miniRedBall[0, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[1, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[2, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[3, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[4, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[5, i], i + 1);
           
            for (int j = 0; j < 6; j++)
            {
                newRow = _DT.NewRow();
                newRow["round"] = arrRound[i].ToString();
                newRow["a0"] = sum;
                newRow["a1"] = repeat;
                newRow["a2"] = near;
                newRow["a3"] = near + repeat;
                newRow["a4"] = isPrime;
                newRow["a5"] = isTwo;
                newRow["a6"] = miniRedBall[5, i] - miniRedBall[0, i];
                newRow["a7"] = miniRedBall[j, i];
                newRow["FLAG"] = Define._AnalyzeOneBallFlag;//99999902
                _DT.Rows.Add(newRow);
            }
        }
    }

    private void AnalyzeSumSix(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        for (int aa = 1; aa < 100; aa++)
        {
            for (int i = arrRound.Count - aa - 1; i >= 1; i--)
            {
                DataRow newRow;
                int sum = 0;
                for (int bb = 0; bb < aa; bb++)
                {
                    sum += miniRedBall[0, i + bb] + miniRedBall[1, i + bb] + miniRedBall[2, i + bb] + miniRedBall[3, i + bb] + miniRedBall[4, i + bb] + miniRedBall[5, i + bb];
                }
                newRow = _DT.NewRow();
                newRow["round"] = arrRound[i].ToString();
                newRow["a0"] = sum;
                newRow["a1"] = aa;
                newRow["FLAG"] = Define._AnalyzeSumSixFlag;//99999966
                _DT.Rows.Add(newRow);
            } 
        }
    }

    private void Analyze(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        //sum two prime near repeat
        //平均命中率
        NormalDistribution nn = new NormalDistribution();
        int[] countSum30 = new int[20];
        for (int i = arrRound.Count - 2; i >= 1; i--)
        {
            DataRow newRow;

            newRow = _DT.NewRow();
            newRow["round"] = arrRound[i].ToString();
            int sum = miniRedBall[0, i] + miniRedBall[1, i] + miniRedBall[2, i] + miniRedBall[3, i] + miniRedBall[4, i] + miniRedBall[5, i];
            int isPrime = MyTest.ISPrime(miniRedBall[0, i]) + MyTest.ISPrime(miniRedBall[1, i]) + MyTest.ISPrime(miniRedBall[2, i]) + MyTest.ISPrime(miniRedBall[3, i]) + MyTest.ISPrime(miniRedBall[4, i]) + MyTest.ISPrime(miniRedBall[5, i]);
            int isTwo = MyTest.ISTwo(miniRedBall[0, i]) + MyTest.ISTwo(miniRedBall[1, i]) + MyTest.ISTwo(miniRedBall[2, i]) + MyTest.ISTwo(miniRedBall[3, i]) + MyTest.ISTwo(miniRedBall[4, i]) + MyTest.ISTwo(miniRedBall[5, i]);
            int near = MyTest.ISNear(redBall, miniRedBall[0, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[1, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[2, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[3, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[4, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[5, i], i + 1);
            int repeat = MyTest.ISRepeat(redBall, miniRedBall[0, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[1, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[2, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[3, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[4, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[5, i], i + 1);
            newRow["a0"] = sum;
            newRow["a1"] = repeat;
            newRow["a2"] = near;
            newRow["a3"] = near + repeat;
            newRow["a4"] = isPrime;
            newRow["a5"] = isTwo;
            newRow["a6"] = miniRedBall[5, i] - miniRedBall[0, i];
            newRow["a7"] = MyTest.FindUpNumber(i, miniRedBall[0, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[1, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[2, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[3, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[4, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[5, i] - 1, arrRound.Count - 1, redBall);
            newRow["a8"] = near + repeat + isPrime + isTwo;
            newRow["a12"] = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
            newRow["a13"] = repeat + "|" + near + "|" + isPrime + "|" + isTwo;

            string hope = MyTest.Belong(miniRedBall, i, 1);

            newRow["a14"] = hope.Split('_')[0];
            newRow["a15"] = hope.Split('_')[1];

            hope = MyTest.Belong(miniRedBall, i, 2);

            newRow["a16"] = hope.Split('_')[0];
            newRow["a17"] = hope.Split('_')[1];

            hope = MyTest.Belong(miniRedBall, i, 3);

            newRow["a18"] = hope.Split('_')[0];
            newRow["a19"] = hope.Split('_')[1];
            int sum30 = 0;
            int[] miniSum30 = new int[6];
            int min30 = 0;
            int max30 = 0;

            if (i + 30 <= arrRound.Count - 1)
            {
                
                for (int x = 0; x < 6; x++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        sum30 += redBall[miniRedBall[x, i] - 1, i + j + 1];
                        miniSum30[x] += redBall[miniRedBall[x, i] - 1, i + j + 1];
                    }
                    if (min30 == 0)
                        min30 = miniSum30[x];

                    if (min30 > miniSum30[x])
                        min30 = miniSum30[x];
                    if (max30 < miniSum30[x])
                        max30 = miniSum30[x];


                    newRow["a2" + x.ToString()] = miniSum30[x];
                    countSum30[miniSum30[x]]++;
                }

                string strC = "";
                for (int x = 0; x < 6; x++)
                {
                    if (miniSum30[x] >= 9)
                        newRow["a26"] = "A" + newRow["a26"];
                    else if (miniSum30[x] >= 3)
                        newRow["a26"] += "B";
                    else
                        strC += "C";
                }
                newRow["a26"] += strC;
            }
            newRow["a27"] = NewNumber.GetTwoNearRepeatRound(redBall, miniRedBall[0, i], miniRedBall[1, i], miniRedBall[2, i], miniRedBall[3, i], miniRedBall[4, i], miniRedBall[5, i], i);

            int[] sub = new int[7];
            sub[0] = miniRedBall[0, i];
            sub[1] = miniRedBall[1, i] - miniRedBall[0, i] - 1;
            sub[2] = miniRedBall[2, i] - miniRedBall[1, i] - 1;
            sub[3] = miniRedBall[3, i] - miniRedBall[2, i] - 1;
            sub[4] = miniRedBall[4, i] - miniRedBall[3, i] - 1;
            sub[5] = miniRedBall[5, i] - miniRedBall[4, i] - 1;
            sub[6] = 34 - miniRedBall[5, i];
           // string strSub = sub[0].ToString() + "-" + sub[1].ToString() + "-" + sub[2].ToString() + "-" + sub[3].ToString() + "-" + sub[4].ToString() + "-" + sub[5].ToString();// +"-" + sub[6].ToString();//无用
            string strSubSub = MyTest.GetSubStr(sub);
            newRow["a28"] = strSubSub;

            ArrayList al = new ArrayList();
            al.Add(MyTest.FindUpNumber(i, miniRedBall[0, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[1, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[2, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[3, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[4, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[5, i] - 1, arrRound.Count - 1, redBall));
            newRow["a29"] = al[0].ToString() + "|" + al[1].ToString() + "|" + al[2].ToString() + "|" + al[3].ToString() + "|" + al[4].ToString() + "|" + al[5].ToString();
            al.Sort();

            newRow["a9"] = sum30;
            newRow["a10"] = int.Parse(al[0].ToString());
            newRow["a11"] = int.Parse(al[5].ToString());
            //for (int j = 0; j < al.Count; j++)
            //{
            //    newRow["a12"] += int.Parse(al[j].ToString()).ToString("00") + " ";
            //}
            newRow["FLAG"] = Define._AnalyzeFlag;//999999
            _DT.Rows.Add(newRow);

            newRow = _DT.NewRow();
            newRow["round"] = arrRound[i].ToString();
            
            int[] lastNum = new int[10];
            int oneNumSum = 0;
            int lastNumSum = 0;
            int mathSum = 0;
            string strOne = "";
            int max = miniRedBall[0, i];
            int maxBegin = 0;
            int maxEnd = miniRedBall[0, i];
            if (miniRedBall[1, i] - miniRedBall[0, i] > max)
            {
                max = miniRedBall[1, i] - miniRedBall[0, i];
                maxBegin = miniRedBall[0, i];
                maxEnd = miniRedBall[1, i];
            }
            if (miniRedBall[2, i] - miniRedBall[1, i] > max)
            {
                max = miniRedBall[2, i] - miniRedBall[1, i];
                maxBegin = miniRedBall[1, i];
                maxEnd = miniRedBall[2, i];
            }
            if (miniRedBall[3, i] - miniRedBall[2, i] > max)
            {
                max = miniRedBall[3, i] - miniRedBall[2, i];
                maxBegin = miniRedBall[2, i];
                maxEnd = miniRedBall[3, i];
            }
            if (miniRedBall[4, i] - miniRedBall[3, i] > max)
            {
                max = miniRedBall[4, i] - miniRedBall[3, i];
                maxBegin = miniRedBall[3, i];
                maxEnd = miniRedBall[4, i];
            }
            if (miniRedBall[5, i] - miniRedBall[4, i] > max)
            {
                max = miniRedBall[5, i] - miniRedBall[4, i];
                maxBegin = miniRedBall[4, i];
                maxEnd = miniRedBall[5, i];
            }
            if (34 - miniRedBall[5, i] > max)
            {
                max = 34 - miniRedBall[5, i];
                maxBegin = miniRedBall[5, i];
                maxEnd = 34;
            }
            newRow["a12"] = max.ToString("00");
            newRow["a13"] = maxBegin;
            newRow["a14"] = maxEnd;
            newRow["a15"] = miniRedBall[0, i];
            newRow["a16"] = miniRedBall[5, i];

            List<double> dd = new List<double>();
            dd.Add(Convert.ToDouble(miniRedBall[0, i]));
            dd.Add(Convert.ToDouble(miniRedBall[1, i]));
            dd.Add(Convert.ToDouble(miniRedBall[2, i]));
            dd.Add(Convert.ToDouble(miniRedBall[3, i]));
            dd.Add(Convert.ToDouble(miniRedBall[4, i]));
            dd.Add(Convert.ToDouble(miniRedBall[5, i]));
            double ddd = nn.stdev(dd);
            double aaa = nn.average(dd);
            newRow["a20"] = ddd.ToString("0.0");
            newRow["a21"] = aaa.ToString("0.0");
            dd = new List<double>();
            dd.Add(Convert.ToDouble(miniRedBall[0, i]));
            dd.Add(Convert.ToDouble(miniRedBall[1, i] - miniRedBall[0, i]));
            dd.Add(Convert.ToDouble(miniRedBall[2, i] - miniRedBall[1, i]));
            dd.Add(Convert.ToDouble(miniRedBall[3, i] - miniRedBall[2, i]));
            dd.Add(Convert.ToDouble(miniRedBall[4, i] - miniRedBall[3, i]));
            dd.Add(Convert.ToDouble(miniRedBall[5, i] - miniRedBall[4, i]));
            dd.Add(Convert.ToDouble(33 - miniRedBall[5, i])); 
            ddd = nn.stdev(dd);
            aaa = nn.average(dd);
            newRow["a22"] = ddd.ToString("0.0");
            
            al = new ArrayList();
            al.Add(miniRedBall[0, i]);
            al.Add(miniRedBall[1, i] - miniRedBall[0, i]);
            al.Add(miniRedBall[2, i] - miniRedBall[1, i]);
            al.Add(miniRedBall[3, i] - miniRedBall[2, i]);
            al.Add(miniRedBall[4, i] - miniRedBall[3, i]);
            al.Add(miniRedBall[5, i] - miniRedBall[4, i]);
            al.Add(33-miniRedBall[5, i]);
            for (int x = 0; x < al.Count; x++)
            {
                newRow["a17"] += al[x].ToString() + "|";
            }
            al.Sort();
            for (int x = 0; x < al.Count; x++)
            {
                newRow["a18"] = al[x].ToString() + "|" + newRow["a18"];
            }
            for (int x = 0; x < 6; x++)
            {
                mathSum += Math.Abs(miniRedBall[x, i] - miniRedBall[x, i + 1]);
                newRow["a" + x.ToString()] = Math.Abs(miniRedBall[x, i] - miniRedBall[x, i + 1]);
                if (miniRedBall[x, i] < 10)
                {
                    newRow["a23"] += miniRedBall[x, i].ToString("00") + "|";
                    strOne += "0";
                    lastNumSum += miniRedBall[x, i];
                    //newRow["a2" + x.ToString()] = miniRedBall[x, i];
                    lastNum[miniRedBall[x, i]]++;
                }
                else
                {
                    if (miniRedBall[x, i] < 20)
                    {
                        newRow["a24"] += miniRedBall[x, i].ToString("00") + "|";
                    }
                    else if (miniRedBall[x, i] < 30)
                    {
                        newRow["a25"] += miniRedBall[x, i].ToString("00") + "|";
                    }
                    string begin = miniRedBall[x, i].ToString().Substring(0, 1);
                    strOne += begin;
                    oneNumSum += int.Parse(begin);
                    string end = miniRedBall[x, i].ToString().Substring(1, 1);
                    //newRow["a2" + x.ToString()] = end;
                    lastNumSum += int.Parse(end);
                    lastNum[int.Parse(end)]++;
                }
            }
            
            newRow["a6"] = mathSum;
            newRow["a10"] = min30;
            newRow["a11"] = max30;
            newRow["a27"] = lastNumSum;
            newRow["a28"] = strOne;
            newRow["a29"] = oneNumSum;
            newRow["a19"] = sum;
            newRow["a30"] = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
           
            for (int x = 0; x < 10; x++)
            {
                if (lastNum[x] != 0)
                    for (int y = 0; y < lastNum[x]; y++)
                    {
                        newRow["a26"] += x.ToString();
                    }
            }

            newRow["FLAG"] = Define._AnalyzeTwoFlag;//99999900
            _DT.Rows.Add(newRow);
        }

    }
    #endregion

    #region OftenGoal
    private void OftenGoal(int[,] miniRedBall, ArrayList arrRound, int[,] redBall)
    {
        ArrayList alSum = new ArrayList();
        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        FileStream fs = new FileStream(strPath + "\\spss\\data0123\\stdev.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        for (int i = arrRound.Count - 1; i >= 1; i--)
        {
            string input = miniRedBall[0,i].ToString() + "|" + miniRedBall[1,i].ToString() + "|" +miniRedBall[2,i].ToString() + "|" +miniRedBall[3,i].ToString() + "|" +miniRedBall[4,i].ToString() + "|" +miniRedBall[5,i].ToString();
            MyTest.GetFive(i, input, ref _DT, redBall,miniRedBall, arrRound);
            string strFile = MyTest.GetCircle(i, input, ref _DT, redBall, arrRound, alSum);

            if (strFile != "")
            {
                strFile = arrRound[i].ToString() + strFile;
                sw.WriteLine(strFile);
            }
        }

        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();

        //System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source = .; Initial Catalog = Test; User Id = sa; Password = suyu57501;");
        //bcp.DestinationTableName = "dbo.TestOutput";
        //bcp.WriteToServer(_DT);

        //string[] ss = new string[2];
        //ss[0] = "ABCDEFG";
        //ss[1] = "1234567";
        //if (ss.Contains("234567"))
        //{
        //    if (ss.Contains("ABC"))
        //    { }
        //}
       
    }
    #endregion

    #region TwoNearRepeat
    private void TwoNearRepeat(ArrayList arrRound, int[,] miniRedBall, int[,] redBall)
    {
        MyGoal.InnerHtml = NewNumber.TwoNearRepeat(arrRound, miniRedBall, redBall, ref _DT);
       
    }

    #endregion

    #region ForSpssModeler

    private void CreateSpssModelerData(ArrayList arrRound, int[,] miniRedBall, int[,] redBall, int[] blueBall, ArrayList arrGoal)
    {
        int count = arrRound.Count;

        int[] sum = new int[count];
        int[] leftRight = new int[count];
        int[] upup = new int[count];
        int[] mini0 = new int[count];
        int[] mini1 = new int[count];
        int[] mini2 = new int[count];
        int[] mini3 = new int[count];
        int[] mini4 = new int[count];
        int[] mini5 = new int[count];
        int[] two = new int[count];
        int[] prime = new int[count];
        int[] nearRepeat = new int[count];
        int[] tpnrSum = new int[count];
        //for (int i = 1; i < arrRound.Count; i++)
        for (int i = 1; i < count; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "brown", _Print);
            for (int j = 0; j < 6; j++)
            {
                sum[i] += miniRedBall[j, i];
                upup[i] += MyTest.FindUpNumber(i, miniRedBall[j, i] - 1, arrRound.Count - 1, redBall);
                two[i] += MyTest.ISTwo(miniRedBall[j, i]);
                prime[i] += MyTest.ISPrime(miniRedBall[j, i]);
                nearRepeat[i] += MyTest.ISNearRepeat(redBall, miniRedBall[j, i], i + 1);
                
            }

            tpnrSum[i] += two[i] + prime[i] + nearRepeat[i];
            leftRight[i] = miniRedBall[5, i] - miniRedBall[0, i];
            MyGoal.InnerHtml += NewNumber.DisplayStr(sum[i] + " || " + leftRight[i], "red", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            mini0[i] = miniRedBall[0, i];
            mini1[i] = miniRedBall[1, i]; 
            mini2[i] = miniRedBall[2, i]; 
            mini3[i] = miniRedBall[3, i]; 
            mini4[i] = miniRedBall[4, i]; 
            mini5[i] = miniRedBall[5, i];

            if (sum[i] > 135)
                sum[i] = 135;
            else if (sum[i] < 65)
                sum[i] = 65;

        }

        int select = 40;

        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        //FileStream fs = new FileStream(strPath + "\\spss\\data33\\33.txt", FileMode.Create);
        //StreamWriter sw = new StreamWriter(fs);


        for (int i = 0; i < 33; i++)
        {
            //string str = "";
            //int j = 0;            
            //while (j <= arrRound.Count - 1)
            //{
            //    int ii = MyTest.FindUpNumber(j, i, arrRound.Count - 1, redBall);
            //    j += ii + 1;
            //    str += ii.ToString() + " ";
            //}
            int[] sum30 = new int[count];
            int sumCount = 30;
            for (int j = 1; j < count; j++)
            {
                //if (j == 1)
                //{}
                int now = 0;
                for (int x = 0; x < sumCount; x++)
                {
                    now += redBall[i, j + x];
                }

                sum30[j] = now;
            }
            DisplaySpss(arrRound, select, sum30, "data33\\data" + i.ToString() + ".txt", count);
            //if (i % 2 == 0)
            //    SpssToFile((i + 1).ToString(), select, str.Substring(0, str.Length - 1), "blue", sw);
            //else
            //    SpssToFile((i + 1).ToString(), select, str.Substring(0, str.Length - 1), "green", sw);
        }

        //清空缓冲区
        //sw.Flush();
        ////关闭流
        //sw.Close();
        //fs.Close();

        FileStream fs = new FileStream(strPath + "\\spss\\data0123\\all.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        string strFile = string.Empty;
        for (int i = 1; i < arrGoal.Count; i++)
        {
            strFile = arrRound[i].ToString() +" " + arrGoal[i].ToString() + " " + sum[i].ToString() + " " + leftRight[i].ToString() + " " + upup[i].ToString() + " " + two[i].ToString() + " " + prime[i].ToString() + " " + nearRepeat[i].ToString();
            strFile = two[i].ToString() + " " + prime[i].ToString() + " " + nearRepeat[i].ToString(); 
            sw.WriteLine(strFile);
        }

        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();

        select = 20;


        DisplaySpss(arrRound, select, mini0, "mini\\miniNew0.txt" ,count);
        DisplaySpss(arrRound, select, mini1, "mini\\miniNew1.txt", count);
        DisplaySpss(arrRound, select, mini2, "mini\\miniNew2.txt", count);
        DisplaySpss(arrRound, select, mini3, "mini\\miniNEw3.txt", count);
        DisplaySpss(arrRound, select, mini4, "mini\\miniNew4.txt", count);
        DisplaySpss(arrRound, select, mini5, "mini\\miniNew5.txt", count);
        DisplaySpss(arrRound, select, sum, "data0123\\sum.txt", count);
        DisplaySpss(arrRound, select, leftRight, "data0123\\leftRight.txt", count);
        DisplaySpss(arrRound, select, blueBall, "data0123\\blueBall.txt", count);
        DisplaySpss(arrRound, select, upup, "data0123\\upup.txt", count);
        DisplaySpss(arrRound, select, two, "data0123\\two.txt", count);
        DisplaySpss(arrRound, select, prime, "data0123\\prime.txt", count);
        DisplaySpss(arrRound, select, nearRepeat, "data0123\\nearRepeat.txt", count);
        DisplaySpss(arrRound, select, tpnrSum, "data0123\\tpnrSum.txt", count);

    }

    private void SpssToFile(string now, int select, string input, string color, StreamWriter sw)
    {
        string[] str = input.Split(' ');

        for (int i = 0; i < str.Length - select; i++)
        {
            int sumAll = 0;
            string strFile = "";
            for (int j = 0; j < select; j++)
            {
                if (j <= 1)
                    sumAll = int.Parse(str[j + i].ToString());
                else
                    sumAll += int.Parse(str[j + i].ToString());
                if (j == 0)
                {                    
                    if(i == 0)
                        MyGoal.InnerHtml += NewNumber.DisplayStr(now + " ", color,_Print);
                    else
                        strFile += now + " ";
                }                
                if(i ==0)
                    MyGoal.InnerHtml += NewNumber.DisplayStr(sumAll + " ", color,_Print);
                else
                    strFile += sumAll + " ";
            }
            if (i == 0)
                MyGoal.InnerHtml += NewNumber.DisplayBROne(_Print);
            else
                //开始写入
                sw.WriteLine(strFile);
        }
        
    }

    private void DisplaySpss(ArrayList arrRound, int select, int[] input, string file, int count)
    {
        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        FileStream fs = new FileStream(strPath + "\\spss\\" + file, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        for (int i = 0; i < count - select; i++)
        {
            int sumAll = 0;
            string strFile = "";
            for (int j = 0; j < select; j++)
            {
                if (j <= 1)
                    sumAll = input[j + i];
                else
                    sumAll += input[j + i];
                if (j == 0)
                    strFile += i.ToString() + ",";
                    //MyGoal.InnerHtml += DisplayStr(sumAll / 10 + " ", color);
                strFile += sumAll + ",";
                //MyGoal.InnerHtml += DisplayStr(sumAll + " ", color);
            }
            //开始写入
            sw.WriteLine(strFile + arrRound[1].ToString() + "," + file.Split('\\')[1].Split('.')[0]);
            //MyGoal.InnerHtml += DisplayBROne();
        }


        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
 
    }
    #endregion

    #region UpSumMyGame
    private void UpSumMyGame(int[,] redBall, ArrayList arrRound, int sumCount)
    {
        for (int i = arrRound.Count - sumCount - 1; i > 0; i--)
        {
            DataRow newRow;
            int roundSum = 0;
            ArrayList al = new ArrayList();
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "blue",_Print);
            int A = 0;
            int C = 0;
            for (int j = 0; j < 33; j++)
            {
                int now = 0;
                for (int x = 0; x < sumCount; x++)
                {
                    now += redBall[j, i + x];
                }
                if (now <= 2)
                    C++;
                else if(now >=9)
                    A++;
                if (redBall[j, i] == 1)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(now.ToString("00") + " ", "red",_Print);
                    roundSum += now;
                    al.Add(now);
                }
                else
                    MyGoal.InnerHtml += NewNumber.DisplayStr(now.ToString("00") + " ", "green",_Print);

                
            }
            MyGoal.InnerHtml += NewNumber.DisplayStr(roundSum.ToString() + " ", "black", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr("A:" +A.ToString() + " ", "red", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr("C:" +C.ToString() + " ", "black", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            al.Sort();

            newRow = _DT.NewRow();
            newRow["round"] = arrRound[i].ToString();
            newRow["a0"] = roundSum;
            newRow["a1"] = A; 
            newRow["a2"] = C;
            for (int j = 0; j < al.Count; j++)
            {
                newRow["a12"] += int.Parse(al[j].ToString()).ToString("00") + " ";
            }
            newRow["FLAG"] = Define._UpSumMyGameFlag;//000000;
            _DT.Rows.Add(newRow);


            if (i == 1)
            {
                roundSum = 0;
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "red",_Print);
                string strA = "";
                string strB = "";
                string strC = "";
                for (int j = 0; j < 33; j++)
                {
                    int now = 0;
                    for (int x = 0; x < sumCount; x++)
                    {
                        now += redBall[j, i + x];
                    }

                    if (now >= 9)
                        strA += (j + 1).ToString("00")+ "|";
                    else if (now >= 3)
                        strB += (j + 1).ToString("00")+ "|";
                    else
                        strC += (j + 1).ToString("00")+ "|";
                    MyGoal.InnerHtml += NewNumber.DisplayStr(now.ToString("00") + " ", "black",_Print);
                }
                MyGoal.InnerHtml += NewNumber.DisplayStr(roundSum.ToString("00") + " ", "blue",_Print);
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "red", _Print);
                for (int j = 0; j < 33; j++)
                {                    
                    MyGoal.InnerHtml += NewNumber.DisplayStr((j+1).ToString("00") + " ", "black", _Print);
                }
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                MyGoal.InnerHtml += NewNumber.DisplayStr("strA:" + strA, "red", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                MyGoal.InnerHtml += NewNumber.DisplayStr("strB:" + strB, "blue", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                MyGoal.InnerHtml += NewNumber.DisplayStr("strC:" + strC, "black", _Print);
            }
        }
    }
    #endregion

    #region Score

    private void Score01(int[,] redBall, ArrayList arrRound)
    {
        string testInput = "1000010000001001001011001001000";
        int[] test = new int[31];

        for (int i = 0; i < test.Length; i++)
        {
            test[i] = int.Parse(testInput.Substring(i, 1));
        }
        int countNew = 6;
        int count = 0;
        int oneCount = 0;
        int zeroCount = 0;
        float avg = (float)8 / (float)22;
        float score = 100;
        int ok = 0;
        ArrayList al = new ArrayList();
        
        //for (int i = arrRound.Count - 1; i > 0; i--)
        for (int i = test.Length - 1; i > 0; i--)
        {

            count++;

            if (count == countNew)
            {
                al.Add(oneCount.ToString() + "|" + zeroCount.ToString());
                oneCount = 0;
                zeroCount = 0;
                count = 0;
            }
            else
            {
                //if (redBall[0, i] == 1)
                if (test[i] == 1)
                {
                    oneCount++;
                }
                else
                {
                    zeroCount++;
                }
            }

            for (int j = 0; j < al.Count; j++)
            {
                float one = float.Parse(al[j].ToString().Split('|')[0]);
                float zero = float.Parse(al[j].ToString().Split('|')[1]);
                //if (redBall[0, i] == 1)
                if (test[i] == 1)
                {
                    one++;
                }
                else
                {
                    zero++;
                }
                al[j] = (one.ToString() + "|" + zero.ToString());
                if (UpYes(avg, one, zero))
                    score= score + 1 / (one + zero);
                else
                    score = score - 1 /( (one + zero) * 6);
            }

            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i - 1].ToString() + " || ", "brown",_Print);
            //if (redBall[0, i - 1] == 1)
            if (test[i - 1] == 1)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(score.ToString("000.00000") + " ", "red",_Print);
                if (score >= 100) ok++;
            }
            else
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(score.ToString("000.00000") + " ", "green",_Print);
                if (score < 100) ok++;
            }
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
        MyGoal.InnerHtml += NewNumber.DisplayStr(ok.ToString() + " ", "red",_Print);
    }
    private bool UpYes(float avg, float oneCount, float zeroCount)
    {
        bool up = true;
        if (oneCount / zeroCount > avg)
            up = false;
        return up;
    }
    private void Score33(int[,] redBall, ArrayList arrRound)
    {
        double up = 0;
        //double down = 0;
        double[,] scoreBall = new double[33, MaxMax];
        int[] GoalCount = new int[33];

        for (int i = arrRound.Count - 1; i > 0; i--)
        {
            for (int j = 0; j < 33; j++)
            {
                if (redBall[j, i] == 1)
                    GoalCount[j]++;
            }
        }

        //down = 1;
        up = Convert.ToDouble(GoalCount[0]) / Convert.ToDouble(arrRound.Count - GoalCount[0]);
        //for (int i = 0; i < 33; i++)
        //{
            bool one = false;
            //int countOne = 0;
            int countZero = 0;
            bool flag = true;
            for (int j = arrRound.Count - 1; j > 0; j--)
            {
                double nowUp = 0;
                //double NowDown = 0;
                if (!one)
                {
                    if (redBall[0, j] == 1)
                    {
                        scoreBall[0, j] = 100;
                        flag = false;
                        for (int x = j + 1; x <= arrRound.Count - 1; x++)
                        {
                            scoreBall[0, x] = scoreBall[0, x - 1] - up;
                        }
                        one = true;
                    }
                }
                else
                {
                    if (redBall[0, j] == 1)
                    {
                        //countOne++;
                        countZero = 0;

                        //NowDown = Convert.ToDouble(countOne * countOne) * down / 25;
                        if (scoreBall[0, j + 1] <= 100)
                        {
                            scoreBall[0, j] = 100;
                            flag = false;
                        }
                        else
                        {
                            scoreBall[0, j] = 101;
                            flag = true;
                        }
                    }
                    else
                    {
                        countZero++;
                        //countOne = 0;
                        if (scoreBall[0, j + 1] >= 102)
                        {
                            flag = false;
                            //countZero = 1;
                        }
                        else if (scoreBall[0, j + 1] <= 99)
                        {
                            flag = true;
                            //countZero = 1;
                        }
                            nowUp = Convert.ToDouble(countZero * countZero) * up / 25;
                        if (flag)
                        {
                            scoreBall[0, j] = scoreBall[0, j + 1] + nowUp;
                        }
                        else
                        {
                            scoreBall[0, j] = scoreBall[0, j + 1] - nowUp;
                        }
                        
                    }

                }
            }
        //}


        DisplayScore33(scoreBall, redBall, arrRound);
    }
    private void DisplayScore33(double[,] scoreBall, int[,] redBall, ArrayList arrRound)
    {
        int one99 = 0;
        int one100 = 0;
        int zero99 = 0;
        int zero100 = 0;
        int[] one = new int[150];
        int[] zero = new int[150];
        for (int i = arrRound.Count - 1; i > 0; i--)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "brown",_Print);
            //for (int j = 0; j < 33; j++)
            //{
                if (redBall[0, i] == 1)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(scoreBall[0, i].ToString("000.00000") + " ", "red",_Print);
                    if (scoreBall[0, i] >= 100)
                        one100++;
                    else
                        one99++;
                    //one[(int)scoreBall[0, i]]++;
                }
                else
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(scoreBall[0, i].ToString("000.00000") + " ", "green",_Print);
                    if (scoreBall[0, i] >= 100)
                        zero100++;
                    else
                        zero99++;
                    //zero[(int)scoreBall[0, i]]++;
                }
            //}
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
    }
    #endregion

    #region SelectSomeRed
    /// <summary>
    /// 创建一张二维数据表
    /// </summary>
    /// <returns>Datatable类型的数据表</returns>
    DataTable CreatData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Language", System.Type.GetType("System.String"));
        dt.Columns.Add("Count", System.Type.GetType("System.String"));

        string[] n = new string[] { "C#", "Java", "Object-C" };
        string[] c = new string[] { "30", "50", "35" };

        for (int i = 0; i < 3; i++)
        {
            DataRow dr = dt.NewRow();
            dr["Language"] = n[i];
            dr["Count"] = c[i];
            dt.Rows.Add(dr);
        }
        return dt;
    }

    private void RedCountSelectHot(ArrayList arrRound, int[,] miniRedBall)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Language", System.Type.GetType("System.String"));
        dt.Columns.Add("Count", System.Type.GetType("System.String"));
        dt.Columns.Add("CountNew", System.Type.GetType("System.String"));

        #region 折线图
        Chart1.DataSource = dt;//绑定数据
        Chart1.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;//设置图表类型
        Chart1.Series[0].XValueMember = "Language";//X轴数据成员列
        Chart1.Series[0].YValueMembers = "Count";//Y轴数据成员列
        Series Series2 = new Series();
        Chart1.Series.Add(Series2);
        Chart1.Series["Series2"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;//设置图表类型
        Chart1.Series[1].XValueMember = "Language";//X轴数据成员列
        Chart1.Series[1].YValueMembers = "CountNew";//Y轴数据成员列
        Chart1.ChartAreas["ChartArea1"].AxisX.Title = "语言";//X轴标题
        Chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
        Chart1.ChartAreas["ChartArea1"].AxisY.Title = "统计";//X轴标题
        Chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;//X轴数据的间距
        Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
        Chart1.Series[0].IsValueShownAsLabel = true;//显示坐标值
        Chart1.Series[1].IsValueShownAsLabel = true;//显示坐标值
        #endregion

        string color = "";
        int[] count = new int[33];//50累加
        int[] lastCount = new int[33];
        int[] lastLastCount = new int[33];
        int[] countAll = new int[33];//所有累加
        int[] all = new int[33];//所有分类统计
        int[] roundAll = new int[3];//按照all统计对每一轮分类统计
        int[] roundEvery = new int[30];
        ArrayList al = new ArrayList();
        MyGoal.InnerHtml += NewNumber.DisplayStr("1111111||", "blue",_Print);
        for (int i = 0; i < 33; i++)
        {
            color = "blue";
            MyGoal.InnerHtml += NewNumber.DisplayStr((i + 1).ToString("000") + "  ", color,_Print);
        }
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        for (int i = arrRound.Count - 1; i >=1; i--)
        {
            DataRow newRow;
            newRow = _DT.NewRow();
            newRow["FLAG"] = Define._RedCountSelectHotFlag;//77777733;
            newRow["Round"] = arrRound[i].ToString();

            for (int j = 0; j < 6; j++)
            {
                count[miniRedBall[j, i] - 1]++;
                newRow["A" + j.ToString()] = miniRedBall[j, i];
                if (al.Count > 0)
                {
                    newRow["A1" + j.ToString()] = lastLastCount[miniRedBall[j, i] - 1];
                    newRow["A2" + j.ToString()] = lastCount[miniRedBall[j, i] - 1];
                }
            }
            newRow["A9"] = al.Count;
            _DT.Rows.Add(newRow);

            string str = arrRound[i].ToString().Substring(arrRound[i].ToString().Length - 3, 3);
            string year = arrRound[i].ToString().Substring(arrRound[i].ToString().Length - 5, 2);
            if ((year != "03" && year != "04" && (str == "001" || str == "051" || str == "101")) || (year == "03" && (str == "001" || str == "041")) || (year == "04" && (str == "001" || str == "041" || str == "081")))
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "blue",_Print);
                for (int j = 0; j < 33; j++)
                {
                    if (count[j] < 8)
                    {
                        color = "black";
                        roundAll[0]++;
                    }
                    else if (count[j] < 11)
                    {
                        color = "green";
                        roundAll[1]++;
                    }
                    else
                    {
                        color = "red";
                        roundAll[2]++;
                    }

                    MyGoal.InnerHtml += NewNumber.DisplayStr(count[j].ToString("000") + "  ", color,_Print);
                }

                for (int j = 0; j < roundAll.Length; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr("--" + roundAll[j].ToString("00") + "--", "blue",_Print);
                }

                for (int j = 0; j < count.Length; j++)
                    roundEvery[count[j]]++;

                for (int j = 0; j < roundEvery.Length; j++)
                {
                    if (roundEvery[j] != 0)
                    {
                        if (j < 8)
                        {
                            color = "black";
                        }
                        else if (j < 11)
                        {
                            color = "green";
                        }
                        else
                        {
                            color = "red";
                        }
                        MyGoal.InnerHtml += NewNumber.DisplayStr(" " + j.ToString("00") + ":" + roundEvery[j].ToString("00") + " ", color,_Print);
                    }
                }
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                for (int j = 0; j < 33; j++)
                {
                    countAll[j] += count[j];
                    all[count[j]]++;
                }

                DataRow dr = dt.NewRow();
                dr["Language"] = arrRound[i].ToString();
                dr["Count"] = count[0].ToString("00");
                dr["CountNew"] = count[1].ToString("00");
                dt.Rows.Add(dr);



                al.Add(count);
                lastLastCount = lastCount;
                lastCount = count;
                count = new int[33];
                roundAll = new int[roundAll.Length];
                roundEvery = new int[roundEvery.Length];



            }

        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("1111111||", "blue", _Print);
        for (int i = 0; i < 33; i++)
        {
            color = "blue";
            MyGoal.InnerHtml += NewNumber.DisplayStr((i + 1).ToString("000") + "  ", color, _Print);
        }
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("1111111||", "blue",_Print);
        for (int i = 0; i < 33; i++)
        {
            color = "red";

            MyGoal.InnerHtml += NewNumber.DisplayStr(countAll[i].ToString("000") + "  ", color,_Print);


        }
    }

    private void SelectSomeRed(ArrayList arrRound, int[,] miniRedBall, int[,] redBall)
    {
        //横向方差 SumSixBall 65----135  1=34_25 2=2_31 3=12  15-16=12_03 16-17=10 
        //StdevLeftRight(arrRound, miniRedBall);
        //分类处理
        SubRed(arrRound, miniRedBall);
        //red累计
        //RedCountSelectHot(arrRound, miniRedBall);
        //遗传算法
        //SelectCorssChange(arrRound, miniRedBall);
        //3-11二维组合 <5
        //SelectTwoDimension(arrRound, miniRedBall, redBall);

        //StdevLikeNow(arrRound, miniRedBall, redBall);
        //StdevLikeUpDown(arrRound, miniRedBall);
    }

    private void StdevLikeUpDown(ArrayList arrRound, int[,] miniRedBall)
    {
        NormalDistribution nn = new NormalDistribution();

        //int goal = 1;
        int round = 5;//小于5
        ArrayList al = new ArrayList();

        for (int i = arrRound.Count - 2 - round; i >= 1; i--)
        {
            DataRow newRow;
            newRow = _DT.NewRow();
            newRow["FLAG"] = Define._StdevLikeUpDownFlag;//77777722;
            newRow["Round"] = arrRound[i].ToString();
            double aaaCount = 0;
            double dddCount = 0;
            for (int x = 1; x <= round; x++)
            {
                List<double> dd = new List<double>();
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i + x].ToString() + "||" + arrRound[i].ToString() + "==", "blue", _Print);
                for (int j = 0; j < 6; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedBall[j, i + x].ToString("00") + "_" + miniRedBall[j, i].ToString("00") + "|", "green", _Print);
                    int aa = Math.Abs(miniRedBall[j, i] - miniRedBall[j, i + x]);
                    dd.Add(Convert.ToDouble(aa));
                }
                for (int j = 0; j < 6; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(dd[j].ToString("00") + "  ", "brown", _Print);
                    //int aa = Math.Abs(miniRedBall[j, 1] - miniRedBall[j, i]);
                    //dd.Add(Convert.ToDouble(aa));
                }
                double ddd = nn.stdev(dd);
                double aaa = nn.average(dd);
                MyGoal.InnerHtml += NewNumber.DisplayStr(ddd.ToString("00") + "  " + ddd.ToString() + "  ", "red", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayStr(aaa.ToString("00") + "  " + aaa.ToString() + "  ", "blue", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                newRow["A" + (2 * x).ToString()] = ddd;
                newRow["A" + (2 * x + 1).ToString()] = aaa;
                newRow["A" + (2 * x + 10).ToString()] = ddd.ToString();
                newRow["A" + (2 * x + 11).ToString()] = aaa.ToString();
                aaaCount += aaa;
                dddCount += ddd;

            }
            MyGoal.InnerHtml += NewNumber.DisplayStr("--------------------------------------------------------------------------------------------------------------------", "black", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);


            if (aaaCount <= 7)
                al.Add(arrRound[i].ToString());

            newRow["A0"] = dddCount;
            newRow["A1"] = aaaCount;
            newRow["A29"] = dddCount.ToString();
            newRow["A30"] = aaaCount.ToString();
            _DT.Rows.Add(newRow);
        }
    }

    private void StdevLikeNow(ArrayList arrRound, int[,] miniRedBall, int[,] redBall)
    {
        NormalDistribution nn = new NormalDistribution();

        int goal = 1;
        int round = 3;//小于5
        ArrayList al = new ArrayList();

        for (int i = arrRound.Count - 2 - round; i > goal; i--)
        {
            DataRow newRow;
            newRow = _DT.NewRow();
            newRow["FLAG"] = Define._StdevLikeNowFlag;//77777711;
            newRow["Round"] = arrRound[i].ToString();
            double aaaCount = 0;
            double dddCount = 0;
            for (int x = 0; x < round; x++)
            {
                List<double> dd = new List<double>();
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i + x].ToString() + "||", "blue", _Print);
                for (int j = 0; j < 6; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedBall[j, i + x].ToString("00") + "_" + miniRedBall[j, goal + x].ToString("00")+"|", "green", _Print);
                    int aa = Math.Abs(miniRedBall[j, goal + x] - miniRedBall[j, i + x]);
                    dd.Add(Convert.ToDouble(aa));
                }
                for (int j = 0; j < 6; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(dd[j].ToString("00") + "  ", "brown", _Print);
                    //int aa = Math.Abs(miniRedBall[j, 1] - miniRedBall[j, i]);
                    //dd.Add(Convert.ToDouble(aa));
                }
                double ddd = nn.stdev(dd);
                double aaa = nn.average(dd);
                MyGoal.InnerHtml += NewNumber.DisplayStr(ddd.ToString("00") + "  " + ddd.ToString() + "  ", "red", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayStr(aaa.ToString("00") + "  " + aaa.ToString() + "  ", "blue", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                newRow["A" + (2 * x).ToString()] = ddd;
                newRow["A" + (2 * x + 1).ToString()] = aaa;
                newRow["A" + (2 * x + 12).ToString()] = ddd.ToString();
                newRow["A" + (2 * x + 13).ToString()] = aaa.ToString();
                aaaCount += aaa;
                dddCount += ddd;

            }
            MyGoal.InnerHtml += NewNumber.DisplayStr("--------------------------------------------------------------------------------------------------------------------", "black", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            if (goal > 1)
            {
                List<double> dd = new List<double>();
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i - 1].ToString() + "||", "blue", _Print);
                for (int j = 0; j < 6; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedBall[j, i - 1].ToString("00") + "_" + miniRedBall[j, goal - 1].ToString("00") + "|", "green", _Print);
                    int aa = Math.Abs(miniRedBall[j, goal -1] - miniRedBall[j, i -1]);
                    dd.Add(Convert.ToDouble(aa));
                }
                for (int j = 0; j < 6; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(dd[j].ToString("00") + "  ", "brown", _Print);
                    //int aa = Math.Abs(miniRedBall[j, 1] - miniRedBall[j, i]);
                    //dd.Add(Convert.ToDouble(aa));
                }
                double ddd = nn.stdev(dd);
                double aaa = nn.average(dd);
                MyGoal.InnerHtml += NewNumber.DisplayStr(ddd.ToString("00") + "  " + ddd.ToString() + "  ", "red", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayStr(aaa.ToString("00") + "  " + aaa.ToString() + "  ", "blue", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
   
                newRow["A27"] = ddd.ToString();
                newRow["A28"] = aaa.ToString();
            }
            MyGoal.InnerHtml += NewNumber.DisplayStr("********************************************************************************************************************", "black", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
            if (aaaCount <= 7)
                al.Add(arrRound[i].ToString());

            newRow["A10"] = dddCount;
            newRow["A11"] = aaaCount;
            newRow["A29"] = dddCount.ToString();
            newRow["A30"] = aaaCount.ToString();
            //newRow["A16"] = strChangeB;
            //newRow["A24"] = str;
            _DT.Rows.Add(newRow);
        }

        for (int i = arrRound.Count - 2; i >= 1; i--)
        {
            string color = "green";
            if (al.Contains(arrRound[i].ToString()))
            {
                color = "red";

                for (int x = 9; x >= 0; x--)
                {
                    if (i + x < arrRound.Count - 1)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i + x].ToString() + "||", "blue", _Print);
                        for (int j = 0; j < 33; j++)
                        {
                            if (redBall[j, i + x] == 1)
                            {
                                if(redBall[j, goal + x] ==1)
                                    MyGoal.InnerHtml += NewNumber.DisplayLineThroughStr((j + 1).ToString("00") + "  ", color, _Print);
                                else
                                    MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", color, _Print);
                            }
                            else
                            {
                                if (redBall[j, goal + x] == 1)
                                    MyGoal.InnerHtml += NewNumber.DisplayLineThroughStr("00  ", "black", _Print);
                                else
                                    MyGoal.InnerHtml += NewNumber.DisplayStr("00  ", "black", _Print);
                            }
                        }
                        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                    }
                }
                color = "brown";
                if (i -1 >=1)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i  -1].ToString() + "||", "red", _Print);
                    for (int j = 0; j < 33; j++)
                    {
                        if (redBall[j, i - 1] == 1)
                        {
                            if (redBall[j, goal - 1] == 1 && goal > 1)
                                MyGoal.InnerHtml += NewNumber.DisplayLineThroughStr((j + 1).ToString("00") + "  ", color, _Print);
                            else
                                MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", color, _Print);
                        }
                        else
                        {
                            if (redBall[j, goal - 1] == 1 && goal > 1)
                                MyGoal.InnerHtml += NewNumber.DisplayLineThroughStr("00  ", "black", _Print);
                            else
                                MyGoal.InnerHtml += NewNumber.DisplayStr("00  ", "black", _Print);
                        }
                    }
                    MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
                }
                MyGoal.InnerHtml += NewNumber.DisplayStr("--------------------------------------------------------------------------------------------------------------------", "black", _Print);
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
            }
           
        }

    }

    private void SelectTwoDimension(ArrayList arrRound, int[,] miniRedBall, int[,] redBall)
    {
        int height = 3;
        int weight = 11;
        
        for (int i = arrRound.Count - height - height; i >= 1; i--)
        {
            DataRow newRow;
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "blue",_Print);
            int[] round = new int[weight];
            int[] last = new int[weight];

            for (int j = 0; j < 33; j++)
            {
                if((j/3) % 2 == 1)
                    MyGoal.InnerHtml += NewNumber.DisplayStr(redBall[j, i].ToString("00") + "  ", "green",_Print);
                else
                    MyGoal.InnerHtml += NewNumber.DisplayStr(redBall[j, i].ToString("00") + "  ", "black",_Print);
                round[j / 3] += redBall[j, i] + redBall[j, i + 1] + redBall[j, i + 2];
                last[j / 3] += redBall[j, i + height] + redBall[j, i + height + 1] + redBall[j, i + height + 2];
            }
            string str = string.Empty;
            string strChangeA = string.Empty;
            string strChangeB = string.Empty;
            int change = 0;
            for (int j = 0; j < round.Length; j++)
            {
                if (i != arrRound.Count - height - height)
                {
                    str += round[j].ToString();
                    if (round[j] != last[j])
                    {
                        change++;
                        if (round[j] > last[j])
                            strChangeA += (round[j] - last[j]).ToString();
                        else
                            strChangeB += (last[j] - round[j]).ToString();
                    }
                }
                MyGoal.InnerHtml += NewNumber.DisplayStr(round[j].ToString("00") + "_" + last[j].ToString("00") + "  ", "red",_Print);

                //last[j] = round[j];
            }
            MyGoal.InnerHtml += NewNumber.DisplayStr("|" + change.ToString("00") + "  ", "brown",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            if (i == 1)
            {
                last = new int[weight];
                round=  new int[weight];
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "red",_Print);
                for (int j = 0; j < 33; j++)
                {
                    if ((j / 3) % 2 == 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr(redBall[j, i].ToString("00") + "  ", "green",_Print);
                    else
                        MyGoal.InnerHtml += NewNumber.DisplayStr(redBall[j, i].ToString("00") + "  ", "black",_Print);
                    round[j / 3] += redBall[j, i] + redBall[j, i + 1];
                    last[j / 3] += redBall[j, i + height - 1] + redBall[j, i + height] + redBall[j, i + height + 1];
                }

                for (int j = 0; j < last.Length; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(last[j].ToString("00") + "  ", "brown", _Print);
                }

                for (int j = 0; j < round.Length; j++)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(round[j].ToString("00") + "  ", "blue",_Print);
                }

                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
            }

            newRow = _DT.NewRow();
            newRow["A1"] = change;
            newRow["A14"] = arrRound[i].ToString();
            newRow["A15"] = strChangeA;
            newRow["A16"] = strChangeB;
            newRow["A24"] = str;
            newRow["FLAG"] = Define._SelectTwoDimensionFlag;//777777;
            _DT.Rows.Add(newRow);
        }

        //throw new NotImplementedException();
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

    private void SubRed(ArrayList arrRound, int[,] miniRedBall)
    {
        DataRow newRow;
        int[] sub = new int[6];
        //int[] count = new int[3];
        for (int i = 1; i < arrRound.Count; i++)
        {
            ArrayList al = new ArrayList();
            string strSimple = string.Empty;
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "blue",_Print);
            for (int j = 0; j < miniRedBall.GetLength(0); j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedBall[j, i].ToString("00") + "  ", "green",_Print);
                if (j == 0)
                    sub[0] = miniRedBall[j, i] - 1;
                else
                    sub[j] = miniRedBall[j, i] - miniRedBall[j - 1, i] - 1;

                if (i + 1 < arrRound.Count)
                {
                    string str = SimpleRedSix210(miniRedBall[j, i], miniRedBall[j, i+ 1]);
                    strSimple += str;
                    al.Add(str);
                    //count[int.Parse(str)]++;
                }

            }
            sub[0] += 33 - miniRedBall[5,i];

            string subsub = string.Empty;
            string subStr = MyTest.GetSubStr(sub);
            ArrayList alSub = new ArrayList();
            for (int j = 0; j < sub.Length; j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(sub[j].ToString("00") + "  ", "red",_Print);
                subsub += sub[j].ToString("00")+"|";
                alSub.Add(sub[j]);
            }

            newRow = _DT.NewRow();

            newRow["A12"] = subStr;
            newRow["A13"] = subsub;
            newRow["A14"] = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
            
            newRow["round"] = arrRound[i].ToString();
            newRow["A24"] = strSimple;

            al.Sort();
            alSub.Sort();
            strSimple = string.Empty;
            string strSub = string.Empty;
            for (int j = 0; j < al.Count; j++)
            {
                strSimple += al[j].ToString();
                strSub += alSub[j].ToString() + "|";
            }
            newRow["A15"] = strSub;
            newRow["A25"] = strSimple;
            newRow["FLAG"] = Define._SubRedFlag;//77777744;
            _DT.Rows.Add(newRow);

            MyGoal.InnerHtml += NewNumber.DisplayStr(subStr + "  ", "black",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(newRow["A24"] + "  ", "black",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(newRow["A25"] + "  ", "black",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
    }
    

    private void StdevLeftRight(ArrayList arrRound, int[,] miniRedBall)
    {
        DataRow newRow;

        NormalDistribution nn = new NormalDistribution();
        List<double> dd;

        for (int i = 1; i < arrRound.Count - 2; i++)
        {
            int count = 0;
            dd = new List<double>();
            int[] ballTwo = new int[33];
            int[] ballThree = new int[33];
            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + "||", "blue",_Print);
            for (int j = 0; j < miniRedBall.GetLength(0); j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedBall[j, i].ToString("00") + "  ", "green",_Print);
                if (j == 0)
                    dd.Add(miniRedBall[j, i]);
                else if (miniRedBall[j, i] != miniRedBall[j - 1, i])
                {
                    dd.Add(miniRedBall[j, i] - miniRedBall[j - 1, i]);
                    if (j == miniRedBall.GetLength(0) - 1)
                        dd.Add(33 - miniRedBall[j, i]);
                }
                count += miniRedBall[j, i];

                ballTwo[miniRedBall[j, i] - 1]++;
                ballTwo[miniRedBall[j, i + 1] - 1]++;
                ballThree[miniRedBall[j, i] - 1]++;
                ballThree[miniRedBall[j, i + 1] - 1]++;
                ballThree[miniRedBall[j, i + 2] - 1]++;
            }
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
            foreach (double item in dd)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(item.ToString("00") + "  ", "red",_Print);
                str1 += item.ToString("00");
            }
            double ddd1 = nn.stdev(dd);
            MyGoal.InnerHtml += NewNumber.DisplayStr(ddd1.ToString() + "___Count:=  " + count.ToString(), "black",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            dd = MyTest.CreateStdev33DD(ballTwo);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
            foreach (double item in dd)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(item.ToString("00") + "  ", "red",_Print); 
                str2 += item.ToString("00");
            }
            double ddd2 = nn.stdev(dd);
            MyGoal.InnerHtml += NewNumber.DisplayStr(ddd2.ToString() + "  ", "black",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            dd = MyTest.CreateStdev33DD(ballThree);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
            foreach (double item in dd)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(item.ToString("00") + "  ", "red",_Print);
                str3 += item.ToString("00");
            }
            double ddd3 = nn.stdev(dd);
            MyGoal.InnerHtml += NewNumber.DisplayStr(ddd3.ToString() + "  ", "black",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            newRow = _DT.NewRow();
            newRow["A1"] = count;
            newRow["A12"] = str1;
            newRow["A13"] = str2;
            newRow["A14"] = str3;
            newRow["A15"] = ddd1;
            newRow["A16"] = ddd2;
            newRow["A17"] = ddd3;
            newRow["FLAG"] = Define._StdevLeftRightFlag;//77777700;
            _DT.Rows.Add(newRow);
        }


    }

    private void SelectCorssChange(ArrayList arrRound, int[,] miniRedBall)
    {
        int unitCount = 4;
        int selectCount = 2;
        int oneCount = 22;
        int[,] selectUnit = new int[unitCount, 33];
        //int[,] selectNextUnit = new int[unitCount, 33];
        int[] selectNext = new int[selectCount];
        int[] good = new int[unitCount];

        Random ro = new Random();
        //Random aa = new Random((int)(DateTime.Now.Ticks / 10000));

        //初始群体的产生
        for (int i = 0; i < unitCount; i++)
        {
            int count = 0;
            while (count <= oneCount)
            {
                int iUp = 33;
                int iResult = ro.Next(iUp);

                if (selectUnit[i, iResult] == 0)
                {
                    selectUnit[i, iResult] = 1;
                    count++;
                }
            }
        }

        for (int i = 0; i < 1000; i++)
        {
            //适应度计算
            good = GoodUnit(selectUnit, miniRedBall, arrRound.Count);
            //选择运算（轮盘赌）
            selectNext = SelectUnit(selectUnit, good, selectNext);
            //交叉 
            selectUnit = CrossUnit(selectUnit, selectNext, oneCount);
            //变异 
            selectUnit = ChangeUnit(selectUnit, selectNext, oneCount);
        }
        int[] selectUnitCount = new int[selectUnit.GetLength(0)];
        selectUnitCount = GetSelectUnitCount(selectUnit);
    }

    private int[] GetSelectUnitCount(int[,] selectUnit)
    {
        int[] selectUnitCount = new int[selectUnit.GetLength(0)];

        for (int i = 0; i < selectUnitCount.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < selectUnit.GetLength(1); j++)
            {
                if (selectUnit[i, j] == 1)
                    count++;
            }
            selectUnitCount[i] = count;
        }
        return selectUnitCount;
    }

    private void PrintSelectUnit(int[,] selectUnit)
    {
        for (int i = 0; i < selectUnit.GetLength(0); i++)
        {
            for (int j = 0; j < selectUnit.GetLength(1); j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(selectUnit[i, j].ToString(), "blue",_Print);
            }
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
    }

    private int NoZero(int Max)
    {
        Random rand = new Random();
        int randNew = rand.Next(1, Max);

        while (randNew == 0)
        {
            randNew = rand.Next(1, Max);
        }

        return randNew;
    }

    private int[,] ChangeUnit(int[,] selectUnit, int[] selectNext, int oneCount)
    {

        int randChangeOne = NoZero(oneCount);
        int randChangeZero = NoZero(33 - oneCount);

        for (int i = 0; i < selectNext.Length; i++)
        {
            int oneSum = 0;
            int ZeroSum = 0;
            for (int j = 0; j < selectUnit.GetLength(1); j++)
            {
                if (selectUnit[selectNext[i], j] == 1)
                    oneSum++;
                else if (selectUnit[selectNext[i], j] == 0)
                    ZeroSum++;
                if (oneSum == randChangeOne)
                {
                    selectUnit[selectNext[i], j] = 0; oneSum++;
                }
                if (ZeroSum == randChangeZero)
                {
                    selectUnit[selectNext[i], j] = 1; ZeroSum++;
                }
            }
        }
        //int[] selectUnitCount = new int[selectUnit.GetLength(0)];
        //selectUnitCount = GetSelectUnitCount(selectUnit);
        //MyGoal.InnerHtml += DisplayStr("selectUnitCount:" + selectUnitCount[0].ToString() + " " + selectUnitCount[1].ToString() + " " + selectUnitCount[2].ToString() + " " + selectUnitCount[3].ToString(), "green");
        //MyGoal.InnerHtml += DisplayBR();
        //MyGoal.InnerHtml += DisplayStr("randChangeOne:" + randChangeOne.ToString(), "red");
        //MyGoal.InnerHtml += DisplayBR();
        //MyGoal.InnerHtml += DisplayStr("randChangeZero:" + randChangeZero.ToString(), "red");
        //MyGoal.InnerHtml += DisplayBR();
        //PrintSelectUnit(selectUnit);
        return selectUnit;
    }

    private int[,] CrossUnit(int[,] selectUnit, int[] selectNext, int oneCount)
    {
        int randCross = NoZero(oneCount);
        int[,] selectNewUnit = new int[selectUnit.GetLength(0), 33];
        for (int j = 0; j < selectNext.Length / 2; j++)
        {
            int[] one = new int[selectUnit.GetLength(1)];
            int[] two = new int[selectUnit.GetLength(1)];

            int oneSum = 0;
            int twoSum = 0;
            for (int i = 0; i < selectUnit.GetLength(1); i++)
            {

                if (selectUnit[selectNext[j * 2 + 0], i] == 1)
                    oneSum++;
                if (selectUnit[selectNext[j * 2 + 1], i] == 1)
                    twoSum++;
                if (oneSum > randCross)
                {
                    one[i] = selectUnit[selectNext[j * 2 + 0], i];
                }
                else if (selectUnit[selectNext[j * 2 + 0], i] == 1)
                    two[i] = selectUnit[selectNext[j * 2 + 0], i];
                if (twoSum > randCross)
                {
                    two[i] = selectUnit[selectNext[j * 2 + 1], i];
                }
                else if (selectUnit[selectNext[j * 2 + 1], i] == 1)
                    one[i] = selectUnit[selectNext[j * 2 + 1], i];

            }
            for (int i = 0; i < selectUnit.GetLength(1); i++)
            {
                selectNewUnit[j * 2 + 1, i] = one[i];

                selectNewUnit[j * 2 + 0, i] = two[i];
            }
        }
        int[] selectUnitCount = new int[selectUnit.GetLength(0)];
        selectUnitCount = GetSelectUnitCount(selectNewUnit);

        for (int i = 0; i < selectUnitCount.Length; i++)
        {
            if (selectUnitCount[i] < oneCount + 1)
            {
                int add = oneCount + 1 - selectUnitCount[i];
                while (add > 0)
                {
                    randCross = NoZero(32);
                    if (selectNewUnit[i, randCross] == 0)
                    {
                        selectNewUnit[i, randCross] = 1;
                        add--;
                    }
                }
            }
        }
        //selectUnitCount = GetSelectUnitCount(selectUnit);
        //MyGoal.InnerHtml += DisplayStr("selectUnitCount:" + selectUnitCount[0].ToString() + " " + selectUnitCount[1].ToString() + " " + selectUnitCount[2].ToString() + " " + selectUnitCount[3].ToString(), "green");
        //MyGoal.InnerHtml += DisplayBR();
        //MyGoal.InnerHtml += DisplayStr("CrossRand:" + randCross.ToString(), "red");
        //MyGoal.InnerHtml += DisplayBR();
        //PrintSelectUnit(selectUnit);
        return selectNewUnit;
    }

    private int[] SelectUnit(int[,] selectUnit, int[] good, int[] selectNext)
    {
        double[] goodNew = new double[good.Length]; 
        //double[] goodSelect = new double[good.Length - 1];
        
        Random rand = new Random();
        for (int j = 0; j < selectNext.Length; j++)
        {
            double randDegree = rand.Next(1, 100) * 0.01;
            int all = 0;
            for (int i = 0; i < good.Length; i++)
            {
                all += good[i];
            }
            for (int i = 0; i < good.Length; i++)
            {
                goodNew[i] = (double)good[i] / (double)all;
            }

            double goodSelect = 0;
            for (int i = 0; i < goodNew.Length; i++)
            {
                goodSelect += goodNew[i];
                if (randDegree < goodSelect)
                {
                    //if (j != 0 && selectNext[j - 1] == i)
                    //    j = j-1;
                    //else
                        selectNext[j] = i;
                    break;
                }
            }
        }


        //int[] selectUnitCount = new int[selectUnit.GetLength(0)];
        //selectUnitCount = GetSelectUnitCount(selectUnit);
        //MyGoal.InnerHtml += DisplayStr("selectUnitCount:" + selectUnitCount[0].ToString() + " " + selectUnitCount[1].ToString() + " " + selectUnitCount[2].ToString() + " " + selectUnitCount[3].ToString(), "green");
        //MyGoal.InnerHtml += DisplayBR();
        //MyGoal.InnerHtml += DisplayStr("selectNext:" + selectNext[0].ToString() + " " + selectNext[1].ToString(), "red");
        //MyGoal.InnerHtml += DisplayBR();
        //PrintSelectUnit(selectUnit);
        return selectNext;
    }

    private int[] GoodUnit(int[,] selectUnit, int[,] miniRedBall, int round)
    {
        int[] good = new int[selectUnit.GetLength(0)];

        for (int i = 0; i < good.Length; i++)
        {            
            for (int j = 1; j < round; j++)
            {
                int count = 0;
                for (int x = 0; x < 6; x++)
                {
                    if (selectUnit[i, miniRedBall[x, j] - 1] == 1)
                        count++;
                }
                if (count == 6)
                    good[i] = good[i] + 1;
                else if (count == 5)
                    good[i] = good[i] + 1;

            }
        }

            return good;
    }


    #endregion

    #region NoNormal
    private void DoBeiJing(ArrayList arrRound, int[,] miniRedBall, int[,] redBall)
    {
        string strTwo = string.Empty;
        int[] sumTwo = new int[7];
        string strPrime = string.Empty;
        int[] sumPrime = new int[7];
        string strNearRepeat = string.Empty;
        int[] sumNearRepeat = new int[7];
        string strNearRepeat_2 = string.Empty;//一个号有两个NearRepeat
        int[] sumNearRepeat_2 = new int[19];
        string strNearRepeat_22 = string.Empty;//和两轮比-----_NearRepeat_NoSelect
        int[] sumNearRepeat_22 = new int[7];
        string strRepeat_22 = string.Empty;//和两轮比-----_NearRepeat_NoSelect
        int[] sumRepeat_22 = new int[7];
        string strNearRepeatChange = string.Empty;
        int[] sumNearRepeatChange = new int[70];
        string[] strMiniRed = new string[6];
        string strSumSix = string.Empty;
        string strOneSixAbs = string.Empty;
        for (int i = arrRound.Count - 1; i > 0; i--)
        //for (int i = 20; i > 0; i--)
        {
            int prime = MyTest.ISPrime(miniRedBall[0, i]) + MyTest.ISPrime(miniRedBall[1, i]) + MyTest.ISPrime(miniRedBall[2, i]) + MyTest.ISPrime(miniRedBall[3, i]) + MyTest.ISPrime(miniRedBall[4, i]) + MyTest.ISPrime(miniRedBall[5, i]);
            strPrime += prime.ToString();
            sumPrime[prime]++;
            if (i != arrRound.Count - 1)
            {
                int nearRepeat = MyTest.ISNearRepeat(_RedBall, miniRedBall[0, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[1, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[2, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[3, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[4, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[5, i], i + 1);
                strNearRepeat += nearRepeat.ToString();
                sumNearRepeat[nearRepeat]++;

                if (i != arrRound.Count - 2)
                {
                    int nearRepeat_22 = 0;// = MyTest.ISNearRepeat(_RedBall, miniRedBall[0, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[1, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[2, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[3, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[4, i], i + 1) + MyTest.ISNearRepeat(_RedBall, miniRedBall[5, i], i + 1);
                    int repeat_22 = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (MyTest.ISNearRepeat(_RedBall, miniRedBall[j, i], i + 1) == 0)
                            nearRepeat_22 += MyTest.ISNearRepeat(_RedBall, miniRedBall[j, i], i + 2);
                        else
                            nearRepeat_22 += MyTest.ISNearRepeat(_RedBall, miniRedBall[j, i], i + 1);

                        if (MyTest.ISRepeat(_RedBall, miniRedBall[j, i], i + 1) == 0)
                            repeat_22 += MyTest.ISRepeat(_RedBall, miniRedBall[j, i], i + 2);
                        else
                            repeat_22 += MyTest.ISRepeat(_RedBall, miniRedBall[j, i], i + 1);
                    }
                    strNearRepeat_22 += nearRepeat_22.ToString();
                    sumNearRepeat_22[nearRepeat_22]++;
                    strRepeat_22 += repeat_22.ToString();
                    sumRepeat_22[repeat_22]++;
                }

                int nearRepeat_2 = MyTest.ISNearRepeat_2(_RedBall, miniRedBall[0, i], i + 1) + MyTest.ISNearRepeat_2(_RedBall, miniRedBall[1, i], i + 1) + MyTest.ISNearRepeat_2(_RedBall, miniRedBall[2, i], i + 1) + MyTest.ISNearRepeat_2(_RedBall, miniRedBall[3, i], i + 1) + MyTest.ISNearRepeat_2(_RedBall, miniRedBall[4, i], i + 1) + MyTest.ISNearRepeat_2(_RedBall, miniRedBall[5, i], i + 1);
                strNearRepeat_2 += nearRepeat_2.ToString();
                sumNearRepeat_2[nearRepeat_2]++;

                strNearRepeatChange += (nearRepeat_2 - nearRepeat).ToString();
                if (nearRepeat != nearRepeat_2)
                {
                    sumNearRepeatChange[nearRepeat]++;
                    sumNearRepeatChange[nearRepeat * 10 + nearRepeat_2]++;
                }


                int sumSix = 0;
                int oneSixAbs = miniRedBall[5, i] - miniRedBall[0, i];
                for (int j = 0; j < miniRedBall.GetLength(0); j++)
                {
                    sumSix += miniRedBall[j, i];
                }

                strSumSix += (sumSix / 10).ToString("00");
                strOneSixAbs += oneSixAbs.ToString("00");
            }               
            int two = MyTest.ISTwo(miniRedBall[0, i]) + MyTest.ISTwo(miniRedBall[1, i]) + MyTest.ISTwo(miniRedBall[2, i]) + MyTest.ISTwo(miniRedBall[3, i]) + MyTest.ISTwo(miniRedBall[4, i]) + MyTest.ISTwo(miniRedBall[5, i]);
            strTwo += two.ToString();
            sumTwo[two]++;
        }


        string[] strUP = new string[33];
        for (int i = 0; i < 33; i++)
        {
            int j = 0;
            while (j <= arrRound.Count - 1)
            {
                int ii = MyTest.FindUpNumber(j, i, arrRound.Count - 1, redBall);
                j += ii + 1;
                if (ii >= 100)
                    strUP[i] = "99" + strUP[i];
                else
                    strUP[i] = ii.ToString("00") + strUP[i];
            }
        }

        BeiJing bjTwo = new BeiJing();
        bjTwo.RealStr = strTwo;
        bjTwo.SumReal = sumTwo;
        bjTwo.UpChangeA = 4;
        bjTwo.DownChangeA = 2;//012 3 456
        bjTwo.ChangeAStr = BeiJingFunC.GetChangeAStr(bjTwo);
        bjTwo.ChangeBStr = BeiJingFunC.GetChangeBStr(bjTwo);

        BeiJing bjPrime = new BeiJing();
        bjPrime.RealStr = strPrime;
        bjPrime.SumReal = sumPrime;
        bjPrime.UpChangeA = 3;
        bjPrime.DownChangeA = 1;//01 2 3456
        bjPrime.ChangeAStr = BeiJingFunC.GetChangeAStr(bjPrime);
        bjPrime.ChangeBStr = BeiJingFunC.GetChangeBStr(bjPrime);

        BeiJing bjNearRepeat = new BeiJing();
        bjNearRepeat.RealStr = strNearRepeat;
        bjNearRepeat.SumReal = sumNearRepeat;
        bjNearRepeat.UpChangeA = 4;
        bjNearRepeat.DownChangeA = 2;//012 3 456
        bjNearRepeat.ChangeAStr = BeiJingFunC.GetChangeAStr(bjNearRepeat);
        bjNearRepeat.ChangeBStr = BeiJingFunC.GetChangeBStr(bjNearRepeat);


        MyGoal.InnerHtml += NewNumber.DisplayStr("bjTwo     ：" + strTwo, "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("bjPrime   ：" + strPrime, "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("NearRepeat：_" + strNearRepeat, "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("NearRepeat_2：_" + strNearRepeat_2, "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("NearRepeat_22：__" + strNearRepeat_22, "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("strSumSix：" + strSumSix, "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("strOneSixAbs：" + strOneSixAbs, "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);


        int matlab = 10;

        for (int i = 0; i <= strNearRepeat.Length - matlab; i++)
        {
            for (int j = 0; j < matlab; j++)
            {
                if(j == 0)
                    MyGoal.InnerHtml += NewNumber.DisplayStr(strNearRepeat.Substring(i + j, 1), "green", _Print);
                else
                    MyGoal.InnerHtml += NewNumber.DisplayStr(" " + strNearRepeat.Substring(i + j, 1), "green", _Print);
            }
            MyGoal.InnerHtml += NewNumber.DisplayBROne(_Print);
        }

        for (int i = 0; i < 33; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr((i + 1).ToString("00") + "_UP：" + strUP[i], "blue", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }


        DoWithStr(strNearRepeat, strTwo, strPrime, 2);

        DataRow newRow;

        for (int i = 2; i < 20; i++)
        {
            for (int j = 0; j <= bjTwo.ChangeAStr.Length - i; j++)
            {
                newRow = _DT.NewRow();
                //newRow["a9"] = int.Parse(arrRound[j].ToString());
                newRow["a10"] = j;
                newRow["A11"] = i;
                newRow["A12"] = bjTwo.ChangeAStr.Substring(j, i - 1);
                newRow["A13"] = bjTwo.ChangeAStr.Substring(j, i);
                newRow["A14"] = bjTwo.ChangeAStr.Substring(j + i - 1, 1);
                newRow["A15"] = bjTwo.RealStr.Substring(j, i - 1);
                newRow["A16"] = bjTwo.RealStr.Substring(j, i);
                newRow["A17"] = bjTwo.RealStr.Substring(j + i - 1, 1);

                newRow["A18"] = bjPrime.ChangeAStr.Substring(j, i - 1);
                newRow["A19"] = bjPrime.ChangeAStr.Substring(j, i);
                newRow["A20"] = bjPrime.ChangeAStr.Substring(j + i - 1, 1);
                newRow["A21"] = bjPrime.RealStr.Substring(j, i - 1);
                newRow["A22"] = bjPrime.RealStr.Substring(j, i);
                newRow["A23"] = bjPrime.RealStr.Substring(j + i - 1, 1);

                if (j != 0)
                {
                    newRow["A24"] = bjNearRepeat.ChangeAStr.Substring(j - 1, i - 1);
                    newRow["A25"] = bjNearRepeat.ChangeAStr.Substring(j-1, i);
                    newRow["A26"] = bjNearRepeat.ChangeAStr.Substring(j + i - 2, 1);
                    newRow["A27"] = bjNearRepeat.RealStr.Substring(j-1, i - 1);
                    newRow["A28"] = bjNearRepeat.RealStr.Substring(j-1, i);
                    newRow["A29"] = bjNearRepeat.RealStr.Substring(j + i - 2, 1);
                    newRow["A30"] = newRow["A16"].ToString() + newRow["A22"].ToString() + newRow["A28"].ToString();
                }
                newRow["FLAG"] = Define._DoBeiJingFlag;//888888;
                _DT.Rows.Add(newRow);
            }
        }

        
    }

    private void DoWithStr(string str,string strTwo,string strPrime, int cut)
    {
        NormalDistribution nn = new NormalDistribution();
        List<double> dd;

        DataRow newRow;

        int length = str.Length;
        for (int i = 0; i < length - cut; i++)
        {
            string now = str.Substring(length - i - 1, 1);
            string old = str.Substring(length - i - 1 - cut, cut);
            string nowTwo = strTwo.Substring(length - i, 1);
            string oldTwo = strTwo.Substring(length - i - cut, cut);
            string nowPrime = strPrime.Substring(length - i, 1);
            string oldPrime = strPrime.Substring(length - i - cut, cut);

            dd = new List<double>();

            for (int j = 0; j < old.Length; j++)
            {
                dd.Add(Convert.ToDouble(old.Substring(j, 1)));
            }

            double ddd = nn.stdev(dd);
            double avg = nn.average(dd);

            newRow = _DT.NewRow();
            newRow["A0"] = i;
            newRow["A12"] = ddd;
            newRow["A13"] = Convert.ToDouble(now) - avg;
            newRow["A14"] = now;
            newRow["A15"] = old;
            newRow["A16"] = nowTwo;
            newRow["A17"] = oldTwo;
            newRow["A18"] = nowPrime;
            newRow["A19"] = oldPrime;


            newRow["FLAG"] = Define._DoWithStrFlag;//99999911;
            _DT.Rows.Add(newRow);

        }
    }

    private void NoNormal(ArrayList arrRound, int[,] miniRedBall)
    {
        //DoBeiJing(arrRound, miniRedBall);

        DataRow newRow;
        int[] repeat = RepeatBall(miniRedBall, arrRound);
        int[] near = NearBall(miniRedBall, arrRound);
        string strRound = string.Empty;
        int myRound = 0;
        int[] my = new int[6];
        int round = 0;
        int count = 0;
        int lastSixSum = 0;
        int lastNear = 0;
        int lastRepeat = 0;
        int lastMyNumber = 0;
        int lastOne = 0;
        int LastSix = 0;
        for (int i = 0; i < arrRound.Count; i++)
        {
            string strGoal = repeat[i].ToString() + near[i].ToString(); 
            newRow = _DT.NewRow();
            int myNumber = repeat[i] * 3 + near[i] * 2;
            string myStr = "";
            if(myNumber > 7)
                myStr = "大";
            else if (myNumber <= 4)
                myStr = "小";
            else
                myStr = "中";

            if (i == 0)
            {
                lastSixSum = miniRedBall[0,i] +miniRedBall[1,i] +miniRedBall[2,i] +miniRedBall[3,i] +miniRedBall[4,i] +miniRedBall[5,i];
                lastNear = near[i];
                lastRepeat = repeat[i];
                lastMyNumber = myNumber;
                lastOne = miniRedBall[0, i];
                LastSix = miniRedBall[5, i];
            }
            else
            {
                newRow["A0"] = miniRedBall[0, i] + miniRedBall[1, i] + miniRedBall[2, i] + miniRedBall[3, i] + miniRedBall[4, i] + miniRedBall[5, i];
                newRow["A1"] = repeat[i];
                newRow["A2"] = near[i];
                newRow["A3"] = myNumber;
                newRow["A4"] = miniRedBall[0, i];
                newRow["A5"] = miniRedBall[5, i];
                newRow["A6"] = lastSixSum;
                newRow["A7"] = lastRepeat;
                newRow["A8"] = lastNear;
                newRow["A9"] = lastMyNumber;
                newRow["A10"] = lastOne;
                newRow["A11"] = LastSix;

                newRow["A12"] = strGoal;
                newRow["A13"] = myStr;
                newRow["FLAG"] = 444444;
                newRow["ROUND"] = i.ToString("0000");
                _DT.Rows.Add(newRow);

                lastSixSum = int.Parse(newRow["A0"].ToString());
                lastNear = int.Parse(newRow["A1"].ToString()); ;
                lastRepeat = int.Parse(newRow["A2"].ToString()); ;
                lastMyNumber = int.Parse(newRow["A3"].ToString()); ;
                lastOne = int.Parse(newRow["A4"].ToString()); ;
                LastSix = int.Parse(newRow["A5"].ToString()); ;
            }
            strRound += strGoal;
            myRound += repeat[i] + near[i];
            count++;
            switch(strGoal)//1305
            {
                case "12":
                    if (my[0] == 0)
                    {
                        round++;
                    }
                    my[0]++;
                    break;
                case "11":
                    if (my[1] == 0)
                    {
                        round++;
                    }
                    my[1]++;
                    break;
                case "02":
                    if (my[2] == 0)
                    {
                        round++;
                    }
                    my[2]++;
                    break;
                case "21":
                    if (my[3] == 0)
                    {
                        round++;
                    }
                    my[3]++;
                    break;
                case "22":
                    if (my[4] == 0)
                    {
                        round++;
                    }
                    my[4]++;
                    break;
                case "01":
                    if (my[5] == 0)
                    {
                        round++;
                    }
                    my[5]++;
                    break;
            }

            if (round == 6 || (round == 5 && count >= 20) || (round == 4 && count >= 30))
            {
                int myAll = my[0] + my[1] + my[2] + my[3] + my[4] + my[5];
                newRow = _DT.NewRow();
                newRow["A0"] = count;
                newRow["A1"] = my[0];
                newRow["A2"] = my[1];
                newRow["A3"] = my[2];
                newRow["A4"] = my[3];
                newRow["A5"] = my[4];
                newRow["A6"] = my[5];
                newRow["A7"] = myAll;
                newRow["A8"] = myRound;
                newRow["A14"] = (double)myAll / (double)count;
                newRow["A12"] = strRound;
                newRow["A13"] = my[0].ToString() + "|" +my[1].ToString() + "|" +my[2].ToString() + "|" +my[3].ToString() + "|" +my[4].ToString() + "|" +my[5].ToString();
                newRow["FLAG"] = 444555;
                _DT.Rows.Add(newRow);


                strRound = string.Empty;
                my = new int[6];
                round = 0;
                count = 0;
                myRound = 0;
            }
        }
    }
    #endregion

    #region UPUP
    private void UPUPEverySum(int[,] redBall, ArrayList arrRound)
    {
        DataRow newRow;
        for (int i = 3; i <= 9; i++)
        {
            for (int j = arrRound.Count - i - 1; j >= 1; j--)
            {
                int[] sum = new int[33];
                for (int y = 1; y <= i; y++)
                {
                    for (int x = 0; x < 33; x++)
                    {
                        sum[x] += redBall[x, j + y];
                    }
                }

                newRow = _DT.NewRow();
                newRow["ROUND"] = arrRound[j].ToString();
                newRow["FLAG"] = 55555500 + i;
                int zeroSum = 0;
                for (int x = 0; x < 33; x++)
                {
                    newRow["A12"] += sum[x].ToString();
                    if (sum[x] == 0)
                        zeroSum++;
                }
                newRow["A10"] = zeroSum;
                zeroSum = 0;
                for (int x = 0; x < 33; x++)
                {
                    sum[x] += redBall[x, j];
                    newRow["A13"] += sum[x].ToString();
                    if (sum[x] == 0)
                        zeroSum++;
                }
                newRow["A11"] = zeroSum;

                _DT.Rows.Add(newRow);
            }
        }
    }
    private void UPUP33Sum(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        DataRow newRow;
        int lastCount6 = 0;
        int count6 = 0;

        NormalDistribution nn = new NormalDistribution();
        List<double> dd;

        for (int j = arrRound.Count - 1; j >= 1 ; j--)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[j].ToString() + ":", "red",_Print);
            int count33 = 0;
            lastCount6 = count6;
            count6 = 0;
            int[] iiSix = new int[7];
            int[] leftRight = new int[7];
            int[] goal = new int[7];
            leftRight[0] = miniRedBall[0, j];
            leftRight[1] = miniRedBall[1, j] - miniRedBall[0, j];
            leftRight[2] = miniRedBall[2, j] - miniRedBall[1, j];
            leftRight[3] = miniRedBall[3, j] - miniRedBall[2, j];
            leftRight[4] = miniRedBall[4, j] - miniRedBall[3, j];
            leftRight[5] = miniRedBall[5, j] - miniRedBall[4, j];
            leftRight[6] = 33 - miniRedBall[5, j];
            if (leftRight[6] == 0)
                leftRight[6]++;
            int countIISix = 0;
            for (int i = 0; i < 33; i++)
            {
                int ii = MyTest.FindUpNumber(j - 1, i, arrRound.Count - 1, redBall);
                iiSix[countIISix] += ii;
   

                if (i == 0)
                    MyGoal.InnerHtml += NewNumber.DisplayStr("UpNumber-" + ii.ToString("00"), "blue",_Print);
                else
                    MyGoal.InnerHtml += NewNumber.DisplayStr("|" + ii.ToString("00"), "blue",_Print);

                count33 += ii;
                if (redBall[i, j - 1] == 1)
                {
                    count6 += ii;
                    goal[countIISix]++;
                }
                if (ii == 0)
                    countIISix++;
            }
            MyGoal.InnerHtml += NewNumber.DisplayStr("-COUNR33:" + count33.ToString("000"), "black",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr("-COUNR6:" + lastCount6.ToString("00") + "-", "brown",_Print   );

            string str = string.Empty;
            string strNew = string.Empty;
            string strGoal = string.Empty;
            string strRightLeft = string.Empty;
            for (int i = 0; i < 7; i++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr("|" + iiSix[i].ToString("00") + "/" + leftRight[i].ToString() + "=" + (iiSix[i] / leftRight[i]).ToString(), "blue", _Print);
                str += "-" + (iiSix[i] / 10).ToString();
                strNew += "-" + (iiSix[i] / leftRight[i]).ToString();

                strGoal += "-" + goal[i].ToString();

                strRightLeft += "-" + leftRight[i].ToString();
            }
            MyGoal.InnerHtml += NewNumber.DisplayStr("|" + str, "brown", _Print);

            MyGoal.InnerHtml += NewNumber.DisplayStr("|" + strNew, "black", _Print);

            MyGoal.InnerHtml += NewNumber.DisplayStr("|" + strGoal, "green", _Print);

            dd = MyTest.CreateStdev7DD(leftRight);

            double stdev = nn.stdev(dd);

            MyGoal.InnerHtml += NewNumber.DisplayStr("|" + strRightLeft + "|" + stdev.ToString(), "red", _Print);

            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);


            for (int i = 0; i < 7; i++ )
            {
                newRow = _DT.NewRow();
                newRow["ROUND"] = arrRound[j].ToString();
                newRow["FLAG"] = 5555552;
                newRow["A0"] = iiSix[i];
                newRow["A1"] = iiSix[i] / 10;
                newRow["A2"] = leftRight[i];
                newRow["A3"] = iiSix[i] / leftRight[i];
                newRow["A4"] = goal[i];
                _DT.Rows.Add(newRow);
 
            }
            newRow = _DT.NewRow();
            newRow["A0"] = count33;
            newRow["A1"] = lastCount6;
            newRow["A2"] = count6;
            newRow["A3"] = count6 + lastCount6;
            newRow["A4"] = count33 - lastCount6;

            newRow["A5"] = iiSix[0];
            newRow["A6"] = iiSix[1];
            newRow["A7"] = iiSix[2];
            newRow["A8"] = iiSix[3];
            newRow["A9"] = iiSix[4];
            newRow["A10"] = iiSix[5];
            newRow["A11"] = iiSix[6];

            newRow["A12"] = str;
            newRow["A13"] = strNew;
            newRow["A14"] = strGoal;

            newRow["A15"] = leftRight[0];
            newRow["A16"] = leftRight[1];
            newRow["A17"] = leftRight[2];
            newRow["A18"] = leftRight[3];
            newRow["A19"] = leftRight[4];
            newRow["A20"] = leftRight[5];
            newRow["A21"] = leftRight[6];

            newRow["A22"] = goal[0];
            newRow["A23"] = goal[1];
            newRow["A24"] = goal[2];
            newRow["A25"] = goal[3];
            newRow["A26"] = goal[4];
            newRow["A27"] = goal[5];
            newRow["A28"] = goal[6];
            newRow["A29"] = stdev;

            newRow["ROUND"] = arrRound[j].ToString();
            newRow["FLAG"] = 5555551;
            _DT.Rows.Add(newRow);

        }
    }

    private void UPUP(int[,] redBall, ArrayList arrRound)
    {
        DataRow newRow;
        string[] strUP = new string[33];
        for (int i = 0; i < 33; i++)
        {              
            int j = 0;
            while (j <= arrRound.Count - 1)
            {
                int ii = MyTest.FindUpNumber(j, i, arrRound.Count - 1, redBall);
                j += ii + 1;
                if(ii >= 100)
                    strUP[i] += "99$";
                else
                    strUP[i] += ii.ToString("00$");
            }

            for (j = 0; j <= strUP[i].Length - 6; j = j + 3)
            {
                newRow = _DT.NewRow();
                newRow["A0"] = j;
                newRow["A1"] = i + 1;
                if (j + 6 <= strUP[i].Length)
                    newRow["A12"] = strUP[i].Substring(j, 6);
                if (j + 9 <= strUP[i].Length)
                    newRow["A13"] = strUP[i].Substring(j, 9);
                if (j + 12 <= strUP[i].Length)
                    newRow["A14"] = strUP[i].Substring(j, 12);
                if (j + 15 <= strUP[i].Length)
                    newRow["A15"] = strUP[i].Substring(j, 15);
                if (j + 18 <= strUP[i].Length)
                    newRow["A16"] = strUP[i].Substring(j, 18);
                if (j + 21 <= strUP[i].Length)
                    newRow["A17"] = strUP[i].Substring(j, 21);
                if (j + 24 <= strUP[i].Length)
                    newRow["A18"] = strUP[i].Substring(j, 24);
                if (j + 27 <= strUP[i].Length)
                    newRow["A19"] = strUP[i].Substring(j, 27);
                if (j + 30 <= strUP[i].Length)
                    newRow["A20"] = strUP[i].Substring(j, 30);
                newRow["FLAG"] = 555555;
                _DT.Rows.Add(newRow);
            }
            
        }
    }
    #endregion

    #region BlueAndSix
    private int[] RepeatBall(int[,] miniRedBall,ArrayList arrRound)
    {
        int[] repeat = new int[MaxMax];
        for (int i = 1; i < arrRound.Count - 1; i++)
        {
            int[] aa = new int[6];

            for (int j = 0; j < 6; j++)
            {
                aa[j] = miniRedBall[j, i];
            }

            for(int x = 0; x < 6; x++)
                for (int y = 0; y < 6; y++)
                {
                    if (miniRedBall[y, i + 1] == aa[x])
                    {
                        repeat[i]++;
                        break;
                    }
                }
        }
        
        return repeat;
    }
    private int[] NearBall(int[,] miniRedBall, ArrayList arrRound)
    {
        int[] near = new int[MaxMax];

        for (int i = 1; i < arrRound.Count - 1; i++)
        {
            int[] aa = new int[6];

            for (int j = 0; j < 6; j++)
            {
                aa[j] = miniRedBall[j, i];
            }

            for (int x = 0; x < 6; x++)
                for (int y = 0; y < 6; y++)
                {
                    if (!aa.Contains(miniRedBall[y, i + 1]))
                    {
                        if (miniRedBall[y, i + 1] == aa[x] - 1 || miniRedBall[y, i + 1] == aa[x] + 1)
                        {
                            near[i]++;
                            break;
                        }
                    }
                }
        }
        return near;
    
    }
    private string SimpleRedSix(int redJ, int redJNext)
    {
        if (redJ == redJNext)
            return "中";
        else if (redJ > redJNext)
            return "大";
        else
            return "小";
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
    private void BlueAndSixGroup(int[] blueBall, int[,] redBall, ArrayList arrRound)
    {
        DataRow newRow;
        for (int i = 0; i < arrRound.Count - 1; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " ", "blue", _Print);
            int[] six = new int[11];
            for (int j = 0; j < 33; j++)
            {
                if(redBall[j,i] == 1)
                    six[j / 3]++;
            }
            string strSix = "";
            for (int j = 0; j < six.Length; j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(six[j].ToString("00") + " ", "red", _Print);
                strSix += six[j].ToString() + "|";
            } 
            int blue = blueBall[i] / 4;
            MyGoal.InnerHtml += NewNumber.DisplayStr(blue.ToString("00") + "  " , "blue", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            newRow = _DT.NewRow();

            newRow["A12"] = strSix;
            newRow["A13"] = blue;
            newRow["ROUND"] = arrRound[i].ToString();
            newRow["FLAG"] = 11111166;
            _DT.Rows.Add(newRow);
        }
    }

    private void BlueLeftRight(int[] blueBall, ArrayList arrRound, int[] sixSum, int[,] miniRedBall, int[,] redBall)
    {
        int[] repeat = RepeatBall(miniRedBall, arrRound);
        int[] near = NearBall(miniRedBall, arrRound);
        DataRow newRow;
        int[] blueUp = new int[arrRound.Count];
        for (int i = 1; i < arrRound.Count - 1; i++)
        {
            blueUp[i] = blueBall[i] - blueBall[i + 1];
        }
        string[] miniRedNow = new string[6];
        miniRedNow[0] = "-" + miniRedBall[0, 1].ToString("00") + "-" + miniRedBall[0, 2].ToString("00") + "-" + miniRedBall[0, 3].ToString("00");
        miniRedNow[1] = "-" + miniRedBall[1, 1].ToString("00") + "-" + miniRedBall[1, 2].ToString("00");
        miniRedNow[2] = "-" + miniRedBall[2, 1].ToString("00") + "-" + miniRedBall[2, 2].ToString("00");
        miniRedNow[3] = "-" + miniRedBall[3, 1].ToString("00") + "-" + miniRedBall[3, 2].ToString("00");
        miniRedNow[4] = "-" + miniRedBall[4, 1].ToString("00") + "-" + miniRedBall[4, 2].ToString("00");
        miniRedNow[5] = "-" + miniRedBall[5, 1].ToString("00") + "-" + miniRedBall[5, 2].ToString("00") + "-" + miniRedBall[5, 3].ToString("00");
        string sixSumNow = "/" + (sixSum[1]/10).ToString("00") + "/" + (sixSum[2]/10).ToString("00") + "/" + (sixSum[3]/10).ToString("00");
        string blueBallNow = "|" + blueBall[1].ToString("00") + "|" + blueBall[2].ToString("00");// +"|" + blueBall[3].ToString("00");
        ArrayList alSixSum = new ArrayList();
        ArrayList alBlueBall = new ArrayList();
        ArrayList alOne = new ArrayList();
        ArrayList alOne3 = new ArrayList();
        ArrayList alTwo = new ArrayList();
        ArrayList alThree = new ArrayList();
        ArrayList alFour = new ArrayList();
        ArrayList alFive = new ArrayList();
        ArrayList alSix = new ArrayList();
        ArrayList alSix3 = new ArrayList();
        int sum = 0;
        int sumBlue = 0;
        int sumSix = 0;
        string strBlue = string.Empty;//分析篮ball
        string strSumSix = string.Empty;//分析红ball和值
        string strRedOne = string.Empty;//分析定位红第一位
        string strRedTwo = string.Empty;//分析定位红第二位
        string strRedThree = string.Empty;//分析定位红第三位
        string strRedFour = string.Empty;//分析定位红第四位
        string strRedFive = string.Empty;//分析定位红第五位
        string strRedSix = string.Empty;//分析定位红第六位
        string strSimOne = string.Empty;//分析定位红第一位
        string strSimTwo = string.Empty;//分析定位红第二位
        string strSimThree = string.Empty;//分析定位红第三位
        string strSimFour = string.Empty;//分析定位红第四位
        string strSimFive = string.Empty;//分析定位红第五位
        string strSimSix = string.Empty;//分析定位红第六位
        string strRepeatNear = string.Empty;//分析重临ball
        int[] redBall01 = new int[33];//33位 0 1
        int[] redBallAll = new int[33];//33位累加
        string[] strRedBall01 = new string[10];
        for (int y = 0; y < 33; y++)
        {
            strRedBall01[0] += redBall[y, 1].ToString();
        }
        for (int i = 2; i <= 50; i++)
        {            
            for (int j = 1; j <= arrRound.Count - 1; j++)
            {
                sum = 0;
                sumBlue = 0;
                sumSix = 0;
                strBlue = string.Empty;
                strSumSix = string.Empty;
                strRedOne = string.Empty;//分析定位红第一位
                strRedTwo = string.Empty;//分析定位红第二位
                strRedThree = string.Empty;//分析定位红第三位
                strRedFour = string.Empty;//分析定位红第四位
                strRedFive = string.Empty;//分析定位红第五位
                strRedSix = string.Empty;//分析定位红第六位
                strSimOne = string.Empty;//分析定位红第一位
                strSimTwo = string.Empty;//分析定位红第二位
                strSimThree = string.Empty;//分析定位红第三位
                strSimFour = string.Empty;//分析定位红第四位
                strSimFive = string.Empty;//分析定位红第五位
                strSimSix = string.Empty;//分析定位红第六位
                strRepeatNear = string.Empty;//分析重临ball
                redBall01 = new int[33];//33位 0 1
                redBallAll = new int[33];//33位累加
                int myNumber = 0;
                string myStr = "";

                for (int x = 0; x < i; x++)
                {
                    if (j + x < arrRound.Count)
                    {
                        if (j + x < arrRound.Count - 1)
                        {
                            strSimOne += SimpleRedSix(miniRedBall[0, j + x], miniRedBall[0, j + x + 1]);//分析定位红第一位
                            strSimTwo += SimpleRedSix(miniRedBall[1, j + x], miniRedBall[1, j + x + 1]);//分析定位红第二位
                            strSimThree += SimpleRedSix(miniRedBall[2, j + x], miniRedBall[2, j + x + 1]);//分析定位红第三位
                            strSimFour += SimpleRedSix(miniRedBall[3, j + x], miniRedBall[3, j + x + 1]);//分析定位红第四位
                            strSimFive += SimpleRedSix(miniRedBall[4, j + x], miniRedBall[4, j + x + 1]);//分析定位红第五位
                            strSimSix += SimpleRedSix(miniRedBall[5, j + x], miniRedBall[5, j + x + 1]);//分析定位红第六位
                        }
                        sum += blueUp[j + x];
                        sumBlue += blueBall[j + x];
                        sumSix += sixSum[j + x];
                        if (j + x == i || j + x == arrRound.Count - 1 || x == i - 1)
                        {
                            strBlue += blueBall[j + x].ToString("00");
                            strSumSix += (sixSum[j + x] / 10).ToString("00");
                            strRedOne += miniRedBall[0, j + x].ToString("00");
                            strRedTwo += miniRedBall[1, j + x].ToString("00");
                            strRedThree += miniRedBall[2, j + x].ToString("00");
                            strRedFour += miniRedBall[3, j + x].ToString("00");
                            strRedFive += miniRedBall[4, j + x].ToString("00");
                            strRedSix += miniRedBall[5, j + x].ToString("00");
                            strRepeatNear += repeat[j + x].ToString("0") + near[j + x].ToString("0");
                        }
                        else
                        {
                            strBlue += blueBall[j + x].ToString("00") + "|";
                            strSumSix += (sixSum[j + x] / 10).ToString("00") + "/";
                            strRedOne += miniRedBall[0, j + x].ToString("00") + "-";
                            strRedTwo += miniRedBall[1, j + x].ToString("00") + "-";
                            strRedThree += miniRedBall[2, j + x].ToString("00") + "-";
                            strRedFour += miniRedBall[3, j + x].ToString("00") + "-";
                            strRedFive += miniRedBall[4, j + x].ToString("00") + "-";
                            strRedSix += miniRedBall[5, j + x].ToString("00") + "-";
                            strRepeatNear += repeat[j + x].ToString("0") + near[j + x].ToString("0") + "&";
                        }
                        int nowMumber = repeat[j + x] * 3 + near[j + x] * 2;
                        myNumber += nowMumber;
                        if (nowMumber > 7)
                            myStr += "大";
                        else if (nowMumber <= 4)
                            myStr += "小";
                        else
                            myStr += "中";

                        for (int y = 0; y < 33; y++)
                        {                            
                            if (redBall[y, j + x] == 1)
                            {
                                redBallAll[y] += redBall[y, j + x];
                                redBall01[y] = 1;
                            }
                        }
                    }
                    else
                        break;
                }
                newRow = _DT.NewRow();
                newRow["A0"] = sum;
                newRow["A1"] = Math.Abs(sum);
                newRow["A2"] = j;
                newRow["A3"] = blueBall[j - 1];
                newRow["A4"] = sumBlue / i;
                newRow["A5"] = sumBlue;
                newRow["A6"] = sumSix / i / 10 * 10;
                newRow["A7"] = sumSix;
                newRow["A8"] = sixSum[j - 1] / 10 * 10;
                newRow["A9"] = sixSum[j - 1];
                newRow["A10"] = FindLastBlue(j, blueBall);
                if(i == 3 && j + 2 < arrRound.Count)
                    newRow["A11"] = (blueBall[j] - blueBall[j + 1]) * (blueBall[j + 1] - blueBall[j + 2]);
                newRow["A12"] = strBlue;
                newRow["A13"] = strSumSix;
                newRow["A14"] = strRedOne;
                newRow["A15"] = strRedTwo;
                newRow["A16"] = strRedThree;
                newRow["A17"] = strRedFour;
                newRow["A18"] = strRedFive;
                newRow["A19"] = strRedSix;
                newRow["A20"] = strRepeatNear;
                for (int y = 0; y < 33; y++)
                {
                    newRow["A21"] += redBallAll[y].ToString();
                    newRow["A22"] += redBall01[y].ToString();
                }
                newRow["A23"] = myNumber.ToString();
                newRow["A24"] = myStr;
                newRow["A25"] = strSimOne;
                newRow["A26"] = strSimTwo;
                newRow["A27"] = strSimThree;
                newRow["A28"] = strSimFour;
                newRow["A29"] = strSimFive;
                newRow["A30"] = strSimSix;
                newRow["ROUND"] = arrRound[j].ToString();
                newRow["FLAG"] = i;
                _DT.Rows.Add(newRow);

                if (j == 1 && i <= 10)
                {
                    strRedBall01[i - 1] = newRow["A22"].ToString();
                }

                string[] ss;
                if (i == 4)
                {
                    //if (strBlue.Contains(blueBallNow))
                    //{
                    //    ss = strBlue.Split('|');
                    //    alBlueBall.Add(ss[0]);
                    //}
                    if (strSumSix.Contains(sixSumNow))
                    {
                        ss = strSumSix.Split('/');
                        alSixSum.Add(ss[0]);
                    }
                    if (strRedOne.Contains(miniRedNow[0]))
                    {
                        ss = strRedOne.Split('-');
                        alOne.Add(ss[0]);
                    }
                    if (strRedSix.Contains(miniRedNow[5]))
                    {
                        ss = strRedSix.Split('-');
                        alSix.Add(ss[0]);
                    }
                }
                else if (i == 3)
                {
                    if (strBlue.Contains(blueBallNow))
                    {
                        ss = strBlue.Split('|');
                        alBlueBall.Add(ss[0]);
                    }
                    if (strRedOne.Contains(miniRedNow[0].Substring(0, miniRedNow[0].Length - 3)))
                    {
                        ss = strRedOne.Split('-');
                        alOne3.Add(ss[0]);
                    }
                    if (strRedSix.Contains(miniRedNow[5].Substring(0, miniRedNow[5].Length - 3)))
                    {
                        ss = strRedSix.Split('-');
                        alSix3.Add(ss[0]);
                    }
                    if (strRedTwo.Contains(miniRedNow[1]))
                    {
                        ss = strRedTwo.Split('-');
                        alTwo.Add(ss[0]);
                    }
                    if (strRedThree.Contains(miniRedNow[2]))
                    {
                        ss = strRedThree.Split('-');
                        alThree.Add(ss[0]);
                    }
                    if (strRedFour.Contains(miniRedNow[3]))
                    {
                        ss = strRedFour.Split('-');
                        alFour.Add(ss[0]);
                    }
                    if (strRedFive.Contains(miniRedNow[4]))
                    {
                        ss = strRedFive.Split('-');
                        alFive.Add(ss[0]);
                    }
                }
            }
        }

        sum = 0;
        for (int i = 1; i <= arrRound.Count - 1; i++)
        {
            sum += blueUp[i];
            if ((i - 1) % 3 == 0)
            {
                newRow = _DT.NewRow();
                newRow["A0"] = sum;
                newRow["A1"] = Math.Abs(sum);
                newRow["A2"] = i;
                newRow["FLAG"] = 3333;
                _DT.Rows.Add(newRow);
            }
        }

        sum = 0;
        //int last1 = 0;
        int last2 = 0;
        for (int i = 1; i <= arrRound.Count - 1; i++)
        {
            sum += blueUp[i];
            //if (Math.Abs(sum) <= 1)
            //{
            //    newRow = _DT.NewRow();
            //    newRow["A0"] = sum;
            //    newRow["A1"] = Math.Abs(sum);
            //    newRow["A2"] = i - last1;
            //    newRow["FLAG"] = 4444;
            //    _DT.Rows.Add(newRow);
            //    last1 = i;
            //}

            if (Math.Abs(sum) <= 2)
            {
                newRow = _DT.NewRow();
                newRow["A0"] = sum;
                newRow["A1"] = Math.Abs(sum);
                newRow["A2"] = i - last2;
                newRow["FLAG"] = 5555;
                _DT.Rows.Add(newRow);
                last2 = i;
                sum = 0;
            }
        }
        alBlueBall.Sort();
        alSixSum.Sort();
        alOne.Sort();
        alTwo.Sort();
        alThree.Sort();
        alFour.Sort();
        alFive.Sort();
        alSix.Sort();
        alOne3.Sort();
        alSix3.Sort();
        PrintBlueLeftRight(blueBallNow, sixSumNow, miniRedNow, alBlueBall, alSixSum, alOne, alTwo, alThree, alFour, alFive, alSix, alOne3, alSix3, strRedBall01);
    }
    private void PrintBlueLeftRight(string blueBallNow, string sixSumNow, string[] miniRedNow, ArrayList alBlueBall, ArrayList alSixSum, ArrayList alOne, ArrayList alTwo, ArrayList alThree, ArrayList alFour, ArrayList alFive, ArrayList alSix, ArrayList alOne3, ArrayList alSix3, string[] strRedBall01)
    {
        MyGoal.InnerHtml += NewNumber.DisplayStr("//BlueBallNow:" + blueBallNow, "blue", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("_NoSelectBlueBall = \"", "green", _Print);
        for (int i = 0; i < alBlueBall.Count; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(alBlueBall[i].ToString() + " ", "red", _Print);
        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("\";", "green", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

        MyGoal.InnerHtml += NewNumber.DisplayStr("//SixSumNow:" + sixSumNow, "blue", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("_NoSelectSixSum = \"", "green", _Print);
        for (int i = 0; i < alSixSum.Count; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(alSixSum[i].ToString() + "0 ", "red", _Print);
        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("\";", "green", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

        for (int i = 0; i < miniRedNow.Length; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr("//MiniRedBall" + i.ToString() + ":" + miniRedNow[i], "blue", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
            switch (i)
            {
                case 0:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("_MiniRedNow[" + i.ToString() + "] = \"", "green", _Print);
                    for (int j = 0; j < alOne.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr(alOne[j].ToString() + " ", "red", _Print);
                    }
                    for (int j = 0; j < alOne3.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr("-" + alOne3[j].ToString(), "blue", _Print);
                    }
                    break;
                case 1:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("_MiniRedNow[" + i.ToString() + "] = \"", "green", _Print);
                    for (int j = 0; j < alTwo.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr(alTwo[j].ToString() + " ", "red", _Print);
                    }
                    break;
                case 2:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("_MiniRedNow[" + i.ToString() + "] = \"", "green", _Print);
                    for (int j = 0; j < alThree.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr(alThree[j].ToString() + " ", "red", _Print);
                    }
                    break;
                case 3:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("_MiniRedNow[" + i.ToString() + "] = \"", "green", _Print);
                    for (int j = 0; j < alFour.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr(alFour[j].ToString() + " ", "red", _Print);
                    }
                    break;
                case 4:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("_MiniRedNow[" + i.ToString() + "] = \"", "green", _Print);
                    for (int j = 0; j < alFive.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr(alFive[j].ToString() + " ", "red", _Print);
                    }
                    break;
                case 5:
                    MyGoal.InnerHtml += NewNumber.DisplayStr("_MiniRedNow[" + i.ToString() + "] = \"", "green", _Print);
                    for (int j = 0; j < alSix.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr(alSix[j].ToString() + " ", "red", _Print);
                    }
                    for (int j = 0; j < alSix3.Count; j++)
                    {
                        MyGoal.InnerHtml += NewNumber.DisplayStr("-" + alSix3[j].ToString(), "blue", _Print);
                    }
                    break;
            }
            MyGoal.InnerHtml += NewNumber.DisplayStr("\";", "green", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            //MyGoal.InnerHtml += DisplayStr("strRedBall01:", "blue");
            //MyGoal.InnerHtml += DisplayBR();
        }
        for (int i = 0; i <= 7; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr("_StrRedBall01[" + i.ToString() + "] = \"", "green", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(strRedBall01[i], "red", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr("\";", "green", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
    }
    //private void BlueHotCold(int[] blueBall, ArrayList arrRound)
    //{
    //    DataRow newRow;
    //    int[] blueUp = new int[arrRound.Count];
    //    for (int i = 1; i < arrRound.Count - 1; i++)
    //    {
    //        int count = 0;
    //        for (int j = i; j < arrRound.Count; j++)
    //        {
    //            if (i + j < arrRound.Count)
    //            {
    //                if (blueBall[i] == blueBall[i + j])
    //                {
    //                    blueUp[i] = count;
    //                    newRow = _DT.NewRow();
    //                    newRow["A0"] = count;
    //                    newRow["FLAG"] = 7777;
    //                    _DT.Rows.Add(newRow);
    //                    break;
    //                }
    //                count++;
    //            }
    //            else
    //                break;
    //        }
    
    //    }
    //}
    #endregion

    #region OneByOne
    private int GetBallState(int countAll, int countOne)
    {
        int ballState = 0;
        float ff = (float)countOne / (float)countAll;
        if (ff == 0)
            ballState = 0;
        else if (ff < 0.2)
            ballState = 1;
        else if (ff < 0.4)
            ballState = 2;
        else
            ballState = 3;

        return ballState;
    }
    private string GetBallStateByEnd(int redBall, int ballState, int countAll, int countOne, int minNum, int maxNum)
    {
        //int ballState = 0;
        int newBallState = 0;
        int end = 0;
        if (countAll == minNum)//第一次计算
        {
            ballState = GetBallState(countAll, countOne);
        }
        else if (redBall == 1 && countAll >= maxNum)//防止过长
        {
            newBallState = GetBallState(countAll, countOne);
            if (ballState != newBallState)
            {
                ballState = 5;
            }
            end = 1;
        }
        else if (countAll > minNum)//判断是否阶段结束
        {
            newBallState = GetBallState(countAll, countOne);
            if (ballState != newBallState)
            {
                end = 1;
                ballState = 5;
            }
        }
        else//countAll < minNum
        {
            ballState = 5;
        }
        return ballState.ToString() + "|" + end.ToString();
    }

    private void DisplayOneByOne(int[,] redBall, ArrayList arrRound,int minNum, int maxNum)
    {        
        int[,] myBall = new int[33, MaxMax];
        int[,] myBallChange = new int[33, MaxMax];
        int[,] myBallCount = new int[33, MaxMax];
        for (int i = 0; i < 33; i++)
        {
            int countAll = 0;
            int countOne = 0;
            int countIfOne = 0;
            int ballState = 0;
            int newBallState = 0;
            
            //float ffChange = 0;
            bool end = false;
            for (int j = arrRound.Count - 1; j >=0; j--)
            {
                string str;
                string[] ss;
                if (i == 20 && arrRound[j].ToString() == "1111111")
                {
 
                }
                //0  6-无穷大个0 1 6-12个以内达到20% 2 6-12个以内达到%40 3 其他
                countAll++;
                countOne += redBall[i, j];

                myBallCount[i, j] = countAll*100 + countOne;

                if (redBall[i, j] == 0)
                {
                    countIfOne = countOne + 1;
                    str = GetBallStateByEnd(redBall[i, j], ballState,countAll, countIfOne, minNum, maxNum);
                    ss = str.Split('|');
                    newBallState = int.Parse(ss[0]);
                    myBallChange[i, j] = newBallState;
                }

                str = GetBallStateByEnd(redBall[i, j], ballState, countAll, countOne, minNum, maxNum);
                ss = str.Split('|');
                ballState = int.Parse(ss[0]);
                if (ss[1] == "1")
                    end = true;

                myBall[i, j] = ballState;

                if (redBall[i, j] == 1)
                    myBallChange[i, j] = ballState;

                if (end)//阶段结束处理数组
                {
                    end = false;
                    if (ballState == 5)//不包含
                    {
                        countAll = 1;
                        countOne = redBall[i, j];
                    }
                    else
                    {
                        countAll = 0;
                        countOne = 0;
                    }
                }
            }
        }
        DisplayMyBall(myBall, myBallCount, myBallChange, redBall, arrRound, maxNum * 10 + minNum);
    }

    private void DisplayMyBall(int[,] myBall, int[,] myBallCount, int[,]myBallChange,int[,] redBall, ArrayList arrRound, int flag)
    {
        DataRow newRow;
        string strLastOne = "";//最后一轮的中间过程显示
        string strNext = "";//最后预测轮的中间过程显示
        string strNoSelect = "";//不可以选择的
        string str00 = "";//可选择的黑色
        string str11 = "";//可选择的绿色
        string str22 = "";//可选择的蓝色
        string str33 = "";//可选择的红色
        string str44 = "";//可选择的棕色
        for (int i = arrRound.Count - 1; i >= 0; i--) //for (int i = 500; i >= 0; i--)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "brown",_Print);
            int sum0 = 0;
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            int sum4 = 0;
            int sum00 = 0;
            int sum11 = 0;
            int sum22 = 0;
            int sum33 = 0;
            int sum44 = 0;
            int sumOneChange = 0;//计算每一轮如果全是命中可能改变的数量
            int sumChange = 0;//计算每一轮结果造成改变的数量
            int sumChange0 = 0;//计算每一轮由于结果为1造成改变的数量
            for (int j = 0; j < 33; j++)
            {
                if (j == 1 && arrRound[i].ToString() == "2009119")
                {

                }
                string color = "";

                if (i != arrRound.Count - 1)
                {
                    switch (myBall[j, i + 1])
                    {
                        case 0:
                            sum00++;
                            if (i == 0) str00 += (j + 1).ToString() + "|";
                            if (redBall[j, i] == 1) sum0++; 
                            break;
                        case 1:
                            sum11++;
                            if (i == 0) str11 += (j + 1).ToString() + "|";
                            if (redBall[j, i] == 1) sum1++; 
                            break;
                        case 2:
                            sum22++;
                            if (i == 0) str22 += (j + 1).ToString() + "|";
                            if (redBall[j, i] == 1) sum2++; 
                            break;
                        case 3:
                            sum33++;
                            if (i == 0) str33 += (j + 1).ToString() + "|";
                            if (redBall[j, i] == 1) sum3++; 
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            sum44++;
                            if (i == 0) str44 += (j + 1).ToString() + "|";
                            if (redBall[j, i] == 1) sum4++; 
                            break;
                    }
                    if (myBall[j, i + 1] != myBall[j, i])
                    {
                        sumChange++;
                        if (redBall[j, i] == 1)
                            sumChange0++;
                    }
                    if (myBall[j, i + 1] != myBallChange[j, i])
                    {
                        sumOneChange++;
                    }
                    else if (i == 0)
                    {
                        strNoSelect += (j+1).ToString() + "|";
                    }
                    if (i == 1)
                        strLastOne += j.ToString() + " " + myBall[j, i + 1].ToString() + myBallChange[j, i].ToString() + "|";
                    if (i == 0)
                        strNext += j.ToString() + " " + myBall[j, i + 1].ToString() + myBallChange[j, i].ToString() + "|";
                }
                switch (myBall[j, i])
                {
                    case 0:
                        color = "black"; break;
                    case 1:
                        color = "green"; break;
                    case 2:
                        color = "blue"; break;
                    case 3:
                        color = "red"; break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        color = "purple"; break;
                }
                if (redBall[j, i] == 0)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStrWidth("00" + " ", color,_Print);
                }
                else
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStrWidthBold((j + 1).ToString("00") + " ", color,_Print);
                }

                if (j == 32)
                {
                    MyGoal.InnerHtml += NewNumber.DisplayStr(myBallCount[j, i].ToString("0000") + " ", color,_Print);
                    //MyGoal.InnerHtml += DisplayStr(myBallChange[j, i].ToString("00") + " ", color);
                }
                //if(i == 0)
                //    MyGoal.InnerHtml += DisplayStr(myBall[j, i+1].ToString()+"-"+ myBallChange[j, i].ToString(), color);

            }
            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sum0.ToString() + "_" + sum00.ToString(), "black", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sum1.ToString() + "_" + sum11.ToString(), "green", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sum2.ToString() + "_" + sum22.ToString(), "blue", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sum3.ToString() + "_" + sum33.ToString(), "red", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sum4.ToString() + "_" + sum44.ToString(), "purple", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sumChange0.ToString() + "_" + sumOneChange.ToString() + "|" + sumChange.ToString(), "brown", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);


            if (i != 0)//去除1111111轮
            {
                newRow = _DT.NewRow();
                newRow["A0"] = sum0;
                newRow["A1"] = sum00;
                newRow["A2"] = sum1;
                newRow["A3"] = sum11;
                newRow["A4"] = sum2;
                newRow["A5"] = sum22;
                newRow["A6"] = sum3;
                newRow["A7"] = sum33;
                newRow["A8"] = sumChange0;
                newRow["A9"] = sumOneChange;
                newRow["FLAG"] = flag;
                newRow["A10"] = sum4;
                newRow["A11"] = sum44;
                newRow["A12"] = OneCombination(sumOneChange, sumChange0, false);
                _DT.Rows.Add(newRow);
            }
        }
        if (flag == 73)
        {
            for (int i = 0; i < 33; i++)
            {
                int now = 5;
                for (int j = arrRound.Count - 1; j > 0; j--)
                {
                    if (now == 5)
                        now = myBall[i, j];
                    else if (myBall[i, j] != 5 && myBall[i, j] != now)
                    {
                        newRow = _DT.NewRow();
                        newRow["A0"] = now;
                        newRow["A1"] = myBall[i, j];
                        newRow["A2"] = i;
                        newRow["A12"] = now.ToString() + myBall[i, j].ToString();
                        newRow["A13"] = arrRound[j].ToString();
                        newRow["FLAG"] = "111222";
                        _DT.Rows.Add(newRow);
                        now = myBall[i, j];
                    }

                }
            }
        }


        MyGoal.InnerHtml += NewNumber.DisplayStr("LastOne-" + strLastOne, "purple", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR( _Print);
        MyGoal.InnerHtml += NewNumber.DisplayStr("1111111-" + strNext, "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR( _Print);


        MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[1].ToString() + "NSelect-" + strNoSelect, "blue", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR();
        MyGoal.InnerHtml += NewNumber.DisplayStr("黑色-" + str00, "black", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR();
        MyGoal.InnerHtml += NewNumber.DisplayStr("绿色-" + str11, "green", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR();
        MyGoal.InnerHtml += NewNumber.DisplayStr("蓝色-" + str22, "blue", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR();
        MyGoal.InnerHtml += NewNumber.DisplayStr("红色-" + str33, "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR();
        MyGoal.InnerHtml += NewNumber.DisplayStr("棕色-" + str44, "purple", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR( _Print);

        for (int i = 0; i < 33; i++)
        {
            int ii = MyTest.FindUpNumber(0, i, arrRound.Count - 1, redBall); 
            if(i == 0)
                MyGoal.InnerHtml += NewNumber.DisplayStr("UpNumber-" + ii.ToString(), "blue", _Print); 
            else
                MyGoal.InnerHtml += NewNumber.DisplayStr("|" + ii.ToString(), "blue", _Print); 
        }
        MyGoal.InnerHtml += NewNumber.DisplayBR( _Print);
    }

    #endregion

    #region Right--
    private int GetMyBall(int input)
    {
        int output = 0;
        switch (input)
        {
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
                output = 1; break;
            case 0:
            case 1:
            case 2:
                output = 0;break;
            default:
                output = 2; break;
        }
        return output;
    }

    private int GetMyUpBall(int input)
    {
        int output = 0;
        switch (input)
        {
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
                output = 1; break;
            case 0:
            case 1:
            case 2:
                output = 0; break;
            default:
                output = 2; break;

        }
        return output;
    }



    private void Right_Left(int[,] redBall, ArrayList arrRound, int arrLintCount)
    {
        int[,] myBall = new int[6, MaxMax];
        string[] nowBall = new string[MaxMax];
        string[] sameBall = new string[MaxMax];
        string[] sameMyBall = new string[MaxMax];
        string[] sameOrderbyBall = new string[MaxMax];
        string[] sameOrderbyMyBall = new string[MaxMax];
        int[] my = new int[3];//使得1234分类统计结果差不多
        int[] myCount = new int[27];//统计出现数字的个数

        int[,] myUpBall = new int[6, MaxMax];
        string[] sameUpBall = new string[MaxMax];
        string[] sameMyUpBall = new string[MaxMax];
        string[] sameOrderbyUpBall = new string[MaxMax];
        string[] sameOrderbyMyUpBall = new string[MaxMax];
        int[] myUp = new int[3];//使得1234分类统计结果差不多
        int[] myUpCount = new int[200];//统计上一次出现该数字和本次的间隔

        for (int i = 1; i < arrLintCount; i++)
        {
            ArrayList al = new ArrayList();//为sameOrderbyBall排序
            ArrayList alUp = new ArrayList();//为sameOrderbyBall排序
            int min = 0;
            int count = 0;
            for (int j = 0; j < 33; j++)
            {
                if (redBall[j, i] == 1) 
                {
                    nowBall[i] += (j + 1).ToString("00");

                    myBall[count,i] = j - min;
                    min = j + 1;
                    myCount[myBall[count, i]]++;
                    
                    sameBall[i] += myBall[count, i].ToString("00");

                    int mm = GetMyBall(myBall[count, i]);
                    my[mm]++;
                    sameMyBall[i] += mm.ToString("00");
                    
                    al.Add(myBall[count, i]);

                    myUpBall[count, i] = MyTest.FindUpNumber(i, j, arrLintCount, redBall);
                    
                    myUpCount[myUpBall[count, i]]++;

                    sameUpBall[i] += myUpBall[count, i].ToString("00");

                    mm = GetMyUpBall(myUpBall[count, i]);
                    myUp[mm]++;
                    sameMyUpBall[i] += mm.ToString("00");

                    alUp.Add(myUpBall[count, i]);

                    count++;
                }
            }   
            al.Sort();
            alUp.Sort();
            for (int j = 0; j < al.Count; j++)
            {
                int mm = GetMyBall(int.Parse(al[j].ToString()));
                sameOrderbyBall[i] += int.Parse(al[j].ToString()).ToString("00");//排序之后的结果
                sameOrderbyMyBall[i] += mm.ToString("00");

                mm = GetMyUpBall(int.Parse(alUp[j].ToString()));
                sameOrderbyUpBall[i] += int.Parse(alUp[j].ToString()).ToString("00");//排序之后的结果
                sameOrderbyMyUpBall[i] += mm.ToString("00");
            }
        }

        if(arrLintCount != 2)
            FindLoveNumber(sameOrderbyBall);

        DisplayRight_Left(nowBall ,myBall, myUpBall, arrRound, sameBall, sameUpBall, sameOrderbyBall, sameOrderbyUpBall, sameMyBall, sameMyUpBall, sameOrderbyMyBall, sameOrderbyMyUpBall, arrLintCount);

    }

    /// <summary>
    /// 查找互相排斥的数字
    /// </summary>
    /// <param name="sameOrderbyBall"></param>
    private void FindLoveNumber(string[] sameOrderbyBall)
    {
        int max =  5;
        string[] str = new string[sameOrderbyBall.Length];
        for (int i = 1; i < sameOrderbyBall.Length; i++)
        {
            if (sameOrderbyBall[i] != null)
            {
                for (int j = 0; j < 6; j++)
                {

                    string ss = sameOrderbyBall[i].Substring(j * 2, 2);
                    if (int.Parse(ss) > max)
                        str[i] += max.ToString("00") + "_";
                    else
                        str[i] += ss + "_";

                }
            }
        }

        ArrayList al = new ArrayList();
        for (int i = 0; i <= max; i++)
            for (int j = 0; j <= max; j++)
            {
                int count = 0;
                if (i != j)
                {
                    for(int x = 0; x< str.Length; x++)
                    {
                        if(str[x] != null)
                        {
                            if (str[x].Contains(i.ToString("00_")) && str[x].Contains(j.ToString("00_")))
                                count++;
                        }
                    }
                    DataRow newRow;
                    newRow = _DT.NewRow();
                    newRow["A0"] = i;
                    newRow["A1"] = j;
                    newRow["A2"] = count;
                    newRow["FLAG"] = max * 1111;
                    _DT.Rows.Add(newRow);
                    al.Add(i.ToString("00") + "+" + j.ToString("00") + "=" + count.ToString());
                }
            }
        al.Sort();
    }

    private void DisplayRight_Left(string[] nowBall ,int[,] myBall, int[,] myUpBall, ArrayList arrRound, string[] sameBall, string[] sameUpBall, string[] sameOrderbyBall, string[] sameOrderbyUpBall, string[] sameMyBall, string[] sameMyUpBall, string[] sameOrderbyMyBall, string[] sameOrderbyMyUpBall, int arrRoundCount)
    {

        for (int i = arrRoundCount - 1; i > 0; i--)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "brown", _Print);
            for (int j = 0; j < 6; j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(myBall[j, i].ToString("00") + " ", "red", _Print);
            }

            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sameMyBall[i], "blue", _Print);

            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "Green", _Print);
            int sumUp = 0;
            for (int j = 0; j < 6; j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(myUpBall[j, i].ToString("00") + " ", "blue", _Print);
                sumUp += myUpBall[j, i];
            }

            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sameMyUpBall[i], "red", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayStr(" " + sumUp.ToString(), "brown", _Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

            DataRow newRow;
            newRow = _DT.NewRow();
            newRow["A0"] = sumUp;
            newRow["ROUND"] = arrRound[i].ToString();
            newRow["FLAG"] = 888888;
            _DT.Rows.Add(newRow);


            DTNewRowA12(sameBall[i], 10, arrRound[i].ToString());
            DTNewRowA12(sameOrderbyBall[i], 20, arrRound[i].ToString());
            DTNewRowA12(sameMyBall[i], 30, arrRound[i].ToString());
            DTNewRowA12(sameUpBall[i], 40, arrRound[i].ToString());
            DTNewRowA12(sameOrderbyUpBall[i], 50, arrRound[i].ToString());
            DTNewRowA12(sameMyUpBall[i], 60, arrRound[i].ToString());

            DTNewRowA12(sameOrderbyMyBall[i], 70, arrRound[i].ToString());
            DTNewRowA12(sameOrderbyMyUpBall[i], 80, arrRound[i].ToString());

            DTNewRowA12(nowBall[i], 90, arrRound[i].ToString());
        }
    }

    private void DTNewRowA12(string str, int flag, string round)
    {
        DataRow newRow;
        newRow = _DT.NewRow();
        newRow["A12"] = str;
        newRow["ROUND"] = round;
        newRow["FLAG"] = 6 + flag;
        _DT.Rows.Add(newRow);

        for (int j = 0; j < 2; j++)
        {
            newRow = _DT.NewRow();
            newRow["A12"] = str.Substring(j * 2, 10);
            newRow["ROUND"] = round;
            newRow["FLAG"] = 5 + flag;
            _DT.Rows.Add(newRow);
        }

        for (int j = 0; j < 3; j++)
        {
            newRow = _DT.NewRow();
            newRow["A12"] = str.Substring(j * 2, 8);
            newRow["ROUND"] = round;
            newRow["FLAG"] = 4 + flag;
            _DT.Rows.Add(newRow);
        }

        for (int j = 0; j < 4; j++)
        {
            newRow = _DT.NewRow();
            newRow["A12"] = str.Substring(j * 2, 6);
            newRow["ROUND"] = round;
            newRow["FLAG"] = 3 + flag;
            _DT.Rows.Add(newRow);
        }
    }
    #endregion

    #region Graph
    //private void GraphSixRed(int[,] redBall, ArrayList arrRound)
    //{
    //    for (int i = arrRound.Count - 1; i > 0; i--)
    //    {
    //        MyGoal.InnerHtml += DisplayStr(arrRound[i].ToString() + " || ", "red");
    //    }
    //}
    private void GraphFindAllLine(int[,] redBall, ArrayList arrRound, int line)
    {
        ArrayList al = new ArrayList();
        ArrayList alCount = new ArrayList();
        ArrayList alOneCount = new ArrayList();
        for (int i = arrRound.Count - 1; i > line + 1; i--)
        {
            int count = 0;
            int countOne = 0; 
            int count1 = 0; 
            int count2 = 0; 
            int count3 = 0;
            int count4 = 0;
            for (int j = 0; j < line; j++)
            {
                for (int x = 0; x < 33; x++)
                {
                    if (redBall[x, line - j] == 1 && redBall[x, line - j] == redBall[x,  i - j])
                        count = count + 2;
                    else
                    {
                        if (x != 0 && redBall[x - 1, line - j] == 1 && redBall[x - 1, line - j] == redBall[x, i - j])
                        {
                            countOne++; count1++; //if (j == 0 || j == 1) countOne++;
                        }
                        else if (x != 32 && redBall[x + 1, line - j] == 1 && redBall[x + 1, line - j] == redBall[x, i - j])
                        {
                            countOne++; count2++; //if (j == 0 || j == 1) countOne++;
                        }
                        else if (line - j - 1 != 0 && redBall[x, line - j - 1] == 1 && redBall[x, line - j - 1] == redBall[x, i - j])
                        {
                            countOne++; count3++; //if (j == 0 || j == 1) countOne++;
                        }
                        else if (line - j + 1 != line + 1 && redBall[x, line - j + 1] == 1 && redBall[x, line - j + 1] == redBall[x, i - j])
                        {
                            countOne++; count4++; //if (j == 0 || j == 1) countOne++;
                        }
                    }
                }
            }
            //alOneCount.Add(countOne);
            //if(count + countOne>= 18)
            alCount.Add(count + countOne);
            al.Add(i.ToString() + "_" + (count + countOne).ToString() + "_" + arrRound[i].ToString() + "_" + count1.ToString() + "_" + count2.ToString() + "_" + count3.ToString() + "_" + count4.ToString() );
        }
        alCount.Sort();
        //alOneCount.Sort();
        int max = int.Parse(alCount[alCount.Count - 1].ToString());

        for (int i = 0; i < al.Count; i++)
        {
            int now = int.Parse(al[i].ToString().Split('_')[1]);
            if (now == max)
            {
                alOneCount.Add(al[i].ToString().Split('_')[0]);
                MyGoal.InnerHtml += NewNumber.DisplayStr(al[i].ToString() + " || ", "red", _Print);
            }
        }
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

        string color = "";
        int select = 0;
        for (int i = arrRound.Count - 1; i > 0; i--)
        {
            if (alOneCount.Contains(i.ToString()))
            {
                color = "red";
                select = i;
            }
            else
            {
                if (select !=0 && select - i < line)
                    color = "red";
                else
                    color = "yellow";

            }
            if (color == "red")
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "red", _Print);
            else
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "black", _Print);
            for (int j = 0; j < 33; j++ )
            {
                if (color == "red")
                {
                    if (redBall[j, i] == 1 && redBall[j, line - (select - i)] == 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", "red", _Print);
                    else if (redBall[j, i] == 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", "blue", _Print);
                    else if (redBall[j, line - (select - i)] == 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr(redBall[j, i].ToString("00") + "  ", "red", _Print);
                    else
                        MyGoal.InnerHtml += NewNumber.DisplayStr(redBall[j, i].ToString("00") + "  ", "yellow", _Print);
                }
                else
                {
                    if (redBall[j, i] == 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", "black", _Print);
                    else
                        MyGoal.InnerHtml += NewNumber.DisplayStr(redBall[j, i].ToString("00") + "  ", "yellow", _Print);
                }
            }
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
    }

    private void GraphFindBlueLine(int[] blueBall, ArrayList arrRound, int line)
    {
        ArrayList al = new ArrayList();
        ArrayList alCount = new ArrayList();
        ArrayList alOneCount = new ArrayList();
        for (int i = arrRound.Count - 1; i > line + 1; i--)
        {
            int count = 0;
            for (int j = 0; j < line; j++)
            {
                if (blueBall[line - j] == blueBall[i - j] || Math.Abs(blueBall[i - j] - blueBall[line - j]) == 1)
                    count++;
            }
            alCount.Add(count);
            al.Add(i.ToString() + "_" + count.ToString() + "_" + arrRound[i].ToString());
        }

        alCount.Sort();
        int max = int.Parse(alCount[alCount.Count - 1].ToString());

        for (int i = 0; i < al.Count; i++)
        {
            int now = int.Parse(al[i].ToString().Split('_')[1]);
            if (now == max)
            {
                alOneCount.Add(al[i].ToString().Split('_')[0]);
                MyGoal.InnerHtml += NewNumber.DisplayStr(al[i].ToString() + " || ", "red",_Print);
            }
        }
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

        string color = "";
        int select = 0;
        for (int i = arrRound.Count - 1; i > 0; i--)
        {
            if (alOneCount.Contains(i.ToString()))
            {
                color = "red";
                select = i;
            }
            else
            {
                if (select != 0 && select - i < line)
                    color = "red";
                else
                    color = "yellow";

            }
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", color, _Print);
            for (int j = 0; j < 16; j++)
            {
                if (color == "red")
                {
                    if (blueBall[i] == j + 1 && blueBall[line - (select - i)] == j + 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", "red", _Print);
                    else if (blueBall[i] == j + 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", "blue", _Print);
                    else if (blueBall[line - (select - i)] == j + 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr("00  ", "red", _Print);
                    else
                        MyGoal.InnerHtml += NewNumber.DisplayStr("00  ", "yellow", _Print);
                }
                else
                {
                    if (blueBall[i] == j + 1)
                        MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + "  ", "black", _Print);
                    else
                        MyGoal.InnerHtml += NewNumber.DisplayStr("00  ", "yellow", _Print);
                }
            }
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
    }
    

    private void GraphFind(int[,] redBall, ArrayList arrRound)
    {
        int inputLength = 5;
        int maxNo = 2;
        int[,] input = new int[,]{{1,0,0,1,0},
                                  {0,0,0,0,0},
                                  {1,0,0,0,0},
                                  {0,0,1,0,1},
                                  {0,1,0,0,1}};
        //int[,] input = new int[,]{{0,1,0,1,0},
        //                          {1,0,1,1,0},
        //                          {0,1,0,0,0},
        //                          {0,1,0,0,1},
        //                          {0,0,1,0,0}};
        ArrayList al = new ArrayList();
        string strFind = "";
        
        for (int i = arrRound.Count - 1; i >= 4; i--)
        {
            for (int j = 0; j < 33 - inputLength; j++)
            {
                if (j == 24 && arrRound[i].ToString() == "2015077")
                {
                }
                int[] find = new int[4];
                if (FindOneGraph(redBall, input, find, i, j, maxNo))
                {
                    al.Add(find);
                    strFind += "_" + find[1].ToString() + "_" + (find[1] + 1).ToString() + "_" + (find[1] + 2).ToString() + "_" + (find[1] + 3).ToString() + "_" + (find[1] + 4).ToString() + "_|" + (find[1] - 1).ToString() + "|";
                }
            }
        }
        DisplayGraph(redBall, arrRound, al, input, strFind);
    }

    private void DisplayGraph(int[,] redBall, ArrayList arrRound, ArrayList al, int[,] input, string strFind)
    {

        for (int i = arrRound.Count - 1; i > 0; i--)
        {
            string color = "black";
            bool findLine = false;

            //if (strFind.Contains("_" + i.ToString() + "_") || strFind.Contains("|" + i.ToString() + "|"))
            //    findLine = true;

            if (strFind.Contains("_" + i.ToString() + "_"))
            {
                findLine = true;
                color = "brown";
            }

            if (strFind.Contains("|" + i.ToString() + "|"))
                MyGoal.InnerHtml += NewNumber.DisplayOverLineStr(arrRound[i].ToString() + " || ", color, _Print);
            else if (findLine)
                MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", color, _Print);
            for (int j = 0; j < 33; j++)
            {
                if (redBall[j, i] == 0)
                {
                    if (strFind.Contains("_" + i.ToString() + "_"))
                        color = "yellow";
                    else
                        color = "black";
                    for (int x = 0; x < al.Count; x++)
                    {
                        int[] find = (int[])al[x];
                        if (j >= find[0] && i >= find[1] && j <= find[2] && i <= find[3])
                        {
                            if (input[find[3] - i, j - find[0]] == 1)
                                color = "blue";
                            break;
                        }
                    }
                    if (strFind.Contains("|" + i.ToString() + "|"))
                        MyGoal.InnerHtml += NewNumber.DisplayOverLineStr("00" + " ", color, _Print);
                    else if (findLine)
                        MyGoal.InnerHtml += NewNumber.DisplayStr("00" + " ", color, _Print);
                }
                else
                {
                    //if (strFind.Contains("_" + i.ToString() + "_"))
                        color = "red";
                    //else
                    //    color = "brown";
                    for (int x = 0; x < al.Count; x++ )
                    {
                        int[] find = (int[])al[x];
                        if (j >= find[0] && i >= find[1] && j <= find[2] && i <= find[3])
                        {
                            if(input[find[3] - i, j - find[0]] == 1)
                                color = "blue"; 
                            else
                                color = "green";
                            break;
                        }
                    }
                    if (strFind.Contains("|" + i.ToString() + "|"))
                        MyGoal.InnerHtml += NewNumber.DisplayOverLineStr((j + 1).ToString("00") + " ", color, _Print);
                    else if(findLine)
                        MyGoal.InnerHtml += NewNumber.DisplayStr((j + 1).ToString("00") + " ", color, _Print);
                }
            }
            if (findLine || strFind.Contains("|" + i.ToString() + "|"))
                MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

        }
    }
    private bool FindOneGraph(int[,] redBall, int[,] input, int[] find, int i, int j, int maxNo)
    {
        bool ok = false;
        int noCount = 0;

        for (int x = 0; x < 5; x++)
            for (int y = 0; y < 5; y++)
            {
                if (input[x, y] == 1 && redBall[j + y, i - x] == 0)
                {
                    noCount++;
                }                     
            }
        if (noCount <= maxNo)
        {
            ok = true;
            find[0] = j;
            find[1] = i - 4;
            find[2] = j + 4;
            find[3] = i;
        }
        return ok;
    }
    #endregion

    #region GM(1,1)
    private void GMOneOne(int a, int b, int d, double[] input)
    {
  
        MyGoal.InnerHtml += NewNumber.DisplayStr("rnnny请输入预测模型的维数，即N= " + a.ToString(), "green",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("rnnny请输入预测模型的维数，即N= ：");
        //int.Parse(Console.ReadLine());

        MyGoal.InnerHtml += NewNumber.DisplayStr("请输入每一维的元素个数：" + b.ToString(), "green",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("请输入每一维的元素个数：");
        //int.Parse(Console.ReadLine());

        double[,] MatrixX = new double[a, b];
        double[,] MatrixY = new double[b - 1, 1];
        //Console.WriteLine("请依次输入每一维的各元素：");
        MyGoal.InnerHtml += NewNumber.DisplayStr("请依次输入每一维的各元素：", "red", _Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                MatrixX[i, j] = input[j];
            }
        }

        for (int i = 0; i < b - 1; i++)
        {
            MatrixY[i, 0] = MatrixX[0, i + 1];
        }
        //Console.WriteLine("矩阵Y为：");
        MyGoal.InnerHtml += NewNumber.DisplayStr("矩阵Y为：", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        outputMatrix(MatrixY, b - 1, 1);
        for (int i = 0; i < a; i++)
        {
            for (int j = 1; j < b; j++)
            {

                MatrixX[i, j] = MatrixX[i, j - 1] + MatrixX[i, j];

            }
        }
        //Console.WriteLine("矩阵X为：");
        MyGoal.InnerHtml += NewNumber.DisplayStr("矩阵X为：", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        outputMatrix(MatrixX, a, b);
        if (a == 1)
            a = a + 1;
        double[,] MatrixB = new double[b - 1, a];

        if (a == 2)
        {

            for (int i = 0; i < b - 1; i++)
            {

                MatrixB[i, 0] = -0.5 * (MatrixX[0, i] + MatrixX[0, i + 1]);

                MatrixB[i, 1] = 1;

            }
        }
        else
        {
            for (int i = 0; i < b - 1; i++)
            {

                MatrixB[i, 0] = -0.5 * (MatrixX[0, i] + MatrixX[0, i + 1]);
                for (int j = 1; j < a; j++)
                {
                    MatrixB[i, j] = MatrixX[j, i + 1];
                }
            }
        }
        //double[,] MatrixB = new double[b - 1, a];
        MyGoal.InnerHtml += NewNumber.DisplayStr("矩阵B为：", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("矩阵B为：");
        outputMatrix(MatrixB, b - 1, a);
        double[,] MatrixBT = new double[a, b - 1];
        for (int i = 0; i < b - 1; i++)
        {
            for (int j = 0; j < a; j++)
                MatrixBT[j, i] = MatrixB[i, j];
        }

        MyGoal.InnerHtml += NewNumber.DisplayStr("矩阵B的转置矩阵BT为:", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("矩阵B的转置矩阵BT为:");
        outputMatrix(MatrixBT, a, b - 1);
        double[,] MatrixBTB = new double[a, a];
        for (int i = 0; i < a; i++)
        {
            for (int k = 0; k < a; k++)
            {
                for (int j = 0; j < b - 1; j++)
                    MatrixBTB[i, k] += MatrixBT[i, j] * MatrixB[j, k];
            }
        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("矩阵BT与B的乘积BTB为:", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("矩阵BT与B的乘积BTB为:");
        outputMatrix(MatrixBTB, a, a);
        double[,] MatrixBTY = new double[a, 1];
        for (int i = 0; i < a; i++)
        {


            for (int j = 0; j < b - 1; j++)
                MatrixBTY[i, 0] += MatrixBT[i, j] * MatrixY[j, 0];

        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("矩阵BT与Y的乘积BTY为:", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("矩阵BT与Y的乘积BTY为:");
        outputMatrix(MatrixBTY, a, 1);
        double N = 0; int p = 0;
        for (int k = 0; k < a; k++)
        {
            double M = 0;
            for (int i = k; i < a; i++)
            {
                if (Math.Abs(MatrixBTB[i, k]) > M)
                {
                    M = Math.Abs(MatrixBTB[i, k]);
                    p = i;
                }
            }

            for (int i = k; i < a; i++)
            {
                N = MatrixBTB[p, i];
                MatrixBTB[p, i] = MatrixBTB[k, i];
                MatrixBTB[k, i] = N;
            }

            {
                N = MatrixBTY[p, 0];
                MatrixBTY[p, 0] = MatrixBTY[k, 0];
                MatrixBTY[k, 0] = N;
            }
            for (int i = k + 1; i < a; i++)
            {
                N = MatrixBTB[i, k] / MatrixBTB[k, k];
                for (int j = k; j < a; j++)
                {
                    MatrixBTB[i, j] = MatrixBTB[i, j] - N * MatrixBTB[k, j];
                }

                MatrixBTY[i, 0] = MatrixBTY[i, 0] - N * MatrixBTY[k, 0];
            }
        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("变换后的矩阵BTB为:", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("变换后的矩阵BTB为:");
        outputMatrix(MatrixBTB, a, a);
        MyGoal.InnerHtml += NewNumber.DisplayStr("变换后的矩阵BTY为:", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("变换后的矩阵BTY为:");
        outputMatrix(MatrixBTY, a, 1);

        //if (MatrixBTB[a - 1, a - 1] == 0)
        //Console.WriteLine("计算停止！");
        //else
        MatrixBTY[a - 1, 0] = MatrixBTY[a - 1, 0] / MatrixBTB[a - 1, a - 1];

        for (int i = a - 2; i >= 0; i--)
        {
            N = 0;
            for (int j = i + 1; j < a; j++)
            {
                N += MatrixBTB[i, j] * MatrixBTY[j, 0];
            }
            MatrixBTY[i, 0] = (MatrixBTY[i, 0] - N) / MatrixBTB[i, i];

        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("所求的参数矩阵为:", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("所求的参数矩阵为:");
        outputMatrix(MatrixBTY, a, 1);

        double c = 0;
        


        //Console.WriteLine("请输入要预测的时间段:");
        //int.Parse(Console.ReadLine());
        double[,] MatrixA = new double[b, 2];
        double[,] MatrixYUCE = new double[d, 1];
        for (int i = 0; i < b; i++)
        {
            double M = 0;
            for (int j = 1; j < a; j++)
            {
                if (a == 2)
                    M = MatrixBTY[j, 0];
                else
                    M = M + MatrixBTY[j, 0] * MatrixX[j, i];
            }
            c = MatrixBTY[0, 0];

            //MatrixA[0, 0] = MatrixX[0, 0];
            MatrixA[i, 0] = (MatrixX[0, 0] - M / c) * Math.Exp(-c * i) + M / c;
            //MatrixA[i, 0] = MatrixA[i, 0] - MatrixA[i-1, 0];

            //for (int j = 0; j < b ; j++)
            //{

            //MatrixYUCE[j, 0] = (MatrixX[0, 0] - M / c) * Math.Exp(-c * j) + M / c;
            //}
            for (int k = 0; k < d; k++)
            {
                MatrixYUCE[k, 0] = (MatrixX[0, 0] - M / c) * Math.Exp(-c * (k + b)) + M / c;
            }
        }
        MyGoal.InnerHtml += NewNumber.DisplayStr("请输入要预测的时间段:" + d.ToString() + "|C的值为：" + c.ToString(), "green",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);

        for (int i = d - 1; i > 0; i--)
        {
            MatrixYUCE[i, 0] = MatrixYUCE[i, 0] - MatrixYUCE[i - 1, 0];
        }
        MatrixYUCE[0, 0] = MatrixYUCE[0, 0] - MatrixA[b - 1, 0];
        for (int i = b - 1; i > 0; i--)
        {
            MatrixA[i, 0] = MatrixA[i, 0] - MatrixA[i - 1, 0];
        }


        for (int i = 1; i < b; i++)
        {
            MatrixA[i, 1] = (MatrixA[i, 0] - MatrixY[i - 1, 0]) / MatrixY[i - 1, 0];
        }

        MyGoal.InnerHtml += NewNumber.DisplayStr("所求的拟合数据及其相对误差为:", "red",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("所求的拟合数据及其相对误差为:");
        outputMatrix(MatrixA, b, 2);

        MyGoal.InnerHtml += NewNumber.DisplayStr("所求的预测数据为:", "blue",_Print);
        MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        //Console.WriteLine("所求的预测数据为:");
        outputMatrix(MatrixYUCE, d, 1);
        for (int i = 0; i < d; i++)
        {
            //Console.WriteLine((i + 1).ToString() + MatrixYUCE[i, 0]);
            MyGoal.InnerHtml += NewNumber.DisplayStr((i + 1).ToString()+":" + MatrixYUCE[i, 0].ToString(), "blue",_Print);
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }
        //System.IO.StreamWriter Yuce = new System.IO.StreamWriter(@"d:\预测数据.txt");
        //for (int i = 0; i < d; i++)
        //{
        //    Yuce.WriteLine("{0}:  {1}", i + 1, MatrixYUCE[i, 0]);
        //}
        //Yuce.Close();
        //Yuce.Dispose();
    }
    private void outputMatrix(double[,] MatrixX, double rowCount, double columnCount)
    {
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                MyGoal.InnerHtml += NewNumber.DisplayStr(MatrixX[i, j].ToString() + " ", "red", _Print);
                //Console.Write(MatrixX[i, j] + "\t");
            }
            //Console.WriteLine();
            MyGoal.InnerHtml += NewNumber.DisplayBR(_Print);
        }

    }
    #endregion

    //#region Display
    //private string DisplayOverLineStr(string input, string color)
    //{
    //    if (_Print)
    //        return "<span style='text-decoration:overline;color:" + color + "'>" + input + "</span>";
    //    else
    //        return string.Empty;
    //}

    //private string DisplayStr(string input, string color)
    //{
    //    if (_Print)
    //        return "<span style='color:" + color + "'>" + input + "</span>";
    //    else
    //        return string.Empty;
    //}

    //private string DisplayStrWidthBold(string input, string color)
    //{
    //    if (_Print)
    //        return "<span style='display:-moz-inline-box; display:inline-block; width:20px;font-weight: bold;color:" + color + "'>" + input + "</span>";
    //    else
    //        return string.Empty;
    //}

    //private string DisplayStrWidth(string input, string color)
    //{
    //    if (_Print)
    //        return "<span style='display:-moz-inline-box; display:inline-block; width:20px;color:" + color + "'>" + input + "</span>";
    //    else
    //        return string.Empty;
    //}

    //private string DisplayStr(string input, string color, int number)
    //{
    //    if (_Print)
    //        return "<span title=" + number.ToString() + " style='cursor:pointer;color:" + color + "'>" + input + "</span>";
    //    else
    //        return string.Empty;

    //}

    //private string DisplayBR()
    //{
    //    if (_Print)
    //        return "<br><br>";
    //    else
    //        return string.Empty;
    //}
    //private string DisplayBROne()
    //{
    //    if (_Print)
    //        return "<br>";
    //    else
    //        return string.Empty;
    //}
    //#endregion

    #region Method
    /// <summary>
    /// 排列组合
    /// </summary>
    /// <param name="data"></param>
    private void Combination(bool data)
    {
        for (int i = 1; i <= 33; i++)
            for (int j = 1; j <= 6; j++)
            {
                if (j > i)
                    break;
                else
                {
                    OneCombination(i,j,data);
                }
            }
    }
    private double OneCombination(int i, int j, bool data)
    {
        double dd = 0;
        if (j > i || i == 0 || j == 0)
        { }
        else
        {            
            if (j == 6)
            {
                dd = MyTest.CC(i, j);
            }
            else if (i == j)
            {
                dd = MyTest.CC(33 - i, 6 - j);
            }
            else if (33 - i == 6 - j)
            {
                dd = MyTest.CC(i, j);
            }
            else if (33 - i > 6 - j)
            {
                dd = MyTest.CC(i, j) * MyTest.CC(33 - i, 6 - j);
            }
            else
            {
            }
            //double dd2 = Test.C(27, 5) * Test.C(6, 1);

            if (data)
            {
                DataRow newRow = _DT.NewRow();
                newRow["A0"] = i;
                newRow["A1"] = j;
                newRow["A2"] = dd;
                newRow["FLAG"] = 9999;
                _DT.Rows.Add(newRow);
            }
        }
        return dd;
    }
    #endregion

}