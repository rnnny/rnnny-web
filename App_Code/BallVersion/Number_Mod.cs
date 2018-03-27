using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

/// <summary>
/// Number_Mod 的摘要说明
/// </summary>
public class Number_Mod
{
    private const int MAXRound = 400;
	public Number_Mod()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    private int _NumberID = 0;
    public int NumberID
    {
        get
        {
            return this._NumberID;
        }
        set
        {
            this._NumberID = value;
        }
    }

    private int[] _NumberAll = new int[MAXRound];
    public int[] NumberAll
    {
        get
        {
            return this._NumberAll;
        }
        set
        {
            this._NumberAll = value;
        }
    }

    private int[] _NumberColor = new int[MAXRound];
    public int[] NumberColor
    {
        get
        {
            return this._NumberColor;
        }
        set
        {
            this._NumberColor = value;
        }
    }

    private int[] _NumberDisplay = new int[MAXRound];
    public int[] NumberDisplay
    {
        get
        {
            return this._NumberDisplay;
        }
        set
        {
            this._NumberDisplay = value;
        }
    }

    private ArrayList _AlZeroCount = new ArrayList();
    public ArrayList AlZeroCount
    {
        get
        {
            return this._AlZeroCount;
        }
        set
        {
            this._AlZeroCount = value;
        }
    }

    private ArrayList _AlZeroCountStDev = new ArrayList();
    public ArrayList AlZeroCountStDev
    {
        get
        {
            return this._AlZeroCountStDev;
        }
        set
        {
            this._AlZeroCountStDev = value;
        }
    }

    private string _ColorArea = string.Empty;
    public string ColorArea
    {
        get
        {
            return this._ColorArea;
        }
        set
        {
            this._ColorArea = value;
        }
    }
}
