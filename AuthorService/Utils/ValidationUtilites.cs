using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class ValidationUtilites
    {
        //public static bool LegalId(string s)
        //{
        //    int x;
        //    if (!int.TryParse(s, out x))
        //        return false;
        //    if (s.Length < 5 || s.Length > 9)
        //        return false;
        //    for (int i = s.Length; i < 9; i++)
        //        s = "0" + s;
        //    int sum = 0;
        //    for (int i = 0; i < 9; i++)
        //    {
        //        char c = s[i]; ;
        //        int k = ((i % 2) + 1) * (c - '0');
        //        if (k > 9)
        //            k -= 9;
        //        sum += k;

        //    }
        //    return sum % 10 == 0;
        //}
        public static bool IsCreditNum(string creditNum)
        {
            if (creditNum.Length != 16)
                return false;
            return true;
        }

        public static bool IsCreditDate(string creditDate)
        {
            DateTime dt = DateTime.Now;
            int year = dt.Year;
            int month = dt.Month;

            if (Convert.ToInt32(creditDate.Substring(3, 4)) < year)
                return false;
            return true;
        }
        public static bool IsAtAge(DateTime birthDay)//בדיקה האם מעל גיל 13
        {
            DateTime birthDate = birthDay;
            DateTime toDayDate = DateTime.Now;
            if (toDayDate.Year - birthDate.Year < 13)
                return false;
            return true;
        }
        public static bool IsLegalPhonNum(string word)//בדיקה אם מספר טלפון חוקי אורך 7 ורק ספרות 
        {
            foreach (char c in word)
                if (!(IsDigits(c)) || (!(word.Length == 7)))
                    return false;
            return true;
        }
        public static bool IsLegalAdd(string word)// בדיקת חוקיות כתובת
        {
            foreach (char c in (word))
                if (IsHebrewLetter(c) == false && IsDigits(c) == false && c != ' ')
                    return false;
            return true;
        }
        public static string SubPhone(string phone)// הפרדת הקידומת ממספר הטלפון הכללי
        {
            string sub;
            string c = phone.Substring(2, 1);// התו השלישי במחרוזת של המספר
            if (c == "-")  // אם התו השלישי הוא מקף אז הקידומת היא של שתי ספרות
            {
                sub = phone.Substring(0, 2);
                return sub;
            }
            else  //אחרת הקידומת היא של 3 ספרות
            {

                sub = phone.Substring(0, 3);
                return sub;

            }

        }
        public static string PhoneNum(string phone) // החזרת מספר הטלפון ללא קידומת
        {

            string c = phone.Substring(2, 1);
            if (c == "-")
            {
                string phoneNoSub = phone.Substring(3);
                return phoneNoSub;
            }
            else
            {
                string phoneNoSub = phone.Substring(4);
                return phoneNoSub;
            }
        }
        public static bool PhoneNumber(string num)
        {
            string pattern = @"\b0[2-4 7-9]-[2-9]\d{6}";
            Regex r = new Regex(pattern);
            return r.IsMatch(num);
        }
        public static bool LegalName(string name)
        {
            string pattern = @"\b[א-ת- ]+";
            Regex r = new Regex(pattern);
            return r.IsMatch(name);
        }
        public static int GetAge(DateTime d)
        {
            DateTime t = DateTime.Today;
            int age = t.Year - d.Year;
            if (t < d.AddYears(age)) age--;
            return age;
        }


        /// ///////////////////////////////////
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool GreaterThanZero(int num)
        {
            return num > 0;
        }

        public static bool IsHebrewLetter(char c)
        {
            string otiyot = "'אבגדהוזחטיכלמנסעפצקרשתךםןףץ";
            if (otiyot.IndexOf(c) == -1)
                return false;
            return true;
        }

        public static bool IsEnglishLetter(char c)
        {
            string otiyot = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'";
            if (otiyot.IndexOf(c) == -1)
                return false;
            return true;
        }

        public static bool IsDigits(char c)
        {
            string digits = "0123456789";
            if (digits.IndexOf(c) == -1)
                return false;
            return true;
        }
        public static bool isId(string s)
        {
            foreach (char c in s)
            {
                if (!IsDigits(c))
                {
                    return false;
                }
            }
            return true;
        }


        public static bool IsNumberQuantity(string word)
        {
            if (word.Contains('-'))
            { return false; }
            foreach (char c in word)
                if (IsDigits(c) == false)
                    return false;
            return true;
        }
        public static bool IsLegalItemName(string word)
        {
            foreach (char c in word)
                if (IsDigits(c) == false && IsHebrewLetter(c) == false && c != '-' && c != ' ' && IsEnglishLetter(c) == false)
                    return false;
            return true;
        }

        public static bool IsLegalName(string word)
        {
            String a = Regex.Replace(word, @"\s", "");
            foreach (char c in a)
                if (IsHebrewLetter(c) == false && IsEnglishLetter(c) == false && c != '-')

                    return false;
            return true;
        }

        public static bool IsLegalCity(string word)
        {
            foreach (char c in word)
                if (IsHebrewLetter(c) == false && IsEnglishLetter(c) == false && c != '-' && c != ' ')
                    return false;
            return true;
        }
        public static bool IsLegalIdNum(string word)//בדיקת מספר פריט חוקי
        {
            foreach (char c in word)
                if (!(IsDigits(c)) && (!(word.Length == 9)))
                    return false;
            return true;
        }
        public static bool IsLegalId(string id)
        {
            string word = id;
            if (word.Length != 9)
                return false;
            foreach (char c in word)
                if (IsDigits(c) == false)
                    return false;
            return true;
        }
        public static bool IsLegalDigit(string dig)
        {
            string digit = dig;
            foreach (char c in digit)
                if (digit.IndexOf(c) == -1)
                    return false;
            return true;
        }
        public static bool IsLegalZipcode(string zip)
        {
            string zipcode = zip;
            if (zipcode.Length != 5)
                return false;
            foreach (char c in zipcode)
                if (IsDigits(c) == false)
                    return false;
            return true;
        }
        public static bool IsLegalPrice(String zip)
        {
            String arr = "0123456789";
            foreach (char c in zip)
            {
                if (!(c == '.' || arr.Contains(c)))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsLegalSupplierCode(String zip)
        {
            String arr = "0123456789";
            foreach (char c in zip)
            {
                if (!(arr.Contains(c) && zip.Length == 3))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsLegalCNumberVisa(string cnum)
        {
            string creditnumber = cnum;
            if (creditnumber.Length != 16)
                return false;
            foreach (char c in creditnumber)
                if (IsDigits(c) == false)
                    return false;
            return true;
        }
        public static bool IsLegalCNumberAmericanexpress(string cnum)
        {
            string creditnumber = cnum;
            if (creditnumber.Length != 15)
                return false;
            foreach (char c in creditnumber)
                if (IsDigits(c) == false)
                    return false;
            return true;
        }
        public static bool IsLegalThreeDig(string tdig)
        {
            string threedig = tdig;
            if (threedig.Length != 3)
                return false;
            foreach (char c in threedig)
                if (IsDigits(c) == false)
                    return false;
            return true;
        }
        public static bool checkphonenumber(int n)
        {
            if (n < 0)
            {
                return false;
            }
            int num = n, c = 0;
            while (num > 0)
            {
                c++;
                if (num % 10 < 0 || num % 10 > 9)
                {
                    return false;
                }
                num /= 0;
            }
            if (c != 10)
            { return false; }
            return true;
        }
        // בדוגמאות שלנו יש כל מספר טלפון מתחיל ב 05 וזה היה שימוש
        /*מספרי טלפון תקיני:
  "+123-456-7890"
  "+1 (123) 456-7890"
  "123-456-7890"
  מספרי טלפון לא תקינים:
  "123-456-789" (קצר מדי)
  "+123-456-789-123456" (ארוך מדי)
  "123.456.7890" (משתמש בתווים לא תקינים)
  "abc-456-7890" (מכיל תווים שאינם מספרים)
  "123 456 7890" (לא מכיל תווי חיבור או סימן +)*/

        public static bool myCheckPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false; // Handle empty strings
            }

            // Allow for different separators, international numbers (+ sign), and whitespace
            string validChars = "0123456789 +-()";
            phoneNumber = phoneNumber.Replace(" ", ""); // Remove spaces

            // Check length based on presence of country code
            if (phoneNumber.StartsWith("+"))
            {
                if (phoneNumber.Length < 12 || phoneNumber.Length > 14) // +XXX-XXX-XXXX or +XXXX-XXX-XXXX
                {
                    return false;
                }
            }
            else
            {
                if (phoneNumber.Length != 10) // XXX-XXX-XXXX
                {
                    return false;
                }
            }

            // Check if all characters are valid
            foreach (char c in phoneNumber)
            {
                if (!validChars.Contains(c))
                {
                    return false;
                }
            }



            return true;
        }



        public static bool IsLegalItemId(string id)
        {
            string word = id;
            if (word.Length != 5)
                return false;
            foreach (char c in word)
                if (IsDigits(c) == false)
                    return false;
            return true;
        }

        public static bool IsEmailValid(string email)
        {
            bool b = false;
            if (email == null)
            {
                return false;
            }
            // Define a regular expression pattern for a basic email format
            string pattern = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";

            // Use Regex.IsMatch to check if the email matches the pattern
            try
            {
                b = Regex.IsMatch(email, pattern);

            }
            catch (Exception)
            {
                return false;
            }
            return b;
        }
        public static DateTime FromBirthdateFormat(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException("Invalid date format. Expected format is dd-MM-yyyy.", ex);
            }
        }
   public static string ToBirthdateFormat(DateTime date)
    {
        return date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
    }
        internal static bool IsOnlyDigits(string p)
        {
            throw new NotImplementedException();
        }
    }
}
