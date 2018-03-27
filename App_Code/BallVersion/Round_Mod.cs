using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Round_Mod 的摘要说明
/// </summary>
public class Round_Mod
{
	public Round_Mod()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    
    private string _RoundID = string.Empty;
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

    private int[] _RoundNumber = new int[6];
    public int[] RoundNumber
    {
        get
        {
            return this._RoundNumber;
        }
        set
        {
            this._RoundNumber = value;
        }
    }

    //private int[] _RoundLast = new int[6];
    //public int[] RoundLast
    //{
    //    get
    //    {
    //        return this._RoundLast;
    //    }
    //    set
    //    {
    //        this._RoundLast = value;
    //    }
    //}

    private int[] _RoundFindLast = new int[6];
    public int[] RoundFindLast
    {
        get
        {
            return this._RoundFindLast;
        }
        set
        {
            this._RoundFindLast = value;
        }
    }

    private string _RoundFindLastAna = string.Empty;
    public string RoundFindLastAna
    {
        get
        {
            return this._RoundFindLastAna;
        }
        set
        {
            this._RoundFindLastAna = value;
        }
    }

    private int[] _RoundOneZero = new int[33];
    public int[] RoundOneZero
    {
        get
        {
            return this._RoundOneZero;
        }
        set
        {
            this._RoundOneZero = value;
        }
    }

    private int[] _Round30All = new int[33];
    public int[] Round30All
    {
        get
        {
            return this._Round30All;
        }
        set
        {
            this._Round30All = value;
        }
    }

    private string _Round30StDev = string.Empty;
    public string Round30StDev
    {
        get
        {
            return this._Round30StDev;
        }
        set
        {
            this._Round30StDev = value;
        }
    }

    //private int _RoundGoal = 0;
    //public int RoundGoal
    //{
    //    get
    //    {
    //        return this._RoundGoal;
    //    }
    //    set
    //    {
    //        this._RoundGoal = value;
    //    }
    //}
}
