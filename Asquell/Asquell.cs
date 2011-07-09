using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Parser;

namespace Asquell
{
    class Asquell
    {
        private string[] _script;
        private MemoryBlock _memory;
        public Asquell(string[] script)
        {
            _script = script;
        }
        //TODO: Threading, LINQ/SQL-Like Statements
        /*
         * Possible Operation Types
         * BOOL VarA, CompareString, VarB, StoreResult
         * SCOPE ScopeNameString
         * END_SCOPE ScopeNameString
         * OP VarA, OperationString, VarB, StoreResult
         * EXTERN externNameString, StoreResult, Vars {...}
         * QL ListVar, QueryString
         * 
         */
        public void Run()
        {
            List<ParsedCommand> commands = CodeParser.ParseScript(_script);
            _memory = new MemoryBlock();
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Evaluate(_memory);
            }
        }
    }
}
