
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///正态分布
/// </summary>
public class NormalDistribution
{
    public NormalDistribution()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 正态分布随机数
    /// </summary>
    const int N = 100;
    const int MAX = 50;
    const double MIN = 0.1;
    const int MIU = 40;
    const int SIGMA = 1;
    static Random aa = new Random((int)(DateTime.Now.Ticks / 10000));
    /// <summary>
    /// 产生(min,max)之间均匀分布的随机数
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public double AverageRandom(double min, double max)
    {
        int MINnteger = (int)(min * 10000);
        int MAXnteger = (int)(max * 10000);
        int resultInteger = aa.Next(MINnteger, MAXnteger);
        return resultInteger / 10000.0;
    }
    /// <summary>
    /// 正态分布概率密度函数
    /// </summary>
    /// <param name="x"></param>
    /// <param name="miu"></param>
    /// <param name="sigma"></param>
    /// <returns></returns>
    public double Normal(double x, double miu, double sigma)
    {
        return 1.0 / (x * Math.Sqrt(2 * Math.PI) * sigma) * Math.Exp(-1 * (Math.Log(x) - miu) * (Math.Log(x) - miu) / (2 * sigma * sigma));
    }
    /// <summary>
    /// 产生正态分布随机数
    /// </summary>
    /// <param name="miu"></param>
    /// <param name="sigma"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public double Random_Normal(double miu, double sigma, double min, double max)
    {
        double x;
        double dScope;
        double y;
        do
        {
            x = AverageRandom(min, max);
            y = Normal(x, miu, sigma);
            dScope = AverageRandom(0, Normal(miu, miu, sigma));
        } while (dScope > y);
        return x;
    }
    /// <summary>
    /// 指数分布随机数
    /// </summary>
    /// <param name="const_a">const_a是指数分布的参数λ</param>
    /// <returns></returns>
    public double RandExp(double const_a)
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        double p;
        double temp;
        if (const_a != 0)
            temp = 1 / const_a;
        else
            throw new System.InvalidOperationException("除数不能为零！不能产生参数为零的指数分布！");
        double randres;
        while (true) //用于产生随机的密度，保证比参数λ小
        {
            p = rand.NextDouble();
            if (p < const_a)
                break;
        }
        randres = -temp * Math.Log(temp * p, Math.E);
        return randres;
    }

    /// <summary>
    /// 求出数据平均值,并保留三位小数
    /// </summary>
    /// <param name="Valist">数据集合</param>
    /// <returns></returns>
    public double average(List<double> Valist)
    {
        double sum = 0;
        foreach (double d in Valist)
        {
            sum = sum + d;
        }
        double revl = System.Math.Round(sum / Valist.Count, 2);
        return revl;
    }
    /// <summary>
    /// 求数据集合标准差
    /// </summary>
    /// <param name="ValList"></param>
    /// <returns></returns>
    public double stdev(List<double> ValList)
    {
        double avg = average(ValList);
        double sumstdev = 0;
        double count = 0;
        foreach (double d in ValList)
        {
            sumstdev = sumstdev + (d - avg) * (d - avg);
            count = count + 1;
        }
        double stdeval = System.Math.Sqrt(sumstdev / count);
        return System.Math.Round(stdeval, 2);
    }
}
