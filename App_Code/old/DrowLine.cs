using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Collections;

public class imgdraw
{
    public imgdraw()
    {

    }
    public void draw(Page page, DataSet ds)
    {
        //取得记录数量
        int count = ds.Tables[0].Rows.Count;
        //记算图表宽度
        int wd = 80 + 20 * (count - 1);
        //设置最小宽度为800
        if (wd < 800) wd = 800;
        //生成Bitmap对像
        Bitmap img = new Bitmap(wd, 400);
        //生成绘图对像
        Graphics g = Graphics.FromImage(img);
        //定义黑色画笔
        Pen Bp = new Pen(Color.Black);
        //定义红色画笔
        Pen Rp = new Pen(Color.Red);
        //定义银灰色画笔

        Pen Sp = new Pen(Color.Silver);
        //定义大标题字体

        Font Bfont = new Font("Arial", 12, FontStyle.Bold);
        //定义一般字体

        Font font = new Font("Arial", 8);
        //定义大点的字体

        Font Tfont = new Font("Arial", 9);
        //绘制底色
        g.DrawRectangle(new Pen(Color.White, 400), 0, 0, img.Width, img.Height);
        //定义黑色过渡型笔刷

        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.Black, Color.Black, 1.2F, true);
        //定义蓝色过渡型笔刷

        LinearGradientBrush Bluebrush = new LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.Blue, Color.Blue, 1.2F, true);
        //绘制大标题

        g.DrawString("技术部量化考核", Bfont, brush, 50, 5);

        //g.DrawString(info, Tfont, Bluebrush, 40, 25);

        //绘制图片边框
        g.DrawRectangle(Bp, 0, 0, img.Width - 1, img.Height - 1);



        ArrayList al = new ArrayList();

        al.Add("总数");
        al.Add("BUG");
        al.Add("任务");
        al.Add("分数");
        al.Add("日志");
        al.Add("技术研讨");

        for (int i = 1; i <= 6; i++)
        {
            //绘制竖坐标线       
            g.DrawLine(Sp, 50 + 40 * i, 60, 50 + 40 * i, 360);

            //绘制时间轴坐标标签

            g.DrawString(al[i-1].ToString(), font, brush, 30 + 40 * i, 370);
        }

        //绘制竖坐标轴
        g.DrawLine(Bp, 50, 55, 50, 360);
        //绘制横坐标轴
        g.DrawLine(Bp, 50, 360, 500, 360);


        //绘制竖坐标标题

        g.DrawString("姓名", Tfont, brush, 5, 40);

        //绘制横坐标标题

        g.DrawString("统计结果", Tfont, brush, 40, 385);

        int[] big = new int[6];
        int[,] Same = new int[count, 6];

        for (int i = 0; i < 6; i++)
        {
            big[i] = int.Parse(ds.Tables[0].Rows[0][i].ToString());
            for (int j = 0; j < count; j++)
            {
                if (int.Parse(ds.Tables[0].Rows[j][i].ToString()) > big[i])
                    big[i] = int.Parse(ds.Tables[0].Rows[j][i].ToString());
                for (int x = 0; x < count; x++)
                {
                    if( j != x)
                    {
                        if (int.Parse(ds.Tables[0].Rows[j][i].ToString()) == int.Parse(ds.Tables[0].Rows[x][i].ToString()) && Same[j, i] == Same[x, i])
                        {
                            Same[x, i] += 2;
                        }
                    }
                }
            }

            if (big[i] == 0) big[i] = 1;

        }

        //定义曲线转折点

        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            Color color = new Color();
            switch (i)
            {
                case 0:
                    color = Color.Red;
                    break;
                case 1:
                    color = Color.Blue;
                    break;
                case 2:
                    color = Color.Aqua;
                    break;
                case 3:
                    color = Color.Yellow;
                    break;
                case 4:
                    color = Color.DarkSalmon;
                    break;
                default :
                    color = Color.Black;
                    break;
            }

            Rp = new Pen(color);
            brush = new LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), color, color, 1.2F, true);

            //绘制横坐标线
            g.DrawLine(Sp, 50, 360 - 40 * (i + 1), 290, 360 - 40 * (i + 1));

            //绘制发送量轴坐标标签

            g.DrawString(ds.Tables[0].Rows[i]["USER_NAME"].ToString(), font, brush, 5, 360 - 40 * (i + 1));

            al.Clear();
            al.Add(ds.Tables[0].Rows[i]["COUNT_ALL"].ToString());
            al.Add(ds.Tables[0].Rows[i]["COUNT_BUG"].ToString());
            al.Add(ds.Tables[0].Rows[i]["COUNT_ROLE"].ToString());
            al.Add(ds.Tables[0].Rows[i]["COUNT_SCORE"].ToString());
            al.Add(ds.Tables[0].Rows[i]["COUNT_LOG"].ToString());
            al.Add(ds.Tables[0].Rows[i]["COUNT_TECH"].ToString());

            Point[] p = new Point[6];

            p[0].X = 90;
            p[0].Y = 360 - Convert.ToInt32(float.Parse(ds.Tables[0].Rows[i]["COUNT_ALL"].ToString()) / big[0] * 220) + Same[i, 0];
            p[1].X = 130;
            p[1].Y = 360 - Convert.ToInt32(float.Parse(ds.Tables[0].Rows[i]["COUNT_BUG"].ToString()) / big[1] * 220) + Same[i, 1];
            p[2].X = 170;
            p[2].Y = 360 - Convert.ToInt32(float.Parse(ds.Tables[0].Rows[i]["COUNT_ROLE"].ToString()) / big[2] * 220) + Same[i, 2];
            p[3].X = 210;
            p[3].Y = 360 - Convert.ToInt32(float.Parse(ds.Tables[0].Rows[i]["COUNT_SCORE"].ToString()) / big[3] * 220) + Same[i, 3];
            p[4].X = 250;
            p[4].Y = 360 - Convert.ToInt32(float.Parse(ds.Tables[0].Rows[i]["COUNT_LOG"].ToString()) / big[4] * 220) + Same[i, 4];
            p[5].X = 290;
            p[5].Y = 360 - Convert.ToInt32(float.Parse(ds.Tables[0].Rows[i]["COUNT_TECH"].ToString()) / big[5] * 220) + Same[i, 5];

            if (p.Length > 1)
                g.DrawLines(Rp, p);

            for (int j = 0; j < 6; j++)
            {
                //绘制发送记录点的发送量
                g.DrawString(al[j].ToString(), font, Bluebrush, p[j].X, p[j].Y - Same[i, j] - 12);
                //绘制发送记录点
                g.DrawRectangle(Rp, p[j].X - 1, p[j].Y - Same[i, j] - 1, 2, 2);
            }
        }

        //保存绘制的图片

        MemoryStream stream = new MemoryStream();
        img.Save(stream, ImageFormat.Jpeg);

        //图片输出
        page.Response.Clear();
        page.Response.ContentType = "image/jpeg";
        page.Response.BinaryWrite(stream.ToArray());

    }
}
