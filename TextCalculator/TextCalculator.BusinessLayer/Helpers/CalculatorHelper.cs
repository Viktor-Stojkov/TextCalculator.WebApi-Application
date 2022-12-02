using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.BusinessLayer.Helpers
{
    /// <summary>
    /// This class serves as a helper for calculation operations
    /// </summary>
    public class CalculatorHelper
    {

        /// <summary>
        /// This method gets a string of numbers as an argument and converts the string to list of integers.
        /// It is used for easier manipulation with the string data 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>List of integers, if the received string is empty, it returns null</returns>
        public List<int> ConvertStringToList(string numbers) 
        {
            List<int> numList = null;
            if (!String.IsNullOrEmpty(numbers))
            {
                numList = new List<int>();
                string[] numbersArray = numbers.Trim().Split(',');
                for(var i = 0; i < numbersArray.Length; i++)
                {
                    numList.Add(Convert.ToInt32(numbersArray[i]));
                }
            }
            return numList;
        }


        /// <summary>
        /// This method checks if the string of numbers contains negative values. 
        /// If yes, it return the values separated by comma, otherwise, it returns empty string.
        /// If empty string is returned, it means that the string of numbers DOES NOT contain negative numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>comma-separated string or empty string if no negative values</returns>
        public string HasNegativeNumbers(string numbers)
        {
            List<int> list = ConvertStringToList(numbers);
            string result = "";
            List<string> negativeNumbers = new List<string>();
            foreach(var item in list)
            {
                if (item < 0)
                {
                    negativeNumbers.Add(item.ToString());                    
                }
            }
            result = string.Join(",", negativeNumbers.ToArray());

            return result;
        }

        /// <summary>
        /// Method that checks if the string is only with digits
        /// </summary>
        /// <param name="numbers">true if only digits, false if other characters present</param>
        /// <returns></returns>
        public bool IsDigitsOnly(string numbers)
        {
            if(String.IsNullOrEmpty(numbers)) return false;

            return numbers.Split(",").All(x => int.TryParse(x, out _));
        }
    }
}
