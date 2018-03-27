/*
 *
 * 所属部分 : 逻辑处理层
 * 文件名称 : Exam_DAL.cs
 * 功能描述 : 逻辑处理定义
 * 版本     日期                作者            修改/作成
 * -------------------------------------------------------------------------
 * 1.0      2018/3/22 16:07:35  自动生成 		作成
 *
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace FZX.App.WebEngine
{
   public class Exam_Bll
   {
       public Exam_Bll()
       {
           //
           // TODO: 在此处添加构造函数逻辑
           //
       }

       #region 数据库基本操作

       /// <summary>
       /// 还原Mod对象
       /// </summary>
       public static Exam_Mod CreateExamMod(string id)
       {
           return Exam_Dal.CreateExamMod("Rnnny", id);
       }

       /// <summary>
       /// 向数据库增加记录
       /// </summary>
       public static void InsertExamMod(Exam_Mod mod)
       {
           Exam_Dal.InsertExamMod("Rnnny", mod);
       }

       /// <summary>
       /// 更新数据库
       /// </summary>
       public static void UpdateExamMod(Exam_Mod mod)
       {
           Exam_Dal.UpdateExamMod("Rnnny", mod);
       }

       /// <summary>
       /// 删除一条数据库数据
       /// </summary>
       public static void DeleteExamMod(string id, string uid)
       {
           Exam_Dal.DeleteExamMod("Rnnny", id, uid);
       }

       /// <summary>
       /// 返回本表的所有记录
       /// </summary>
       public static DataSet GetTableList()
       {
           return Exam_Dal.GetTableList("Rnnny");
       }

       #endregion

       #region 判断某字段在表中是否存在某数据

       public static bool IsHaveValueId(string data)
       {
           return Exam_Dal.IsHaveValueId("Rnnny", data);
       }

       public static bool IsHaveValueFlag(string data)
       {
           return Exam_Dal.IsHaveValueFlag("Rnnny", data);
       }

       public static bool IsHaveValueA0(string data)
       {
           return Exam_Dal.IsHaveValueA0("Rnnny", data);
       }

       public static bool IsHaveValueA1(string data)
       {
           return Exam_Dal.IsHaveValueA1("Rnnny", data);
       }

       public static bool IsHaveValueA2(string data)
       {
           return Exam_Dal.IsHaveValueA2("Rnnny", data);
       }

       public static bool IsHaveValueA3(string data)
       {
           return Exam_Dal.IsHaveValueA3("Rnnny", data);
       }

       public static bool IsHaveValueA4(string data)
       {
           return Exam_Dal.IsHaveValueA4("Rnnny", data);
       }

       public static bool IsHaveValueA5(string data)
       {
           return Exam_Dal.IsHaveValueA5("Rnnny", data);
       }

       public static bool IsHaveValueA6(string data)
       {
           return Exam_Dal.IsHaveValueA6("Rnnny", data);
       }

       public static bool IsHaveValueA7(string data)
       {
           return Exam_Dal.IsHaveValueA7("Rnnny", data);
       }

       public static bool IsHaveValueA8(string data)
       {
           return Exam_Dal.IsHaveValueA8("Rnnny", data);
       }

       public static bool IsHaveValueA9(string data)
       {
           return Exam_Dal.IsHaveValueA9("Rnnny", data);
       }

       public static bool IsHaveValueA10(string data)
       {
           return Exam_Dal.IsHaveValueA10("Rnnny", data);
       }

       public static bool IsHaveValueA11(string data)
       {
           return Exam_Dal.IsHaveValueA11("Rnnny", data);
       }

       public static bool IsHaveValueA12(string data)
       {
           return Exam_Dal.IsHaveValueA12("Rnnny", data);
       }

       public static bool IsHaveValueA13(string data)
       {
           return Exam_Dal.IsHaveValueA13("Rnnny", data);
       }

       public static bool IsHaveValueA14(string data)
       {
           return Exam_Dal.IsHaveValueA14("Rnnny", data);
       }

       public static bool IsHaveValueA15(string data)
       {
           return Exam_Dal.IsHaveValueA15("Rnnny", data);
       }

       public static bool IsHaveValueA16(string data)
       {
           return Exam_Dal.IsHaveValueA16("Rnnny", data);
       }

       public static bool IsHaveValueA17(string data)
       {
           return Exam_Dal.IsHaveValueA17("Rnnny", data);
       }

       public static bool IsHaveValueA18(string data)
       {
           return Exam_Dal.IsHaveValueA18("Rnnny", data);
       }

       public static bool IsHaveValueA19(string data)
       {
           return Exam_Dal.IsHaveValueA19("Rnnny", data);
       }

       public static bool IsHaveValueA20(string data)
       {
           return Exam_Dal.IsHaveValueA20("Rnnny", data);
       }

       public static bool IsHaveValueA21(string data)
       {
           return Exam_Dal.IsHaveValueA21("Rnnny", data);
       }

       public static bool IsHaveValueA22(string data)
       {
           return Exam_Dal.IsHaveValueA22("Rnnny", data);
       }

       public static bool IsHaveValueA23(string data)
       {
           return Exam_Dal.IsHaveValueA23("Rnnny", data);
       }

       public static bool IsHaveValueA24(string data)
       {
           return Exam_Dal.IsHaveValueA24("Rnnny", data);
       }

       public static bool IsHaveValueA25(string data)
       {
           return Exam_Dal.IsHaveValueA25("Rnnny", data);
       }

       public static bool IsHaveValueA26(string data)
       {
           return Exam_Dal.IsHaveValueA26("Rnnny", data);
       }

       public static bool IsHaveValueA27(string data)
       {
           return Exam_Dal.IsHaveValueA27("Rnnny", data);
       }

       public static bool IsHaveValueA28(string data)
       {
           return Exam_Dal.IsHaveValueA28("Rnnny", data);
       }

       public static bool IsHaveValueA29(string data)
       {
           return Exam_Dal.IsHaveValueA29("Rnnny", data);
       }

       public static bool IsHaveValueA30(string data)
       {
           return Exam_Dal.IsHaveValueA30("Rnnny", data);
       }

       public static bool IsHaveValueA31(string data)
       {
           return Exam_Dal.IsHaveValueA31("Rnnny", data);
       }

       public static bool IsHaveValueA32(string data)
       {
           return Exam_Dal.IsHaveValueA32("Rnnny", data);
       }

       public static bool IsHaveValueA33(string data)
       {
           return Exam_Dal.IsHaveValueA33("Rnnny", data);
       }

       public static bool IsHaveValueA34(string data)
       {
           return Exam_Dal.IsHaveValueA34("Rnnny", data);
       }

       public static bool IsHaveValueA35(string data)
       {
           return Exam_Dal.IsHaveValueA35("Rnnny", data);
       }

       public static bool IsHaveValueA36(string data)
       {
           return Exam_Dal.IsHaveValueA36("Rnnny", data);
       }

       public static bool IsHaveValueA37(string data)
       {
           return Exam_Dal.IsHaveValueA37("Rnnny", data);
       }

       public static bool IsHaveValueA38(string data)
       {
           return Exam_Dal.IsHaveValueA38("Rnnny", data);
       }

       public static bool IsHaveValueA39(string data)
       {
           return Exam_Dal.IsHaveValueA39("Rnnny", data);
       }

       public static bool IsHaveValueA40(string data)
       {
           return Exam_Dal.IsHaveValueA40("Rnnny", data);
       }

       public static bool IsHaveValueB0(string data)
       {
           return Exam_Dal.IsHaveValueB0("Rnnny", data);
       }

       public static bool IsHaveValueB1(string data)
       {
           return Exam_Dal.IsHaveValueB1("Rnnny", data);
       }

       public static bool IsHaveValueB2(string data)
       {
           return Exam_Dal.IsHaveValueB2("Rnnny", data);
       }

       public static bool IsHaveValueB3(string data)
       {
           return Exam_Dal.IsHaveValueB3("Rnnny", data);
       }

       public static bool IsHaveValueB4(string data)
       {
           return Exam_Dal.IsHaveValueB4("Rnnny", data);
       }

       public static bool IsHaveValueB5(string data)
       {
           return Exam_Dal.IsHaveValueB5("Rnnny", data);
       }

       public static bool IsHaveValueB6(string data)
       {
           return Exam_Dal.IsHaveValueB6("Rnnny", data);
       }

       public static bool IsHaveValueB7(string data)
       {
           return Exam_Dal.IsHaveValueB7("Rnnny", data);
       }

       public static bool IsHaveValueB8(string data)
       {
           return Exam_Dal.IsHaveValueB8("Rnnny", data);
       }

       public static bool IsHaveValueB9(string data)
       {
           return Exam_Dal.IsHaveValueB9("Rnnny", data);
       }

       public static bool IsHaveValueB10(string data)
       {
           return Exam_Dal.IsHaveValueB10("Rnnny", data);
       }

       public static bool IsHaveValueB11(string data)
       {
           return Exam_Dal.IsHaveValueB11("Rnnny", data);
       }

       public static bool IsHaveValueB12(string data)
       {
           return Exam_Dal.IsHaveValueB12("Rnnny", data);
       }

       public static bool IsHaveValueB13(string data)
       {
           return Exam_Dal.IsHaveValueB13("Rnnny", data);
       }

       public static bool IsHaveValueB14(string data)
       {
           return Exam_Dal.IsHaveValueB14("Rnnny", data);
       }

       public static bool IsHaveValueB15(string data)
       {
           return Exam_Dal.IsHaveValueB15("Rnnny", data);
       }

       public static bool IsHaveValueB16(string data)
       {
           return Exam_Dal.IsHaveValueB16("Rnnny", data);
       }

       public static bool IsHaveValueB17(string data)
       {
           return Exam_Dal.IsHaveValueB17("Rnnny", data);
       }

       public static bool IsHaveValueB18(string data)
       {
           return Exam_Dal.IsHaveValueB18("Rnnny", data);
       }

       public static bool IsHaveValueB19(string data)
       {
           return Exam_Dal.IsHaveValueB19("Rnnny", data);
       }

       public static bool IsHaveValueB20(string data)
       {
           return Exam_Dal.IsHaveValueB20("Rnnny", data);
       }

       public static bool IsHaveValueB21(string data)
       {
           return Exam_Dal.IsHaveValueB21("Rnnny", data);
       }

       public static bool IsHaveValueB22(string data)
       {
           return Exam_Dal.IsHaveValueB22("Rnnny", data);
       }

       public static bool IsHaveValueB23(string data)
       {
           return Exam_Dal.IsHaveValueB23("Rnnny", data);
       }

       public static bool IsHaveValueB24(string data)
       {
           return Exam_Dal.IsHaveValueB24("Rnnny", data);
       }

       public static bool IsHaveValueB25(string data)
       {
           return Exam_Dal.IsHaveValueB25("Rnnny", data);
       }

       public static bool IsHaveValueB26(string data)
       {
           return Exam_Dal.IsHaveValueB26("Rnnny", data);
       }

       public static bool IsHaveValueB27(string data)
       {
           return Exam_Dal.IsHaveValueB27("Rnnny", data);
       }

       public static bool IsHaveValueB28(string data)
       {
           return Exam_Dal.IsHaveValueB28("Rnnny", data);
       }

       public static bool IsHaveValueB29(string data)
       {
           return Exam_Dal.IsHaveValueB29("Rnnny", data);
       }

       public static bool IsHaveValueB30(string data)
       {
           return Exam_Dal.IsHaveValueB30("Rnnny", data);
       }

       public static bool IsHaveValueB31(string data)
       {
           return Exam_Dal.IsHaveValueB31("Rnnny", data);
       }

       public static bool IsHaveValueB32(string data)
       {
           return Exam_Dal.IsHaveValueB32("Rnnny", data);
       }

       public static bool IsHaveValueB33(string data)
       {
           return Exam_Dal.IsHaveValueB33("Rnnny", data);
       }

       public static bool IsHaveValueB34(string data)
       {
           return Exam_Dal.IsHaveValueB34("Rnnny", data);
       }

       public static bool IsHaveValueB35(string data)
       {
           return Exam_Dal.IsHaveValueB35("Rnnny", data);
       }

       public static bool IsHaveValueB36(string data)
       {
           return Exam_Dal.IsHaveValueB36("Rnnny", data);
       }

       public static bool IsHaveValueB37(string data)
       {
           return Exam_Dal.IsHaveValueB37("Rnnny", data);
       }

       public static bool IsHaveValueB38(string data)
       {
           return Exam_Dal.IsHaveValueB38("Rnnny", data);
       }

       public static bool IsHaveValueB39(string data)
       {
           return Exam_Dal.IsHaveValueB39("Rnnny", data);
       }

       public static bool IsHaveValueB40(string data)
       {
           return Exam_Dal.IsHaveValueB40("Rnnny", data);
       }

       public static bool IsHaveValueRound(string data)
       {
           return Exam_Dal.IsHaveValueRound("Rnnny", data);
       }

       #endregion

   }
}
