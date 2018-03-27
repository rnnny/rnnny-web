using System;
using Splash;

/* ----------------------------------------------------------
文件名称：HMM.cs

作者：秦建辉

MSN：splashcn@msn.com
QQ：36748897

版本历史：
    V1.1    2011年06月09日
            修正UMDHMM在Baum-Welch<a href="http://lib.csdn.net/base/datastructure" class='replace_word' title="算法与数据结构知识库" target='_blank' style='color:#df3434; font-weight:bold;'>算法</a>中存在的模型参数调整错误。

    V1.0	2011年06月08日
			将<a href="http://lib.csdn.net/base/c" class='replace_word' title="C语言知识库" target='_blank' style='color:#df3434; font-weight:bold;'>C语言</a>实现的隐马尔科夫模型算法（UMDHMM）改为C#语言实现。

功能描述：
	1.前向算法（forward algorithm）：给定HMM求一个观察序列的概率（评估）
    2.后向算法（backward algorithm）：给定HMM求一个观察序列的概率（评估）
    3.前向-后向算法（forward-backward algorithm）：根据观察序列生成隐马尔科夫模型（学习）
    4.维特比算法（Viterbi algorithm）：搜索最有可能生成一个观察序列的隐藏状态序列（解码）

参考资料：
    C代码：http://www.kanungo.com/software/umdhmm-v1.02.zip
    学习资料：http://www.52nlp.cn/category/hidden-markov-model
 ------------------------------------------------------------ */

namespace Splash
{
    public partial class HMM
    {
        /// <summary>
        /// 隐藏状态数目 N
        /// </summary>
        public readonly Int32 N;

        /// <summary>
        /// 观察符号数目 M
        /// </summary>
        public readonly Int32 M;

        /// <summary>
        /// 状态转移矩阵 A
        /// </summary>
        public Double[,] A;

        /// <summary>
        /// 混淆矩阵（confusion matrix）B
        /// </summary>
        public Double[,] B;

        /// <summary>
        /// 初始概率向量 PI
        /// </summary>
        public Double[] PI;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="StatesNum">隐藏状态数目</param>
        /// <param name="ObservationSymbolsNum">观察符号数目</param>
        public HMM(Int32 StatesNum, Int32 ObservationSymbolsNum)
        {
            N = StatesNum;              // 隐藏状态数目
            M = ObservationSymbolsNum;  // 观察符号数目

            A = new Double[N, N];   // 状态转移矩阵
            B = new Double[N, M];   // 混淆矩阵 
            PI = new Double[N];     // 初始概率向量
        }
    }
}


namespace Splash
{
    partial class HMM
    {
        /// <summary>
        /// 维特比算法：通过给定的观察序列，推算出可能性最大的隐藏状态序列
        /// Viterbi Algorithm: Finding most probable sequence of hidden states
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="Probability">可能性最大的隐藏状态序列的概率</param>
        /// <returns>可能性最大的隐藏状态序列</returns>
        /// <remarks>使用双精度运算，不输出中间结果</remarks>
        public Int32[] Viterbi(Int32[] OB, out Double Probability)
        {
            Double[,] DELTA;
            Int32[,] PSI;

            return Viterbi(OB, out DELTA, out PSI, out Probability);
        }

        /// <summary>
        /// 维特比算法：通过给定的观察序列，推算出可能性最大的隐藏状态序列
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="DELTA">输出中间结果：局部最大概率</param>
        /// <param name="PSI">输出中间结果：反向指针指示最可能路径</param>
        /// <param name="Probability">可能性最大的隐藏状态序列的概率</param>
        /// <returns>可能性最大的隐藏状态序列</returns> 
        /// <remarks>使用双精度运算，且输出中间结果</remarks>
        public Int32[] Viterbi(Int32[] OB, out Double[,] DELTA, out Int32[,] PSI, out Double Probability)
        {            
            DELTA = new Double[OB.Length, N];   // 局部概率
            PSI = new Int32[OB.Length, N];      // 反向指针

            // 1. 初始化
            for (Int32 j = 0; j < N; j++)
            {
                DELTA[0, j] = PI[j] * B[j, OB[0]];
            }

            // 2. 递归
            for (Int32 t = 1; t < OB.Length; t++)
            {
                for (Int32 j = 0; j < N; j++)
                {
                    Double MaxValue = DELTA[t - 1, 0] * A[0, j];
                    Int32 MaxValueIndex = 0;
                    for (Int32 i = 1; i < N; i++)
                    {
                        Double Value = DELTA[t - 1, i] * A[i, j];
                        if (Value > MaxValue)
                        {
                            MaxValue = Value;
                            MaxValueIndex = i;
                        }
                    }

                    DELTA[t, j] = MaxValue * B[j, OB[t]];
                    PSI[t, j] = MaxValueIndex; // 记录下最有可能到达此状态的上一个状态
                }
            }

            // 3. 终止
            Int32[] Q = new Int32[OB.Length];   // 定义最佳路径
            Probability = DELTA[OB.Length - 1, 0];
            Q[OB.Length - 1] = 0;
            for (Int32 i = 1; i < N; i++)
            {
                if (DELTA[OB.Length - 1, i] > Probability)
                {
                    Probability = DELTA[OB.Length - 1, i];
                    Q[OB.Length - 1] = i;
                }
            }

            // 4. 路径回溯
            for (Int32 t = OB.Length - 2; t >= 0; t--)
            {
                Q[t] = PSI[t + 1, Q[t + 1]];
            }

            return Q;
        }

        /// <summary>
        /// 维特比算法：通过给定的观察序列，推算出可能性最大的隐藏状态序列
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="Probability">可能性最大的隐藏状态序列的概率</param>
        /// <returns>可能性最大的隐藏状态序列</returns>
        /// <remarks>使用对数运算，不输出中间结果</remarks>
        public Int32[] ViterbiLog(Int32[] OB, out Double Probability)
        {
            Double[,] DELTA;
            Int32[,] PSI;  

            return ViterbiLog(OB, out DELTA, out PSI, out Probability);
        }

        /// <summary>
        /// 维特比算法：通过给定的观察序列，推算出可能性最大的隐藏状态序列
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="DELTA">输出中间结果：局部最大概率。结果为自然对数值</param>
        /// <param name="PSI">输出中间结果：反向指针指示最可能路径</param>
        /// <param name="Probability">可能性最大的隐藏状态序列的概率</param>
        /// <returns>可能性最大的隐藏状态序列</returns> 
        /// <remarks>使用对数运算，且输出中间结果</remarks>
        public Int32[] ViterbiLog(Int32[] OB, out Double[,] DELTA, out Int32[,] PSI, out Double Probability)
        {            
            DELTA = new Double[OB.Length, N];   // 局部概率
            PSI = new Int32[OB.Length, N];      // 反向指针

            // 0. 预处理
            Double[,] LogA = new Double[N, N];
            for (Int32 i = 0; i < N; i++)
            {
                for (Int32 j = 0; j < N; j++)
                {
                    LogA[i, j] = Math.Log(A[i, j]);
                }
            }

            Double[,] LogBIOT = new Double[N, OB.Length];
            for (Int32 i = 0; i < N; i++)
            {
                for (Int32 t = 0; t < OB.Length; t++)
                {
                    LogBIOT[i, t] = Math.Log(B[i, OB[t]]);
                }
            }

            Double[] LogPI = new Double[N];
            for (Int32 i = 0; i < N; i++)
            {
                LogPI[i] = Math.Log(PI[i]);
            }

            // 1. 初始化
            for (Int32 j = 0; j < N; j++)
            {
                DELTA[0, j] = LogPI[j] + LogBIOT[j, 0];
            }

            // 2. 递归
            for (Int32 t = 1; t < OB.Length; t++)
            {
                for (Int32 j = 0; j < N; j++)
                {
                    Double MaxValue = DELTA[t - 1, 0] + LogA[0, j];
                    Int32 MaxValueIndex = 0;
                    for (Int32 i = 1; i < N; i++)
                    {
                        Double Value = DELTA[t - 1, i] + LogA[i, j];
                        if (Value > MaxValue)
                        {
                            MaxValue = Value;
                            MaxValueIndex = i;
                        }
                    }

                    DELTA[t, j] = MaxValue + LogBIOT[j, t];
                    PSI[t, j] = MaxValueIndex; // 记录下最有可能到达此状态的上一个状态
                }
            }

            // 3. 终止
            Int32[] Q = new Int32[OB.Length];   // 定义最佳路径
            Probability = DELTA[OB.Length - 1, 0];
            Q[OB.Length - 1] = 0;
            for (Int32 i = 1; i < N; i++)
            {
                if (DELTA[OB.Length - 1, i] > Probability)
                {
                    Probability = DELTA[OB.Length - 1, i];
                    Q[OB.Length - 1] = i;
                }
            }

            // 4. 路径回溯
            Probability = Math.Exp(Probability);
            for (Int32 t = OB.Length - 2; t >= 0; t--)
            {
                Q[t] = PSI[t + 1, Q[t + 1]];
            }

            return Q;
        }
    }
}


namespace Splash
{
    partial class HMM
    {
        /// <summary>
        /// 前向-后向算法，用于参数学习
        /// Forward-backward algorithm: Generating a HMM from a sequence of obersvations
        /// </summary>
        /// <param name="OB">已知的观察序列</param>        
        /// <param name="LogProbInit">初始自然对数概率</param>
        /// <param name="LogProbFinal">最终自然对数概率</param>
        /// <param name="ExitError">迭代中允许的自然对数概率误差，缺省0.001</param>
        /// <param name="MSP">状态概率最小值，缺省0.001</param>
        /// <param name="MOP">观察概率最小值，缺省0.001</param>
        /// <returns>迭代次数</returns>
        /// <remarks>修正UMDHMM在模型参数调整中的错误</remarks>        
        public Int32 BaumWelch(Int32[] OB, out Double LogProbInit, out Double LogProbFinal, 
            Double ExitError = 0.001, Double MSP = 0.001, Double MOP = 0.001)
        {
            Double[,] ALPHA = null;
            Double[,] BETA = null;            
            Double[] SCALE = null;
            Double[,] GAMMA = null;
            Double[, ,] XI = null;

            Double LogProbForward = LogProbInit = ForwardWithScale(OB, ref ALPHA, ref SCALE); // 前向算法
            BackwardWithScale(OB, SCALE, ref BETA); // 后向算法
            ComputeGamma(ALPHA, BETA, ref GAMMA);   // 求解各时刻位于各隐藏状态的概率矩阵
            ComputeXI(OB, ALPHA, BETA, ref XI);     // 求解各时刻位于各隐藏状态及下一时刻位于各隐藏状态的关联概率矩阵
            
            Int32 Iterations;
            Double LogProbPrev = LogProbForward;
            for(Iterations = 1; ; Iterations++)
            {   // 重新估计初始概率向量
                for (Int32 i = 0; i < N; i++)
                {   // 注意：此处修正UMDHMM错误，以保证概率总和为1
                    PI[i] = MSP + (1 - MSP * N) * GAMMA[0, i];
                }

                for(Int32 i = 0; i < N; i++)
                {   // 重新估计状态转移矩阵
                    Double DenominatorA = 0;
                    for(Int32 t = 0; t < OB.Length - 1; t++)
                        DenominatorA += GAMMA[t, i];
                    
                    for(Int32 j = 0; j < N; j++)
                    {
                        Double NumeratorA = 0;
                        for(Int32 t = 0; t < OB.Length - 1; t++)
                            NumeratorA += XI[t,i,j];

                        // 注意：此处修正UMDHMM错误，以保证概率总和为1
                        A[i, j] = MSP + (1 - MSP * N) * NumeratorA / DenominatorA;
                    }

                    // 重新估计混淆矩阵
                    Double DenominatorB = DenominatorA + GAMMA[OB.Length - 1, i];
                    for(Int32 k = 0; k < M; k++)
                    {
                        Double NumeratorB = 0;
                        for(Int32 t = 0; t < OB.Length; t++)
                        {
                            if(OB[t] == k) NumeratorB += GAMMA[t,i];
                        }

                        // 注意：此处修正UMDHMM错误，以保证概率总和为1
                        B[i, k] = MOP + (1 - MOP * M) * NumeratorB / DenominatorB;
                    }                   
                } // End for i

                // 计算概率差，决定是否停止迭代
                LogProbForward = ForwardWithScale(OB, ref ALPHA, ref SCALE);
                if (LogProbForward - LogProbPrev <= ExitError) break;

                BackwardWithScale(OB, SCALE, ref BETA);
                ComputeGamma(ALPHA, BETA, ref GAMMA);
                ComputeXI(OB, ALPHA, BETA, ref XI);
                LogProbPrev = LogProbForward;
            } // End for Iterations

            LogProbFinal = LogProbForward;  // 最终概率

            // 返回迭代次数
            return Iterations;
        }

        /// <summary>
        /// 求解t时刻位于隐藏状态Si的概率矩阵
        /// </summary>
        /// <param name="ALPHA">前向算法局部概率</param>
        /// <param name="BETA">后向算法局部概率</param>
        /// <param name="GAMMA">输出：各时刻位于各隐藏状态的概率矩阵</param>
        private void ComputeGamma(Double[,] ALPHA, Double[,] BETA, ref Double[,] GAMMA)
        {
            Int32 T = ALPHA.GetLength(0);
            if (GAMMA == null) GAMMA = new Double[T, N];

            for (Int32 t = 0; t < T; t++)
            {
                Double Denominator = 0;
                for (Int32 i = 0; i < N; i++)
                {
                    GAMMA[t, i] = ALPHA[t, i] * BETA[t, i];
                    Denominator += GAMMA[t, i];
                }

                for (Int32 i = 0; i < N; i++)
                {
                    GAMMA[t, i] /= Denominator; // 保证各时刻的概率总和等于1
                }
            }
        }

        /// <summary>
        /// 求解t时刻位于隐藏状态Si及t+1时刻位于隐藏状态Sj的概率矩阵
        /// </summary>
        /// <param name="OB">观察序列</param>
        /// <param name="ALPHA">前向算法局部概率</param>
        /// <param name="BETA">后向算法局部概率</param>
        /// <param name="XI">输出：求解各时刻位于各隐藏状态及下一时刻位于各隐藏状态的关联概率矩阵</param>
        private void ComputeXI(Int32[] OB, Double[,] ALPHA, Double[,] BETA, ref Double[,,] XI)
        {
            Int32 T = OB.Length;
            if (XI == null) XI = new Double[T, N, N];

            for (Int32 t = 0; t < T - 1; t++)
            {
                Double Sum = 0;
                for (Int32 i = 0; i < N; i++)
                {
                    for (Int32 j = 0; j < N; j++)
                    {
                        XI[t, i, j] = ALPHA[t, i] * A[i, j] * B[j, OB[t + 1]] * BETA[t + 1, j];
                        Sum += XI[t, i, j];
                    }
                }

                // 保证各时刻的概率总和等于1
                for (Int32 i = 0; i < N; i++)
                    for (Int32 j = 0; j < N; j++)
                        XI[t, i, j] /= Sum; 
            }
        }
    }
}


namespace Splash
{
    partial class HMM
    {
        /// <summary>
        /// 后向算法：计算观察序列的概率
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <returns>观察序列的概率</returns>
        public Double Backward(Int32[] OB)
        {
            Double[,] BETA;     // 只声明，不定义

            return Backward(OB, out BETA);
        }

        /// <summary>
        /// 后向算法：计算观察序列的概率
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="BETA">中间结果</param>
        /// <returns>观察序列的概率</returns>
        public Double Backward(Int32[] OB, out Double[,] BETA)
        {            
            BETA = new Double[OB.Length, N];

            // 初始化
            for (Int32 j = 0; j < N; j++)
            {
                BETA[OB.Length - 1, j] = 1.0;
            }

            // 归纳
            for (Int32 t = OB.Length - 2; t >= 0; t--)
            {
                for (Int32 j = 0; j < N; j++)
                {
                    Double Sum = 0;
                    for (Int32 i = 0; i < N; i++)
                    {
                        Sum += A[j, i] * B[i, OB[t + 1]] * BETA[t + 1, i];
                    }

                    BETA[t, j] = Sum;
                }
            }

            // 终止
            Double Probability = 0;
            for (Int32 i = 0; i < N; i++)
            {
                Probability += BETA[0, i];
            }

            return Probability;
        }

        /// <summary>
        /// 带比例因子修正的后向算法
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="SCALE">用于修正的比例因子</param>
        /// <param name="BETA">中间结果：局部概率</param>
        private void BackwardWithScale(Int32[] OB, Double[] SCALE, ref Double[,] BETA)
        {
            if(BETA == null) BETA = new Double[OB.Length, N];

            // 初始化
            for (Int32 j = 0; j < N; j++)
            {
                BETA[OB.Length - 1, j] = 1.0 / SCALE[OB.Length - 1];
            }

            // 归纳
            for (Int32 t = OB.Length - 2; t >= 0; t--)
            {
                for (Int32 j = 0; j < N; j++)
                {
                    Double Sum = 0;
                    for (Int32 i = 0; i < N; i++)
                    {
                        Sum += A[j, i] * B[i, OB[t + 1]] * BETA[t + 1, i];
                    }

                    BETA[t, j] = Sum / SCALE[t];
                }
            }
        }
    }
}


namespace Splash
{
    partial class HMM
    {
        /// <summary>
        /// 前向算法：计算观察序列的概率
        /// Forward Algorithm: Finding the probability of an observed sequence
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <returns>观察序列的概率</returns>
        /// <remarks>使用双精度运算，不输出中间结果</remarks>
        public Double Forward(Int32[] OB)
        {
            Double[,] ALPHA;    // 只声明，不定义

            return Forward(OB, out ALPHA);
        }

        /// <summary>
        /// 前向算法：计算观察序列的概率
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="ALPHA">输出中间结果：局部概率</param>
        /// <returns>观察序列的概率</returns>
        /// <remarks>使用双精度运算，输出中间结果</remarks>
        public Double Forward(Int32[] OB, out Double[,] ALPHA)
        {            
            ALPHA = new Double[OB.Length, N];   // 局部概率

            // 1. 初始化：计算初始时刻所有状态的局部概率
            for (Int32 j = 0; j < N; j++)
            {
                ALPHA[0, j] = PI[j] * B[j, OB[0]];
            }

            // 2. 归纳：递归计算每个时间点的局部概率
            for (Int32 t = 1; t < OB.Length; t++)
            {
                for (Int32 j = 0; j < N; j++)
                {
                    Double Sum = 0;
                    for (Int32 i = 0; i < N; i++)
                    {
                        Sum += ALPHA[t - 1, i] * A[i, j];
                    }

                    ALPHA[t, j] = Sum * B[j, OB[t]];
                }
            }

            // 3. 终止：观察序列的概率等于最终时刻所有局部概率之和
            Double Probability = 0;
            for (Int32 i = 0; i < N; i++)
            {
                Probability += ALPHA[OB.Length - 1, i];
            }

            return Probability;
        }

        /// <summary>
        /// 带比例因子修正的前向算法：计算观察序列的概率
        /// </summary>
        /// <param name="OB">已知的观察序列</param>
        /// <param name="ALPHA">中间结果：局部概率</param>
        /// <param name="SCALE">中间结果：比例因子</param>
        /// <returns>观察序列的概率（自然对数值）</returns>
        private Double ForwardWithScale(Int32[] OB, ref Double[,] ALPHA, ref Double[] SCALE)
        {
            if(ALPHA == null) ALPHA = new Double[OB.Length, N];
            if(SCALE == null) SCALE = new Double[OB.Length];

            // 1. 初始化
            SCALE[0] = 0;
            for (Int32 j = 0; j < N; j++)
            {
                ALPHA[0, j] = PI[j] * B[j, OB[0]];
                SCALE[0] += ALPHA[0, j];
            }

            for (Int32 j = 0; j < N; j++)
            {
                ALPHA[0, j] /= SCALE[0];
            }

            // 2. 归纳
            for (Int32 t = 1; t < OB.Length; t++)
            {
                SCALE[t] = 0;
                for (Int32 j = 0; j < N; j++)
                {
                    Double Sum = 0;
                    for (Int32 i = 0; i < N; i++)
                    {
                        Sum += ALPHA[t - 1, i] * A[i, j];
                    }

                    ALPHA[t, j] = Sum * B[j, OB[t]];
                    SCALE[t] += ALPHA[t, j];
                }

                for (Int32 j = 0; j < N; j++)
                {
                    ALPHA[t, j] /= SCALE[t];
                }
            }            

            // 3. 终止
            Double Probability = 0;
            for (Int32 t = 0; t < OB.Length; t++)
            {
                Probability += Math.Log(SCALE[t]);
            }

            return Probability;     // 自然对数值
        }
    }
}


namespace SplashCheck
{
    public class TestHMMCS
    {
        enum Weather { Sunny, Cloudy, Rainy };  // 隐藏状态（天气）
        enum Seaweed { Dry, Dryish, Damp, Soggy };  // 观察状态（海藻湿度）

        //static void Main(string[] args)
        //{
            // 测试前向<a href="http://lib.csdn.net/base/datastructure" class='replace_word' title="算法与数据结构知识库" target='_blank' style='color:#df3434; font-weight:bold;'>算法</a>和后向算法
            //CheckForwardAndBackward();
            //Console.WriteLine();

            //// 测试维特比算法
            //CheckViterbi();
            //Console.WriteLine();

            //// 测试HMM学习算法
            //CheckBaumWelch();
        //}

        // 测试前向算法和后向算法
        public static string CheckForwardAndBackward()
        {
            // 状态转移矩阵
            Double[,] A = {
                {0.500, 0.375, 0.125},
                {0.250, 0.125, 0.625},
                {0.250, 0.375, 0.375}
            };

            // 混淆矩阵
            Double[,] B = 
            {
                {0.60, 0.20, 0.15, 0.05},
                {0.25, 0.25, 0.25, 0.25},
                {0.05, 0.10, 0.35, 0.50}
            };

            // 初始概率向量
            Double[] PI = { 0.63, 0.17, 0.20 };

            // 观察序列
            Int32[] OB = { (Int32)Seaweed.Dry, (Int32)Seaweed.Damp, (Int32)Seaweed.Soggy };

            // 初始化HMM模型
            HMM hmm = new HMM(A.GetLength(0), B.GetLength(1));
            hmm.A = A;
            hmm.B = B;
            hmm.PI = PI;

            // 观察序列的概率
            //Console.WriteLine("------------前向算法：双精度运算-----------------");
            Double ProbabilityFor = hmm.Forward(OB);
            //Console.WriteLine("Probability =" + Probability.ToString("0.###E+0"));
            //Console.WriteLine();

            // 观察序列的概率
            //Console.WriteLine("------------后向算法：双精度运算-----------------");
            Double ProbabilityBack = hmm.Backward(OB);
            //Console.WriteLine("Probability =" + Probability.ToString("0.###E+0"));

            return ProbabilityFor.ToString("0.###E+0") + "|" + ProbabilityBack.ToString("0.###E+0");
        }

        // 测试维特比算法
        public static void CheckViterbi()
        {
            // 状态转移矩阵
            Double[,] A = {
                {0.500, 0.250, 0.250},
                {0.375, 0.125, 0.375},
                {0.125, 0.675, 0.375}
            };

            // 混淆矩阵
            Double[,] B = 
            {
                {0.60, 0.20, 0.15, 0.05},
                {0.25, 0.25, 0.25, 0.25},
                {0.05, 0.10, 0.35, 0.50}
            };

            // 初始概率向量
            Double[] PI = { 0.63, 0.17, 0.20 };

            // 观察序列
            Int32[] OB = { (Int32)Seaweed.Dry, (Int32)Seaweed.Damp, (Int32)Seaweed.Soggy, (Int32)Seaweed.Dryish, (Int32)Seaweed.Dry };

            // 初始化HMM模型
            HMM hmm = new HMM(A.GetLength(0), B.GetLength(1));
            hmm.A = A;
            hmm.B = B;
            hmm.PI = PI;

            // 找出最有可能的隐藏状态序列
            Double Probability;

            Console.WriteLine("------------维特比算法：双精度运算-----------------");
            Int32[] Q = hmm.Viterbi(OB, out Probability);
            Console.WriteLine("Probability =" + Probability.ToString("0.###E+0"));
            foreach (Int32 Value in Q)
            {
                Console.WriteLine(((Weather)Value).ToString());
            }
            Console.WriteLine();

            Console.WriteLine("------------维特比算法：对数运算-----------------");
            Q = hmm.ViterbiLog(OB, out Probability);
            Console.WriteLine("Probability =" + Probability.ToString("0.###E+0"));
            foreach (Int32 Value in Q)
            {
                Console.WriteLine(((Weather)Value).ToString());
            }
        }

        public static void CheckBaumWelch()
        {
            // 状态转移矩阵
            Double[,] A = {
                {0.500, 0.250, 0.250},
                {0.375, 0.125, 0.375},
                {0.125, 0.675, 0.375}
            };

            // 混淆矩阵
            Double[,] B = 
            {
                {0.60, 0.20, 0.15, 0.05},
                {0.25, 0.25, 0.25, 0.25},
                {0.05, 0.10, 0.35, 0.50}
            };

            // 初始概率向量
            Double[] PI = { 0.63, 0.17, 0.20 };

            // 观察序列
            Int32[] OB = { (Int32)Seaweed.Dry, (Int32)Seaweed.Damp, (Int32)Seaweed.Soggy, (Int32)Seaweed.Dryish, (Int32)Seaweed.Dry };

            // 初始化HMM模型
            HMM hmm = new HMM(A.GetLength(0), B.GetLength(1));

            // 数组克隆，避免损坏原始数据
            hmm.A = (Double[,])A.Clone();
            hmm.B = (Double[,])B.Clone();
            hmm.PI = (Double[])PI.Clone();

            // 前向-后向算法
            Console.WriteLine("------------Baum-Welch算法-----------------");
            Double LogProbInit, LogProbFinal;
            Int32 Iterations = hmm.BaumWelch(OB, out LogProbInit, out LogProbFinal);
            Console.WriteLine("迭代次数 = {0}", Iterations);
            Console.WriteLine("初始概率 = {0}", Math.Exp(LogProbInit));
            Console.WriteLine("最终概率 = {0}", Math.Exp(LogProbFinal));
            Console.WriteLine();

            // 打印学习后的模型参数
            Console.WriteLine("新的模型参数：");
            Console.WriteLine("PI");
            for (Int32 i = 0; i < hmm.N; i++)
            {
                if (i == 0)
                    Console.Write(hmm.PI[i].ToString("0.000"));
                else
                    Console.Write(" " + hmm.PI[i].ToString("0.000"));
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("A");
            for (Int32 i = 0; i < hmm.N; i++)
            {
                for (Int32 j = 0; j < hmm.N; j++)
                {
                    if (j == 0)
                        Console.Write(hmm.A[i, j].ToString("0.000"));
                    else
                        Console.Write(" " + hmm.A[i, j].ToString("0.000"));
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("B");
            for (Int32 i = 0; i < hmm.N; i++)
            {
                for (Int32 j = 0; j < hmm.M; j++)
                {
                    if (j == 0)
                        Console.Write(hmm.B[i, j].ToString("0.000"));
                    else
                        Console.Write(" " + hmm.B[i, j].ToString("0.000"));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
