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
        private List<ReflectedClass> _globalMethods;
        public ReflectedCommands()
        {
            _opToClass = new Dictionary<string, ReflectedClass>();
            _globalMethods = new List<ReflectedClass>();
        }
        public bool Embed(Type type)
        {
            bool success = false;
            if (type.IsClass&&type.IsPublic)
            {
                string embedName = type.Name;
                AsquellClass attr = getClassAttributes(type);

                if (attr!=null)
                {
                    if (attr.AccessibleName != null)
                        embedName = attr.AccessibleName;
                    else
                    {
                        return embedToGlobal(type);
                    }

                    if (!_opToClass.ContainsKey(embedName))
                    {
                        _opToClass[embedName] = new ReflectedClass(type);
                        success = true;
                    }
                }
            }
            return success;
        }

        private bool embedToGlobal(Type type)
        {
            if (!isClassEmbedded(type))
            {
                ReflectedClass reflected = new ReflectedClass(type);
                for (int i = 0; i < _globalMethods.Count; i++)
                {
                    if (_globalMethods[i].ContainsMatchingMethods(reflected))
                    {
                        throw new AmbiguousMatchException("Global Methods already contain a method with the same name!");
                    }
                }
                _globalMethods.Add(reflected);
                return true;
            }
            return false;
        }
        public bool CallReflection(string embedName, string methodName, MemoryBlock block, params AsquellObj[] args)
        {
            if (embedName == null)
            {
                for (int i = 0; i < _globalMethods.Count; i++)
                {
                    if (_globalMethods[i].ContainsMethod(methodName))
                        return _globalMethods[i].DoReflection(methodName, args, block);
                }
            }
            else if (_opToClass.ContainsKey(embedName))
            {
                return _opToClass[embedName].DoReflection(methodName, args, block);
            }
            return false;
        }
        private AsquellClass getClassAttributes(Type type)
        {
            AsquellClass[] attr = (AsquellClass[])type.GetCustomAttributes(typeof(AsquellClass), true);
            if (attr != null && attr.Length == 1)
                return attr[0];
            return null;
        }
        private bool isClassEmbedded(Type type)
        {
            for (int i = 0; i < _globalMethods.Count; i++)
            {
                if (_globalMethods[i].IsType(type))
                    return true;
            }
            return false;
        }
    }
}
