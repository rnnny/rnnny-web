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

public partial class _Default : System.Web.UI.Page 
{
    public ArrayList _Arr = new ArrayList();
    public ArrayList _Display = new ArrayList();
    public int[,] _TotalBall = new int[33, 400];
    public int[,] _RedBall = new int[33,400];
    public int[,] _LeftArr = new int[33, 100];
    public int[,] _RightArr = new int[33, 100];
    public int[,] _TopArr = new int[33, 100];
    public int[,] _BottomArr = new int[33, 100];
    public bool _Left = false;
    public bool _Right = false;
    public bool _Top = false;
    public bool _Bottom = false;


    protected void Page_Load(object sender, EventArgs e)
    {
        _Arr = ReadFile();
        //Response.Write("12345");
        //Response.Write("<br>");
        //Response.Write("67890");
    }
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
        //_Arr = ReadFile();
        FoundMuchPoint();

        for (int i = 0; i < _Arr.Count; i++)
        {            
            string[] str = (string[])_Arr[i];
            for (int j = 0; j < str.Length; j++)
            {
                if (DisplayArrRed(j,i))
                    haha.InnerHtml += "<div style='float:left; color:red; width: 10px; height: 12px;border-style:groove" + BorderColor() +"'>" + str[j].ToString() + "</div>";
                else
                    haha.InnerHtml += "<div style='float:left; width: 10px; height: 12px;border-style:groove" + BorderColor() + "'>" + str[j].ToString() + "</div>";
            }
            haha.InnerHtml += "<br><br>";
        }
    }

    private string BorderColor()
    {
        string returnStr = string.Empty;
        if (_Left) returnStr = ";border-left-color:Blue";
        if (_Right) returnStr += ";border-right-color:Blue";
        if (_Top) returnStr += ";border-top-color:Blue";
        if (_Bottom) returnStr += ";border-bottom-color:Blue";

        return returnStr;
    }    

    private void FoundMuchPoint()
    {
        for (int i = 0; i < 32; i++)
            for (int j = 0; j < 99; j++)
            {
                int x = 1;
                int y = 1;
                bool xOK = true;
                //x方向
                for (int a = 1; a < 33 - i - x; a++)
                {
                    if (Zero(i + a + x, j, i + a + x, j + y) == false || Zero(i, j, i + x + a, j) == false || Zero(i, j, i, j + y) == false || Zero(i, j + y, i + x + a, j + y) == false)
                    {
                        a--;
                        break;
                    }
                    xOK = CountNum(i, j, i + a + x, j + y);
                    if (xOK == false)
                    {
                        x += a - 1;
                        break;
                    }
                    else
                    {
                        DisplayArr(i.ToString() + "," + j.ToString(), Convert.ToString(i + a + x) + "," + Convert.ToString(j + y));
                        //_Display.Add(i.ToString() + "," + j.ToString() + "|" + Convert.ToString(i + a + x) + "," + Convert.ToString(j + y));
                    }
                }
                //y方向
                bool yOK = true;

                for (int b = 1; b < 100 - j - y; b++)
                {
                    if (Zero(i, j + b + y, i + x, j + b + y) == false || Zero(i, j, i, j + b + y) == false || Zero(i, j, i + x, j) == false || Zero(i + x, j, i + x, j + b + y) == false)
                    {
                        b--;
                        break;
                    }
                    yOK = CountNum(i, j, i + x, j + b + y);
                    if (yOK == false)
                        break;
                    else
                    {
                        DisplayArr(i.ToString() + "," + j.ToString(), Convert.ToString(i + x) + "," + Convert.ToString(j + b + y));
                        //_Display.Add(i.ToString() + "," + j.ToString() + "|" + Convert.ToString(i + x) + "," + Convert.ToString(j + b + y));
                    }
                }
            }
    } 

    private bool CountNum(int x0,int y0,int x1,int y1)
    {
        bool returnBool = true;
        int count = 0;
        int countNew = (x1 - x0 + 1) * (y1 - y0 + 1);
        for(int i = x0; i <= x1; i++)
            for (int j = y0; j <= y1; j++)
            { 
                count += _RedBall[i, j]; 
            }

        if (count < (countNew - count)) returnBool = false;

        return returnBool;
    }

    private bool Zero(int x0, int y0, int x1, int y1)
    {
        bool returnBool = false;
        if (x0 == x1) 
        {
            for (int i = y0; i <= y1; i++)
                if (_RedBall[x0, i] > 0)
                {
                    returnBool = true; break;
                }
        }
        else if (y0 == y1) 
        {
            for (int i = x0; i <= x1; i++)
                if (_RedBall[i, y0] > 0)
                {
                    returnBool = true; break;
                }
        }

        return returnBool;
    }

    private void DisplayArr(string upPoint, string downPoint)
    {
        String[] str;
        bool insert = true;
        for (int i = 0; i < _Display.Count; i++)
        {
            str = _Display[i].ToString().Split('|');

            if (str[0] == upPoint)
            {
                string[] str0 = str[1].Split(',');
                string[] str1 = downPoint.Split(',');

                if (int.Parse(str0[0]) <= int.Parse(str1[0]) && int.Parse(str0[1]) <= int.Parse(str1[1]))
                {
                    _Display[i] = upPoint + "|" + downPoint;
                    insert = false;
                    break;
                }
                else if (int.Parse(str0[0]) >= int.Parse(str1[0]) && int.Parse(str0[1]) >= int.Parse(str1[1]))
                    insert = false;
            }
        }

        if (insert) _Display.Add(upPoint + "|" + downPoint);
    }

    private bool DisplayArrRed(int x, int y)
    {
        bool red = false;
        bool left = true;
        bool right = true;
        bool top = true;
        bool bottom = true;
        _Left = false;
        _Right = false;
        _Top = false;
        _Bottom = false;
        
        for (int i = 0; i < _Display.Count; i++)
        {
            string[] str = _Display[i].ToString().Split('|');

            string[] str0 = str[0].Split(',');
            string[] str1 = str[1].Split(',');

            if (x >= int.Parse(str0[0]) && x <= int.Parse(str1[0]) && y >=int.Parse(str0[1]) && y <= int.Parse(str1[1]))
            {                
                red = true;
                if (x == int.Parse(str0[0]) && left)
                    _Left = true;
                else
                {
                    _Left = false; left = false;
                }
                if (x == int.Parse(str1[0]) && right)
                    _Right = true;
                else
                {
                    _Right = false; right = false;
                }
                if (y == int.Parse(str0[1]) && top)
                    _Top = true;
                else
                {
                    _Top = false; top = false;
                }
                if (y == int.Parse(str1[1]) && bottom)
                    _Bottom = true;
                else
                {
                    _Bottom = false; bottom = false;
                }                
                
                //if (x == int.Parse(str0[0])) _Left = true;
                //if (x == int.Parse(str1[0])) _Right = true;
                //if (y == int.Parse(str0[1])) _Top = true;
                //if (y == int.Parse(str1[1])) _Bottom = true;

                //if (x == int.Parse(str0[0])) _Left = true;
                //else _Left = false;
                //if (x == int.Parse(str1[0])) _Right = true;
                //else _Right = false;
                //if (y == int.Parse(str0[1])) _Top = true;
                //else _Top = false;
                //if (y == int.Parse(str1[1])) _Bottom = true;
                //else _Bottom = false;
            }

        }
        
        return red;
    }
    #endregion 

    #region ClickHaHa
    protected void btnHaHa_Click(object sender, EventArgs e)
    {
        //_Arr = ReadFile();
        FoundEmpty();

        for (int i = 0; i < _Arr.Count; i++)
        {
            string[] str = (string[])_Arr[i];
            for (int j = 0; j < str.Length; j++)
            {
                haha.InnerHtml += "<div style='float:left; color:red; width: 29px; height: 35px;border-style:groove" + BorderColor(j,i) + "'>" + str[j].ToString() + "</div>";
            }
            haha.InnerHtml += "<br><br>";
        }
    }

    private string BorderColor(int x, int y)
    {
        string returnStr = string.Empty;
        if (_LeftArr[x, y] == 1) returnStr = ";border-left-color:Blue";
        if (_RightArr[x, y] == 1) returnStr += ";border-right-color:Blue";
        if (_TopArr[x, y] == 1) returnStr += ";border-top-color:Blue";
        if (_BottomArr[x, y] == 1) returnStr += ";border-bottom-color:Blue";

        return returnStr;
    }

    private void FoundEmpty()
    {
        for (int i = 0; i < 33; i++)
            for (int j = 0; j < 100; j++)
            {
                if (_RedBall[i, j] == 0)
                {
                    //left
                    GoLeft(i, j);
                    //right
                    GoRight(i, j);
                    //Top
                    GoTop(i, j);
                    //bottom
                    GoBottom(i, j);
                }
            }
    }

    private void GoLeft(int x, int y)
    {
        if (x == 0)
            _LeftArr[x, y] = 1;
        else
            if (_RedBall[x - 1, y] != 0)
            {
                _LeftArr[x, y] = 1;
                if (y - 1 >= 0 && _RedBall[x, y - 1] == 0)
                    for (int i = x - 1; i >= 0; i--)
                    {
                        if (_LeftArr[i, y - 1] != 1 && _RedBall[i, y - 1] == 0)
                        {
                            if (_TopArr[i, y - 1] == 1)
                            {
                                _LeftArr[i + 1, y - 1] = 1; break;
                            }
                            else
                                _TopArr[i, y] = 1;
                        }
                        else
                        {
                            if (_RedBall[i, y - 1] == 0)
                                _TopArr[i, y] = 1;
                            break;
                        }
                        //if (_LeftArr[i, y] == 1 && y < 99)
                        while (_LeftArr[i, y] == 1 && y < 99)
                            y = y + 1;
                    }
            }
    }

    private void GoRight(int x, int y)
    {
        if (x == 32)
            _RightArr[x, y] = 1;
        else
            if (_RedBall[x + 1, y] != 0)
            {
                _LeftArr[x + 1, y] = 1;
                if (y > 0)
                    for (int i = x + 1; i < 33; i++)
                    {
                        if (_RedBall[i, y - 1] == 0)
                        {
                            if (_TopArr[i, y - 1] == 1)
                            {
                                _LeftArr[x + 1, y - 1] = 1; break;
                            }
                            else
                                _TopArr[i, y] = 1;
                        }
                        else
                        {
                            break;
                        }
                    }
            }
    }

    private void GoTop(int x, int y)
    {
        if (y == 0)
            _TopArr[x, y] = 1;
        else
            if (_RedBall[x, y - 1] != 0)
            {
                _TopArr[x, y] = 1;
                if (x + 1 < 33 && _RedBall[x + 1, y] == 0)
                    for (int i = y - 1; i >= 0; i--)
                    {
                        if (_TopArr[x + 1, i] != 1 && _RedBall[x + 1, i] == 0)
                        {
                            if (_LeftArr[x, i] == 1)
                            {
                                _TopArr[x, i + 1] = 1;break;
                            }
                            else
                                _LeftArr[x + 1, i] = 1;
                        }
                        else
                        {
                            if (_RedBall[x + 1, i] == 0)
                                _LeftArr[x + 1, i] = 1;
                            //if (_TopArr[x, i] != 1) x = x - 1;
                            //else
                            break;
                        }
                        //if (_TopArr[x, i] == 1 && x > 0)
                        while (_TopArr[x, i] == 1 && x > 0)
                            x = x - 1;
                    }
            }
    }

    private void GoBottom(int x, int y)
    {
        if (y == 99)
            _BottomArr[x, y] = 1;
        else
            if (_RedBall[x, y + 1] != 0)
            {
                _TopArr[x, y + 1] = 1;
                if (x < 32)
                    for (int i = y + 1; i < 100; i++)
                    {
                        if (_RedBall[x + 1, i] == 0)
                        {
                            if (_LeftArr[x, i] == 1)
                            {
                                _TopArr[x, i] = 1; break;
                            }
                            else
                                _LeftArr[x + 1, i] = 1;                            
                        }
                        else
                        {
                            break;
                        }
                    }
            }
    }
    #endregion

    #region ClickHoHo
    protected void btnHoHo_Click(object sender, EventArgs e)
    {
        //_Arr = ReadFile();
        FoundEmptyNew();

        for (int i = 0; i < 33; i++)
            for (int j = 0; j < 100; j++)
            {
                if (j > 0 && _RedBall[i, j] != _RedBall[i, j - 1])
                    _TopArr[i, j] = 1;
                if (i > 0 && _RedBall[i, j] != _RedBall[i - 1, j])
                    _LeftArr[i, j] = 1;
                if (j < 98 && _RedBall[i, j] != _RedBall[i, j + 1])
                    _BottomArr[i, j] = 1;
                if (i < 32 && _RedBall[i, j] != _RedBall[i + 1, j])
                    _RightArr[i, j] = 1;

            }

        for (int i = 0; i < _Arr.Count; i++)
        {
            string[] str = (string[])_Arr[i];
            for (int j = 0; j < str.Length; j++)
            {
                haha.InnerHtml += "<div style='float:left; color:red; width: 15px; height: 20px;border-style:groove" + BorderColor(j, i) + "'>" + str[j].ToString() + "</div>";
                
            }
            haha.InnerHtml += "<br><br>";
            over.InnerHtml += "<div style='float:left; color:red; width:200px; height: 20px;border-style:groove'>" + "大家好啊大家好啊大家好啊" + "</div><br><br>";
            
        }

        //for (int i = 0; i < 33; i++)
        //{
        //    for (int j = 0; j < 100; j++)
        //    {
        //        haha.InnerHtml += "<div style='float:left; color:red; width: 20px; height: 35px;border-style:groove'>" + _RedBall[i, j].ToString() + "</div>";
        //    }
        //    haha.InnerHtml += "<br><br>";
        //}
    }

    public int _MaxLength = 0;
    public int _NowLength = 0;
    public int _DownFirst = 0;
    public int _DownEnd = 0;
    bool _CanLeft = true;
    //bool _CanDown = true;
    private void FoundEmptyNew()
    {
        int count = 2;
        string point = string.Empty;
        int row = 0;

        for (int j = 0; j < 100; j++)
            for (int i = 0; i < 33; i++)
            {
                _CanLeft = true;
                point = "left";
                if (_RedBall[i, j] == 0)
                {
                    //判断方向.向上,向左,向右,向下.
                    //走到有数字的位置,每走一步,负值count.
                    //判断当前行是否有数字,如果有改变方向向下
                    if (point == "left")
                        for (int x = j; x < 99 - j; x++)
                        {
                            if (GoLeftWay(count, i, j, x))
                            {
                                //point = "down";
                                //row = x;
                                //break;
                            }
                        }
                    if (point == "down")
                    {
                        for (int x = _DownFirst; x < _DownEnd; x++)
                        {
                            GoDownWay(count, x, row);
                        }
                    }
                    if(_CanLeft == false)
                        count++;
                }
            }
    }

    private bool GoLeftWay(int count, int i, int j, int x)
    {
        bool found = false;
        for (int a = i; a < 33; a++)
        {
            if (_RedBall[a, x] != 0)
            {
                if(j != x)
                    found = true;

                _NowLength = a - i;
                if (_MaxLength == 0)
                    _MaxLength = _NowLength;
                else
                {
                    if (_CanLeft)
                    {
                        if (_NowLength < _MaxLength)
                        {
                            _CanLeft = false;
                            _MaxLength = _NowLength;
                        }
                        else
                            _MaxLength = _NowLength;
                    }
                    else
                    {
                        if (_NowLength < _MaxLength)
                        {
                            _MaxLength = _NowLength;
                        }
                        else
                            _NowLength = _MaxLength;

                    }
                }

                _DownFirst = a + 1;
                for (int b = a + 1; b < 33; b++)
                {
                    if (_RedBall[a, x] != 0)
                    {
                        _DownEnd = b; break;
                    }
                }
                //for (int c = i; c < _NowLength + i; c++)
                //{
                //    _RedBall[c, x] = count;
                //}
                break;
            }
            else
                _RedBall[a, x] = count;
        } 
        return found;
    }

    private void GoDownWay(int count, int x, int row)
    {
        for (int a = row; a < 99; a++)
        {
            if (_RedBall[x, a] != 0)
            {
                _NowLength = a - row;
                if (_MaxLength == 0)
                    _MaxLength = _NowLength;
                else
                {
                    if (_CanLeft)
                    {
                        if (_NowLength < _MaxLength)
                        {
                            _CanLeft = false;
                            _MaxLength = _NowLength;
                        }
                        else
                            _MaxLength = _NowLength;
                    }
                    else
                    {
                        if (_NowLength < _MaxLength)
                        {
                            _MaxLength = _NowLength;
                        }
                        else
                            _NowLength = _MaxLength;
                    }
                }
                //for (int b = row; b < _NowLength + row; a++)
                //{
                //    _RedBall[x, b] = count;
                //}
                break;
            }
            else
                _RedBall[x, a] = count;
        }
    }
    #endregion

    #region 临号和重号
    /// <summary>
    /// 计算重号个数、临号个数以及重号和临号之和
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNear_Click(object sender, EventArgs e)
    {
        //ArrayList arrNear = new ArrayList();
        //ArrayList arrRepeat = new ArrayList();
        ArrayList arrCount = new ArrayList();
        ArrayList arrNearRepeat = new ArrayList();
        //_Arr = ReadFile();
        string[] str;
        string[] strArr = new string[6];
        if (txtInput.Text != string.Empty)
            strArr = txtInput.Text.Split(' ');
        //over.InnerHtml += "<div style='float:left; color:red; width:200px; height: 20px;border-style:groove'>" + "临号和重号" + "</div><br><br>";
        
        for(int i = 0; i < _Arr.Count - 1; i++)
        {
            int same = 0;
            int count = 0;
            int repeat = 0;
            int near = 0;
            string[] strLast = (string[])_Arr[i + 1];
            str = (string[])_Arr[i];
            for (int j = 0; j < 33; j++)
            {
                if (count < 6 && int.Parse(strArr[count]) == j + 1)
                {
                    haha.InnerHtml += "<div style='float:left; color:red; width: 15px; height: 20px;border-style:groove;border-color:Blue'>" + str[j].ToString() + "</div>";
                    count++;
                    if (str[j] != "")
                        same++;
                }
                else
                    haha.InnerHtml += "<div style='float:left; color:red; width: 15px; height: 20px;border-style:groove'>" + str[j].ToString() + "</div>";
                if (str[j] != "")
                {
                    if (strLast[j] != "")
                        repeat++;
                    else
                    {
                        if (j != 0 && strLast[j - 1] != "")
                            near++;
                        else if (j < 32 && strLast[j + 1] != "")
                            near++;
                    }
                }

            }
            haha.InnerHtml += "<br><br>";
            //over.InnerHtml += "<div style='float:left; color:red; width:200px; height: 20px;border-style:groove'>" + "重号："+ repeat.ToString() +"；临号：" + near.ToString() + "；和：" + Convert.ToString(repeat + near) + "</div><br><br>";
            over.InnerHtml += "<div style='float:left; color:red; width:200px; height: 20px;border-style:groove'>" + "比较结果：" + same.ToString() + "</div><br><br>";
            arrNearRepeat.Add(near.ToString() + "_" + repeat.ToString());
            arrCount.Add(near + repeat);
        }

        str = (string[])_Arr[_Arr.Count - 1];
        for (int i = 0; i < 33; i++)
        {
            haha.InnerHtml += "<div style='float:left; color:red; width: 15px; height: 20px;border-style:groove'>" + str[i].ToString() + "</div>";

        }
        haha.InnerHtml += "<br><br>";

        Hashtable hsMax = new Hashtable();
        hsMax = FindMax(arrCount);

        Hashtable hsNearRepeat = new Hashtable();
        hsNearRepeat = FindMax(arrNearRepeat);
    }

    private Hashtable FindMax(ArrayList arr)
    {
        Hashtable hs = new Hashtable();
        for (int i = 0; i < arr.Count; i++)
        {
            if (hs.ContainsKey(arr[i].ToString()))
            {
                int a = int.Parse(hs[arr[i].ToString()].ToString());
                hs[arr[i].ToString()] = a + 1;
            }
            else
            {
                hs.Add(arr[i].ToString(), 1);
            }

        }
        return hs;
    }

    protected void btnMove_Click(object sender, EventArgs e)
    {
        ArrayList arrCount = new ArrayList();
        //_Arr = ReadFile();
        string[] str;
        //over.InnerHtml += "<div style='float:left; color:red; width:200px; height: 20px;border-style:groove'>" + "临号和重号" + "</div><br><br>";

        //for (int i = 0; i < _Arr.Count - 1; i++)
        //{
        //    int first = 0;
        //    string strMove = string.Empty;
        //    str = (string[])_Arr[i];
        //    for (int j = 0; j < 33; j++)
        //    {
        //        if (str[j] != string.Empty)
        //        {
        //            if (first == 0)
        //                first = int.Parse(str[j]);
        //            strMove += Convert.ToString(int.Parse(str[j]) - first) + "_";
        //        }
        //    }
        //    strMove = strMove.Substring(0,strMove.Length - 1);
        //    arrCount.Add(strMove);
        //}

        for (int i = 0; i < _Arr.Count - 1; i++)
        {
            int first = 0;
            string[] strArr = new string[6];
            
            str = (string[])_Arr[i];
            for (int j = 0; j < 33; j++)
            {
                if (str[j] != string.Empty)
                {
                    strArr[first] = str[j];
                    first++;
                }
            }
            
            for (int j = 0; j < 6; j++)
            {
                string strMove = string.Empty;
                for(int x = 0; x < 6; x++)
                {
                    if(j !=x )
                        strMove += strArr[x];
                }

                arrCount.Add(strMove);
            }
        }

        Hashtable hsMax = new Hashtable();
        hsMax = FindMax(arrCount);
    }
    #endregion

    #region 五轮相加结果
    protected void btnFive_Click(object sender, EventArgs e)
    {
        //_Arr = ReadFile();
        string[] str;
        int number = 6;
        int count = 0;
        for (int i = 0; i < _Arr.Count - number - 1; i++)
        {
            int total = 0;
            //int repeat = 0;
            str = (string[])_Arr[i];
            //for (int j = 0; j < 33; j++)
            //{
            //    haha.InnerHtml += "<div style='float:left; color:red; width: 15px; height: 20px;border-style:groove'>" + str[j].ToString() + "</div>";
            //}

            //haha.InnerHtml += "<br><br>";

            for (int j = 0; j < 33; j++)
            {
                for (int x = 1; x <= number; x++)
                {
                    _TotalBall[j, i] += _RedBall[j, i + x];
                }
                haha.InnerHtml += "<div style='float:left; color:blue; width: 15.2px; height: 20px;border-style:groove'>" + _TotalBall[j, i] + "</div>";

                if (_TotalBall[j, i] > 0) total++;

                //if (_RedBall[j, i + 1] != 0 || _RedBall[j, i + 2] != 0 || _RedBall[j, i + 3] != 0 || _RedBall[j, i + 4] != 0)
                //{
                //    total++;
                //    if (_RedBall[j, i] != 0)
                //        repeat++;
                //}
            }

            haha.InnerHtml += "<br><br>";
            over.InnerHtml += "<div style='float:left; color:red; width:120px; height: 20px;border-style:groove'>" + "红号：" + total.ToString() + "</div><br><br>";
            //over.InnerHtml += "<div style='float:left; color:red; width:120px; height: 20px;border-style:groove'>" + "重号：" + repeat.ToString() + "</div><br><br>";

            count += total;
        }

        float abc = count / (_Arr.Count - number - 1);
        over.InnerHtml += "<div style='float:left; color:red; width:120px; height: 20px;border-style:groove'>" + "平均红号：" + abc.ToString() + "</div><br><br>";
    }
    #endregion

}
