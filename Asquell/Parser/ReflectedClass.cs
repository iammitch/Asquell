using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;
using System.Reflection;

using Asquell.Invokables;

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
            for (int i = 0; i < methods.Length; i++)
            {
                if (paramsMeetAttributes(methods[i]))
                    _usableMethods.Add(getMethodAccessibleName(methods[i]),methods[i]);
            }
        }
        public bool DoReflection(string name, AsquellObj[] args, MemoryBlock block)
        {
            if (_usableMethods.ContainsKey(name))
            {
                MethodInfo m = _usableMethods[name];
                int argCount = args.Length;

                if (getMethodAttr(m).NoMemoryBlock == false)
                    argCount++;

                //Don't want to call a method that will throw a C# error
                if (m.GetParameters().Length!=argCount)
                    return false;

                object[] methodArgs = new object[argCount];
                
                if (args.Length < argCount)
                { methodArgs[0] = block; }

                int argTrueCount = 0;
                for (int i = (args.Length < argCount?1:0); i < methodArgs.Length; i++)
                {
                    methodArgs[i] = args[argTrueCount];
                    argTrueCount++;
                }

                m.Invoke(null, methodArgs);

                return true;
            }
            return false;
        }
        private AsquellMethod getMethodAttr(MethodInfo method)
        {
            AsquellMethod[] attr = (AsquellMethod[])method.GetCustomAttributes(typeof(AsquellMethod), true);
            if (attr.Length == 1)
            {
                return attr[0];
            }
            return null;
        }
        private string getMethodAccessibleName(MethodInfo method)
        {
            AsquellMethod attr = getMethodAttr(method);
            return (attr != null && attr.AccessibleName != null ? attr.AccessibleName : method.Name);
        }
        private bool paramsMeetAttributes(MethodInfo method)
        {
            AsquellMethod attr = getMethodAttr(method);
            if (attr != null && attr.Exposed == true)
            {
                ParameterInfo[] pinfo = method.GetParameters();
                for (int i = 0; i < pinfo.Length; i++)
                {
                    //Passes the MemoryBlock to the method as the first parameter
                    if (i==0&&attr.NoMemoryBlock == false)
                    {
                        //False if not the first parameter
                        if (pinfo[i].ParameterType != typeof(MemoryBlock))
                        {
                            return false;
                        }
                        continue;
                    }
                    //All other parameters must be of type AsquellObj
                    if (pinfo[i].ParameterType != typeof(AsquellObj))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
