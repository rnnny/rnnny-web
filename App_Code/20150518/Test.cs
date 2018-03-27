using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Data;

public class MyTest
{
    public const int MaxMax = 3000;

    #region SelectSomeRed
    public static string ReturnChangeStr(string strRound2, string strRound3, int a1, int a2, int a3, int a4, int a5, int a6)
    {
        string[] str2 = strRound2.Split(' ');
        string[] str3 = strRound3.Split(' ');
        int[] round  = new int[str2.Length];
        int[] last = new int[str2.Length];

        for (int i = 0; i < round.Length; i++ )
        {
            last[i] = int.Parse(str3[i]);
            round[i] = int.Parse(str2[i]);
        }

        round[(a1 -1) / 3]++;
        round[(a2 - 1) / 3]++;
        round[(a3 - 1) / 3]++;
        round[(a4 - 1) / 3]++;
        round[(a5 - 1) / 3]++;
        round[(a6 - 1) / 3]++;

        string strChangeA = string.Empty;
        string strChangeB = string.Empty;
        int change = 0;
        for (int j = 0; j < round.Length; j++)
        {
            if (round[j] != last[j])
            {
                change++;
                if (round[j] > last[j])
                    strChangeA += (round[j] - last[j]).ToString();
                else
                    strChangeB += (last[j] - round[j]).ToString();
            }
        }
        return strChangeA + "-" + strChangeB + "|" + change.ToString();
    }
    #endregion

    #region PrimeTwoNearRepeat
    /// <summary>
    /// 质数为1
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int ISPrime(long n)
    {
        long b = n / 2;
        //if (n < 2) return 1;
        if (n <= 2) return 1;
        else
        {
            if (n % 2 == 0) return 0;//偶数一步就可以判断出来
            for (long a = 3; a <= b; a = a + 2)//大于4的偶数中没有质数，所以不用作为被除数
            {
                if (n % a == 0) return 0;
                b = n / a;//把被除数的范围进一步缩小
            }
            return 1;
        }
    }

    /// <summary>
    /// 奇数为1
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int ISTwo(long n)
    {
        if (n % 2 == 0) return 0;//偶数一步就可以判断出来
        else
            return 1;
    }

    /// <summary>
    /// near repeat 重复加
    /// </summary>
    /// <param name="redBall"></param>
    /// <param name="aa"></param>
    /// <param name="GameOver"></param>
    /// <returns></returns>
    public static int ISNearRepeat_2(int[,] redBall, int aa, int GameOver)
    {
        int count = 0;
        if (aa - 2 >= 0 && redBall[aa - 2, GameOver] == 1)
            count++;
        if (aa < 33 && redBall[aa, GameOver] == 1)
            count++;        
        if (aa - 1 >= 0 && redBall[aa - 1, GameOver] == 1)
            count++;
        return count;
    }

    /// <summary>
    /// sum Near Repeat
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int ISNearRepeat(int[,] redBall, int aa, int GameOver)
    {
        if (ISRepeat(redBall, aa, GameOver) == 1)
            return 1;
        else if (ISNear(redBall, aa, GameOver) == 1)
            return 1;
        else 
            return 0;
    }

    public static int ISNear(int[,] redBall, int aa, int GameOver)
    {
        if (aa - 1 >= 0 && redBall[aa - 1, GameOver] == 1)
            return 0;
        else if (aa - 2 >= 0 && redBall[aa - 2, GameOver] == 1)
            return 1;
        else if (aa < 33 && redBall[aa, GameOver] == 1)
            return 1;
        else
            return 0;
    }

    public static int ISRepeat(int[,] redBall, int aa, int GameOver)
    {
        if (aa - 1 >= 0 && redBall[aa - 1, GameOver] == 1)
            return 1;
        else
            return 0;
    }
    #endregion

    #region ReadFile
    public static int ReadFile(ArrayList arrRound, ArrayList arrGoal, int[,] redBall, int[,] miniRedBall, int[] blueBall, int[] sixSum, string file)
    {
        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase; 
        StreamReader smRead = new StreamReader(strPath + "\\"+ file +".txt", System.Text.Encoding.Default);
        string line;
        int count = 1;
        arrRound.Add("1111111");
        arrGoal.Add("1111111");
        int lineMax = 0;
        if (file == "ball")
            lineMax = 33;
        else
            lineMax = 35;

        for (int i = 0; i < lineMax; i++)
        {
            redBall[i, 0] = 1;
        }
        while ((line = smRead.ReadLine()) != null)
        {
            ReadLine(arrRound,arrGoal, redBall, miniRedBall, blueBall, sixSum, line, count, file, lineMax);
            count++;
        }
        smRead.Close();
        return count;
    }

    public static int ReadFile(ArrayList arrRound, ArrayList arrGoal, int[,] redBall, int[,] miniRedBall, int[] blueBall, int[] sixSum, int maxCount, string file)
    {
        string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        StreamReader smRead = new StreamReader(strPath + "\\"+ file +".txt", System.Text.Encoding.Default);
        string line;
        int count = 1;
        arrRound.Add("1111111");
        arrGoal.Add("1111111");
        int lineMax = 0;
        if (file == "ball")
            lineMax = 33;
        else
            lineMax = 35;

        for (int i = 0; i < lineMax; i++)
        {
            redBall[i, 0] = 1;
        }
        while ((line = smRead.ReadLine()) != null && count <= maxCount)
        {
            //int intGoal;
            ReadLine(arrRound,arrGoal, redBall, miniRedBall, blueBall, sixSum, line, count, file, lineMax);
            count++;
        }
        smRead.Close();
        return count;
    }

    private static int ReadLine(ArrayList arrRound, ArrayList arrGoal, int[,] redBall, int[,] miniRedBall, int[] blueBall, int[] sixSum, string line, int count, string file, int lineMax)
    {
       //int intGoal;
            if (!line.Contains("//"))//intGoal <= 2)
            {
                string str;
                if (line.Contains("查看统计"))
                {
                    string[] ss = line.Split('\t');
                    //intGoal = int.Parse(ss[5]);
                    str = ss[2];
                    if (file == "ball")
                        blueBall[count] = int.Parse(ss[3]);
                    else
                    {
                        string[] big = ss[3].Split(' ');
                        blueBall[count] = int.Parse(big[0]);
                        sixSum[count] = int.Parse(big[1]);
                    }
                    arrRound.Add(ss[0]);

                    if (int.Parse(ss[0]) > 2009113)
                    {
                        arrGoal.Add(ss[5]);
                    }
                }
                else
                {
                    string[] ss = line.Split(' ');
                    //intGoal = int.Parse(line.Split(' ')[11]);
                    str = line.Substring(6, 17);
                    blueBall[count] = int.Parse(line.Substring(24, 2));
                    arrRound.Add("20" + line.Substring(0, 5));

                    arrGoal.Add(ss[11]);
                }

                ArrayList alLine = new ArrayList();
                for (int k = 0; k < str.Split(' ').Length; k++)
                {
                    alLine.Add(str.Split(' ')[k]);
                }

                if (file == "ball")
                {
                    for (int k = 0; k < alLine.Count - 1; k++)
                    {
                        sixSum[count] += int.Parse(alLine[k].ToString());
                    }
                }

                int redCount = 0;
                for (int i = 1; i <= lineMax; i++)
                {
                    string a = i.ToString("00");

                    if (alLine.Contains(a))
                    {
                        miniRedBall[redCount, count] = i;
                        redCount++;
                        redBall[i - 1, count] = 1;
                    }
                    else
                    {
                        redBall[i - 1, count] = 0;
                    }
                }
            }
        return count;
    }
    #endregion

    #region 组合算法
    /// <summary>
    /// 排列循环方法
    /// </summary>
    /// <param name="N"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    public static long P1(int N, int R)
    {
        if (R > N || R <= 0 || N <= 0) throw new ArgumentException("params invalid!");
        long t = 1;
        int i = N;

        while (i != N - R)
        {
            try
            {
                checked
                {
                    t *= i;
                }
            }
            catch
            {
                throw new OverflowException("overflow happens!");
            }
            --i;
        }
        return t;
    }

    /// <summary>
    /// 排列堆栈方法
    /// </summary>
    /// <param name="N"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    public static long P2(int N, int R)
    {
        if (R > N || R <= 0 || N <= 0) throw new ArgumentException("arguments invalid!");
        Stack<int> s = new Stack<int>();
        long iRlt = 1;
        int t;
        s.Push(N);
        while ((t = s.Peek()) != N - R)
        {
            try
            {
                checked
                {
                    iRlt *= t;
                }
            }
            catch
            {
                throw new OverflowException("overflow happens!");
            }
            s.Pop();
            s.Push(t - 1);
        }
        return iRlt;
    }

    /// <summary>
    /// 组合
    /// </summary>
    /// <param name="N"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    public static long CC(int N, int R)
    {
        return P1(N, R) / P1(R, R);
    }
    #endregion

    #region SubStr
    public static string GetSubStr(int[] sub)
    {
        int aaa = 0;//得出分类结果。a连续数相同 b非连续数相同 c不相同
        int aaaAll = 0;
        string str = string.Empty;
        bool same = false;
        string subStr = string.Empty;
        for (int j = 0; j < sub.Length; j++)
        {
            if (j != 0)
            {
                if (sub[j] == sub[j - 1])
                {
                    str += j.ToString() + (j - 1).ToString();
                    aaa++;
                    aaaAll++;
                    if (same == false)
                    {
                        aaa++;
                        aaaAll++;
                    }
                    same = true;
                }
                else if (same)
                {
                    subStr += "a" + aaa.ToString();
                    aaa = 0;
                    same = false;
                }

                if (j == sub.Length - 1 && same)
                {
                    subStr += "a" + aaa.ToString();
                }
            }
        }

        ArrayList al = new ArrayList();
        for (int j = 0; j < sub.Length; j++)
        {
            if (!str.Contains(j.ToString()))
            {
                al.Add(sub[j]);
            }
        }

        al.Sort();
        same = false;
        int bbb = 0;
        int bbbAll = 0;

        for (int j = 0; j < al.Count; j++)
        {
            if (j != 0)
            {
                if (al[j].ToString() == al[j - 1].ToString())
                {
                    bbb++;
                    bbbAll++;
                    if (same == false)
                    {
                        bbb++;
                        bbbAll++;
                    }
                    same = true;
                }
                else if (same)
                {
                    subStr += "b" + bbb.ToString();
                    bbb = 0;
                    same = false;
                }

                if (j == al.Count - 1 && same)
                {
                    subStr += "b" + bbb.ToString();
                }
            }


        }
        int ccc = sub.Length - aaaAll - bbbAll;
        if (ccc != 0)
            subStr += "c" + ccc.ToString();

        return subStr;
    }

    #endregion

    #region StdevDD
    public static List<double> CreateStdev33DD(int[] ball)
    {
        List<double>  dd = new List<double>();
        int count = 0;
        for (int i = 0; i < ball.Length; i++)
        {
            if (ball[i] == 0)
                count++;
            else
            {
                dd.Add(count);
                count = 0;                
            }
        }

        return dd;
    }

    public static List<double> CreateStdev7DD(int[] ball)
    {
        List<double> dd = new List<double>();
        for (int i = 0; i < ball.Length; i++)
        {
            dd.Add(ball[i]);
        }

        return dd;
    }
    #endregion

    #region Number
    public static int FindUpNumber(int i, int j, int arrLintCount, int[,] redBall)
    {
        int output = 0;
        bool find = false;
        int ii = i + 1;
        while (!find)
        {
            if (ii >= arrLintCount && arrLintCount != 2)
            {
                find = true;
                output = ii - i;
            }
            else if (redBall[j, ii] == 1)
            {
                output = ii - i - 1;
                find = true;
            }
            else
                ii++;
        }

        return output;
    }
    #endregion

    #region HandInput
    public static string HandInput(string str, ArrayList arrRound, int[,] miniRedBall, int[,] redBall, hangzhou hz)
    {

        string[] strNew = str.Trim().Split(' ');

        int[] input = new int[strNew.Length];

        int sum = 0;
        int nearRepeat = 0;
        int prime = 0;
        int two = 0;
        int leftRight = 0;
        int upup = 0;
        for (int i = 0; i < strNew.Length; i++)
        {
            input[i] = int.Parse(strNew[i]);
            sum += input[i];

            upup += MyTest.FindUpNumber(0, input[i] - 1, arrRound.Count - 1, redBall);
            two += MyTest.ISTwo(input[i]);
            prime += MyTest.ISPrime(input[i]);
            nearRepeat += MyTest.ISNearRepeat(redBall, input[i], 1);
        }

        leftRight = input[strNew.Length - 1] - input[0];




        string returnStr = "sum=" + sum.ToString() + "_" + hz.Sum.ToString() + "|leftRight=" + leftRight.ToString() + "_" + hz.LeftRight.ToString() + "|upup=" + upup.ToString() + "_" + hz.UpUp.ToString() + "|two=" + two.ToString() + "_" + hz.Two.ToString() + "|prime=" + prime.ToString() + "_" + hz.Prime.ToString() + "|nearRepeat=" + nearRepeat.ToString() + "_" + hz.NearRepeat.ToString();

        return returnStr;
    }

    #endregion

    #region MySelect
    
    //private static bool FindFromArrayList(string[] str, ArrayList al)
    //{
    //    bool find = true;

    //    for (int i = 0; i < al.Count; i++ )
    //    {
    //        int count = 0;
    //        for (int j = 0; j < str.Length; j++)
    //        {
    //            if (!al[i].ToString().Contains(str[j]))
    //            {
    //                find = false; break;
    //            }
    //            else
    //                count++;
    //        }
    //        if (count == 4)
    //        {
    //            find = true;
    //            break;
    //        }
    //    }

    //    if (al.Count == 0)
    //        find = false;
    //    return find;
    //}

    public static ArrayList MyFourToSix(string[] inputAll, int max, ref DataTable dt, int[,] redBall, string six)
    {
        DataRow newRow;
        ArrayList al = new ArrayList();

        string[] input = new string[inputAll.Length];
        int[] num = new int[inputAll.Length];
        for (int i = 0; i < input.Length; i++)
        {
            string[] str = inputAll[i].Split('#');

            num[i] = int.Parse(str[0]);

            input[i] = str[1];

        }

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != "")
            {
                string[] strI = input[i].Split('|');
                //if (FindFromArrayList(strI, al))
                //{
                //    input[i] = "";
                //}
                //else
                //{
                //bool select = false;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] != "")
                    {
                        string[] strJ = input[j].Split('|');
                        //if (FindFromArrayList(strJ, al))
                        //{
                        //    input[j] = "";
                        //}
                        //else
                        //{
                        int count = 0;
                        for (int x = 0; x < strI.Length; x++)
                        {
                            if (input[j].Contains(strI[x]))
                                count++;
                            if (count > 2)
                                break;
                        }

                        if (count == 2)
                        {

                            //string[] str = al[i].ToString().Split('_');
                            string[] str0 = input[i].Split('|');
                            string[] str1 = input[j].Split('|');

                            ArrayList alNew = new ArrayList();

                            for (int x = 0; x < str0.Length; x++)
                            {
                                if (!alNew.Contains(str0[x]))
                                    alNew.Add(str0[x]);
                                if (!alNew.Contains(str1[x]))
                                    alNew.Add(str1[x]);
                            }

                            int countAl = 0;
                            for (int x = 0; x < al.Count; x++)
                            {
                                countAl = 0;
                                for (int y = 0; y < alNew.Count; y++)
                                {
                                    if (al[x].ToString().Split('%')[0].Contains(alNew[y].ToString()))
                                        countAl++;

                                    if (countAl > 3)
                                        break;
                                }
                                if (countAl > 3)
                                    break;
                            }
                            if (countAl <= 3)
                            {
                                alNew.Sort();
                                string strSix = "";
                                for (int x = 0; x < alNew.Count; x++)
                                {
                                    if (x == alNew.Count - 1)
                                        strSix += alNew[x].ToString();
                                    else
                                        strSix += alNew[x].ToString() + "|";
                                }

                                //al[i] = al[i].ToString() ;
                                if (six.Contains(strSix))
                                {
                                    string[] str6 = strSix.Split('|');

                                    int a1 = int.Parse(str6[0]);
                                    int a2 = int.Parse(str6[1]);
                                    int a3 = int.Parse(str6[2]);
                                    int a4 = int.Parse(str6[3]);
                                    int a5 = int.Parse(str6[4]);
                                    int a6 = int.Parse(str6[5]);

                                    //if ((a2 - a1 == 1 || a3 - a2 == 1 || a4 - a3 == 1 || a5 - a4 == 1 || a6 - a5 == 1) && (ISRepeat(redBall, a1, 1) == 1 || ISRepeat(redBall, a2, 1) == 1 || ISRepeat(redBall, a3, 1) == 1 || ISRepeat(redBall, a4, 1) == 1 || ISRepeat(redBall, a5, 1) == 1 || ISRepeat(redBall, a6, 1) == 1))
                                    if ((a2 - a1 == 1 || a3 - a2 == 1 || a4 - a3 == 1 || a5 - a4 == 1 || a6 - a5 == 1) || (ISRepeat(redBall, a1, 1) == 1 || ISRepeat(redBall, a2, 1) == 1 || ISRepeat(redBall, a3, 1) == 1 || ISRepeat(redBall, a4, 1) == 1 || ISRepeat(redBall, a5, 1) == 1 || ISRepeat(redBall, a6, 1) == 1))
                                    {

                                        al.Add(input[i] + "_" + input[j] + "=" + strSix + "%" + (num[i] + num[j]).ToString());

                                        newRow = dt.NewRow();
                                        newRow["FLAG"] = 778877;
                                        newRow["A1"] = num[i] + num[j];
                                        newRow["A12"] = strSix;
                                        newRow["A15"] = NewNumber.GetTwoNearRepeatRound(redBall, a1, a2, a3, a4, a5, a6, 0);
                                        newRow["A13"] = a1 + a2 + a3 + a4 + a5 + a6;
                                        newRow["A14"] = a6 - a1;
                                        dt.Rows.Add(newRow);

                                        input[i] = "";
                                        input[j] = "";

                                        //select = true;
                                        break;
                                    }

                                }
                            }
                        }


                    }
                    //if (!select)
                    //{
                    //    newRow = dt.NewRow();
                    //    newRow["FLAG"] = 77887788;
                    //    newRow["A1"] = num[i];
                    //    newRow["A12"] = input[i];

                    //    dt.Rows.Add(newRow);
                    //}
                }
            }
        }


        return al;
    }
    public static ArrayList MySelect(string[] input, int max, ref DataTable dt)
    {
        ArrayList al = new ArrayList();

        for (int i = 0; i < input.Length; i++)
        {
            GetFive(input[i], ref dt);
        }
            return al;
    }
    public static string GetOneCircle(int a1,int a2, int a3, int a4, int a5, int a6,int[,] redBall)
    {
        int max = 0;
        int[] aa = new int[6];

        aa[0] = a1 - 1 + 33 - a6;
        aa[1] = a2 - a1 - 1;
        aa[2] = a3 - a2 - 1;
        aa[3] = a4 - a3 - 1;
        aa[4] = a5 - a4 - 1;
        aa[5] = a6 - a5 - 1;

        NormalDistribution nn = new NormalDistribution();
        List<double> dd = new List<double>();
        for (int i = 0; i < 6; i++ )
            dd.Add(Convert.ToDouble(aa[i]));

         

        double ddd = nn.stdev(dd);

        for (int i = 0; i < aa.Length; i++)
        {
            if (aa[i] > max)
                max = aa[i];
        }

        string str = "";
        string strNew = "";
        bool change = false;
        for (int i = 0; i < aa.Length; i++)
        {
            if (max == aa[i] || change)
            {
                str += aa[i].ToString() + "_";
                if (max == aa[i])
                    change = true;
            }
            else
            {
                strNew += aa[i].ToString() + "_";
            }
        }

        return (str + strNew).Substring(0, (str + strNew).Length - 1) + "|" + ddd.ToString();//+ "|" + near.ToString() +  "|" + repeat.ToString();
    }

    public static string GetCircle(int ii, string input, ref DataTable dt, int[,] redBall, ArrayList arrRound, ArrayList alSum)
    {
        string returnStr = "";
        DataRow newRow;
        string[] str = input.Split('|');

        int a1 = int.Parse(str[0]);
        int a2 = int.Parse(str[1]);
        int a3 = int.Parse(str[2]);
        int a4 = int.Parse(str[3]);
        int a5 = int.Parse(str[4]);
        int a6 = int.Parse(str[5]);

        int[] aa = new int[6];
        //int max = 0;
        alSum.Add(a1 + a2 + a3 + a4 + a5 + a6);

        for (int i = 0; i < aa.Length; i++)
        {
            if (i == 0)
            {
                aa[i] = int.Parse(str[i]) - 1 + 33 - int.Parse(str[5]);
                //max = aa[i];
            }
            else
            {
                aa[i] = int.Parse(str[i]) - int.Parse(str[i - 1]) - 1;
                //if (max < aa[i])
                   // max = aa[i];
            }
        }
        
        
        newRow = dt.NewRow();
        newRow["FLAG"] = 778888555;

        newRow["A2"] = int.Parse(str[5]) - int.Parse(str[0]);
        newRow["A12"] = input;
        newRow["A13"] = aa[0].ToString() + "_" +aa[1].ToString() + "_" +aa[2].ToString() + "_" +aa[3].ToString() + "_" +aa[4].ToString() + "_" +aa[5].ToString() ;
        //string strNew = "";
        //bool change = false;
        //for (int i = 0; i < aa.Length; i++)
        //{
        //    if (max == aa[i] || change)
        //    {
        //        newRow["A14"] += aa[i].ToString("00");
        //        if (max == aa[i])
        //            change = true;
        //    }
        //    else
        //    {
        //        strNew += aa[i].ToString("00");
        //    }
        //}
        string strCircle = GetOneCircle(a1,a2,a3,a4,a5,a6,redBall);
        newRow["A14"] = strCircle.Split('|')[0];
        newRow["A15"] = strCircle.Split('|')[1];

        ArrayList al = new ArrayList();

        al.Add(a1 - 1 + 33 - a6);
        al.Add(a2 - a1 - 1);
        al.Add(a3 - a2 - 1);
        al.Add(a4 - a3 - 1);
        al.Add(a5 - a4 - 1);
        al.Add(a6 - a5 - 1);
        al.Sort();
        newRow["A16"] = al[0].ToString() + "_" + al[1].ToString() + "_" + al[2].ToString() + "_" + al[3].ToString() + "_" + al[4].ToString() + "_" + al[5].ToString();
        newRow["A17"] = al[0].ToString() + "_" + al[1].ToString() + "_" + al[2].ToString() + "_" + al[3].ToString() + "_" + al[4].ToString() ;
        newRow["A18"] = al[0].ToString() + "_" + al[1].ToString() + "_" + al[2].ToString() + "_" + al[3].ToString() ;
        newRow["A19"] = al[0].ToString() + "_" + al[1].ToString() + "_" + al[2].ToString() ;

        int near = MyTest.ISNear(redBall, a1, ii + 1) + MyTest.ISNear(redBall, a2, ii + 1) + MyTest.ISNear(redBall, a3, ii + 1) + MyTest.ISNear(redBall, a4, ii + 1) + MyTest.ISNear(redBall, a5, ii + 1) + MyTest.ISNear(redBall, a6, ii + 1);
        int repeat = MyTest.ISRepeat(redBall, a1, ii + 1) + MyTest.ISRepeat(redBall, a2, ii + 1) + MyTest.ISRepeat(redBall, a3, ii + 1) + MyTest.ISRepeat(redBall, a4, ii + 1) + MyTest.ISRepeat(redBall, a5, ii + 1) + MyTest.ISRepeat(redBall, a6, ii + 1);

        if (alSum.Count >= 7)
        {
            returnStr += "|" + alSum[alSum.Count - 1].ToString();
            int row = 19;
            NormalDistribution nn = new NormalDistribution();
            List<double> dd = new List<double>();
            dd.Add(Convert.ToDouble(alSum[alSum.Count - 2].ToString()));
            for (int i = 0; i < 5; i++)
            {
                dd.Add(Convert.ToDouble(alSum[alSum.Count - i - 3].ToString()));
                double ddd = nn.stdev(dd);
                double avg = nn.average(dd);
                newRow["A" + (row + i * 2 + 1).ToString()] = ddd;
                newRow["A" + (row + i * 2 + 2).ToString()] = avg;

                returnStr += "|" + ddd.ToString() + "|" + avg.ToString();
            }
        }

        newRow["A3"] = near;
        newRow["A4"] = repeat;
        newRow["A5"] = a1 + a2 + a3 + a4 + a5 + a6;
        newRow["A6"] = (a1 + a2 + a3 + a4 + a5 + a6) / 10;
        newRow["round"] = arrRound[ii].ToString();
        dt.Rows.Add(newRow);

        return returnStr;
    }

    public static void GetFive(int ii,string input, ref DataTable dt, int[,] redBall,int[,] miniRedBall, ArrayList arrRound)
    {
        string[] str = input.Split('|');
        DataRow newRow;


        int a1 = int.Parse(str[0]);
        int a2 = int.Parse(str[1]);
        int a3 = int.Parse(str[2]);
        int a4 = int.Parse(str[3]);
        int a5 = int.Parse(str[4]);
        int a6 = int.Parse(str[5]);

        int countRound = 0;
        string strFourRound = "";
        string strFiveRound = "";
        if (ii <= 1000)
        {
            for (int i = arrRound.Count - 1; i > ii; i--)
            {
                int count = 0;
                if (redBall[a1 - 1, i] == 1)
                    count++;
                if (redBall[a2 - 1, i] == 1)
                    count++;
                if (redBall[a3 - 1, i] == 1)
                    count++;
                if (redBall[a4 - 1, i] == 1)
                    count++;
                if (redBall[a5 - 1, i] == 1)
                    count++;
                if (redBall[a6 - 1, i] == 1)
                    count++;
                if (count == 4)
                {
                    strFourRound += arrRound[i].ToString() + "-";
                    countRound++;

                    newRow = dt.NewRow();
                    newRow["FLAG"] = 77888844;
                    newRow["A28"] = input;
                    newRow["A29"] = miniRedBall[0, i].ToString() + "|" + miniRedBall[1, i].ToString() + "|" + miniRedBall[2, i].ToString() + "|" + miniRedBall[3, i].ToString() + "|" + miniRedBall[4, i].ToString() + "|" + miniRedBall[5, i].ToString();
                    newRow["A30"] = arrRound[i].ToString();
                    newRow["Round"] = arrRound[ii].ToString();
                    dt.Rows.Add(newRow);
                }
                else if (count == 5)
                { 
                    strFiveRound += arrRound[i].ToString() + "-";

                    newRow = dt.NewRow();
                    newRow["FLAG"] = 77888855;
                    newRow["A28"] = input;
                    newRow["A29"] = miniRedBall[0, i].ToString() + "|" + miniRedBall[1, i].ToString() + "|" + miniRedBall[2, i].ToString() + "|" + miniRedBall[3, i].ToString() + "|" + miniRedBall[4, i].ToString() + "|" + miniRedBall[5, i].ToString();
                    newRow["A30"] = arrRound[i].ToString();
                    newRow["Round"] = arrRound[ii].ToString();
                    dt.Rows.Add(newRow);
                }
            }
            

        }


        newRow = dt.NewRow();

        newRow["A25"] = countRound;
        newRow["A23"] = strFourRound;
        newRow["A24"] = strFiveRound;
        
        newRow["FLAG"] = 7788886;
        newRow["A12"] = input;
        newRow["round"] = arrRound[ii].ToString();

        newRow["A13"] = (a2 - a1).ToString() + "_" + (a3 - a2).ToString() + "_" + (a4 - a3).ToString() + "_" + (a5 - a4).ToString() + "_" + (a6 - a5).ToString();

        ArrayList al = new ArrayList();
        al.Add(a2 - a1); al.Add(a3 - a2); al.Add(a4 - a3); al.Add(a5 - a4); al.Add(a6 - a5);
        al.Sort();
        newRow["A14"] = al[0].ToString() + "_" + al[1].ToString() + "_" + al[2].ToString() + "_" + al[3].ToString() + "_" + al[4].ToString();

        a1 = FindUpNumber(ii, a1 - 1, arrRound.Count, redBall);
        a2 = FindUpNumber(ii, a2 - 1, arrRound.Count, redBall);
        a3 = FindUpNumber(ii, a3 - 1, arrRound.Count, redBall);
        a4 = FindUpNumber(ii, a4 - 1, arrRound.Count, redBall);
        a5 = FindUpNumber(ii, a5 - 1, arrRound.Count, redBall);
        a6 = FindUpNumber(ii, a6 - 1, arrRound.Count, redBall);
        newRow["A15"] = a1.ToString() + "/" + a2.ToString() + "/" + a3.ToString() + "/" + a4.ToString() + "/" + a5.ToString() + "/" + a5.ToString();

        newRow["A16"] = a1.ToString();
        newRow["A17"] = a2.ToString();
        newRow["A18"] = a3.ToString();
        newRow["A19"] = a4.ToString();
        newRow["A20"] = a5.ToString();
        newRow["A21"] = a6.ToString();
        newRow["A22"] = (a1 + a2 + a3 + a4 + a5 + a6).ToString();
        dt.Rows.Add(newRow);

        for (int i = 0; i < str.Length; i++)
        {
            string strFive = string.Empty;
            for (int j = 0; j < str.Length; j++)
            {
                if (i != j)
                {
                    strFive += str[j] + "|";
                }
            }

            if (strFive.Substring(strFive.Length - 1, 1) == "|")
                strFive = strFive.Substring(0, strFive.Length - 1);

            string[] str5 = strFive.Split('|');

            a1 = int.Parse(str5[0]);
            a2 = int.Parse(str5[1]);
            a3 = int.Parse(str5[2]);
            a4 = int.Parse(str5[3]);
            a5 = int.Parse(str5[4]);

            newRow = dt.NewRow();
            newRow["FLAG"] = 7788885;
            newRow["A12"] = strFive;
            newRow["A0"] = ii;
            newRow["round"] = arrRound[ii].ToString();
            newRow["A13"] = (a2 - a1).ToString() + "_" + (a3 - a2).ToString() + "_" + (a4 - a3).ToString() + "_" + (a5 - a4).ToString();

            al = new ArrayList();
            al.Add(a2 - a1); al.Add(a3 - a2); al.Add(a4 - a3); al.Add(a5 - a4);
            al.Sort();
            newRow["A14"] = al[0].ToString() + "_" + al[1].ToString() + "_" + al[2].ToString() + "_" + al[3].ToString();

            a1 = FindUpNumber(ii, a1 - 1, arrRound.Count, redBall);
            a2 = FindUpNumber(ii, a2 - 1, arrRound.Count, redBall);
            a3 = FindUpNumber(ii, a3 - 1, arrRound.Count, redBall);
            a4 = FindUpNumber(ii, a4 - 1, arrRound.Count, redBall);
            a5 = FindUpNumber(ii, a5 - 1, arrRound.Count, redBall);
            newRow["A15"] = a1.ToString() + "/" + a2.ToString() + "/" + a3.ToString() + "/" + a4.ToString() + "/" + a5.ToString();

            dt.Rows.Add(newRow);

            GetFour(strFive, ref dt, "4", ii);
        }
    }

    public static void GetFive(string input, ref DataTable dt)
    {
        string[] str = input.Split('|');
      

        for (int i = 0; i < str.Length; i++)
        {
            string strFive = string.Empty;
            for (int j = 0; j < str.Length; j++)
            {
                if (i != j)
                {
                    strFive += str[j] + "|";
                }
            }

            if (strFive.Substring(strFive.Length - 1, 1) == "|")
                strFive = strFive.Substring(0, strFive.Length - 1);

            GetFour(strFive, ref dt, "",0);
        }
    }   

    public static void GetFour(string input, ref DataTable dt, string flag, int ii)
    {
        //string strII = string.Empty;
        string[] str = input.Split('|');
        DataRow newRow;
        for (int i = 0; i < str.Length; i++)
        {
            newRow = dt.NewRow();
            string strFour = string.Empty;
            for (int j = 0; j < str.Length; j++)
            {
                if (i != j)
                {
                    strFour += str[j] + "|";
                }
            }


            if (strFour.Substring(strFour.Length - 1, 1) == "|")
                strFour = strFour.Substring(0, strFour.Length - 1);
            //if (ii == 0 || !strII.Contains(strFour + "-" + ii.ToString()))
            //{
            //    strII += strFour + "-" + ii.ToString();

                string[] str4 = strFour.Split('|');

                int a1 = int.Parse(str4[0]);
                int a2 = int.Parse(str4[1]);
                int a3 = int.Parse(str4[2]);
                int a4 = int.Parse(str4[3]);


                newRow["FLAG"] = "778888" + flag;
                newRow["round"] = ii.ToString();
                newRow["A12"] = strFour;

                newRow["A13"] = (a2 - a1).ToString() + "_" + (a3 - a2).ToString() + "_" + (a4 - a3).ToString();

                ArrayList al = new ArrayList();
                al.Add(a2 - a1); al.Add(a3 - a2); al.Add(a4 - a3);
                al.Sort();
                newRow["A14"] = al[0].ToString() + "_" + al[1].ToString() + "_" + al[2].ToString();

                dt.Rows.Add(newRow);
            //}
            //else
            //{ 
            //}
        }
    }

    public static string GetFive(string input)
    {
        string strReturn = string.Empty;
        string strFourReturn = string.Empty;
        string[] str = input.Split('|');


        for (int i = 0; i < str.Length; i++)
        {
            string strFive = string.Empty;
            for (int j = 0; j < str.Length; j++)
            {
                if (i != j)
                {
                    strFive += str[j] + "|";
                }
            }

            if (strFive.Substring(strFive.Length - 1, 1) == "|")
                strFive = strFive.Substring(0, strFive.Length - 1);
            strReturn += strFive + "-" ;
            strFourReturn += GetFour(strFive, strFourReturn);
        }
        return strReturn + strFourReturn;
    }

    public static string GetFour(string input, string strFourReturn)
    {
        string strII = string.Empty;
        string[] str = input.Split('|');

        for (int i = 0; i < str.Length; i++)
        {
            string strFour = string.Empty;
            for (int j = 0; j < str.Length; j++)
            {
                if (i != j)
                {
                    strFour += str[j] + "|";
                }
            }


            if (strFour.Substring(strFour.Length - 1, 1) == "|")
                strFour = strFour.Substring(0, strFour.Length - 1);
            if (!strFourReturn.Contains(strFour))
                strII += strFour + "-";
        }

        return strII;
    }
    #endregion

    #region Analyze

    public static string Belong(int[,] miniRedBall, int i, int next)
    {
        string hope = "";
        int[] abc = new int[7];
        for (int j = 0; j < 6; j++)
        {
            for (int x = 0; x < 6; x++)
            {
                //if (i == 1)
                //{ 
                //}

                if (miniRedBall[j, i] >= miniRedBall[5, i + next])
                {
                    hope += "5|";
                    abc[5]++;
                    break;
                }
                else if (x == 0 && miniRedBall[j, i] < miniRedBall[x, i + next])
                {
                    hope += "0|";
                    abc[0]++;
                    break;
                }
                else if (miniRedBall[j, i] < miniRedBall[x, i + next] && miniRedBall[j, i] > miniRedBall[x - 1, i + next])
                {

                    if (miniRedBall[j, i] - miniRedBall[x - 1, i + next] > miniRedBall[x, i + next] - miniRedBall[j, i])
                    {
                        hope += x.ToString() + "|";
                        abc[x]++;
                        break;
                    }
                    else if (miniRedBall[j, i] - miniRedBall[x - 1, i + next] < miniRedBall[x, i + next] - miniRedBall[j, i])
                    {
                        hope += (x - 1).ToString() + "|";
                        abc[x - 1]++;
                        break;
                    }
                    else
                    {
                        hope += (x - 1).ToString() + "half|";
                        abc[6]++;
                        break;
                    }

                }
                else if (miniRedBall[j, i] == miniRedBall[x, i + next])
                {
                    hope += x.ToString() + "|";
                    abc[x]++;
                    break;
                }
            }
        }
        int count = 0;
        for (int j = 0; j < 7; j++)
        {
            if (abc[j] != 0)
                count++;
        }

        return hope + "_" + count.ToString();
    }

    #endregion
}

