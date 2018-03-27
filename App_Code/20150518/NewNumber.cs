using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;
using System.Data;

/// <summary>
///NewNumber 的摘要说明
/// </summary>
public class NewNumber
{
	public NewNumber()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    #region TwoNearRepeat
    public static string GetSum30String(ArrayList arrRound, int[,] redBall, string input, int sumCount, int sumDisplay)
    {
        string str = "";

        string[] numberStr = input.Split(' ');

        if (sumDisplay < arrRound.Count - sumCount)
        {
            for (int j = 0; j < numberStr.Length; j++)
            {
                if (numberStr[j] != "")
                {
                    str += numberStr[j] + ": ";
                    for (int i = 1; i < sumDisplay; i++)
                    {
                        int now = 0;


                        for (int x = 0; x < sumCount; x++)
                        {
                            now += redBall[int.Parse(numberStr[j]) - 1, i + x];
                        }
                        str += now.ToString("00") + "|";
                    }
                    
                    int sum = 0;
                    for (int i = 0; i <= 250; i++)
                    {
                        sum += redBall[int.Parse(numberStr[j]) - 1, i];
                        if (i != 0 && i % 50 == 0)
                        {
                            str += "&" + sum.ToString("000");
                            sum = 0;
                        }
                    }

                    str += "_";
                }
            }


        }
        return str;
    }

    public static void GetTwoNearRepeat(int[,] redBall, int input, int i ,ref int near,ref int repeat,ref int near_22,ref int repeat_22)
    {
        
        //int repeat0 = 0;
        if (MyTest.ISRepeat(redBall, input, i + 1) == 0)
        {
            if (MyTest.ISNear(redBall, input, i + 1) == 0)
            {
                if (MyTest.ISRepeat(redBall, input, i + 2) == 0)
                    near_22 += MyTest.ISNear(redBall, input, i + 2);
                else
                    repeat_22 += MyTest.ISRepeat(redBall, input, i + 2);
            }
            else
                near += MyTest.ISNear(redBall, input, i + 1);
        }
        else
        {
            repeat += MyTest.ISRepeat(redBall, input, i + 1);             
        }
        
            
 

    }

    public static string GetTwoNearRepeatRound(int[,] redBall, int a1,int a2,int a3, int a4, int a5, int a6, int i)
    {
        int near = 0;
        int repeat = 0;
        int near_22 = 0;
        int repeat_22 = 0;
        string strReturn = string.Empty;

        GetTwoNearRepeat(redBall, a1, i, ref near, ref repeat, ref near_22, ref repeat_22);
        GetTwoNearRepeat(redBall, a2, i, ref near, ref repeat, ref near_22, ref repeat_22);
        GetTwoNearRepeat(redBall, a3, i, ref near, ref repeat, ref near_22, ref repeat_22);
        GetTwoNearRepeat(redBall, a4, i, ref near, ref repeat, ref near_22, ref repeat_22);
        GetTwoNearRepeat(redBall, a5, i, ref near, ref repeat, ref near_22, ref repeat_22);
        GetTwoNearRepeat(redBall, a6, i, ref near, ref repeat, ref near_22, ref repeat_22);

        strReturn = (near + repeat + near_22 + repeat_22).ToString() + "_" + repeat.ToString() + near.ToString() + repeat_22.ToString() + near_22.ToString();
        return strReturn;
    }

    public static string TwoNearRepeat(ArrayList arrRound, int[,] miniRedBall, int[,] redBall, ref DataTable dt)
    {
        string strReturn = string.Empty;

        string nearRepeat22_NoSelect = string.Empty;
        string repeat22_Select = string.Empty;

        string nearStr = string.Empty;
        string near22Str = string.Empty;
        string repeatStr = string.Empty;
        string repeat22Str = string.Empty;

        int inputBall = 0;
        if(miniRedBall.GetLength(0) == 6)
            inputBall = 33;
        if(miniRedBall.GetLength(0) == 5)
            inputBall = 35;

        for (int i = 1; i <= redBall.GetLength(0); i++)
        {
            nearRepeat22_NoSelect += i.ToString("00") + " ";
        }

        for (int i = 0; i < miniRedBall.GetLength(0); i++)
        {
            nearRepeat22_NoSelect = nearRepeat22_NoSelect.Replace(miniRedBall[i, 1].ToString("00") + " ", "");
            nearRepeat22_NoSelect = nearRepeat22_NoSelect.Replace(miniRedBall[i, 2].ToString("00") + " ", "");
            nearRepeat22_NoSelect = nearRepeat22_NoSelect.Replace((miniRedBall[i, 1] + 1).ToString("00") + " ", "");
            nearRepeat22_NoSelect = nearRepeat22_NoSelect.Replace((miniRedBall[i, 2] + 1).ToString("00") + " ", "");
            nearRepeat22_NoSelect = nearRepeat22_NoSelect.Replace((miniRedBall[i, 1] - 1).ToString("00") + " ", "");
            nearRepeat22_NoSelect = nearRepeat22_NoSelect.Replace((miniRedBall[i, 2] - 1).ToString("00") + " ", "");

            if (!repeat22_Select.Contains(miniRedBall[i, 1].ToString("00")))
                repeat22_Select += miniRedBall[i, 1].ToString("00") + " ";
            if (!repeat22_Select.Contains(miniRedBall[i, 2].ToString("00")))
                repeat22_Select += miniRedBall[i, 2].ToString("00") + " ";

            repeatStr += miniRedBall[i, 1].ToString("00") + " ";
        }

        for (int i = 0; i < miniRedBall.GetLength(0); i++)
        {
            if (!repeatStr.Contains(miniRedBall[i, 2].ToString("00")))
                repeat22Str += miniRedBall[i, 2].ToString("00") + " ";
        }
        for (int i = 0; i < miniRedBall.GetLength(0); i++)
        {
            if (!repeatStr.Contains((miniRedBall[i, 1] + 1).ToString("00")) && !repeat22Str.Contains((miniRedBall[i, 1] + 1).ToString("00")) && miniRedBall[i, 1] + 1 <= inputBall)
                nearStr += (miniRedBall[i, 1] + 1).ToString("00") + " ";

            if (!repeatStr.Contains((miniRedBall[i, 1] - 1).ToString("00")) && !repeat22Str.Contains((miniRedBall[i, 1] - 1).ToString("00")) && miniRedBall[i, 1] - 1 > 0)
                nearStr += (miniRedBall[i, 1] - 1).ToString("00") + " ";
        }
        for (int i = 0; i < miniRedBall.GetLength(0); i++)
        {
            if (!repeatStr.Contains((miniRedBall[i, 2] + 1).ToString("00")) && !repeat22Str.Contains((miniRedBall[i, 2] + 1).ToString("00")) && !nearStr.Contains((miniRedBall[i, 2] + 1).ToString("00")) && miniRedBall[i, 2] + 1 <= inputBall)
                near22Str += (miniRedBall[i, 2] + 1).ToString("00") + " ";

            if (!repeatStr.Contains((miniRedBall[i, 2] - 1).ToString("00")) && !repeat22Str.Contains((miniRedBall[i, 2] - 1).ToString("00")) && !nearStr.Contains((miniRedBall[i, 2] - 1).ToString("00")) && miniRedBall[i, 2] - 1 > 0)
                near22Str += (miniRedBall[i, 2] - 1).ToString("00") + " ";
        }

        strReturn += DisplayStr("_NearRepeat22_NoSelect:", "brown"); 
        strReturn += DisplayStr(nearRepeat22_NoSelect, "green");
        strReturn += DisplayBR();

        strReturn += DisplayStr("_Repeat22_Select:", "brown");
        strReturn += DisplayStr(repeat22_Select, "green");
        strReturn += DisplayBR();

        strReturn += DisplayStr("Repeat:", "brown");
        strReturn += DisplayStr(repeatStr, "green");
        strReturn += DisplayBR();

        string str = GetSum30String(arrRound, redBall, repeatStr, 30, 25);
        string[] strDisplay = str.Split('_');
        for (int i = 0; i < strDisplay.Length; i++)
        {
            strReturn += DisplayStr(strDisplay[i], "red");
            strReturn += DisplayBR();
        }

        strReturn += DisplayStr("Repeat22:", "brown");
        strReturn += DisplayStr(repeat22Str, "green");
        strReturn += DisplayBR();

        str = GetSum30String(arrRound, redBall, repeat22Str, 30, 25);
        strDisplay = str.Split('_');
        for (int i = 0; i < strDisplay.Length; i++)
        {
            strReturn += DisplayStr(strDisplay[i], "red");
            strReturn += DisplayBR();
        }

        strReturn += DisplayStr("Near:", "brown");
        strReturn += DisplayStr(nearStr, "green");
        strReturn += DisplayBR();

        str = GetSum30String(arrRound, redBall, nearStr, 30, 25);
        strDisplay = str.Split('_');
        for (int i = 0; i < strDisplay.Length; i++)
        {
            strReturn += DisplayStr(strDisplay[i], "red");
            strReturn += DisplayBR();
        }

        strReturn += DisplayStr("Near22:", "brown");
        strReturn += DisplayStr(near22Str, "green");
        strReturn += DisplayBR();

        str = GetSum30String(arrRound, redBall, near22Str, 30, 25);
        strDisplay = str.Split('_');
        for (int i = 0; i < strDisplay.Length; i++)
        {
            strReturn += DisplayStr(strDisplay[i], "red");
            strReturn += DisplayBR();
        }

        for (int i = arrRound.Count - 1; i > 0 ; i--)
        {
            DataRow newRow;
            strReturn += DisplayStr(arrRound[i].ToString() + "||", "blue");
            int near = 0;
            int repeat = 0;
            int near_22 = 0;
            int repeat_22 = 0;
            string str11 = "";
            string str6 = "";
            int[] aa = new int[11];
            if (i != arrRound.Count - 2)
            {

                for (int j = 0; j < miniRedBall.GetLength(0); j++)
                {
                    strReturn += DisplayStr(miniRedBall[j, i].ToString("00") + " ", "red");

                    GetTwoNearRepeat(redBall, miniRedBall[j, i], i, ref near ,ref repeat ,ref near_22 ,ref repeat_22);

                    //near = int.Parse(str.Substring(2,1));
                    //repeat = int.Parse(str.Substring(3, 1));
                    //near_22 = int.Parse(str.Substring(4,1));
                    //repeat_22 = int.Parse(str.Substring(5, 1));


                    switch (miniRedBall[j, i])
                    {
                        case 1:
                        case 2:
                        case 3: aa[0]++; break;
                        case 4:
                        case 5:
                        case 6: aa[1]++; break;
                        case 7:
                        case 8:
                        case 9: aa[2]++; break;
                        case 10:
                        case 11:
                        case 12: aa[3]++; break;
                        case 13:
                        case 14:
                        case 15: aa[4]++; break;
                        case 16:
                        case 17:
                        case 18: aa[5]++; break;
                        case 19:
                        case 20:
                        case 21: aa[6]++; break;
                        case 22:
                        case 23:
                        case 24: aa[7]++; break;
                        case 25:
                        case 26:
                        case 27: aa[8]++; break;
                        case 28:
                        case 29:
                        case 30: aa[9]++; break;
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35: aa[10]++; break;
                    }
                }

                for (int j = 0; j < 11; j++)
                {
                    str11 += aa[j].ToString();

                    if (j != 10 && j % 2 == 0)
                        str6 += (aa[j] + aa[j + 1]).ToString();
                    else if (j == 10)
                        str6 += aa[j].ToString();


                }
                strReturn += DisplayStr("|near:" + near.ToString(), "green");
                strReturn += DisplayStr("|repeat:" + repeat.ToString(), "green");
                strReturn += DisplayStr("|near22:" + near_22.ToString(), "green");
                strReturn += DisplayStr("|repeat22:" + repeat_22.ToString(), "green");

                strReturn += DisplayStr("|str6:" + str6, "red");
                strReturn += DisplayStr("|str11:" + str11, "red");

                strReturn += DisplayStr("|All:" + (near + repeat + near_22 + repeat_22).ToString()+"||", "black");


                for (int j = 0; j < redBall.GetLength(0); j++)
                {
                    string color = "";
                    if (near + repeat + near_22 + repeat_22 == 6 || near + repeat + near_22 + repeat_22 == 5)                    
                        color = "green";
                    else
                        color = "black";
                    if (redBall[j, i] == 1)
                    {
                        if (near + repeat + near_22 + repeat_22 == 6)
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "red");
                        else if (redBall[j, i + 1] == 1)
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "red");
                        else if (j - 1 >= 0 && redBall[j - 1, i + 1] == 1)
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "red");
                        else if (j + 1 < 33 && redBall[j + 1, i + 1] == 1)
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "red");
                        else if (redBall[j, i + 2] == 1)
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "red");
                        else if (j - 1 >= 0 && redBall[j - 1, i + 2] == 1)
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "red");
                        else if (j + 1 < 33 && redBall[j + 1, i + 2] == 1)
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "red");
                        else
                            strReturn += DisplayStrBackground((j + 1).ToString("00") + " ", "blue");

                    }
                    else
                    {
                        //if(color == "black")
                        //    strReturn += DisplayStr(redBall[j, i].ToString("00") + " ", color);
                        //else
                            strReturn += DisplayStrLine(redBall[j, i].ToString("00") + " ", color);
                    }
                }
            }




            strReturn += DisplayBR();


            newRow = dt.NewRow();
            newRow["round"] = arrRound[i].ToString();
            newRow["A0"] = near;
            newRow["A1"] = repeat;
            newRow["A2"] = near_22;
            newRow["A3"] = repeat_22;
            newRow["A4"] = near + repeat + near_22 + repeat_22;
            newRow["A5"] = near + repeat;
            newRow["A12"] = repeat.ToString() + near.ToString() + repeat_22.ToString() + near_22.ToString();
            newRow["A13"] = str6;
            newRow["A14"] = str11;
            newRow["FLAG"] = 777788;
            dt.Rows.Add(newRow);
        }

        return strReturn;
    }

    #endregion

    #region Display

    public static string DisplayStr(string input, string color)
    {
        return "<span style='color:" + color + "'>" + input + "</span>";
       
    }

    public static string DisplayStrBackground(string input, string color)
    {
        return "<span style='font-weight:bold;background-color:#E2C2DE;color:" + color + "'>" + input + "</span>";

    }

    public static string DisplayStrLine(string input, string color)
    {
        return "<span style='font-weight:bold;color:" + color + "'>" + input + "</span>";
    }

    public static string DisplayBR()
    {
        return "<br><br>";
    }

    public static string DisplayBROne()
    {
        return "<br>";
    }
    public static string DisplayOverLineStr(string input, string color, bool print)
    {
        if (print)
            return "<span style='text-decoration:overline;color:" + color + "'>" + input + "</span>";
        else
            return string.Empty;
    }
    public static string DisplayLineThroughStr(string input, string color, bool print)
    {
        if (print)
            return "<span style='text-decoration:line-through;color:" + color + "'>" + input + "</span>";
        else
            return string.Empty;
    }

    public static string DisplayStr(string input, string color, bool print)
    {
        if (print)
            return "<span style='color:" + color + "'>" + input + "</span>";
        else
            return string.Empty;
    }

    public static string DisplayStrWidthBold(string input, string color, bool print)
    {
        if (print)
            return "<span style='display:-moz-inline-box; display:inline-block; width:20px;font-weight: bold;color:" + color + "'>" + input + "</span>";
        else
            return string.Empty;
    }

    public static string DisplayStrWidth(string input, string color, bool print)
    {
        if (print)
            return "<span style='display:-moz-inline-box; display:inline-block; width:20px;color:" + color + "'>" + input + "</span>";
        else
            return string.Empty;
    }

    public static string DisplayStr(string input, string color, int number, bool print)
    {
        if (print)
            return "<span title=" + number.ToString() + " style='cursor:pointer;color:" + color + "'>" + input + "</span>";
        else
            return string.Empty;

    }

    public static string DisplayBR(bool print)
    {
        if (print)
            return "<br><br>";
        else
            return string.Empty;
    }
    public static string DisplayBROne(bool print)
    {
        if (print)
            return "<br>";
        else
            return string.Empty;
    }
    #endregion
}