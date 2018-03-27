using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
///Class1 的摘要说明
/// </summary>
public class MyGame
{
    public MyGame()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
   
    public static ArrayList GiveMyOpinion(ArrayList alInput, string flag)
    {
        ArrayList alReturn = new ArrayList();
        ArrayList alMy = new ArrayList();
        float[] temp = new float[10];
        switch (flag)
        {
            case "0":
                temp = new float[10]{0.4f, 0.8f, 1.2f, 1.6f, 2, 2.4f, 2.8f, 3.2f, 3.6f, 4};
                break;
        }
        for (int i = 0; i < alInput.Count; i++)
        {
            float[] myNum = (float[])alInput[i];
            //int[] iiNum = new int[myNum.Length - 1];
            string str = "";

            for (int j = 2; j < myNum.Length; j++)
                str += ReturnNumber(myNum[j], temp);
            alMy.Add(str);    
        }

        alReturn = ReturnStatistics(alMy);

        return alReturn;
    }

    private static ArrayList ReturnStatistics(ArrayList alInput)
    {
        alInput.Sort();

        ArrayList alReturn = new ArrayList();
        string now = alInput[0].ToString();
        int count = 1;
        for (int i = 1; i < alInput.Count; i++)
        {
            if (alInput[i].ToString() == now)
                count++;
            else
            {
                alReturn.Add(now + "_" + count);
                now = alInput[i].ToString();
                count = 1;
            }
        }        
        return alReturn;
    }

    private static string ReturnNumber(float ff, float[] temp)
    {
        int i;
        for (i = 0; i < temp.Length; i++)
        {
            if (ff < temp[i])
                break;
        }
        if (i == 10)
            i = 9;
        return i.ToString();
    }

}