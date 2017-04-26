using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DailyProgrammerEasy
{
    class Code
    {
        //[2017-04-24] Challenge #312 [Easy] L33tspeak Translator
        public string ConvertText(string textToConvert)
        {
            string result = textToConvert;
            bool leet = false;

            Dictionary<string, string> leetDictionary = new Dictionary<string, string>() { { "A", "4" }, { "B", "6" }, { "E", "3" }, { "I", "1" }, { "L", "1" }, { "M", "(V)" }, { "N", "(\\)" }, { "O", "0" }, { "S", "5" }, { "T", "7" }, { "V", "\\/" }, { "W", "`//" } };

            foreach (KeyValuePair<string, string> item in leetDictionary)
            {
                if (result.Contains(item.Value))
                {
                    leet = true;
                    break;
                }
            }

            if (!leet)
            {
                foreach (KeyValuePair<string, string> letter in leetDictionary)
                {
                    result = Regex.Replace(result, letter.Key, letter.Value, RegexOptions.IgnoreCase);
                }
            }
            else
            {
                foreach (KeyValuePair<string, string> letter in leetDictionary)
                {
                    result = Regex.Replace(result, Regex.Escape(letter.Value), letter.Key, RegexOptions.IgnoreCase);
                }
                result = char.ToUpper(result[0]) + result.Substring(1).ToLower();
            }

            return result;
        }
    }
}
