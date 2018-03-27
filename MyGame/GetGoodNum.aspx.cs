using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class MyGame_GetGoodNum : System.Web.UI.Page
{
    #region 变量
    private const int MaxMax = 500;
    private const int MaxStatistics = 100;
    private const int MaxCount = 30;
    private ArrayList _ArrLine = new ArrayList();
    
    private int[,] _RedBall = new int[33, MaxMax];
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        ReadFile();
        DisplayMyGame(_RedBall, _ArrLine);
    }
    #endregion

    #region ReadFile
    private int ReadFile()
    {
        StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
        string line;
        int count = 0;
        while ((line = smRead.ReadLine()) != null )
        {
            if (!line.Contains("查看统计"))
            {
                int intGoal = int.Parse(line.Split(' ')[11]);
                if (true)//intGoal <= 2)
                {
                    string str = line.Substring(6, 17);
                    _ArrLine.Add(line.Substring(0, 5));

                    ArrayList arrLine = new ArrayList();
                    for (int k = 0; k < str.Split(' ').Length; k++)
                    {
                        arrLine.Add(str.Split(' ')[k]);
                    }

                    for (int i = 1; i <= 33; i++)
                    {
                        string a = i.ToString("00");

                        if (arrLine.Contains(a))
                        {
                            _RedBall[i - 1, count] = 1;
                        }
                        else
                        {
                            _RedBall[i - 1, count] = 0;
                        }
                    }
                    count++;
                }
            }
            
        }
        return count;
    }
    #endregion

    #region Display
    private void DisplayMyGame(int[,] redBall, ArrayList arrLine)
    {
        int[,] myBall = new int[33, MaxMax];
        //int nono = 0;
        for (int i = arrLine.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < 33; j++)
            {
                for (int x = 0; x < MaxCount; x++)
                {
                    if (i - x >= 0)
                        myBall[j, i] += redBall[j, i - x];                    
                }
            }
        }
        DisplayMyBall30(myBall, arrLine, arrLine.Count % MaxCount - 1);

        for (int j = 0; j < 33; j++)
            for (int x = 0; x < MaxCount; x++)
                myBall[j, 0] += redBall[j, x];
        DispalyMyBall(myBall, arrLine);
    }
    private void DisplayMyBall30(int[,] myBall, ArrayList arrLine, int input)
    {
        string color = "blue";
        int count = 0;
        int[,] countColor = new int[33, 4];
        int[] countByCount = new int[33];
        int countBy = 0;
        string[] str30 = new string[33];
        int[] int357 = new int[4];
        for (int i = arrLine.Count - 1; i >= 0; i--)
        {
            count++;
            if (i == arrLine.Count - 1 || count == 30 || i == input)
            {
                countBy++;
                MyGoal.InnerHtml += DisplayStr(arrLine[i].ToString() + " || ", "brown");
                for (int j = 0; j < 33; j++)
                {
                    int357[3] += myBall[j, i];
                    countColor[j, 3] += myBall[j, i];
                    countByCount[j] += myBall[j, i];

                    if (myBall[j, i] > 6)
                    {
                        color = "red";
                        countColor[j, 2]++;
                        str30[j] += "7";
                        int357[2]++;
                    }
                    else if (myBall[j, i] < 4)
                    {
                        color = "brown";
                        countColor[j, 0]++;
                        str30[j] += "3";
                        int357[0]++;
                    }
                    else
                    {
                        color = "blue";
                        countColor[j, 1]++;
                        str30[j] += "5";
                        int357[1]++;
                    }
                    
                    MyGoal.InnerHtml += DisplayStr(myBall[j, i].ToString("00") + " ", color, j + 1);

                    if (j == 10 || j == 21 || j == 32)
                    {
                        MyGoal.InnerHtml += DisplayStr("|| ", "yellow");
                    }

                }

                MyGoal.InnerHtml += DisplayBR();

                count = 0;

                if (countBy == 3)
                {
                    int sum = 0;
                    for (int j = 0; j < 33; j++)
                    {
                        sum += countByCount[j];
                    }
                    sum = sum / 33;

                    MyGoal.InnerHtml += DisplayStr("33333 || ", "red");

                    for (int j = 0; j < 33; j++)
                    {
                        if (countByCount[j] >= sum)
                            color = "green";
                        else if (countByCount[j] < sum)
                            color = "black";
                        
                        MyGoal.InnerHtml += DisplayStr(countByCount[j].ToString("00") + " ", color, j + 1);

                        if (j == 10 || j == 21 || j == 32)
                        {
                            MyGoal.InnerHtml += DisplayStr("|| ", "yellow");
                        }
                    }
                    countBy = 0;
                    countByCount = new int[33];
                    MyGoal.InnerHtml += sum.ToString() + DisplayBR();
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            int357[i] = int357[i] / 33;
        }
        for (int i = 0; i < 4; i++)
        {
            MyGoal.InnerHtml = DisplayBR() + MyGoal.InnerHtml;

            MyGoal.InnerHtml = DisplayStr(" " + int357[i].ToString(), "blue") + MyGoal.InnerHtml;

            for (int j = 32; j >= 0; j--)
            {
                if (j == 10 || j == 21 || j == 32)
                {
                    MyGoal.InnerHtml = DisplayStr("|| ", "yellow") + MyGoal.InnerHtml;
                }
                if (countColor[j, i] >= int357[i])
                    color = "green";
                else if (countColor[j, i] < int357[i])
                    color = "black";
                                
                MyGoal.InnerHtml = DisplayStr(countColor[j, i].ToString("00") + " ", color, j + 1) + MyGoal.InnerHtml;
            }
            MyGoal.InnerHtml = "0000" + i.ToString() + " || " + MyGoal.InnerHtml;

        }
    }
    private void DispalyMyBall(int[,] myBall, ArrayList arrLine)
    {
        string color = "yellow";
        
        int[] beginEngSum = new int[33];        
        int[] sumSixSum = new int[200]; 
        int[] stat = new int[8];
        int[] splitThree = new int[600];
        int[] nearThree = new int[600];
        int[] maxTwoHave = new int[7];
        //int[] fromTo = new int[33335];
        int[] fFindCount = new int[100];
        int[] fFindModel = new int[222223];
        for (int i = 0; i < arrLine.Count - MaxCount; i++)
        {
            int sumSix = 0;
            int beginEnd = 0;

            if(i == 0)
                MyGoal.InnerHtml += DisplayStr("00000 || ", "red");
            else 
                MyGoal.InnerHtml += DisplayStr(arrLine[i - 1].ToString() + " || ", "red");
            
            ArrayList al = new ArrayList();
            int one = 0, two = 0, three = 0;
            int same = 0, near = 0, far = 0;
            string strFind = string.Empty;
            int fFind = 0;
            int findModel = 0;
            string strFindModel = string.Empty;
            for (int j = 0; j < 33; j++ )
            {
                if (i > 0 && _RedBall[j, i - 1] == 1)
                {
                    color = "red";

                    if (_RedBall[j, i] == 1 )//|| _RedBall[j, i + 1] == 1)
                        same++;
                    else
                    {
                        if (j == 0)
                        {
                            if (_RedBall[j + 1, i] == 1 )//|| _RedBall[j + 1, i + 1] == 1)
                                near++;
                        }
                        else if (j == 32)
                        {
                            if (_RedBall[j - 1, i] == 1 )//|| _RedBall[j - 1, i + 1] == 1)
                                near++;
                        }
                        else
                        {
                            if (_RedBall[j + 1, i] == 1 || _RedBall[j - 1, i] == 1 )//|| _RedBall[j + 1, i + 1] == 1 || _RedBall[j - 1, i + 1] == 1)
                                near++;
                        }
                    }
                    
                    int ff = FindLastBall(_RedBall, j, i - 1);
                    strFind += ff.ToString("00");
                    fFind += ff;                    
                    
                    findModel = ff;
                    
                }
                if (i == 0)
                {
                    if (myBall[j, i] > 6)
                        color = "red";
                    else if (myBall[j, i] < 4)
                        color = "brown";
                    else
                        color = "blue";
                    
                    MyGoal.InnerHtml += DisplayStr(myBall[j, i].ToString("00") + " ", color, j + 1);
                    if (j == 32) color = "yellow";
                }
                else
                {
                    MyGoal.InnerHtml += DisplayStr((j + 1).ToString("00") + " ", color, myBall[j, i]);
                    if (color == "red")
                    {
                        al.Add(j + 1);
                        int left = 0;
                        if (al.Count == 1)
                            left = Convert.ToInt32(al[0]);                        
                        else
                            left = Convert.ToInt32(al[al.Count - 1]) - Convert.ToInt32(al[al.Count - 2]);

                        findModel += left;
                        //fFindModel[findModel]++;
                        if (findModel > 12)
                            strFindModel += "2";
                        else if (findModel > 6)
                            strFindModel = "1" + strFindModel; 
                        
                        strFind += left.ToString("00") + "|" + findModel.ToString("00") + "_";      

                        sumSix += j + 1;
                        color = "yellow";
                    }
                }

                if (j == 10 || j == 21 || j == 32)
                {
                    MyGoal.InnerHtml += DisplayStr("|| ", "red");
                    switch (j)
                    {
                        case 10:
                            one = al.Count;
                            break;
                        case 21:
                            two = al.Count - one;
                            break;
                        case 32:
                            three = al.Count - two - one;
                            break;
                    }
                }
            }
            
            string str = NumModel(al);
            //string strComplexModel = ComplexModel(al, fromTo);
            string strModel = FindGoodModel(str);

            if (i > 0)
            {
                beginEnd = int.Parse(al[5].ToString()) - int.Parse(al[0].ToString());
                beginEngSum[beginEnd / 5 * 5]++;
                sumSixSum[sumSix / 10 * 10]++;
                far = 6 - same - near;
            }
            string strNear = same.ToString() + near.ToString() + far.ToString();
            string split = one.ToString() + two.ToString() + three.ToString();
            string strMaxTwo = MaxTwoHave(_RedBall, i);
            
            MyGoal.InnerHtml += DisplayStr("  BeginEnd_" + beginEnd.ToString("00"), "purple");

            MyGoal.InnerHtml += DisplayStr("  Split_" + split, "red");

            //if (i > 0 && sumSix < 100)
            //    MyGoal.InnerHtml += DisplayStr("  SumSix_0" + sumSix.ToString(), "black");
            //else
                
            MyGoal.InnerHtml += DisplayStr("  SumSix_" + sumSix.ToString("000"), "black");
            MyGoal.InnerHtml += DisplayStr("  MaxTwo_" + strMaxTwo, "green");
            MyGoal.InnerHtml += DisplayStr("  SumFind" + fFind.ToString(), "pink");
            MyGoal.InnerHtml += DisplayStr("  Near_" + strNear, "brown");            
            MyGoal.InnerHtml += DisplayStr("  Model_" + strModel, "blue");
            //MyGoal.InnerHtml += DisplayStr("  ComplexModel_" + strComplexModel, "pink");
            MyGoal.InnerHtml += DisplayStr("  Find_" + strFind, "black");
            if (strFindModel != "")
            {
                fFindModel[int.Parse(strFindModel)]++;
                MyGoal.InnerHtml += DisplayStr("  FindModel_" + int.Parse(strFindModel).ToString("000000"), "green");
            }
            MyGoal.InnerHtml += DisplayBR();

            stat[int.Parse(strModel)]++;
            splitThree[int.Parse(split)]++;
            nearThree[int.Parse(strNear)]++;
            fFindCount[fFind / 5 * 5]++;
 

            if (strMaxTwo != "")
                maxTwoHave[int.Parse(strMaxTwo.Split('|')[1])]++;
            
        }
        float allCount = arrLine.Count;
        int tenSplit = arrLine.Count / 10;
        for (int i = 1; i < nearThree.Length; i++)
        {
            if (nearThree[i] != 0)
            {
                if (nearThree[i] >= tenSplit)
                    color = "red";
                else
                    color = "black";

                MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + nearThree[i].ToString() + "次", "brown");
                MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(nearThree[i]) / allCount).ToString("0.00") + "%", color);
                MyGoal.InnerHtml += DisplayBR();
            }
        }

        for (int i = 1; i < splitThree.Length; i++)
        {
            if (splitThree[i] != 0)
            {
                if (splitThree[i] >= tenSplit)
                    color = "red";
                else
                    color = "black";
                MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + splitThree[i].ToString() + "次", "red");
                MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(splitThree[i]) / allCount).ToString("0.00") + "%", color);                
                MyGoal.InnerHtml += DisplayBR();
            }
        }

        for (int i = 0; i < stat.Length; i++)
        {
            if (stat[i] >= tenSplit)
                color = "red";
            else
                color = "black";
            MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + stat[i].ToString() + "次", "blue");
            MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(stat[i]) / allCount).ToString("0.00") + "%", color);
            MyGoal.InnerHtml += DisplayBR();
        }

        for (int i = 0; i < maxTwoHave.Length; i++)
        {
            if (maxTwoHave[i] >= tenSplit)
                color = "red";
            else
                color = "black";
            MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + maxTwoHave[i].ToString() + "次", "green");
            MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(maxTwoHave[i]) / allCount).ToString("0.00") + "%", color);
            MyGoal.InnerHtml += DisplayBR();
        }

        //for (int i = 0; i < fromTo.Length; i++)
        //{
        //    if (fromTo[i] != 0)
        //    {
        //        if (fromTo[i] >= tenSplit)
        //            color = "red";
        //        else
        //            color = "black";
        //        MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + fromTo[i].ToString() + "次", "pink");
        //        MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(fromTo[i]) / allCount).ToString("0.00") + "%", color);
        //        MyGoal.InnerHtml += DisplayBR();
        //    }
        //}

        for (int i = 0; i < sumSixSum.Length; i++)
        {
            if (sumSixSum[i] != 0)
            {
                if (sumSixSum[i] >= tenSplit)
                    color = "red";
                else
                    color = "black";
                MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + sumSixSum[i].ToString() + "次", "black");
                MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(sumSixSum[i]) / allCount).ToString("0.00") + "%", color);
                MyGoal.InnerHtml += DisplayBR();
            }
        }

        for (int i = 0; i < beginEngSum.Length; i++)
        {
            if (beginEngSum[i] != 0)
            {
                if (beginEngSum[i] >= tenSplit)
                    color = "red";
                else
                    color = "black";
                MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + beginEngSum[i].ToString() + "次", "purple");
                MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(beginEngSum[i]) / allCount).ToString("0.00") + "%", color);
                MyGoal.InnerHtml += DisplayBR();
            }
        }

        for (int i = 0; i < fFindCount.Length; i++)
        {
            if (fFindCount[i] != 0)
            {
                if (fFindCount[i] >= tenSplit)
                    color = "red";
                else
                    color = "black";
                MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + fFindCount[i].ToString() + "次", "black");
                MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(fFindCount[i]) / allCount).ToString("0.00") + "%", color);
                MyGoal.InnerHtml += DisplayBR();
            }
        }

        for (int i = 0; i < fFindModel.Length; i++)
        {
            if (fFindModel[i] != 0)
            {
                if (fFindModel[i] >= tenSplit)
                    color = "red";
                else
                    color = "black";
                MyGoal.InnerHtml += DisplayStr("模式为" + i.ToString() + "共发生" + fFindModel[i].ToString() + "次", "green");
                MyGoal.InnerHtml += DisplayStr("占" + (Convert.ToSingle(fFindModel[i]) / allCount).ToString("0.00") + "%", color);
                MyGoal.InnerHtml += DisplayBR();
            }
        }
    }

    private string DisplayStr(string input, string color)
    {
        return "<span style='color:" + color + "'>" + input + "</span>";
    }

    private string DisplayStr(string input, string color, int number)
    {
        return "<span title=" + number.ToString() + " style='cursor:pointer;color:" + color + "'>" + input + "</span>";
    }

    private string DisplayBR()
    {
        return "<br><br>";
    }
    #endregion

    #region Model
    private string NumModel(ArrayList al)
    {
        string str = string.Empty;
        int[] sub = new int[5];
        for (int i = 0; i < al.Count - 1; i++)
        {
            sub[i] = int.Parse(al[i + 1].ToString()) - int.Parse(al[i].ToString());
            //fromTo[sub[i]]++;
        }

        for (int i = 0; i < sub.Length; i++)
        {
            if(sub[i] == 1)
                str += "1";
            else if (sub[i] != 0 && str != "" && str.Substring(str.Length - 1, 1) == "1")
                str += "0";            
        }
        if(str != "")
            str = str.Substring(0, str.LastIndexOf("1") + 1);
        return str;
    }

    private string ComplexModel(ArrayList al, int[] fromTo)
    {
        string str = string.Empty;
        ArrayList alSub = new ArrayList();
        for (int i = 0; i < al.Count - 1; i++)
        {
            int sub = int.Parse(al[i + 1].ToString()) - int.Parse(al[i].ToString());
            if (sub >= 3) sub = 0;
            alSub.Add(sub);            
        }
        alSub.Sort();

        for (int i = 0; i < alSub.Count; i++)
        {
            str += alSub[i].ToString();
        }
        if(str != "")
            fromTo[int.Parse(str)]++;
        return str;
    }

    private string FindGoodModel(string input)
    {
        string str = string.Empty;
        switch (input)
        {
            case "":
                str = "0";
                break;
            case "1":
                str = "1";
                break;
            case "101":
                str = "2";
                break;
            case "11":
                str = "3";
                break;
            case "10101":
                str = "4";
                break;
            case "1011":
            case "1101":
                str = "5";
                break;
            case "111":
                str = "6";
                break;
            case "10111":
            case "11101":
                str = "7";
                break;
            
        }
        return str;
    }
    #endregion

    #region FindLastBall
    private int FindLastBall(int[,] redBall, int x, int y)
    {
        int find = 0;

        for (find = 1; find <= MaxCount; find++)
        {
            if (redBall[x, y + find] == 1)
            {
                //find = i;
                break;
            }
        }

        return find;
    }

    #endregion

    #region MaxTwoHave
    private string DoStr(string str, int j)
    {
        string strNum = (j + 1).ToString();
        if (j + 1 < 10) strNum = "0" + strNum;
        if (str == "")
            str = strNum;
        else
            str += "_" + strNum;
        return str;
    }
    private string MaxTwoHave(int[,] redBall, int i)
    {
        string str = string.Empty;
        if (i > 1)
        {
            int one = 0;
            int two = 0;
            int count = 0;
            string strOneHave = string.Empty;
            string strTwoHave = string.Empty;            
            string strCountHave = string.Empty;
            
            for (int j = 0; j < 33; j++)
            {
                if (redBall[j, i - 1] == 0)
                {
                    count++;
                    if (redBall[j, i - 2] == 1)
                        strCountHave = DoStr(strCountHave, j);
                }
                if (redBall[j, i - 1] == 1 || j == 32)
                {
                    if (redBall[j, i - 1] == 1 && redBall[j, i - 2] == 1)
                        strCountHave = DoStr(strCountHave, j);
                    if (count > one || (count == one && strCountHave.Length > strOneHave.Length))
                    {
                        two = one;
                        strTwoHave = strOneHave;

                        one = count;
                        strOneHave = strCountHave;
                    }
                    else if (count > two || (count == two && strCountHave.Length > strTwoHave.Length))
                    {
                        two = count;
                        strTwoHave = strCountHave;
                    }
                    count = 0;
                    if (redBall[j, i - 1] == 1 && redBall[j, i - 2] == 1)
                    {
                        strCountHave = DoStr("", j);
                    }
                    else
                    {
                        strCountHave = "";            
                    }
                }
            }

            str = one.ToString("00") + "_" + two.ToString("00");

            if(strOneHave != "")
                one = strOneHave.Split('_').Length;
            else
                one = 0;
            if(strTwoHave != "")
                two = strTwoHave.Split('_').Length;
            else
                two = 0;
            int all = one + two;

            string strA = string.Empty;
            string strB = string.Empty;
            if (one != 0 && two != 0)
            {
                strA = strOneHave.Substring(0, 2);
                strB = strOneHave.Substring(strOneHave.Length - 2, 2);

                if (strTwoHave.Contains(strA) || strTwoHave.Contains(strB))
                    all--;
            }
            str += "|" + all.ToString("00");
        }
        return str;
    }
    #endregion
}