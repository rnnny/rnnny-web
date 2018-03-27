/*
 *
 * 所属部分 : 数据实体层
 * 文件名称 : Exam_Mod.cs
 * 功能描述 : 数据表实体定义
 * 版本     日期                作者            修改/作成
 * -------------------------------------------------------------------------
 * 1.0      2018/3/22 16:07:35  自动生成 		作成
 *
 */


using System;
using System.Collections.Generic;
using System.Text;
using HGData;

namespace FZX.App.WebEngine
{
   public class Exam_Mod
   {
       public  Exam_Mod()
       {
           //
           // TODO: 在此处添加构造函数逻辑
           //
       }

       private string _Id= Guid.NewGuid().ToString();
       [DataProperty(Field = "ID", IsKey = true)]
       public string Id
       {
           get { return _Id; }
           set { _Id = value; }
       }

       private int _Flag= 0;
       [DataProperty(Field = "FLAG")]
       public int Flag
       {
           get { return _Flag; }
           set { _Flag = value; }
       }

       private int _A0= 0;
       [DataProperty(Field = "A0")]
       public int A0
       {
           get { return _A0; }
           set { _A0 = value; }
       }

       private int _A1= 0;
       [DataProperty(Field = "A1")]
       public int A1
       {
           get { return _A1; }
           set { _A1 = value; }
       }

       private int _A2= 0;
       [DataProperty(Field = "A2")]
       public int A2
       {
           get { return _A2; }
           set { _A2 = value; }
       }

       private int _A3= 0;
       [DataProperty(Field = "A3")]
       public int A3
       {
           get { return _A3; }
           set { _A3 = value; }
       }

       private int _A4= 0;
       [DataProperty(Field = "A4")]
       public int A4
       {
           get { return _A4; }
           set { _A4 = value; }
       }

       private int _A5= 0;
       [DataProperty(Field = "A5")]
       public int A5
       {
           get { return _A5; }
           set { _A5 = value; }
       }

       private int _A6= 0;
       [DataProperty(Field = "A6")]
       public int A6
       {
           get { return _A6; }
           set { _A6 = value; }
       }

       private int _A7= 0;
       [DataProperty(Field = "A7")]
       public int A7
       {
           get { return _A7; }
           set { _A7 = value; }
       }

       private int _A8= 0;
       [DataProperty(Field = "A8")]
       public int A8
       {
           get { return _A8; }
           set { _A8 = value; }
       }

       private int _A9= 0;
       [DataProperty(Field = "A9")]
       public int A9
       {
           get { return _A9; }
           set { _A9 = value; }
       }

       private int _A10= 0;
       [DataProperty(Field = "A10")]
       public int A10
       {
           get { return _A10; }
           set { _A10 = value; }
       }

       private int _A11= 0;
       [DataProperty(Field = "A11")]
       public int A11
       {
           get { return _A11; }
           set { _A11 = value; }
       }

       private int _A12= 0;
       [DataProperty(Field = "A12")]
       public int A12
       {
           get { return _A12; }
           set { _A12 = value; }
       }

       private int _A13= 0;
       [DataProperty(Field = "A13")]
       public int A13
       {
           get { return _A13; }
           set { _A13 = value; }
       }

       private int _A14= 0;
       [DataProperty(Field = "A14")]
       public int A14
       {
           get { return _A14; }
           set { _A14 = value; }
       }

       private int _A15= 0;
       [DataProperty(Field = "A15")]
       public int A15
       {
           get { return _A15; }
           set { _A15 = value; }
       }

       private int _A16= 0;
       [DataProperty(Field = "A16")]
       public int A16
       {
           get { return _A16; }
           set { _A16 = value; }
       }

       private int _A17= 0;
       [DataProperty(Field = "A17")]
       public int A17
       {
           get { return _A17; }
           set { _A17 = value; }
       }

       private int _A18= 0;
       [DataProperty(Field = "A18")]
       public int A18
       {
           get { return _A18; }
           set { _A18 = value; }
       }

       private int _A19= 0;
       [DataProperty(Field = "A19")]
       public int A19
       {
           get { return _A19; }
           set { _A19 = value; }
       }

       private int _A20= 0;
       [DataProperty(Field = "A20")]
       public int A20
       {
           get { return _A20; }
           set { _A20 = value; }
       }

       private int _A21= 0;
       [DataProperty(Field = "A21")]
       public int A21
       {
           get { return _A21; }
           set { _A21 = value; }
       }

       private int _A22= 0;
       [DataProperty(Field = "A22")]
       public int A22
       {
           get { return _A22; }
           set { _A22 = value; }
       }

       private int _A23= 0;
       [DataProperty(Field = "A23")]
       public int A23
       {
           get { return _A23; }
           set { _A23 = value; }
       }

       private int _A24= 0;
       [DataProperty(Field = "A24")]
       public int A24
       {
           get { return _A24; }
           set { _A24 = value; }
       }

       private int _A25= 0;
       [DataProperty(Field = "A25")]
       public int A25
       {
           get { return _A25; }
           set { _A25 = value; }
       }

       private int _A26= 0;
       [DataProperty(Field = "A26")]
       public int A26
       {
           get { return _A26; }
           set { _A26 = value; }
       }

       private int _A27= 0;
       [DataProperty(Field = "A27")]
       public int A27
       {
           get { return _A27; }
           set { _A27 = value; }
       }

       private int _A28= 0;
       [DataProperty(Field = "A28")]
       public int A28
       {
           get { return _A28; }
           set { _A28 = value; }
       }

       private int _A29= 0;
       [DataProperty(Field = "A29")]
       public int A29
       {
           get { return _A29; }
           set { _A29 = value; }
       }

       private int _A30= 0;
       [DataProperty(Field = "A30")]
       public int A30
       {
           get { return _A30; }
           set { _A30 = value; }
       }

       private int _A31= 0;
       [DataProperty(Field = "A31")]
       public int A31
       {
           get { return _A31; }
           set { _A31 = value; }
       }

       private int _A32= 0;
       [DataProperty(Field = "A32")]
       public int A32
       {
           get { return _A32; }
           set { _A32 = value; }
       }

       private int _A33= 0;
       [DataProperty(Field = "A33")]
       public int A33
       {
           get { return _A33; }
           set { _A33 = value; }
       }

       private int _A34= 0;
       [DataProperty(Field = "A34")]
       public int A34
       {
           get { return _A34; }
           set { _A34 = value; }
       }

       private int _A35= 0;
       [DataProperty(Field = "A35")]
       public int A35
       {
           get { return _A35; }
           set { _A35 = value; }
       }

       private int _A36= 0;
       [DataProperty(Field = "A36")]
       public int A36
       {
           get { return _A36; }
           set { _A36 = value; }
       }

       private int _A37= 0;
       [DataProperty(Field = "A37")]
       public int A37
       {
           get { return _A37; }
           set { _A37 = value; }
       }

       private int _A38= 0;
       [DataProperty(Field = "A38")]
       public int A38
       {
           get { return _A38; }
           set { _A38 = value; }
       }

       private int _A39= 0;
       [DataProperty(Field = "A39")]
       public int A39
       {
           get { return _A39; }
           set { _A39 = value; }
       }

       private int _A40= 0;
       [DataProperty(Field = "A40")]
       public int A40
       {
           get { return _A40; }
           set { _A40 = value; }
       }

       private string _B0= string.Empty;
       [DataProperty(Field = "B0")]
       public string B0
       {
           get { return _B0; }
           set { _B0 = value; }
       }

       private string _B1= string.Empty;
       [DataProperty(Field = "B1")]
       public string B1
       {
           get { return _B1; }
           set { _B1 = value; }
       }

       private string _B2= string.Empty;
       [DataProperty(Field = "B2")]
       public string B2
       {
           get { return _B2; }
           set { _B2 = value; }
       }

       private string _B3= string.Empty;
       [DataProperty(Field = "B3")]
       public string B3
       {
           get { return _B3; }
           set { _B3 = value; }
       }

       private string _B4= string.Empty;
       [DataProperty(Field = "B4")]
       public string B4
       {
           get { return _B4; }
           set { _B4 = value; }
       }

       private string _B5= string.Empty;
       [DataProperty(Field = "B5")]
       public string B5
       {
           get { return _B5; }
           set { _B5 = value; }
       }

       private string _B6= string.Empty;
       [DataProperty(Field = "B6")]
       public string B6
       {
           get { return _B6; }
           set { _B6 = value; }
       }

       private string _B7= string.Empty;
       [DataProperty(Field = "B7")]
       public string B7
       {
           get { return _B7; }
           set { _B7 = value; }
       }

       private string _B8= string.Empty;
       [DataProperty(Field = "B8")]
       public string B8
       {
           get { return _B8; }
           set { _B8 = value; }
       }

       private string _B9= string.Empty;
       [DataProperty(Field = "B9")]
       public string B9
       {
           get { return _B9; }
           set { _B9 = value; }
       }

       private string _B10= string.Empty;
       [DataProperty(Field = "B10")]
       public string B10
       {
           get { return _B10; }
           set { _B10 = value; }
       }

       private string _B11= string.Empty;
       [DataProperty(Field = "B11")]
       public string B11
       {
           get { return _B11; }
           set { _B11 = value; }
       }

       private string _B12= string.Empty;
       [DataProperty(Field = "B12")]
       public string B12
       {
           get { return _B12; }
           set { _B12 = value; }
       }

       private string _B13= string.Empty;
       [DataProperty(Field = "B13")]
       public string B13
       {
           get { return _B13; }
           set { _B13 = value; }
       }

       private string _B14= string.Empty;
       [DataProperty(Field = "B14")]
       public string B14
       {
           get { return _B14; }
           set { _B14 = value; }
       }

       private string _B15= string.Empty;
       [DataProperty(Field = "B15")]
       public string B15
       {
           get { return _B15; }
           set { _B15 = value; }
       }

       private string _B16= string.Empty;
       [DataProperty(Field = "B16")]
       public string B16
       {
           get { return _B16; }
           set { _B16 = value; }
       }

       private string _B17= string.Empty;
       [DataProperty(Field = "B17")]
       public string B17
       {
           get { return _B17; }
           set { _B17 = value; }
       }

       private string _B18= string.Empty;
       [DataProperty(Field = "B18")]
       public string B18
       {
           get { return _B18; }
           set { _B18 = value; }
       }

       private string _B19= string.Empty;
       [DataProperty(Field = "B19")]
       public string B19
       {
           get { return _B19; }
           set { _B19 = value; }
       }

       private string _B20= string.Empty;
       [DataProperty(Field = "B20")]
       public string B20
       {
           get { return _B20; }
           set { _B20 = value; }
       }

       private string _B21= string.Empty;
       [DataProperty(Field = "B21")]
       public string B21
       {
           get { return _B21; }
           set { _B21 = value; }
       }

       private string _B22= string.Empty;
       [DataProperty(Field = "B22")]
       public string B22
       {
           get { return _B22; }
           set { _B22 = value; }
       }

       private string _B23= string.Empty;
       [DataProperty(Field = "B23")]
       public string B23
       {
           get { return _B23; }
           set { _B23 = value; }
       }

       private string _B24= string.Empty;
       [DataProperty(Field = "B24")]
       public string B24
       {
           get { return _B24; }
           set { _B24 = value; }
       }

       private string _B25= string.Empty;
       [DataProperty(Field = "B25")]
       public string B25
       {
           get { return _B25; }
           set { _B25 = value; }
       }

       private string _B26= string.Empty;
       [DataProperty(Field = "B26")]
       public string B26
       {
           get { return _B26; }
           set { _B26 = value; }
       }

       private string _B27= string.Empty;
       [DataProperty(Field = "B27")]
       public string B27
       {
           get { return _B27; }
           set { _B27 = value; }
       }

       private string _B28= string.Empty;
       [DataProperty(Field = "B28")]
       public string B28
       {
           get { return _B28; }
           set { _B28 = value; }
       }

       private string _B29= string.Empty;
       [DataProperty(Field = "B29")]
       public string B29
       {
           get { return _B29; }
           set { _B29 = value; }
       }

       private string _B30= string.Empty;
       [DataProperty(Field = "B30")]
       public string B30
       {
           get { return _B30; }
           set { _B30 = value; }
       }

       private string _B31= string.Empty;
       [DataProperty(Field = "B31")]
       public string B31
       {
           get { return _B31; }
           set { _B31 = value; }
       }

       private string _B32= string.Empty;
       [DataProperty(Field = "B32")]
       public string B32
       {
           get { return _B32; }
           set { _B32 = value; }
       }

       private string _B33= string.Empty;
       [DataProperty(Field = "B33")]
       public string B33
       {
           get { return _B33; }
           set { _B33 = value; }
       }

       private string _B34= string.Empty;
       [DataProperty(Field = "B34")]
       public string B34
       {
           get { return _B34; }
           set { _B34 = value; }
       }

       private string _B35= string.Empty;
       [DataProperty(Field = "B35")]
       public string B35
       {
           get { return _B35; }
           set { _B35 = value; }
       }

       private string _B36= string.Empty;
       [DataProperty(Field = "B36")]
       public string B36
       {
           get { return _B36; }
           set { _B36 = value; }
       }

       private string _B37= string.Empty;
       [DataProperty(Field = "B37")]
       public string B37
       {
           get { return _B37; }
           set { _B37 = value; }
       }

       private string _B38= string.Empty;
       [DataProperty(Field = "B38")]
       public string B38
       {
           get { return _B38; }
           set { _B38 = value; }
       }

       private string _B39= string.Empty;
       [DataProperty(Field = "B39")]
       public string B39
       {
           get { return _B39; }
           set { _B39 = value; }
       }

       private string _B40= string.Empty;
       [DataProperty(Field = "B40")]
       public string B40
       {
           get { return _B40; }
           set { _B40 = value; }
       }

       private string _Round= string.Empty;
       [DataProperty(Field = "ROUND")]
       public string Round
       {
           get { return _Round; }
           set { _Round = value; }
       }

   }
}

