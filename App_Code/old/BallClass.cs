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

/// <summary>
/// BallClass 的摘要说明
/// </summary>
public class BallClass
{
	public BallClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static ArrayList CreateBallClassArray(StreamReader smRead)
    {
        
        string line;
        ArrayList arrBall = new ArrayList();
        //int[] lastBall = new int[33];
        int[] lastFiveBall = new int[33];
        while ((line = smRead.ReadLine()) != null)
        {
            string str = line.Substring(0, 23);
            string[] strArray = str.Split(' ');

            BallClassMod bc = new BallClassMod();

            bc.RoundID = strArray[0];//期号
            for (int i = 1; i <= 33; i++)
            {
                int number = 0;
                
                for (int j = 1; j <= 6; j++)
                {
                    if (int.Parse(strArray[j]) == i)
                    {
                        number = i;
                        bc.BallNum += i;//总合数

                        if (i < 17)
                            bc.SmallNum++;//小号数
                        if (i % 2 == 1)
                            bc.OddNum++;//奇数数
                        if (PrimeNumber(i))
                            bc.PrimeNum++;//质数数

                        break;
                    }
                }
                bc.RoundBall[i - 1] = number;//基本数据
            }
            bc.SpanNum = int.Parse(strArray[6]) - int.Parse(strArray[1]);//首尾跨度差
            
            arrBall.Add(bc);

            if (arrBall.Count > 1)
            {
                ((BallClassMod)arrBall[arrBall.Count - 2]).LastBall = bc.RoundBall;                
            }
        }

        return arrBall;
    }

    private static bool PrimeNumber(int n)
    {
        bool b = true;
        if (n == 1 || n == 2)
            b = true;
        else
        {
            int sqr = Convert.ToInt32(Math.Sqrt(n));
            for (int i = sqr; i >= 2; i--)
            {
                if (n % i == 0)
                {
                    b = false;
                }
            }
        }
        return b;
    }

    
}

public class BallClassMod
{
    private string _RoundID = string.Empty;//期号
    private int[] _RoundBall = new int[33];//基本数据
    private int[] _OldBall = new int[33];//前5期数据
    private int[] _LastBall = new int[33];//上期数据
    private int _NearNum = 0;//临号数
    private int _ReapterNum = 0;//重号数
    private int _NeatReapterNum = 0;//临号重号和
    private int _BallNum = 0;//总合数
    private int _SmallNum = 0;//小号数
    private int _OddNum = 0;//奇数数
    private int _OldNum = 0;//旧号数
    private int _PrimeNum = 0;//质数数
    private int _SpanNum = 0;//首尾跨度差

    public string RoundID
    {
        get
        {
            return this._RoundID;
        }
        set
        {
            this._RoundID = value;
        }
    }

    public int[] RoundBall
    {
        get
        {
            return this._RoundBall;
        }
        set
        {
            this._RoundBall = value;
        }
    }

    public int[] OldBall
    {
        get
        {
            return this._OldBall;
        }
        set
        {
            this._OldBall = value;
        }
    }

    public int[] LastBall
    {
        get
        {
            return this._LastBall;
        }
        set
        {
            this._LastBall = value;
        }
    }

    public int NearNum
    {
        get
        {
            return this._NearNum;
        }
        set
        {
            this._NearNum = value;
        }
    }

    public int ReapterNum
    {
        get
        {
            return this._ReapterNum;
        }
        set
        {
            this._ReapterNum = value;
        }
    }

    public int NeatReapterNum
    {
        get
        {
            return this._NeatReapterNum;
        }
        set
        {
            this._NeatReapterNum = value;
        }
    }

    public int BallNum
    {
        get
        {
            return this._BallNum;
        }
        set
        {
            this._BallNum = value;
        }
    }

    public int SmallNum
    {
        get
        {
            return this._SmallNum;
        }
        set
        {
            this._SmallNum = value;
        }
    }

    public int OddNum
    {
        get
        {
            return this._OddNum;
        }
        set
        {
            this._OddNum = value;
        }
    }

    public int OldNum
    {
        get
        {
            return this._OldNum;
        }
        set
        {
            this._OldNum = value;
        }
    }

    public int PrimeNum
    {
        get
        {
            return this._PrimeNum;
        }
        set
        {
            this._PrimeNum = value;
        }
    }

    public int SpanNum
    {
        get
        {
            return this._SpanNum;
        }
        set
        {
            this._SpanNum = value;
        }
    }

}
