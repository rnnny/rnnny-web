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

public partial class TwoBall585 : System.Web.UI.Page
{
    #region 变量
    private const int MaxCount = 29;
    private const int MaxSplit = 200;
    private const int MaxMax = 500;
    private ArrayList _Arr = new ArrayList();
    private ArrayList _ArrLine = new ArrayList();
    private ArrayList _ArrGoal = new ArrayList();
    private int[,] _RedBall = new int[33, MaxMax];
    private int _High = 0;
    private int _Low = 0;
    private int _SumHot = 0;
    private int _SumGoal = 0;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (txtInput.Text == string.Empty)
        {
            StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
            string line = smRead.ReadLine();
            txtInput.Text = line.Substring(6, 17);
        }

        InitPage();

        if (!IsPostBack)
        {
            InitRadioButton();
        }

        //SessionArray();

    }

    private void SessionArray()
    {
        int[,] totalBall = new int[33, MaxMax];
        for (int i = 0; i < _Arr.Count - MaxCount - 1; i++)
        {
            for (int j = 0; j < 33; j++)
            {
                for (int x = 0; x <= MaxCount; x++)
                {
                    totalBall[j, i] += _RedBall[j, i + x];
                }
            }
        }

        Session["TotalBall"] = totalBall;
        Session["RedBall"] = _RedBall;
        Session["ArrLine"] = _ArrLine;
        Session["TxtInput"] = txtInput.Text;
    }

    private void InitPage()
    {
        txtDisplay.Text = string.Empty;
        haha.InnerHtml = string.Empty;
        _Arr = ReadFile();
        InitSplitTxt();

        _SumHot = int.Parse(txtHot.Text);
        _SumGoal = int.Parse(txtGoal.Text);
        _High = GetHighSelectItem();
        _Low = GetLowSelectItem();
    }

    private void InitSplitTxt()
    {
        int splitSum = 0, splitHead = 0;
        for (int i = 0; i < _Arr.Count; i++)
        {
            int begin = 0, count = 0;
            string[] strNew = (string[])_Arr[i];

            for (int j = 0; j < strNew.Length; j++)
            {
                if (strNew[j] != "")
                {
                    splitSum += int.Parse(strNew[j]);
                    count++;
                    if (count == 1)
                        begin = int.Parse(strNew[j]);
                    if (count == 6)
                    {
                        splitHead += int.Parse(strNew[j]) - begin;
                        break;
                    }
                }
            }
        }

        float averageSum = (float)splitSum / (float)_Arr.Count;
        float averageHead = (float)splitHead / (float)_Arr.Count;
        txtSplitSum.Text = averageSum.ToString();
        txtSplitHead.Text = averageHead.ToString();
    }

    private int GetLowSelectItem()
    {
        int low;

        if (radioButtonNum.SelectedItem == null)
            low = 3;
        else
            low = int.Parse(radioButtonNum.SelectedItem.Value);

        return low;
    }

    private int GetHighSelectItem()
    {
        int high;

        if (radioButtonTo.SelectedItem == null)
            high = 8;
        else
            high = int.Parse(radioButtonTo.SelectedItem.Value);

        return high;
    }

    private void InitRadioButton()
    {
        this.radioButtonNum.Items.Clear();

        ListItem li = new ListItem();
        li.Text = "一";
        li.Value = "1";
        radioButtonNum.Items.Add(li);

        li = new ListItem();
        li.Text = "二";
        li.Value = "2";
        radioButtonNum.Items.Add(li);

        li = new ListItem();
        li.Text = "三";
        li.Value = "3";
        radioButtonNum.Items.Add(li);

        li = new ListItem();
        li.Text = "四";
        li.Value = "4";
        radioButtonNum.Items.Add(li);

        li = new ListItem();
        li.Text = "五";
        li.Value = "5";
        radioButtonNum.Items.Add(li);

        li = new ListItem();
        li.Text = "六";
        li.Value = "6";
        radioButtonNum.Items.Add(li);

        li = new ListItem();
        li.Text = "七";
        li.Value = "7";
        radioButtonNum.Items.Add(li);

        this.radioButtonTo.Items.Clear();

        li = new ListItem();
        li.Text = "四";
        li.Value = "4";
        radioButtonTo.Items.Add(li);

        li = new ListItem();
        li.Text = "五";
        li.Value = "5";
        radioButtonTo.Items.Add(li);

        li = new ListItem();
        li.Text = "六";
        li.Value = "6";
        radioButtonTo.Items.Add(li);

        li = new ListItem();
        li.Text = "七";
        li.Value = "7";
        radioButtonTo.Items.Add(li);

        li = new ListItem();
        li.Text = "八";
        li.Value = "8";
        radioButtonTo.Items.Add(li);

        li = new ListItem();
        li.Text = "九";
        li.Value = "9";
        radioButtonTo.Items.Add(li);

        li = new ListItem();
        li.Text = "十";
        li.Value = "10";
        radioButtonTo.Items.Add(li);
    }

    #endregion

    #region ReadFile
    private ArrayList ReadFile()
    {
        StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
        string line;
        ArrayList arrSource = new ArrayList();
        int count = 0;
        while ((line = smRead.ReadLine()) != null)
        {
            string str = line.Substring(6, 17);
            _ArrLine.Add(line.Substring(0, 5));
            _ArrGoal.Add(line.Split(' ')[11]);
            
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

        return arrSource;
    }
    #endregion

    #region ClickOK
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (txtInput.Text.Trim() != string.Empty)
        {
            string[] strNow = new string[6];            
            string[] strArr = new string[6];
            int[] totalSub = new int[33];
            int[] totalNum = new int[16];
            strArr = txtInput.Text.Trim().Split(' ');
            ArrayList alFound = new ArrayList();

            //_Arr = ReadFile();
            bool found = false;
            for (int i = 0; i < _Arr.Count; i++)
            {

                haha.InnerHtml += "<span style='float:left; color:red; width: 40px; height: 12px;border-style:groove'>" + (string)_ArrLine[i] + "</span>";

                string[] str = (string[])_Arr[i];

                found = FoundLike(strArr, str, ref alFound);
                int count = 0;
                int num = 0;

                for (int j = 0; j < str.Length; j++)
                {
                    if (found)
                    {
                        if (str[j].ToString() != string.Empty && FoundLike(strArr, str[j].ToString()))
                            haha.InnerHtml += "<span style='float:left; color:red; width: 16px; height: 12px;border-style:groove;border-bottom-color:Blue'>" + str[j].ToString() + "</span>";
                        else
                            haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove;border-bottom-color:Blue'>" + str[j].ToString() + "</span>";
                    }
                    else
                        haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove'>" + str[j].ToString() + "</span>";
                    if (str[j].ToString() != string.Empty)
                    {
                        strNow[count] = str[j];
                        num += int.Parse(strNow[count]);
                        count++;                        
                    }
                }
                int sub = int.Parse(strNow[5]) - int.Parse(strNow[0]);
                totalSub[sub]++;
                if(sub <= 20)
                    haha.InnerHtml += "<span style='float:left;color:red; width: 60px; height: 12px;border-style:groove'>" + "首尾" + sub.ToString() + "</span>";
                else
                    haha.InnerHtml += "<span style='float:left;color:green; width: 60px; height: 12px;border-style:groove'>" + "首尾" + sub.ToString() + "</span>";
                haha.InnerHtml += "<span style='float:left; width: 60px; height: 12px;border-style:groove'>" + "总和" + num.ToString() + "</span>";

                if (_ArrLine.Count > i + 30)
                    haha.InnerHtml += "<span style='float:left; color:blue; width:100px; height:12px;border-style:groove'><a href='GreatBall.aspx?ID=" + _ArrLine[i].ToString() + "-" + _ArrLine[i + 30] + "&Like=" + txtMax.Text + "&Color=" + "4-7" + "' target='_blank'>" + _ArrLine[i].ToString() + "-" + _ArrLine[i + 30] + "</a></span>";
                            
                haha.InnerHtml += "<br><br>";

                totalNum[FoundBigSmall(num)]++;
            }

            for (int i = 0; i < totalSub.Length; i++)
            {
                if (totalSub[i] > 0)
                    haha.InnerHtml += "<span style='float:left; width: 150px; height: 12px;border-style:groove'>" + "首尾差为" + i.ToString() + "有"+ totalSub[i].ToString() + "次" + "</span>";
            }

            haha.InnerHtml += "<br><br>";

            for (int i = 0; i < totalNum.Length; i++)
            {
                if (totalNum[i] > 0)
                    haha.InnerHtml += "<span style='float:left; width: 150px; height: 12px;border-style:groove'>" + "总和为" + i.ToString() + "0有" + totalNum[i].ToString() + "次" + "</span>";
            }

            haha.InnerHtml += "<br><br>";

            alFound.Sort();

            for (int i = 0; i < alFound.Count; i++)
            {
                haha.InnerHtml += "<span style='float:left; width: 200px; height: 12px;border-style:groove'>" + "历史组合有" + alFound[i].ToString()  + "</span>";
            }

            haha.InnerHtml += "<br><br>";
        }
    }

    private int FoundBigSmall(int input)
    {
        input = input / 10;

        if (input < 5)
            input = 5;
        else if (input > 15)
            input = 15;

        return input;
    }

    private bool FoundLike(string[] strArr, string[] str, ref ArrayList al)
    {
        string strFound = string.Empty;
        bool found = false;
        int count = 0;
        int[] sum = new int[6];
        int sumCount = 0;

        for (int i = 0; i < strArr.Length; i++)
        {
            if (strArr[i] != "")
            {
                sum[sumCount] = int.Parse(strArr[i]); sumCount++;
            }
        }
        for (int i = 0; i < sum.Length; i++)
        {
            if (str[sum[i] - 1] != string.Empty)
            {
                count++;
                strFound += "_" + strArr[i];
            }
        }

        if (count >= 3)
        {
            found = true;
            al.Add(strFound);
        }
        return found;
    }

    private bool FoundLike(string[] strArr, string str)
    {
        bool found = false;
        for (int i = 0; i < strArr.Length; i++)
        {
            if (str == strArr[i])
            {
                found = true;break;
            }
        }
        return found;
    }
    #endregion 

    #region 30分析
    private string SortChar(ArrayList input)
    {
        input.Sort();
        string str = string.Empty;
        for (int i = 0; i < input.Count; i++)
        {
            str += input[i].ToString();
        }
        return str;
    }

    protected void btnCount_Click(object sender, EventArgs e)
    {
        //_Arr = ReadFile();
        string[] str;
        //int number = MaxCount;
        //int sumBall = int.Parse(txtHot.Text);
        //int high = GetHighSelectItem();
        //int low = GetLowSelectItem();

        int[,] totalBall = new int[33, MaxMax];
        int[] abc = new int[34];
        int[] goalAbc = new int[7];
        int[] goalTotalBall = new int[60];
        int[] blueBall = new int[34];
        float[] goalHow = new float[34];
        int[] goalBall = new int[34];
        int[] goal0Ball = new int[34];
        int[] goal1Ball = new int[34];
        int[] goalLikeTotal = new int[15];

        int sum = 0;
        int goalSum = 0;

        ArrayList input = new ArrayList();
        //ArrayList alOnly = new ArrayList();
        //ArrayList alRepaet = new ArrayList();
        //ArrayList alThree = new ArrayList();

        for (int i = 1; i < _Arr.Count - MaxCount - 1; i++)
        {
            if (int.Parse(_ArrGoal[i - 1].ToString()) >= _SumGoal)
            {
                string strOne = string.Empty;
                int total = 0;
                int goalTotal = 0;
                int ballTotal = 0;
                str = (string[])_Arr[i];
                int[] sumRedBall = new int[33];

                for (int j = 0; j < 33; j++)
                {
                    for (int x = 0; x <= MaxCount; x++)
                    {
                        totalBall[j, i] += _RedBall[j, i + x];
                    }

                    for (int x = 0; x < _SumHot; x++)
                        sumRedBall[j] += _RedBall[j, i + x];

                    if (totalBall[j, i] >= _Low && totalBall[j, i] <= _High)
                    {
                        total++;
                        if (_RedBall[j, i - 1] > 0)
                        {
                            if (!input.Contains(totalBall[j, i]))
                                input.Add(totalBall[j, i]);
                            haha.InnerHtml += "<span title='" + Convert.ToString(j + 1) + "' style='cursor:hand;float:left; color:red; width:14px; height:12px;border-style:solid;background-color:yellow'>" + totalBall[j, i] + "</span>";
                            goalTotal++;
                            ballTotal += totalBall[j, i];
                            goalBall[totalBall[j, i]]++;

                            if (sumRedBall[j] > 0)
                                goal1Ball[totalBall[j, i]]++;
                            else
                                goal0Ball[totalBall[j, i]]++;
                        }
                        else
                            haha.InnerHtml += "<span title='" + Convert.ToString(j + 1) + "' style='cursor:hand;float:left; color:red; width:14px; height:12px;border-style:groove'>" + totalBall[j, i] + "</span>";
                    }
                    else
                    {
                        if (_RedBall[j, i - 1] > 0)
                        {
                            if (!input.Contains(totalBall[j, i]))
                                input.Add(totalBall[j, i]);
                            ballTotal += totalBall[j, i];
                            goalBall[totalBall[j, i]]++;

                            if (sumRedBall[j] > 0)
                                goal1Ball[totalBall[j, i]]++;
                            else
                                goal0Ball[totalBall[j, i]]++;

                            haha.InnerHtml += "<span title='" + Convert.ToString(j + 1) + "' style='cursor:hand;float:left; color:blue; width:14px; height:12px;border-style:solid;background-color:yellow'>" + totalBall[j, i] + "</span>";
                        }
                        else
                            haha.InnerHtml += "<span title='" + Convert.ToString(j + 1) + "' style='cursor:hand;float:left; color:blue; width:14px; height:12px;border-style:groove'>" + totalBall[j, i] + "</span>";
                    }
                }
                haha.InnerHtml += "<span style='float:left; color:blue; width:50px; height:12px;border-style:groove'>" + ">" + _Low.ToString() + "<" + _High.ToString() + "=" + total + "</span>";
                if (goalTotal == 6)
                    haha.InnerHtml += "<span style='float:left; color:red; width:50px; height:12px;border-style:groove'>" + "命中=" + goalTotal + "</span>";
                else if (goalTotal == 5)
                    haha.InnerHtml += "<span style='float:left; color:black; width:50px; height:12px;border-style:groove'>" + "命中=" + goalTotal + "</span>";
                else
                    haha.InnerHtml += "<span style='float:left; color:blue; width:50px; height:12px;border-style:groove'>" + "命中=" + goalTotal + "</span>";
                haha.InnerHtml += "<span style='float:left; color:blue; width:70px; height:12px;border-style:groove'>" + "合计=" + ballTotal + "</span>";

                strOne = SortChar(input);
                goalLikeTotal[input.Count]++;
                input.Clear();
                //if (!alOnly.Contains(strOne))
                //    alOnly.Add(strOne);
                //else if (!alRepaet.Contains(strOne))
                //    alRepaet.Add(strOne);
                //else
                //    alThree.Add(strOne);
                if (strOne.Length <= 3)
                    haha.InnerHtml += "<span style='float:left; color:red; width:135px; height:12px;border-style:groove'>" + "样式=" + strOne + "</span>";
                else if (strOne.Length == 4)
                    haha.InnerHtml += "<span style='float:left; color:black; width:135px; height:12px;border-style:groove'>" + "样式=" + strOne + "</span>";
                else
                    haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "样式=" + strOne + "</span>";
                haha.InnerHtml += "<span style='float:left; color:blue; width:100px; height:12px;border-style:groove'><a href='GreatBall.aspx?ID=" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "&Like=" + txtMax.Text + "&Color=" + _Low.ToString() + "-" + _High.ToString() + "' target='_blank'>" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "</a></span>";
                haha.InnerHtml += "<br><br>";

                sum += total;
                goalSum += goalTotal;
                abc[total]++;
                goalAbc[goalTotal]++;
                goalTotalBall[ballTotal]++;
            }
        }

        for (int x = 0; x < 33; x++)
            for (int y = 0; y < _Arr.Count; y++)
            {
                if (totalBall[x, y] > 0)
                    blueBall[totalBall[x, y]]++;
            }

        for (int x = 0; x < goalHow.Length; x++)
        {
            if (blueBall[x] > 0 && goalBall[x] > 0)
                goalHow[x] = (float)goalBall[x] / (float)blueBall[x] * 100;
        }

        //alOnly.Sort();
        //alRepaet.Sort();
        double ff =  Convert.ToDouble(goalSum) / Convert.ToDouble(sum);
        double newff = Convert.ToDouble(goalSum) / Convert.ToDouble(6 * (_Arr.Count - MaxCount - 1));
        txtDisplay.Text = ">" + _Low.ToString() + "<" + _High.ToString() + " = " + sum.ToString() + "；命中 = " + goalSum.ToString() + "；百分比 = " + ff.ToString() + "；命中百分比 = " + newff.ToString() + "\n\n";
        
        UpDownGoal(totalBall);

        haha.InnerHtml += TotalDisplay(abc, ">" + _Low.ToString() + "<" + _High.ToString() + "=");
        haha.InnerHtml += TotalDisplay(goalAbc, "命中=");
        haha.InnerHtml += TotalDisplay(goalTotalBall, "合计=");
        haha.InnerHtml += TotalDisplay(blueBall, "blueBall为");
        haha.InnerHtml += TotalDisplay(goalHow, "goal百分比为");
        haha.InnerHtml += TotalDisplay(goalBall, "goal为");
        haha.InnerHtml += TotalDisplay(goal0Ball, "0goal为");
        haha.InnerHtml += TotalDisplay(goal1Ball, "1goal为");
        haha.InnerHtml += TotalDisplay(goalLikeTotal, "样式个数");        
    }

    private void UpDownGoal(int[,] totalBall)
    {
        int find = 30, upTotal = 0, downTotal = 0, sameTotal = 0; ;
        ArrayList al = new ArrayList();

        for (int i = 0; i < _Arr.Count - find - MaxCount; i++)
        {
            int up = 0, down = 0, same = 0;
            txtDisplay.Text += (string)_ArrLine[i] + " ";
            for (int j = 0; j < 33; j++)
            {
                if (_RedBall[j, i] > 0)
                {
                    int first = totalBall[j, i + 1] ;
                    
                    for (int x = 1; x <= find; x++)
                    {
                        if (totalBall[j, i + x] >= first + 2)
                        {
                            down++;
                            break;
                        }
                        else if (totalBall[j, i + x] <= first - 2)
                        {
                            up++;
                            break;
                        }

                        if (x == find)
                            same++;
                    }
                    if (j < 9)
                        txtDisplay.Text += "0" + Convert.ToString(j + 1) + " ";
                    else
                        txtDisplay.Text += Convert.ToString(j + 1) + " ";
                }
            }
            txtDisplay.Text += "UP:" + up.ToString() + " DOWN:" + down.ToString() + " SAME:" + same.ToString() + "\n";
            al.Add(up.ToString() + down.ToString() + same.ToString());
            upTotal += up;
            downTotal += down;
            sameTotal += same;
        }

        txtDisplay.Text += "UPTotal:" + upTotal.ToString() + " DOWNTotal:" + downTotal.ToString() + " SAMETotal:" + sameTotal.ToString() + "\n" 
            + SumArrayList(al, "UpDown组合为：");        
    }

    private string TotalDisplay(float[] abc, string strInput)
    {
        string str = "<br><br>";
        for (int i = 0; i < abc.Length; i++)
        {
            if (abc[i] > 0)
            {
                str += "<span style='float:left; color:blue; width:230px; height:12px;border-style:groove'>" + strInput + i.ToString() + "有百分之" + abc[i].ToString() + "</span>";
            }
        }

        return str;
    }

    private string TotalDisplay(int[] abc, string strInput)
    {
        string str = "<br><br>";
        for (int i = 0; i < abc.Length; i++)
        {
            if (abc[i] > 0)
            {
                str += "<span style='float:left; color:blue; width:140px; height:12px;border-style:groove'>" + strInput + i.ToString() + "有" + abc[i].ToString() + "次</span>";
            }
        }

        return str;
    }
    #endregion

    #region 相邻比较
    protected void btnNext_Click(object sender, EventArgs e)
    {
        //_Arr = ReadFile();

        int[] countSum = new int[31];
        for (int input = 1; input <= 30; input++)
        {
            int count = 0;
            int[] linkSum = new int[6];
            //haha.InnerHtml += "<span style='float:left; color:red; width: 100px; height: 12px;border-style:groove'>" + "相隔为---" + input.ToString() + "：" + "</span><br><br>";
            for (int i = 0; i < _Arr.Count - input; i++)
            {
                string[] strArr = (string[])_Arr[i];
                string[] str = (string[])_Arr[i + input];
                bool found = false;
                ArrayList alFound = new ArrayList();

                found = FoundLike(strArr, str, ref alFound);
                if (found)
                {
                    int total = 0;
                    count++;
                    for (int abc = 0; abc <= input; abc++)
                    {
                        if (abc == 0)
                        {
                            //haha.InnerHtml += "<span style='float:left; color:red; width: 40px; height: 12px;border-style:groove'>" + (string)_ArrLine[i + abc] + "</span>";
                            for (int j = 0; j < strArr.Length; j++)
                            {
                                if (strArr[j].ToString() != string.Empty && FoundLike(str, strArr[j].ToString()))
                                {
                                    //haha.InnerHtml += "<span style='float:left; color:red; width: 16px; height: 12px;border-style:groove'>" + strArr[j].ToString() + "</span>";
                                    total++;
                                }
                                //else
                                //    haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove'>" + strArr[j].ToString() + "</span>";
                            }

                            linkSum[total]++;
                            haha.InnerHtml += "<br><br>";
                        }
                        //else if (abc == input)
                        //{
                        //    haha.InnerHtml += "<span style='float:left; color:red; width: 40px; height: 12px;border-style:groove'>" + (string)_ArrLine[i + abc] + "</span>";
                        //    for (int j = 0; j < str.Length; j++)
                        //    {
                        //        if (str[j].ToString() != string.Empty && FoundLike(strArr, str[j].ToString()))
                        //            haha.InnerHtml += "<span style='float:left; color:red; width: 16px; height: 12px;border-style:groove;border-bottom-color:Blue'>" + str[j].ToString() + "</span>";
                        //        else
                        //            haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove;border-bottom-color:Blue'>" + str[j].ToString() + "</span>";
                        //    }
                        //    haha.InnerHtml += "<br><br>";
                        //}
                        //else
                        //{
                        //    string[] strMiddle = (string[])_Arr[i + abc];
                        //    for (int j = 0; j < strMiddle.Length; j++)
                        //    {
                        //        haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove'>" + strMiddle[j].ToString() + "</span>";
                        //    }
                        //}

                    }
                }
            }

            txtDisplay.Text += "\n" + "相邻比较结果，相邻" + input.ToString() + "个结果为：" + count.ToString();
            countSum[input] = count;
            for (int i = 0; i < linkSum.Length; i++)
            {
                if (linkSum[i] != 0)
                    txtDisplay.Text += "\n相同为" + i.ToString() + "个的有：" + linkSum[i].ToString();
            }
        }

        int max = 0;
        for (int i = 0; i < countSum.Length - 1; i++)
        {
            if (countSum[i] + countSum[i + 1] > max)
            {
                max = countSum[i] + countSum[i + 1];
                txtMax.Text = i.ToString() + "|" + Convert.ToString(i + 1);
            }
        }

    }

    protected void btnLook_Click(object sender, EventArgs e)
    {
        string[] strNow = new string[6];   
        //_Arr = ReadFile();

        int one = int.Parse(txtMax.Text.Split('|')[0]);
        int two = int.Parse(txtMax.Text.Split('|')[1]);

        for (int input = one; input <= two; input++)
        {
            int count = 0;
            int[] linkSum = new int[6];
            haha.InnerHtml += "<span style='float:left; color:red; width: 100px; height: 12px;border-style:groove'>" + "相隔为---" + input.ToString() + "：" + "</span><br><br>";
            for (int i = 0; i < _Arr.Count - input; i++)
            {
                string[] strArr = (string[])_Arr[i];
                string[] str = (string[])_Arr[i + input];
                bool found = false;
                ArrayList alFound = new ArrayList();


                found = FoundLike(strArr, str, ref alFound);
                if (found)
                {
                    int total = 0;
                    count++;
                    for (int abc = 0; abc <= input; abc++)
                    {
                        if (abc == 0)
                        {        
                            int strNowCount = 0;
                            int num = 0;
                            haha.InnerHtml += "<span style='float:left; color:red; width: 40px; height: 12px;border-style:groove'>" + (string)_ArrLine[i] + "</span>";
                            for (int j = 0; j < strArr.Length; j++)
                            {
                                if (strArr[j].ToString() != string.Empty && FoundLike(str, strArr[j].ToString()))
                                {
                                    haha.InnerHtml += "<span style='float:left; color:red; width: 16px; height: 12px;border-style:groove'>" + strArr[j].ToString() + "</span>";
                                    total++;
                                }
                                else
                                    haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove'>" + strArr[j].ToString() + "</span>";

                                if (strArr[j].ToString() != string.Empty)
                                {
                                    strNow[strNowCount] = strArr[j];
                                    num += int.Parse(strNow[strNowCount]);
                                    strNowCount++;
                                }
                            }
                            int sub = int.Parse(strNow[5]) - int.Parse(strNow[0]);
                            
                            haha.InnerHtml += "<span style='float:left; width: 60px; height: 12px;border-style:groove'>" + "首尾" + sub.ToString() + "</span>";
                            haha.InnerHtml += "<span style='float:left; width: 60px; height: 12px;border-style:groove'>" + "总和" + num.ToString() + "</span>";

                            linkSum[total]++;
                            if(_ArrLine.Count > i + 30)
                                haha.InnerHtml += "<span style='float:left; color:blue; width:100px; height:12px;border-style:groove'><a href='GreatBall.aspx?ID=" + _ArrLine[i].ToString() + "-" + _ArrLine[i + 30] + "&Like=" + txtMax.Text + "&Color=" + "4-7" + "' target='_blank'>" + _ArrLine[i].ToString() + "-" + _ArrLine[i + 30] + "</a></span>";
                            haha.InnerHtml += "<br><br>";
                        }
                        else if (abc == input)
                        {
                            int strNowCount = 0;
                            int num = 0;
                            haha.InnerHtml += "<span style='float:left; color:red; width: 40px; height: 12px;border-style:groove'>" + (string)_ArrLine[i + abc] + "</span>";
                            for (int j = 0; j < str.Length; j++)
                            {
                                if (str[j].ToString() != string.Empty && FoundLike(strArr, str[j].ToString()))
                                    haha.InnerHtml += "<span style='float:left; color:red; width: 16px; height: 12px;border-style:groove;border-bottom-color:Blue'>" + str[j].ToString() + "</span>";
                                else
                                    haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove;border-bottom-color:Blue'>" + str[j].ToString() + "</span>";
                                if (str[j].ToString() != string.Empty)
                                {
                                    strNow[strNowCount] = str[j];
                                    num += int.Parse(strNow[strNowCount]);
                                    strNowCount++;
                                }
                            }
                            int sub = int.Parse(strNow[5]) - int.Parse(strNow[0]);

                            haha.InnerHtml += "<span style='float:left; width: 60px; height: 12px;border-style:groove'>" + "首尾" + sub.ToString() + "</span>";
                            haha.InnerHtml += "<span style='float:left; width: 60px; height: 12px;border-style:groove'>" + "总和" + num.ToString() + "</span>";

                            haha.InnerHtml += "<br><br>";
                        }
                        //else
                        //{
                        //    string[] strMiddle = (string[])_Arr[i + abc];
                        //    for (int j = 0; j < strMiddle.Length; j++)
                        //    {
                        //        haha.InnerHtml += "<span style='float:left; width: 16px; height: 12px;border-style:groove'>" + strMiddle[j].ToString() + "</span>";
                        //    }
                        //}

                    }
                }
            }

            txtDisplay.Text += "\n" + "相邻比较结果，相邻" + input.ToString() + "个结果为：" + count.ToString();
            
            for (int i = 0; i < linkSum.Length; i++)
            {
                if (linkSum[i] != 0)
                    txtDisplay.Text += "\n相同为" + i.ToString() + "个的有：" + linkSum[i].ToString();
            }
        }
    }
    #endregion

    #region 热度分析
    protected void btnHot_Click(object sender, EventArgs e)
    {
        //_Arr = ReadFile();
        
        for (int i = 1; i < 30; i++)
        {
            txtDisplay.Text += i.ToString() + "期比较结果：\n" + HotAnalysis(_Arr, _RedBall, i);
        }

    }
    protected void btnHotLook_Click(object sender, EventArgs e)
    {
        //_Arr = ReadFile();
        
        haha.InnerHtml += HotAnalysisHtml(_Arr, _RedBall, int.Parse(txtHot.Text), _ArrLine);

    }
    private double Combination(int big, int small)
    {
        return Combination(big) / Combination(small) / Combination(big - small);
    }

    private double Combination(int num)
    {
        double combin = 1;
        for (int i = 1; i <= num; i++)
        {
            combin = combin * i;
        }
        
        return combin;
    }
    private string HotAnalysisHtml(ArrayList arr, int[,] redBall, int sum, ArrayList arrLine)
    {
        int[] count = new int[sum + 1];
        int[] countGoal = new int[sum + 1];
        int[] sumGoal = new int[7];

        string returnStr = string.Empty;
        for (int i = 1; i < arr.Count - MaxCount - 1; i++)
        {
            int total = 0;
            int goal = 0;
            int[] sumRedBall = new int[33];
            int five = 0;
            returnStr += "<span style='float:left; color:red; width: 40px; height: 12px;border-style:groove'>" + (string)arrLine[i - 1] + "</span>";
            for (int j = 0; j < 33; j++)
            {
                for (int x = 0; x < sum; x++)
                    sumRedBall[j] += redBall[j, i + x];

                count[sumRedBall[j]]++;

                if (sumRedBall[j] > 0)
                {
                    total++;
                    if (redBall[j, i - 1] > 0)
                    {
                        countGoal[sumRedBall[j]]++;
                        five++;
                        goal++;
                        returnStr += "<span style='float:left; color:red; width: 16px; height: 12px;border-style:groove;border-color:yellow'>" + sumRedBall[j].ToString() + "</span>";
                    }
                    else
                        returnStr += "<span style='float:left; color:red; width: 16px; height: 12px;border-style:groove'>" + sumRedBall[j].ToString() + "</span>";
                }
                else if (redBall[j, i - 1] > 0)
                {
                    countGoal[sumRedBall[j]]++;
                    returnStr += "<span style='float:left; color:blue; width: 16px; height: 12px;border-style:groove;border-color:yellow'>0</span>";
                }
                else
                    returnStr += "<span style='float:left; color:blue; width: 16px; height: 12px;border-style:groove'>0</span>";
            }

            returnStr += "<span style='float:left; color:blue; width:60px; height:12px;border-style:groove'>" + "包含=" + total.ToString() + "</span>";
            if (five >= 5)
            {                
                if (five == 5)
                    returnStr += "<span style='float:left; color:black; width:50px; height:12px;border-style:groove'>" + "命中=" + goal.ToString() + "</span>"; 
                else
                    returnStr += "<span style='float:left; color:red; width:50px; height:12px;border-style:groove'>" + "命中=" + goal.ToString() + "</span>"; 
            }
            else
                returnStr += "<span style='float:left; color:blue; width:50px; height:12px;border-style:groove'>" + "命中=" + goal.ToString() + "</span>";
            returnStr += "<span style='float:left; color:blue; width:100px; height:12px;border-style:groove'><a href='GreatBall.aspx?ID=" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "&Like=" + txtMax.Text + "&Color=" + _Low.ToString() + "-" + _High.ToString() + "' target='_blank'>" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "</a></span>";
            returnStr += "<br><br>";

            sumGoal[goal]++;
        }

        returnStr += TotalDisplay(count, "样式个数");
        returnStr += TotalDisplay(countGoal, "命中个数");
        returnStr += TotalDisplay(sumGoal, "命中总数");
        return returnStr;
    }

    private string HotAnalysis(ArrayList arr, int[,] redBall, int sum)
    {
        int total = 0;
        int goal = 0;
        int countFive = 0;
        int countSix = 0;
        for (int i = 1; i < arr.Count - sum - 1; i++)
        {
            int[] sumRedBall = new int[33];
            int five = 0;

            for (int j = 0; j < 33; j++)
            {
                for (int x = 0; x < sum; x++)
                    sumRedBall[j] += redBall[j, i + x];

                if (sumRedBall[j] > 0) total++;
                if (sumRedBall[j] > 0 && redBall[j, i - 1] > 0)
                {
                    five++;
                    goal++;
                }
            }

            if (five >= 5)
            {
                countFive++;
                if (five > 5)
                    countSix++;
            }
        }

        double average = Convert.ToDouble(goal) / Convert.ToDouble(total);
        double averageGoal = Convert.ToDouble(goal) / Convert.ToDouble(arr.Count - sum - 1);
        double averageTotal = Convert.ToDouble(total) / Convert.ToDouble(arr.Count - sum - 1);

        double combin = Combination(Convert.ToInt32(averageTotal), 6);
        double averageFive = Convert.ToDouble(countFive) / combin;
        double averageSix = Convert.ToDouble(countSix) / combin;
        
        return "    包含：" + total.ToString() + "  命中：" + goal.ToString() + "  命中比率：" + average.ToString() + "\n" 
            + "    平均包含：" + averageTotal.ToString() + "  平均命中：" + averageGoal.ToString() + "  包含组合：" + combin.ToString() + "\n"
            + "    命中超五：" + countFive.ToString() + "  平均超五：" + averageFive.ToString() + "\n"
            + "    命中超六：" + countSix.ToString() + "  平均超六：" + averageSix.ToString() + "\n";
    }
    #endregion

    #region SELECT
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        Response.Write("<script> window.open('GreatBall.aspx?ID=select&Like=" + txtMax.Text + "&Color=" + _Low.ToString() + "-" + _High.ToString() + "')</script>");
    }
    #endregion

    #region Graph
    protected void btnGraph_Click(object sender, EventArgs e)
    {        
        //Response.Write("<script> window.open('Graph.aspx')</script>");
        ArrayList al = new ArrayList();

        al.Add(10);
        al.Add(20);
        al.Add(30);
        al.Add(40);
        al.Add(50);
        al.Add(60);

        txtDisplay.Text += StDevInput(al) + "\n";

        al.Add(70);
        al.Add(80);
        al.Add(90);

        txtDisplay.Text += StDevInput(al) + "\n";

        al.Add(40);
        al.Add(50);
        al.Add(60);

        txtDisplay.Text += StDevInput(al) + "\n";
    }

    private void SetGraphSession(ArrayList alNormal, ArrayList alSpecial, ArrayList alYStr, ArrayList alToGreatBall, string area)
    {
        Session["Normal"] = alNormal;
        Session["Special"] = alSpecial;
        Session["Y_Str"] = alYStr;
        Session["Area"] = area;
        Session["ToGreatBall"] = alToGreatBall;
    }
    #endregion

    #region SORT
    protected void btnSort_Click(object sender, EventArgs e)
    {        
        //int sum = int.Parse(txtHot.Text);
        //int high = GetHighSelectItem();
        //int low = GetLowSelectItem();
        int[] totalFind = new int[33];
        int[] totalFinsSame = new int[33];
        ArrayList alMyHope = new ArrayList();
        ArrayList alSimple = new ArrayList();
        ArrayList alSimpleFind = new ArrayList();
        ArrayList alSimpleSF = new ArrayList();
        ArrayList alBegin = new ArrayList();
        ArrayList alEnd = new ArrayList();
        ArrayList alBeginEnd = new ArrayList();

        
        for (int i = 1; i < _Arr.Count - MaxCount - 1; i++)
        {
            if (int.Parse(_ArrGoal[i - 1].ToString()) >= _SumGoal)
            {
                string[] str = (string[])_Arr[i - 1];
                int[] totalBall = new int[33];
                int[] sumRedBall = new int[33];
                int count = 0;
                ArrayList input = new ArrayList();
                ArrayList inputSimple = new ArrayList();
                ArrayList alFind = new ArrayList();
                ArrayList arrNoEmtpy = new ArrayList();
                string strFind = string.Empty;
                string strSimpleFind = string.Empty;

                haha.InnerHtml += "<span style='float:left; color:red; width: 100px; height: 12px;border-style:groove'>" + (string)_ArrLine[i - 1] + "中" + _ArrGoal[i - 1].ToString() + "注" + "</span>";
                for (int j = 0; j < str.Length; j++)
                {
                    for (int x = 0; x <= MaxCount; x++)
                        totalBall[j] += _RedBall[j, i + x];

                    for (int x = 0; x < _SumHot; x++)
                        sumRedBall[j] += _RedBall[j, i + x];

                    if (str[j] != "")
                    {
                        arrNoEmtpy.Add(str[j]);

                        input.Add(totalBall[j]);
                        inputSimple.Add(SimpleInput(totalBall[j]));

                        haha.InnerHtml += "<span style='float:left; color:blue; width: 16px; height: 12px;border-style:groove'>" + str[j] + "</span>";
                        int find = FindLastBall(_RedBall, j, i - 1);
                        alFind.Add(find);
                        totalFind[find]++;

                        if (totalBall[j] >= _Low && totalBall[j] <= _High && sumRedBall[j] > 0)
                            count++;
                    }
                }

                alBegin.Add(arrNoEmtpy[0].ToString());
                alEnd.Add(arrNoEmtpy[5].ToString());
                alBeginEnd.Add(BeginEndInput(arrNoEmtpy[0].ToString()) + "_" + BeginEndInput(arrNoEmtpy[5].ToString()));

                if (count == 6)
                    alMyHope.Add((string)_ArrLine[i - 1]);

                alFind.Sort();
                for (int j = 0; j < alFind.Count; j++)
                {
                    strFind += alFind[j].ToString() + " ";
                    strSimpleFind += SimpleLastSame((int)alFind[j]);
                }

                string strFindSame = FindSameRegion(_RedBall, str, _SumHot, i - 1);

                string[] findSame = strFindSame.Trim().Split(' ');
                for (int j = 0; j < findSame.Length; j++)
                {
                    if (findSame[j] != "")
                        totalFinsSame[int.Parse(findSame[j])]++;
                }

                string strSimple = SortChar(inputSimple);

                alSimple.Add(strSimple);
                alSimpleFind.Add(strSimpleFind);

                if (strSimple.Contains("7777") && strSimpleFind.Contains("1111"))
                    alSimpleSF.Add(strSimple + strSimpleFind);

                haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "样式=" + SortChar(input) + "</span>";
                haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "简单样式=" + strSimple + "</span>";
                haha.InnerHtml += "<span style='float:left; color:blue; width:180px; height:12px;border-style:groove'>" + "上个=" + strFind + "</span>";
                haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "简单上个=" + strSimpleFind + "</span>";
                haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "开始结束=" + arrNoEmtpy[0].ToString() + "_" + arrNoEmtpy[5].ToString() + "</span>";
                //haha.InnerHtml += "<span style='float:left; color:blue; width:300px; height:12px;border-style:groove'>" + "命中区域=" + strFindSame + "</span>";
                haha.InnerHtml += "<span style='float:left; color:blue; width:100px; height:12px;border-style:groove'><a href='GreatBall.aspx?ID=" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "&Like=" + txtMax.Text + "&Color=" + _Low.ToString() + "-" + _High.ToString() + "' target='_blank'>" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "</a></span>";
                haha.InnerHtml += "<br><br>";
            }
        }

        for (int i = 0; i < totalFind.Length; i++)
        {
            if (totalFind[i] > 0)
                txtDisplay.Text += "上一个为 " + i.ToString() + " 期之外的发生过 " + totalFind[i].ToString() + "次\n";
        }

        txtDisplay.Text += SumArrayList(alSimple, "简单样式为 ");

        txtDisplay.Text += SumArrayList(alSimpleFind, "简单上个为 ");

        txtDisplay.Text += SumArrayList(alSimpleSF, "简单综合统计为 ");

        txtDisplay.Text += SumArrayList(alBegin, "第一统计为 ");

        txtDisplay.Text += SumArrayList(alEnd, "最后统计为 ");

        txtDisplay.Text += SumArrayList(alBeginEnd, "首尾综合统计为 ");

        txtDisplay.Text += "\n";
        for (int i = 0; i < totalFinsSame.Length; i++)
        {
            if (totalFinsSame[i] > 0)
                txtDisplay.Text += "命中区域为 " + i.ToString() + " 期附近的发生过 " + totalFinsSame[i].ToString() + "次\n";
        }

        txtDisplay.Text += "\n";
        for (int i = 0; i < alMyHope.Count; i++)
        {
            txtDisplay.Text += "满足--小于" + _High.ToString() + "大于" + _Low.ToString() + " 在" + _SumHot.ToString() + "期内出现--条件的期数为" + alMyHope[i].ToString() + "\n";
        }
    }

    private string SumArrayList(ArrayList alSimple, string strInput)
    {
        alSimple.Sort();
        string strSimple = alSimple[0].ToString();
        int countSimple = alSimple.Count;
        string str = "\n";

        while (alSimple.Count > 0)
        {
            if (alSimple.Contains(strSimple))
            {
                alSimple.Remove(strSimple);
            }
            else
            {
                str += strInput + strSimple + " 的发生过 " + Convert.ToString(countSimple - alSimple.Count) + "次\n";
                strSimple = alSimple[0].ToString();
                countSimple = alSimple.Count;
            }
        }

        str += strInput + strSimple + " 的发生过 " + Convert.ToString(countSimple - alSimple.Count) + "次\n";

        return str;
    }

    private string BeginEndInput(string input)
    {
        string back = string.Empty;

        switch (input)
        {
            case "01":
            case "02":
            case "03":
            case "04":
            case "05":
                back = "05";
                break;
            case "06":
            case "07":
            case "08":
            case "09":
            case "10":
                back = "10";
                break;
            case "11":
            case "12":
            case "13":
            case "14":
            case "15":
                back = "15";
                break;
            case "16":
            case "17":
            case "18":
            case "19":
            case "20":
                back = "20";
                break;
            case "21":
            case "22":
            case "23":
            case "24":
            case "25":
                back = "25";
                break;
            case "26":
            case "27":
            case "28":
            case "29":
            case "30":
                back = "30";
                break;
            default:
                back = "33";
                break;
        }

        return back;
    }

    private int SimpleInput(int input)
    {
        int back = 0;
        switch (input)
        {
            case 0:
            case 1:
            case 2:                 
            case 3:
                back = 3;
                break;
            case 4:
            case 5:
            case 6:
            case 7:
                back = 7;
                break;
            case 8:
            default:
                back = 9;
                break;
        }
        return back;
    }

    private string SimpleLastSame(int input)
    {
        int back = 0;
        switch (input)
        {
            case 0:
            case 1:
            case 2:
            case 3:                
            case 4:
            case 5:
            case 6:            
            case 7:
            case 8:   
                back = 1;
                break;
            //case 9:

            //case 10:
            //case 11:
            //case 12:
            //    back = 2;
            //    break;     
            default:
                back = 2;
                break;
        }
        return back.ToString();
    }

    private string FindSameRegion(int[,] totalBall, string[] str, int sum, int begin)
    {
        string returnStr = string.Empty;

        for (int i = 1; i < MaxCount - sum - 1; i++)
        {
            int[] totalSum = new int[33];

            for (int j = 0; j < 33; j++)
                for (int x = 0; x < sum; x++)
                    totalSum[j] += totalBall[j, begin + i + x];

            if (FindSame(totalSum, str))
                returnStr += i.ToString() + " ";
        }

        return returnStr;
    }

    private bool FindSame(int[] input, string[] str)
    {
        bool find = false;
        int count = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != "" && input[i] > 0)
                count++;
            if (count == 5)
            {
                find = true;
                break;
            }
        }
        
        return find;
    }

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

    #region Split

    protected void btnSplitSum_Click(object sender, EventArgs e)
    {
        ArrayList input = new ArrayList();

        for (int i = 0; i < _Arr.Count; i++)
        {
            string[] str = (string[])_Arr[i];
            int sum = 0;

            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] != "")
                    sum += int.Parse(str[j]);
            }

            input.Add(sum);
        }

        DisplaySplit(input, 2);
    }

    protected void btnSplitGoal_Click(object sender, EventArgs e)
    {
        DisplaySplit(_ArrGoal, 2);
    }

    protected void btnSplitHead_Click(object sender, EventArgs e)
    {
        ArrayList input = new ArrayList();

        for (int i = 0; i < _Arr.Count; i++)
        {
            string[] str = (string[])_Arr[i];
            int begin = 0;
            int count = 0;

            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] != "")
                {
                    count++;
                    if (count == 1)
                        begin = int.Parse(str[j]);
                    if (count == 6)
                    {
                        begin = int.Parse(str[j]) - begin;
                        break;
                    }
                }
            }

            input.Add(begin);
        }

        DisplaySplit(input, 2);
    }

    private void DisplaySplit(ArrayList al, int begin)
    {
        for (int i = MaxSplit; i >= begin; i--)
        {
            //int count = 0;            
            int sumAvarage = 0;
            ArrayList alInput = new ArrayList();
            for (int j = 0; j < al.Count; j++)
            {
                int sum = 0;
                if (j + i <= al.Count)
                {
                    for (int x = j; x < j + i; x++)
                    {
                        sum += int.Parse(al[x].ToString());
                    }
                    
                    //alInput.Add((float)sum / (float)i);
                    sumAvarage += sum;
                    alInput.Add(sum);
                }
                
                //sumAvarage += int.Parse(al[j].ToString());

                //if (count != i)
                //{
                //    sum += int.Parse(al[j].ToString());
                //    count++;
                //}
                //else
                //{
                //    sumAvarage += sum;
                //    alInput.Add((float)sum / (float)i);
                //    sum = int.Parse(al[j].ToString());
                //    count = 1;
                //}
            }           
            float average = (float)sumAvarage / (float)(al.Count - i + 1);
            //float average = (float)sumAvarage / (float)(al.Count);
            string strStDev = StDevInput(alInput);
            float aveStDev = float.Parse(strStDev) / average;
            txtDisplay.Text += "\n    当每" + i.ToString() + "个为一层时，标准差为：" + strStDev + "；平均标准差为：" + aveStDev.ToString() + "；平均值为：" + average.ToString() + "\n";

            //for (int j = 0; j < alInput.Count; j++)
            //{
            //    if ((j != 0 && j % 6 == 0) || (j == alInput.Count - 1))
            //        txtDisplay.Text += "当前值：" + alInput[j].ToString() + "\n";
            //    else
            //        txtDisplay.Text += "当前值：" + alInput[j].ToString() + "；";
            //}
        }
    }

    private string StDevInput(ArrayList alInput)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("input", typeof(int));
        for (int i = 0; i < alInput.Count; i++)
        {
            DataRow dRow = dt.NewRow();
            dRow["input"] = float.Parse(alInput[i].ToString());            
            dt.Rows.Add(dRow);
        }
        object rt = dt.Compute("StDev(input)", "true");
        return rt.ToString();
    }
    
    protected void btnSplit_Click(object sender, EventArgs e)
    {
        int sumGoal = 0, headGoal = 0, goalSumHead = 0;
        bool sumBool = false;

        for (int i = 1; i < _Arr.Count - MaxCount - 1; i++)
        {
            string[] str = (string[])_Arr[i - 1];

            haha.InnerHtml += "<span style='float:left; color:red; width: 100px; height: 12px;border-style:groove'>" + (string)_ArrLine[i - 1] + "中" + _ArrGoal[i - 1].ToString() + "注" + "</span>";
            int sum = 0, head = 0;
            int begin = 0;
            int count = 0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] != "")
                {
                    haha.InnerHtml += "<span style='float:left; color:blue; width: 16px; height: 12px;border-style:groove'>" + str[j] + "</span>";
                    sum += int.Parse(str[j]);
                    count++;
                    if (count == 1)
                        begin = int.Parse(str[j]);
                    if (count == 6)
                    {
                        head += int.Parse(str[j]) - begin;
                        break;
                    }
                }
            }
            haha.InnerHtml += "<span style='float:left; color:blue; width:80px; height:12px;border-style:groove'>" + "总和=" + sum.ToString() + "</span>";
            haha.InnerHtml += "<span style='float:left; color:blue; width:80px; height:12px;border-style:groove'>" + "首尾=" + head.ToString() + "</span>";
            int splitSum = 0, splitHead = 0;
            if (i + 29 < _Arr.Count)
            {
                for (int y = 0; y < 29; y++)
                {
                    string[] strNew = (string[])_Arr[i + y];
                    begin = 0;
                    count = 0;
                    for (int x = 0; x < strNew.Length; x++)
                    {
                        if (strNew[x] != "")
                        {
                            splitSum += int.Parse(strNew[x]);
                            count++;
                            if (count == 1)
                                begin = int.Parse(strNew[x]);
                            if (count == 6)
                            {
                                splitHead += int.Parse(strNew[x]) - begin;
                                break;
                            }
                        }
                    }
                }
            }

            float averageSum = (float)splitSum / (float)29;
            float averageHead = (float)splitHead / (float)29;

            haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "平均总和=" + txtSplitSum.Text + "</span>";
            haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "平均首尾=" + txtSplitHead.Text + "</span>";

            if ((averageSum > float.Parse(txtSplitSum.Text) && sum < float.Parse(txtSplitSum.Text)) || (averageSum < float.Parse(txtSplitSum.Text) && sum > float.Parse(txtSplitSum.Text)))
            {
                haha.InnerHtml += "<span style='float:left; color:red; width:135px; height:12px;border-style:groove'>" + "29总和=" + averageSum.ToString() + "</span>";
                sumBool = true;
                sumGoal++;
            }
            else
                haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "29总和=" + averageSum.ToString() + "</span>";

            if ((averageHead > float.Parse(txtSplitHead.Text) && head < float.Parse(txtSplitHead.Text)) || (averageHead < float.Parse(txtSplitHead.Text) && head > float.Parse(txtSplitHead.Text)))
            {
                haha.InnerHtml += "<span style='float:left; color:red; width:135px; height:12px;border-style:groove'>" + "29首尾=" + averageHead.ToString() + "</span>";
                headGoal++;
                if (sumBool)
                {
                    goalSumHead++;
                }
            }
            else
                haha.InnerHtml += "<span style='float:left; color:blue; width:135px; height:12px;border-style:groove'>" + "29首尾=" + averageHead.ToString() + "</span>";

            sumBool = false;

            haha.InnerHtml += "<span style='float:left; color:blue; width:90px; height:12px;border-style:groove'><a href='GreatBall.aspx?ID=" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "&Like=" + txtMax.Text + "&Color=" + _Low.ToString() + "-" + _High.ToString() + "' target='_blank'>" + _ArrLine[i - 1].ToString() + "-" + _ArrLine[i + MaxCount] + "</a></span>";
            haha.InnerHtml += "<br><br>";
        }

        txtDisplay.Text = "总和Goal：" + sumGoal.ToString() + "首尾Goal：" + headGoal.ToString() + "；goalSumHead：" + goalSumHead.ToString();
    } 

    #endregion

    #region OneOne
    private void StDevOneOne(int i, ref int sum, ref int countStDev, ref int[] sumNum, ArrayList alAll, ArrayList alNormal, ArrayList alToGreatBall)
    {
        string stDev = "";
        int count = 0;
        ArrayList al = new ArrayList();

        for (int j = 0; j < _Arr.Count; j++)
        {

            if (_RedBall[i, j] == 1)
            {
                //if (al.Count == 0 && j == 0)
                //    al.Add(1);
                //else if (al.Count == 0)
                //    count++;

                if (j != 0)
                    sumNum[count]++;

                al.Add(count);
                alAll.Add(count);
                sum += count;
                count = 0;
            }
            else
                count++;
        }        

        ArrayList alStDevNormal = new ArrayList();
        ArrayList alAverNormal = new ArrayList();
        for (int x = 0; x < 40; x++)
        {
            float average = (float)sum / (float)al.Count;
            stDev = StDevInput(al);
            txtDisplay.Text += "数字" + Convert.ToString(i + 1) + "的标准差为：" + stDev + "；当前值为：" + al[0].ToString() + "；平均值为：" + average.ToString() + "；总数为：" + al.Count.ToString() + "\n";

            if (stDev == string.Empty)
                stDev = "0";
            alStDevNormal.Add(stDev);
            alAverNormal.Add(average);

            //sum = sum - (int)al[0];
            al.RemoveAt(0);
        }
        alNormal.Add(alStDevNormal);
        alNormal.Add(alAverNormal);
        txtDisplay.Text += "\n";
        
        for (int x = 0; x < alStDevNormal.Count - 1; x++)
        {
            if (float.Parse(alStDevNormal[x].ToString()) > float.Parse(alStDevNormal[x + 1].ToString()))// && float.Parse(alStDevNormal[x + 1].ToString()) > float.Parse(alStDevNormal[x + 2].ToString()))
            {
                txtDisplay.Text += "↑ ";
                if (x == 0)
                {
                    haha.InnerHtml += "<span style='float:left; color:blue; width:200px; height:12px;border-style:groove'>平均的标准差为正：" + Convert.ToString(i + 1) + "</span><br><br>";                    
                }
            }
            else if (float.Parse(alStDevNormal[x].ToString()) < float.Parse(alStDevNormal[x + 1].ToString()))// && float.Parse(alStDevNormal[x + 1].ToString()) < float.Parse(alStDevNormal[x + 2].ToString()))
            {
                txtDisplay.Text += "↓ ";
                countStDev++;
                if (x == 0)
                {
                    haha.InnerHtml += "<span style='float:left; color:blue; width:200px; height:12px;border-style:groove'>平均的标准差为负：" + Convert.ToString(i + 1) + "</span><br><br>";
                    alToGreatBall.Add(i);
                }
            }
        }

        txtDisplay.Text += "\n↓:" + countStDev.ToString() + "次;↑:" + Convert.ToString(alStDevNormal.Count - 1 - countStDev) + "次\n";
    }

    private void StDevOneOne(int i)
    {
        int sum = 0, countStDev = 0;
        string stDev = "";
        int count = 0;
        ArrayList al = new ArrayList();

        for (int j = 0; j < _Arr.Count; j++)
        {

            if (_RedBall[i, j] == 1)
            {
                //if (al.Count == 0 && j == 0)
                //    al.Add(1);

                al.Add(count);
                sum += count;
                count = 0;
            }
            else
                count++;
        }

        ArrayList alStDevNormal = new ArrayList();
        ArrayList alAverNormal = new ArrayList();
        for (int x = 0; x < 40; x++)
        {
            float average = (float)sum / (float)al.Count;
            stDev = StDevInput(al);
            txtDisplay.Text += "数字" + Convert.ToString(i + 1) + "的标准差为：" + stDev + "；当前值为：" + al[0].ToString() + "；平均值为：" + average.ToString() + "；总数为：" + al.Count.ToString() + "\n";

            if (stDev == string.Empty)
                stDev = "0";
            alStDevNormal.Add(stDev);
            alAverNormal.Add(average);

            sum = sum - (int)al[0];
            al.RemoveAt(0);
        }
        txtDisplay.Text += "\n";

        for (int x = 0; x < alStDevNormal.Count - 1; x++)
        {
            if (float.Parse(alStDevNormal[x].ToString()) > float.Parse(alStDevNormal[x + 1].ToString()))// && float.Parse(alStDevNormal[x + 1].ToString()) > float.Parse(alStDevNormal[x + 2].ToString()))
            {
                txtDisplay.Text += "↑ ";
                if (x == 0)
                {
                    haha.InnerHtml += "<span style='float:left; color:blue; width:200px; height:12px;border-style:groove'>平均的标准差为正：" + Convert.ToString(i + 1) + "</span><br><br>";

                }
            }
            else if (float.Parse(alStDevNormal[x].ToString()) < float.Parse(alStDevNormal[x + 1].ToString()))// && float.Parse(alStDevNormal[x + 1].ToString()) < float.Parse(alStDevNormal[x + 2].ToString()))
            {
                txtDisplay.Text += "↓ ";
                countStDev++;
                if (x == 0)
                {
                    haha.InnerHtml += "<span style='float:left; color:blue; width:200px; height:12px;border-style:groove'>平均的标准差为负：" + Convert.ToString(i + 1) + "</span><br><br>";

                }
            }
        }

        txtDisplay.Text += "\n↓:" + countStDev.ToString() + "次;↑:" + Convert.ToString(alStDevNormal.Count - 1 - countStDev) + "次\n";
    }

    protected void btnNumber_Click(object sender, EventArgs e)
    {
        int sumStDev = 0;
        int sumAll = 0;
        int[] sumNum = new int[50];
        string stDev = "";
        ArrayList alAll = new ArrayList();
        ArrayList alNormal = new ArrayList();
        ArrayList alSpecial = new ArrayList();
        ArrayList alYStr = new ArrayList();
        ArrayList alToGreatBall = new ArrayList();

        for (int i = 0; i < 33; i++)
        {
            int sum = 0;
            int countStDev = 0;

            StDevOneOne(i, ref sum, ref countStDev, ref sumNum, alAll, alNormal, alToGreatBall);

            sumAll += sum;
            sumStDev += countStDev;
        }

        txtDisplay.Text += "\n合计↓:" + sumStDev.ToString() + "次\n";

        float averageAll = (float)sumAll / (float)alAll.Count;
        stDev = StDevInput(alAll);

        SetGraphSession(alNormal, alSpecial, alYStr, alToGreatBall, "0_" + stDev + "_" + averageAll + "_10");
        haha.InnerHtml += "<span style='float:left; color:blue; width:600px; height:12px;border-style:groove'>平均的标准差为：" + stDev + "；平均值为：" + averageAll.ToString() + "；总数为：" + alAll.Count.ToString() + "</span>";
        haha.InnerHtml += "<br><br><span style='float:left; color:blue; width:100px; height:12px;border-style:groove'><a href='Graph.aspx' target='_blank'>显示图形</a></span>";
        haha.InnerHtml += "<br><br>" + TotalDisplay(sumNum, "间隔为");
    }

    protected void btnOneOne_Click(object sender, EventArgs e)
    {
        if (listBNum.SelectedValue != "")
        {
            int select = int.Parse(listBNum.SelectedValue) - 1;
            int[,] oneOne = new int[33, _Arr.Count];
            int[,] oneColor = new int[33, _Arr.Count];
            int[] sumColor = new int[40];

            oneOne = CreateColor(oneOne, select);

            StDevOneOne(select);

            for (int i = _Arr.Count - 1; i > -1; i--)
            {
                string color = FindColor(oneOne, select, i);

                if (color == "red" || color == "blue")
                {
                    if (color == "red")
                    {
                        oneColor[select, i] = 0;
                    }
                    else
                        oneColor[select, i] = 1;
                }
                else
                    oneColor[select, i] = 2;

                haha.InnerHtml += "<span style='cursor:hand;float:left; color:" + color + "; width:50px; height:12px;border-style:groove'>" + (string)_ArrLine[i] + "</span>";
                haha.InnerHtml += "<span style='cursor:hand;float:left; color:" + color + "; width:15px; height:12px;border-style:groove'>" + _RedBall[select, i] + "</span>";
            }

            string str = String.Empty;
            sumColor = FindOneHowColor(oneColor, sumColor, select, ref str);

            txtDisplay.Text += str;
            haha.InnerHtml += TotalDisplay(sumColor, "颜色为");
        }
    }

    private int[,] CreateColor(int[,] oneOne, int select)
    {
        int count = 0;
        int myColor = 0;
        for (int i = _Arr.Count - 1; i > -1; i--)
        {
            //txtDisplay.Text += _RedBall[select, i].ToString();
            if (_RedBall[select, i] == 1 || i == 0)
            {
                if (_RedBall[select, i] == 0)
                    count++;

                if (count <= 1)
                {
                    myColor = 2;
                }
                else if (count <= 4)
                {
                    myColor = 3;
                }
                else
                {
                    myColor = 4;
                }

                if (_RedBall[select, i] == 1)
                    oneOne[select, i] = 1;
                else
                {
                    oneOne[select, i] = myColor;
                    count--;
                }

                for (int j = i + 1; j <= i + count; j++)
                    oneOne[select, j] = myColor;
                count = 0;
            }
            else
                count++;
        }
        return oneOne;
    }

    private string FindColor(int[,] oneOne, int select, int i)
    {
        string color = string.Empty;
        int one = 0;
        if (oneOne[select, i] != 1)
            one = oneOne[select, i];
        else
        {
            if (i == 0)
                one = oneOne[select, i + 1];
            else if (i == _Arr.Count - 1)
                one = oneOne[select, i - 1];
            else if (oneOne[select, i - 1] <= oneOne[select, i + 1])
                one = oneOne[select, i - 1];
            else
                one = oneOne[select, i + 1];

        }
        switch (one)
        {
            case 1:
            case 2:
                color = "red";
                break;
            case 3:
                color = "blue";
                break;
            case 4:
                color = "black";
                break;
        }

        return color;
    }

    protected void btnAll_Click(object sender, EventArgs e)
    {
        int[,] oneOne = new int[33, _Arr.Count];
        int[,] oneColor = new int[33, _Arr.Count];
        int[] sumColor = new int[40];
        string[] totalColor = new string[33];

        for (int i = 0; i < 33; i++)
        {
            oneOne = CreateColor(oneOne, i);
        }

        int allRGoal = 0;
        int allRBGoal = 0;
        for (int i = 0; i < _Arr.Count; i++)
        {
            haha.InnerHtml += "<span style='float:left; color:red; width: 100px; height: 12px;border-style:groove'>" + (string)_ArrLine[i] + "中" + _ArrGoal[i].ToString() + "注" + "</span>";
            int goalRTotal = 0;
            int redTotal = 0;
            int redBlueTotal = 0;
            int goalRBTotal = 0;

            for (int j = 0; j < 33; j++)
            {
                string color = FindColor(oneOne, j, i);
                if (color == "red" || color == "blue")
                {
                    redBlueTotal++;
                    if (color == "red")
                    {
                        redTotal++;
                        oneColor[j, i] = 0;
                    }
                    else
                        oneColor[j, i] = 1;

                }
                else
                    oneColor[j, i] = 2;

                if (oneOne[j, i] == 1)
                {
                    haha.InnerHtml += "<span title='" + Convert.ToString(j + 1) + "' style='cursor:hand;float:left;color:" + color + ";width:15px;height:12px;border-style:groove;background-color:yellow'>" + oneOne[j, i] + "</span>";
                    if (color == "red" || color == "blue")
                    {
                        goalRBTotal++;
                        if (color == "red")
                            goalRTotal++;
                    }
                }
                else
                    haha.InnerHtml += "<span title='" + Convert.ToString(j + 1) + "' style='cursor:hand;float:left;color:" + color + ";width:15px;height:12px;border-style:groove'>" + oneOne[j, i] + "</span>";
            }
            haha.InnerHtml += "<span style='float:left; color:blue; width:50px; height:12px;border-style:groove'>" + "Red=" + redTotal + "</span>";
            if (goalRTotal == 6)
            {
                haha.InnerHtml += "<span style='float:left; color:red; width:50px; height:12px;border-style:groove'>" + "命中=" + goalRTotal + "</span>";
                allRGoal++;
            }
            else if (goalRTotal == 5)
                haha.InnerHtml += "<span style='float:left; color:black; width:50px; height:12px;border-style:groove'>" + "命中=" + goalRTotal + "</span>";
            else
                haha.InnerHtml += "<span style='float:left; color:blue; width:50px; height:12px;border-style:groove'>" + "命中=" + goalRTotal + "</span>";

            haha.InnerHtml += "<span style='float:left; color:blue; width:50px; height:12px;border-style:groove'>" + "RB=" + redBlueTotal + "</span>";
            if (goalRBTotal == 6)
            {
                haha.InnerHtml += "<span style='float:left; color:red; width:50px; height:12px;border-style:groove'>" + "命中=" + goalRBTotal + "</span>";
                allRBGoal++;
            }
            else if (goalRBTotal == 5)
                haha.InnerHtml += "<span style='float:left; color:black; width:50px; height:12px;border-style:groove'>" + "命中=" + goalRBTotal + "</span>";
            else
                haha.InnerHtml += "<span style='float:left; color:blue; width:50px; height:12px;border-style:groove'>" + "命中=" + goalRBTotal + "</span>";
            haha.InnerHtml += "<br><br>";
        }

        sumColor = FindHowColor(oneColor, sumColor, ref totalColor);

        haha.InnerHtml += "<span style='float:left; color:red; width:100px; height:12px;border-style:groove'>" + "R总共命中=" + allRGoal + "</span>";
        haha.InnerHtml += "<span style='float:left; color:red; width:100px; height:12px;border-style:groove'>" + "RB总共命中=" + allRBGoal + "</span>";
        haha.InnerHtml += "<br><br>" + TotalDisplay(sumColor, "颜色为");

        //DisplayTotalColor(totalColor);
        DisplayTotalColorMuch(totalColor);
    }

    private void DisplayTotalColorMuch(string[] totalColor)
    {
        ArrayList alID = new ArrayList();
        ArrayList alValue = new ArrayList();
        ArrayList alNow = new ArrayList();

        for (int i = 0; i < totalColor.Length; i++)
        {
            for (int j = 0; j < totalColor[i].Length - 2; j++)
            {
                if (j == 0)
                    alNow.Add(totalColor[i].Substring(0, 2));
                string str = totalColor[i].Substring(j, 3);
                int ok = alID.IndexOf(str);
                if (ok != -1)
                {
                    int now = int.Parse(alValue[ok].ToString());
                    now++;
                    alValue[ok] = now;
                }
                else
                {
                    alID.Add(str);
                    alValue.Add(1);
                }
            }
        }

        txtDisplay.Text += "对三个一组的分析\n";
        for (int j = 0; j < alID.Count; j++)
        {
            txtDisplay.Text += "组合为 " + alID[j].ToString() + " 的有 " + alValue[j].ToString() + " 次\n";
        }

        for (int i = 0; i < totalColor.Length; i++)
        {
            txtDisplay.Text += "对数字"+ Convert.ToString(i + 1) +"的分析\n";
            txtDisplay.Text += "    " + totalColor[i] + "\n";
            for (int j = 0; j < alID.Count; j++)
            {
                if (alID[j].ToString().Substring(1, 2) == alNow[i].ToString())
                    txtDisplay.Text += "    为 " + alID[j].ToString() + " 的有 " + alValue[j].ToString() + " 次\n";
            }
        }
    }

    private void DisplayTotalColor(string[] totalColor)
    {
        char[] input = {'A', 'B', 'C', 'D', 'E', 'F'};

        for (int i = 0; i < input.Length; i++)
        {
            ArrayList alID = new ArrayList();
            ArrayList alValue = new ArrayList();

            for (int j = 0; j < totalColor.Length; j++)
            {
                string[] find = totalColor[j].Split(input[i]);

                for (int x = 0; x < find.Length; x++)
                {
                    if (find[x] != "")
                    {
                        if (x != find.Length - 1)
                        {
                            string str = "+" + find[x].Substring(find[x].Length - 1, 1);
                            int ok = alID.IndexOf(str);
                            if (ok != -1)
                            {
                                int now = int.Parse(alValue[ok].ToString());
                                now++;
                                alValue[ok] = now;
                            }
                            else
                            {
                                alID.Add(str);
                                alValue.Add(1);
                            }
                        }
                        if (x != 0)
                        {
                            string str = "-" + find[x].Substring(0, 1);
                            int ok = alID.IndexOf(str);
                            if (ok != -1)
                            {
                                int now = int.Parse(alValue[ok].ToString());
                                now++;
                                alValue[ok] = now;
                            }
                            else
                            {
                                alID.Add(str);
                                alValue.Add(1);
                            }
                        }
                    }
                }
            }

            txtDisplay.Text += "对 "+ input[i] +" 分析\n";
            for (int j = 0; j < alID.Count; j++)
            {
                if(alID[j].ToString().Contains("+"))
                    txtDisplay.Text += "下一个为 " + alID[j].ToString() + " 的有 "+ alValue[j].ToString() +" 次\n";
                else
                    txtDisplay.Text += "上一个为 " + alID[j].ToString() + " 的有 " + alValue[j].ToString() + " 次\n";
            }
        }
    }

    private int[] FindHowColor(int[, ] oneColor, int[] sumColor, ref string[] totalColor)
    {   
        for (int i = 0; i < 33; i++)
        {
            string str = string.Empty;
            sumColor = FindOneHowColor(oneColor, sumColor, i, ref str);
            totalColor[i] = str;
        }

        return sumColor;
    }

    private int[] FindOneHowColor(int[,] oneColor, int[] sumColor, int i, ref string str)
    {
        int now = 0;
        int count = 0;
        for (int j = 0; j < _Arr.Count; j++)
        {
            if (j == 0)
            {
                now = oneColor[i, j];
                sumColor[now]++;
                count++;
            }
            else
            {
                if (now != oneColor[i, j])
                {
                    int subColor = 0;
                    if (now == 0)
                        subColor = 3;
                    else if (now == 1)
                        subColor = 5;
                    else
                        subColor = 12;
                                        
                    int wow = count / subColor;
                    if (wow > 9)
                        wow = 9;
                    sumColor[(now + 1) * 10 + wow]++;

                    if (now == 0)
                    {
                        if (wow == 0)
                            str += "A";
                        else
                            str += "B";
                    }
                    else if (now == 1)
                    {
                        if (wow == 0)
                            str += "C";
                        else
                            str += "D";
                    }
                    else
                    {
                        if (wow == 0)
                            str += "E";
                        else
                            str += "F";
                    }

                    count = 1;
                    
                    now = oneColor[i, j];
                    sumColor[now]++;
                }
                else
                    count++;
            }
        }
        return sumColor;
    }
    #endregion
}

