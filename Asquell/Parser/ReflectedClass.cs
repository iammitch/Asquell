using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;
using System.Reflection;

namespace Asquell.Parser
{
    public class ReflectedClass
    {
        private Type _type;
        private Dictionary<string,MethodInfo> _usableMethods;
        public ReflectedClass(Type type)
        {
            _type = type;
            _usableMethods = new Dictionary<string, MethodInfo>();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
            ParameterInfo[] pinfo;
            bool allowedMethod;
            for (int i = 0; i < methods.Length; i++)
            {
                allowedMethod = true;
                pinfo = methods[i].GetParameters();
                for (int i2 = 0; i2 < pinfo.Length; i2++)
                {
                    if (pinfo[i2].IsOut||pinfo[i2].ParameterType != typeof(AsquellObj))
                    {
                        allowedMethod = false; break;
                    }
                }
                if (allowedMethod)
                    _usableMethods.Add(methods[i].Name,methods[i]);
            }
        }
        public bool DoReflection(string name, AsquellObj[] args)
        {
            if (_usableMethods.ContainsKey(name))
            {
                _usableMethods[name].Invoke(null, args);
                return true;
            }
            return false;
        }
    }
}
