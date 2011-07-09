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
                string embedName = type.Name;
                AsquellClass[] attr = (AsquellClass[])type.GetCustomAttributes(typeof(AsquellClass),true);
                
                if (attr.Length == 1 && attr[0].AccessibleName != null)
                    embedName = attr[0].AccessibleName;

                _opToClass[embedName] = new ReflectedClass(type);
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
