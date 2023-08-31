using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace FML
{
    public static class Utilities
    {
        public static string _sConString = ConfigurationSettings.AppSettings["strcon"];

        public static string _system_name = "-";
        public static string HMI_INITIATE = "";
        public static string fml_id = "-";
        public static string fml_date = "";
        public static string NEW_MCS = "";
        public static string OLD_MCS = "";
        public static string usertype = "";
        public static string InvoiceNo = "";

        public static string _pUser_name;
        public static int chart_fml_count = 0;
        public static int cnt = 0;

        public static int DSAuthenticationCount = 0;
        public static void LogErrors(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            string path = AppDomain.CurrentDomain.BaseDirectory + "LogError.txt";
            // flush every 20 seconds as you do it

            sb.AppendLine();
            sb.Append("Log Time: " + DateTime.Now);
            sb.AppendLine();
            sb.Append("--------------------------------------------------");
            sb.AppendLine();
            if (ex != null)
            {
                sb.Append("Exception: " + ex.ToString());
                if (ex.InnerException != null)
                {
                    sb.Append("Inner Exception: " + ex.InnerException.ToString());
                }
            }
            sb.AppendLine();
            sb.Append("--------------------------------------------------");
            sb.AppendLine();

            File.AppendAllText(path, sb.ToString());
            sb.Clear();
        }
        public static bool executeNonQuery(string _sCommandText)
        {
            bool _bResult = false;
            SqlConnection _objCon = new SqlConnection(_sConString);
            SqlCommand _objCmd = new SqlCommand();
            try
            {
                if (_objCon.State == System.Data.ConnectionState.Closed) _objCon.Open();
                _objCmd.Connection = _objCon;
                _objCmd.CommandText = _sCommandText;
                _bResult = Convert.ToBoolean(_objCmd.ExecuteNonQuery());
            }
            catch (Exception ex) { LogErrors(ex); }
            finally
            {
                if (_objCon.State == System.Data.ConnectionState.Open) _objCon.Close();
            }
            return _bResult;
        }
        public static int executeUNonQuery(string _sCommandText)
        {
            int _bResult = 0;
            SqlConnection _objCon = new SqlConnection(_sConString);
            SqlCommand _objCmd = new SqlCommand();
            try
            {
                if (_objCon.State == System.Data.ConnectionState.Closed) _objCon.Open();
                _objCmd.Connection = _objCon;
                _objCmd.CommandText = _sCommandText;
                _bResult = Convert.ToInt32(_objCmd.ExecuteNonQuery());

             //  _objCmd.CommandText = "Select @@Rowcount";
            }
            catch { }
            finally
            {
                if (_objCon.State == System.Data.ConnectionState.Open) _objCon.Close();
            }
            return _bResult;
        }
        
        public static SqlDataReader executeQuery(string _sCommandText)
        {
            SqlDataReader rdr1 = null;
            SqlConnection _objCon = new SqlConnection(_sConString);
            SqlCommand _objCmd = new SqlCommand();
            try
            {
                if (_objCon.State == System.Data.ConnectionState.Closed) _objCon.Open();
                _objCmd.Connection = _objCon;
                _objCmd.CommandText = _sCommandText;
                
                rdr1 = _objCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch { }
            finally { }
            return rdr1;
        }



        //--------------------------------------------------------------------CURRENCY CONVERTER-------------------------
        public static string AmountInWords(decimal Num)
        {
            string returnValue;
            //I have created this function for converting amount in indian rupees (INR).
            //You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.


            string strNum;
            string strNumDec;
            string StrWord;
            strNum = Num.ToString();


            if (strNum.IndexOf(".") + 1 != 0)
            {
                strNumDec = strNum.Substring(strNum.IndexOf(".") + 2 - 1);


                if (strNumDec.Length == 1)
                {
                    strNumDec = strNumDec + "0";
                }
                if (strNumDec.Length > 2)
                {
                    strNumDec = strNumDec.Substring(0, 2);
                }


                strNum = strNum.Substring(0, strNum.IndexOf(".") + 0);
                StrWord = (NumToWord((decimal)(double.Parse(strNum)))) + ((double.Parse(strNumDec) > 0) ? (" Rupees and " + cWord3((decimal)(double.Parse(strNumDec))) + " Paise") : "");//(double.Parse(strNum) == 1) ? " Rupee " : " Rupees ") +
            }
            else
            {
                StrWord = NumToWord((decimal)(double.Parse(strNum))) + " Rupees";//((double.Parse(strNum) == 1) ? " Rupee " : " Rupees ") +
            }
            returnValue = StrWord + " Only";
            return returnValue;
        }

        /// <summary>
        /// Put a string between double quotes.
        /// </summary>
        /// <param name="value">Value to be put between double quotes ex: foo</param>
        /// <returns>double quoted string ex: "foo"</returns>
        public static string AddDoubleQuotes(this string value)
        {
            return "\"" + value + "\"";
        }
        static public string NumToWord(decimal Num)
        {
            string returnValue;


            //I divided this function in two part.
            //1. Three or less digit number.
            //2. more than three digit number.
            string strNum;
            string StrWord;
            strNum = Num.ToString();


            if (strNum.Length <= 3)
            {
                StrWord = cWord3((decimal)(double.Parse(strNum)));
            }
            else
            {
                StrWord = cWordG3((decimal)(double.Parse(strNum.Substring(0, strNum.Length - 3)))) + " " + cWord3((decimal)(double.Parse(strNum.Substring(strNum.Length - 2 - 1))));
            }
            returnValue = StrWord;
            return returnValue;
        }
        static public string cWordG3(decimal Num)
        {
            string returnValue;
            //2. more than three digit number.
            string strNum = "";
            string StrWord = "";
            string readNum = "";
            strNum = Num.ToString();
            if (strNum.Length % 2 != 0)
            {
                readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 1)));
                if (readNum != "0")
                {
                    StrWord = retWord(decimal.Parse(readNum));
                    readNum = System.Convert.ToString(double.Parse("1" + strReplicate("0", strNum.Length - 1) + "000"));
                    StrWord = StrWord + " " + retWord(decimal.Parse(readNum));
                }
                strNum = strNum.Substring(1);
            }
            while (!System.Convert.ToBoolean(strNum.Length == 0))
            {
                readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 2)));
                if (readNum != "0")
                {
                    StrWord = StrWord + " " + cWord3(decimal.Parse(readNum));
                    readNum = System.Convert.ToString(double.Parse("1" + strReplicate("0", strNum.Length - 2) + "000"));
                    StrWord = StrWord + " " + retWord(decimal.Parse(readNum));
                }
                strNum = strNum.Substring(2);
            }
            returnValue = StrWord;
            return returnValue;
        }
        static public string cWord3(decimal Num)
        {
            string returnValue;
            //1. Three or less digit number.
            string strNum = "";
            string StrWord = "";
            string readNum = "";
            if (Num < 0)
            {
                Num = Num * -1;
            }
            strNum = Num.ToString();


            if (strNum.Length == 3)
            {
                readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 1)));
                StrWord = retWord(decimal.Parse(readNum)) + " Hundred";
                strNum = strNum.Substring(1, strNum.Length - 1);
            }


            if (strNum.Length <= 2)
            {
                if (double.Parse(strNum) >= 0 && double.Parse(strNum) <= 20)
                {
                    StrWord = StrWord + " " + retWord((decimal)(double.Parse(strNum)));
                }
                else
                {
                    StrWord = StrWord + " " + retWord((decimal)(System.Convert.ToDouble(strNum.Substring(0, 1) + "0"))) + " " + retWord((decimal)(double.Parse(strNum.Substring(1, 1))));
                }
            }


            strNum = Num.ToString();
            returnValue = StrWord;
            return returnValue;
        }
        static public string retWord(decimal Num)
        {
            string returnValue;
            //This two dimensional array store the primary word convertion of number.
            returnValue = "";
            object[,] ArrWordList = new object[,] { { 0, "" }, { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" }, { 20, "Twenty" }, { 30, "Thirty" }, { 40, "Forty" }, { 50, "Fifty" }, { 60, "Sixty" }, { 70, "Seventy" }, { 80, "Eighty" }, { 90, "Ninety" }, { 100, "Hundred" }, { 1000, "Thousand" }, { 100000, "Lakh" }, { 10000000, "Crore" } };


            int i;
            for (i = 0; i <= (ArrWordList.Length - 1); i++)
            {
                if (Num == System.Convert.ToDecimal(ArrWordList[i, 0]))
                {
                    returnValue = (string)(ArrWordList[i, 1]);
                    break;
                }
            }
            return returnValue;
        }
        static public string strReplicate(string str, int intD)
        {
            string returnValue;
            //This fucntion padded "0" after the number to evaluate hundred, thousand and on....
            //using this function you can replicate any Charactor with given string.
            int i;
            returnValue = "";
            for (i = 1; i <= intD; i++)
            {
                returnValue = returnValue + str;
            }
            return returnValue;
        }

        public static bool findform(string frmname)
        {
            bool _bfound = false;
            try
            {
                FormCollection _fc = Application.OpenForms;
                foreach (Form _f in _fc)
                {
                    // does the form text match our sender 
                    if (_f.Name == frmname)
                    {
                        _f.BringToFront();
                        _bfound = true;
                        break;
                    }
                }
            }
            catch { }
            return _bfound;
        }
      
       
    }
}
