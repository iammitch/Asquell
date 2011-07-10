using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;

namespace Asquell.Invokables
{
    [AsquellClass(AccessibleName=null)]
    public static class MemoryAccess
    {
        [AsquellMethod(AccessibleName = "Set", Exposed = true, NoMemoryBlock = false)]
        public static void SetMemory(MemoryBlock memory, AsquellObj to, AsquellObj from)
        {
            memory.ModifyVariable(to, from);
        }
        [AsquellMethod(AccessibleName = "Delete", Exposed = true, NoMemoryBlock = false)]
        public static void DeleteMemory(MemoryBlock memory, AsquellObj block)
        {
            memory.DeleteVariable(block);
        }
        [AsquellMethod(AccessibleName = "Move", Exposed = true, NoMemoryBlock = false)]
        public static void MoveMemory(MemoryBlock memory, AsquellObj to, AsquellObj from)
        {
            if (from.Type == AsquellObjectType.RunTimeValue)
            {
                if (memory.VariableInMemory(from))
                {
                    AsquellObj rawValue = memory.GetRealVariable(from);
                    memory.ModifyVariable(to, rawValue);
                    memory.DeleteVariable(from);
                    return;
                }
                else
                {
                    throw new KeyNotFoundException("Can not find '"+from.Value.ToString()+"' in memory!");
                }
            }
            throw new ArgumentException("Invalid type for moving memory! First argument must be a variable!");
        }
        [AsquellMethod(AccessibleName = "MakeArray", Exposed = true, NoMemoryBlock = false)]
        public static void MakeArray(MemoryBlock memory, AsquellObj to, params AsquellObj[] values)
        {
            if (to.Type == AsquellObjectType.RunTimeValue)
            {
                ArrayObj array = new ArrayObj(values);
                memory.ModifyVariable(to, array.BaseObj);
                return;
            }
            throw new ArgumentException("Invalid type for modifying memory! First argument must be a variable!");
        }
    }
}
