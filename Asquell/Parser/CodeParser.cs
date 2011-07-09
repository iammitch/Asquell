using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asquell.Parser
{
    public class CodeParser
    {
        public static List<ParsedCommand> ParseScript(string[] Script)
        {
            List<ParsedCommand> _commands = new List<ParsedCommand>(Script.Length);
            for (int i = 0; i < Script.Length; i++)
            {
                _commands.Add(ParseCommand(Script[i],i+1));
            }
            return _commands;
        }
        private static ParsedCommand ParseCommand(string row,int rowNum)
        {
            if (row == String.Empty) return null;
            row = row.Trim();

            int commandArgSplit = (row.IndexOf(" ") != -1 ? row.IndexOf(" ") : row.Length);

            string command = row.Substring(0, commandArgSplit);
            string argsBeforeSplit = row.Substring(commandArgSplit);
            argsBeforeSplit = argsBeforeSplit.Trim();

            List<string> args;

            char tmp;
            char inString = ' ';
            int stringStart = 0;
            string final;

            for (int i = 0; i < argsBeforeSplit.Length; i++)
            {
                tmp = argsBeforeSplit[i];
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

                        int endIndex = argsBeforeSplit.IndexOf(inString, stringStart + 1);
                        if (endIndex==-1)
                            break;
                        string nonChecked = argsBeforeSplit.Substring(stringStart, endIndex - stringStart);

                        string checkedStr = nonChecked.Replace("%", "%PERCENT").Replace(",", "%COMMA");

                        final = argsBeforeSplit.Replace(nonChecked, checkedStr);

                        i = endIndex;
                        continue;
                    }
                }
            }

            args = argsBeforeSplit.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            return new ParsedCommand(command, args, rowNum);
        }
    }
}
