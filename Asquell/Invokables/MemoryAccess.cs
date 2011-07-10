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
        public static void SetMemory(MemoryBlock memory, AsquellObj from, AsquellObj to)
        {
            memory.ModifyVariable(to, from);
        }
        [AsquellMethod(AccessibleName = "Delete", Exposed = true, NoMemoryBlock = false)]
        public static void DeleteMemory(MemoryBlock memory, AsquellObj block)
        {
            memory.DeleteVariable(block);
        }
        [AsquellMethod(AccessibleName = "Move", Exposed = true, NoMemoryBlock = false)]
        public static void MoveMemory(MemoryBlock memory, AsquellObj from, AsquellObj to)
        {
            if (from.Type == AsquellObjectType.RunTimeValue && to.Type == AsquellObjectType.RunTimeValue)
            {
                AsquellObj rawValue = memory.GetRealVariable(from);
                memory.ModifyVariable(to, rawValue);
                memory.DeleteVariable(from);
            }
        }
    }
}
