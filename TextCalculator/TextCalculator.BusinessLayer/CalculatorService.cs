using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCalculator.BusinessLayer.Helpers;

namespace TextCalculator.BusinessLayer
{

    /// <summary>
    /// This service is for Calculator operations and contains the business logic for the calculator operations
    /// </summary>
    public class CalculatorService
    {

        /// <summary>
        /// instance of the CalculatorHelper to be able to use its methods
        /// </summary>
        CalculatorHelper helper = new CalculatorHelper();



        /// <summary>
        /// Method that returns the sum of the string provided
        /// </summary>
        /// <param name="number"></param>
        /// <returns>string of numbers</returns>
        /// <exception cref="Exception">
        /// InvalidOperationException if the string ends with comma or has negative numbers
        /// ArgumentException if string contains invalid characters
        /// </exception>
        public string Add(string number)
        {
            try
            {
                if (String.IsNullOrEmpty(number))
                {
                    return "0";
                }

                if (!helper.IsDigitsOnly(number))
                {
                    throw new ArgumentException("Not valid input. Please enter numbers separated by comma!");
                }

                if (!char.IsDigit(number.Last()) && number.Last() == ',')
                {
                    throw new InvalidOperationException("Missing number in last position.");
                }

                string negativeNumbers = helper.HasNegativeNumbers(number);
                if (!String.IsNullOrEmpty(negativeNumbers))
                {
                    throw new InvalidOperationException("Negative not allowed :" + negativeNumbers);
                }

                List<int> listOfNumbers = helper.ConvertStringToList(number);
                int result = 0;
                if (listOfNumbers != null && listOfNumbers.Any())
                {
                    foreach (var num in listOfNumbers)
                    {
                        result += num;
                    }
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
