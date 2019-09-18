using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace ConsoleApplication1
{


    public  class Program
    {
        public static char[] op = { '+', '-', '*', '/' };//将运算符写入一个静态数组
        public static string mkformula()
        {
            Random rd = new Random();
            string formula = null;
            //随机生成数
            int num1 = (int)rd.Next(0, 100);
            int opNum = (int)rd.Next(2, 4);
            formula = formula + num1;//初始化等式，拥有第一个运算数
            for (int i = 0; i < opNum;)//根据随机生成的运算符的数量进行遍历
            {
                int num2 = (int)rd.Next(0, 100);//随机生成后面的运算数
                int opChoose = (int)rd.Next(0, 4);//在运算符数组中随机选择运算符
                formula = formula + op[opChoose] + num2;//叠加上等式

                /*废掉的代码
                if (Check(formula) == false)
                {
                    continue;
                }*/
                i++;

            }
            return formula;//返回一个等式
        }
        //计算随机生成的等式的值
        public static string Solve(string formula)
        {
            DataTable dt = new DataTable();
            object result = null;
            result = dt.Compute(formula, "");
            while (result.ToString().Contains(".") || formula.Contains("/0") || int.Parse(result.ToString()) < 0)
            {

                formula = mkformula();
                result = dt.Compute(formula, "");
            }
            return formula + "=" + result.ToString();
        }
        //判断是否出现被除数为0，且值含有小数的情况
        //加减法不会出现小数的情况，只用考虑除法的情况
        //考虑用一个bool函数
        /*public static bool Check(string formula)
        {
            //遍历我们的等式，找到除法
            for (int i = 0; i < formula.Length; i++)
            {
                if (formula[i] =='/')
                {
                    //获取除数与被除数，并判断是否满足条件
                    if (formula[i - 1] % formula[i + 1] != 0 || formula[i+1]==0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }*/
        //写入文件里面
        public static void File(string formula)
        {
            StreamWriter sw = new StreamWriter("F:\\Work2\\AchaoCalculator\\charming0011\\subject.txt", false, Encoding.UTF8);
            sw.Write(formula);
            sw.Close();

        }
        //事务处理函数
        public static void process()
        {
            string result = null;
            Console.Write("想生成题目的数量：");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                result = result + Solve(mkformula()) + "\r\n";
                File(result);
                //result = result + Solve(formula);
                //设置种子变换，使其生成不一样的数
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine(result);

        }


        public static void Main(string[] args)
        {
            process();
            Console.Read();
        }
    }
}
