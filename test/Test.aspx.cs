using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtResult.Text = string.Empty;
    }
    #region 20110729
    #region 给定一组数列236751498,每次选定n,使前n个数翻转.例n=5,则576321498.依此类推,直至有序123456789。
    /// <summary>
    /// 给定一组数列236751498,每次选定n,使前n个数翻转.例n=5,则576321498.依此类推,直至有序123456789。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTwo_Click(object sender, EventArgs e)
    {
        string strInput = txtTwo.Text.Trim();


        ArrayList alLink = new ArrayList();
        ArrayList alLeft = new ArrayList();
        ArrayList alRight = new ArrayList();

        alLeft.Add("12");
        alLeft.Add("123");
        alLeft.Add("1234");
        alLeft.Add("12345");
        alLeft.Add("123456");
        alLeft.Add("1234567");
        alLeft.Add("12345678");
        alLeft.Add("123456789");

        alRight.Add("21");
        alRight.Add("321");
        alRight.Add("4321");
        alRight.Add("54321");
        alRight.Add("654321");
        alRight.Add("7654321");
        alRight.Add("87654321");
        alRight.Add("987654321");

        int count = 0;
        int right = 0;
        string str = string.Empty;
        string strChange = string.Empty;
        string strChangeTwo = string.Empty;
        //bool test = true;
        while (strInput != "123456789" && strInput != "987654321")
        {
            txtResult.Text += "strInput:" + strInput + "\n";

            //test = true;
            for (int i = 2; i <= 9; i++)
            {
                strChange = ChangeStr(strInput, i);
                for (int j = right; j < 8; j++)
                {
                    if (strChange.IndexOf(alLeft[j].ToString()) != -1 || strChange.IndexOf(alRight[j].ToString()) != -1)
                    {
                        if (j > right)
                        {
                            right = j;
                            strInput = strChange;
                            txtResult.Text += "ChangeOne:" + strChange + "\n";
                            //test = false;
                        }
                    }
                    else
                    {
                        if (strChange.IndexOf(alLeft[right].ToString()) != -1)
                            strChangeTwo = strChange.Replace(alLeft[right].ToString(), alRight[right].ToString());
                        else if (strChange.IndexOf(alRight[j].ToString()) != -1)
                            strChangeTwo = strChange.Replace(alRight[right].ToString(), alLeft[right].ToString());
                        if (strChangeTwo.IndexOf(alLeft[j].ToString()) != -1 || strChangeTwo.IndexOf(alRight[j].ToString()) != -1)
                        {
                            if (j > right)
                            {
                                right = j;
                                strInput = strChangeTwo;
                                txtResult.Text += "ChangeTwo:" + strChangeTwo + "\n";
                                //test = false;
                            }
                        }
                        else
                            break;
                    }
                }

            }
            //if (test) strInput = strChange;
            count++;

        }
    }

    private string ChangeStr(string strInput, int n)
    {
        ArrayList al = new ArrayList();
        for (int i = 0; i < 9; i++)
        {
            al.Add(strInput.Substring(i, 1));
        }

        int count = 0;
        if (n % 2 == 1)
            count = (n - 1) / 2;
        else
            count = n / 2;
        string str = string.Empty;

        for (int i = 0; i < count; i++)
        {
            str = al[i].ToString();
            al[i] = al[n - 1 - i].ToString();
            al[n - 1 - i] = str;
        }

        strInput = string.Empty;

        for (int i = 0; i < 9; i++)
        {
            strInput += al[i].ToString();
        }
        return strInput;
    }
    #endregion

    #region 有面值10元，20元，50元的人民币，加起来等于1000元钱，有多少种组合的方法。

    /// <summary>
    /// 有面值10元，20元，50元的人民币，加起来等于1000元钱，有多少种组合的方法。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMoney_Click(object sender, EventArgs e)
    {
        int count = 0;
        int ten = 0;
        for(int i = 0; i <= 20; i++)
            for (int j = 0; j <= 50; j++)
            {
                if (i * 5 + j * 2 <= 100)
                {
                    count++;
                    ten = 100 - i * 5 - j * 2;
                    txtResult.Text += "50元" + i.ToString() + "个；20元" + j.ToString() + "个；10元" + ten.ToString() + "个\n";
                }
                else
                    break;
            }
        txtResult.Text += "一共有" + count.ToString() + "种组合";
    } 
    #endregion

    #region 输出蛇形矩阵
    /// <summary>
    /// 输入数字个数，输出蛇形矩阵如下：16个效果
    /// 1  2  9  10
    /// 4  3  8  11
    /// 5  6  7  12
    /// 16 15 14 13
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnThree_Click(object sender, EventArgs e)
    {
        int input = int.Parse(txtThree.Text);

        int[,] result = new int[10, 10];

        bool inputBool = true;
        bool xy = true;
        int now = 1;
        int count = 2;
        int x = 0;
        int y = 0;
        result[x, y] = 1;
        y++;
        for (int i = 2; i <= input; i++)
        {
            for (int j = now + 1; j <= i * i; j++)
            {
                if (j != now + 1)                
                {
                    if (xy)
                    {
                        if (y - 1 < 0)
                            y++;
                        else if (result[x, y - 1] > 0)
                            y++;
                        else
                            y--;
                    }
                    else
                    {
                        if (x - 1 < 0)
                            x++;
                        else if (result[x - 1, y] > 0)
                            x++;
                        else
                            x--;
                    }
                    count++;
                }
                
                result[x, y] = j;                 

                if (count == i)
                {
                    if (xy)
                    {
                        xy = false;
                    }
                    else
                    {
                        xy = true;
                    }

                    count = 1;
                }
            }
            if (inputBool)
            {
                x++;
                inputBool = false;
                xy = true;
            }
            else
            {
                y++;
                inputBool = true;
                xy = false;
            }

            now = i * i;
         
        }        

        txtResult.Text = "";
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (result[i, j].ToString().Length == 1)
                    txtResult.Text += " 0" + result[i, j].ToString();
                else
                    txtResult.Text += " " + result[i, j].ToString();
            }

            txtResult.Text += "\n";
        }
    }
    #endregion
    #endregion

    #region 20111011
    /// <summary>
    /// 题一：
    ///1-9组成3个每位都不重复的3位数
    ///要求第二个数是第一个数的2倍，第三个数是第一个数的3倍
    ///问这样的组合一共多少组
    /// </summary>
    protected void btnOne1011_Click(object sender, EventArgs e)
    {
        for (int i = 123; i <= 987; i++)
        {
            int two = i * 2;
            int three = i * 3;
            bool ok = true;

            if (two <= 987 && three <= 987)
            {
                string input = i.ToString() + two.ToString() + three.ToString();

                for (int j = 1; j <= 9; j++)
                {
                    if (!input.Contains(j.ToString()))
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                    txtResult.Text += "one=" + i.ToString() + ";two=" + two.ToString() + ";three=" + three.ToString() + "\n";
            }
        }
    } 
    
    /// <summary>
    /// 题二：
    ///有一对兔子(刚出生的)，从出生后第N个月起每个月都生一对兔子，
    ///小兔子长到第N个月起每个月又生一对兔子，假如兔子都不死，
    ///问在m(m>n)个月后 总共有多少对兔子?n=3
    /// </summary>
    protected void btnTwo1011_Click(object sender, EventArgs e)
    {
        int m = int.Parse(txtTwo1011.Text);
        int n = 3;
        int count = 0;
        int born1 = 0;
        int born2 = 0;
        int born3 = 2;
        //int born4 = 1;
        int allCount = 2;
        for (int i = n; i <= m; i++)
        {
            count += born3 / 2;
            born3 = born2;
            born2 = born1;

            born1 = count * 2;
            txtResult.Text += "第" + i.ToString() + "月出生" + born1.ToString() + "\n";
            allCount += born1;
        }

        txtResult.Text += m.ToString() + "个月总共" + allCount.ToString() + "\n";
    }

    /// <summary>
    /// 题三：
    ///有N堆纸牌，编号分别为 1，2，…, N。每堆上有若干张，但纸牌总数必为 N 的倍数。可以在任一堆上取若于张纸牌，然后移动。
    ///移牌规则为：在编号为 1 堆上取的纸牌，只能移到编号为 2 的堆上；在编号为 N 的堆上取的纸牌，只能移到编号为 N-1 的堆上；其他堆上取的纸牌，可以移到相邻左边或右边的堆上。
    ///例如：N= 16, 从第一堆开始每堆的数量分别是1,2,89,6,42,3,9,99,6,24,9,2,50,2,60,12
    ///1、现在要求找出一种移动方法，用最少的移动次数使每堆上纸牌数都一样多。
    ///2、移动的顺序和每次移动的数量。
    /// </summary>
    protected void btnThree1011_Click(object sender, EventArgs e)
    {
        string[] str = txtThree1011.Text.Split(',');

        int[] remove = new int[str.Length];
        int[] display = new int[str.Length];
        int average = 0;
        for (int i = 0; i < str.Length; i++)
        {
            remove[i] = int.Parse(str[i]);
            display[i] = remove[i];
            average += remove[i];
        }

        average = average / str.Length;

        int sum = 0;
        int count = 0;
        int move = 0;
        ArrayList al = new ArrayList();
        for (int i = 0; i < str.Length; i++)
        {
            sum += remove[i];
            al.Add(i);
            if (sum > (i + 1) * average)
            {
                
                if (al.Count == 1)
                {
                    int now = Convert.ToInt16(al[0]);
                    count = display[now] - average;

                    txtResult.Text += al[0].ToString() + "方向-->移动" + count.ToString() + "\n";
                    display[int.Parse(al[0].ToString()) + 1] += count;
                }
                else
                {
                    move = sum - (i + 1) * average;
                    for (int j = al.Count - 1; j > 0; j--)
                    {
                        int my = 0;
                        for (int x = 0; x <= j - 1; x++)
                        {
                            int now = Convert.ToInt16(al[x]);

                            my +=average - display[now];
                        }

                        txtResult.Text += al[j].ToString() + "方向<--移动" + my.ToString() + "\n";
                    }

                    if (move != 0)
                    {
                        txtResult.Text += al[al.Count - 1].ToString() + "方向-->移动" + move.ToString() + "\n";
                        display[int.Parse(al[al.Count - 1].ToString()) + 1] += move;
                    }
                }
                al.Clear();
            }
        }

    }
    #endregion

    #region 20120201
    /// <summary>
    /// 一共有5种布局： 
    /// 小井（4子围成一个方块，如图黄点）踢一子，
    /// 三斜（三子在一条斜线上，且两边的子必须在棋盘的边线上，如图红点）踢一子，
    /// 四斜（又名四季，四字在一条斜线上，且最两边的子必须在棋盘的边线上，如图蓝点）踢二子，
    /// 五福( 五子在一条直线上，如图黑点)踢三子，通天（五子在一条斜线上，如图绿点）踢五子。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFiveLove_Click(object sender, EventArgs e)
    {
        int[,] input = { {0, 2, 4, 0, 1}, {6, 8, 10, 3, 0}, {12, 14, 5, 16, 7}, {18, 9, 0, 11, 20}, {13, 15, 17, 19, 21} };
        int select = int.Parse(txtFiveLove.Text);
        int[] result = new int[20];
        string[] strOut = new string[20];

        for(int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
            {
                if (input[i, j] != 0 && input[i, j] % 2 == select)
                {
                    if (i == j)
                    {
                        result[0]++; //通天\
                        strOut[0] += input[i, j].ToString() + "_";
                    }
                    int add = i + j;
                    int sub = i - j;
                    result[i + 2]++;//五福X
                    result[j + 7]++;//五福Y
                    strOut[i + 2] += input[i, j].ToString() + "_";
                    strOut[j + 7] += input[i, j].ToString() + "_";

                    switch (add)
                    {
                        case 4:
                            result[1]++;//通天/
                            strOut[1] += input[i, j].ToString() + "_";
                            break;
                        case 3:
                            result[12]++;//四斜/
                            strOut[12] += input[i, j].ToString() + "_";
                            break;
                        case 5:
                            result[13]++;//四斜/
                            strOut[13] += input[i, j].ToString() + "_";
                            break;
                        case 2:
                            result[16]++;//三斜/
                            strOut[16] += input[i, j].ToString() + "_";
                            break;
                        case 6:
                            result[17]++;//三斜/
                            strOut[17] += input[i, j].ToString() + "_";
                            break;
                    }
                    switch (sub)
                    {
                        case 1:
                            result[14]++;//四斜\
                            strOut[14] += input[i, j].ToString() + "_";
                            break;
                        case -1:
                            result[15]++;//四斜\
                            strOut[15] += input[i, j].ToString() + "_";
                            break;
                        case 2:
                            result[18]++;//三斜\
                            strOut[18] += input[i, j].ToString() + "_";
                            break;
                        case -2:
                            result[19]++;//三斜\
                            strOut[19] += input[i, j].ToString() + "_";
                            break;
                    }
                }
                else 
                {

                }
            }

        for (int i = 0; i < result.Length; i++)
        {
            switch (i)
            {
                case 0:
                case 1:
                    if (result[i] == 5)
                    {
                        txtResult.Text += "通天有：" + strOut[i] + "\n";
                    }
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    if (result[i] == 5)
                    {
                        txtResult.Text += "五福X方向有：" + strOut[i] + "\n";
                    }
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    if (result[i] == 5)
                    {
                        txtResult.Text += "五福Y方向有：" + strOut[i] + "\n";
                    }
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                    if (result[i] == 4)
                    {
                        txtResult.Text += "四斜有：" + strOut[i] + "\n";
                    }
                    break;
                case 16:
                case 17:
                case 18:
                case 19:
                    if (result[i] == 3)
                    {
                        txtResult.Text += "三斜有：" + strOut[i] + "\n";
                    }
                    break;
            }
        }

    }
    #endregion
    protected void btnTest_Click(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)this.Page.FindControl("txtThree");
    }

}
