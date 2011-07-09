using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;

namespace Asquell.Parser
{
    public class ParsedCommand
    {
        private string _name;
        private List<AsquellObj> _args;
        public ParsedCommand(string name, List<string> args, int rowNum)
        {
            _name = name;
            _args = new List<AsquellObj>(args.Count);
            for (int i = 0; i < args.Count; i++)
            {
                _args.Add(new AsquellObj(args[i]));
            }
        }
        public void Evaluate(MemoryBlock memory)
        {
            
        }
    }
}
