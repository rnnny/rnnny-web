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

public partial class AjaxServer : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Ajax"] != null && Request.QueryString["input"] != null && Request.QueryString["count"] != null)
        {
            ArrayList alNormal = new ArrayList();
            ArrayList alSpecial = new ArrayList();
            ArrayList alYStr = new ArrayList();

            alNormal = (ArrayList)Session["Normal"];
            alSpecial = (ArrayList)Session["Special"];
            alYStr = (ArrayList)Session["Y_Str"];

            string area = (string)Session["Area"];

            string str = DrawOneLine(alNormal, alSpecial, alYStr, area, int.Parse(Request.QueryString["input"].ToString()), Request.QueryString["Ajax"].ToString(), int.Parse(Request.QueryString["count"].ToString()));
            Response.Write(str);
        }        
    }

    private string DrawOneLine(ArrayList alNormal, ArrayList alSpecial, ArrayList alYStr, string area, int input, string color, int count)
    {
        string str = string.Empty;
        if (input < alNormal.Count)
        {            
            ArrayList al = (ArrayList)alNormal[input];
            ArrayList alLine = new ArrayList();
            string[] splitStr = area.Split('_');
            float begin = 0, end = 0, xDistance = 0, yDistance = 0;
            for (int i = 0; i < splitStr.Length; i++)
            {
                if (i == 0) begin = float.Parse(splitStr[i]);
                else if (i == splitStr.Length - 1) end = float.Parse(splitStr[i]);
                else alLine.Add(splitStr[i]);
            }

            yDistance = 800 / (end - begin);
            xDistance = 30;

            if (count == 0)
            {
                str += "<v:shape CoordOrig='0,0' CoordSize='8000,800' style='width:8000;height:800'/>"
               + "<v:line id='line' from='0,0' to='0,800' position='absolute' strokeColor='red' strokeWeight='2'></v:line>"
               + "<v:line id='line' from='0,0' to='8000,0' position='absolute' strokeColor='red' strokeWeight='2'></v:line>"
               + "<v:line id='line' from='8000,0' to='8000,800' position='absolute' strokeColor='red' strokeWeight='2'></v:line>"
               + "<v:line id='line' from='0,800' to='8000,800' position='absolute' strokeColor='red' strokeWeight='2'></v:line>";


                for (int i = 1; i < Convert.ToInt16(800 / yDistance); i++)
                {
                    str += "<v:line id='line' from='0, " + Convert.ToString(i * yDistance) + "' to='8000, " + Convert.ToString(i * yDistance) + "' position='absolute' strokeColor='blue' strokeWeight='1'></v:line>";
                }

                for (int i = 1; i < al.Count; i++)
                {
                    str += "<v:line id='line' from='" + Convert.ToString(i * xDistance) + ", 0' to='" + Convert.ToString(i * xDistance) + ", 800' position='absolute' strokeColor='blue' strokeWeight='1'></v:line>";
                }

                for (int i = 0; i < alLine.Count; i++)
                {
                    str += "<v:line id='line' from='0, " + Convert.ToString(float.Parse(alLine[i].ToString()) * yDistance) + "' to='8000, " + Convert.ToString(float.Parse(alLine[i].ToString()) * yDistance) + "' position='absolute' strokeColor='red' strokeWeight='" + Convert.ToString(i + 2) + "'></v:line>";
                }
            }
            for (int i = 0; i < al.Count - 1; i++)
            {
                str += "<v:line id='line' from='" + Convert.ToString((i + 1) * xDistance) + ", " + Convert.ToString(float.Parse(al[i + 1].ToString()) * yDistance) + "' to='" + Convert.ToString(i * xDistance) + ", " + Convert.ToString(float.Parse(al[i].ToString()) * yDistance) + "' position='absolute' strokeColor='" + color + "' strokeWeight='2'></v:line>";
            }
        }
        return str;
    }
}
