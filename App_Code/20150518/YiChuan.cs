using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YiChuan
{
    public class YiChuanTest
    {
        #region 权重
        /// <summary>
        /// 知识点分布权重
        /// </summary>
        public static double kpcoverage = 0.10;

        /// <summary>
        /// 试卷难度系数权重
        /// </summary>
        public static double difficulty = 0.90;
        #endregion

        #region 调用示例
        public void Show()
        {
            DB db = new DB();
            Paper paper = new Paper()
            {
                ID = 1,
                TotalScore = 100,
                Difficulty = 0.72,
                Points = new List<int>() { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59, 61, 63, 65, 67, 69, 71, 73, 75, 77, 79, 81 },
                EachTypeCount = new[] { 20, 5, 10, 7, 5 },
                EachTypeSumScore = new[] { 20, 10, 20, 20, 30 }
            };

            List<Unit> unitList = CSZQ(20, paper, db.ProblemDB);
            int count = 0;
            ShowUnit(unitList);
            Console.WriteLine("-----------------------------------------------");
            double expand = 0.98;
            int runCount = 500;
            while (!IsEnd(unitList, expand))
            {
                count++;
                if (count > runCount)
                {
                    Console.WriteLine("计算 " + runCount + " 代仍没有结果，请重新设计条件！");
                    break;
                }
                unitList = Select(unitList, 10);

                unitList = Cross(unitList, 20, paper);

                if (IsEnd(unitList, expand))
                {
                    break;
                }

                unitList = Change(unitList, db.ProblemDB, paper);
                if (IsEnd(unitList, expand))
                {
                    break;
                }
                Console.WriteLine("在第 " + count + " 代未得到结果");
            }
            if (count <= runCount)
            {
                Console.WriteLine("在第 " + count + " 代得到结果，结果为：");
                Console.WriteLine("试卷难度：" + paper.Difficulty);
                ShowResult(unitList, expand);
            }
        }
        #endregion

        #region 初始种群
        public List<Unit> CSZQ(int count, Paper paper, List<Problem> problemList)
        {
            List<Unit> unitList = new List<Unit>();
            int[] eachTypeCount = paper.EachTypeCount;
            Unit unit;
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                unit = new Unit();
                unit.ID = i + 1;
                unit.AdaptationDegree = 0.00;
                while (paper.TotalScore != unit.SumScore)
                {
                    unit.ProblemList.Clear();
                    for (int j = 0; j < eachTypeCount.Length; j++)
                    {
                        List<Problem> oneTypeProblem = problemList
                            .Where(o => o.Type == (j + 1))
                            .Where(p => IsContain(paper, p))
                            .ToList();
                        Problem temp = new Problem();
                        for (int k = 0; k < eachTypeCount[j]; k++)
                        {
                            int index = rand.Next(0, oneTypeProblem.Count - k);
                            unit.ProblemList.Add(oneTypeProblem[index]);
                            temp = oneTypeProblem[oneTypeProblem.Count - 1 - k];
                            oneTypeProblem[oneTypeProblem.Count - 1 - k] = oneTypeProblem[index];
                            oneTypeProblem[index] = temp;
                        }
                    }
                }

                unitList.Add(unit);
            }

            unitList = GetKPCoverage(unitList, paper);
            unitList = GetAdaptationDegree(unitList, paper, kpcoverage, difficulty);

            return unitList;
        }
        #endregion

        #region 选择算子
        public List<Unit> Select(List<Unit> unitList, int count)
        {
            List<Unit> selectedUnitList = new List<Unit>();
            double AllAdaptationDegree = 0;
            unitList.ForEach(delegate(Unit u)
            {
                AllAdaptationDegree += u.AdaptationDegree;
            });
            Random rand = new Random();
            while (selectedUnitList.Count != count)
            {
                double degree = 0.00;
                double randDegree = rand.Next(1, 100) * 0.01 * AllAdaptationDegree;
                for (int j = 0; j < unitList.Count; j++)
                {
                    degree += unitList[j].AdaptationDegree;
                    if (degree >= randDegree)
                    {
                        if (!selectedUnitList.Contains(unitList[j]))
                        {
                            selectedUnitList.Add(unitList[j]);
                        }
                        break;
                    }
                }
            }
            return selectedUnitList;
        }
        #endregion

        #region 交叉算子
        public List<Unit> Cross(List<Unit> unitList, int count, Paper paper)
        {
            List<Unit> crossedUnitList = new List<Unit>();
            Random rand = new Random();
            while (crossedUnitList.Count != count)
            {
                int indexOne = rand.Next(0, unitList.Count);
                int indexTwo = rand.Next(0, unitList.Count);
                Unit unitOne;
                Unit unitTwo;
                if (indexOne != indexTwo)
                {
                    unitOne = unitList[indexOne];
                    unitTwo = unitList[indexTwo];
                    int crossPosition = rand.Next(0, unitOne.ProblemCount - 2);
                    double scoreOne = unitOne.ProblemList[crossPosition].Score + unitOne.ProblemList[crossPosition + 1].Score;
                    double scoreTwo = unitTwo.ProblemList[crossPosition].Score + unitTwo.ProblemList[crossPosition + 1].Score;
                    if (scoreOne == scoreTwo)
                    {
                        Unit unitNewOne = new Unit();
                        unitNewOne.ProblemList = new List<Problem>();
                        unitNewOne.ProblemList.AddRange(unitOne.ProblemList);
                        Unit unitNewTwo = new Unit();
                        unitNewTwo.ProblemList = new List<Problem>();
                        unitNewTwo.ProblemList.AddRange(unitTwo.ProblemList);
                        for (int i = crossPosition; i < crossPosition + 2; i++)
                        {
                            unitNewOne.ProblemList[i] = new Problem(unitTwo.ProblemList[i]);
                            unitNewTwo.ProblemList[i] = new Problem(unitOne.ProblemList[i]);
                        }
                        unitNewOne.ID = crossedUnitList.Count;
                        unitNewTwo.ID = unitNewOne.ID + 1;
                        if (crossedUnitList.Count < count)
                        {
                            crossedUnitList.Add(unitNewOne);
                        }
                        if (crossedUnitList.Count < count)
                        {
                            crossedUnitList.Add(unitNewTwo);
                        }

                    }
                }
                crossedUnitList = crossedUnitList.Distinct(new ProblemComparer()).ToList();
            }

            crossedUnitList = GetKPCoverage(crossedUnitList, paper);
            crossedUnitList = GetAdaptationDegree(crossedUnitList, paper, kpcoverage, difficulty);
            return crossedUnitList;
        }
        #endregion

        #region 变异算子
        public List<Unit> Change(List<Unit> unitList, List<Problem> problemList, Paper paper)
        {
            Random rand = new Random();
            int index = 0;
            unitList.ForEach(delegate(Unit u)
            {
                index = rand.Next(0, u.ProblemList.Count);
                Problem temp = u.ProblemList[index];
                Problem problem = new Problem();
                for (int i = 0; i < temp.Points.Count; i++)
                {
                    if (paper.Points.Contains(temp.Points[i]))
                    {
                        problem.Points.Add(temp.Points[i]);
                    }
                }

                var otherDB = from a in problemList
                              where a.Points.Intersect(problem.Points).Count() > 0
                              select a;

                List<Problem> smallDB = otherDB.Where(p => IsContain(paper, p)).Where(o => o.Score == temp.Score && o.Type == temp.Type && o.ID != temp.ID).ToList();

                if (smallDB.Count > 0)
                {
                    int changeIndex = rand.Next(0, smallDB.Count);
                    u.ProblemList[index] = smallDB[changeIndex];
                }
            });

            unitList = GetKPCoverage(unitList, paper);
            unitList = GetAdaptationDegree(unitList, paper, kpcoverage, difficulty);
            return unitList;
        }
        #endregion

        #region 是否达到目标
        public bool IsEnd(List<Unit> unitList, double endcondition)
        {
            if (unitList.Count > 0)
            {
                for (int i = 0; i < unitList.Count; i++)
                {
                    if (unitList[i].AdaptationDegree >= endcondition)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region 题目知识点是否符合试卷要求
        private bool IsContain(Paper paper, Problem problem)
        {
            for (int i = 0; i < problem.Points.Count; i++)
            {
                if (paper.Points.Contains(problem.Points[i]))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 计算知识点分布
        public List<Unit> GetKPCoverage(List<Unit> unitList, Paper paper)
        {
            List<int> kp;
            for (int i = 0; i < unitList.Count; i++)
            {
                kp = new List<int>();
                unitList[i].ProblemList.ForEach(delegate(Problem p)
                {
                    kp.AddRange(p.Points);
                });
                var common = kp.Intersect(paper.Points);
                unitList[i].KPCoverage = common.Count() * 1.00 / paper.Points.Count;
            }
            return unitList;
        }
        #endregion

        #region 计算试卷适应度
        public List<Unit> GetAdaptationDegree(List<Unit> unitList, Paper paper, double KPCoverage, double Difficulty)
        {
            unitList = GetKPCoverage(unitList, paper);
            for (int i = 0; i < unitList.Count; i++)
            {
                unitList[i].AdaptationDegree = 1 - (1 - unitList[i].KPCoverage) * KPCoverage - Math.Abs(unitList[i].Difficulty - paper.Difficulty) * Difficulty;
            }
            return unitList;
        }
        #endregion

        #region 显示群体
        public void ShowUnit(List<Unit> unitList)
        {
            unitList.OrderBy(o => o.ID).ToList().ForEach(delegate(Unit u)
            {
                Console.WriteLine("第" + u.ID + "套：");
                Console.WriteLine("题目数量\t知识点分布\t难度系数\t适应度");
                Console.WriteLine(u.ProblemCount + "\t\t" + u.KPCoverage.ToString("f2") + "\t\t" + u.Difficulty.ToString("f2") + "\t\t" + u.AdaptationDegree.ToString("f2"));
                //Console.WriteLine("编号\t分数\t题型\t难度系数");
                //u.ProblemList.ForEach(delegate(Problem p)
                //{
                //    Console.WriteLine(p.ID + "\t" + p.Score + "\t" + p.Type + "\t" + p.Difficulty.ToString("f2"));
                //});
                Console.WriteLine();
                Console.WriteLine();
            });
        }
        #endregion

        #region 显示结果
        public void ShowResult(List<Unit> unitList, double expand)
        {
            unitList.OrderBy(o => o.ID).ToList().ForEach(delegate(Unit u)
            {
                if (u.AdaptationDegree >= expand)
                {
                    Console.WriteLine("第" + u.ID + "套：");
                    Console.WriteLine("题目数量\t知识点分布\t难度系数\t适应度");
                    Console.WriteLine(u.ProblemCount + "\t\t" + u.KPCoverage.ToString("f2") + "\t\t" + u.Difficulty.ToString("f2") + "\t\t" + u.AdaptationDegree.ToString("f2"));
                    //Console.WriteLine("编号\t分数\t题型\t难度系数");
                    //u.ProblemList.ForEach(delegate(Problem p)
                    //{
                    //    Console.WriteLine(p.ID + "\t" + p.Score + "\t" + p.Type + "\t" + p.Difficulty.ToString("f2"));
                    //});
                    Console.WriteLine();
                    Console.WriteLine();
                }
            });
        }
        #endregion

        #region 显示一个群体题目编号
        public void ShowUnit(Unit u)
        {
            Console.WriteLine("编号\t知识点分布\t难度系数");
            Console.WriteLine(u.ID + "\t" + u.KPCoverage.ToString("f2") + "\t\t" + u.Difficulty.ToString("f2"));
            u.ProblemList.ForEach(delegate(Problem p)
            {
                Console.Write(p.ID + "\t");
            });
            Console.WriteLine();
        }
        #endregion
    }

    #region 检查是否有重得试题
    public class ProblemComparer : IEqualityComparer<Unit>
    {
        public bool Equals(Unit x, Unit y)
        {
            bool result = true;
            for (int i = 0; i < x.ProblemList.Count; i++)
            {
                if (x.ProblemList[i].ID != y.ProblemList[i].ID)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public int GetHashCode(Unit obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
    #endregion

    #region 种群个体
    public class Unit
    {
        public Unit()
        {
            ID = 0;
            AdaptationDegree = 0.00;
            KPCoverage = 0.00;
            ProblemList = new List<Problem>();
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 适应度
        /// </summary>
        public double AdaptationDegree { get; set; }
        /// <summary>
        /// 难度系数
        /// </summary>
        public double Difficulty
        {
            get
            {
                double diff = 0.00;
                ProblemList.ForEach(delegate(Problem p)
                {
                    diff += p.Difficulty * p.Score;
                });
                return diff / SumScore;
            }
        }
        /// <summary>
        /// 题目数量
        /// </summary>
        public int ProblemCount
        {
            get
            {
                return ProblemList.Count;
            }
        }
        /// <summary>
        /// 总分
        /// </summary>
        public int SumScore
        {
            get
            {
                int sum = 0;
                ProblemList.ForEach(delegate(Problem p)
                {
                    sum += p.Score;
                });
                return sum;
            }
        }
        /// <summary>
        /// 知识点分布
        /// </summary>
        public double KPCoverage { get; set; }
        /// <summary>
        /// 题目
        /// </summary>
        public List<Problem> ProblemList { get; set; }
    }
    #endregion

    #region 题目实体
    public class Problem
    {
        public Problem()
        {
            ID = 0;
            Type = 0;
            Score = 0;
            Difficulty = 0.00;
            Points = new List<int>();
        }

        public Problem(Problem p)
        {
            this.ID = p.ID;
            this.Type = p.Type;
            this.Score = p.Score;
            this.Difficulty = p.Difficulty;
            this.Points = p.Points;
        }

        public int ID { get; set; }
        /// <summary>
        /// 1、2、3、4、5对应单选，多选，判断，填空，问答
        /// </summary>
        public int Type { get; set; }
        public int Score { get; set; }
        public double Difficulty { get; set; }
        public List<int> Points { get; set; }
    }
    #endregion

    #region 试卷
    public class Paper
    {
        public int ID { get; set; }
        public int TotalScore { get; set; }
        public double Difficulty { get; set; }
        public List<int> Points { get; set; }
        public int[] EachTypeCount { get; set; }
        public int[] EachTypeSumScore { get; set; }
    }
    #endregion

    #region 试题库
    public class DB
    {
        public List<Problem> ProblemDB;
        public DB()
        {
            ProblemDB = new List<Problem>();
            Problem model;
            Random rand = new Random();
            List<int> Points;
            for (int i = 1; i <= 5000; i++)
            {
                model = new Problem();
                model.ID = i;
                model.Difficulty = rand.Next(30, 100) * 0.01;
                if (i < 1001)
                {
                    model.Type = 1;
                    model.Score = 1;
                }
                if (i > 1000 && i < 2001)
                {
                    model.Type = 2;
                    model.Score = 2;
                }
                if (i > 2000 && i < 3001)
                {
                    model.Type = 3;
                    model.Score = 2;
                }
                if (i > 3000 && i < 4001)
                {
                    model.Type = 4;
                    model.Score = rand.Next(1, 5);
                }
                if (i > 4000 && i < 5001)
                {
                    model.Type = 5;
                    model.Score = model.Difficulty > 0.3 ? (int)(double.Parse(model.Difficulty.ToString("f1")) * 10) : 3;
                }
                Points = new List<int>();
                int count = rand.Next(1, 5);
                for (int j = 0; j < count; j++)
                {
                    Points.Add(rand.Next(1, 100));
                }
                model.Points = Points;
                ProblemDB.Add(model);
            }
        }
        public void ShowDB()
        {
            ProblemDB.ForEach(
                delegate(Problem p)
                {
                    Console.Write(p.ID + "\t" + p.Type + "\t" + p.Score + "\t" + p.Difficulty + "\t");
                    p.Points.ForEach(
                        delegate(int o)
                        {
                            Console.Write(o + "\t");
                        }
                    );
                    Console.WriteLine();
                });
        }
    }
    #endregion
}