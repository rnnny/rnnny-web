/*
 *
 * 所属部分 : 数据操作层
 * 文件名称 : Exam_Dal.cs
 * 功能描述 : 数据表操作定义
 * 版本     日期                作者            修改/作成
 * -------------------------------------------------------------------------
 * 1.0      2018/3/22 16:07:35  自动生成 		作成
 *
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HGData;
using System.Collections;

namespace FZX.App.WebEngine
{
   public class Exam_Dal
   {
       private static string table = "EXAM";
       private static string key = "ID";

       public Exam_Dal()
       {
           //
           // TODO: 在此处添加构造函数逻辑
           //
       }

       #region 数据库基本操作

       /// <summary>
       /// 还原Mod对象
       /// </summary>
       public static Exam_Mod CreateExamMod(string dbname, string id)
       {
           Exam_Mod mod = new Exam_Mod();
           return (Exam_Mod)DBEngine.RestoreMod(dbname, table, key, mod, id);
       }

       /// <summary>
       /// 向数据库增加记录
       /// </summary>
       public static void InsertExamMod(string dbname, Exam_Mod mod)
       {
           DBEngine.InsertMod(dbname, table, mod);
       }

       /// <summary>
       /// 更新数据库
       /// </summary>
       public static void UpdateExamMod(string dbname, Exam_Mod mod)
       {
           DBEngine.UpdateMod(dbname, table, mod);
       }

       /// <summary>
       /// 删除一条数据库数据
       /// </summary>
       public static void DeleteExamMod(string dbname, string id, string uid)
       {
           DBEngine.DeleteMod(dbname, table, key, id, uid);
       }

       /// <summary>
       /// 返回本表的所有记录
       /// </summary>
       public static DataSet GetTableList(string dbname)
       {
           return DBEngine.GetTableList(dbname, table, "CREATE_TIME", false);
       }

       #endregion

       #region 判断某字段在表中是否存在某数据

       public static bool IsHaveValueId(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "ID", data);
       }

       public static bool IsHaveValueFlag(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "FLAG", data);
       }

       public static bool IsHaveValueA0(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A0", data);
       }

       public static bool IsHaveValueA1(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A1", data);
       }

       public static bool IsHaveValueA2(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A2", data);
       }

       public static bool IsHaveValueA3(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A3", data);
       }

       public static bool IsHaveValueA4(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A4", data);
       }

       public static bool IsHaveValueA5(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A5", data);
       }

       public static bool IsHaveValueA6(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A6", data);
       }

       public static bool IsHaveValueA7(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A7", data);
       }

       public static bool IsHaveValueA8(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A8", data);
       }

       public static bool IsHaveValueA9(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A9", data);
       }

       public static bool IsHaveValueA10(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A10", data);
       }

       public static bool IsHaveValueA11(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A11", data);
       }

       public static bool IsHaveValueA12(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A12", data);
       }

       public static bool IsHaveValueA13(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A13", data);
       }

       public static bool IsHaveValueA14(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A14", data);
       }

       public static bool IsHaveValueA15(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A15", data);
       }

       public static bool IsHaveValueA16(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A16", data);
       }

       public static bool IsHaveValueA17(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A17", data);
       }

       public static bool IsHaveValueA18(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A18", data);
       }

       public static bool IsHaveValueA19(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A19", data);
       }

       public static bool IsHaveValueA20(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A20", data);
       }

       public static bool IsHaveValueA21(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A21", data);
       }

       public static bool IsHaveValueA22(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A22", data);
       }

       public static bool IsHaveValueA23(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A23", data);
       }

       public static bool IsHaveValueA24(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A24", data);
       }

       public static bool IsHaveValueA25(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A25", data);
       }

       public static bool IsHaveValueA26(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A26", data);
       }

       public static bool IsHaveValueA27(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A27", data);
       }

       public static bool IsHaveValueA28(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A28", data);
       }

       public static bool IsHaveValueA29(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A29", data);
       }

       public static bool IsHaveValueA30(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A30", data);
       }

       public static bool IsHaveValueA31(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A31", data);
       }

       public static bool IsHaveValueA32(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A32", data);
       }

       public static bool IsHaveValueA33(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A33", data);
       }

       public static bool IsHaveValueA34(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A34", data);
       }

       public static bool IsHaveValueA35(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A35", data);
       }

       public static bool IsHaveValueA36(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A36", data);
       }

       public static bool IsHaveValueA37(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A37", data);
       }

       public static bool IsHaveValueA38(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A38", data);
       }

       public static bool IsHaveValueA39(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A39", data);
       }

       public static bool IsHaveValueA40(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "A40", data);
       }

       public static bool IsHaveValueB0(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B0", data);
       }

       public static bool IsHaveValueB1(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B1", data);
       }

       public static bool IsHaveValueB2(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B2", data);
       }

       public static bool IsHaveValueB3(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B3", data);
       }

       public static bool IsHaveValueB4(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B4", data);
       }

       public static bool IsHaveValueB5(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B5", data);
       }

       public static bool IsHaveValueB6(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B6", data);
       }

       public static bool IsHaveValueB7(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B7", data);
       }

       public static bool IsHaveValueB8(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B8", data);
       }

       public static bool IsHaveValueB9(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B9", data);
       }

       public static bool IsHaveValueB10(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B10", data);
       }

       public static bool IsHaveValueB11(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B11", data);
       }

       public static bool IsHaveValueB12(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B12", data);
       }

       public static bool IsHaveValueB13(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B13", data);
       }

       public static bool IsHaveValueB14(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B14", data);
       }

       public static bool IsHaveValueB15(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B15", data);
       }

       public static bool IsHaveValueB16(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B16", data);
       }

       public static bool IsHaveValueB17(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B17", data);
       }

       public static bool IsHaveValueB18(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B18", data);
       }

       public static bool IsHaveValueB19(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B19", data);
       }

       public static bool IsHaveValueB20(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B20", data);
       }

       public static bool IsHaveValueB21(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B21", data);
       }

       public static bool IsHaveValueB22(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B22", data);
       }

       public static bool IsHaveValueB23(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B23", data);
       }

       public static bool IsHaveValueB24(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B24", data);
       }

       public static bool IsHaveValueB25(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B25", data);
       }

       public static bool IsHaveValueB26(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B26", data);
       }

       public static bool IsHaveValueB27(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B27", data);
       }

       public static bool IsHaveValueB28(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B28", data);
       }

       public static bool IsHaveValueB29(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B29", data);
       }

       public static bool IsHaveValueB30(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B30", data);
       }

       public static bool IsHaveValueB31(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B31", data);
       }

       public static bool IsHaveValueB32(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B32", data);
       }

       public static bool IsHaveValueB33(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B33", data);
       }

       public static bool IsHaveValueB34(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B34", data);
       }

       public static bool IsHaveValueB35(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B35", data);
       }

       public static bool IsHaveValueB36(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B36", data);
       }

       public static bool IsHaveValueB37(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B37", data);
       }

       public static bool IsHaveValueB38(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B38", data);
       }

       public static bool IsHaveValueB39(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B39", data);
       }

       public static bool IsHaveValueB40(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "B40", data);
       }

       public static bool IsHaveValueRound(string dbname, string data)
       {
           return DBEngine.FieldIsHaveValue(dbname, table, "ROUND", data);
       }

       #endregion

   }
}
