using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
///BeiJing 的摘要说明
/// </summary>
public class BeiJing
{
	public BeiJing()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private string _RealStr = string.Empty;
    public string RealStr
    {
        get
        {
            return this._RealStr;
        }
        set
        {
            this._RealStr = value;
        }
    }

    private int[] _SumReal = new int[MyTest.MaxMax];
    public int[] SumReal
    {
        get
        {
            return this._SumReal;
        }
        set
        {
            this._SumReal = value;
        }
    }

    private string _ChangeAStr = string.Empty;
    public string ChangeAStr
    {
        get
        {
            return this._ChangeAStr;
        }
        set
        {
            this._ChangeAStr = value;
        }
    }

    private int[] _SumChangeA = new int[MyTest.MaxMax];
    public int[] SumChangeA
    {
        get
        {
            return this._SumChangeA;
        }
        set
        {
            this._SumChangeA = value;
        }
    }

    private int _UpChangeA = 0;
    public int UpChangeA
    {
        get
        {
            return this._UpChangeA;
        }
        set
        {
            this._UpChangeA = value;
        }
    }

    private int _DownChangeA = 0;
    public int DownChangeA
    {
        get
        {
            return this._DownChangeA;
        }
        set
        {
            this._DownChangeA = value;
        }
    }

    private string _ChangeBStr = string.Empty;
    public string ChangeBStr
    {
        get
        {
            return this._ChangeBStr;
        }
        set
        {
            this._ChangeBStr = value;
        }
    }

    private string _ChangeBLastAStr = string.Empty;
    public string ChangeBLastAStr
    {
        get
        {
            return this._ChangeBLastAStr;
        }
        set
        {
            this._ChangeBLastAStr = value;
        }
    }
    private string[] _ChangeBArr = new string[MyTest.MaxMax];
    public string[] ChangeBArr
    {
        get
        {
            return this._ChangeBArr;
        }
        set
        {
            this._ChangeBArr = value;
        }
    }

    private int[] _SumChangeB = new int[MyTest.MaxMax];
    public int[] SumChangeB
    {
        get
        {
            return this._SumChangeB;
        }
        set
        {
            this._SumChangeB = value;
        }
    }

    private string _Result = string.Empty;
    public string Result
    {
        get
        {
            return this._Result;
        }
        set
        {
            this._Result = value;
        }
    }
}
public class BeiJingFunC
{

    public static string GetChangeAStr(BeiJing bj)
    {
        string str =  string.Empty;
        int[] sumChangeA = new int[3];
        for (int i = 0; i < bj.RealStr.Length; i++)
        {
            int real = int.Parse(bj.RealStr.Substring(i, 1));
            int change = 0;
            if (real >= bj.UpChangeA)
                change = 2;
            else if (real <= bj.DownChangeA)
                change = 0;
            else
                change = 1;
            sumChangeA[change]++;
            str += change.ToString();
        }
        bj.SumChangeA = sumChangeA;
        return str;
    }

    public static string GetChangeBStr(BeiJing bj)
    {
        int[] sumChangeB = new int[50];
        string changeBStr = string.Empty;
        string[] changeBArr = new string[MyTest.MaxMax];

        string str = string.Empty;
        int[] input = new int[bj.ChangeAStr.Length]; 
        int count = 0;
        int flagA = 3;
        int flagB = 3;
        string stateAA = "";
        //string stateAB = "";
        for (int i = 0; i < bj.ChangeAStr.Length; i++ )
        {
            input[i] = int.Parse(bj.ChangeAStr.Substring(i,1));
            if (flagA == 3 && flagB == 3)
            {
                flagA = input[i];
                str += input[i].ToString();
                count++;
            }
            else if (flagA != 3 && flagB == 3)
            {
                if (stateAA == string.Empty && flagA != input[i])
                {
                    flagB = input[i];
                    //stateAB = "ok";
                }
                else
                    stateAA = "ok";

                if (stateAA == "ok" && flagA != input[i])
                {
                    sumChangeB[count]++;
                    changeBArr[i] = str;
                    count = 1;
                    str = input[i].ToString();
                    flagA = input[i];
                    flagB = 3;
                    stateAA = "";
                    //stateAB = "";

                    changeBStr += "A";
                }
                else
                {
                    str += input[i].ToString();
                    count++;
                }
            }
            else if (flagA != 3 && flagB != 3)
            {
                if (input[i] != flagA && input[i] != flagB)
                {
                    if ((flagA == 0 && flagB == 2) || (flagA == 2 && flagB == 0))
                        changeBStr += "C";
                    else
                        changeBStr += "B";
                    sumChangeB[count]++;
                    changeBArr[i] = str;
                    count = 1;
                    str = input[i].ToString();
                    flagA = input[i];
                    flagB = 3;
                    stateAA = "";
                    //stateAB = "";
                }
                else
                {
                    if (count >= 4)
                    {
                        if (input[i] == input[i - 1] && input[i] == input[i - 2])
                        {
                            if ((flagA == 0 && flagB == 2) || (flagA == 2 && flagB == 0))
                                changeBStr += "C";
                            else
                                changeBStr += "B";
                            string strNew = str.Substring(0, str.Length - 2);
                            count = count - 2;
                            sumChangeB[count]++;
                            changeBArr[i] = strNew;
                            count = 3;
                            str = input[i].ToString() + input[i].ToString() + input[i].ToString();
                            flagA = input[i];
                            flagB = 3;
                            stateAA = "ok";
                            //stateAB = "";
                        }
                        else
                        {
                            str += input[i].ToString();
                            count++;
                        }
                    }
                    else
                    {
                        str += input[i].ToString();
                        count++;
                    }
                }
            }
        }

        sumChangeB[count]++;
        bj.ChangeBLastAStr = str;

        bj.SumChangeB = sumChangeB;
        bj.ChangeBArr = changeBArr;
        return changeBStr;
    }  
}