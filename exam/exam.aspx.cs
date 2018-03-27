using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Data;
using SplashCheck;
using FZX.App.WebEngine;
using System.Data.SqlClient;


public partial class exam_exam : System.Web.UI.Page
{
    #region 变量
    private const int MaxMax = MyTest.MaxMax;
    private ArrayList _ArrRound = new ArrayList();
    private ArrayList _ArrGoal = new ArrayList();
    private int[] _BlueBall = new int[MaxMax];
    private int[] _SixSum = new int[MaxMax];//6个红ball和值
    private int[,] _RedBall = new int[33, MaxMax];
    private int[,] _MiniRedBall = new int[6, MaxMax];
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        int maxCount = 10000;
        //string dataBase = "Test";

        MyTest.ReadFile(_ArrRound, _ArrGoal, _RedBall, _MiniRedBall, _BlueBall, _SixSum, maxCount, "ball");

       

        List<Exam_Mod> exModList = Exam_Analyze(_RedBall, _MiniRedBall, _ArrRound);
        using (SqlConnection conn = new SqlConnection("server=.;uid='sa';password='suyu57501';database='TestNew';enlist=true"))
        {
            conn.BulkCopy(exModList, 20000, "EXAM");
        }
    }

    #region Exam_Analyze
    private List<Exam_Mod> Exam_Analyze(int[,] redBall, int[,] miniRedBall, ArrayList arrRound)
    {
        //sum two prime near repeat
        //平均命中率
        //NormalDistribution nn = new NormalDistribution();
        int[] countSum30 = new int[20];
        List<Exam_Mod> exModList = new List<Exam_Mod>();
        for (int i = arrRound.Count - 2; i >= 1; i--)
        {
            Exam_Mod exMod = new Exam_Mod();
            
            exMod.Round = arrRound[i].ToString();
            int sum = miniRedBall[0, i] + miniRedBall[1, i] + miniRedBall[2, i] + miniRedBall[3, i] + miniRedBall[4, i] + miniRedBall[5, i];
            int isPrime = MyTest.ISPrime(miniRedBall[0, i]) + MyTest.ISPrime(miniRedBall[1, i]) + MyTest.ISPrime(miniRedBall[2, i]) + MyTest.ISPrime(miniRedBall[3, i]) + MyTest.ISPrime(miniRedBall[4, i]) + MyTest.ISPrime(miniRedBall[5, i]);
            int isTwo = MyTest.ISTwo(miniRedBall[0, i]) + MyTest.ISTwo(miniRedBall[1, i]) + MyTest.ISTwo(miniRedBall[2, i]) + MyTest.ISTwo(miniRedBall[3, i]) + MyTest.ISTwo(miniRedBall[4, i]) + MyTest.ISTwo(miniRedBall[5, i]);
            int near = MyTest.ISNear(redBall, miniRedBall[0, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[1, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[2, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[3, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[4, i], i + 1) + MyTest.ISNear(redBall, miniRedBall[5, i], i + 1);
            int repeat = MyTest.ISRepeat(redBall, miniRedBall[0, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[1, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[2, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[3, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[4, i], i + 1) + MyTest.ISRepeat(redBall, miniRedBall[5, i], i + 1);
            exMod.A0 = sum;
            exMod.A1 = repeat;
            exMod.A2 = near;
            exMod.A3 = near + repeat;
            exMod.A4 = isPrime;
            exMod.A5 = isTwo;
            exMod.A6 = miniRedBall[5, i] - miniRedBall[0, i];
            exMod.A7 = MyTest.FindUpNumber(i, miniRedBall[0, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[1, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[2, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[3, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[4, i] - 1, arrRound.Count - 1, redBall) + MyTest.FindUpNumber(i, miniRedBall[5, i] - 1, arrRound.Count - 1, redBall);
            exMod.A8 = near + repeat + isPrime + isTwo;
            exMod.B12 = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
            exMod.B13 = repeat + "|" + near + "|" + isPrime + "|" + isTwo;

            string hope = MyTest.Belong(miniRedBall, i, 1);

            exMod.B14 = hope.Split('_')[0];
            exMod.B15 = hope.Split('_')[1];

            hope = MyTest.Belong(miniRedBall, i, 2);

            exMod.B16 = hope.Split('_')[0];
            exMod.B17 = hope.Split('_')[1];

            hope = MyTest.Belong(miniRedBall, i, 3);

            exMod.B18 = hope.Split('_')[0];
            exMod.B19 = hope.Split('_')[1];
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


                    //newRow["a2" + x.ToString()] = miniSum30[x];
                    countSum30[miniSum30[x]]++;
                }

                string strC = "";
                for (int x = 0; x < 6; x++)
                {
                    if (miniSum30[x] >= 9)
                        exMod.B26 = "A" + exMod.B26;
                    else if (miniSum30[x] >= 3)
                        exMod.B26 += "B";
                    else
                        strC += "C";
                }
                exMod.B26 += strC;
            }
            exMod.B27 = NewNumber.GetTwoNearRepeatRound(redBall, miniRedBall[0, i], miniRedBall[1, i], miniRedBall[2, i], miniRedBall[3, i], miniRedBall[4, i], miniRedBall[5, i], i);

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
            exMod.B28 = strSubSub;

            ArrayList al = new ArrayList();
            al.Add(MyTest.FindUpNumber(i, miniRedBall[0, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[1, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[2, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[3, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[4, i] - 1, arrRound.Count - 1, redBall));
            al.Add(MyTest.FindUpNumber(i, miniRedBall[5, i] - 1, arrRound.Count - 1, redBall));
            exMod.B29 = al[0].ToString() + "|" + al[1].ToString() + "|" + al[2].ToString() + "|" + al[3].ToString() + "|" + al[4].ToString() + "|" + al[5].ToString();
            al.Sort();

            exMod.A9 = sum30;
            exMod.A10 = int.Parse(al[0].ToString());
            exMod.A11 = int.Parse(al[5].ToString());
            //for (int j = 0; j < al.Count; j++)
            //{
            //    newRow["a12"] += int.Parse(al[j].ToString()).ToString("00") + " ";
            //}
            exMod.Flag = Define._AnalyzeFlag;//999999

            //Exam_Bll.InsertExamMod(exMod);
            exModList.Add(exMod);

            //_DT.Rows.Add(newRow);

            //newRow = _DT.NewRow();
            //newRow["round"] = arrRound[i].ToString();
            
            //int[] lastNum = new int[10];
            //int oneNumSum = 0;
            //int lastNumSum = 0;
            //int mathSum = 0;
            //string strOne = "";
            //int max = miniRedBall[0, i];
            //int maxBegin = 0;
            //int maxEnd = miniRedBall[0, i];
            //if (miniRedBall[1, i] - miniRedBall[0, i] > max)
            //{
            //    max = miniRedBall[1, i] - miniRedBall[0, i];
            //    maxBegin = miniRedBall[0, i];
            //    maxEnd = miniRedBall[1, i];
            //}
            //if (miniRedBall[2, i] - miniRedBall[1, i] > max)
            //{
            //    max = miniRedBall[2, i] - miniRedBall[1, i];
            //    maxBegin = miniRedBall[1, i];
            //    maxEnd = miniRedBall[2, i];
            //}
            //if (miniRedBall[3, i] - miniRedBall[2, i] > max)
            //{
            //    max = miniRedBall[3, i] - miniRedBall[2, i];
            //    maxBegin = miniRedBall[2, i];
            //    maxEnd = miniRedBall[3, i];
            //}
            //if (miniRedBall[4, i] - miniRedBall[3, i] > max)
            //{
            //    max = miniRedBall[4, i] - miniRedBall[3, i];
            //    maxBegin = miniRedBall[3, i];
            //    maxEnd = miniRedBall[4, i];
            //}
            //if (miniRedBall[5, i] - miniRedBall[4, i] > max)
            //{
            //    max = miniRedBall[5, i] - miniRedBall[4, i];
            //    maxBegin = miniRedBall[4, i];
            //    maxEnd = miniRedBall[5, i];
            //}
            //if (34 - miniRedBall[5, i] > max)
            //{
            //    max = 34 - miniRedBall[5, i];
            //    maxBegin = miniRedBall[5, i];
            //    maxEnd = 34;
            //}
            //newRow["a12"] = max.ToString("00");
            //newRow["a13"] = maxBegin;
            //newRow["a14"] = maxEnd;
            //newRow["a15"] = miniRedBall[0, i];
            //newRow["a16"] = miniRedBall[5, i];

            //List<double> dd = new List<double>();
            //dd.Add(Convert.ToDouble(miniRedBall[0, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[1, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[2, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[3, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[4, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[5, i]));
            //double ddd = nn.stdev(dd);
            //double aaa = nn.average(dd);
            //newRow["a20"] = ddd.ToString("0.0");
            //newRow["a21"] = aaa.ToString("0.0");
            //dd = new List<double>();
            //dd.Add(Convert.ToDouble(miniRedBall[0, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[1, i] - miniRedBall[0, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[2, i] - miniRedBall[1, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[3, i] - miniRedBall[2, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[4, i] - miniRedBall[3, i]));
            //dd.Add(Convert.ToDouble(miniRedBall[5, i] - miniRedBall[4, i]));
            //dd.Add(Convert.ToDouble(33 - miniRedBall[5, i])); 
            //ddd = nn.stdev(dd);
            //aaa = nn.average(dd);
            //newRow["a22"] = ddd.ToString("0.0");
            
            //al = new ArrayList();
            //al.Add(miniRedBall[0, i]);
            //al.Add(miniRedBall[1, i] - miniRedBall[0, i]);
            //al.Add(miniRedBall[2, i] - miniRedBall[1, i]);
            //al.Add(miniRedBall[3, i] - miniRedBall[2, i]);
            //al.Add(miniRedBall[4, i] - miniRedBall[3, i]);
            //al.Add(miniRedBall[5, i] - miniRedBall[4, i]);
            //al.Add(33-miniRedBall[5, i]);
            //for (int x = 0; x < al.Count; x++)
            //{
            //    newRow["a17"] += al[x].ToString() + "|";
            //}
            //al.Sort();
            //for (int x = 0; x < al.Count; x++)
            //{
            //    newRow["a18"] = al[x].ToString() + "|" + newRow["a18"];
            //}
            //for (int x = 0; x < 6; x++)
            //{
            //    mathSum += Math.Abs(miniRedBall[x, i] - miniRedBall[x, i + 1]);
            //    newRow["a" + x.ToString()] = Math.Abs(miniRedBall[x, i] - miniRedBall[x, i + 1]);
            //    if (miniRedBall[x, i] < 10)
            //    {
            //        newRow["a23"] += miniRedBall[x, i].ToString("00") + "|";
            //        strOne += "0";
            //        lastNumSum += miniRedBall[x, i];
            //        //newRow["a2" + x.ToString()] = miniRedBall[x, i];
            //        lastNum[miniRedBall[x, i]]++;
            //    }
            //    else
            //    {
            //        if (miniRedBall[x, i] < 20)
            //        {
            //            newRow["a24"] += miniRedBall[x, i].ToString("00") + "|";
            //        }
            //        else if (miniRedBall[x, i] < 30)
            //        {
            //            newRow["a25"] += miniRedBall[x, i].ToString("00") + "|";
            //        }
            //        string begin = miniRedBall[x, i].ToString().Substring(0, 1);
            //        strOne += begin;
            //        oneNumSum += int.Parse(begin);
            //        string end = miniRedBall[x, i].ToString().Substring(1, 1);
            //        //newRow["a2" + x.ToString()] = end;
            //        lastNumSum += int.Parse(end);
            //        lastNum[int.Parse(end)]++;
            //    }
            //}
            
            //newRow["a6"] = mathSum;
            //newRow["a10"] = min30;
            //newRow["a11"] = max30;
            //newRow["a27"] = lastNumSum;
            //newRow["a28"] = strOne;
            //newRow["a29"] = oneNumSum;
            //newRow["a19"] = sum;
            //newRow["a30"] = miniRedBall[0, i] + "|" + miniRedBall[1, i] + "|" + miniRedBall[2, i] + "|" + miniRedBall[3, i] + "|" + miniRedBall[4, i] + "|" + miniRedBall[5, i];
           
            //for (int x = 0; x < 10; x++)
            //{
            //    if (lastNum[x] != 0)
            //        for (int y = 0; y < lastNum[x]; y++)
            //        {
            //            newRow["a26"] += x.ToString();
            //        }
            //}

            //newRow["FLAG"] = Define._AnalyzeTwoFlag;//99999900
            //_DT.Rows.Add(newRow);
        }
        return exModList;
    }
    #endregion

    /// <summary>
    /// 先选择3个。通过
    /// </summary>
    private void SelectOne()
    { }
}