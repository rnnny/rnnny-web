using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Data;

public partial class _20150518_BigNumber : System.Web.UI.Page
{
    #region 变量
    private const int MaxMax = MyTest.MaxMax;
    private ArrayList _ArrRound = new ArrayList();
    private ArrayList _ArrGoal = new ArrayList();
    //private const int MaxCount = 5;
    private DataTable _DT = new DataTable();
    private int[] _OneBall = new int[MaxMax];
    private int[] _TwoBall = new int[MaxMax];//6个红ball和值
    private int[,] _RedBall = new int[35, MaxMax];
    private int[,] _MiniRedBall = new int[5, MaxMax];
    private bool _Data = false;
    //private bool _Print = false;
    private int GameOver = 1;
    private hangzhou _HangZhou = new hangzhou();
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        _DT = CreateTable();

        GameOver = 1;//模拟结果为1，计算结果为2，

        int maxCount = 10000;
        MyTest.ReadFile(_ArrRound,_ArrGoal, _RedBall, _MiniRedBall, _OneBall, _TwoBall, maxCount, "big");

        if (GameOver == 2)
        {
            //_HangZhou.Data = 121;
            //_HangZhou.Data1 = 0;
            //_HangZhou.Data2 = 4;//down
            //_HangZhou.Data3 = 15;
            //_HangZhou.Data33 = "";
            
            //_HangZhou.Two = -1;
            //_HangZhou.Prime = 1;
            //_HangZhou.NearRepeat = 3;

            //_HangZhou.Mini0 = 5;//up
            //_HangZhou.Mini1 = 5;//down
            //_HangZhou.Mini2 = 35;//up
            //_HangZhou.Mini3 = 23;//up
            //_HangZhou.Mini4 = 20;//up
            //_HangZhou.Mini5 = -1;//up

            int a1 = _MiniRedBall[0, 1];
            int a2 = _MiniRedBall[1, 1];
            int a3 = _MiniRedBall[2, 1];
            int a4 = _MiniRedBall[3, 1];
            int a5 = _MiniRedBall[4, 1];

            int a21 = _MiniRedBall[0, 2];
            int a22 = _MiniRedBall[1, 2];
            int a23 = _MiniRedBall[2, 2];
            int a24 = _MiniRedBall[3, 2];
            int a25 = _MiniRedBall[4, 2];
            //int a6 = _TwoBall[1];

            int sum  = 0;//= a1 + a2 + a3 + a4 + a5;
            int upup = 0;
            for (int j = 0; j < 5; j++)
            {
                sum += _MiniRedBall[j, 1];
                upup += MyTest.FindUpNumber(1, _MiniRedBall[j, 1] - 1, _ArrRound.Count - 1, _RedBall);

            }

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

            //_Print = true;

            int isPrime = MyTest.ISPrime(a1) + MyTest.ISPrime(a2) + MyTest.ISPrime(a3) + MyTest.ISPrime(a4) + MyTest.ISPrime(a5);
            int isTwo = MyTest.ISTwo(a1) + MyTest.ISTwo(a2) + MyTest.ISTwo(a3) + MyTest.ISTwo(a4) + MyTest.ISTwo(a5);
            int isNearRepeat = MyTest.ISNearRepeat(_RedBall, a1, GameOver) + MyTest.ISNearRepeat(_RedBall, a2, GameOver) + MyTest.ISNearRepeat(_RedBall, a3, GameOver) + MyTest.ISNearRepeat(_RedBall, a4, GameOver) + MyTest.ISNearRepeat(_RedBall, a5, GameOver);


            MyGoal.InnerHtml += NewNumber.DisplayStr("00--" + _ArrRound[1].ToString() + " --#" + sum.ToString() + "_" + _HangZhou.Sum + "|" + (a5 - a1).ToString() + "_" + _HangZhou.LeftRight + "|" + _OneBall[1].ToString() + "_" + _HangZhou.BlueBall + "_" + _OneBall[2].ToString() + "|" + upup.ToString() + "_" + _HangZhou.UpUp + "|" + count.ToString() + "|" + a1.ToString() + "_" + _HangZhou.Mini0 + "_" + a21.ToString() + "|" + a2.ToString() + "_" + _HangZhou.Mini1 + "_" + a22.ToString() + "|" + a3.ToString() + "_" + _HangZhou.Mini2 + "_" + a23.ToString() + "|" + a4.ToString() + "_" + _HangZhou.Mini3 + "_" + a24.ToString() + "|" + a5.ToString() + "_" + _HangZhou.Mini4 + "_" + a25.ToString() + "|" + _TwoBall[1].ToString() + "_" + _HangZhou.Mini5 + "_" + _TwoBall[2].ToString() + "|" + isTwo.ToString() + "_" + _HangZhou.Two + "|" + isPrime.ToString() + "_" + _HangZhou.Prime + "|" + isNearRepeat.ToString() + "_" + _HangZhou.NearRepeat, "green");
  
        }

        if (GameOver == 1)
        {
            //_DT = CreateTable();

            string dataBase = "";

            //string dataBase = "Test";

            //int maxCount = 1000;
            //string dataBase = "TestNew";


            //_Data = true;
            //Combination(_Data);

            #region ForSpssModeler
            dataBase = "TestNew";
            _Data = false;
            //_Print = true;
            CreateSpssModelerData(_ArrRound, _MiniRedBall, _RedBall, _OneBall, _TwoBall);
            #endregion

            #region TwoNearRepeat
            //777788
            dataBase = "TestNew";
            _Data = true;
            //_Print = true;
            TwoNearRepeat(_ArrRound, _MiniRedBall, _RedBall);
            #endregion


            if (_Data)
            {
                System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source = .; Initial Catalog = " + dataBase + "; User Id = sa; Password = suyu57501;");
                bcp.DestinationTableName = "dbo.TestOutput";
                bcp.WriteToServer(_DT);
            }
        }
    }

    #region ForSpssModeler

    private void CreateSpssModelerData(ArrayList arrRound, int[,] miniRedBall, int[,] redBall, int[] oneBall, int[] twoBall)
    {
        int[] sum = new int[arrRound.Count];
        int[] leftRight = new int[arrRound.Count];
        int[] upup = new int[arrRound.Count];
        int[] mini0 = new int[arrRound.Count];
        int[] mini1 = new int[arrRound.Count];
        int[] mini2 = new int[arrRound.Count];
        int[] mini3 = new int[arrRound.Count];
        int[] mini4 = new int[arrRound.Count];
        int[] mini5 = new int[arrRound.Count];
        int[] two = new int[arrRound.Count];
        int[] prime = new int[arrRound.Count];
        int[] nearRepeat = new int[arrRound.Count];

        for (int i = 1; i < arrRound.Count; i++)
        {
            MyGoal.InnerHtml += NewNumber.DisplayStr(arrRound[i].ToString() + " || ", "brown");
            for (int j = 0; j < 5; j++)
            {
                sum[i] += miniRedBall[j, i];
                MyGoal.InnerHtml += NewNumber.DisplayStr(miniRedBall[j, i].ToString("00") + " ", "red");
                upup[i] += MyTest.FindUpNumber(i, miniRedBall[j, i] - 1, arrRound.Count - 1, redBall);
                two[i] += MyTest.ISTwo(miniRedBall[j, i]);
                prime[i] += MyTest.ISPrime(miniRedBall[j, i]);
                nearRepeat[i] += MyTest.ISNearRepeat(redBall, miniRedBall[j, i], i + 1);

            }
            leftRight[i] = miniRedBall[4, i] - miniRedBall[0, i];
            MyGoal.InnerHtml += NewNumber.DisplayStr("--" + sum[i] + " || " + leftRight[i], "blue");
            MyGoal.InnerHtml += NewNumber.DisplayBR();

            mini0[i] = miniRedBall[0, i];
            mini1[i] = miniRedBall[1, i];
            mini2[i] = miniRedBall[2, i];
            mini3[i] = miniRedBall[3, i];
            mini4[i] = miniRedBall[4, i];
            mini5[i] = twoBall[i];

        }

        int select = 40;

        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        FileStream fs = new FileStream(strPath + "\\spss\\data33\\33.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        for (int i = 0; i < 35; i++)
        {
            int j = 0;
            string str = "";
            while (j <= arrRound.Count - 1)
            {
                int ii = MyTest.FindUpNumber(j, i, arrRound.Count - 1, redBall);
                j += ii + 1;
                str += ii.ToString() + " ";
            }
            if (i % 2 == 0)
                SpssToFile((i + 1).ToString(), select, str.Substring(0, str.Length - 1), "blue", sw);
            else
                SpssToFile((i + 1).ToString(), select, str.Substring(0, str.Length - 1), "green", sw);
        }

        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();

        select = 20;


        DisplaySpss(arrRound, select, mini0, "mini\\miniNew0.txt");
        DisplaySpss(arrRound, select, mini1, "mini\\miniNew1.txt");
        DisplaySpss(arrRound, select, mini2, "mini\\miniNew2.txt");
        DisplaySpss(arrRound, select, mini3, "mini\\miniNEw3.txt");
        DisplaySpss(arrRound, select, mini4, "mini\\miniNew4.txt");
        DisplaySpss(arrRound, select, mini5, "mini\\miniNew5.txt");
        DisplaySpss(arrRound, select, sum, "data0123\\dataNew.txt");
        DisplaySpss(arrRound, select, leftRight, "data0123\\dataNew1.txt");
        DisplaySpss(arrRound, select, oneBall, "data0123\\dataNew2.txt");
        DisplaySpss(arrRound, select, upup, "data0123\\dataNew3.txt");
        DisplaySpss(arrRound, select, two, "data0123\\two.txt");
        DisplaySpss(arrRound, select, prime, "data0123\\prime.txt");
        DisplaySpss(arrRound, select, nearRepeat, "data0123\\nearRepeat.txt");

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
                    if (i == 0)
                        MyGoal.InnerHtml += NewNumber.DisplayStr(now + " ", color);
                    else
                        strFile += now + " ";
                }
                if (i == 0)
                    MyGoal.InnerHtml += NewNumber.DisplayStr(sumAll + " ", color);
                else
                    strFile += sumAll + " ";
            }
            if (i == 0)
                MyGoal.InnerHtml += NewNumber.DisplayBROne();
            else
                //开始写入
                sw.WriteLine(strFile);
        }

    }

    private void DisplaySpss(ArrayList arrRound, int select, int[] input, string file)
    {
        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        FileStream fs = new FileStream(strPath + "\\spss\\" + file, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        for (int i = 0; i < arrRound.Count - select; i++)
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
                    strFile += sumAll / 10 + " ";
                //MyGoal.InnerHtml += DisplayStr(sumAll / 10 + " ", color);
                strFile += sumAll + " ";
                //MyGoal.InnerHtml += DisplayStr(sumAll + " ", color);
            }
            //开始写入
            sw.WriteLine(strFile);
            //MyGoal.InnerHtml += DisplayBROne();
        }


        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();

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

    #region TwoNearRepeat
    private void TwoNearRepeat(ArrayList arrRound, int[,] miniRedBall, int[,] redBall)
    {
        MyGoal.InnerHtml = NewNumber.TwoNearRepeat(arrRound, miniRedBall, redBall, ref _DT);

    }
    #endregion

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

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string str = txtInput.Text.Trim();

       // str = "1 2 3 4 5";


        MyGoal.InnerHtml = MyTest.HandInput(str, _ArrRound, _MiniRedBall, _RedBall, _HangZhou);

    }
}