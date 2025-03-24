using NCalc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumericalAnalysis
{
    /// <summary>
    /// Polynomial poly = new Polynomial(1, -2, 3); // 1 - 2x + 3x^2
    /// Console.WriteLine(poly.ToString()); // "3x^2 + -2x^1 + 1"
    /// Console.WriteLine(poly.Evaluate(2)); // 計算 x = 2 時的值
    /// </summary>
    class Polynomial
    {
        private double[] coefficients;

        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }

        public double Evaluate(double x)
        {
            double result = 0;
            double power = 1;
            for (int i = 0; i < coefficients.Length; i++)
            {
                result += coefficients[i] * power;
                power *= x;
            }
            return result;
        }

        public override string ToString()
        {
            List<string> terms = new List<string>();
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                if (coefficients[i] != 0)
                {
                    terms.Add($"{coefficients[i]}x^{i}");
                }
            }
            return string.Join(" + ", terms);
        }
    }

    class Base
    {
        public double EvaluateFunction(string expression, double x)
        {
            try
            {
                var expr = new Expression(expression);  // 創建表達式對象
                expr.Parameters["x"] = x;                // 設置 x 參數
                return Convert.ToDouble(expr.Evaluate()); // 計算並返回結果
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"解析或計算函數失敗: {ex.Message}");
            }
        }
    }

    class EquationOneVariable:Base
    {
        public double Bisection(Func<double, double> function, double a, double b, double tolerance, int maxIterations)
        {
            if (function(a) * function(b) >= 0)
            {
                Console.WriteLine("函數值在區間端點的符號相同，無法確保存在根！");
            }
            double mid = 0;
            for (int i = 0; i < maxIterations; i++)
            {
                mid = (a + b) / 2;
                double fMid = function(mid);
                if (Math.Abs(fMid) < tolerance) // 判斷是否收斂
                    return mid;
                if (function(a) * fMid < 0)
                    b = mid; // 根在 [a, mid] 內
                else
                    a = mid; // 根在 [mid, b] 內
            }
            return mid; // 返回最後的近似根
        }


    }

}
