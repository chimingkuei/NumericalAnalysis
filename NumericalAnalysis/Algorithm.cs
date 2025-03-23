using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalAnalysis
{
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


}
