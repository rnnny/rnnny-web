using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class BallVersion2_MyGame : System.Web.UI.Page
{
    #region 变量
    private const int MaxMax = 500;
    private const int MaxStatistics = 100;
    private int[,] _RedBall = new int[33, MaxMax];
    private ArrayList _ArrStr = new ArrayList();
    private ArrayList _ArrMyStr = new ArrayList();
    private ArrayList _ArrNowStr = new ArrayList();
    private int _Input = 5;
    private int _Min = 2;
    private int _Middle = 4;
    private int _Max = 6;
    private float _ISelect = 0.5f;
    private string _StrNow = string.Empty;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        int count = ReadFile();

        if (dropTurn.SelectedItem.Value == "all")
        {
            txtTurn.Text = _StrNow;  
            ArrayList alReturn = new ArrayList();            

            for (int i = 1; i <= MaxStatistics; i++)
            {
                _StrNow = dropTurn.Items[i].Value.Split('_')[1];
                _ArrStr = FindAllStr(_Input, _RedBall, count, int.Parse(dropTurn.Items[i].Value.Split('_')[0]));

                alReturn = StatisticsAll(float.Parse(dropTurn.Items[i].Text), _Min, _Max, _Middle, _Input, _ArrStr, _ArrMyStr, _ArrNowStr, alReturn);
            }

            ArrayList al = MyGame.GiveMyOpinion(alReturn, "0");

            DisplayStatisticsArray(al, 1);
            //DisplayStatisticsArray(alReturn, 0);
        }
        else
        {
            if (dropTurn.SelectedItem.Value == "now")
            {
                _StrNow = "";
                _ArrStr = FindAllStr(_Input, _RedBall, count, 0);
            }
            else
            {
                _StrNow = dropTurn.SelectedItem.Value.Split('_')[1];                
                _ArrStr = FindAllStr(_Input, _RedBall, count, int.Parse(dropTurn.SelectedItem.Value.Split('_')[0]));
            }
            txtTurn.Text = _StrNow;
            DisplayResult(_Min, _Max, _Middle, _Input, _ArrStr, _ArrMyStr, _ArrNowStr);
        }
    }
    #endregion

    #region statistics
    private ArrayList StatisticsAll(float ffTrun, int min, int max, int middle, int input, ArrayList arrStr, ArrayList arrMyStr, ArrayList arrNowStr, ArrayList alReturn)
    {        
        for (int i = 0; i < arrMyStr.Count; i++)
        {
            string str = arrMyStr[i].ToString();
                        
            string minStr = str.Substring(str.Length - min, min);
            string middleStr = str.Substring(str.Length - middle, middle);
            string maxStr = str.Substring(str.Length - max, max);
            int now = int.Parse(arrNowStr[i].ToString());
            float[] ffAll = new float[6]; 
            
            ffAll[0] = ffTrun;

            ffAll[1] = i + 1;

            int[] allReturn = SearchStr("", arrStr, input, now);
            float ff = ((float)allReturn[now + 1] / (float)allReturn[now]);

            allReturn = SearchStr(maxStr, arrStr, input, now);
            ffAll[4] = (float)allReturn[now + 1] / (float)allReturn[now] / ff;

            allReturn = SearchStr(middleStr, arrStr, input, now);
            ffAll[3] = (float)allReturn[now + 1] / (float)allReturn[now] / ff;

            allReturn = SearchStr(minStr, arrStr, input, now);
            ffAll[2] = (float)allReturn[now + 1] / (float)allReturn[now] / ff;

            string strNumber = "";
            if (i < 9)
                strNumber = "0" + (i + 1).ToString();
            else
                strNumber = (i + 1).ToString();
            if (_StrNow.IndexOf(strNumber) == -1)
            {
                ffAll[5] = 1;
                alReturn.Add(ffAll);
            }
            else
            {
                ffAll[5] = 0;
                alReturn.Insert(0, ffAll);
            }
        }
        return alReturn;
    }
    #endregion

    #region ReadFile
    private int ReadFile()
    {
        StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
        string line;
        //ArrayList arrSource = new ArrayList();
        int count = 0;
        dropTurn.Items.Add(new ListItem("now", "now"));
        while ((line = smRead.ReadLine()) != null)
        {
            //if (line.Substring(0, 2) != "//" && line.Substring(0, 2) != "\\")
            //{
            string str = line.Substring(6, 17);
            if(count <= MaxStatistics)
                dropTurn.Items.Add(new ListItem(line.Substring(0, 5), (count + 1).ToString() + "_" + str)); 
            //_ArrLine.Add(line.Substring(0, 5));
            //_ArrGoal.Add(line.Split(' ')[11]);

            ArrayList arrLine = new ArrayList();
            for (int k = 0; k < str.Split(' ').Length; k++)
            {
                arrLine.Add(str.Split(' ')[k]);
            }
            //string[] strLine = new string[33];
            for (int i = 1; i <= 33; i++)
            {
                string a = i.ToString();
                if (i < 10)
                    a = "0" + i.ToString();
                if (arrLine.Contains(a))
                {
                    //strLine[i - 1] = a;
                    _RedBall[i - 1, count] = 1;
                }
                else
                {
                    //strLine[i - 1] = "";
                    _RedBall[i - 1, count] = 0;
                }
            }
            //arrSource.Add(strLine);
            count++;
            //}
            //else
            //{
            //    if (line.Substring(0, 2) == "//")
            //        _StrNow = line.Substring(8, 17);
            //}
        }
        dropTurn.Items.Add(new ListItem("all", "all"));
        return count;
    }
    #endregion

    #region FindAllStr
    private ArrayList FindAllStr(int input, int[,] redBall, int count, int end)
    {
        ArrayList al = new ArrayList();
        _ArrMyStr.Clear();
        _ArrNowStr.Clear();

        for(int i = 0; i < 33; i++)
            for (int j = 1; j <= input; j++)
            {
                string str = "";
                int begin = count - j;
                while (begin - end > 0)
                {
                    int sum = 0;
                    if (begin - end >= input)
                    {
                        for (int x = 1; x <= input; x++)
                        {
                            sum += redBall[i, begin - x];
                        }
                     
                        str += sum.ToString();
                    }
                    begin = begin - input;
                    if (begin - end == -1)
                    {
                        for (int x = 1; x < input; x++)
                        {
                            sum += redBall[i, begin + x];
                        }
                        _ArrNowStr.Add(sum);
                    }
                }
                if (begin - end == -1) 
                    _ArrMyStr.Add(str);
                al.Add(str);
            }
        return al; 
    }
    #endregion

    #region Display
    private void DisplayStatisticsArray(ArrayList al, int flag)
    {
        MyGoal.InnerHtml = "";
        string color = "red";
        for (int i = 0; i < al.Count; i++)
        {
            switch (flag)
            {
                case 0:                    
                        float[] ffAll = (float[])al[i];

                        if (ffAll[ffAll.Length - 1] == 1)
                            color = "blue";
                        for (int j = 0; j < ffAll.Length - 1; j++)
                        {
                            if (j > 1)
                                MyGoal.InnerHtml += DisplayDiv("-" + ffAll[j].ToString("0.00") + "-", color);
                            else
                                MyGoal.InnerHtml += DisplayDiv("-" + ffAll[j].ToString("0") + "-", "black");
                        }
                        if ((i + 1) % 6 == 0)
                            MyGoal.InnerHtml += DisplayBR();
                    
                    break;
                case 1:
                    MyGoal.InnerHtml += DisplayDiv(al[i].ToString() + "  ", "red");
                    MyGoal.InnerHtml += DisplayBR();
                    break;

            }
        }
    }
    private void DisplayResult(int min, int max, int middle, int input, ArrayList arrStr ,ArrayList arrMyStr, ArrayList arrNowStr)
    {
        MyGoal.InnerHtml = string.Empty;
        for (int i = 0; i < arrMyStr.Count; i++)
        {
            string str = arrMyStr[i].ToString();
            string strNumber = "";
            string color = "";
            if (i < 9)
                strNumber = "0" + (i + 1).ToString();
            else
                strNumber = (i + 1).ToString();
            if (_StrNow == string.Empty || _StrNow.IndexOf(strNumber) == -1)
                color = "red";          
            else
                color = "green"; 
            
            MyGoal.InnerHtml += DisplayDiv(strNumber, color);          
            string minStr = str.Substring(str.Length - min, min);
            string middleStr = str.Substring(str.Length - middle, middle);
            string maxStr = str.Substring(str.Length - max, max);
            int now = int.Parse(arrNowStr[i].ToString());
            MyGoal.InnerHtml += DisplayDiv("-" + maxStr, "black");
            MyGoal.InnerHtml += DisplayDiv("-" + middleStr, "brown");
            MyGoal.InnerHtml += DisplayDiv("-" + minStr, "blue");
            MyGoal.InnerHtml += DisplayDiv("-" + now.ToString(), "red");

            int[] allReturn = SearchStr("", arrStr, input, now);
            MyGoal.InnerHtml += DisplaySearchStr(allReturn, now, "AllStr");
            float ffAll = ((float)allReturn[now + 1] / (float)allReturn[now]);

            int[] intReturn = SearchStr(maxStr, arrStr, input, now);
            MyGoal.InnerHtml += DisplaySearchStr(intReturn, now, "MaxStr", allReturn);
            float ff = (float)intReturn[now + 1] / (float)intReturn[now];

            intReturn = SearchStr(middleStr, arrStr, input, now);
            MyGoal.InnerHtml += DisplaySearchStr(intReturn, now, "MiddleStr", allReturn);
            ff += (float)intReturn[now + 1] / (float)intReturn[now];

            intReturn = SearchStr(minStr, arrStr, input, now);
            MyGoal.InnerHtml += DisplaySearchStr(intReturn, now, "MinStr", allReturn);
            ff += (float)intReturn[now + 1] / (float)intReturn[now];

            MyGoal.InnerHtml += DisplayDiv("|" + ff.ToString("0.00") + "/" + ffAll.ToString("0.00") + "=" + (ff / ffAll).ToString("0.00"), color);   
            MyGoal.InnerHtml += DisplayBR();
        }
    }

    private string DisplaySearchStr(int[] inputResult, int now, string talk)
    {
        string str = "";
        str += DisplayDiv("|" + talk + "->", "black");
        for (int j = 0; j < inputResult.Length; j++)
        {
            if (j == now)
                str += DisplayDiv(" " + inputResult[j].ToString(), "blue");
            else if (j == now + 1)
                str += DisplayDiv(" " + inputResult[j].ToString(), "red");
            else
                str += DisplayDiv(" " + inputResult[j].ToString(), "black");
        }
        //float ff = (float)inputResult[now + 1] / (float)inputResult[now];
        //if (ff >= _ISelect)
        //    str += DisplayDiv(" " + ff.ToString(), "green");
        //else
        //    str += DisplayDiv(" " + ff.ToString(), "brown");
        return str;
    }

    private string DisplaySearchStr(int[] inputResult, int now, string talk, int[] allResult)
    {
        string str = "";
        str += DisplayDiv("|" + talk + "->", "black");
        for (int j = 0; j < inputResult.Length; j++)
        {
            if (j == now)
                str += DisplayDiv(" " + inputResult[j].ToString(), "blue");
            else if (j == now + 1)
                str += DisplayDiv(" " + inputResult[j].ToString(), "red");
            else
                str += DisplayDiv(" " + inputResult[j].ToString(), "black");
        }

        float ff = (float)inputResult[now + 1] / (float)inputResult[now];
        float ffAll = ((float)allResult[now + 1] / (float)allResult[now]);
        if (ff >= _ISelect)
            str += DisplayDiv(" " + ff.ToString("0.00"), "green");
        else
            str += DisplayDiv(" " + ff.ToString("0.00"), "brown");
        if(ff >= ffAll)
            str += DisplayDiv("_" + ffAll.ToString("0.00"), "red");
        else
            str += DisplayDiv("_" + ffAll.ToString("0.00"), "black");
        return str;
    }

    private string DisplayDiv(string input, string color)
    {
        return "<span style='color:" + color + "'>" + input + "</span>";
    }

    private string DisplayBR()
    {
        return "<br><br>";
    }
    #endregion

    #region math
    private int[] SearchStr(string myStr, ArrayList arrStr, int input, int now)
    {
        int[] inputResult = new int[input + 1];
        for (int i = 0; i < arrStr.Count; i++)
        {
            string str = arrStr[i].ToString();
            for (int j = 0; j < str.Length - myStr.Length - 1; j++)
            {
                if (myStr == str.Substring(j, myStr.Length))
                {
                    inputResult[int.Parse(str.Substring(j + myStr.Length + 1, 1))]++;                    
                }
            }
        }

        if (inputResult[now] == 0 || inputResult[now + 1] == 0)
        {
            inputResult[now]++;
            inputResult[now + 1]++;
        }
        return inputResult;
    }
    #endregion
}