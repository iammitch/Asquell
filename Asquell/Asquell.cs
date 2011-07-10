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
            _memory = new MemoryBlock();
            _reflected = new ReflectedCommands();
            //Default Embedded Types
            _reflected.Embed(typeof(Invokables.MemoryAccess));
            _reflected.Embed(typeof(Invokables.MathCore));
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
        public void Embed(Type type)
        {
            _reflected.Embed(type);
        }
        public void Parse()
        {
            _commands = CodeParser.ParseScript(_script);
        }
        public void Run()
        {
            if (_commands == null)
                Parse();

            for (int i = 0; i < _commands.Count; i++)
            {
                RunLine(i);
            }
        }
        public void RunLine(int lineNo)
        {
            if (_commands == null)
                Parse();

            _commands[lineNo].Evaluate(_memory, _reflected);
        }
        public Dictionary<string,AsquellObj> MemorySnapshot()
        {
            return _memory.GlobalMemory;
        }
    }
}
