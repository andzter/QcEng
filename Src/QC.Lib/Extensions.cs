using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QC.Lib
{
    public static class Extensions
    {

        public static string ToCurrecyString(this string str, string curr = "")
        {
            if (string.IsNullOrWhiteSpace(str)) return "";
            try
            {
                var amt = $"{curr} {str.ToDecimal().ToString("N")}";
                return amt.TrimStart().TrimEnd();

            }
            catch
            {
                return "";
            }
        }


        public static int ToInt(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            try
            {
                int i = 0;
                int.TryParse(str, out i);
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ToDecimal(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            try
            {
                decimal i = 0;
                decimal.TryParse(str, out i);
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static double ToDbl(this string str)
        {
            try
            {
                double d;
                if (str == null)
                    return 0;
                Double.TryParse(str.ToString(), out d);
                return d;
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return new DateTime(1900, 1, 1);
            try
            {
                DateTime dt;
                DateTime.TryParse(str, out dt);
                return dt;
            }
            catch
            {
                return new DateTime(1900, 1, 1);
            }
        }

        public static DateTime? ToDate(this string str)
        {
            try
            {
                DateTime d = DateTime.Now;
                if (str == null)
                    return null;
                DateTime.TryParse(str, out d);
                return d;
            }
            catch
            {
                return null;
            }
        }

        public static int ToBit(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            try
            {
                int i = 0;
                if (str.Equals(1) || str.ToLower().Equals("true") || str.ToLower().Equals("yes"))
                    i = 1;
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static bool ToBool(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            try
            {
                if (str.Equals("1") || str.ToLower().Equals("true") || str.ToLower().Equals("yes"))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }


        public static string SanitizeXMLString(this string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            return str.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("\'", "&apos;").Replace("&", "&amp;");
        }

        public static string SanitizeSQL(this string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            return str.Replace("\"", "\"\"");
        }


        private static string ones(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            string name = string.Empty;
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static string tens(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            string name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }


        public static string ConvertToWords(this string numb, string endstr = "")
        {
            string val = "", wholeNo = numb, points , pointStr = "";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        pointStr = ConvertWholeNumber(points);
                    }
                }
                val = $"{ConvertWholeNumber(wholeNo).Trim()} Pesos and {pointStr} Centavos {endstr}";
            }
            catch { }
            return val.Trim();
        }

        private static string ConvertWholeNumber(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping    
                    string place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        private static string ConvertDecimals(string number)
        {
            string cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }
    }


    public static class DataExtension
    {

        public static DataTable ListToDataTable<T>(this IList<T> data, string tableName)
        {
            DataTable table = new DataTable(tableName);

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch  
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public static List<T> ToList2<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                DataNamesMapper<T> mapper = new DataNamesMapper<T>();
                List<T> list = mapper.Map(table).ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }

        public static T ToObject<T>(this DataTable table) where T : class, new()
        {
            try
            {
                DataNamesMapper<T> mapper = new DataNamesMapper<T>();
                List<T> list = mapper.Map(table).ToList();
                if (list.Count > 0)
                    return list[0];
                return null;
            }
            catch
            {
                return null;
            }
        }



        public static void Filter(this DataTable dt, string filter)
        {
            dt.DefaultView.RowFilter = filter;
        }


        public static DataTable SetColumnsOrder(this DataTable table, string[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                if (table.Columns.Contains(columnName))
                {
                    table.Columns[columnName].SetOrdinal(columnIndex);
                    columnIndex++;
                }
            }
            return table;
        }
    }

}
