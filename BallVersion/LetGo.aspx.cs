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
using System.IO;

public partial class LetGo : System.Web.UI.Page
{
    #region Page_load Private
    private ArrayList _ArrRound = new ArrayList();
    private ArrayList _ArrNumber = new ArrayList();
    //private bool dropChange = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        MyGoal.InnerHtml = string.Empty;
        if (!IsPostBack)
        {
            _ArrRound = ReadFile();
            _ArrRound = ControlRound(_ArrRound);
            _ArrNumber = CreateNumber(_ArrRound);
            _ArrRound = CreateRoundFindLast(_ArrRound, _ArrNumber);

            //Round_Mod rm = new Round_Mod();
            //rm.RoundID = "round";
            //_ArrRound.Insert(0, rm);

            DisplayNumber("Round");
            Session["ArrRound"] = _ArrRound;
            Session["ArrNumber"] = _ArrNumber;
        }
        else
        {
            _ArrRound = (ArrayList)Session["ArrRound"];
            _ArrNumber = (ArrayList)Session["ArrNumber"];
            //dropChange = false;
        }

    }
    #endregion

    #region ReadFile
    private ArrayList ReadFile()
    {
        StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
        string line;
        Round_Mod rm = new Round_Mod();
        ArrayList arrRound = new ArrayList();

        rm.RoundID = "round";
        arrRound.Insert(0, rm);

        while ((line = smRead.ReadLine()) != null)
        {
            rm = new Round_Mod();
            string str = line.Substring(6, 17);
            String[] strLine = str.Split(' ');

            rm.RoundID = line.Substring(0, 5);

            ListItem li = new ListItem();
            li.Text = rm.RoundID;
            li.Value = rm.RoundID;
            dropRound.Items.Add(li);

            //rm.RoundGoal = int.Parse(line.Split(' ')[11]);
            
            for (int i = 0; i < strLine.Length; i++)
            {
                rm.RoundNumber[i] = int.Parse(strLine[i]);
                rm.RoundOneZero[int.Parse(strLine[i]) - 1] = 1;
            }            
            arrRound.Add(rm);            
        }

        return arrRound;
    }

    private ArrayList ReadFile(string strRoundID)
    {
        StreamReader smRead = new StreamReader(Server.MapPath("../ball.txt"), System.Text.Encoding.Default);
        string line;
        Round_Mod rm = new Round_Mod();
        ArrayList arrRound = new ArrayList();
        
        rm.RoundID = "round";
        arrRound.Insert(0, rm);

        bool begin = false;

        while ((line = smRead.ReadLine()) != null)
        {
            rm = new Round_Mod();

            rm.RoundID = line.Substring(0, 5);

            if (rm.RoundID == strRoundID)
            {
                begin = true;
            }
            if(begin)
            {
                string str = line.Substring(6, 17);
                String[] strLine = str.Split(' ');

                //rm.RoundGoal = int.Parse(line.Split(' ')[11]);

                for (int i = 0; i < strLine.Length; i++)
                {
                    rm.RoundNumber[i] = int.Parse(strLine[i]);
                    rm.RoundOneZero[int.Parse(strLine[i]) - 1] = 1;
                }
                arrRound.Add(rm);
            }
        }

        return arrRound;
    }
    #endregion

    #region InitRound
    private ArrayList ControlRound(ArrayList arrRound)
    {
        for (int i = 0; i < arrRound.Count - 30; i++)
        {
            Round_Mod rm = new Round_Mod();
            rm = (Round_Mod)arrRound[i];
            
            for (int j = i + 1; j <= i + 30; j++)
            {
                Round_Mod rmNew = new Round_Mod();
                rmNew = (Round_Mod)arrRound[j];
                for (int x = 0; x < 33; x++)
                {
                    rm.Round30All[x] += rmNew.RoundOneZero[x];
                }
            }

            if (i != 0)
            {
                ArrayList al = new ArrayList();
                for (int j = 0; j < 6; j++)
                {
                    al.Add(rm.Round30All[rm.RoundNumber[j] - 1]);
                }

                rm.Round30StDev = StDevInput(rm.Round30All) + "_" + StDevInput(al);
            }
        }

        return arrRound;
    }

    private ArrayList CreateRoundFindLast(ArrayList arrRound, ArrayList arrNumber)
    {
        ArrayList al = new ArrayList();
        for (int i = 1; i < arrRound.Count; i++)
        {
            Round_Mod rm = (Round_Mod)arrRound[i];
            
            for (int j = 0; j < 33; j++)
            {
                Number_Mod nm = (Number_Mod)arrNumber[j];
                ArrayList alClone = new ArrayList(nm.AlZeroCount);
                al.Add(alClone);
            }
            for (int j = 0; j < rm.RoundFindLast.Length; j++)
            {
                //Number_Mod nm = (Number_Mod)arrNumber[rm.RoundNumber[j] - 1];
                ArrayList alClone = (ArrayList)al[rm.RoundNumber[j] - 1];
                rm.RoundFindLast[j] = int.Parse(alClone[1].ToString());
                alClone.RemoveAt(1);
            }
        }

        for (int i = 1; i < arrRound.Count; i++)
        {
            Round_Mod rm = (Round_Mod)arrRound[i];
            int sum = 0;
            string stDev = StDevInput(rm.RoundFindLast);
            for (int j = 0; j < rm.RoundFindLast.Length; j++)
            {
                sum += rm.RoundFindLast[j];
            }
            rm.RoundFindLastAna = sum.ToString() + "_" + stDev;
        }
        
        return arrRound;
    }
    #endregion

    #region InitNumber
    private ArrayList CreateNumber(ArrayList arrRound)
    {
        ArrayList arrNumber = new ArrayList();
        for (int i = 0; i < 33; i++)
        {
            Number_Mod nm = new Number_Mod();
            nm.NumberID = i + 1;
            
            for (int j = 0; j < arrRound.Count; j++)
            {
                Round_Mod rm = (Round_Mod)arrRound[j];
                nm.NumberAll[j] = rm.RoundOneZero[i];
            }
            ArrayList alZeroCount = new ArrayList();
            nm.NumberColor = CreateNumberColor(nm.NumberAll, ref alZeroCount);
            nm.AlZeroCount = new ArrayList(alZeroCount);
            nm.AlZeroCountStDev = CreateNumberStDev(alZeroCount);
            nm.NumberDisplay = CreateNumberDisplay(nm.NumberColor);
            nm.ColorArea = CreateColorArea(nm.NumberDisplay);
            arrNumber.Add(nm);
        }

        return arrNumber;
    }

    private ArrayList CreateNumberStDev(ArrayList alZeroCount)
    {
        ArrayList alStDev = new ArrayList();
        for (int i = 0; i < 10; i++)
        {
            string strStDev = string.Empty;
            if (i == 0)
            {
                strStDev = StDevInput(alZeroCount);
                alStDev.Add(strStDev);

                alZeroCount[0] = int.Parse(alZeroCount[0].ToString()) + 1;                
            }

            strStDev = StDevInput(alZeroCount);
            alStDev.Add(strStDev);

            alZeroCount.RemoveAt(0);
        }
        return alStDev;
    }

    private int[] CreateNumberColor(int[] numberAll, ref ArrayList alZeroCount)
    {
        int[] numberColor = new int[numberAll.Length]; 
        int count = 0;
        int myColor = 0;
        for (int i = _ArrRound.Count - 1; i > -1; i--)
        {            
            if (numberAll[i] == 1 || i == 0)
            {
                if (numberAll[i] == 0)
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


                if (i == 0)
                {
                    // if (numberAll[i] != 1)
                    alZeroCount.Insert(0, count - 1);
                }
                else
                alZeroCount.Insert(0, count);

                if (numberAll[i] == 1)
                    numberColor[i] = 1;
                else
                {
                    numberColor[i] = myColor;
                    count--;
                }

                for (int j = i + 1; j <= i + count; j++)
                    numberColor[j] = myColor;
         
                count = 0;
            }
            else
                count++;
        }
        return numberColor;
    }

    private int[] CreateNumberDisplay(int[] numberColor)
    {
        int[] numberDisplay = new int[numberColor.Length];
        
        int one = 0;
        for (int i = 0; i < _ArrRound.Count; i++)
        {
            if (numberColor[i] != 1)
                one = numberColor[i];
            else
            {
                if (i == 0)
                    one = numberColor[i + 1];
                else if (i == numberColor.Length - 1)
                    one = numberColor[i - 1];
                else if (numberColor[i - 1] <= numberColor[i + 1])
                    one = numberColor[i - 1];
                else
                    one = numberColor[i + 1];

            }
            switch (one)
            {
                case 1:
                case 2:
                    numberDisplay[i] = 0;
                    break;
                case 3:
                    numberDisplay[i] = 1;
                    break;
                case 4:
                    numberDisplay[i] = 2;
                    break;
            }
        }
        return numberDisplay;
    }

    private string CreateColorArea(int[] numberDisplay)
    {
        string strColorArea = string.Empty;
        int now = 0;
        int count = 0;
        for (int j = 0; j < _ArrRound.Count; j++)
        {
            if (j == 0)
            {
                now = numberDisplay[j];
                
                count++;
            }
            else
            {
                if (now != numberDisplay[j])
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

                    if (now == 0)
                    {
                        if (wow == 0)
                            strColorArea += "A";
                        else
                            strColorArea += "B";
                    }
                    else if (now == 1)
                    {
                        if (wow == 0)
                            strColorArea += "C";
                        else
                            strColorArea += "D";
                    }
                    else
                    {
                        if (wow == 0)
                            strColorArea += "E";
                        else
                            strColorArea += "F";
                    }

                    count = 1;

                    now = numberDisplay[j];
                }
                else
                    count++;
            }
        }
        return strColorArea;
    }
    #endregion

    #region Display
    private void DisplayNumber(string input)
    {
        switch (input)
        {
            case "Number":
                if (Session["NumberDisplay"] == null)
                {
                    for (int i = 0; i < _ArrNumber.Count; i++)
                    {
                        Number_Mod nm = new Number_Mod();
                        nm = (Number_Mod)_ArrNumber[i];

                        for (int j = 0; j < _ArrRound.Count; j++)
                        {
                            string color = "black";
                            switch (nm.NumberDisplay[j])
                            {
                                case 0:
                                    color = "red";
                                    break;
                                case 1:
                                    color = "blue";
                                    break;
                            }
                            MyGoal.InnerHtml += DisplayDiv(nm.NumberAll[j].ToString() + " ", color);
                            //if(nm.NumberAll[j] == 0)
                            //    MyGoal.InnerHtml += DisplayDiv(nm.NumberAll[j].ToString() + " ", "black");
                            //else
                            //    MyGoal.InnerHtml += DisplayDiv(nm.NumberAll[j].ToString() + " ", "red");
                        }

                        MyGoal.InnerHtml += DisplayBR();
                    }
                    Session["NumberDisplay"] = MyGoal.InnerHtml;
                }
                else
                    MyGoal.InnerHtml = Session["NumberDisplay"].ToString();
                break;
            case "Round":
                if (Session["RoundDisplay"] == null)
                {
                    for (int i = 0; i < _ArrRound.Count - 30; i++)
                    {
                        Round_Mod rm = new Round_Mod();
                        rm = (Round_Mod)_ArrRound[i];

                        MyGoal.InnerHtml += DisplayDiv(rm.RoundID + " ", "blue");

                        for (int j = 1; j <= rm.RoundOneZero.Length; j++)
                        {
                            string color = "black";
                            if (rm.RoundOneZero[j - 1] == 1)
                                color = "red";
                            if (j < 10)
                                MyGoal.InnerHtml += DisplayDiv("0" + j.ToString() + " ", color);
                            else
                                MyGoal.InnerHtml += DisplayDiv(j.ToString() + " ", color);
                        }

                        MyGoal.InnerHtml += DisplayBR();
                    }
                    Session["RoundDisplay"] = MyGoal.InnerHtml;
                }
                else
                    MyGoal.InnerHtml = Session["RoundDisplay"].ToString();
                break;
            case "Round30":
                if (Session["Round30Display"] == null)
                {
                    for (int i = 0; i < _ArrRound.Count - 30; i++)
                    {
                        Round_Mod rm = new Round_Mod();
                        rm = (Round_Mod)_ArrRound[i];

                        MyGoal.InnerHtml += DisplayDiv(rm.RoundID + " ", "blue");

                        string strGoal = string.Empty;
                        for (int j = 0; j < rm.Round30All.Length; j++)
                        {
                            string color = "green";
                            if (rm.RoundOneZero[j] == 1)
                            {
                                color = "red";
                                strGoal += DisplayDiv(" " + rm.Round30All[j].ToString() + " ", color);
                            }
                            if (rm.Round30All[j] < 10)
                                MyGoal.InnerHtml += DisplayDiv(" 0" + rm.Round30All[j].ToString(), color);
                            else
                                MyGoal.InnerHtml += DisplayDiv(" " + rm.Round30All[j].ToString() + " ", color);
                        }
                        MyGoal.InnerHtml += DisplayDiv(" " + rm.Round30StDev + " ", "black") + strGoal + DisplayBR();
                    }
                    Session["Round30Display"] = MyGoal.InnerHtml;
                }
                else
                    MyGoal.InnerHtml = Session["Round30Display"].ToString();
                break;
            case "RoundFindLast":
                if (Session["RoundFindLastDisplay"] == null)
                {
                    for (int i = 0; i < _ArrRound.Count - 30; i++)
                    {
                        Round_Mod rm = new Round_Mod();
                        rm = (Round_Mod)_ArrRound[i];

                        MyGoal.InnerHtml += DisplayDiv(rm.RoundID + " ", "blue");

                        string strGoal = string.Empty;
                        for (int j = 0; j < rm.RoundFindLast.Length; j++)
                        {
                            string color = "green";
                            //if (rm.RoundOneZero[j] == 1)
                            //{
                            //    color = "red";
                            //    strGoal += DisplayDiv(" " + rm.Round30All[j].ToString() + " ", color);
                            //}
                            if (rm.RoundFindLast[j] < 10)
                                MyGoal.InnerHtml += DisplayDiv(" 0" + rm.RoundFindLast[j].ToString(), color);
                            else
                                MyGoal.InnerHtml += DisplayDiv(" " + rm.RoundFindLast[j].ToString() + " ", color);
                        }
                        MyGoal.InnerHtml += DisplayDiv(" " + rm.RoundFindLastAna + " ", "black") + strGoal + DisplayBR();
                    }
                    Session["RoundFindLastDisplay"] = MyGoal.InnerHtml;
                }
                else
                    MyGoal.InnerHtml = Session["RoundFindLastDisplay"].ToString();
                break;
            case "NumberStDev":
                if (Session["NumberStDevDisplay"] == null)
                {
                    for (int i = 0; i < _ArrNumber.Count; i++)
                    {
                        Number_Mod nm = (Number_Mod)_ArrNumber[i];

                        for (int j = 0; j < nm.AlZeroCountStDev.Count; j++)
                        {
                            MyGoal.InnerHtml += DisplayDiv(nm.AlZeroCountStDev[j].ToString() + "  ", "green");
                        }

                        MyGoal.InnerHtml += DisplayBR();

                        for (int j = 0; j < nm.AlZeroCountStDev.Count - 1; j++)
                        {
                            string color = "blue";
                            float sub = 0;
                            if (j == 0)
                            {
                                sub = float.Parse(nm.AlZeroCountStDev[0].ToString()) - float.Parse(nm.AlZeroCountStDev[2].ToString());
                                color = "red";
                            }
                            else
                                sub = float.Parse(nm.AlZeroCountStDev[j].ToString()) - float.Parse(nm.AlZeroCountStDev[j + 1].ToString());

                            if (j == 1)
                                color = "black";
                            MyGoal.InnerHtml += DisplayDiv(sub.ToString() + "  ", color);
                        }

                        MyGoal.InnerHtml += DisplayBR();
                    }
                    
                    Session["NumberStDevDisplay"] = MyGoal.InnerHtml;
                }
                else
                    MyGoal.InnerHtml = Session["NumberStDevDisplay"].ToString();
                break;
        }
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

    #region LinkButton
    protected void linkBtnNumber_Click(object sender, EventArgs e)
    {
        DisplayNumber("Number");
    }

    protected void LinkBtnRound_Click(object sender, EventArgs e)
    {
        DisplayNumber("Round");
    }

    protected void LinkBtnRound30_Click(object sender, EventArgs e)
    {
        DisplayNumber("Round30");
    }

    protected void LinkBtnNumStDev_Click(object sender, EventArgs e)
    {
        DisplayNumber("NumberStDev");
    }

    protected void LinkBtnRoundFindLast_Click(object sender, EventArgs e)
    {
        DisplayNumber("RoundFindLast");
    }
    #endregion

    #region StDev
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

    private string StDevInput(int[] input)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("input", typeof(int));
        for (int i = 0; i < input.Length; i++)
        {
            DataRow dRow = dt.NewRow();
            dRow["input"] = float.Parse(input[i].ToString());
            dt.Rows.Add(dRow);
        }
        object rt = dt.Compute("StDev(input)", "true");
        return rt.ToString();
    }
    #endregion

    #region Drop
    protected void dropRound_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["NumberDisplay"] = null;
        Session["NumberStDevDisplay"] = null;
        Session["Round30Display"] = null;
        Session["RoundDisplay"] = null;
        _ArrRound = ReadFile(dropRound.SelectedItem.Value);
        _ArrRound = ControlRound(_ArrRound);
        _ArrNumber = CreateNumber(_ArrRound);
        _ArrRound = CreateRoundFindLast(_ArrRound, _ArrNumber);

        //Round_Mod rm = new Round_Mod();
        //rm.RoundID = "round";
        //_ArrRound.Insert(0, rm);

        DisplayNumber("Round");
        Session["ArrRound"] = _ArrRound;
        Session["ArrNumber"] = _ArrNumber;

    }
    #endregion

}
