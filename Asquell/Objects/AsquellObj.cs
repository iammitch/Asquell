﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        Invalid = 99
    }
    public class AsquellObj
    {
        private AsquellObjectType type = AsquellObjectType.Invalid;
        private string rawValue;
        private object parseValue;
        public AsquellObj(string rawValue)
        {
            this.rawValue = rawValue;
            defineType();
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

            if (!rawValue.Contains(' '))
            {
                type = AsquellObjectType.RunTimeValue;
            }

            #endregion
        }
    }
}
