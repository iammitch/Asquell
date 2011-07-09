using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Invokables;
using System.Reflection;
using Asquell.Objects;

namespace Asquell.Parser
{
    public class ReflectedCommands
    {
        private Dictionary<string, ReflectedClass> _opToClass;
        public ReflectedCommands()
        {
            _opToClass = new Dictionary<string, ReflectedClass>();
        }
        public bool Embed(Type type)
        {
            bool success = false;
            if (!_opToClass.ContainsKey(type.Name)&&type.IsClass&&type.IsPublic)
            {
                _opToClass[type.Name] = new ReflectedClass(type);
            }
            return success;
        }
        public bool CallReflection(string embedName, string methodName, params AsquellObj[] args)
        {
            if (_opToClass.ContainsKey(embedName))
            {
                _opToClass[embedName].DoReflection(methodName, args);
                return true;
            }
            return false;
        }
    }
}
