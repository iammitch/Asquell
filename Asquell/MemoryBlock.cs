using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asquell.Objects;

namespace Asquell
{
    public class MemoryBlock
    {
        private Dictionary<string, AsquellObj> _globals;
        private Dictionary<string, MemoryBlock> _scoped;
        public MemoryBlock()
        {
            _globals = new Dictionary<string, AsquellObj>();
            _scoped = new Dictionary<string, MemoryBlock>();
        }
        public void ModifyVariable(string name, AsquellObj value)
        {
            _globals[name] = value;
        }
        public void ModifyVariable(AsquellObj name, AsquellObj value)
        {
            if (name.Type == AsquellObjectType.RunTimeValue)
                ModifyVariable(name.Value.ToString(), value);
            else
                throw new ArgumentException("Can not write to memory value where name is type '"+name.Type.ToString()+"'!");
        }
        public AsquellObj GetVariable(string name)
        {
            if (!_globals.ContainsKey(name))
                throw new KeyNotFoundException("Can not read from memory where name is '" + name + "'! Does not exist in current memory context!");
            return (_globals.ContainsKey(name) ? _globals[name] : null);
        }
        public AsquellObj GetVariable(AsquellObj name)
        {
            if (name.Type == AsquellObjectType.RunTimeValue)
                return GetVariable(name.Value.ToString());
            else
                throw new ArgumentException("Can not read from memory value where name is type '" + name.Type.ToString() + "'!");
        }
        public AsquellObj GetRealVariable(AsquellObj name)
        {
            AsquellObj tmp = name;
            AsquellObj last;
            while (true)
            {
                last = tmp;
                tmp = GetVariable(name);
                if (tmp != null || tmp.Type != AsquellObjectType.RunTimeValue)
                    break;
            }
            return last;
        }
        public void DeleteVariable(string name)
        {
            if (_globals.ContainsKey(name))
                _globals.Remove(name);
            else
                throw new KeyNotFoundException("Can not delete from memory where name is '" + name + "'! Does not exist in current memory context!");
        }
        public void DeleteVariable(AsquellObj name)
        {
            if (name.Type == AsquellObjectType.RunTimeValue)
                DeleteVariable(name.Value.ToString());
            else
                throw new ArgumentException("Can not delete from memory value where name is type '" + name.Type.ToString() + "'!");
        }
        public bool VariableInMemory(string name)
        {
            return _globals.ContainsKey(name);
        }
        public bool VariableInMemory(AsquellObj name)
        {
            if (name.Type == AsquellObjectType.RunTimeValue)
                return VariableInMemory(name.Value.ToString());
            else
                throw new ArgumentException("Can not read from memory value where name is type '" + name.Type.ToString() + "'!");
        }
        public bool CreateScope(string scope)
        {
            if (_scoped.ContainsKey(scope))
                return false;

            _scoped[scope] = new MemoryBlock();

            return true;
        }
        public MemoryBlock GetScope(string scope)
        {
            return (_scoped.ContainsKey(scope) ? _scoped[scope] : null);
        }
    }
}
