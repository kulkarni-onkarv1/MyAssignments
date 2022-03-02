using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Imperative_LINQ
{
    internal class SalaryBreakupCalculation
    {
        public static void FlexibleBenefitPlanForManager(ref float HRA,ref float TS,ref float DA,float Salary)
        {
            HRA = Salary * 0.1f;
            TS = Salary * 0.15f;
            DA = Salary * 0.2f;
        }
        public static void FlexibleBenefitPlanForDirector(ref float HRA, ref float TS, ref float DA, float Salary)
        {
            HRA = Salary * 0.2f;
            TS = Salary * 0.3f;
            DA = Salary * 0.4f;
        }

        public static void FlexibleBenefitPlanForEngineer(ref float HRA, ref float TS, ref float DA, float Salary)
        {
            HRA = Salary * 0.05f;
            TS = Salary * 0.1f;
            DA = Salary * 0.15f;
        }

        public static void FlexibleBenefitPlanForAdmin(ref float HRA, ref float TS, ref float DA, float Salary)
        {
            HRA = Salary * 0.08f;
            TS = Salary * 0.12f;
            DA = Salary * 0.19f;
        }

        public static void IncomeWiseTaxCalculation(float Gross,out float Tax)
        {
            if (Gross >= 5 && Gross < 10)
            {
                Tax = Gross * 0.1f;
            }
            else if(Gross >=10  && Gross < 20)
            {
                Tax = Gross * 0.15f;
            }
            else if(Gross >= 20)
            {
                Tax = Gross * 0.2f;
            }
            else
            {
                Tax = Gross * 0.05f;
            }
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = String.Empty;

            /*if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }*/

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " lacs ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                String[] unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                String[] tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

    }
}
