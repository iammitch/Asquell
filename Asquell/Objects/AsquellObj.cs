using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asquell.Objects
{
    public enum AsquellObjectType
    {
        Undefined = 0,
        Null = 1,
        String = 2,
        Number = 3,
        Boolean = 4,
        Generic = 5,
        RunTimeValue = 6,
        Invalid = 99
    }
    public class AsquellObj
    {
        private AsquellObjectType type = AsquellObjectType.Undefined;
        private string rawValue;
        private string parseValue; //Mainly for strings where % was changed
        public AsquellObj(string rawValue)
        {
            this.rawValue = rawValue;
            this.parseValue = rawValue;
            defineType();
        }
        private void defineType()
        {
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
                    if (tmp == '"' || tmp == '\'')
                    {
                        if (tmp == inString)
                        {
                            inString = ' ';
                        }
                        else if (inString == ' ')
                        {
                            inString = tmp;
                            stringStart = i;

                            int endIndex = rawValue.IndexOf(inString, stringStart + 1);
                            if (endIndex == -1)
                            { type = AsquellObjectType.Invalid; return; }

                            string nonChecked = rawValue.Substring(stringStart, endIndex - stringStart);
                            string checkedStr = nonChecked.Replace("%PERCENT", "%").Replace("%COMMA", ",");

                            parseValue = rawValue.Replace(nonChecked, checkedStr);

                            i = endIndex;
                            if (i + 1 != rawValue.Length)
                            { type = AsquellObjectType.Invalid; return; }

                        }
                    }
                }
            }
            
        }
    }
}
