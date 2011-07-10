using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;

namespace Asquell.Parser
{
    public class ParsedCommand
    {
        private string _class;
        private string _method;
        private List<AsquellObj> _args;
        public ParsedCommand(string name, List<string> args, int rowNum)
        {
            int classMethodSep = name.IndexOf('.');
            if (classMethodSep==-1)
            {
                _class = "Global";
                _method = name;
            }
            else
            {
                _class = name.Substring(0, classMethodSep);
                _method = name.Substring(classMethodSep+1);
            }

            _args = new List<AsquellObj>(args.Count);
            for (int i = 0; i < args.Count; i++)
            {
                _args.Add(new AsquellObj(args[i]));
            }
        }
        public void Evaluate(MemoryBlock memory,ReflectedCommands reflect)
        {
            reflect.CallReflection(_class, _method, memory, _args.ToArray());
        }
        public override string ToString()
        {
            return _class + "." + _method + "("+_args.Count+" Args)";
        }
    }
}
