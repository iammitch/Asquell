using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Parser;
using Asquell.Objects;

namespace Asquell
{
    class Asquell
    {
        private string[] _script;
        private MemoryBlock _memory;
        private ReflectedCommands _reflected;
        private List<ParsedCommand> _commands = null;
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
        public void Parse()
        {
            _commands = CodeParser.ParseScript(_script);
        }
        public void Run()
        {
            if (_commands == null)
                Parse();

            _memory = new MemoryBlock();
            _reflected = new ReflectedCommands();

            _reflected.Embed(typeof(Invokables.MemoryAccess));

            for (int i = 0; i < _commands.Count; i++)
            {
                _commands[i].Evaluate(_memory,_reflected);
            }
        }
    }
}
