using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace Asquell.Objects
{
    public enum AsquellObjectType
    {
        Null = 0,
        String = 1,
        Number = 2,
        Boolean = 3,
        RunTimeValue = 4,
        MathsOperator = 5,
        BooleanOperator = 6,
        Array = 7,
        Invalid = 99
    }
    public class AsquellObj
    {
        private AsquellObjectType type = AsquellObjectType.Invalid;
        private string rawValue;
        private object parseValue = null;
        public AsquellObj(string rawValue)
        {
            this.rawValue = rawValue;
            defineType();
        }
        public AsquellObj(object obj)
        {
            if (obj == null)
            {
                this.type = AsquellObjectType.Null;
                return;
            }
            Type t = obj.GetType();
            if (t == typeof(double))
            {
                this.parseValue = obj;
                this.type = AsquellObjectType.Number;
            }
            else if (t == typeof(bool))
            {
                this.parseValue = obj;
                this.type = AsquellObjectType.Boolean;
            }
            else if (t == typeof(string))
            {
                this.rawValue = obj.ToString();
                defineType();
            }
            else if (t == typeof(AsquellObj[]))
            {
                this.parseValue = obj;
                this.type = AsquellObjectType.Array;
            }
        }
        private int findStringEnd(string str, int start, char stringChar)
        {
            int end = -1;
            while (true)
            {
                if (start + 1 >= str.Length) return -1;
                end = str.IndexOf(stringChar, start + 1);
                if (end == -1)
                    return -1;
                else if (str[end - 1] == '\\')
                    continue;
                else
                    return end;
            }
        }
        public static bool AllowedVariableName(string name)
        {
            Regex reg = new Regex("^[a-zA-Z0-9]+$");
            return reg.IsMatch(name);
        }
        private void defineType()
        {
            #region Type String-like

            int isString = rawValue.IndexOfAny(new char[] { '\'', '"' });
            if (isString!=-1)
            {
                if (isString != 0)
                {
                    //Contains invalid characters - No name of variable can have " or ' in it
                    type = AsquellObjectType.Invalid;
                    return;
                }
                char tmp;
                char inString = ' ';
                int stringStart = 0;

                for (int i = 0; i < rawValue.Length; i++)
                {
                    tmp = rawValue[i];
                    if ((tmp == '"' || tmp == '\''))
                    {
                        if (i >= 1 && rawValue[i-1] == '\\')
                            continue;
                        if (tmp == inString)
                        {
                            inString = ' ';
                        }
                        else if (inString == ' ')
                        {
                            inString = tmp;
                            stringStart = i;

                            int endIndex = findStringEnd(rawValue, stringStart, inString);

                            if (endIndex == -1)
                            { type = AsquellObjectType.Invalid; return; }

                            string nonChecked = rawValue.Substring(stringStart, endIndex - stringStart);
                            string checkedStr = nonChecked.Replace("%PERCENT", "%").Replace("%COMMA", ",");

                            parseValue = rawValue.Replace(nonChecked, checkedStr);

                            i = endIndex;
                            if (i + 1 != rawValue.Length)
                            { type = AsquellObjectType.Invalid; return; }

                            type = AsquellObjectType.String;
                        }
                    }
                }
            }

            #endregion

            #region Type Numeric

            double numericValue;
            if (double.TryParse(rawValue,out numericValue))
            {
                parseValue = numericValue;
                type = AsquellObjectType.Number;
                return;
            }

            #endregion

            #region Type Boolean

            bool booleanValue;
            if (bool.TryParse(rawValue, out booleanValue))
            {
                parseValue = booleanValue;
                type = AsquellObjectType.Boolean;
                return;
            }

            #endregion

            #region Type Null

            if (rawValue == "NULL")
            {
                type = AsquellObjectType.Null;
                parseValue = null;
                return;
            }

            #endregion

            #region Type Maths Operators
            
            if (rawValue.IndexOfAny(new char[] { '+', '-', '*', '/', '%', '^'})==0&&rawValue.Length==1)
            {
                type = AsquellObjectType.MathsOperator;
                parseValue = rawValue;
                return;
            }
            
            #endregion

            #region Type Boolean Operators

            if ((rawValue.IndexOfAny(new char[] { '>', '<' }) == 0 && rawValue.Length == 1) ||
                ((rawValue.IndexOf("<=") == 0 || rawValue.IndexOf("<=") == 0 ||
                    rawValue.IndexOf("==") == 0 || rawValue.IndexOf("!=") == 0) && rawValue.Length == 2))
            {
                type = AsquellObjectType.BooleanOperator;
                parseValue = rawValue;
            }
            
            #endregion

            #region Type Runtime Value

            if (AllowedVariableName(rawValue))
            {
                type = AsquellObjectType.RunTimeValue;
                parseValue = rawValue;
            }

            #endregion
        }
        public object Value
        {
            get { return parseValue; }
        }
        public AsquellObjectType Type
        {
            get { return type; }
        }
    }
}
